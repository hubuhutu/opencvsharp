using System;

namespace OpenCvSharp.CPlusPlus
{
	public class KalmanFilter : DisposableCvObject
	{
		private bool disposed;

		public Mat StatePre
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("KalmanFilter");
				}
				return new Mat(NativeMethods.video_KalmanFilter_statePre(ptr));
			}
		}

		public Mat StatePost
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("KalmanFilter");
				}
				return new Mat(NativeMethods.video_KalmanFilter_statePost(ptr));
			}
		}

		public Mat TransitionMatrix
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("KalmanFilter");
				}
				return new Mat(NativeMethods.video_KalmanFilter_transitionMatrix(ptr));
			}
		}

		public Mat ControlMatrix
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("KalmanFilter");
				}
				return new Mat(NativeMethods.video_KalmanFilter_controlMatrix(ptr));
			}
		}

		public Mat MeasurementMatrix
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("KalmanFilter");
				}
				return new Mat(NativeMethods.video_KalmanFilter_measurementMatrix(ptr));
			}
		}

		public Mat ProcessNoiseCov
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("KalmanFilter");
				}
				return new Mat(NativeMethods.video_KalmanFilter_processNoiseCov(ptr));
			}
		}

		public Mat MeasurementNoiseCov
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("KalmanFilter");
				}
				return new Mat(NativeMethods.video_KalmanFilter_measurementNoiseCov(ptr));
			}
		}

		public Mat ErrorCovPre
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("KalmanFilter");
				}
				return new Mat(NativeMethods.video_KalmanFilter_errorCovPre(ptr));
			}
		}

		public Mat Gain
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("KalmanFilter");
				}
				return new Mat(NativeMethods.video_KalmanFilter_gain(ptr));
			}
		}

		public Mat ErrorCovPost
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("KalmanFilter");
				}
				return new Mat(NativeMethods.video_KalmanFilter_errorCovPost(ptr));
			}
		}

		public KalmanFilter()
		{
			ptr = NativeMethods.video_KalmanFilter_new1();
		}

		public KalmanFilter(int dynamParams, int measureParams, int controlParams = 0, int type = 5)
		{
			ptr = NativeMethods.video_KalmanFilter_new2(dynamParams, measureParams, controlParams, type);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (ptr != IntPtr.Zero)
					{
						NativeMethods.video_KalmanFilter_delete(ptr);
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

		public void Init(int dynamParams, int measureParams, int controlParams = 0, int type = 5)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("KalmanFilter");
			}
			NativeMethods.video_KalmanFilter_init(ptr, dynamParams, measureParams, controlParams, type);
		}

		public Mat Predict(Mat control = null)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("KalmanFilter");
			}
			return new Mat(NativeMethods.video_KalmanFilter_predict(ptr, Cv2.ToPtr(control)));
		}

		public Mat Correct(Mat measurement)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("KalmanFilter");
			}
			if (measurement == null)
			{
				throw new ArgumentNullException("measurement");
			}
			measurement.ThrowIfDisposed();
			return new Mat(NativeMethods.video_KalmanFilter_correct(ptr, measurement.CvPtr));
		}
	}
}
