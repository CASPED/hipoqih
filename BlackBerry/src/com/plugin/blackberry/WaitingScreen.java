/*
 * WaitingScreen.java
 *
 * © <your company here>, 2003-2007
 * Confidential and proprietary.
 */

package com.ipoki.plugin.blackberry;

import net.rim.device.api.ui.*;
import net.rim.device.api.ui.component.*;
import net.rim.device.api.ui.container.*;

/**
 * This class will show a progress bar
 */
public class WaitingScreen extends PopupScreen
{
    private GaugeField _gauge;
    private int _gaugeValue = 1;
    
    public WaitingScreen() 
    {    
        super(new VerticalFieldManager(), Field.FOCUSABLE);
        _gauge = new GaugeField("Waiting", 1, 10, 1, GaugeField.LABEL_AS_PROGRESS);
        add(_gauge);
    }
    
    public void advanceGauge()
    {
        if (++_gaugeValue > 10)
            _gaugeValue = 1;
        
        _gauge.setValue(_gaugeValue);
    }
} 
