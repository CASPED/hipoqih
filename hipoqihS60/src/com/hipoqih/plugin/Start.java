package com.hipoqih.plugin;

import javax.microedition.midlet.*;
import javax.microedition.rms.*;
import javax.microedition.lcdui.*;
import com.hipoqih.plugin.MVC.*;

public class Start extends MIDlet implements CommandListener 
{
	private Command exitCommand;
	private Command goCommand;
	private Display display;

	public Start () throws Exception 
	{ 
		System.out.println("Empezamos");
		display = Display.getDisplay(this);
		MVCComponent.display = display;
		exitCommand = new Command("EXIT", Command.SCREEN, 2);
		goCommand = new Command("GO", Command.SCREEN, 1);
		State.user = getAppProperty("User");
		State.password = getAppProperty("Password");
	}

	public void startApp() 
	{
		try 
		{
			// Initialize any exisitng security info
			// that might be stored in RMS stores.
			this.loadConfiguration();
			
			// Other methods might use static secuirty info
			// without init UpdateToken object first.
			(new MainForm()).prepareScreen();
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
	    display.setCurrent(splash);
	}
	
	public void pauseApp() 
	{
	}
	 
	public void destroyApp(boolean unconditional) 
	{
	}

	public void commandAction(Command command, Displayable screen) 
	{
		if (command == exitCommand) 
		{
			destroyApp(false);
			notifyDestroyed();
	    } 
		else if (command == goCommand) 
		{ 
			// MainForm need to access life cycle and MIDlet methods
			MainForm.m = this;
			(new MainForm()).showScreen();
	    }
	}
	
	// Load stored state
	private void loadConfiguration() throws Exception
	{
		RecordStore recordStore = RecordStore.openRecordStore("hipoqih", true);
		// Enumerate records without filter nor order
		RecordEnumeration re = recordStore.enumerateRecords(null, null, false);
		while(re.hasNextElement())
		{
			int id = re.nextRecordId();
			byte[] record = re.nextRecord();
			processRecord(record, id);
		}
		recordStore.closeRecordStore();
	}
	
	private void processRecord(byte[] record, int typeId)
	{
		// Each record type has a different id
		switch(typeId)
		{
		case RecordTypes.ALERTHEIGHT:
			State.alertHeight = bytesToInteger(record);
			break;
		case RecordTypes.ALERTLEFT:
			State.alertLeft = bytesToInteger(record);
			break;
		case RecordTypes.ALERTTOP:
			State.alertTop = bytesToInteger(record);
			break;
		case RecordTypes.ALERTWIDTH:
			State.alertWidth = bytesToInteger(record);
			break;
		}
	}
	
	private int bytesToInteger(byte[] record)
	{
		int result;
		String s = new String(record, 0, record.length);
		try
		{
			result = Integer.parseInt(s);
		}
		catch(NumberFormatException nfe)
		{
			result = 0;
		}
		return result;
	}
}
