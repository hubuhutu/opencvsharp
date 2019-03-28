using System;

namespace OpenCvSharp.CPlusPlus
{
	public class BackgroundSubtractorMOG : BackgroundSubtractor
	{
		private Ptr<BackgroundSubtractorMOG> objectPtr;

		private bool disposed;

		public override IntPtr InfoPtr => NativeMethods.video_BackgroundSubtractorMOG_info(ptr);

		public BackgroundSubtractorMOG()
		{
			IntPtr intPtr = NativeMethods.video_BackgroundSubtractorMOG_new1();
			if (intPtr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create BackgroundSubtractorMOG");
			}
			objectPtr = new Ptr<BackgroundSubtractorMOG>(intPtr);
			ptr = objectPtr.Obj;
		}

		public BackgroundSubtractorMOG(int history, int nmixtures, double backgroundRatio, double noiseSigma = 0.0)
		{
			IntPtr intPtr = NativeMethods.video_BackgroundSubtractorMOG_new2(history, nmixtures, backgroundRatio, noiseSigma);
			if (intPtr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create BackgroundSubtractorMOG");
			}
			objectPtr = new Ptr<BackgroundSubtractorMOG>(intPtr);
			ptr = objectPtr.Obj;
		}

		internal BackgroundSubtractorMOG(Ptr<BackgroundSubtractorMOG> objectPtr, IntPtr ptr)
		{
			this.objectPtr = objectPtr;
			base.ptr = ptr;
		}

		internal new static BackgroundSubtractorMOG FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid BackgroundSubtractorMOG pointer");
			}
			Ptr<BackgroundSubtractorMOG> ptr2 = new Ptr<BackgroundSubtractorMOG>(ptr);
			return new BackgroundSubtractorMOG(ptr2, ptr2.Obj);
		}

		internal new static BackgroundSubtractorMOG FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid BackgroundSubtractorMOG pointer");
			}
			return new BackgroundSubtractorMOG(null, ptr);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						if (objectPtr != null)
						{
							objectPtr.Dispose();
						}
						else
						{
							NativeMethods.video_BackgroundSubtractorMOG_delete(ptr);
						}
						objectPtr = null;
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

		public override void Run(InputArray image, OutputArray fgmask, double learningRate = 0.0)
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			if (fgmask == null)
			{
				throw new ArgumentNullException("fgmask");
			}
			image.ThrowIfDisposed();
			fgmask.ThrowIfNotReady();
			NativeMethods.video_BackgroundSubtractorMOG_operator(ptr, image.CvPtr, fgmask.CvPtr, learningRate);
			fgmask.Fix();
		}

		public virtual void Initialize(Size frameSize, int frameType)
		{
			NativeMethods.video_BackgroundSubtractorMOG_initialize(ptr, frameSize, frameType);
		}
	}
}
