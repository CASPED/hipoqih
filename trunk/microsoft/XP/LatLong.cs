using System;

namespace GPSUtilities
{
	/// <summary>
	/// Summary description for LatLong.
	/// </summary>
	public struct LatLong
	{
		public readonly double Latitude;
		public readonly double Longitude;
		public LatLong(double latitude, double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}
	}
}
