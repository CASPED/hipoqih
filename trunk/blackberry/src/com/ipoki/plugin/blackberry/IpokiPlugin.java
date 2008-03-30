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

import org.xml.sax.*;
import org.w3c.dom.*;
import java.io.*;
import javax.microedition.io.*;
import javax.microedition.rms.*;
import javax.microedition.location.*;
import net.rim.device.api.ui.*;
import net.rim.device.api.system.*;
import net.rim.device.api.ui.container.*;
import net.rim.device.api.ui.component.*;
import net.rim.device.api.i18n.*;
import net.rim.device.api.system.*;
import net.rim.device.api.ui.text.*;
import net.rim.device.api.xml.parsers.*;
import net.rim.device.api.util.*;
import com.ipoki.plugin.blackberry.resource.*;

public class IpokiPlugin  extends UiApplication implements IpokiPluginResource
{
    IpokiMainScreen _mainScreen;

    PopupScreen _gaugeScreen;
    GaugeField _gauge;
    LabelField _label;
    LocationProvider _locationProvider;    
    String _lastMessageSent = "";
    String _messageToSend = "";


    LabelField _lblStatus;
    LabelField _lblUser;
    LabelField _lblLongitude;
    LabelField _lblLatitude;
    LabelField _lblCommentSent;
    
    static int _interval = 1; //seconds - this is the period of position query
    static ResourceBundle _resources = ResourceBundle.getBundle(BUNDLE_ID, BUNDLE_NAME);
    static PersistentObject _userStore;
    static PersistentObject _passStore;
    static PersistentObject _freqStore;
    static String _idUser = "";
    static String _comment = "";
    static String _user;
    static String _pass;
    static int _freq;
    static boolean _isConnected = false;
    
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
    
    public void Test1()
    {
    	_listenThread.pause();
        Test1Screen sc = new Test1Screen(this._lblLatitude.getText(), this._lblLongitude.getText());
        pushScreen(sc);
    	_listenThread.go();
    }
    
    public void Test2()
    {
        Test2Screen sc = new Test2Screen();
        pushScreen(sc);
    }

    public void Test3()
    {
        Test3Screen sc = new Test3Screen();
        pushScreen(sc);
    }

    public void viewOptions()
    {
        SetupScreen setupScreen = new SetupScreen();
        pushScreen(setupScreen);
    }
    
    public void sendMessage()
    {
        MessageScreen messageScreen = new MessageScreen(_lastMessageSent);
        pushScreen(messageScreen);
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
    
    private class Test1Screen extends MainScreen
    {
        private int _zoom = 3;
        private String _latitude;
        private String _longitude;
        private String _width;
        private String _height;
        private EditField _urlLabel;
        
        public Test1Screen(String latitude, String longitude) 
        {
            _latitude = latitude.substring(0, 6);
            _longitude = longitude.substring(0, 6);
            
            _width = Integer.toString(Graphics.getScreenWidth());
            _height = Integer.toString(Graphics.getScreenHeight());
            _urlLabel = new EditField();
            add(_urlLabel);

            invokeLater(new Runnable() 
            {
                public void run()
                {
                    showMap();
                }
            });
        }
        
        private void showMap()
        {
            StreamConnection s = null;
            try
            {
                String url = getUrl(_latitude, _longitude, _width, _height, Integer.toString(_zoom));
                s = (StreamConnection)Connector.open(url);
                HttpConnection httpConn = (HttpConnection)s;
                httpConn.setRequestProperty("User-Agent", "IpokiPlugin/BlackBerry/0.1");
                
                int status = httpConn.getResponseCode();
                if (status == HttpConnection.HTTP_OK)
                {
                    try
                    {
                        DocumentBuilder doc = DocumentBuilderFactory.newInstance().newDocumentBuilder(); 
                        DataInputStream dis = s.openDataInputStream();
                        Document d = doc.parse(dis);
                        Element el = d.getDocumentElement();
                        url = el.getFirstChild().getNodeValue() + ";deviceside=true";
                        dis.close();
                    }
                    catch(SAXException e)
                    {
                        System.err.println(e.toString());
                    }
                    catch(ParserConfigurationException e)
                    {
                        System.err.println(e.toString());
                    }
                }
                
                _urlLabel.setText(url);
                
                s.close();                
            }
            catch (java.io.IOException e) 
            {
                System.err.println(e.toString());
            }
            catch(Exception e)
            {
                System.err.println(e.toString());
            }
        }
        
        private String getUrl(String latitude, String longitude, String width, String height, String zoom)
        {
            String url = "http://local.yahooapis.com/MapsService/V1/mapImage?appid=08REOqLV34HybSt1yvZRY7DcL5hbUGyaFpRP.hsVJve.01qb6KWXP78TmIPi_w--" + 
                    "&latitude=" + latitude + 
                    "&longitude=" + longitude + 
                    "&image_height=" + 32 + 
                    "&image_width=" + 32 + 
                    "&zoom=" + zoom;
            return url + ";deviceside=true";
        }
        

        protected void makeMenu( Menu menu, int instance )
        {
            super.makeMenu(menu, instance);
        }
    }
    
    
    private class Test2Screen extends MainScreen
    {
        private BitmapField _mapField;
        
        public Test2Screen() 
        {
            _mapField = new BitmapField();
            add(_mapField);

            invokeLater(new Runnable() 
            {
                public void run()
                {
                    showMap();
                }
            });
        }
        
        private void showMap()
        {
        	InputStream input = null;
        	byte[] data = new byte[3771];
        	try
        	{
                _mapField.setBitmap(Bitmap.getBitmapResource("mapimage.png"));
                this.invalidate();
        	}
        	catch(IllegalArgumentException e)
        	{
        		System.err.println(e.toString());
        	}
        	
        	/*StreamConnection s = null;
            try
            {
               String url = "http://gws.maps.yahoo.com/mapimage?MAPDATA=EPR93.d6wXUKRCCveKnn9tCtml6zw_1C8IoE9yD6z027KI6tiuJBU8wLpcmsQTngCg2Egz1hFeyISUfINW1xFY8h6gz3KNJh_w0zDzR3o7RUqJNwLJEdLqWVPNd9NTM2PPSrFE1nidB9L1B5pw--&mvt=m?cltype=onnetwork&.intl=us;deviceside=true";
                
                s = (StreamConnection)Connector.open(url);
                HttpConnection httpConn = (HttpConnection)s;
                httpConn.setRequestProperty("User-Agent", "IpokiPlugin/BlackBerry/0.1");
                
                int status = httpConn.getResponseCode();
                if (status == HttpConnection.HTTP_OK)
                {
                    java.io.InputStream input = s.openInputStream();
                    byte[] data = new byte[1];
                    ByteVector bv = new ByteVector();
                    while ( -1 != input.read(data) )
                    {
                        bv.addElement(data[0]);
                    }                    
                    try
                    {
                        _mapField.setBitmap(Bitmap.createBitmapFromPNG(bv.getArray(), 0, -1));
                        this.invalidate();
                    }
                    catch(Exception e)
                    {
                        System.err.println(e.toString());
                    }
                    input.close();
                }
                s.close();                
            }
            catch (java.io.IOException e) 
            {
                System.err.println(e.toString());
            }
            catch(Exception e)
            {
                System.err.println(e.toString());
            }*/
        }
        
        protected void makeMenu( Menu menu, int instance )
        {
            super.makeMenu(menu, instance);
        }

    }
    
    private class Test3Screen extends MainScreen
    {
        private BitmapField _mapField;
        
        public Test3Screen() 
        {
            _mapField = new BitmapField();
            add(_mapField);

            invokeLater(new Runnable() 
            {
                public void run()
                {
                    showMap();
                }
            });
        }
        
        private void showMap()
        {
            StreamConnection s = null;
            try
            {
                String url = "http://gws.maps.yahoo.com/mapimage?MAPDATA=EPR93.d6wXUKRCCveKnn9tCtml6zw_1C8IoE9yD6z027KI6tiuJBU8wLpcmsQTngCg2Egz1hFeyISUfINW1xFY8h6gz3KNJh_w0zDzR3o7RUqJNwLJEdLqWVPNd9NTM2PPSrFE1nidB9L1B5pw--&mvt=m?cltype=onnetwork&.intl=us;deviceside=true";
                
                s = (StreamConnection)Connector.open(url);
                HttpConnection httpConn = (HttpConnection)s;
                httpConn.setRequestProperty("User-Agent", "IpokiPlugin/BlackBerry/0.1");
                
                int status = httpConn.getResponseCode();
                if (status == HttpConnection.HTTP_OK)
                {
                    java.io.InputStream input = s.openInputStream();
                    byte[] data = new byte[5000];
                    //ByteVector bv = new ByteVector();
                    while ( -1 != input.read(data) )
                    {
                        //bv.addElement(data[0]);
                        
                    }
                    try
                    {
                        //_mapField.setBitmap(Bitmap.createBitmapFromPNG(bv.getArray(), 0, -1));
                        _mapField.setBitmap(Bitmap.createBitmapFromPNG(data, 0, -1));
                        this.invalidate();
                    }
                    catch(Exception e)
                    {
                        System.err.println(e.toString());
                    }
                    input.close();
                }
                s.close();                
            }
            catch (java.io.IOException e) 
            {
                System.err.println(e.toString());
            }
            catch(Exception e)
            {
                System.err.println(e.toString());
            }
        }
        
        protected void makeMenu( Menu menu, int instance )
        {
            super.makeMenu(menu, instance);
        }

    }
    
    private class MapScreen extends MainScreen
    {
        private int _zoom = 3;
        private String _latitude;
        private String _longitude;
        private String _width;
        private String _height;
        private BitmapField _mapField;
        
        public MapScreen(String latitude, String longitude) 
        {
            _latitude = latitude.substring(0, 6);
            _longitude = longitude.substring(0, 6);
            
            _width = Integer.toString(Graphics.getScreenWidth());
            _height = Integer.toString(Graphics.getScreenHeight());
            _mapField = new BitmapField();
            add(_mapField);

            invokeLater(new Runnable() 
            {
                public void run()
                {
                    showMap();
                }
            });
        }
        
        private void showMap()
        {
            StreamConnection s = null;
            try
            {
                String url = getUrl(_latitude, _longitude, _width, _height, Integer.toString(_zoom));
                s = (StreamConnection)Connector.open(url);
                HttpConnection httpConn = (HttpConnection)s;
                httpConn.setRequestProperty("User-Agent", "IpokiPlugin/BlackBerry/0.1");
                
                int status = httpConn.getResponseCode();
                if (status == HttpConnection.HTTP_OK)
                {
                    try
                    {
                        DocumentBuilder doc = DocumentBuilderFactory.newInstance().newDocumentBuilder(); 
                        DataInputStream dis = s.openDataInputStream();
                        Document d = doc.parse(dis);
                        Element el = d.getDocumentElement();
                        url = el.getFirstChild().getNodeValue() + ";deviceside=true";
                        dis.close();
                    }
                    catch(SAXException e)
                    {
                        System.err.println(e.toString());
                    }
                    catch(ParserConfigurationException e)
                    {
                        System.err.println(e.toString());
                    }
                }
                
                s = (StreamConnection)Connector.open(url);
                httpConn = (HttpConnection)s;
                httpConn.setRequestProperty("User-Agent", "IpokiPlugin/BlackBerry/0.1");
                
                status = httpConn.getResponseCode();
                if (status == HttpConnection.HTTP_OK)
                {
                    java.io.InputStream input = s.openInputStream();
                    byte[] data = new byte[1];
                    ByteVector bv = new ByteVector();
                    while ( -1 != input.read(data) )
                    {
                        bv.addElement(data[0]);
                    }
                    try
                    {
                        _mapField.setBitmap(Bitmap.createBitmapFromPNG(bv.getArray(), 0, -1));
                        this.invalidate();
                    }
                    catch(Exception e)
                    {
                        System.err.println(e.toString());
                    }
                    input.close();
                }
                s.close();                
            }
            catch (java.io.IOException e) 
            {
                System.err.println(e.toString());
            }
            catch(Exception e)
            {
                System.err.println(e.toString());
            }
        }
        
        private String getUrl(String latitude, String longitude, String width, String height, String zoom)
        {
            String url = "http://local.yahooapis.com/MapsService/V1/mapImage?appid=08REOqLV34HybSt1yvZRY7DcL5hbUGyaFpRP.hsVJve.01qb6KWXP78TmIPi_w--" + 
                    "&latitude=" + latitude + 
                    "&longitude=" + longitude + 
                    "&image_height=" + 32 + 
                    "&image_width=" + 32 + 
                    "&zoom=" + zoom;
            return url + ";deviceside=true";
        }
        
        private MenuItem _zoomIn = new MenuItem(IpokiPlugin._resources, MNU_ZOOMIN, 200000, 10) {
            public void run()
            {   
                if (_zoom > 1)
                {
                    _zoom --;
                    invokeLater(new Runnable() 
                    {
                        public void run()
                        {
                            showMap();
                        }
                    });
                }
            }
        };
        
        private MenuItem _zoomOut = new MenuItem(IpokiPlugin._resources, MNU_ZOOMOUT, 200000, 10) {
            public void run()
            {
                if (_zoom < 12)
                {
                    _zoom ++;
                    invokeLater(new Runnable() 
                    {
                        public void run()
                        {
                            showMap();
                        }
                    });
                }   
            }
        };
        
        protected void makeMenu( Menu menu, int instance )
        {
            menu.add(_zoomIn);
            menu.add(_zoomOut);
            
            super.makeMenu(menu, instance);
        }

    }
    
    private class MessageScreen extends MainScreen
    {
        private LabelField _messageLabel;
        private EditField _messageEdit;
        private LabelField _lastLabel;
        private LabelField _lastMessageLabel;
        
        public MessageScreen(String last) 
        {    
            _messageLabel = new LabelField(IpokiPlugin._resources.getString(LBL_MESSAGE), DrawStyle.ELLIPSIS);
            Font font = _messageLabel.getFont();
            Font newFont = font.derive(Font.BOLD);
            _messageLabel.setFont(newFont);
            add(_messageLabel);
            _messageEdit = new EditField("", "", 144, Field.EDITABLE);
            add(_messageEdit);
            _lastLabel = new LabelField(IpokiPlugin._resources.getString(LBL_LAST_MESSAGE), DrawStyle.ELLIPSIS);
            font = _lastLabel.getFont();
            newFont = font.derive(Font.BOLD);
            _lastLabel.setFont(newFont);
            add(_lastLabel);
            _lastMessageLabel = new LabelField(last, DrawStyle.ELLIPSIS);
            add(_lastMessageLabel);
        }
        
        private MenuItem _cancel = new MenuItem(IpokiPlugin._resources, MNU_CANCEL,  300000, 10) {
            public void run()
            {
                 MessageScreen.this.close();
            }
        };  
        
        private MenuItem _send = new MenuItem(IpokiPlugin._resources, MNU_SEND, 200000, 10) {
            public void run()
            {   
                _messageToSend = _messageEdit.getText();
                MessageScreen.this.close();
            }
        };
        
        protected void makeMenu( Menu menu, int instance )
        {
            menu.add(_send);
            menu.add(_cancel);
            
            super.makeMenu(menu, instance);
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
                invokeLater(new Runnable() 
                {
                    public void run()
                    {
                        _lblUser.setText(_userEdit.getText());
                    }
                });    
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
        _gaugeScreen = new PopupScreen(new VerticalFieldManager());
        _gauge = new GaugeField("", 0, 9, 0, GaugeField.LABEL_AS_PROGRESS);
        _gaugeScreen.add(_gauge);

        
        //start the helper threads
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
    
    public void showMap()
    {
    	_listenThread.pause();
        MapScreen mapScreen = new MapScreen(this._lblLatitude.getText(), this._lblLongitude.getText());
        pushScreen(mapScreen);
        _listenThread.go();
    }
    
    public void showAbout()
    {
        Bitmap bitmap = Bitmap.getBitmapResource("ipokito.png");
        Dialog about = new Dialog(Dialog.D_OK, "Ipoki Plugin for BlackBerry", 0, bitmap, 0);
        LabelField text1 = new LabelField("Ipoki Technologies S.L.");
        about.add(text1);
        pushScreen(about);
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
            } 
            else 
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
        //_gauge.setValue(0);
        _connectionThread.signIn(_user, _pass);
        //_statusThread.go();
        //pushScreen(_gaugeScreen);
    }
    
    public void disconnect()
    {
        if (!_idUser.equals(""))
        {
            //_gauge.setValue(0);
            //_statusThread.go();
            //pushScreen(_gaugeScreen);
            pauseListenThread();
            _connectionThread.signout(_idUser);
        }
    }
    
    public void pauseListenThread()
    {
        _listenThread.pause();
        try 
        {
            synchronized(_listenThread)
            {
                //Check the paused condition, incase the notify fires prior to our wait, in which case we may never see that nofity
                while ( !_listenThread.isPaused() )
                {
                    _listenThread.wait();
                }
            }
        } 
        catch (InterruptedException e) 
        {
            System.err.println(e.toString());
        }
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
} 


