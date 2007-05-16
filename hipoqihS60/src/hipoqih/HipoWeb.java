package hipoqih;

import java.io.*;
import java.io.IOException;
import javax.microedition.io.*;

public class HipoWeb
{
	public static int conectar(String url) throws IOException
	{
		HttpConnection c = null;
		InputStream is = null;
		StringBuffer str = new StringBuffer(); // StringBuffer que almacenará la cadena de repuesta
		int resultado = ResultadoWeb.UNKNOWN_MESSAGE_TYPE;
		
		/*try
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

		// El texto hasta el primer $$$ marca el tipo de mensaje
		String mensaje = str.toString();*/
		
		String mensaje = "AVISO$$$Esto es el aviso$$$http://$$$12.000000$$$32.000000$$$20$$$Pepito$$$N$$$";
		
		String[] mensajes = InterpretarMensaje(mensaje);

		if (mensajes.length == 0)
			return ResultadoWeb.BAD_RESPONSE;
		
		String tipoMensaje = mensajes[0];
		
		// Si el tipo es CODIGO, obtenemos el IdSeguro
		if (tipoMensaje.equals("CODIGO"))
		{
			String idSeguro = mensajes[1];
			
			if (idSeguro.equals("ERROR"))
			{
				return ResultadoWeb.ERROR_CODIGO;
			}
			
			resultado = ResultadoWeb.OK_CODIGO;
		}
		
		if (tipoMensaje.equals("AVISO"))
		{
			if (mensajes.length != 8)
			{
				return ResultadoWeb.ERROR_AVISO;
			}
			
			Aviso.Texto = mensajes[1];
			Aviso.Url = mensajes[2];
			Aviso.Latitud = mensajes[3];
			Aviso.Longitud = mensajes[4];
			Aviso.Radio = mensajes[5];
			Aviso.Login = mensajes[6];
			Aviso.EsPosicional = mensajes[7].equals("S");
			
			resultado = ResultadoWeb.OK_AVISO;
		}

		//return resultado;	
		return ResultadoWeb.OK_AVISO;	
	}
	
	private static String[] InterpretarMensaje(String mensaje)
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
