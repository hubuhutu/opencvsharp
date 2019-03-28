using System;

namespace OpenCvSharp.CPlusPlus
{
	internal sealed class DenseOpticalFlowExtImpl : DenseOpticalFlowExt
	{
		private bool disposed;

		private Ptr<DenseOpticalFlowExt> detectorPtr;

		public override IntPtr InfoPtr => NativeMethods.superres_DenseOpticalFlowExt_info(ptr);

		private DenseOpticalFlowExtImpl()
		{
			detectorPtr = null;
			ptr = IntPtr.Zero;
		}

		internal static DenseOpticalFlowExtImpl FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid DenseOpticalFlowExt pointer");
			}
			Ptr<DenseOpticalFlowExt> ptr2 = new Ptr<DenseOpticalFlowExt>(ptr);
			return new DenseOpticalFlowExtImpl
			{
				detectorPtr = ptr2,
				ptr = ptr2.Obj
			};
		}

		internal static DenseOpticalFlowExtImpl FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid DenseOpticalFlowExt pointer");
			}
			return new DenseOpticalFlowExtImpl
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

		public override void Calc(InputArray frame0, InputArray frame1, OutputArray flow1, OutputArray flow2 = null)
		{
			if (frame0 == null)
			{
				throw new ArgumentNullException("frame0");
			}
			if (frame1 == null)
			{
				throw new ArgumentNullException("frame1");
			}
			if (flow1 == null)
			{
				throw new ArgumentNullException("flow1");
			}
			frame0.ThrowIfDisposed();
			frame1.ThrowIfDisposed();
			flow1.ThrowIfNotReady();
			flow2?.ThrowIfNotReady();
			NativeMethods.superres_DenseOpticalFlowExt_calc(ptr, frame0.CvPtr, frame1.CvPtr, flow1.CvPtr, Cv2.ToPtr(flow2));
			flow1.Fix();
			flow2?.Fix();
			GC.KeepAlive(frame0);
			GC.KeepAlive(frame1);
		}

		public override void CollectGarbage()
		{
			NativeMethods.superres_DenseOpticalFlowExt_collectGarbage(ptr);
		}
	}
}
