using System;

namespace OpenCvSharp.CPlusPlus
{
	internal sealed class FrameSourceImpl : FrameSource
	{
		private bool disposed;

		private Ptr<FrameSource> detectorPtr;

		private FrameSourceImpl()
		{
			detectorPtr = null;
			ptr = IntPtr.Zero;
		}

		internal static FrameSource FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid FrameSource pointer");
			}
			FrameSourceImpl frameSourceImpl = new FrameSourceImpl();
			frameSourceImpl.ptr = (frameSourceImpl.detectorPtr = new Ptr<FrameSource>(ptr)).Obj;
			return frameSourceImpl;
		}

		internal static FrameSource FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid FrameSource pointer");
			}
			return new FrameSourceImpl
			{
				detectorPtr = null,
				ptr = ptr
			};
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						if (detectorPtr != null)
						{
							detectorPtr.Dispose();
						}
						detectorPtr = null;
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

		public override void NextFrame(OutputArray frame)
		{
			ThrowIfDisposed();
			if (frame == null)
			{
				throw new ArgumentNullException("frame");
			}
			frame.ThrowIfNotReady();
			NativeMethods.superres_FrameSource_nextFrame(ptr, frame.CvPtr);
			frame.Fix();
		}

		public override void Reset()
		{
			ThrowIfDisposed();
			NativeMethods.superres_FrameSource_reset(ptr);
		}
	}
}
