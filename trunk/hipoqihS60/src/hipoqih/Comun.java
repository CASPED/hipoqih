package hipoqih;

import java.util.*;

public class Comun
{
	public static String fechaToString (long date)
	{
		Calendar c = Calendar.getInstance();
		c.setTime(new Date(date));
		int y = c.get(Calendar.YEAR);
		int m = c.get(Calendar.MONTH) + 1;
		int d = c.get(Calendar.DATE);
		String t = (d<10?"0": "")+d+"/"+(m<10? "0": "")+m+"/"+(y<10? "0": "")+y;
		return t;
	}

	public static String horaToString (long date)
	{
		Calendar c = Calendar.getInstance();
		c.setTime(new Date(date));
		int h = c.get(Calendar.HOUR_OF_DAY);
		int m = c.get(Calendar.MINUTE);
		int s = c.get(Calendar.SECOND);
		String t = (h<10? "0": "")+h+":"+(m<10? "0": "")+m+":"+(s<10?"0": "")+s;
		return t;
	}
}

