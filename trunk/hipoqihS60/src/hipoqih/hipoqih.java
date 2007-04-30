package hipoqih;

import javax.microedition.midlet.MIDlet;
import hipoqih.CommandHandler;
import hipoqih.hipoForm;

public class hipoqih extends MIDlet
{
     hipoForm hipoForm = new hipoForm();
     public void startApp()
     {
          CommandHandler.getInstance().initialize(this);
          CommandHandler.getInstance().start(hipoForm);
     }

     public void destroyApp(boolean b)
     {
     }

     public void pauseApp()
     {
     }
}