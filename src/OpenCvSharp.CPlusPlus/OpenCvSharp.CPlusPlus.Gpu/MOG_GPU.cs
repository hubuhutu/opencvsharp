using System;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public class MOG_GPU : DisposableCvObject
	{
		private bool disposed;

		public unsafe int History
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				return *NativeMethods.gpu_MOG_GPU_history(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				*NativeMethods.gpu_MOG_GPU_history(ptr) = value;
			}
		}

		public unsafe float VarThreshold
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				return *NativeMethods.gpu_MOG_GPU_varThreshold(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				*NativeMethods.gpu_MOG_GPU_varThreshold(ptr) = value;
			}
		}

		public unsafe float BackgroundRatio
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				return *NativeMethods.gpu_MOG_GPU_backgroundRatio(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				*NativeMethods.gpu_MOG_GPU_backgroundRatio(ptr) = value;
			}
		}

		public unsafe float NoiseSigma
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				return *NativeMethods.gpu_MOG_GPU_noiseSigma(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				*NativeMethods.gpu_MOG_GPU_noiseSigma(ptr) = value;
			}
		}

		public MOG_GPU(int nMixtures = -1)
		{
			Cv2Gpu.ThrowIfGpuNotAvailable();
			ptr = NativeMethods.gpu_MOG_GPU_new(nMixtures);
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
						NativeMethods.gpu_MOG_GPU_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public void Initialize(Size frameSize, int frameType)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			NativeMethods.gpu_MOG_GPU_initialize(ptr, frameSize, frameType);
		}

		public void Update(GpuMat frame, GpuMat fgmask, float learningRate = 0f, Stream stream = null)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (frame == null)
			{
				throw new ArgumentNullException("frame");
			}
			if (fgmask == null)
			{
				throw new ArgumentNullException("fgmask");
			}
			stream = (stream ?? Stream.Null);
			NativeMethods.gpu_MOG_GPU_operator(ptr, frame.CvPtr, fgmask.CvPtr, learningRate, stream.CvPtr);
			GC.KeepAlive(frame);
			GC.KeepAlive(fgmask);
			GC.KeepAlive(stream);
		}

		public void GetBackgroundImage(GpuMat backgroundImage, Stream stream = null)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (backgroundImage == null)
			{
				throw new ArgumentNullException("backgroundImage");
			}
			stream = (stream ?? Stream.Null);
			NativeMethods.gpu_MOG_GPU_getBackgroundImage(ptr, backgroundImage.CvPtr, stream.CvPtr);
			GC.KeepAlive(backgroundImage);
			GC.KeepAlive(stream);
		}

		public void Release()
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			NativeMethods.gpu_MOG_GPU_release(ptr);
		}
	}
}
