using System;

namespace GPSUtilities
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public enum GPSTrackerEventType
	{
		FoundGPSOnCOMPort = 0,
		ReceivedGPSStream =1,
		GenericNotify = 2,
		NoGPSFoundOnCOMPort = 3
	}

	internal enum GPSWorkerThreadState
	{
		Exited =0,
		Running = 1,
		Paused = 2
	}

	public enum GPSSentenceType
	{
		Unknown = -1,
		FixedData = 0,
		GeographicPosition = 1,
		ActiveSatellites = 2,
		SatellitesInView = 3,
		PositionAndTime = 4,
		CourseOverGround = 5
	}

	public enum Direction
	{
		Unknown = -1,
		North = 0,
		South = 1,
		East = 2,
		West = 3,
		NorthEast = 4,
		NorthWest = 5,
		SouthEast = 6,
		SouthWest = 7
	}

	public enum Units
	{
		Miles = 0,
		Kilometers = 1
	}

	public enum CommPortScanStatus
	{
		Scanning = 0,
		GPSFound = 1,
		GPSNotFound = 2
	}
}
