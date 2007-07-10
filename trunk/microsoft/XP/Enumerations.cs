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
