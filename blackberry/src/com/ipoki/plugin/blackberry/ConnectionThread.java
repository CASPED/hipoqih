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
    private static final int RETRY_TIME = 100;
    private String _theUrl;
    private static final String SIGNIN = "http://www.ipoki.com/signin.php";
    private static final String EAR = "http://www.ipoki.com/ear.php";
    private static final String SIGNOUT = "http://www.ipoki.com/signout.php";
    private static final String READPOS = "http://www.ipoki.com/readposition.php";
    private static final String MYFRIENDS = "http://www.ipoki.com/myfriends.php";
    private static final int SIGNIN_S = 0;
    private static final int EAR_S = 1;
    private static final int SIGNOUT_S = 2;
    private static final int READPOS_S = 3;
    private static final int MYFRIENDS_S = 4;
    private int _urlType = 0;
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
    
    public void signIn(String user, String pass)
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
                _theUrl = SIGNIN + "?user=" + user + "&pass=" + pass;
                _urlType = SIGNIN_S;
            }
        }
    }
    
    public void ear(String idUser, String lat, String lon, String comment)
    {
        try
        {
            if ( _start )
            {
                sleep(RETRY_TIME);
            }        
            synchronized(this)
            {
                if (_start)
                {
                    sleep(RETRY_TIME);
                }
                else
                {
                    _start = true;
                    _theUrl = EAR + "?iduser=" + idUser + "&lat=" + lat + "&lon=" + lon + "&comment=" + comment;
                    _urlType = EAR_S;
                }
            }
        }
        catch(InterruptedException e)
        {
            System.err.println(e.toString());
        }
    }
    
    public void signout(String idUser)
    {
        try
        {
            if ( _start )
            {
                sleep(RETRY_TIME);
            }        
            synchronized(this)
            {
                if (_start)
                {
                    sleep(RETRY_TIME);
                }
                else
                {
                    _start = true;
                    _theUrl = SIGNOUT + "?iduser=" + idUser;
                    _urlType = SIGNOUT_S;
                }
            }
        }
        catch(InterruptedException e)
        {
            System.err.println(e.toString());
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
                StreamConnection s = null;
                try
                {
                    System.err.println("open conn");
                    s = (StreamConnection)Connector.open(getUrl());
                    HttpConnection httpConn = (HttpConnection)s;
                    httpConn.setRequestProperty("User-Agent", "IpokiPlugin/BlackBerry/0.1");
                    
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
                        java.util.Vector messages = parseMessage(raw.toString());
                        processMessages(messages);
                        input.close();
                    }
                    s.close();                }
                catch (java.io.IOException e) 
                {
                    System.err.println(e.toString());
                }

                _start = false;
            } // synchronized
        } // for
    } // run

    private void processMessages(java.util.Vector messages)
    {
        if (messages.size() < 1)
            return;
        
        String typeMessage = (String)messages.elementAt(0);
        if (typeMessage.equals("CODIGO"))
        {
            _app._statusThread.pause();
            _app.invokeLater(new Runnable() 
            {
                public void run()
                {
                    _app.popScreen(_app._gaugeScreen);
                }
            });    

            String message = (String)messages.elementAt(1);
            if (message.equals("ERROR") )
            {
                _app.invokeLater(new Runnable() 
                {
                    public void run()
                    {
                        Dialog.alert(IpokiPlugin._resources.getString(LBL_LOGIN_ERROR));
                    }
                });    
                return;
            }
                
            IpokiPlugin._idUser = (String)messages.elementAt(1);
            _app._listenThread.go();

            _app.invokeLater(new Runnable() 
            {
                public void run()
                {
                    _app._lblStatus.setText(IpokiPlugin._resources.getString(LBL_CONNECTED));                
                }
            });    
        }
        else if(typeMessage.equals("COMMENT"))
        {
            if (messages.size() < 3)
                return;
                
            IpokiPlugin._comment = (String)messages.elementAt(1) + ": " + (String)messages.elementAt(2);
        }
        
        if (_urlType == SIGNOUT_S && typeMessage.equals("OK"))
        {
            _app._statusThread.pause();
            _app.invokeLater(new Runnable() 
            {
                public void run()
                {
                    _app._lblStatus.setText(IpokiPlugin._resources.getString(LBL_DISCONNECTED));
                    _app.popScreen(_app._gaugeScreen);
                }
            });    
        }
    }

    public void stop()
    { 
        _stop = true;
    }
    
    private java.util.Vector parseMessage(String mensaje)
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
        
        if (mensaje.length() > 0)
            mensajes.addElement(mensaje);
            
        return mensajes;
    }

} // class
