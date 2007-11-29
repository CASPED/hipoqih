/*
 * MainScreen.java
 *
 * © <your company here>, 2003-2007
 * Confidential and proprietary.
 */

package com.ipoki.plugin.blackberry;

import net.rim.device.api.ui.*;
import net.rim.device.api.ui.component.*;
import net.rim.device.api.ui.container.*;
import net.rim.device.api.i18n.*;
import com.ipoki.plugin.blackberry.resource.*;

final class IpokiMainScreen extends MainScreen implements IpokiPluginResource
{
    static ResourceBundle _resources = ResourceBundle.getBundle(BUNDLE_ID, BUNDLE_NAME);
    
    IpokiPlugin _app;
    LabelField _lblStatus;

    public IpokiMainScreen()
    {
        super(DEFAULT_MENU | DEFAULT_CLOSE);
        setTitle(_resources.getString(APP_TITLE));
        _app = (IpokiPlugin)UiApplication.getUiApplication();
        _lblStatus = new LabelField(_resources.getString(LBL_DISCONNECTED));
        add(_lblStatus);
    }
    
    public void makeMenu(Menu menu, int instance)
    {
        menu.add(invokeConnect);
        menu.addSeparator();
        menu.add(invokeMap);
        menu.add(invokeFriends);
        menu.addSeparator();
        menu.add(invokePositionLog);
        menu.add(invokeOptions);
        menu.add(invokeAbout);
        menu.addSeparator();
        menu.add(invokeClose);
    }
    
    MenuItem invokeConnect  = new MenuItem(_resources.getString(MNU_CONNECT),0,0)
    {
        public void run()
        {
            _app.connect();
            
        }        
    };    

    MenuItem invokeMap  = new MenuItem(_resources.getString(MNU_MAP),0,0)
    {
        public void run()
        {
        }        
    };    

    MenuItem invokeFriends  = new MenuItem(_resources.getString(MNU_FRIENDS),0,0)
    {
        public void run()
        {
        }        
    };    

    MenuItem invokePositionLog  = new MenuItem(_resources.getString(MNU_POSITION_LOG_ON),0,0)
    {
        public void run()
        {
        }        
    };    

    MenuItem invokeOptions  = new MenuItem(_resources.getString(MNU_OPTIONS),0,0)
    {
        public void run()
        {
        }        
    };    
    
    MenuItem invokeAbout  = new MenuItem(_resources.getString(MNU_ABOUT),0,0)
    {
        public void run()
        {
        }        
    };    

    MenuItem invokeClose = new MenuItem(_resources.getString(MNU_CLOSE),0,0)
    {
        public void run()
        {
            onClose();
        }        
    };    
}

