using System;

namespace OpenCvSharp.CPlusPlus
{
	public static class SimilarRects
	{
		public static bool Compare(double eps, Rect r1, Rect r2)
		{
			double num = eps * (double)(Math.Min(r1.Width, r2.Width) + Math.Min(r1.Height, r2.Height)) * 0.5;
			if ((double)Math.Abs(r1.X - r2.X) <= num && (double)Math.Abs(r1.Y - r2.Y) <= num && (double)Math.Abs(r1.X + r1.Width - r2.X - r2.Width) <= num)
			{
				return (double)Math.Abs(r1.Y + r1.Height - r2.Y - r2.Height) <= num;
			}
			return false;
		}
	}
}
