using System;

namespace OpenCvSharp.CPlusPlus.Flann
{
	public class LinearIndexParams : IndexParams
	{
		private bool disposed;

		public LinearIndexParams()
		{
			ptr = NativeMethods.flann_LinearIndexParams_new();
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create LinearIndexParams");
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
							NativeMethods.flann_LinearIndexParams_delete(ptr);
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
