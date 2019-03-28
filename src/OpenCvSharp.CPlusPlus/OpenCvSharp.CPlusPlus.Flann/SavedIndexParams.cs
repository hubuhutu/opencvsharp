using System;

namespace OpenCvSharp.CPlusPlus.Flann
{
	public class SavedIndexParams : IndexParams
	{
		private bool disposed;

		public SavedIndexParams(string filename)
		{
			if (string.IsNullOrEmpty(filename))
			{
				throw new ArgumentNullException("filename");
			}
			ptr = NativeMethods.flann_SavedIndexParams_new(filename);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create SavedIndexParams");
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
							NativeMethods.flann_SavedIndexParams_delete(ptr);
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
