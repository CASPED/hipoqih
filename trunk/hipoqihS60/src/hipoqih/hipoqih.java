package hipoqih;

import javax.microedition.midlet.MIDlet;
import hipoqih.CommandHandler;
import hipoqih.hipoForm;
import hipoqih.hipoConf;

public class hipoqih extends MIDlet
{
     hipoForm hipoForm = new hipoForm();
     hipoConf hipoConf = new hipoConf();
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