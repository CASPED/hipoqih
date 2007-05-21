package com.hipoqih.plugin.task;

import javax.microedition.lcdui.*;
import com.hipoqih.plugin.MVC.*;
import com.hipoqih.plugin.gps.*;

public class SelectGPSDeviceTask extends BackgroundTask 
{
	private BluetoothConnection bt = new BluetoothConnection();
	private GPS gps = new GPS(bt);
	
	public SelectGPSDeviceTask (Display d) throws Exception 
	{
		super (d);
		MainForm.setGPS(gps);
		prevScreen = (new MainForm()).prepareScreen();
	}
	
	public void runTask () throws Exception
	{
		bt.searchDevices();
		SelectGPSDevice.setDevices(bt.getDevicesList());
		nextScreen = (new SelectGPSDevice()).prepareScreen();
	}
}
