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
import net.rim.device.api.ui.container.*;
import net.rim.device.api.ui.component.*;
import net.rim.device.api.i18n.*;
import com.ipoki.plugin.blackberry.resource.*;

public class IpokiPlugin  extends UiApplication
{
    private IpokiMainScreen _mainScreen;
    
    PopupScreen _gaugeScreen;
    GaugeField _gauge;
    LabelField _label;
    
    StatusThread _statusThread = new StatusThread();
    ConnectionThread _connectionThread = new ConnectionThread();
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
        
        pushScreen(_mainScreen);
    }
    
    public void connect()
    {
        _gaugeScreen = new PopupScreen(new VerticalFieldManager());
        _gauge = new GaugeField("Connecting...", 0, 9, 0, GaugeField.LABEL_AS_PROGRESS);
        _gaugeScreen.add(_gauge);
        _connectionThread.connect();
        _statusThread.go();
        pushScreen(_gaugeScreen);
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


