package com.hipoqih.plugin.Web;

import java.io.*;
import java.io.IOException;
import javax.microedition.io.*;
import com.hipoqih.plugin.*;

public class HipoWeb
{
	public static int sendWebReg(String user, String pass) throws IOException
	{
		
		
		
		int result = WebResult.UNKNOWN_MESSAGE_TYPE;
		
		/*

		// El texto hasta el primer $$$ marca el tipo de mensaje
		String url = "http://www.hipoqih.com/alta.php?user="+user+"&pass="+pass;
		String mensaje = sendWebRequest(url);*/
		
		String message = "AVISO$$$Esto es el aviso$$$http://$$$12.000000$$$32.000000$$$20$$$Pepito$$$N$$$";
		
		String[] messages = parseMessage(message);

		if (messages.length == 0)
			return WebResult.BAD_RESPONSE;
		
		String messageType = messages[0];
		
		// Si el tipo es CODIGO, obtenemos el IdSeguro
		if (messageType.equals("CODIGO"))
		{
			String secureID = messages[1];
			
			if (secureID.equals("ERROR"))
			{
				return WebResult.ERROR_CODIGO;
			}
			State.connected = true;
			result = WebResult.OK_CODIGO;
		}
		
		if (messageType.equals("AVISO"))
		{
			if (messages.length != 8)
			{
				return WebResult.ERROR_AVISO;
			}
			
			HipoAlert.Text = messages[1];
			HipoAlert.Url = messages[2];
			HipoAlert.Latitude = messages[3];
			HipoAlert.Longitude = messages[4];
			HipoAlert.Distance = messages[5];
			HipoAlert.Login = messages[6];
			HipoAlert.IsPositional = messages[7].equals("S");
			
			result = WebResult.OK_AVISO;
		}

		//return resultado;	
		return WebResult.OK_AVISO;	
	}
	
	private static String sendWebRequest(String url) throws IOException
	{
		HttpConnection c = null;
		InputStream is = null;
		StringBuffer str = new StringBuffer(); // StringBuffer que almacenará la cadena de repuesta
		
		try
		{
			// Obtenemos la conexión con la dirección url indicada
			c = (HttpConnection)Connector.open(url);
			
			// Obtener el código de respuesta abrirá la conexión,
			// enviará la petición, y leerá las cabeceras de la respuesta HTTP.
			int rc = c.getResponseCode();
			if (rc != HttpConnection.HTTP_OK )
			{
				throw new IOException("Error HTTP:" + rc);
			}

			// Obtenemos el "stream" de datos
			is = c.openInputStream();
			
		
			// Leemos carácter a carácter hasta el final (-1)
			int actual = -1;
			while ((actual = is.read()) != -1)
			{
				str.append((char)actual);
			}
			
			// Si no se devuelven datos, devolvemos un error
			if (str.length() == 0)
				throw new IOException("Unexpected error: empty response.");
		}
		catch (ClassCastException e)
		{
			throw new IllegalArgumentException("Not an HTTP URL");
		}
		finally
		{
			if ( is != null )
				is.close();
			if ( c != null )
				c.close();
		}
		
		return str.toString();
	}
	
	private static String[] parseMessage(String mensaje)
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
}
