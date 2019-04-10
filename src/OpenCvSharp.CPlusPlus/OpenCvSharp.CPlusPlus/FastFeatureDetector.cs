using System;

namespace OpenCvSharp.CPlusPlus
{
	public class FastFeatureDetector : FeatureDetector
	{
		private bool disposed;

		private Ptr<FastFeatureDetector> detectorPtr;

        public override IntPtr InfoPtr { get { return NativeMethods.features2d_FastFeatureDetector_info(ptr); } }

		public FastFeatureDetector(int threshold = 10, bool nonmaxSuppression = true)
		{
			ptr = NativeMethods.features2d_FastFeatureDetector_new(threshold, nonmaxSuppression ? 1 : 0);
		}

		internal FastFeatureDetector(Ptr<FastFeatureDetector> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal FastFeatureDetector(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		internal new static FastFeatureDetector FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<FastFeatureDetector> pointer");
			}
			return new FastFeatureDetector(new Ptr<FastFeatureDetector>(ptr));
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
							NativeMethods.features2d_FastFeatureDetector_delete(ptr);
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

		public KeyPoint[] Run(Mat image, Mat mask)
		{
			ThrowIfDisposed();
			return Detect(image, mask);
		}
	}
}
