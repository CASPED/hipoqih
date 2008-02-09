/*
 * Created by Javier Cancela
 * Copyright (C) 2007 hipoqih.com, All Rights Reserved.
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, If not, see <http://www.gnu.org/licenses/>.*/

// hash of com.ipoki.plugin.blackberry.user
// 0x57faa02a62ef6e45L
// hash of com.ipoki.plugin.blackberry.pass
// 0xe91da859a7ee3581L
// hash of com.ipoki.plugin.blackberry.freq
// 0x90b4a6286eb92c20L
package com.ipoki.plugin.blackberry;

import javax.microedition.rms.*;
import javax.microedition.location.*;
import net.rim.device.api.ui.*;
import net.rim.device.api.ui.container.*;
import net.rim.device.api.ui.component.*;
import net.rim.device.api.i18n.*;
import net.rim.device.api.system.*;
import net.rim.device.api.ui.text.*;
import com.ipoki.plugin.blackberry.resource.*;

public class IpokiPlugin  extends UiApplication implements IpokiPluginResource
{
    private IpokiMainScreen _mainScreen;
    private static int _interval = 1; //seconds - this is the period of position query

    PopupScreen _gaugeScreen;
    GaugeField _gauge;
    LabelField _label;
    private LocationProvider _locationProvider;    


    LabelField _lblStatus;
    LabelField _lblUser;
    LabelField _lblLongitude;
    LabelField _lblLatitude;
    
    static ResourceBundle _resources = ResourceBundle.getBundle(BUNDLE_ID, BUNDLE_NAME);
    static PersistentObject _userStore;
    static PersistentObject _passStore;
    static PersistentObject _freqStore;
    static String _idUser = "";
    static String _comment = "";
    static String _user;
    static String _pass;
    static int _freq;
    
    static 
    {
        _userStore = PersistentStore.getPersistentObject(0x57faa02a62ef6e45L);
        _passStore = PersistentStore.getPersistentObject(0xe91da859a7ee3581L);
        _freqStore = PersistentStore.getPersistentObject(0x90b4a6286eb92c20L);
        
        if(_userStore.getContents()!= null && _passStore.getContents()!= null && _freqStore.getContents()!= null)
        {
            _user = (String)_userStore.getContents();
            _pass = (String)_passStore.getContents();
            _freq = Integer.parseInt((String)_freqStore.getContents());
        }
        else
        {
            _user = "";
            _pass = "";
            _freq = 10;
        }
    }
    
    public void viewOptions()
    {
        SetupScreen setupScreen = new SetupScreen();
        pushScreen(setupScreen);
    }
    
    static void saveOptions(String user, String pass, String freq)
    {
        synchronized(_userStore)
        {
            _userStore.setContents(user);
            _userStore.commit();
            _user = user;
        }
        synchronized(_passStore)
        {
            _passStore.setContents(pass);
            _passStore.commit();
            _pass = pass;
        }
        synchronized(_freqStore)
        {
            _freqStore.setContents(freq);
            _freqStore.commit();
            _freq = Integer.parseInt(freq);
        }
    }
    
    private class SetupScreen extends MainScreen
    {
        private LabelField _userLabel;
        private EditField _userEdit;
        private LabelField _passLabel;
        private PasswordEditField _passEdit;
        private LabelField _freqLabel;
        private EditField _freqEdit;
        
        public SetupScreen() 
        {    
            _userLabel = new LabelField(IpokiPlugin._resources.getString(LBL_USER), DrawStyle.ELLIPSIS);
            add(_userLabel);
            _userEdit = new EditField("", IpokiPlugin._user, 20, Field.EDITABLE);
            add(_userEdit);
            _passLabel = new LabelField(IpokiPlugin._resources.getString(LBL_PASSWORD), DrawStyle.ELLIPSIS);
            add(_passLabel);
            _passEdit = new PasswordEditField("", IpokiPlugin._pass, 20, Field.EDITABLE);
            add(_passEdit);
            _freqLabel = new LabelField(IpokiPlugin._resources.getString(LBL_FREQ), DrawStyle.ELLIPSIS);
            add(_freqLabel);
            _freqEdit = new EditField("", String.valueOf(IpokiPlugin._freq), 20, Field.EDITABLE | EditField.FILTER_INTEGER);
            add(_freqEdit);
        }
        
        private MenuItem _cancel = new MenuItem(IpokiPlugin._resources, MNU_CANCEL,  300000, 10) {
            public void run()
            {
                 SetupScreen.this.close();
            }
        };  
        
        private MenuItem _save = new MenuItem(IpokiPlugin._resources, MNU_SAVE, 200000, 10) {
            public void run()
            {   
                IpokiPlugin.saveOptions(_userEdit.getText(), _passEdit.getText(), _freqEdit.getText());
                IpokiPlugin.this.popScreen(SetupScreen.this);
            }
        };
        
         
        protected void makeMenu( Menu menu, int instance )
        {
            menu.add(_save);
            menu.add(_cancel);
            
            super.makeMenu(menu, instance);
        }
    }

    
    StatusThread _statusThread = new StatusThread();
    ConnectionThread _connectionThread = new ConnectionThread();
    ListenThread _listenThread = new ListenThread();
    
    // App entry point
    public static void main(String[] args)
    {
        IpokiPlugin app = new IpokiPlugin();
        app.enterEventDispatcher();
    }
    
    public IpokiPlugin()
    {
        _mainScreen = new IpokiMainScreen();
        _label = new LabelField("");
        _mainScreen.add(_label);
        
        //start the helper threads
        _statusThread.start();
        _connectionThread.start();
        _listenThread.start();
        
        pushScreen(_mainScreen);

        if (_user == "")
        {
            SetupScreen setupScreen = new SetupScreen();
            pushScreen(setupScreen);
        }
        
        if (startLocationUpdate())
        {
        }
    }
    
    private boolean startLocationUpdate()
    {
        boolean retval = false;
        
        try 
        {
            _locationProvider = LocationProvider.getInstance(null);
            
            if ( _locationProvider == null ) 
            {
                // We would like to display a dialog box indicating that GPS isn't supported, but because
                // the event-dispatcher thread hasn't been started yet, modal screens cannot be pushed onto
                // the display stack.  So delay this operation until the event-dispatcher thread is running
                // by asking it to invoke the following Runnable object as soon as it can.
                Runnable showGpsUnsupportedDialog = new Runnable() 
                {
                    public void run() 
                    {
                        Dialog.alert("GPS is not supported on this platform, exiting...");
                        System.exit( 1 );
                    }
                };
                invokeLater( showGpsUnsupportedDialog );  // ask event-dispatcher thread to display dialog ASAP
            } else 
            {
                // only a single listener can be associated with a provider, and unsetting it involves the same
                // call but with null, therefore, no need to cache the listener instance
                // request an update every second
                _locationProvider.setLocationListener(new LocationListenerImpl(), _interval, 1, 1);
                retval = true;
            }
        } catch (LocationException le) {
            System.err.println("Failed to instantiate the LocationProvider object, exiting...");
            System.err.println(le); 
            System.exit(0);
        }        
        return retval;
    }
    
    private class LocationListenerImpl implements LocationListener
    {
        //members --------------------------------------------------------------
        private int captureCount;
        private int sendCount;
        
        //methods --------------------------------------------------------------
        public void locationUpdated(LocationProvider provider, Location location)
        {
            if(location.isValid())
            {
                double longitude = location.getQualifiedCoordinates().getLongitude();
                double latitude = location.getQualifiedCoordinates().getLatitude();
                float altitude = location.getQualifiedCoordinates().getAltitude();
                float speed = location.getSpeed();                
                
                UpdateLocation(String.valueOf(longitude), String.valueOf(latitude));
            }
        }
  
        public void providerStateChanged(LocationProvider provider, int newState)
        {
            //no-op
        }        
    }
    
    private void UpdateLocation(final String longitude, final String latitude)
    {
        invokeLater(new Runnable() 
        {
            public void run()
            {
                _lblLongitude.setText(longitude);
                _lblLatitude.setText(latitude);
            }
        });    
    }
    
    public void connect()
    {
        _gaugeScreen = new PopupScreen(new VerticalFieldManager());
        _gauge = new GaugeField("Connecting...", 0, 9, 0, GaugeField.LABEL_AS_PROGRESS);
        _gaugeScreen.add(_gauge);
        _connectionThread.signIn(_user, _pass);
        //_statusThread.go();
        _listenThread.go();
        //pushScreen(_gaugeScreen);
    }
    
    public void updateGauge(final int i)
    {
        UiApplication.getUiApplication().invokeLater(new Runnable() {
            public void run()
            {
                _gauge.setValue(i);
            }
        });
    }
    
    public void updateContent(final String message)
    {
        UiApplication.getUiApplication().invokeLater(new Runnable() {
            public void run()
            {
                if (_gaugeScreen.isDisplayed())
                {
                    popScreen(_gaugeScreen);
                }
                _label.setText(message);
            }
        });        
    }
} 


