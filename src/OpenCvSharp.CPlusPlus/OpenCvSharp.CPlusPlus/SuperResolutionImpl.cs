using System;

namespace OpenCvSharp.CPlusPlus
{
	internal sealed class SuperResolutionImpl : SuperResolution
	{
		private bool disposed;

		private Ptr<SuperResolution> detectorPtr;

        public override IntPtr InfoPtr { get { return NativeMethods.superres_SuperResolution_info(ptr); } }

		private SuperResolutionImpl()
		{
			detectorPtr = null;
			ptr = IntPtr.Zero;
		}

		internal static SuperResolutionImpl FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid FrameSource pointer");
			}
			Ptr<SuperResolution> ptr2 = new Ptr<SuperResolution>(ptr);
			return new SuperResolutionImpl
			{
				detectorPtr = ptr2,
				ptr = ptr2.Obj
			};
		}

		internal static SuperResolutionImpl FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid FrameSource pointer");
			}
			return new SuperResolutionImpl
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

		public override void SetInput(FrameSource fs)
		{
			ThrowIfDisposed();
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			NativeMethods.superres_SuperResolution_setInput(ptr, fs.CvPtr);
		}

		public override void NextFrame(OutputArray frame)
		{
			ThrowIfDisposed();
			if (frame == null)
			{
				throw new ArgumentNullException("frame");
			}
			frame.ThrowIfNotReady();
			NativeMethods.superres_SuperResolution_nextFrame(ptr, frame.CvPtr);
			frame.Fix();
		}

		public override void Reset()
		{
			ThrowIfDisposed();
			NativeMethods.superres_SuperResolution_reset(ptr);
		}

		public override void CollectGarbage()
		{
			ThrowIfDisposed();
			NativeMethods.superres_SuperResolution_collectGarbage(ptr);
		}

		protected override void InitImpl(FrameSource fs)
		{
		}

		protected override void ProcessImpl(FrameSource fs, OutputArray output)
		{
		}
	}
}
