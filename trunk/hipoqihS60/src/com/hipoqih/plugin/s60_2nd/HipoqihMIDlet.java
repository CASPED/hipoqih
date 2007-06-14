package com.hipoqih.plugin.s60_2nd;

import com.hipoqih.plugin.*;
import com.hipoqih.plugin.s60_2nd.gps.BluetoothConnection;
import com.hipoqih.plugin.s60_2nd.gps.GPS;

import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;

/**
 * @author Xavi
 *
 */
public class HipoqihMIDlet extends MIDlet implements CommandListener, MIDletExiter
{
	private Command exitCommand;
	private Command goCommand;
	private Command deviceSelection;
    private final static String UUID = "40385A09EF46BCC09AAD8300CFAF611D";

	public HipoqihMIDlet () throws Exception 
	{ 
		State.display = Display.getDisplay(this);
		exitCommand = new Command("EXIT", Command.SCREEN, 2);
		goCommand = new Command("GO", Command.SCREEN, 1);
	}
	
	public void startApp() 
	{
		try 
		{
			// Initialize any exisitng security info
			// that might be stored in RMS stores.
			State.getInstance().loadConfiguration();
	    } 
		catch (Exception e) 
	    {
	      e.printStackTrace();
	    }

	    SplashScreen splash = new SplashScreen ();
	    splash.addCommand(exitCommand);
	    splash.addCommand(goCommand);
	    splash.setFullScreenMode(true);
	    splash.setCommandListener( (CommandListener) this);
	    State.display.setCurrent(splash);
	}
	
	public void exit()
	{
		destroyApp(false);
	    notifyDestroyed();
	}

	public void notifyBTProblem(String message)
	{
		Alert alert = new Alert("Error");
		alert.setString(message);
		State.display.setCurrent(alert);
	}
	
	public void pauseApp() 
	{
	}
	 
	public void destroyApp(boolean unconditional) 
	{
		try
		{
			State.recordStore.closeRecordStore();
		}
		catch(Exception e)
		{
			e.printStackTrace();
		}
	}

	/**
	 * 
	 */
	public void commandAction(Command command, Displayable screen) 
	{
		if (command == exitCommand) 
		{
			destroyApp(false);
			notifyDestroyed();
	    }
		else if (command == goCommand) 
		{
			BluetoothConnection bt = new BluetoothConnection();
			bt.searchDevices();
			List listDevices = bt.getDevicesList();
			deviceSelection = new Command("Select", Command.SCREEN, 3);
			listDevices.addCommand(deviceSelection);
			listDevices.setCommandListener(this);
	        State.display.setCurrent(listDevices);
			
		}		
	}
	
	public void serviceSearchCompleted(int transID, int respCode)
	{
		
	}
}
