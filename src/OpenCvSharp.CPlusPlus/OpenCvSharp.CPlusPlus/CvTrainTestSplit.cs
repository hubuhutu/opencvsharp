using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvTrainTestSplit : DisposableCvObject
	{
		private bool disposed;

		public int TrainSamplePartCount
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvTrainTestSplit");
				}
				return NativeMethods.ml_CvTrainTestSplit_train_sample_part_count_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvTrainTestSplit");
				}
				NativeMethods.ml_CvTrainTestSplit_train_sample_part_count_set(ptr, value);
			}
		}

		public float TrainSamplePartPortion
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvTrainTestSplit");
				}
				return NativeMethods.ml_CvTrainTestSplit_train_sample_part_portion_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvTrainTestSplit");
				}
				NativeMethods.ml_CvTrainTestSplit_train_sample_part_portion_set(ptr, value);
			}
		}

		public TrainSamplePartMode TrainSamplePartMode
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvTrainTestSplit");
				}
				return (TrainSamplePartMode)NativeMethods.ml_CvTrainTestSplit_train_sample_part_mode_get(ptr);
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvTrainTestSplit");
				}
				NativeMethods.ml_CvTrainTestSplit_train_sample_part_mode_set(ptr, (int)value);
			}
		}

		public bool Mix
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvTrainTestSplit");
				}
				return NativeMethods.ml_CvTrainTestSplit_mix_get(ptr) != 0;
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvTrainTestSplit");
				}
				NativeMethods.ml_CvTrainTestSplit_mix_set(ptr, value ? 1 : 0);
			}
		}

		public CvTrainTestSplit()
		{
			ptr = NativeMethods.ml_CvTrainTestSplit_new1();
		}

		public CvTrainTestSplit(int trainSampleCount, bool mix = true)
		{
			ptr = NativeMethods.ml_CvTrainTestSplit_new2(trainSampleCount, mix ? 1 : 0);
		}

		public CvTrainTestSplit(float trainSamplePortion, bool mix = true)
		{
			ptr = NativeMethods.ml_CvTrainTestSplit_new3(trainSamplePortion, mix ? 1 : 0);
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
							NativeMethods.ml_CvTrainTestSplit_delete(ptr);
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
	}
}
