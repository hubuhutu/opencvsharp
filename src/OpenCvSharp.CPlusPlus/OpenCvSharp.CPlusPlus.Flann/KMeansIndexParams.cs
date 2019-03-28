using System;

namespace OpenCvSharp.CPlusPlus.Flann
{
	public class KMeansIndexParams : IndexParams
	{
		private bool disposed;

		public KMeansIndexParams(int branching = 32, int iterations = 11, FlannCentersInit centersInit = FlannCentersInit.Random, float cbIndex = 0.2f)
		{
			ptr = NativeMethods.flann_KMeansIndexParams_new(branching, iterations, centersInit, cbIndex);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create KMeansIndexParams");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						if (ptr != IntPtr.Zero)
						{
							NativeMethods.flann_KMeansIndexParams_delete(ptr);
						}
						ptr = IntPtr.Zero;
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
	}
}
