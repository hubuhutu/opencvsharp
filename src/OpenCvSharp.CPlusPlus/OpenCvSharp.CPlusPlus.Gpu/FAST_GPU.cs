using System;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public class FAST_GPU : DisposableCvObject
	{
		private bool disposed;

		public const int FEATURE_SIZE = 7;

		public bool NonmaxSuppression
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				return NativeMethods.gpu_FAST_GPU_nonmaxSuppression_get(ptr) != 0;
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				NativeMethods.gpu_FAST_GPU_nonmaxSuppression_set(ptr, (!value) ? 1 : 0);
			}
		}

		public int Threshold
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				return NativeMethods.gpu_FAST_GPU_threshold_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				NativeMethods.gpu_FAST_GPU_threshold_set(ptr, value);
			}
		}

		public double KeypointsRatio
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				return NativeMethods.gpu_FAST_GPU_keypointsRatio_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				NativeMethods.gpu_FAST_GPU_keypointsRatio_set(ptr, value);
			}
		}

		public FAST_GPU(int threshold, bool nonmaxSuppression = true, double keypointsRatio = 0.05)
		{
			Cv2Gpu.ThrowIfGpuNotAvailable();
			ptr = NativeMethods.gpu_FAST_GPU_new(threshold, nonmaxSuppression ? 1 : 0, keypointsRatio);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.gpu_FAST_GPU_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public void Release()
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			NativeMethods.gpu_FAST_GPU_release(ptr);
		}

		public void Run(GpuMat image, GpuMat mask, GpuMat keypoints)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			if (mask == null)
			{
				throw new ArgumentNullException("mask");
			}
			if (keypoints == null)
			{
				throw new ArgumentNullException("keypoints");
			}
			NativeMethods.gpu_FAST_GPU_operator1(ptr, image.CvPtr, mask.CvPtr, keypoints.CvPtr);
			GC.KeepAlive(image);
			GC.KeepAlive(mask);
			GC.KeepAlive(keypoints);
		}

		public void Run(GpuMat image, GpuMat mask, out KeyPoint[] keypoints)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			if (mask == null)
			{
				throw new ArgumentNullException("mask");
			}
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
			{
				NativeMethods.gpu_FAST_GPU_operator2(ptr, image.CvPtr, mask.CvPtr, vectorOfKeyPoint.CvPtr);
				keypoints = vectorOfKeyPoint.ToArray();
			}
			GC.KeepAlive(image);
			GC.KeepAlive(mask);
		}

		public KeyPoint[] DownloadKeypoints(GpuMat dKeypoints)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (dKeypoints == null)
			{
				throw new ArgumentNullException("dKeypoints");
			}
			KeyPoint[] result;
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
			{
				NativeMethods.gpu_FAST_GPU_downloadKeypoints(ptr, dKeypoints.CvPtr, vectorOfKeyPoint.CvPtr);
				result = vectorOfKeyPoint.ToArray();
			}
			GC.KeepAlive(dKeypoints);
			return result;
		}

		public KeyPoint[] ConvertKeypoints(Mat hKeypoints)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (hKeypoints == null)
			{
				throw new ArgumentNullException("hKeypoints");
			}
			KeyPoint[] result;
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
			{
				NativeMethods.gpu_FAST_GPU_convertKeypoints(ptr, hKeypoints.CvPtr, vectorOfKeyPoint.CvPtr);
				result = vectorOfKeyPoint.ToArray();
			}
			GC.KeepAlive(hKeypoints);
			return result;
		}

		public int CalcKeyPointsLocation(GpuMat image, GpuMat mask)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			if (mask == null)
			{
				throw new ArgumentNullException("mask");
			}
			int result = NativeMethods.gpu_FAST_GPU_calcKeyPointsLocation(ptr, image.CvPtr, mask.CvPtr);
			GC.KeepAlive(image);
			GC.KeepAlive(mask);
			return result;
		}

		public int GetKeyPoints(GpuMat keypoints)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (keypoints == null)
			{
				throw new ArgumentNullException("keypoints");
			}
			int result = NativeMethods.gpu_FAST_GPU_getKeyPoints(ptr, keypoints.CvPtr);
			GC.KeepAlive(keypoints);
			return result;
		}
	}
}
