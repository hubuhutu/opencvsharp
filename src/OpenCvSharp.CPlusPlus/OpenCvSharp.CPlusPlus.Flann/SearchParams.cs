using System;

namespace OpenCvSharp.CPlusPlus.Flann
{
	public class SearchParams : IndexParams
	{
		private bool disposed;

		public SearchParams()
			: this(32, 0f, sorted: true)
		{
		}

		public SearchParams(int checks)
			: this(checks, 0f, sorted: true)
		{
		}

		public SearchParams(int checks, float eps)
			: this(checks, eps, sorted: true)
		{
		}

		public SearchParams(int checks, float eps, bool sorted)
		{
			ptr = NativeMethods.flann_SearchParams_new(checks, eps, sorted ? 1 : 0);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create SearchParams");
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
							NativeMethods.flann_SearchParams_delete(ptr);
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
