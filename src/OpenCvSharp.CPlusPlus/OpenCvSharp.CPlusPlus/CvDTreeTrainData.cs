using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvDTreeTrainData : DisposableCvObject
	{
		private bool disposed;

		public int SampleCount
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return NativeMethods.ml_CvDTreeTrainData_sample_count(ptr);
			}
		}

		public int VarAll
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return NativeMethods.ml_CvDTreeTrainData_var_all(ptr);
			}
		}

		public int VarCount
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return NativeMethods.ml_CvDTreeTrainData_var_count(ptr);
			}
		}

		public int MaxCCount
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return NativeMethods.ml_CvDTreeTrainData_max_c_count(ptr);
			}
		}

		public int OrdVarCount
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return NativeMethods.ml_CvDTreeTrainData_ord_var_count(ptr);
			}
		}

		public int CatVarCount
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return NativeMethods.ml_CvDTreeTrainData_cat_var_count(ptr);
			}
		}

		public bool HaveLabels
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return NativeMethods.ml_CvDTreeTrainData_have_labels(ptr) != 0;
			}
		}

		public bool HavePriors
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return NativeMethods.ml_CvDTreeTrainData_have_priors(ptr) != 0;
			}
		}

		public bool IsClassifier
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return NativeMethods.ml_CvDTreeTrainData_is_classifier(ptr) != 0;
			}
		}

		public int BufCount
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return NativeMethods.ml_CvDTreeTrainData_buf_count(ptr);
			}
		}

		public int BufSize
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return NativeMethods.ml_CvDTreeTrainData_buf_size(ptr);
			}
		}

		public bool Shared
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return NativeMethods.ml_CvDTreeTrainData_shared(ptr) != 0;
			}
		}

		public CvRNG Rng
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				return new CvRNG(NativeMethods.ml_CvDTreeTrainData_rng(ptr));
			}
		}

		public CvMat CatCount
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				IntPtr intPtr = NativeMethods.ml_CvDTreeTrainData_cat_count(ptr);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvMat(intPtr, isEnabledDispose: false);
			}
		}

		public CvMat CatOfs
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				IntPtr intPtr = NativeMethods.ml_CvDTreeTrainData_cat_ofs(ptr);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvMat(intPtr, isEnabledDispose: false);
			}
		}

		public CvMat CatMap
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				IntPtr intPtr = NativeMethods.ml_CvDTreeTrainData_cat_map(ptr);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvMat(intPtr, isEnabledDispose: false);
			}
		}

		public CvMat Counts
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				IntPtr intPtr = NativeMethods.ml_CvDTreeTrainData_counts(ptr);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvMat(intPtr, isEnabledDispose: false);
			}
		}

		public CvMat Buf
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				IntPtr intPtr = NativeMethods.ml_CvDTreeTrainData_buf(ptr);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvMat(intPtr, isEnabledDispose: false);
			}
		}

		public CvMat Direction
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				IntPtr intPtr = NativeMethods.ml_CvDTreeTrainData_direction(ptr);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvMat(intPtr, isEnabledDispose: false);
			}
		}

		public CvMat SplitBuf
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				IntPtr intPtr = NativeMethods.ml_CvDTreeTrainData_split_buf(ptr);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvMat(intPtr, isEnabledDispose: false);
			}
		}

		public CvMat VarIdx
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				IntPtr intPtr = NativeMethods.ml_CvDTreeTrainData_var_idx(ptr);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvMat(intPtr, isEnabledDispose: false);
			}
		}

		public CvMat VarType
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				IntPtr intPtr = NativeMethods.ml_CvDTreeTrainData_var_type(ptr);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvMat(intPtr, isEnabledDispose: false);
			}
		}

		public CvMat Priors
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("CvDTreeTrainData");
				}
				IntPtr intPtr = NativeMethods.ml_CvDTreeTrainData_priors(ptr);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvMat(intPtr, isEnabledDispose: false);
			}
		}

		public CvDTreeTrainData()
		{
			ptr = NativeMethods.ml_CvDTreeTrainData_new1();
		}

		public CvDTreeTrainData(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		public CvDTreeTrainData(CvMat trainData, DTreeDataLayout tflag, CvMat responses, CvMat varIdx = null, CvMat sampleIdx = null, CvMat varType = null, CvMat missingMask = null, CvDTreeParams param = null, bool shared = false, bool addLabels = false)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (responses == null)
			{
				throw new ArgumentNullException("responses");
			}
			trainData.ThrowIfDisposed();
			responses.ThrowIfDisposed();
			if (param == null)
			{
				param = new CvDTreeParams();
			}
			ptr = NativeMethods.ml_CvDTreeTrainData_new2(trainData.CvPtr, (int)tflag, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), Cv2.ToPtr(varType), Cv2.ToPtr(missingMask), param.CvPtr, shared ? 1 : 0, addLabels ? 1 : 0);
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
							NativeMethods.ml_CvDTreeTrainData_delete(ptr);
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

		public void SetData(CvMat trainData, DTreeDataLayout tflag, CvMat responses, CvMat varIdx = null, CvMat sampleIdx = null, CvMat varType = null, CvMat missingMask = null, CvDTreeParams param = null, bool shared = false, bool addLabels = false, bool updateData = false)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (responses == null)
			{
				throw new ArgumentNullException("responses");
			}
			if (param == null)
			{
				param = new CvDTreeParams();
			}
			NativeMethods.ml_CvDTreeTrainData_set_data(ptr, trainData.CvPtr, (int)tflag, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), Cv2.ToPtr(varType), Cv2.ToPtr(missingMask), param.CvPtr, shared ? 1 : 0, addLabels ? 1 : 0, updateData ? 1 : 0);
		}

		public int GetNumClasses()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvDTreeTrainData");
			}
			return NativeMethods.ml_CvDTreeTrainData_get_num_classes(ptr);
		}

		public int GetVarType(int vi)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvDTreeTrainData");
			}
			return NativeMethods.ml_CvDTreeTrainData_get_var_type(ptr, vi);
		}

		public int GetWorkVarCount()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvDTreeTrainData");
			}
			return NativeMethods.ml_CvDTreeTrainData_get_work_var_count(ptr);
		}

		public virtual PointerAccessor1D_Int32 GetClassLabels(CvDTreeNode n, int[] labelsBuf)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvDTreeTrainData");
			}
			if (n == null)
			{
				throw new ArgumentNullException("n");
			}
			return new PointerAccessor1D_Int32(NativeMethods.ml_CvDTreeTrainData_get_class_labels(ptr, n.CvPtr, labelsBuf));
		}

		public virtual PointerAccessor1D_Single GetOrdResponses(CvDTreeNode n, float[] valuesBuf, int[] sampleIndicesBuf)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvDTreeTrainData");
			}
			if (n == null)
			{
				throw new ArgumentNullException("n");
			}
			return new PointerAccessor1D_Single(NativeMethods.ml_CvDTreeTrainData_get_ord_responses(ptr, n.CvPtr, valuesBuf, sampleIndicesBuf));
		}

		public virtual PointerAccessor1D_Int32 GetLabels(CvDTreeNode n, int[] labelsBuf)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvDTreeTrainData");
			}
			if (n == null)
			{
				throw new ArgumentNullException("n");
			}
			return new PointerAccessor1D_Int32(NativeMethods.ml_CvDTreeTrainData_get_cv_labels(ptr, n.CvPtr, labelsBuf));
		}

		public virtual PointerAccessor1D_Int32 GetCatVarData(CvDTreeNode n, int vi, int[] catValuesBuf)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvDTreeTrainData");
			}
			if (n == null)
			{
				throw new ArgumentNullException("n");
			}
			return new PointerAccessor1D_Int32(NativeMethods.ml_CvDTreeTrainData_get_cat_var_data(ptr, n.CvPtr, vi, catValuesBuf));
		}

		public virtual void GetOrdVarData(CvDTreeNode n, int vi, float[] ordValuesBuf, int[] sortedIndicesBuf, float[][] ordValues, int[][] sortedIndices, int[] sampleIndicesBuf)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvDTreeTrainData");
			}
			if (n == null)
			{
				throw new ArgumentNullException("n");
			}
			NativeMethods.ml_CvDTreeTrainData_get_ord_var_data(ptr, n.CvPtr, vi, ordValuesBuf, sortedIndicesBuf, ordValues, sortedIndices, sampleIndicesBuf);
		}

		public virtual int GetChildBufIdx(CvDTreeNode n)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvDTreeTrainData");
			}
			if (n == null)
			{
				throw new ArgumentNullException("n");
			}
			return NativeMethods.ml_CvDTreeTrainData_get_child_buf_idx(ptr, n.CvPtr);
		}
	}
}
