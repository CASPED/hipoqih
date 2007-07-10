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
	/// Summary description for SatelliteInformation.
	/// </summary>
	public class SatelliteInformation
	{

		private int _numOfSatellites;
		private double _positionDilusionPrecision;
		private double _horizontalDilusionPrecision;
		private double _verticalDilusionPrecision;

		public SatelliteInformation(int numOfSatellites, double positionDilusionPrecision, 
						double horizontalDilusionPrecision, double verticalDilusionPrecision)
		{
			_numOfSatellites = numOfSatellites;
			_positionDilusionPrecision = positionDilusionPrecision;
			_horizontalDilusionPrecision = horizontalDilusionPrecision;
			_verticalDilusionPrecision = verticalDilusionPrecision;
		}

		public int NumberOfSatellitesInView
		{
			get
			{
				return _numOfSatellites;
			}
		}

		public double PositionDilusionPrecision
		{
			get
			{
				return _positionDilusionPrecision;
			}
		}

		public double HorizontalDilusionPrecision
		{
			get
			{
				return _horizontalDilusionPrecision;
			}
		}

		public double VerticalDilusionPrecision
		{
			get
			{
				return _verticalDilusionPrecision;
			}
		}

	}
}
