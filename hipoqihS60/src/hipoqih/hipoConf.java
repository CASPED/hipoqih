/* This file was created by Carbide.j */
package hipoqih;

import javax.microedition.lcdui.*;
import hipoqih.CommandHandler;

public class hipoConf extends Form implements CommandListener
{
     javax.microedition.lcdui.TextField txtLogin = new TextField("TextField", "", 50, TextField.ANY);
     javax.microedition.lcdui.TextField txtClave = new TextField("TextField", "", 50, TextField.ANY);
     static public final javax.microedition.lcdui.Command cmdSalir = new Command("Salir", Command.EXIT, 0);

     public hipoConf(String p1, Item[] p2)
     {
          super(p1, p2);
     }


     public hipoConf(String p1)
     {
          super(p1);
     }


     public hipoConf()
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
          append(txtLogin);
          txtLogin.setLabel("Login");
          append(txtClave);
          txtClave.setLabel("Clave");
          this.addCommand(cmdSalir);
          CommandHandler.getInstance().registerCommand(cmdSalir, "hipoqih.hipoForm");
     }

     public void commandAction(Command command, Displayable displayable)
     {
          if ( !CommandHandler.getInstance().handleCommand(command) )
          {
          }
     }
}