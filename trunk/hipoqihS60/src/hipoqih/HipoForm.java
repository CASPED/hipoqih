/* This file was created by Carbide.j */
package hipoqih;

import java.util.*;
import javax.microedition.lcdui.*;
import hipoqih.CommandHandler;

public class HipoForm extends Form implements CommandListener
{
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
     Alert alertScreen;
     
     public HipoForm(String p1, Item[] p2)
     {
          super(p1, p2);
     }


     public HipoForm(String p1)
     {
          super(p1);
     }


     public HipoForm()
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
          CommandHandler.getInstance().registerDisplayable(this);
          this.setCommandListener(this);
          setTitle("Hipoqih");
          strComStatus.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          strComStatus.setLabel("");
          strComStatus.setText("Disconnected");
          strComStatus.setLayout(Item.LAYOUT_2);
          strComStatus.setPreferredSize(-1, -1);
          append(strComStatus);
          imageOff = Image.createImage("/hipoqih/off.bmp");
          imageOn = Image.createImage("/hipoqih/on.bmp");
          img.setImage(imageOff);
          img.setLabel("");
          img.setLayout(Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          img.setAltText("");
          append(img);
          spacer0.setPreferredSize(10, 10);
          spacer0.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          append(spacer0);
          strLatitud.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
          strLatitud.setPreferredSize(80, -1);
          strLatitud.setLabel("");
          strLatitud.setText("Latitude");
          strLatitud.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
          append(strLatitud);
          strLongitud.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          strLongitud.setPreferredSize(80, -1);
          strLongitud.setLabel("");
          strLongitud.setText("Longitude");
          strLongitud.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
          append(strLongitud);
          strDatoLatitud.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
          strDatoLatitud.setPreferredSize(80, -1);
          strDatoLatitud.setLabel("");
          strDatoLatitud.setText("0.0");
          strDatoLatitud.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          append(strDatoLatitud);
          strDatoLongitud.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          strDatoLongitud.setPreferredSize(80, -1);
          strDatoLongitud.setLabel("");
          strDatoLongitud.setText("0.0");
          strDatoLongitud.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          append(strDatoLongitud);
          spacer1.setPreferredSize(10, 10);
          spacer1.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          append(spacer1);
          strDeUsuario.setText("Last alert:  ");
          strDeUsuario.setLabel("");
          strDeUsuario.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
          strDeUsuario.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
          //strDeUsuario.setPreferredSize(80, -1);
          append(strDeUsuario);
          strDatoDeUsuario.setText("User");
          strDatoDeUsuario.setLabel("");
          strDatoDeUsuario.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          strDatoDeUsuario.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          //strDatoDeUsuario.setPreferredSize(80, -1);
          append(strDatoDeUsuario);
          strDesde.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
          strDesde.setLabel("");
          strDesde.setText("From:  ");
          strDesde.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
          //strDesde.setPreferredSize(80, -1);
          append(strDesde);
          strDatoDesde.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          strDatoDesde.setLabel("");
          strDatoDesde.setText("  x meters");
          strDatoDesde.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          //strDatoDesde.setPreferredSize(80, -1);
          append(strDatoDesde);
          spacer2.setPreferredSize(10, 10);
          spacer2.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_BEFORE | Item.LAYOUT_2);
          append(spacer2);
          strAviso.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          strAviso.setLabel("");
          strAviso.setText("Este es el texto de aviso que el usuario nos ha mandado para la posición indicada");
          strAviso.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_ITALIC, Font.SIZE_SMALL));
          strAviso.setPreferredSize(-1, -1);
          append(strAviso);
          addCommand(cmdRefresh);
          addCommand(cmdConectar);
          addCommand(cmdMapa);
          addCommand(cmdAcercaDe);
          addCommand(cmdExit);
          CommandHandler.getInstance().registerExitCommand(cmdExit, "MIDletExit@r4vw47oc7botc===");
          addCommand(cmdConfigurar);
          CommandHandler.getInstance().registerCommand(cmdConfigurar, "Hipoqih.HipoConfForm");

     }

     public void commandAction(Command command, Displayable displayable)
     {
          if ( !CommandHandler.getInstance().handleCommand(command) )
          {
              if ( command == cmdConectar )
              {
                   if ( isConnected )
                   {
                        strComStatus.setText("Disconnected");
                        img.setImage(imageOff);
                   }
                   else
                   {
                        try
                        {
                             int resultado =  HipoWeb.conectar("http://www.hipoqih.com/alta.php?user=jcanvic&pass=aquelarre");
                             System.out.println(resultado);
                             switch(resultado)
                             {
                             case ResultadoWeb.BAD_RESPONSE:
                                 System.out.println("BAD_RESPONSE");
                             case ResultadoWeb.ERROR_AVISO:
                                 System.out.println("ERROR_AVISO");
                             case ResultadoWeb.ERROR_CODIGO:
                                 System.out.println("ERROR_CODIGO");
                             case ResultadoWeb.UNKNOWN_MESSAGE_TYPE:
                            	 System.out.println("UNKNOWN_MESSAGE_TYPE");
                            	 alertScreen = new Alert("Error");
                            	 alertScreen.setString("There was an error accessing hipoqih");
                            	 alertScreen.setTimeout(Alert.FOREVER);
                            	 CommandHandler.getInstance().start(alertScreen);
                            	 break;
                             case 1:
                            	 System.out.println("OK_AVISO");
                            	 if (Aviso.EsPosicional)
                            	 {
                                     Date hoy = new Date();
                                     String textoAviso = Comun.fechaToString(hoy.getTime()) + "\n" +
                                     					Aviso.Login + " is at " + Aviso.Radio + " meters."; 
                                     strAviso.setText(textoAviso);
                            	 }
                            	 else
                            	 {
                                     Date hoy = new Date();
                                     String textoAviso = Comun.fechaToString(hoy.getTime()) + "\n" +
                                     					Aviso.Texto;
                                     strDatoDeUsuario.setText(Aviso.Login);
                                     strDatoDesde.setText(Aviso.Radio +  " meters");
                                     strAviso.setText(textoAviso);
                            	 }
                            	 break;
                             case ResultadoWeb.OK_CODIGO:
                                 System.out.println("OK_CODIGO");
                            	 break;
                             }
                        }
                        catch (Exception ex)
                        {
                             strAviso.setText("error");
                        }
                        strComStatus.setText("Connected");
                        img.setImage(imageOn);
                   }
                   isConnected = !isConnected;
               }
          }
     }
}