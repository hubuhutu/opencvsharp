using System;

namespace OpenCvSharp.CPlusPlus
{
	public class StereoBM : DisposableCvObject
	{
		private bool disposed;

		public const int PREFILTER_NORMALIZED_RESPONSE = 0;

		public const int PREFILTER_XSOBEL = 1;

		public const int BASIC_PRESET = 0;

		public const int FISH_EYE_PRESET = 1;

		public const int NARROW_PRESET = 2;

		public StereoBM()
		{
			ptr = NativeMethods.calib3d_StereoBM_new1();
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public StereoBM(int preset, int nDisparities = 0, int sadWindowSize = 21)
		{
			ptr = NativeMethods.calib3d_StereoBM_new2(preset, nDisparities, sadWindowSize);
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
						if (ptr != IntPtr.Zero)
						{
							NativeMethods.calib3d_StereoBM_delete(ptr);
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

		public void Init(int preset, int nDisparities = 0, int sadWindowSize = 21)
		{
			NativeMethods.calib3d_StereoBM_init(ptr, preset, nDisparities, sadWindowSize);
		}

		public void Compute(InputArray left, InputArray right, OutputArray disp, int dispType = 3)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("StereoSGBM");
			}
			if (left == null)
			{
				throw new ArgumentNullException("left");
			}
			if (right == null)
			{
				throw new ArgumentNullException("right");
			}
			if (disp == null)
			{
				throw new ArgumentNullException("disp");
			}
			left.ThrowIfDisposed();
			right.ThrowIfDisposed();
			disp.ThrowIfNotReady();
			NativeMethods.calib3d_StereoBM_compute(ptr, left.CvPtr, right.CvPtr, disp.CvPtr, dispType);
			disp.Fix();
		}
	}
}
