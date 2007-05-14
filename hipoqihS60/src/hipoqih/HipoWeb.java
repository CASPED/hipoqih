package hipoqih;

import java.io.*;
import java.io.IOException;
import javax.microedition.io.*;

public class HipoWeb
{
	public static String conectar(String url) throws IOException
	{
		HttpConnection c = null;
		InputStream is = null;
		StringBuffer str = new StringBuffer(); // StringBuffer que almacenará la cadena de repuesta
		String respuesta = "inicio";
		
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

		// El texto hasta el primer $$$ marca el tipo de mensaje
		String mensaje = str.toString();
		int posTipoMensaje = mensaje.indexOf("$$$");
		if (posTipoMensaje == 0)
			throw new IOException("Unexpected error: malformed response.");
		
		String tipoMensaje = mensaje.substring(0, posTipoMensaje);
		
		// Si el tipo es CODIGO, obtenemos el IdSeguro
		if (tipoMensaje.equals("CODIGO"))
		{
			String idSeguro = mensaje.substring(posTipoMensaje + 3);
			System.out.println("--" + idSeguro + "--");
			idSeguro = idSeguro.substring(0, idSeguro.length() - 3);
			System.out.println("--" + idSeguro + "--");
			respuesta = idSeguro;
		}
		
		return respuesta;	
	}
}
