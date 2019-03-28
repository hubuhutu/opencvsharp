using System;

namespace OpenCvSharp.CPlusPlus
{
	internal sealed class DenseOpticalFlowImpl : DenseOpticalFlow
	{
		private bool disposed;

		private Ptr<DenseOpticalFlow> detectorPtr;

		public override IntPtr InfoPtr => NativeMethods.video_DenseOpticalFlow_info(ptr);

		private DenseOpticalFlowImpl()
		{
			detectorPtr = null;
			ptr = IntPtr.Zero;
		}

		internal static DenseOpticalFlowImpl FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid DenseOpticalFlow pointer");
			}
			Ptr<DenseOpticalFlow> ptr2 = new Ptr<DenseOpticalFlow>(ptr);
			return new DenseOpticalFlowImpl
			{
				detectorPtr = ptr2,
				ptr = ptr2.Obj
			};
		}

		internal static DenseOpticalFlowImpl FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid DenseOpticalFlow pointer");
			}
			return new DenseOpticalFlowImpl
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

		public override void Calc(InputArray frame0, InputArray frame1, OutputArray flow)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("DenseOpticalFlowImpl");
			}
			if (frame0 == null)
			{
				throw new ArgumentNullException("frame0");
			}
			if (frame1 == null)
			{
				throw new ArgumentNullException("frame1");
			}
			if (flow == null)
			{
				throw new ArgumentNullException("flow");
			}
			frame0.ThrowIfDisposed();
			frame1.ThrowIfDisposed();
			flow.ThrowIfNotReady();
			NativeMethods.video_DenseOpticalFlow_calc(ptr, frame0.CvPtr, frame1.CvPtr, flow.CvPtr);
			flow.Fix();
		}

		public override void CollectGarbage()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("DenseOpticalFlowImpl");
			}
			NativeMethods.video_DenseOpticalFlow_collectGarbage(ptr);
		}
	}
}
