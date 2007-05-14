/* This file was created by Carbide.j */
package hipoqih;

import javax.microedition.lcdui.*;
import hipoqih.CommandHandler;

public class HipoForm extends Form implements CommandListener
{
     javax.microedition.lcdui.StringItem strComStatus = new StringItem("Parado", "", StringItem.PLAIN);
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
     javax.microedition.lcdui.Command cmdRefresh = new Command("Refrescar Posición", Command.SCREEN, 0);
     javax.microedition.lcdui.Command cmdConectar = new Command("Conectar", Command.SCREEN, 1);
     javax.microedition.lcdui.Command cmdMapa = new Command("Mapa", Command.SCREEN, 1);
     private boolean isConnected = false;
     static public final javax.microedition.lcdui.Command cmdExit = new Command("Salir", Command.EXIT, 0);
     javax.microedition.lcdui.Image image1;
     javax.microedition.lcdui.Command cmdAcercaDe = new Command("Acerca de Hipoqih", Command.SCREEN, 1);
     static public final javax.microedition.lcdui.Command cmdConfigurar = new Command("Configurar", Command.SCREEN, 0);
     
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
          setTitle("HipoForm");
          strComStatus.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          strComStatus.setLabel("");
          strComStatus.setText("Parado");
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
          strLatitud.setText("Latitud");
          strLatitud.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
          append(strLatitud);
          strLongitud.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          strLongitud.setPreferredSize(80, -1);
          strLongitud.setLabel("");
          strLongitud.setText("Longitud");
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
          strDeUsuario.setText("Ultimo aviso:  ");
          strDeUsuario.setLabel("");
          strDeUsuario.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
          strDeUsuario.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
          //strDeUsuario.setPreferredSize(80, -1);
          append(strDeUsuario);
          strDatoDeUsuario.setText("Usuario");
          strDatoDeUsuario.setLabel("");
          strDatoDeUsuario.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          strDatoDeUsuario.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
          //strDatoDeUsuario.setPreferredSize(80, -1);
          append(strDatoDeUsuario);
          strDesde.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
          strDesde.setLabel("");
          strDesde.setText("Desde:  ");
          strDesde.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_SMALL));
          //strDesde.setPreferredSize(80, -1);
          append(strDesde);
          strDatoDesde.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
          strDatoDesde.setLabel("");
          strDatoDesde.setText("  x metros");
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
                        strComStatus.setText("Parado");
                        img.setImage(imageOff);
                   }
                   else
                   {
                        try
                        {
                             String mensaje = HipoWeb.conectar("http://www.hipoqih.com/alta.php?user=jcanvic&pass=aquelarre");
                             strAviso.setText(mensaje);
                        }
                        catch (Exception ex)
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
}