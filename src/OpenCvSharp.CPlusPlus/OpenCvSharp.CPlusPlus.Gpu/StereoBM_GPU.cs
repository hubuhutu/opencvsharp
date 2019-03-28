using System;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public class StereoBM_GPU : DisposableCvObject
	{
		private bool disposed;

		public const int BASIC_PRESET = 0;

		public const int PREFILTER_XSOBEL = 1;

		public const int DEFAULT_NDISP = 64;

		public const int DEFAULT_WINSZ = 19;

		public unsafe int Preset
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoBM_GPU");
				}
				return *NativeMethods.gpu_StereoBM_GPU_preset(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoBM_GPU");
				}
				*NativeMethods.gpu_StereoBM_GPU_preset(ptr) = value;
			}
		}

		public unsafe int Ndisp
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoBM_GPU");
				}
				return *NativeMethods.gpu_StereoBM_GPU_ndisp(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoBM_GPU");
				}
				*NativeMethods.gpu_StereoBM_GPU_ndisp(ptr) = value;
			}
		}

		public unsafe int WinSize
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoBM_GPU");
				}
				return *NativeMethods.gpu_StereoBM_GPU_winSize(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoBM_GPU");
				}
				*NativeMethods.gpu_StereoBM_GPU_winSize(ptr) = value;
			}
		}

		public unsafe float AvergeTexThreshold
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoBM_GPU");
				}
				return *NativeMethods.gpu_StereoBM_GPU_avergeTexThreshold(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoBM_GPU");
				}
				*NativeMethods.gpu_StereoBM_GPU_avergeTexThreshold(ptr) = value;
			}
		}

		public StereoBM_GPU()
		{
			Cv2Gpu.ThrowIfGpuNotAvailable();
			ptr = NativeMethods.gpu_StereoBM_GPU_new1();
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public StereoBM_GPU(int preset, int ndisparities = 64, int winSize = 19)
		{
			Cv2Gpu.ThrowIfGpuNotAvailable();
			ptr = NativeMethods.gpu_StereoBM_GPU_new2(preset, ndisparities, winSize);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public void Release()
		{
			Dispose(disposing: true);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.gpu_StereoBM_GPU_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static bool CheckIfGpuCallReasonable()
		{
			return NativeMethods.gpu_StereoBM_GPU_checkIfGpuCallReasonable() != 0;
		}

		public void Run(GpuMat left, GpuMat right, GpuMat disparity)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("StereoBM_GPU");
			}
			if (left == null)
			{
				throw new ArgumentNullException("left");
			}
			if (right == null)
			{
				throw new ArgumentNullException("right");
			}
			if (disparity == null)
			{
				throw new ArgumentNullException("disparity");
			}
			NativeMethods.gpu_StereoBM_GPU_run1(ptr, left.CvPtr, right.CvPtr, disparity.CvPtr);
		}
	}
}
