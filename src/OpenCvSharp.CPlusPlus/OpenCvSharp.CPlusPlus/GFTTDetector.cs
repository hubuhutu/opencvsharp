using System;

namespace OpenCvSharp.CPlusPlus
{
	public class GFTTDetector : FeatureDetector
	{
		private bool disposed;

		private Ptr<GFTTDetector> detectorPtr;

        public override IntPtr InfoPtr { get { return NativeMethods.features2d_GFTTDetector_info(ptr); } }

		public GFTTDetector(int maxCorners = 1000, double qualityLevel = 0.01, double minDistance = 1.0, int blockSize = 3, bool useHarrisDetector = false, double k = 0.04)
		{
			ptr = NativeMethods.features2d_GFTTDetector_new(maxCorners, qualityLevel, minDistance, blockSize, useHarrisDetector ? 1 : 0, k);
		}

		internal GFTTDetector(Ptr<GFTTDetector> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal GFTTDetector(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		internal new static GFTTDetector FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<GFTTDetector> pointer");
			}
			return new GFTTDetector(new Ptr<GFTTDetector>(ptr));
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
							NativeMethods.features2d_GFTTDetector_delete(ptr);
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
