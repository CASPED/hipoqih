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

package com.ipoki.plugin.blackberry;

import net.rim.device.api.ui.*;
import net.rim.device.api.ui.component.*;
import net.rim.device.api.ui.container.*;
import net.rim.device.api.i18n.*;
import com.ipoki.plugin.blackberry.resource.*;

class IpokiPlugin  extends UiApplication
{
    // App entry point
    public static void main(String[] args)
    {
        IpokiPlugin app = new IpokiPlugin();
        app.enterEventDispatcher();
    }
    
    public IpokiPlugin()
    {
        IpokiPluginScreen screen = new IpokiPluginScreen();
        pushScreen(screen);
    }
} 

final class IpokiPluginScreen extends MainScreen implements IpokiPluginResource
{
    static ResourceBundle _resources = ResourceBundle.getBundle(BUNDLE_ID, BUNDLE_NAME);
    
    IpokiPlugin _app;
    LabelField _lblStatus;
    LabelField _lblSpeed;
    LabelField _lblHeigh;

    public IpokiPluginScreen()
    {
        super(DEFAULT_MENU | DEFAULT_CLOSE);
        setTitle(_resources.getString(APP_TITLE));
        _app = (IpokiPlugin)UiApplication.getUiApplication();
        _lblStatus = new LabelField(_resources.getString(LBL_DISCONNECTED));
        add(_lblStatus);
        _lblSpeed = new LabelField("22.0 km/h");
        add(_lblSpeed);
        _lblHeigh = new LabelField("0023 m");
        add(_lblHeigh);
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
        }        
    };    
}

