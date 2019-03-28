using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvMLData : DisposableCvObject
	{
		private bool disposed;

		public CvMLData()
		{
			ptr = NativeMethods.ml_CvMLData_new();
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
							NativeMethods.ml_CvMLData_delete(ptr);
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

		public int ReadCsv(string filename)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			return NativeMethods.ml_CvMLData_read_csv(ptr, filename);
		}

		public CvMat GetValues()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			IntPtr intPtr = NativeMethods.ml_CvMLData_get_values(ptr);
			if (!(intPtr == IntPtr.Zero))
			{
				return new CvMat(intPtr, isEnabledDispose: false);
			}
			return null;
		}

		public CvMat GetResponses()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			IntPtr intPtr = NativeMethods.ml_CvMLData_get_responses(ptr);
			if (!(intPtr == IntPtr.Zero))
			{
				return new CvMat(intPtr, isEnabledDispose: false);
			}
			return null;
		}

		public CvMat GetMissing()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			IntPtr intPtr = NativeMethods.ml_CvMLData_get_missing(ptr);
			if (!(intPtr == IntPtr.Zero))
			{
				return new CvMat(intPtr, isEnabledDispose: false);
			}
			return null;
		}

		public int GetResponseIdx()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			return NativeMethods.ml_CvMLData_get_response_idx(ptr);
		}

		public void SetResponseIdx(int idx)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			NativeMethods.ml_CvMLData_set_response_idx(ptr, idx);
		}

		public CvMat GetTrainSampleIdx()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			IntPtr intPtr = NativeMethods.ml_CvMLData_get_train_sample_idx(ptr);
			if (!(intPtr == IntPtr.Zero))
			{
				return new CvMat(intPtr, isEnabledDispose: false);
			}
			return null;
		}

		public CvMat GetTestSampleIdx()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			IntPtr intPtr = NativeMethods.ml_CvMLData_get_test_sample_idx(ptr);
			if (!(intPtr == IntPtr.Zero))
			{
				return new CvMat(intPtr, isEnabledDispose: false);
			}
			return null;
		}

		public void MixTrainAndTestIdx()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			NativeMethods.ml_CvMLData_mix_train_and_test_idx(ptr);
		}

		public void SetTrainTestSplit(CvTrainTestSplit spl)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			if (spl == null)
			{
				throw new ArgumentNullException("spl");
			}
			NativeMethods.ml_CvMLData_set_train_test_split(ptr, spl.CvPtr);
		}

		public CvMat GetVarIdx()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			IntPtr intPtr = NativeMethods.ml_CvMLData_get_var_idx(ptr);
			if (!(intPtr == IntPtr.Zero))
			{
				return new CvMat(intPtr, isEnabledDispose: false);
			}
			return null;
		}

		public void ChangeVarIdx(int vi, bool state)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			NativeMethods.ml_CvMLData_change_var_idx(ptr, vi, state ? 1 : 0);
		}

		public CvMat GetVarTypes()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			IntPtr intPtr = NativeMethods.ml_CvMLData_get_var_types(ptr);
			if (!(intPtr == IntPtr.Zero))
			{
				return new CvMat(intPtr, isEnabledDispose: false);
			}
			return null;
		}

		public int GetVarType(int varIdx)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			return NativeMethods.ml_CvMLData_get_var_type(ptr, varIdx);
		}

		public void SetVarTypes(string str)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			NativeMethods.ml_CvMLData_set_var_types(ptr, str);
		}

		public void ChangeVarType(int varIdx, int type)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			NativeMethods.ml_CvMLData_change_var_type(ptr, varIdx, type);
		}

		public void SetDelimiter(byte ch)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			NativeMethods.ml_CvMLData_set_delimiter(ptr, ch);
		}

		public byte GetDelimiter()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			return NativeMethods.ml_CvMLData_get_delimiter(ptr);
		}

		public void SetMissCh(byte ch)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			NativeMethods.ml_CvMLData_set_miss_ch(ptr, ch);
		}

		public byte GetMissCh()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvMLData");
			}
			return NativeMethods.ml_CvMLData_get_miss_ch(ptr);
		}
	}
}
