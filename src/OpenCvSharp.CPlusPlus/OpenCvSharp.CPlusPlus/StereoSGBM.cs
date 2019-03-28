using System;

namespace OpenCvSharp.CPlusPlus
{
	public class StereoSGBM : DisposableCvObject
	{
		private bool disposed;

		public int MinDisparity
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				return NativeMethods.calib3d_StereoSGBM_minDisparity_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				NativeMethods.calib3d_StereoSGBM_minDisparity_set(ptr, value);
			}
		}

		public int NumberOfDisparities
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				return NativeMethods.calib3d_StereoSGBM_numberOfDisparities_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				NativeMethods.calib3d_StereoSGBM_numberOfDisparities_set(ptr, value);
			}
		}

		public int SADWindowSize
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				return NativeMethods.calib3d_StereoSGBM_SADWindowSize_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				NativeMethods.calib3d_StereoSGBM_SADWindowSize_set(ptr, value);
			}
		}

		public int PreFilterCap
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				return NativeMethods.calib3d_StereoSGBM_preFilterCap_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				NativeMethods.calib3d_StereoSGBM_preFilterCap_set(ptr, value);
			}
		}

		public int UniquenessRatio
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				return NativeMethods.calib3d_StereoSGBM_uniquenessRatio_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				NativeMethods.calib3d_StereoSGBM_uniquenessRatio_set(ptr, value);
			}
		}

		public int P1
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				return NativeMethods.calib3d_StereoSGBM_P1_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				NativeMethods.calib3d_StereoSGBM_P1_set(ptr, value);
			}
		}

		public int P2
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				return NativeMethods.calib3d_StereoSGBM_P2_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				NativeMethods.calib3d_StereoSGBM_P2_set(ptr, value);
			}
		}

		public int SpeckleWindowSize
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				return NativeMethods.calib3d_StereoSGBM_speckleWindowSize_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				NativeMethods.calib3d_StereoSGBM_speckleWindowSize_set(ptr, value);
			}
		}

		public int SpeckleRange
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				return NativeMethods.calib3d_StereoSGBM_speckleRange_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				NativeMethods.calib3d_StereoSGBM_speckleRange_set(ptr, value);
			}
		}

		public int Disp12MaxDiff
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				return NativeMethods.calib3d_StereoSGBM_disp12MaxDiff_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				NativeMethods.calib3d_StereoSGBM_disp12MaxDiff_set(ptr, value);
			}
		}

		public bool FullDP
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				return NativeMethods.calib3d_StereoSGBM_fullDP_get(ptr) != 0;
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("StereoSGBM");
				}
				NativeMethods.calib3d_StereoSGBM_fullDP_set(ptr, value ? 1 : 0);
			}
		}

		public StereoSGBM()
		{
			ptr = NativeMethods.calib3d_StereoSGBM_new1();
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public StereoSGBM(int minDisparity, int numDisparities, int sadWindowSize, int p1 = 0, int p2 = 0, int disp12MaxDiff = 0, int preFilterCap = 0, int uniquenessRatio = 0, int speckleWindowSize = 0, int speckleRange = 0, bool fullDP = false)
		{
			ptr = NativeMethods.calib3d_StereoSGBM_new2(minDisparity, numDisparities, sadWindowSize, p1, p2, disp12MaxDiff, preFilterCap, uniquenessRatio, speckleWindowSize, speckleRange, fullDP);
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
							NativeMethods.calib3d_StereoSGBM_delete(ptr);
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

		public void Compute(InputArray left, InputArray right, OutputArray disp)
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
			NativeMethods.calib3d_StereoSGBM_compute(ptr, left.CvPtr, right.CvPtr, disp.CvPtr);
			disp.Fix();
		}
	}
}
