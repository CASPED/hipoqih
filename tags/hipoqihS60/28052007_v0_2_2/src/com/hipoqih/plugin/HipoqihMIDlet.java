package com.hipoqih.plugin;



import javax.microedition.midlet.*;
import javax.microedition.rms.*;
import javax.microedition.lcdui.*;

import com.hipoqih.plugin.UI.*;
import com.hipoqih.plugin.gps.*;

public class HipoqihMIDlet extends MIDlet implements CommandListener, ProviderStatusListener
{
	private Command exitCommand;
	private Command goCommand;
	private static Display display;
    private Object mutex = new Object();
    private HipoqihData data = null;

	public HipoqihMIDlet () throws Exception 
	{ 
		display = Display.getDisplay(this);
		exitCommand = new Command("EXIT", Command.SCREEN, 2);
		goCommand = new Command("GO", Command.SCREEN, 1);
	}
	
	public static Display getDisplay()
	{
		return display;
	}
 
	public void startApp() 
	{
		try 
		{
			// Initialize any exisitng security info
			// that might be stored in RMS stores.
			this.loadConfiguration();
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
		try
		{
			State.recordStore.closeRecordStore();
		}
		catch(Exception e)
		{
			e.printStackTrace();
		}
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
	        if (ConfigurationProvider.isLocationApiSupported())
	        {
	            ConfigurationProvider.getInstance().autoSearch(this);
	        }
	        else
	        {
	            Alert alert = new Alert("Error",
	                    "Location API not supported!", null,
	                    AlertType.ERROR);
	            display.setCurrent(alert);
	        }

			// MainFormUI need to access life cycle and MIDlet methods
			MainFormUI.m = this;
	    }
	}
	
	// Load stored state
	private void loadConfiguration() throws Exception
	{
		State.recordStore = RecordStore.openRecordStore("hipoqih", true);
		
		if (State.recordStore.getNumRecords() == 0)
		{
			createConfiguration(State.recordStore);
		}
		// Enumerate records without filter nor order
		RecordEnumeration re = State.recordStore.enumerateRecords(null, null, false);
		while(re.hasNextElement())
		{
			int id = re.nextRecordId();
			byte[] record = State.recordStore.getRecord(id);
			int typeId = record[0];
			processRecord(record, typeId);
			State.recordMaps.put(new Integer(typeId), new Integer(id));
		}
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
		case RecordTypes.AUTOALERT:
			State.autoAlert = bytesToBoolean(record);
			break;
		case RecordTypes.LATITUDE:
			State.latitude = new String(record, 1, record.length - 1);
			break;
		case RecordTypes.LONGITUDE:
			State.longitude = new String(record, 1, record.length - 1);
			break;
		case RecordTypes.MAPALERT:
			State.mapAlert = bytesToBoolean(record);
			break;
		case RecordTypes.MINUTES:
			State.minutes = new String(record, 1, record.length - 1);
			break;
		case RecordTypes.PASSWORD:
			State.password = new String(record, 1, record.length - 1);
			break;
		case RecordTypes.POSITIONSOURCE:
			State.positionSource = new String(record, 1, record.length - 1);
			break;
		case RecordTypes.SECONDS:
			State.seconds = new String(record, 1, record.length - 1);
			break;
		case RecordTypes.URLMAPALERT:
			State.urlMapAlert = bytesToBoolean(record);
			break;
		case RecordTypes.USER:
			State.user = new String(record, 1, record.length - 1);
			break;
		}
	}
	
	private boolean bytesToBoolean(byte[] record)
	{
		String s = new String(record, 1, record.length - 1);
		return s.equals("1");
	}
	
	private int bytesToInteger(byte[] record)
	{
		int result = 0;
		String s = new String(record, 1, record.length - 1);
		try
		{
			result = Integer.parseInt(s);
		}
		catch(NumberFormatException nfe)
		{
			System.out.println(nfe.getMessage());
			nfe.printStackTrace();
		}
		return result;
	}
	
	private void createConfiguration(RecordStore recordStore)
	{
		createRecord(recordStore, Integer.toString(State.alertHeight), RecordTypes.ALERTHEIGHT);
		createRecord(recordStore, Integer.toString(State.alertLeft), RecordTypes.ALERTLEFT);
		createRecord(recordStore, Integer.toString(State.alertTop), RecordTypes.ALERTTOP);
		createRecord(recordStore, Integer.toString(State.alertWidth), RecordTypes.ALERTWIDTH);
		String autoAlert = State.autoAlert ? "1" : "0";
		createRecord(recordStore, autoAlert, RecordTypes.AUTOALERT);
		createRecord(recordStore, State.latitude, RecordTypes.LATITUDE);
		createRecord(recordStore, State.longitude, RecordTypes.LONGITUDE);
		String mapAlert = State.mapAlert ? "1" : "0";
		createRecord(recordStore, mapAlert, RecordTypes.MAPALERT);
		createRecord(recordStore, State.minutes, RecordTypes.MINUTES);
		createRecord(recordStore, State.password, RecordTypes.PASSWORD);
		createRecord(recordStore, State.positionSource, RecordTypes.POSITIONSOURCE);
		createRecord(recordStore, State.seconds, RecordTypes.SECONDS);
		String urlMapAlert = State.urlMapAlert ? "1" : "0";
		createRecord(recordStore, urlMapAlert, RecordTypes.URLMAPALERT);
		createRecord(recordStore, State.user, RecordTypes.USER);
	}
	
	private void createRecord(RecordStore recordStore, String data, int recordType)
	{
		int recordLength = 1;
		byte[] dataBytes = data.getBytes();
		
		if (data.length() > 0)
			recordLength = dataBytes.length + 1;
		
		byte[] record = new byte[recordLength]; 
		record[0] = (byte)recordType;
		for(int i = 1; i < recordLength; i++)
			record[i] = dataBytes[i-1];
		try
		{
			recordStore.addRecord(record, 0, recordLength);
		}
		catch(RecordStoreException rse)
		{
			System.out.println(rse.getMessage());
			rse.printStackTrace();
		}
	}
	
    public void providerSelectedEvent()
    {
        // Attempt to acquire the mutex
        synchronized (mutex)
        {
            // Start scanning location updates. Also set the TouristData
            // reference data.
            Gauge indicator = new Gauge(null, false, 50, 1);
            indicator.setValue(Gauge.CONTINUOUS_RUNNING);

            Alert alert = new Alert("Information",
                    "Please wait, looking for location data....", null,
                    AlertType.INFO);
            alert.setIndicator(indicator);

            display.setCurrent(alert);

            // Inform the user that MIDlet is looking for location data.
            data = new HipoqihData((ProviderStatusListener) this);
        }
    }
    
    public void firstLocationUpdateEvent()
    {
        // Attempt to acquire the mutex
        synchronized (mutex)
        {
        	MainFormUI mf = new MainFormUI();
        	data.setMainForm(mf);
        	display.setCurrent(mf);
        }
    }

}
