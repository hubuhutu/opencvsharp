namespace OpenCvSharp.CPlusPlus
{
	public class DetectionROI
	{
		public double Scale
		{
			get;
			set;
		}

		public Point[] Locations
		{
			get;
			set;
		}

		public double[] Confidences
		{
			get;
			set;
		}
	}
}
