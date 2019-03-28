using System;

namespace OpenCvSharp.CPlusPlus.Flann
{
	public class KDTreeIndexParams : IndexParams
	{
		private bool disposed;

		public KDTreeIndexParams(int trees = 4)
		{
			ptr = NativeMethods.flann_KDTreeIndexParams_new(trees);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create KDTreeIndexParams");
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
							NativeMethods.flann_KDTreeIndexParams_delete(ptr);
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
