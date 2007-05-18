package hipoqih;

import javax.microedition.midlet.MIDlet;
import hipoqih.CommandHandler;
import hipoqih.HipoForm;
import hipoqih.HipoConfForm;
import hipoqih.HipoWaitForm;

public class Hipoqih extends MIDlet
{
     HipoForm hipoForm = new HipoForm();
     HipoConfForm hipoConf = new HipoConfForm();
     HipoWaitForm hipoWait = new HipoWaitForm();
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