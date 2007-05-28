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
