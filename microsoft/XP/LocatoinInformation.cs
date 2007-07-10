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

using System;

namespace GPSUtilities
{
	/// <summary>
	/// Summary description for LocatoinInformation.
	/// </summary>
	public class LocationInformation
	{

		private LatLong _ll;
		private double _altitude;
		private double _direction;
		private DateTime _time;

		internal LocationInformation(LatLong latlong, Double altitude, double direction, DateTime time)
		{
			_ll = latlong;
			_altitude = altitude;
			_direction = direction;
			_time = time;
		}

		internal static string GetDirectionFromOrientation(double degrees)
		{
			string direction = string.Empty;
			//Anything between 0-20 and 340-360 is showed as north
			if((degrees >= 0 && degrees <20) || (degrees <= 360 && degrees > 340))
			{
				direction = "N";
			}
				// degrees in between 70 and 110
			else if(degrees >= 70 && degrees <= 110)
			{
				direction = "E";
			}
				//degrees in between 160 - 200
			else if(degrees >= 160 && degrees <= 200)
			{
				direction = "S";
			}
				//degrees in between 250 and 290
			else if(degrees >= 250 && degrees <= 290)
			{
				direction = "W";
			}
			else if(degrees > 0 && degrees < 90)
			{
				direction = "NE";
			}
			else if(degrees > 90 && degrees < 180)
			{
				direction = "SE";
			}
			else if(degrees > 180 && degrees < 270)
			{
				direction = "SW";
			}
			else if(degrees > 270 && degrees < 360)
			{
				direction = "NW";
			}

			return direction;
		}

		public double Altitude
		{
			get
			{
				return _altitude;
			}
		}

//		public string Direction
//		{
//			get
//			{
//				return LocationInformation.GetDirectionFromOrientation(_direction);
//			}
//		}
//
//		public double Orientation
//		{
//			get
//			{
//				return _direction;
//			}
//		}

		public DateTime TimeStamp
		{
			get
			{
				return _time;
			}
		}

		public double Latitude
		{
			get
			{
				return _ll.Latitude;
			}
		}

		public double Longitude
		{
			get
			{
				return _ll.Longitude;
			}
		}

	}
}
