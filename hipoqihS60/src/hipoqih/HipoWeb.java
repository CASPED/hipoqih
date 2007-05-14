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
		StringBuffer str = new StringBuffer(); // StringBuffer que almacenar� la cadena de repuesta
		
		try
		{
			// Obtenemos la conexi�n con la direcci�n url indicada
			c = (HttpConnection)Connector.open(url);
			
			// Obtener el c�digo de respuesta abrir� la conexi�n,
			// enviar� la petici�n, y leer� las cabeceras de la respuesta HTTP.
			int rc = c.getResponseCode();
			if (rc != HttpConnection.HTTP_OK )
			{
				throw new IOException("Error HTTP:" + rc);
			}

			// Obtenemos el "stream" de datos
			is = c.openInputStream();
			
		
			// Leemos car�cter a car�cter hasta el final (-1)
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
}
