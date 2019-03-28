using System;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public class CascadeClassifier_GPU : DisposableCvObject
	{
		private bool disposed;

		public bool FindLargestObject
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				return NativeMethods.gpu_CascadeClassifier_GPU_findLargestObject_get(ptr) != 0;
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				NativeMethods.gpu_CascadeClassifier_GPU_findLargestObject_set(ptr, (!value) ? 1 : 0);
			}
		}

		public bool VisualizeInPlace
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				return NativeMethods.gpu_CascadeClassifier_GPU_visualizeInPlace_get(ptr) != 0;
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				NativeMethods.gpu_CascadeClassifier_GPU_visualizeInPlace_set(ptr, (!value) ? 1 : 0);
			}
		}

		public CascadeClassifier_GPU()
		{
			Cv2Gpu.ThrowIfGpuNotAvailable();
			ptr = NativeMethods.gpu_CascadeClassifier_GPU_new1();
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public CascadeClassifier_GPU(string fileName)
		{
			Cv2Gpu.ThrowIfGpuNotAvailable();
			ptr = NativeMethods.gpu_CascadeClassifier_GPU_new2(fileName);
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
						NativeMethods.gpu_CascadeClassifier_GPU_delete(ptr);
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
			NativeMethods.gpu_CascadeClassifier_GPU_release(ptr);
		}

		public int DetectMultiScale(GpuMat image, GpuMat objectsBuf, double scaleFactor = 1.2, int minNeighbors = 4, Size? minSize = default(Size?))
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			if (objectsBuf == null)
			{
				throw new ArgumentNullException("objectsBuf");
			}
			CvSize minSize2 = minSize.GetValueOrDefault(default(Size));
			int result = NativeMethods.gpu_CascadeClassifier_GPU_detectMultiScale1(ptr, image.CvPtr, objectsBuf.CvPtr, scaleFactor, minNeighbors, minSize2);
			GC.KeepAlive(image);
			GC.KeepAlive(objectsBuf);
			return result;
		}

		public int DetectMultiScale(GpuMat image, GpuMat objectsBuf, Size maxObjectSize, Size? minSize = default(Size?), double scaleFactor = 1.1, int minNeighbors = 4)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			if (objectsBuf == null)
			{
				throw new ArgumentNullException("objectsBuf");
			}
			CvSize minSize2 = minSize.GetValueOrDefault(default(Size));
			int result = NativeMethods.gpu_CascadeClassifier_GPU_detectMultiScale2(ptr, image.CvPtr, objectsBuf.CvPtr, maxObjectSize, minSize2, scaleFactor, minNeighbors);
			GC.KeepAlive(image);
			GC.KeepAlive(objectsBuf);
			return result;
		}

		public Size GetClassifierSize()
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			return NativeMethods.gpu_CascadeClassifier_GPU_getClassifierSize(ptr);
		}
	}
}
