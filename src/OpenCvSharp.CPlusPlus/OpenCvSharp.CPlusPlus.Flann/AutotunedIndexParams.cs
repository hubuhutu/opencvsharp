using System;

namespace OpenCvSharp.CPlusPlus.Flann
{
	public class AutotunedIndexParams : IndexParams
	{
		private bool disposed;

		public AutotunedIndexParams(float targetPrecision = 0.9f, float buildWeight = 0.01f, float memoryWeight = 0f, float sampleFraction = 0.1f)
		{
			ptr = NativeMethods.flann_AutotunedIndexParams_new(targetPrecision, buildWeight, memoryWeight, sampleFraction);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create AutotunedIndexParams");
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
							NativeMethods.flann_AutotunedIndexParams_delete(ptr);
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
