using System;

namespace OpenCvSharp.CPlusPlus
{
	public class MSER : FeatureDetector
	{
		private bool disposed;

		private Ptr<MSER> detectorPtr;

		public override IntPtr InfoPtr => NativeMethods.features2d_MSER_info(ptr);

		public MSER(int delta = 5, int minArea = 60, int maxArea = 14400, double maxVariation = 0.25, double minDiversity = 0.2, int maxEvolution = 200, double areaThreshold = 1.01, double minMargin = 0.003, int edgeBlurSize = 5)
		{
			ptr = NativeMethods.features2d_MSER_new(delta, minArea, maxArea, maxVariation, minDiversity, maxEvolution, areaThreshold, minMargin, edgeBlurSize);
		}

		internal MSER(Ptr<MSER> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal MSER(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		internal new static MSER FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<MSER> pointer");
			}
			return new MSER(new Ptr<MSER>(ptr));
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
							NativeMethods.features2d_MSER_delete(ptr);
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

		public Point[][] Run(Mat image, Mat mask)
		{
			ThrowIfDisposed();
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfDisposed();
			NativeMethods.features2d_MSER_detect(ptr, image.CvPtr, out IntPtr msers, Cv2.ToPtr(mask));
			using (VectorOfVectorPoint vectorOfVectorPoint = new VectorOfVectorPoint(msers))
			{
				return vectorOfVectorPoint.ToArray();
			}
		}
	}
}
