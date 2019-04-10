using System;

namespace OpenCvSharp.CPlusPlus
{
	public class BackgroundSubtractor : Algorithm
	{
		private Ptr<BackgroundSubtractor> objectPtr;

		private bool disposed;

        public override IntPtr InfoPtr { get { return NativeMethods.video_BackgroundSubtractor_info(ptr); } }

		internal static BackgroundSubtractor FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid BackgroundSubtractor pointer");
			}
			Ptr<BackgroundSubtractor> ptr2 = new Ptr<BackgroundSubtractor>(ptr);
			return new BackgroundSubtractor
			{
				objectPtr = ptr2,
				ptr = ptr2.Obj
			};
		}

		internal static BackgroundSubtractor FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid BackgroundSubtractor pointer");
			}
			return new BackgroundSubtractor
			{
				objectPtr = null,
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
						if (objectPtr != null)
						{
							objectPtr.Dispose();
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

		public virtual void Run(InputArray image, OutputArray fgmask, double learningRate = 0.0)
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
			NativeMethods.video_BackgroundSubtractor_operator(ptr, image.CvPtr, fgmask.CvPtr, learningRate);
			fgmask.Fix();
		}

		public virtual void GetBackgroundImage(OutputArray backgroundImage)
		{
			if (backgroundImage == null)
			{
				throw new ArgumentNullException("backgroundImage");
			}
			backgroundImage.ThrowIfNotReady();
			NativeMethods.video_BackgroundSubtractor_getBackgroundImage(ptr, backgroundImage.CvPtr);
			backgroundImage.Fix();
		}
	}
}
