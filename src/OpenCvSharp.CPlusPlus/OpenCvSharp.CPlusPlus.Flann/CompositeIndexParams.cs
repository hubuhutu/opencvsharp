using System;

namespace OpenCvSharp.CPlusPlus.Flann
{
	public class CompositeIndexParams : IndexParams
	{
		private bool disposed;

		public CompositeIndexParams(int trees = 4, int branching = 32, int iterations = 11, FlannCentersInit centersInit = FlannCentersInit.Random, float cbIndex = 0.2f)
		{
			ptr = NativeMethods.flann_CompositeIndexParams_new(trees, branching, iterations, centersInit, cbIndex);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create CompositeIndexParams");
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
							NativeMethods.flann_CompositeIndexParams_delete(ptr);
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
