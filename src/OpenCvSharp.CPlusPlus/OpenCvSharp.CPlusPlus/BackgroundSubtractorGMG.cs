using System;

namespace OpenCvSharp.CPlusPlus
{
	public class BackgroundSubtractorGMG : BackgroundSubtractor
	{
		private Ptr<BackgroundSubtractorGMG> objectPtr;

		private bool disposed;

		public unsafe int MaxFeatures
		{
			get
			{
				return *NativeMethods.video_BackgroundSubtractorGMG_maxFeatures(ptr);
			}
			set
			{
				*NativeMethods.video_BackgroundSubtractorGMG_maxFeatures(ptr) = value;
			}
		}

		public unsafe double LearningRate
		{
			get
			{
				return *NativeMethods.video_BackgroundSubtractorGMG_learningRate(ptr);
			}
			set
			{
				*NativeMethods.video_BackgroundSubtractorGMG_learningRate(ptr) = value;
			}
		}

		public unsafe int NumInitializationFrames
		{
			get
			{
				return *NativeMethods.video_BackgroundSubtractorGMG_numInitializationFrames(ptr);
			}
			set
			{
				*NativeMethods.video_BackgroundSubtractorGMG_numInitializationFrames(ptr) = value;
			}
		}

		public unsafe int QuantizationLevels
		{
			get
			{
				return *NativeMethods.video_BackgroundSubtractorGMG_quantizationLevels(ptr);
			}
			set
			{
				*NativeMethods.video_BackgroundSubtractorGMG_quantizationLevels(ptr) = value;
			}
		}

		public unsafe double BackgroundPrior
		{
			get
			{
				return *NativeMethods.video_BackgroundSubtractorGMG_backgroundPrior(ptr);
			}
			set
			{
				*NativeMethods.video_BackgroundSubtractorGMG_backgroundPrior(ptr) = value;
			}
		}

		public unsafe double DecisionThreshold
		{
			get
			{
				return *NativeMethods.video_BackgroundSubtractorGMG_decisionThreshold(ptr);
			}
			set
			{
				*NativeMethods.video_BackgroundSubtractorGMG_decisionThreshold(ptr) = value;
			}
		}

		public unsafe int SmoothingRadius
		{
			get
			{
				return *NativeMethods.video_BackgroundSubtractorGMG_smoothingRadius(ptr);
			}
			set
			{
				*NativeMethods.video_BackgroundSubtractorGMG_smoothingRadius(ptr) = value;
			}
		}

		public bool UpdateBackgroundModel
		{
			get
			{
				return NativeMethods.video_BackgroundSubtractorGMG_updateBackgroundModel_get(ptr) != 0;
			}
			set
			{
				NativeMethods.video_BackgroundSubtractorGMG_updateBackgroundModel_set(ptr, value ? 1 : 0);
			}
		}

		public override IntPtr InfoPtr => NativeMethods.video_BackgroundSubtractorGMG_info(ptr);

		public BackgroundSubtractorGMG()
		{
			IntPtr intPtr = NativeMethods.video_BackgroundSubtractorGMG_new();
			if (intPtr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create BackgroundSubtractorGMG");
			}
			objectPtr = new Ptr<BackgroundSubtractorGMG>(intPtr);
			ptr = objectPtr.Obj;
		}

		internal BackgroundSubtractorGMG(Ptr<BackgroundSubtractorGMG> objectPtr, IntPtr ptr)
		{
			this.objectPtr = objectPtr;
			base.ptr = ptr;
		}

		internal new static BackgroundSubtractorGMG FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid BackgroundSubtractorGMG pointer");
			}
			Ptr<BackgroundSubtractorGMG> ptr2 = new Ptr<BackgroundSubtractorGMG>(ptr);
			return new BackgroundSubtractorGMG(ptr2, ptr2.Obj);
		}

		internal new static BackgroundSubtractorGMG FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid BackgroundSubtractorGMG pointer");
			}
			return new BackgroundSubtractorGMG(null, ptr);
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
							NativeMethods.video_BackgroundSubtractorGMG_delete(ptr);
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
			NativeMethods.video_BackgroundSubtractorGMG_operator(ptr, image.CvPtr, fgmask.CvPtr, learningRate);
			fgmask.Fix();
		}

		public virtual void Initialize(Size frameSize, double min, double max)
		{
			NativeMethods.video_BackgroundSubtractorGMG_initialize(ptr, frameSize, min, max);
		}

		public new void Release()
		{
			NativeMethods.video_BackgroundSubtractorGMG_release(ptr);
		}
	}
}
