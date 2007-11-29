/*
 * ConnectionThread.java
 *
 * © <your company here>, 2003-2007
 * Confidential and proprietary.
 */

package com.ipoki.plugin.blackberry;

import com.ipoki.plugin.blackberry.resource.*;
import java.lang.*;
import javax.microedition.io.*;
import net.rim.device.api.i18n.*;
import net.rim.device.api.ui.*;
import net.rim.device.api.ui.component.Dialog;

public class ConnectionThread extends Thread implements IpokiPluginResource
{
    private static ResourceBundle _resources = ResourceBundle.getBundle(BUNDLE_ID, BUNDLE_NAME);
    private static final int TIMEOUT = 500;
    private String _theUrl;

    private volatile boolean _start = false;
    private volatile boolean _stop = false;
    
    IpokiPlugin _app;
    
    public ConnectionThread()
    {
        _app = (IpokiPlugin)UiApplication.getUiApplication();
    }
        
    public synchronized String getUrl()
    {
        return _theUrl;
    }
    
    public void connect()
    {
            if ( _start )
            {
                Dialog.alert(_resources.getString(LBL_ALERT_REQUESTINPROGRESS));
            }        
            synchronized(this)
            {
                if (_start)
                {
                    Dialog.alert(_resources.getString(LBL_ALERT_REQUESTINPROGRESS));
                }
                else
                {
                    _start = true;
                }
            }
    }
    
    public void run()
    {
        for (;;)
        {
            while ( !_start && !_stop)
            {
                try
                {
                    sleep(TIMEOUT);
                }
                catch(InterruptedException e)
                {
                    System.err.println(e.toString());
                }
            } 
            
            if (_stop)
            {
                return;
            }
            
            synchronized(this)
            {
                try
                {
                    Thread.sleep(10000);
                    stopStatusThread();
                    _app.updateContent("Hecho");
                }
                catch(InterruptedException ie)
                {
                    System.err.println(ie.toString());
                }
                /*StreamConnection s = null;
                try
                {
                    s = (StreamConnection)Connector.open(getUrl());
                    HttpConnection httpConn = (HttpConnection)s;
                    
                    int status = httpConn.getResponseCode();
                    if (status == HttpConnection.HTTP_OK)
                    {
                        java.io.InputStream input = s.openInputStream();
                        
                        byte[] data = new byte[256];
                        int len = 0;
                        int size = 0;
                        StringBuffer raw = new StringBuffer();
                        while ( -1 != (len = input.read(data)) )
                        {
                            raw.append(new String(data, 0, len));
                            size += len;
                        }
                        String[] messages = parseMessage(raw.toString());
                    }
                    
                    
                }
                catch (java.io.IOException e) 
                {
                    System.err.println(e.toString());
                    //stopStatusThread();
                    //updateContent(e.toString());
                }*/

                _start = false;
            } // synchronized
        } // for
    } // run
    
    private void stopStatusThread()
    {
        _app._statusThread.pause();
        try 
        {
            synchronized(_app._statusThread)
            {
                //Check the paused condition, incase the notify fires prior to our wait, in which case we may never see that nofity
                while ( !_app._statusThread.isPaused() );
                {
                    _app._statusThread.wait();
                }
            }
        } 
        catch (InterruptedException e) {
            System.err.println(e.toString());
        }
    }

    public void stop()
    {
        _stop = true;
    }
    
    private String[] parseMessage(String mensaje)
    {
        // Temporalmente almacenaremos los mensajes en un vector 
        // (ya que nos abemos el número de elementos)
        java.util.Vector mensajes = new java.util.Vector();
        
        // Mientras haya un $$$ en la cadena
        while (mensaje.indexOf("$$$") != -1)
        {
            // Añadimos lo que hay hasta el $$$ al vector
            mensajes.addElement(mensaje.substring(0, mensaje.indexOf("$$$")));
            // Eliminamos lo ya añadido (incluído el $$$)
            mensaje = mensaje.substring(mensaje.indexOf("$$$") + 3);
        }
            
        // Copiamos el vector a un array de Strings
        String[] respuesta = new String[mensajes.size()];
        mensajes.copyInto(respuesta);
        return respuesta;
    }

} // class
