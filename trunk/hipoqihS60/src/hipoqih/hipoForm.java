/* This file was created by Carbide.j */
package hipoqih;

import java.io.*;
import javax.microedition.lcdui.*;
import javax.microedition.io.*;

import com.symbian.midp.io.CharConverter;

import hipoqih.CommandHandler;

public class hipoForm extends Form implements CommandListener
{
     javax.microedition.lcdui.StringItem strComStatus = new StringItem("Parado", "", StringItem.PLAIN);
     javax.microedition.lcdui.ImageItem img = new ImageItem("", null, ImageItem.LAYOUT_DEFAULT, "", ImageItem.PLAIN);
     javax.microedition.lcdui.Image imageOn;
     javax.microedition.lcdui.Image imageOff;
     javax.microedition.lcdui.StringItem strLatitud = new StringItem("StringItem", "N/A", StringItem.PLAIN);
     javax.microedition.lcdui.StringItem strLongitud = new StringItem("StringItem", "N/A", StringItem.PLAIN);
     javax.microedition.lcdui.Spacer spacer1 = new Spacer(0, 0);
     javax.microedition.lcdui.StringItem strFrom = new StringItem("StringItem", "N/A", StringItem.PLAIN);
     javax.microedition.lcdui.StringItem stringItem1 = new StringItem("StringItem", "N/A", StringItem.PLAIN);
     javax.microedition.lcdui.StringItem strAviso = new StringItem("StringItem", "N/A", StringItem.PLAIN);
     javax.microedition.lcdui.Spacer spacer2 = new Spacer(0, 0);
     javax.microedition.lcdui.Command cmdRefresh = new Command("Refrescar Posición", Command.SCREEN, 0);
     javax.microedition.lcdui.Command cmdConectar = new Command("Conectar", Command.SCREEN, 1);
     javax.microedition.lcdui.Command cmdMapa = new Command("Mapa", Command.SCREEN, 1);
     private boolean isConnected = false;
     static public final javax.microedition.lcdui.Command cmdExit = new Command("Salir", Command.EXIT, 0);
     javax.microedition.lcdui.Image image1;
     javax.microedition.lcdui.Command cmdAcercaDe = new Command("Acerca de hipoqih", Command.SCREEN, 1);
     static public final javax.microedition.lcdui.Command cmdConfigurar = new Command("Configurar", Command.SCREEN, 0);

     public hipoForm(String p1, Item[] p2)
     {
          super(p1, p2);
     }


     public hipoForm(String p1)
     {
          super(p1);
     }


     public hipoForm()
     {
          this("");
          try
          {
               ndsInit();
          }
          catch (Exception e)
          {
          }
     }

     void ndsInit() throws Exception
     {
          imageOff = Image.createImage("/hipoqih/off.bmp");
          imageOn = Image.createImage("/hipoqih/on.bmp");
          CommandHandler.getInstance().registerDisplayable(this);
          this.setCommandListener(this);
          strComStatus.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          strComStatus.setLabel("");
          strComStatus.setText("Parado");
          strComStatus.setLayout(Item.LAYOUT_2);
          img.setImage(imageOff);
          img.setLabel("");
          strLatitud.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
          strLongitud.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          spacer1.setPreferredSize(10, 10);
          strLatitud.setPreferredSize(80, -1);
          strLongitud.setPreferredSize(80, -1);
          spacer1.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
          strLatitud.setLabel("Latitud");
          strLatitud.setText("0.0");
          strLongitud.setLabel("Longitud");
          strLongitud.setText("0.0");
          strFrom.setText("Usuario");
          strFrom.setLabel("Ultimo aviso");
          strFrom.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
          stringItem1.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          stringItem1.setLabel(" Desde");
          stringItem1.setText("x metros");
          strAviso.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_BEFORE | Item.LAYOUT_EXPAND |
               Item.LAYOUT_VEXPAND | Item.LAYOUT_2);
          strAviso.setLabel("");
          strAviso.setText("Este es el último aviso recibido");
          spacer2.setPreferredSize(10, 10);
          spacer2.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_BEFORE | Item.LAYOUT_2);
          strLongitud.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          strLatitud.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          stringItem1.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          strFrom.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          strAviso.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          img.setLayout(Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          strComStatus.setPreferredSize(-1, -1);
          strFrom.setPreferredSize(100, -1);
          stringItem1.setPreferredSize(80, -1);
          img.setAltText("");
          addCommand(cmdRefresh);
          addCommand(cmdConectar);
          addCommand(cmdMapa);
          this.addCommand(cmdExit);
          CommandHandler.getInstance().registerExitCommand(cmdExit, "MIDletExit@r4vw47oc7botc===");
          append(strComStatus);
          append(img);
          append(strLatitud);
          append(strLongitud);
          append(spacer1);
          append(strFrom);
          append(stringItem1);
          append(spacer2);
          append(strAviso);
          addCommand(cmdAcercaDe);
          this.addCommand(cmdConfigurar);
          CommandHandler.getInstance().registerCommand(cmdConfigurar, "hipoqih.hipoConf");
     }

     public void commandAction(Command command, Displayable displayable)
     {
          if ( !CommandHandler.getInstance().handleCommand(command) )
          {
               if ( command == cmdConectar )
               {
                    if ( isConnected )
                    {
                         strComStatus.setText("Parado");
                         img.setImage(imageOff);
                    }
                    else
                    {
                         try
                         {
                              String mensaje = connect();
                              strAviso.setText(mensaje);
                         }
                         catch (IOException ex)
                         {
                        	 strAviso.setText("error");
                         }
                         strComStatus.setText("Conectado");
                         img.setImage(imageOn);
                    }
                    isConnected = !isConnected;
               }
          }
     }

     private String connect() throws IOException
     {
		String url = "http://www.hipoqih.com/alta.php?user=" + Configuracion.login + "&pass=" + Configuracion.
		   password;
		HttpConnection c = null;
		InputStream is = null;
		String mensaje;
		int rc;
		try
          {
           c = (HttpConnection)Connector.open(url);
           // Obtener el código de respuesta abrirá la conexión,
           // enviará la petición, y leerá las cabeceras de la respuesta HTTP.
           // Las cabeceras se almacenan hasta que sean necesarias.
           rc = c.getResponseCode();
           if ( rc != HttpConnection.HTTP_OK )
           {
                throw new IOException("Error HTTP:" + rc);
           }
           is = c.openInputStream();
           // Get the length and process the data
			int actual = 0;
			StringBuffer str = new StringBuffer();
			mensaje = "antes del while";
			while ((actual = is.read()) != -1)
			{
				str.append((char)actual);
			}
			mensaje = str.toString();
          }
          catch (ClassCastException e)
          {
               throw new IllegalArgumentException("Not an HTTP URL");
          }
          finally
          {
               if ( is != null )
                    is.close();
               if ( c != null )
                    c.close();
          }
          return mensaje;
     }
}