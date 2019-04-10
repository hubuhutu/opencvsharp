using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public class StarDetector : FeatureDetector
	{
		private bool disposed;

		private Ptr<StarDetector> detectorPtr;

        public override IntPtr InfoPtr { get { return NativeMethods.features2d_StarDetector_info(ptr); } }

		public StarDetector(int maxSize = 45, int responseThreshold = 30, int lineThresholdProjected = 10, int lineThresholdBinarized = 8, int suppressNonmaxSize = 5)
		{
			ptr = NativeMethods.features2d_StarDetector_new(maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized, suppressNonmaxSize);
		}

		internal StarDetector(Ptr<StarDetector> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal StarDetector(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		internal new static StarDetector FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<StarDetector> pointer");
			}
			return new StarDetector(new Ptr<StarDetector>(ptr));
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
							NativeMethods.features2d_StarDetector_delete(ptr);
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

		public KeyPoint[] Run(Mat image)
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfDisposed();
            IntPtr keypoints;
            NativeMethods.features2d_StarDetector_detect(ptr, image.CvPtr, out keypoints);
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint(keypoints))
			{
				return vectorOfKeyPoint.ToArray();
			}
		}
	}
}
