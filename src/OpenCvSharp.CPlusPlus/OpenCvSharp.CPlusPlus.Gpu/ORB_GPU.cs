using System;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public class ORB_GPU : DisposableCvObject
	{
		public enum ScoreType
		{
			XRow,
			YRow,
			ResponseRow,
			AngleRow,
			OctaveRow,
			SizeRow,
			RowsCount
		}

		private bool disposed;

		public const int DEFAULT_FAST_THRESHOLD = 20;

		public int DescriptorSize
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				return NativeMethods.gpu_ORB_GPU_descriptorSize(ptr);
			}
		}

		public bool BlurForDescriptor
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				return NativeMethods.gpu_ORB_GPU_blurForDescriptor_get(ptr) != 0;
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				NativeMethods.gpu_ORB_GPU_blurForDescriptor_set(ptr, (!value) ? 1 : 0);
			}
		}

		public ORB_GPU(int nFeatures = 500, float scaleFactor = 1.2f, int nLevels = 8, int edgeThreshold = 31, int firstLevel = 0, int WTA_K = 2, ScoreType scoreType = ScoreType.XRow, int patchSize = 31)
		{
			Cv2Gpu.ThrowIfGpuNotAvailable();
			ptr = NativeMethods.gpu_ORB_GPU_new(nFeatures, scaleFactor, nLevels, edgeThreshold, firstLevel, WTA_K, (int)scoreType, patchSize);
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
						NativeMethods.gpu_ORB_GPU_delete(ptr);
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
			NativeMethods.gpu_ORB_GPU_release(ptr);
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
			NativeMethods.gpu_ORB_GPU_operator1(ptr, image.CvPtr, mask.CvPtr, keypoints.CvPtr);
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
				NativeMethods.gpu_ORB_GPU_operator2(ptr, image.CvPtr, mask.CvPtr, vectorOfKeyPoint.CvPtr);
				keypoints = vectorOfKeyPoint.ToArray();
			}
			GC.KeepAlive(image);
			GC.KeepAlive(mask);
		}

		public void Run(GpuMat image, GpuMat mask, GpuMat keypoints, GpuMat descriptors)
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
			if (descriptors == null)
			{
				throw new ArgumentNullException("descriptors");
			}
			NativeMethods.gpu_ORB_GPU_operator3(ptr, image.CvPtr, mask.CvPtr, keypoints.CvPtr, descriptors.CvPtr);
			GC.KeepAlive(image);
			GC.KeepAlive(mask);
			GC.KeepAlive(keypoints);
			GC.KeepAlive(descriptors);
		}

		public void Run(GpuMat image, GpuMat mask, out KeyPoint[] keypoints, GpuMat descriptors)
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
			if (descriptors == null)
			{
				throw new ArgumentNullException("descriptors");
			}
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
			{
				NativeMethods.gpu_ORB_GPU_operator4(ptr, image.CvPtr, mask.CvPtr, vectorOfKeyPoint.CvPtr, descriptors.CvPtr);
				keypoints = vectorOfKeyPoint.ToArray();
			}
			GC.KeepAlive(image);
			GC.KeepAlive(mask);
			GC.KeepAlive(descriptors);
		}

		public KeyPoint[] DownloadKeyPoints(GpuMat dKeypoints)
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
				NativeMethods.gpu_ORB_GPU_downloadKeyPoints(ptr, dKeypoints.CvPtr, vectorOfKeyPoint.CvPtr);
				result = vectorOfKeyPoint.ToArray();
			}
			GC.KeepAlive(dKeypoints);
			return result;
		}

		public KeyPoint[] ConvertKeyPoints(Mat hKeypoints)
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
				NativeMethods.gpu_ORB_GPU_convertKeyPoints(ptr, hKeypoints.CvPtr, vectorOfKeyPoint.CvPtr);
				result = vectorOfKeyPoint.ToArray();
			}
			GC.KeepAlive(hKeypoints);
			return result;
		}

		public void SetFastParams(int threshold, bool nonmaxSuppression)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			NativeMethods.gpu_ORB_GPU_setFastParams(ptr, threshold, nonmaxSuppression ? 1 : 0);
		}
	}
}
