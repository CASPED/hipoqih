using System;

namespace GPSUtilities
{
	/// <summary>
	/// Summary description for GroundSpeedInformation.
	/// </summary>
	public class GroundSpeedInformation
	{

		private LatLong _ll;
		private double _groundspeed;
		private double _direction;
		private DateTime _time;

		internal GroundSpeedInformation(LatLong latlong, double direction, DateTime time, double groundspeed)
		{
			_ll = latlong;
			_groundspeed = groundspeed;
			_direction = direction;
			_time = time;
		}

		public double GroundSpeed
		{
			get
			{
				return _groundspeed;
			}
		}

		public string BearingText
		{
			get
			{
				return LocationInformation.GetDirectionFromOrientation(_direction);
			}
		}

		public double Bearing
		{
			get
			{
				return _direction;
			}
		}

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
