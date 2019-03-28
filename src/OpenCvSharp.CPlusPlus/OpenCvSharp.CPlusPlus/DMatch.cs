namespace OpenCvSharp.CPlusPlus
{
	public struct DMatch
	{
		public int QueryIdx;

		public int TrainIdx;

		public int ImgIdx;

		public float Distance;

		public static DMatch Empty()
		{
			return new DMatch(-1, -1, -1, float.MaxValue);
		}

		public DMatch(int queryIdx, int trainIdx, float distance)
		{
			this = new DMatch(queryIdx, trainIdx, -1, distance);
		}

		public DMatch(int queryIdx, int trainIdx, int imgIdx, float distance)
		{
			QueryIdx = queryIdx;
			TrainIdx = trainIdx;
			ImgIdx = imgIdx;
			Distance = distance;
		}

		public static bool operator <(DMatch d1, DMatch d2)
		{
			return d1.Distance < d2.Distance;
		}

		public static bool operator >(DMatch d1, DMatch d2)
		{
			return d1.Distance > d2.Distance;
		}

		public static explicit operator Vec4f(DMatch self)
		{
			return new Vec4f(self.QueryIdx, self.TrainIdx, self.ImgIdx, self.Distance);
		}

		public static explicit operator DMatch(Vec4f v)
		{
			return new DMatch((int)v.Item0, (int)v.Item1, (int)v.Item2, v.Item3);
		}

		public override string ToString()
		{
			return $"DMatch (QueryIdx:{QueryIdx}, TrainIdx:{TrainIdx}, ImgIdx:{ImgIdx}, Distance:{Distance})";
		}
	}
}
