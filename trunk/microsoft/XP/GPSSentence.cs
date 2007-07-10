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
	/// Summary description for GPSSentence.
	/// </summary>
	public class GPSSentence
	{

		private string _buffer;
		private string _innerbuffer;
		private GPSSentenceType _type = GPSSentenceType.Unknown;
		private LatLong _latlong;
		private double _groundSpeed;
		private double _direction;
		private double _altitude;
		private int _satellitesUsed;
		private double _pdop;
		private double _hdop;
		private double _vdop;
		private DateTime _time;
		private bool _isValid = false;
		private Units _units = Units.Kilometers;

		internal GPSSentence(string buffer)
		{
			_buffer = buffer;
			//Initialize
			if(buffer == null || buffer.Length <=6)
				Initialize(string.Empty);
			else
			{
				if(buffer.StartsWith("$"))
				{
					//Get Inner buffer
					int checkumindex = _buffer.IndexOf("*", 0);
					if(checkumindex > 0)
					{
						_innerbuffer = _buffer.Substring(0, checkumindex);
					}
					else
					{
						_innerbuffer = _buffer;
					}
					Initialize(_innerbuffer);
					_isValid = true;
				}
				else
				{
					_isValid = false;
				}
			}
		}

		private void Initialize(string sentence)
		{

			if(sentence == null || sentence.Length <= 6)
			{
				return;
			}
			else
			{
				//All buffers must start with standard headers
				string firstSixChars = sentence.Substring(0, 6);

				//Right now I'm only supporting GPRMC (position and time)
				switch(firstSixChars)
				{
					//Global positioning system fixed data
					case "$GPGGA":
						_type = GPSSentenceType.FixedData;
						//Parse it to set values
						ParseFixedDataGPSSentence(sentence);
						break;
					//Geographic position - latitude / longitude
					case "$GPGLL":
						_type = GPSSentenceType.GeographicPosition;
						break;
					//GNSS DOP and active satellites
					case "$GPGSA":
						_type = GPSSentenceType.ActiveSatellites;
						//Parse Satellite information
						ParseActiveSatellitesSentence(sentence);
						break;
					//GNSS satellites in view
					case "$GPGSV":
						_type = GPSSentenceType.SatellitesInView;
						break;
					//Recommended minimum specific GNSS data
					case "$GPRMC":
						_type = GPSSentenceType.PositionAndTime;
						//Parse it to set values
						this.ParsePositionAndTimeGPSSentence(sentence);
						break;
					//Course over ground and ground speed
					case "$GPVTG":
						_type = GPSSentenceType.CourseOverGround;
						break;
					//Invalid string format
					default:
						_type = GPSSentenceType.Unknown;
						break;
				}
				
			}

		}

		private void ParseActiveSatellitesSentence(string sentence)
		{
			//Initialize Satellites Used
			_satellitesUsed = 0;
			//Initialize all precisions
			_pdop = 0.0;
			_vdop = 0.0;
			_hdop = 0.0;

			if(_type != GPSSentenceType.ActiveSatellites)
				return;

			string[] parts = sentence.Split(new char[] {','});

			System.Diagnostics.Debug.Assert(parts != null);

			if(parts.Length != 18)
				return;

			//Now count Satellites
			int satCount = 0;
			for(int i=3;i<15;i++)
			{
				if(parts[i] != null &&
					parts[i] != string.Empty)
				{
					satCount ++;
				}
			}
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
			//Get Position Dilusion Precision
			if(parts[15] != null && parts[15].Length > 0)
				_pdop = Convert.ToDouble(parts[15],nfi);

			//Get Horizontal Dilusion Precision
			if(parts[16] != null && parts[16].Length > 0)
				_hdop = Convert.ToDouble(parts[16],nfi);
            
			//Get Vertical Dilusion Precision
			if(parts[17] != null && parts[17].Length > 0)
				_vdop = Convert.ToDouble(parts[17],nfi);
		}

		private void ParsePositionAndTimeGPSSentence(string sentence)
		{

			//Initialize LatLong
			_latlong = new LatLong(0.0, 0.0);
			//Initialize speed
			_groundSpeed = 0.0;
			//Initialize Direction
			_direction = 0.0;
			//Initialize Time
			_time = DateTime.MinValue;

			if(_type != GPSSentenceType.PositionAndTime)
				return;

			string[] parts = sentence.Split(new char[] {','});

			System.Diagnostics.Debug.Assert(parts != null);

			if(parts.Length != 12)
				return;

			//Check validity
			if(parts[2].Length > 0)
			{
				if(parts[2] == "A")
					_isValid = true;
				else
					_isValid = false;
			}

			//Get Time
			//2nd part is the UTC Time
			//9 is the date
			if(parts[1].Length > 0 &&
				parts[9].Length > 0)
				_time = ConvertToDateTimeExact(parts[1]);


			double lat = 0.0;
			double lon = 0.0;

			//Get Latitude
			if(parts[3].Length > 0)
			{
				if(parts[4] != null && parts[4].Length > 0)
				{
					if(parts[4] == "S")
					{
						lat = -1 * ConvertDegreeMinuteSecondToDegrees(parts[3]);
					}
					else
					{
						lat = ConvertDegreeMinuteSecondToDegrees(parts[3]);
					}
				}
				else
				{
					lat = ConvertDegreeMinuteSecondToDegrees(parts[3]);
				}
			}


			//Get LatLong
			if(parts[5].Length > 0)
			{
				if(parts[6] != null && parts[6].Length > 0)
				{
					if(parts[6] == "W")
					{
						lon = -1 * ConvertDegreeMinuteSecondToDegrees(parts[5]);
					}
					else
					{
						lon = ConvertDegreeMinuteSecondToDegrees(parts[5]);
					}
				}
				else
				{
					lon = ConvertDegreeMinuteSecondToDegrees(parts[5]);
				}
			}


			//Create a latlon
			_latlong = new LatLong(lat, lon);


			//Get Direction
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;

			if(parts[8].Length > 0)
			{
				_direction = Convert.ToDouble(parts[8],nfi);
			}

			//Speed on ground
			if(parts[7].Length > 0)
			{
				_groundSpeed = ConvertKnotsToSpeed(parts[7], _units);
			}
		
		}

		private void ParseFixedDataGPSSentence(string sentence)
		{
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
			//Initialize LatLong
			_latlong = new LatLong(0.0, 0.0);
			//Initialize Direction
			_direction = 0.0;
			//Initialize Time
			_time = DateTime.MinValue;
			//Initialize altitude
			_altitude = 0.0;
			//Initialize Satellites Used
			_satellitesUsed = 0;

			if(_type != GPSSentenceType.FixedData)
				return;

			//Split the data to get the parts
			string[] parts = sentence.Split(new char[] {','});

			System.Diagnostics.Debug.Assert(parts != null);

			if(parts.Length != 15)
				return;

			//Get Time
			//2nd part is the UTC Time
			if(parts[1].Length > 0)
				_time = ConvertToDateTimeExact(parts[1]);


			double lat = 0.0;
			double lon = 0.0;

			//Get LatLong
			if(parts[2].Length > 0 && 
				parts[4].Length > 0)
			{
				lat = ConvertDegreeMinuteSecondToDegrees(parts[2]);
				lon = ConvertDegreeMinuteSecondToDegrees(parts[4]);
			}

			//Get Direction
			if(parts[3].Length > 0 &&
				parts[5].Length > 0)
			{
				if(parts[3] == "S")
				{
					lat = -lat;
				}
				if(parts[5] == "W")
				{
					lon = -lon;
				}
			}

			_latlong = new LatLong(lat, lon);

			//Satellites
			if(parts[7].Length > 0)
			{
				_satellitesUsed = Convert.ToInt32(parts[7], nfi);
			}

			//Altitude
			if(parts[9].Length > 0)
			{
				_altitude = Convert.ToDouble(parts[9], nfi);
			}
		
		}

		#region AllPublicProperties
		public LatLong LatLong
		{
			get
			{
				return _latlong;
			}
		}

		public double Altitude
		{
			get
			{
				return _altitude;
			}
		}

		public double Speed
		{
			get
			{
				return _groundSpeed;
			}
		}

		public DateTime Time
		{
			get
			{
				return _time;
			}
		}

		public int NumberOfSatellites
		{
			get
			{
				return _satellitesUsed;
			}
		}

		public double Direction
		{
			get
			{
				return _direction;
			}
		}

		public GPSSentenceType Type
		{
			get
			{
				return _type;
			}
		}

		public bool IsValid
		{
			get
			{
				if(_isValid)
				{
					if(_satellitesUsed >= 3)
						return true;
					else
						return false;
				}
				else
					return false;
			}
		}

		public int Length
		{
			get
			{
				if(_buffer != null)
					return _buffer.Length;
				else
					return 0;
			}
		}

		public string RawSentence
		{
			get
			{
				return _buffer;
			}
		}

		public double HorizontalDilusionPrecision
		{
			get
			{
				return _hdop;
			}
		}

		public double PositionDilusionPrecision
		{
			get
			{
				return _pdop;
			}
		}

		public double VerticalDilsutionPrecsion
		{
			get
			{
				return _vdop;
			}
		}


		#endregion

		#region utility functions

		/// <summary>
		/// Expects input in dddmm.mmmm or ddmm.mmmm format
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		private double ConvertDegreeMinuteSecondToDegrees(string input)
		{

			if(input == null || input.Length <=0)
				return 0;

            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
            double inputvalue = Convert.ToDouble(input,nfi);
			int degrees = Convert.ToInt32(inputvalue/100);
			double outv = degrees + (inputvalue - degrees * 100)/60;
            return outv;
            //return inputvalue;

		}

		private double ConvertKnotsToSpeed(string input, Units unit)
		{
			if(input == null || input.Length <= 0)
				return 0;

            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
            double knots = Convert.ToDouble(input, nfi);

			if(unit == Units.Kilometers)
			{
				//Return KMPH
				return knots * 1.852;
			}
			else
			{
				//Return MPH
				return knots * 1.151;

			}
		}


		private DateTime ConvertToDateTimeExact(string hhmmsssss)
		{
			if(hhmmsssss == null || hhmmsssss.Length <= 0)
				return DateTime.MinValue;

			//Extract hours
			int hours = Convert.ToInt32(hhmmsssss.Substring(0, 2));
			//Extract minutes
			int minutes = Convert.ToInt32(hhmmsssss.Substring(2,2));
			//Extract seconds
			int seconds = Convert.ToInt32(hhmmsssss.Substring(4,2));

			DateTime nowInUniversal = DateTime.Now.ToUniversalTime();
			return new DateTime(nowInUniversal.Year, nowInUniversal.Month, nowInUniversal.Day, 
								hours, minutes, seconds).ToLocalTime();
		}

		#endregion

	}
}
