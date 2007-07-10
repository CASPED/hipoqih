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
    /// class that represents a gps coordinate in degrees, minutes, and seconds.  
    /// </summary>
    public class DegreesMinutesSeconds
    {
        int degrees;
        int signo;
        /// <summary>
        /// The degrees unit of the coordinate
        /// </summary>
        public int Degrees
        {
            get { return degrees; }
        }

        int minutes;
        /// <summary>
        /// The minutes unit of the coordinate
        /// </summary>
        public int Minutes
        {
            get { return minutes; }
        }

        double seconds;
        /// <summary>
        /// The seconds unit of the coordinate
        /// </summary>
        public double Seconds
        {
            get { return seconds; }
        }

        /// <summary>
        /// Constructs a new instance of DegreesMinutesSeconds converting 
        /// from decimal degrees
        /// </summary>
        /// <param name="decimalDegrees">Initial value as decimal degrees</param>
        public DegreesMinutesSeconds(double decimalDegrees)
        {
            degrees = (int)decimalDegrees;
            if (degrees >= 0)
                signo = 1;
            else
                signo = -1;
            
            double doubleMinutes = (Math.Abs(decimalDegrees) - Math.Abs((double)degrees)) * 60.0;

            minutes = (int)doubleMinutes;
            seconds = (doubleMinutes - (double)minutes) * 60.0;
        }

        /// <summary>
        /// Constructs a new instance of DegreesMinutesSeconds
        /// </summary>
        /// <param name="degrees">Degrees unit of the coordinate</param>
        /// <param name="minutes">Minutes unit of the coordinate</param>
        /// <param name="seconds">Seconds unit of the coordinate</param>
        public DegreesMinutesSeconds(int degrees, int minutes, double seconds)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.seconds = seconds;
            if (degrees >= 0)
                signo = 1;
            else
                signo = -1;
        }

        /// <summary>
        /// Converts the decimal, minutes, seconds coordinate to 
        /// decimal degrees
        /// </summary>
        /// <returns></returns>
        public double ToDecimalDegrees()
        {
            int absDegrees = Math.Abs(degrees);

            double val = (double)absDegrees + ((double)minutes / 60.0) + ((double)seconds / 3600.0);

            // MODIFICADO POR ANDRES!!!! -- castañazo en los Oº (London)
            //  return val * (absDegrees / degrees);
            return val * signo;
        }

        /// <summary>
        /// Converts the instance to a string in format: D M' S"
        /// </summary>
        /// <returns>string representation of degrees, minutes, seconds</returns>
        public override string ToString()
        {
            return degrees + "d " + minutes + "' " + seconds + "\"";
        }
    }
}
