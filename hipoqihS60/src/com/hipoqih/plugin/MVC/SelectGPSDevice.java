package com.hipoqih.plugin.MVC;

import javax.microedition.lcdui.*;

import com.hipoqih.plugin.gps.*;

public class SelectGPSDevice extends MVCComponent  
{
	private static Displayable screen = null; 
	private static List listDevices = null;
    private Command deviceSelection = new Command("Select", Command.SCREEN, 3);
    private BluetoothConnection bt = new BluetoothConnection();
    

    public static void setDevices(List ld)
    {
    	listDevices = ld;
    }

	public Displayable getScreen () 
	{
		return screen;
	}

	protected void initModel()
	{
		
	}
	
	public void commandAction(Command c, Displayable s) 
	{
		if (c == deviceSelection) 
		{
            bt.connectDevice(listDevices.getSelectedIndex());
            (new MainForm()).showScreen();
		}
	}
	
	protected void createView() throws Exception
	{
		if (listDevices == null)
		{
			screen = new List("Searching...", List.IMPLICIT);
		}	
		else
		{
			screen = listDevices;
		}
		screen.addCommand(deviceSelection);
	}
	
	protected void updateView() throws Exception 
	{
		createView();
	}
}
