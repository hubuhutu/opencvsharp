using System;

namespace OpenCvSharp.CPlusPlus
{
	public class DenseFeatureDetector : FeatureDetector
	{
		private bool disposed;

		private Ptr<DenseFeatureDetector> detectorPtr;

        public override IntPtr InfoPtr { get { return NativeMethods.features2d_DenseFeatureDetector_info(ptr); } }

		public DenseFeatureDetector(float initFeatureScale = 1f, int featureScaleLevels = 1, float featureScaleMul = 0.1f, int initXyStep = 6, int initImgBound = 0, bool varyXyStepWithScale = true, bool varyImgBoundWithScale = false)
		{
			ptr = NativeMethods.features2d_DenseFeatureDetector_new(initFeatureScale, featureScaleLevels, featureScaleMul, initXyStep, initImgBound, varyXyStepWithScale ? 1 : 0, varyImgBoundWithScale ? 1 : 0);
		}

		internal DenseFeatureDetector(Ptr<DenseFeatureDetector> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal DenseFeatureDetector(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		internal new static DenseFeatureDetector FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<DenseFeatureDetector> pointer");
			}
			return new DenseFeatureDetector(new Ptr<DenseFeatureDetector>(ptr));
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
							NativeMethods.features2d_DenseFeatureDetector_delete(ptr);
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
