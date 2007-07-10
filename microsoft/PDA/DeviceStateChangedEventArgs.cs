/*
 * Created by Andrés Ribera
 * Copyright (C) 2007 hipoqih.com, All Rights Reserved.
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, If not, see <http://www.gnu.org/licenses/>.*/

#region Using directives

using System;

#endregion

namespace plugin
{
    /// <summary>
    /// Event args used for DeviceStateChanged event.
    /// </summary>
    public class DeviceStateChangedEventArgs: EventArgs
    {
        public DeviceStateChangedEventArgs(GpsDeviceState deviceState)
        {
            this.deviceState = deviceState;
        }

        /// <summary>
        /// Gets the new device state when the GPS reports a new device state.
        /// </summary>
        public GpsDeviceState DeviceState
        {
            get 
            {
                return deviceState;
            }
        }

        private GpsDeviceState deviceState;
    }
}
