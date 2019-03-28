using System;

namespace OpenCvSharp.CPlusPlus
{
	public class BFMatcher : DescriptorMatcher
	{
		private bool disposed;

		private Ptr<BFMatcher> detectorPtr;

		public override IntPtr InfoPtr => NativeMethods.features2d_BFMatcher_info(ptr);

		public BFMatcher(NormType normType = NormType.L2, bool crossCheck = false)
		{
			ptr = NativeMethods.features2d_BFMatcher_new((int)normType, crossCheck ? 1 : 0);
		}

		internal BFMatcher(Ptr<BFMatcher> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal BFMatcher(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		internal new static BFMatcher FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<BFMatcher> pointer");
			}
			return new BFMatcher(new Ptr<BFMatcher>(ptr));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (detectorPtr != null)
					{
						detectorPtr.Dispose();
						detectorPtr = null;
					}
					else
					{
						if (ptr != IntPtr.Zero)
						{
							NativeMethods.features2d_BFMatcher_delete(ptr);
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

		public override bool IsMaskSupported()
		{
			ThrowIfDisposed();
			return NativeMethods.features2d_BFMatcher_isMaskSupported(ptr) != 0;
		}
	}
}
