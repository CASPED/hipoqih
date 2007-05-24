package com.hipoqih.plugin.MVC;

import java.io.*;
import java.util.*;
import javax.microedition.lcdui.*;
import com.hipoqih.plugin.Web.*;
import com.hipoqih.plugin.*;
 
public class MainForm extends MVCComponent 
{
	public static HipoqihMIDlet m;
	private static Displayable screen = null; 
	javax.microedition.lcdui.StringItem strComStatus = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.ImageItem img = new ImageItem("", null, ImageItem.LAYOUT_DEFAULT, "", ImageItem.PLAIN);
	javax.microedition.lcdui.Image imageOn;
	javax.microedition.lcdui.Image imageOff;
	javax.microedition.lcdui.Spacer spacer0 = new Spacer(0, 0);
	javax.microedition.lcdui.StringItem strLatitude = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strLongitude = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strLatitudeData = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strLongitudeData = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.Spacer spacer1 = new Spacer(0, 0);
	javax.microedition.lcdui.StringItem strFromUser = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strDistance = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strFromUserData = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strDistanceData = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strAlert = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.Spacer spacer2 = new Spacer(0, 0);
	javax.microedition.lcdui.Command cmdConnect = new Command("Connect", Command.SCREEN, 1);
	javax.microedition.lcdui.Command cmdDisconnect = new Command("Disconnect", Command.SCREEN, 1);
	javax.microedition.lcdui.Command cmdMap = new Command("Map", Command.SCREEN, 1);
	javax.microedition.lcdui.Command cmdExitMap = new Command("Exit", Command.SCREEN, 1);
	private boolean isConnected = false;
	static public final javax.microedition.lcdui.Command cmdExit = new Command("Exit", Command.EXIT, 0);
	javax.microedition.lcdui.Image image1;
	javax.microedition.lcdui.Command cmdAcercaDe = new Command("About Hipoqih", Command.SCREEN, 1);
	static public final javax.microedition.lcdui.Command cmdConfigurar = new Command("Properties", Command.SCREEN, 0);
	private WebTimerTask webTimerTask = new WebTimerTask();
	private UITimerTask uiTimerTask = new UITimerTask();
	private Timer timer = new Timer();
	private double latitude = 0;
	private double longitude = 0;
	private double lastSentLon = 0;
	private double lastSentLat = 0;
	boolean gpsConnected = false;

	protected void initModel() throws Exception 
	{
	}
	
	public Displayable getScreen () 
	{
		return screen;
	}
	
	public void commandAction(Command command, Displayable displayable)
    {
		// EXIT command
		if (command == cmdExit)
		{
			m.destroyApp(false);
			m.notifyDestroyed();
		}		
		else if ( command == cmdConnect )
		{
			if ( !isConnected )
			{
				try
				{
					System.out.println("cmdConnect->not connected");
					connectToWeb();
					uiTimerTask.cancel();
					webTimerTask = new WebTimerTask();
					timer.schedule(webTimerTask, 0, 2000);
					isConnected = true;
					strComStatus.setText("Connected");
					img.setImage(imageOn);
				}
				catch(Exception ex)
				{
					System.out.println(Thread.currentThread().getName() + ": cmdConnect");
					System.out.println(ex.toString());
					ex.printStackTrace();
				}
			}
		}
		else if ( command == cmdDisconnect)
		{
			if (isConnected)
			{
				try
				{
					isConnected = false;
					strComStatus.setText("Disconnected");
					img.setImage(imageOff);
					webTimerTask.cancel();
					uiTimerTask = new UITimerTask();
					timer.schedule(uiTimerTask, 0, 2000);
				}
				catch(Exception ex)
				{
					System.out.println(Thread.currentThread().getName() + ": cmdDisconnect");
					System.out.println(ex.toString());
					ex.printStackTrace();
				}
			}
		}
		else if (command == cmdMap)
		{
			if (strLatitudeData.getText().trim().length() == 0 || strLongitudeData.getText().trim().length() == 0)
			{
				Alert alertScreen = new Alert("Error");
				alertScreen.setString("There are no position coordinates");
				alertScreen.setTimeout(Alert.FOREVER);
				display.setCurrent(alertScreen);
 			}
			try
			{
				Form form = new Form("Map");
				int width = form.getWidth();
				int height = form.getHeight();
				Image image = getMap(height, width);
				form.append(image);
				form.addCommand(cmdExitMap);
				form.setCommandListener(this);
				display.setCurrent(form);
			}
			catch(IOException ioe)
			{
				System.out.println(ioe.getMessage());
				ioe.printStackTrace();
			}
			catch(Exception ex)
			{
				System.out.println(ex.getMessage());
				ex.printStackTrace();
			}
		}
		else if(command == cmdExitMap)
		{
			display.setCurrent(this.getScreen());
		}
    }
	
	public void setLocation(double lat, double lon, boolean connected)
	{
		latitude = lat;
		longitude = lon;
		gpsConnected = connected;
	}
	
	protected void updateView() throws Exception 
	{
		createView();
	}
	
	private void connectToWeb()
	{
		try
		{
			int resultado =  HipoWeb.sendWebReg(State.user, State.password);
			switch(resultado)
			{
			case WebResult.BAD_RESPONSE:
			case WebResult.ERROR_AVISO:
			case WebResult.ERROR_CODIGO:
			case WebResult.UNKNOWN_MESSAGE_TYPE:
				Alert alertScreen = new Alert("Error");
				alertScreen.setString("There was an error accessing hipoqih");
				alertScreen.setTimeout(Alert.FOREVER);
				display.setCurrent(alertScreen);
				break;
			case WebResult.OK_AVISO:
				if (HipoAlert.IsPositional)
				{
					Date hoy = new Date();
					String textoAviso = Tools.fechaToString(hoy.getTime()) + "\n" +
								HipoAlert.Login + " is at " + HipoAlert.Distance + " meters."; 
					strAlert.setText(textoAviso);
				}
				else
				{
					Date hoy = new Date();
					String textoAviso = Tools.fechaToString(hoy.getTime()) + "\n" +
										HipoAlert.Text;
					strFromUserData.setText(HipoAlert.Login);
					strDistanceData.setText(HipoAlert.Distance +  " meters");
					strAlert.setText(textoAviso);
				}
				break;
			case WebResult.OK_CODIGO:
				break;
			}
		}
		catch (IOException ex)
		{
			strAlert.setText("error");
		}
	}
	
	class WebTimerTask extends TimerTask
	{
		public void run()
		{
			try
			{
				sendPosition();
			}
			catch(Exception ex)
			{
				System.out.println(Thread.currentThread().getName() + ": sendPosition");
				System.out.println(ex.getMessage());
				ex.printStackTrace();
			}
   	 	}
    }
	
	class UITimerTask extends TimerTask
	{
		public void run()
		{
			try
			{
				updateCoorUI();
			}
			catch(Exception ex)
			{
				System.out.println(Thread.currentThread().getName() + ": updateCoorUI");
				System.out.println(ex.getMessage());
				ex.printStackTrace();
			}
  	 	}
	}
	
	private void updateCoorUI()
	{
		if (gpsConnected)
		{
			String lat = Double.toString(latitude);
			if (lat.length() > 8)
				lat = lat.substring(0, 8);
			String lon = Double.toString(longitude);
			if (lon.length() > 8)
				lon = lon.substring(0, 8);
			strLatitudeData.setText(lat);
			strLongitudeData.setText(lon);
		}
		else
		{
			strLatitudeData.setText("Unavailable");
			strLongitudeData.setText("Unavailable");
		}
	}
	
	
    private void sendPosition()
    {
    	if (!State.connected)
    	{
    		connectToWeb();
    	}
    	if (State.positionSource.equals("GPS"))
    	{
    		if (gpsConnected)
    		{
    			updateCoorUI();
    			if (Math.abs(latitude - lastSentLat) > 0.00001 || Math.abs(longitude - lastSentLon) > 0.00001)
    			{
    				try
    				{
    					HipoWeb.sendWebPos(strLatitudeData.getText(), strLongitudeData.getText());
    				}
    				catch(IOException ioe)
    				{
    					isConnected = false;
    					img.setImage(imageOff);
    					System.out.println(ioe.getMessage());
    					ioe.printStackTrace();
    				}
    			}
    		}
    		else
    		{
    			strLatitudeData.setText("Unavailable");
    			strLongitudeData.setText("Unavailable");
    		}
    	}
    }
    
    private Image getMap(int height, int width) throws IOException
    {
   		double longitude = Double.parseDouble(strLongitudeData.getText());
   		double latitude = Double.parseDouble(strLatitudeData.getText());
    	
    	double multipliedLon = longitude * 1000000;
    	if (multipliedLon < 0)
    		multipliedLon = multipliedLon + 1073741824 + 1073741824 + 1073741824 + 1073741824;
    	multipliedLon = Math.floor(multipliedLon);
    	
    	double multipliedLat = latitude * 1000000;
    	if (multipliedLat < 0)
    		multipliedLat = multipliedLat + 1073741824 + 1073741824 + 1073741824 + 1073741824;
    	multipliedLat = Math.floor(multipliedLat);
    	
    	String urlLatitude = Long.toString((new Double(multipliedLat)).longValue());
    	String urlLongitude = Long.toString((new Double(multipliedLon)).longValue());
    	
    	String url = "http://maps.google.com/mapdata?Point=b&Point.latitude_e6=" + urlLatitude + 
    				"&Point.longitude_e6=" + urlLongitude + 
    				"&Point.iconid=15&Point=e&latitude_e6=" + urlLatitude + 
    				"&longitude_e6=" + urlLongitude + 
    				"&zm=" + Integer.toString(State.zoom) + "&w=" + width + "&h=" + height + "&cc=EN&min_priority=2";
    	return HipoWeb.sendWebRequestImage(url);
    }
    
	protected void createView() throws Exception 
	{
		screen = new Form("Hipoqih");
		strComStatus.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
		strComStatus.setLabel("");
		strComStatus.setText("Disconnected");
		strComStatus.setLayout(Item.LAYOUT_2);
		strComStatus.setPreferredSize(-1, -1);
		((Form)screen).append(strComStatus);
		imageOff = Image.createImage("/off.bmp");
		imageOn = Image.createImage("/on.bmp");
		img.setImage(imageOff);
		img.setLabel("");
		img.setLayout(Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		img.setAltText("");
		((Form)screen).append(img);
		spacer0.setPreferredSize(10, 10);
		spacer0.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		((Form)screen).append(spacer0);
		strLatitude.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
		strLatitude.setPreferredSize(80, -1);
		strLatitude.setLabel("");
		strLatitude.setText("Latitude");
		strLatitude.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
		((Form)screen).append(strLatitude);
		strLongitude.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		strLongitude.setPreferredSize(80, -1);
		strLongitude.setLabel("");
		strLongitude.setText("Longitude");
		strLongitude.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
		((Form)screen).append(strLongitude);
		strLatitudeData.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
		strLatitudeData.setPreferredSize(80, -1);
		strLatitudeData.setLabel("");
		strLatitudeData.setText("41.0");
		strLatitudeData.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
		((Form)screen).append(strLatitudeData);
		strLongitudeData.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		strLongitudeData.setPreferredSize(80, -1);
		strLongitudeData.setLabel("");
		strLongitudeData.setText("-74");
		strLongitudeData.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
		((Form)screen).append(strLongitudeData);
		spacer1.setPreferredSize(10, 10);
		spacer1.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		((Form)screen).append(spacer1);
		strFromUser.setText("Last alert:  ");
		strFromUser.setLabel("");
		strFromUser.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
		strFromUser.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
		((Form)screen).append(strFromUser);
		strFromUserData.setText("User");
		strFromUserData.setLabel("");
		strFromUserData.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		strFromUserData.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
		((Form)screen).append(strFromUserData);
		strDistance.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
		strDistance.setLabel("");
		strDistance.setText("From:  ");
		strDistance.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
		((Form)screen).append(strDistance);
		strDistanceData.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		strDistanceData.setLabel("");
		strDistanceData.setText("  x meters");
		strDistanceData.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
		((Form)screen).append(strDistanceData);
		spacer2.setPreferredSize(10, 10);
		spacer2.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_BEFORE | Item.LAYOUT_2);
		((Form)screen).append(spacer2);
		strAlert.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		strAlert.setLabel("");
		strAlert.setText("This is the alert message.");
		strAlert.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_ITALIC, Font.SIZE_SMALL));
		strAlert.setPreferredSize(-1, -1);
		((Form)screen).append(strAlert);
		screen.addCommand(cmdConnect);
		screen.addCommand(cmdDisconnect);
		screen.addCommand(cmdMap);
		screen.addCommand(cmdAcercaDe);
		screen.addCommand(cmdExit);		
	}
}
