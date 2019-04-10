using System;

namespace OpenCvSharp.CPlusPlus
{
	public class BackgroundSubtractorMOG2 : BackgroundSubtractor
	{
		private Ptr<BackgroundSubtractorMOG2> objectPtr;

		private bool disposed;

        public override IntPtr InfoPtr { get { return NativeMethods.video_BackgroundSubtractorMOG2_info(ptr); } }

		public BackgroundSubtractorMOG2()
		{
			IntPtr intPtr = NativeMethods.video_BackgroundSubtractorMOG2_new1();
			if (intPtr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create BackgroundSubtractorMOG2");
			}
			objectPtr = new Ptr<BackgroundSubtractorMOG2>(intPtr);
			ptr = objectPtr.Obj;
		}

		public BackgroundSubtractorMOG2(int history, float varThreshold, bool bShadowDetection = true)
		{
			IntPtr intPtr = NativeMethods.video_BackgroundSubtractorMOG2_new2(history, varThreshold, bShadowDetection ? 1 : 0);
			if (intPtr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create BackgroundSubtractorMOG2");
			}
			objectPtr = new Ptr<BackgroundSubtractorMOG2>(intPtr);
			ptr = objectPtr.Obj;
		}

		internal BackgroundSubtractorMOG2(Ptr<BackgroundSubtractorMOG2> objectPtr, IntPtr ptr)
		{
			this.objectPtr = objectPtr;
			base.ptr = ptr;
		}

		internal new static BackgroundSubtractorMOG2 FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid BackgroundSubtractorMOG2 pointer");
			}
			Ptr<BackgroundSubtractorMOG2> ptr2 = new Ptr<BackgroundSubtractorMOG2>(ptr);
			return new BackgroundSubtractorMOG2(ptr2, ptr2.Obj);
		}

		internal new static BackgroundSubtractorMOG2 FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid BackgroundSubtractorMOG2 pointer");
			}
			return new BackgroundSubtractorMOG2(null, ptr);
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
						else if (ptr != IntPtr.Zero)
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

		public override void Run(InputArray image, OutputArray fgmask, double learningRate = -1.0)
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
			NativeMethods.video_BackgroundSubtractorMOG2_operator(ptr, image.CvPtr, fgmask.CvPtr, learningRate);
			fgmask.Fix();
		}

		public override void GetBackgroundImage(OutputArray backgroundImage)
		{
			if (backgroundImage == null)
			{
				throw new ArgumentNullException("backgroundImage");
			}
			backgroundImage.ThrowIfNotReady();
			NativeMethods.video_BackgroundSubtractorMOG2_getBackgroundImage(ptr, backgroundImage.CvPtr);
			backgroundImage.Fix();
		}

		public virtual void Initialize(Size frameSize, int frameType)
		{
			NativeMethods.video_BackgroundSubtractorMOG2_initialize(ptr, frameSize, frameType);
		}
	}
}
