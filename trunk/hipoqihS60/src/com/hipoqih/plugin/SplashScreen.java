/*
 *
 * The contents of this file are subject to the GNU Public License
 * Version 2.0 (the "License"); you may not use this file except in
 * compliance with the License.
 *
 * Software distributed under the License is distributed on an "AS IS"
 * basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See
 * the License for the specific terms governing rights and limitations
 * under the License.
 *
 * Developed by Michael Juntao Yuan 2002.
 *
 * */
package com.hipoqih.plugin;
 
<<<<<<< .mine
=======
import java.io.*;

>>>>>>> .r90
import javax.microedition.lcdui.*;

public class SplashScreen extends Canvas implements Runnable
{
	private MIDletExiter m;
	Image img[]=new Image[2];
	int imgIndex = 0;
	
	public SplashScreen (MIDletExiter me) 
	{
		m = me;
		try
		{
			img[0]=Image.createImage("/hipoqihSplash.PNG");
			img[1]=Image.createImage("/hipoqihSplash2.png");
		}
		catch(Exception e){}
		Thread th=new Thread(this);
		th.start();
	}

	public void paint (Graphics g) 
	{
		int w = getWidth ();
		int h = getHeight ();

		try 
		{
			g.drawImage(img[imgIndex], w/2, h/2, Graphics.VCENTER | Graphics.HCENTER);
		} 
		catch (Exception e) 
		{
			g.drawString(e.getMessage(), w/2, h/2, Graphics.BASELINE | Graphics.HCENTER);
		}
		
	}
	
	public void run()
	{
		while(true)
		{
			if (imgIndex == 0)
				imgIndex = 1;
			else
				imgIndex = 0;
			
			repaint();
			
			try
			{
				Thread.sleep(500);
			}
			catch(Exception e){}
		}
	}
	
	public void keyPressed(int keyCode)
	{
		m.nextDisplay();
	}
}
