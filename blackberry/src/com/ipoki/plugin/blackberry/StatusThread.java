/*
 * StatusThread.java
 *
 * © <your company here>, 2003-2007
 * Confidential and proprietary.
 */

package com.ipoki.plugin.blackberry;

import java.lang.*;

/*
* Thread can be running or stopped.
* While running, it can be paused.
*/
public class StatusThread extends Thread
{
    private static final int THREAD_TIMEOUT = 500;

    private volatile boolean _stop = false;
    private volatile boolean _running = false;
    private volatile boolean _isPaused = false;

    // Resume execution after pause
    public void go()
    {
        _running = true;
        _isPaused = false;
    }
    
    /*
    * _running = false is the flag that tells the thread to pause.
    * When the thread is actually pause, we signal it with _isPaused = true,
    */
    public void pause()
    {
        _running = false;
    }
    
    // Ends thread
    public void stop()
    {
        _stop = true;
    }
    
    public void run()
    {
        int i = 0;
        
        // main loop
        for(;;)
        {
            // Thread starts paused, waiting for the go()
            while (!_stop && !_running)
            {
                try
                {
                    sleep(THREAD_TIMEOUT);
                }
                catch ( InterruptedException e) 
                {
                    System.err.println(e.toString());
                }
            }
            
            // stop() was called
            if (_stop)
            {
                return;
            }
            
            // Loop until stopped or paused
            for(;;)
            {
                if (_stop)
                {
                    return;
                }
                
                // pause() was called
                if (!_running)
                {
                    _isPaused = true;
                    synchronized(this)
                    {
                        // Wake up waiting thread
                        this.notify();
                    }
                    break;
                }
            }
        }
    }
}
