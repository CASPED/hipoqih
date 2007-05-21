package com.hipoqih.plugin.MVC;

import java.io.*;
import java.util.*;

import javax.microedition.lcdui.*;
import javax.microedition.rms.RecordStore;

import com.hipoqih.plugin.Web.*;
import com.hipoqih.plugin.*;
import com.hipoqih.plugin.gps.*;
import com.hipoqih.plugin.task.SelectGPSDeviceTask;

public class MainForm extends MVCComponent 
{
	public static Start m;
	private static Displayable screen = null; 
	javax.microedition.lcdui.StringItem strComStatus = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.ImageItem img = new ImageItem("", null, ImageItem.LAYOUT_DEFAULT, "", ImageItem.PLAIN);
	javax.microedition.lcdui.Image imageOn;
	javax.microedition.lcdui.Image imageOff;
	javax.microedition.lcdui.Spacer spacer0 = new Spacer(0, 0);
	javax.microedition.lcdui.StringItem strLatitud = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strLongitud = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strDatoLatitud = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strDatoLongitud = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.Spacer spacer1 = new Spacer(0, 0);
	javax.microedition.lcdui.StringItem strDeUsuario = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strDesde = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strDatoDeUsuario = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strDatoDesde = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.StringItem strAviso = new StringItem("", "", StringItem.PLAIN);
	javax.microedition.lcdui.Spacer spacer2 = new Spacer(0, 0);
	javax.microedition.lcdui.Command cmdRefresh = new Command("Refresh position", Command.SCREEN, 0);
	javax.microedition.lcdui.Command cmdConectar = new Command("Connect", Command.SCREEN, 1);
	javax.microedition.lcdui.Command cmdMapa = new Command("Map", Command.SCREEN, 1);
	private boolean isConnected = false;
	static public final javax.microedition.lcdui.Command cmdExit = new Command("Exit", Command.EXIT, 0);
	javax.microedition.lcdui.Image image1;
	javax.microedition.lcdui.Command cmdAcercaDe = new Command("About Hipoqih", Command.SCREEN, 1);
	static public final javax.microedition.lcdui.Command cmdConfigurar = new Command("Properties", Command.SCREEN, 0);
	Temporizador tempo = new Temporizador();
	Timer timer = new Timer();

	protected void initModel() throws Exception 
	{
	}
	
	public Displayable getScreen () 
	{
		return screen;
	}
	
	public static void setGPS(GPS g)
	{
		System.out.println(Thread.currentThread().toString() + ": " + "setGPS");
		State.gps = g;
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
		strLatitud.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
		strLatitud.setPreferredSize(80, -1);
		strLatitud.setLabel("");
		strLatitud.setText("Latitude");
		strLatitud.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
		((Form)screen).append(strLatitud);
		strLongitud.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		strLongitud.setPreferredSize(80, -1);
		strLongitud.setLabel("");
		strLongitud.setText("Longitude");
		strLongitud.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
		((Form)screen).append(strLongitud);
		strDatoLatitud.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
		strDatoLatitud.setPreferredSize(80, -1);
		strDatoLatitud.setLabel("");
		strDatoLatitud.setText("0.0");
		strDatoLatitud.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
		((Form)screen).append(strDatoLatitud);
		strDatoLongitud.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		strDatoLongitud.setPreferredSize(80, -1);
		strDatoLongitud.setLabel("");
		strDatoLongitud.setText("0.0");
		strDatoLongitud.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
		((Form)screen).append(strDatoLongitud);
		spacer1.setPreferredSize(10, 10);
		spacer1.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		((Form)screen).append(spacer1);
		strDeUsuario.setText("Last alert:  ");
		strDeUsuario.setLabel("");
		strDeUsuario.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
		strDeUsuario.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
		((Form)screen).append(strDeUsuario);
		strDatoDeUsuario.setText("User");
		strDatoDeUsuario.setLabel("");
		strDatoDeUsuario.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		strDatoDeUsuario.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
		((Form)screen).append(strDatoDeUsuario);
		strDesde.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
		strDesde.setLabel("");
		strDesde.setText("From:  ");
		strDesde.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
		((Form)screen).append(strDesde);
		strDatoDesde.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		strDatoDesde.setLabel("");
		strDatoDesde.setText("  x meters");
		strDatoDesde.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
		((Form)screen).append(strDatoDesde);
		spacer2.setPreferredSize(10, 10);
		spacer2.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_BEFORE | Item.LAYOUT_2);
		((Form)screen).append(spacer2);
		strAviso.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		strAviso.setLabel("");
		strAviso.setText("This is the alert message.");
		strAviso.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_ITALIC, Font.SIZE_SMALL));
		strAviso.setPreferredSize(-1, -1);
		((Form)screen).append(strAviso);
		screen.addCommand(cmdRefresh);
		screen.addCommand(cmdConectar);
		screen.addCommand(cmdMapa);
		screen.addCommand(cmdAcercaDe);
		screen.addCommand(cmdExit);		
		timer.schedule(tempo, 1000, 1000);
	}

	public void commandAction(Command command, Displayable displayable)
    {
		// EXIT command
		if (command == cmdExit)
		{
			m.destroyApp(false);
			m.notifyDestroyed();
		}		
		else if ( command == cmdConectar )
		{
			if ( isConnected )
			{
				strComStatus.setText("Disconnected");
				img.setImage(imageOff);
			}
			else
			{
				connectToWeb();
			}
			isConnected = !isConnected;
		}
		else if (command == cmdRefresh)
		{
			if (State.gps == null)
			{
				try
				{
					SelectGPSDeviceTask s = new SelectGPSDeviceTask(display);
					s.go();
				}
				catch(Exception ex)
				{
					Alert a = new Alert("Error looking for Bluetooth devices");
					a.setTimeout(Alert.FOREVER);
					display.setCurrent(a);
				}
			}
			else
			{
				strAviso.setText(State.gps.getNMEAMessage());
			}
		}
		else if (command == cmdMapa)
		{
			String ah = "7";
			byte[] alert = ah.getBytes();
			System.out.println("Antes de escribir: " + ah);
			try
			{
				RecordStore recordStore = RecordStore.openRecordStore("hipoqih", true);
				recordStore.setRecord(RecordTypes.ALERTHEIGHT, alert, 0, alert.length);
				recordStore.closeRecordStore();
			}
			catch(Exception ex)
			{
				System.out.println(ex.getMessage());
				ex.printStackTrace();
			}
			
		}
		
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
					strAviso.setText(textoAviso);
				}
				else
				{
					Date hoy = new Date();
					String textoAviso = Tools.fechaToString(hoy.getTime()) + "\n" +
										HipoAlert.Text;
					strDatoDeUsuario.setText(HipoAlert.Login);
					strDatoDesde.setText(HipoAlert.Distance +  " meters");
					strAviso.setText(textoAviso);
				}
				break;
			case WebResult.OK_CODIGO:
				break;
			}
		}
		catch (IOException ex)
		{
			strAviso.setText("error");
		}
		strComStatus.setText("Connected");
		img.setImage(imageOn);
	}
	
	class Temporizador extends TimerTask
	{
		public void run()
		{
			sendPosition();
   	 	}
    }
	
    private void sendPosition()
    {
    	if (!State.connected)
    	{
    		connectToWeb();
    	}
    	if (State.positionSource.equals("CONFIG"))
    	{
    		
    	}
    }
}
