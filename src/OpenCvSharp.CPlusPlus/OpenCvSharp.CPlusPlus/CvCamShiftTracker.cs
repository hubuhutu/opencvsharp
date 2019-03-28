using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvCamShiftTracker : DisposableCvObject
	{
		private bool disposed;

		public CvCamShiftTracker()
		{
			ptr = NativeMethods.legacy_CvCamShiftTracker_new();
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.legacy_CvCamShiftTracker_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public float GetOrientation()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_get_orientation(ptr);
		}

		public float GetLength()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_get_length(ptr);
		}

		public float GetWidth()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_get_width(ptr);
		}

		public CvPoint2D32f GetCenter()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_get_center(ptr);
		}

		public CvRect GetWindow()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_get_window(ptr);
		}

		public int GetThreshold()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_get_threshold(ptr);
		}

		public int GetHistDims(params int[] dims)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_get_hist_dims(ptr, dims);
		}

		public int GetMinChVal(int channel)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_get_min_ch_val(ptr, channel);
		}

		public int GetMaxChVal(int channel)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_get_max_ch_val(ptr, channel);
		}

		public bool SetWindow(CvRect window)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_set_window(ptr, window) != 0;
		}

		public bool SetThreshold(int threshold)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_set_threshold(ptr, threshold) != 0;
		}

		public bool SetHistBinRange(int dim, int minVal, int maxVal)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_set_hist_bin_range(ptr, dim, minVal, maxVal) != 0;
		}

		public bool SetHistDims(int cDims, params int[] dims)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_set_hist_dims(ptr, cDims, dims) != 0;
		}

		public bool SetMinChVal(int channel, int val)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_set_min_ch_val(ptr, channel, val) != 0;
		}

		public bool SetMaxChVal(int channel, int val)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_set_max_ch_val(ptr, channel, val) != 0;
		}

		public virtual bool TrackObject(IplImage curFrame)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			if (curFrame == null)
			{
				throw new ArgumentNullException("curFrame");
			}
			return NativeMethods.legacy_CvCamShiftTracker_track_object(ptr, curFrame.CvPtr) != 0;
		}

		public virtual bool UpdateHistogram(IplImage curFrame)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			if (curFrame == null)
			{
				throw new ArgumentNullException("curFrame");
			}
			return NativeMethods.legacy_CvCamShiftTracker_update_histogram(ptr, curFrame.CvPtr) != 0;
		}

		public virtual void ResetHistogram()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			NativeMethods.legacy_CvCamShiftTracker_reset_histogram(ptr);
		}

		public virtual IplImage GetBackProject()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			IntPtr intPtr = NativeMethods.legacy_CvCamShiftTracker_get_back_project(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new IplImage(intPtr, isEnabledDispose: false);
		}

		public float Query(params int[] bin)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvCamShiftTracker");
			}
			return NativeMethods.legacy_CvCamShiftTracker_query(ptr, bin);
		}
	}
}
