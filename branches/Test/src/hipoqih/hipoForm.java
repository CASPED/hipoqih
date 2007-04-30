/* This file was created by Carbide.j */
package hipoqih;

import javax.microedition.lcdui.*;
import hipoqih.CommandHandler;

public class hipoForm extends Form implements CommandListener
{
     javax.microedition.lcdui.StringItem strComStatus = new StringItem("Parado", "", StringItem.PLAIN);
     javax.microedition.lcdui.ImageItem img = new ImageItem("", null, ImageItem.LAYOUT_DEFAULT, "",
          ImageItem.PLAIN);
     javax.microedition.lcdui.Image imageOn;
     javax.microedition.lcdui.Image imageOff;
     javax.microedition.lcdui.StringItem strLatitud = new StringItem("StringItem", "N/A", StringItem.PLAIN);
     javax.microedition.lcdui.StringItem strLongitud = new StringItem("StringItem", "N/A", StringItem.PLAIN);
     javax.microedition.lcdui.Spacer spacer1 = new Spacer(0, 0);
     javax.microedition.lcdui.StringItem strFrom = new StringItem("StringItem", "N/A", StringItem.PLAIN);
     javax.microedition.lcdui.StringItem stringItem1 = new StringItem("StringItem", "N/A", StringItem.PLAIN);
     javax.microedition.lcdui.StringItem strAviso = new StringItem("StringItem", "N/A", StringItem.PLAIN);
     javax.microedition.lcdui.Spacer spacer2 = new Spacer(0, 0);
     javax.microedition.lcdui.Command cmdRefresh = new Command("Refrescar Posici�n", Command.SCREEN, 0);
     javax.microedition.lcdui.Command cmdConectar = new Command("Conectar", Command.SCREEN, 1);
     javax.microedition.lcdui.Command cmdMapa = new Command("Mapa", Command.SCREEN, 1);
     private boolean conectado = false;
     static public final javax.microedition.lcdui.Command command1 = new Command("Exit", Command.EXIT, 0);
     javax.microedition.lcdui.Image image1;

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
          strAviso.setText("Este es el �ltimo aviso recibido");
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
          this.addCommand(command1);
          CommandHandler.getInstance().registerExitCommand(command1, "MIDletExit@r4vw47oc7botc===");
          append(strComStatus);
          append(img);
          append(strLatitud);
          append(strLongitud);
          append(spacer1);
          append(strFrom);
          append(stringItem1);
          append(spacer2);
          append(strAviso);
     }

     public void commandAction(Command command, Displayable displayable)
     {
          if ( !CommandHandler.getInstance().handleCommand(command) )
          {
               if ( command == cmdConectar )
               {
                    if ( conectado )
                    {
                         strComStatus.setText("Parado");
                         img.setImage(imageOff);
                    }
                    else
                    {
                         strComStatus.setText("Conectado");
                         img.setImage(imageOn);
                    }
                    conectado = !conectado;
               }
          }
     }
}