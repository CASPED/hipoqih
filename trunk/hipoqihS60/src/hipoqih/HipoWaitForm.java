/* This file was created by Carbide.j */
package hipoqih;

import javax.microedition.lcdui.*;
import hipoqih.CommandHandler;

public class HipoWaitForm extends Form implements CommandListener
{
     javax.microedition.lcdui.Gauge gaugEsperar = new Gauge("Gauge", false, 100, 0);

     public HipoWaitForm(String p1, Item[] p2)
     {
          super(p1, p2);
     }


     public HipoWaitForm(String p1)
     {
          super(p1);
     }


     public HipoWaitForm()
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
          append(gaugEsperar);
          gaugEsperar.setMaxValue(-1);
          gaugEsperar.setLayout(Item.LAYOUT_CENTER | Item.LAYOUT_VCENTER | Item.LAYOUT_2);
          gaugEsperar.setLabel("");
     }

     public void commandAction(Command command, Displayable displayable)
     {
          if ( !CommandHandler.getInstance().handleCommand(command) )
          {
          }
     }
}