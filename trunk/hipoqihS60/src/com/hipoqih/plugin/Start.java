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
		System.out.println("Entrando en loadConfiguration");
		RecordStore recordStore = RecordStore.openRecordStore("hipoqih", true);
		
		if (recordStore.getNumRecords() == 0)
		{
			createConfiguration(recordStore);
		}
		// Enumerate records without filter nor order
		RecordEnumeration re = recordStore.enumerateRecords(null, null, false);
		while(re.hasNextElement())
		{
			byte[] record = re.nextRecord();
			int id = record[0];
			processRecord(record, id);
		}
		recordStore.closeRecordStore();
	}
	
	private void processRecord(byte[] record, int typeId)
	{
		System.out.println("Entrando en processRecord");

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
		String s = new String(record, 1, record.length - 1);
		try
		{
			result = Integer.parseInt(s);
		}
		catch(NumberFormatException nfe)
		{
			System.out.println(nfe.getMessage());
			nfe.printStackTrace();
			result = 0;
		}
		return result;
	}
	
	private void createConfiguration(RecordStore recordStore)
	{
		System.out.println("Entrando en createConfiguration");
		createRecord(recordStore, Integer.toString(State.alertHeight), RecordTypes.ALERTHEIGHT);
		createRecord(recordStore, Integer.toString(State.alertLeft), RecordTypes.ALERTLEFT);
		createRecord(recordStore, Integer.toString(State.alertTop), RecordTypes.ALERTTOP);
		createRecord(recordStore, Integer.toString(State.alertWidth), RecordTypes.ALERTWIDTH);
		String autoAlert = State.autoAlert ? "1" : "0";
		createRecord(recordStore, autoAlert, RecordTypes.AUTOALERT);
		createRecord(recordStore, State.latitude, RecordTypes.LATITUDE);
		createRecord(recordStore, State.longitude, RecordTypes.LONGITUDE);
		createRecord(recordStore, State.minutes, RecordTypes.MINUTES);
		createRecord(recordStore, State.password, RecordTypes.PASSWORD);
		createRecord(recordStore, State.positionSource, RecordTypes.POSITIONSOURCE);
		createRecord(recordStore, State.seconds, RecordTypes.SECONDS);
		createRecord(recordStore, State.user, RecordTypes.USER);
	}
	
	private void createRecord(RecordStore recordStore, String data, int recordType)
	{
		System.out.println("Entrando en createRecord: " + data + Integer.toString(recordType));
		int recordLength = 1;
		byte[] dataBytes = data.getBytes();
		
		if (data.length() > 0)
			recordLength = dataBytes.length + 1;
		
		System.out.println("longitud datos: " +Integer.toString(recordLength));
		byte[] record = new byte[recordLength]; 
		record[0] = (byte)recordType;
		for(int i = 1; i < recordLength; i++)
			record[i] = dataBytes[i-1];
		try
		{
			int id = recordStore.addRecord(record, 0, recordLength);
			System.out.println(Integer.toString(id));
		}
		catch(RecordStoreException rse)
		{
			System.out.println(rse.getMessage());
			rse.printStackTrace();
		}
	}
}
