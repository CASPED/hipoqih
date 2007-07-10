package com.hipoqih.plugin;

import java.util.*;
import javax.microedition.rms.*;
 
public class Tools {
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
	
	public static void updateRecord (int recordType, String data) throws RecordStoreException
	{
		Integer id = (Integer)State.recordMaps.get(new Integer(recordType));

		int recordLength = 1;
		byte[] dataBytes = data.getBytes();
		
		if (data.length() > 0)
			recordLength = dataBytes.length + 1;

		byte[] record = new byte[recordLength]; 
		record[0] = (byte)recordType;
		for(int i = 1; i < recordLength; i++)
			record[i] = dataBytes[i-1];
		
		State.recordStore.setRecord(id.intValue(), record, 0, recordLength);
	}
	
	public static String retrieveRecord(int recordType) throws RecordStoreException
	{
		Integer id = (Integer)State.recordMaps.get(new Integer(recordType));
		byte[] record = State.recordStore.getRecord(id.intValue());
		return new String(record, 1, record.length - 1);
	}
}
