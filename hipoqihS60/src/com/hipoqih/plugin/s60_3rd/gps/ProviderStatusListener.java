package com.hipoqih.plugin.s60_3rd.gps;


public interface ProviderStatusListener
{
    /**
     * A Notification event that location provider has been selected.
     */
    public void providerSelectedEvent();

    /**
     * A Notification event about the first location update.
     */
    public void firstLocationUpdateEvent();
}
