using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvBoost : CvStatModel
	{
		private bool disposed;

		public const BoostType DISCRETE = BoostType.Discrete;

		public const BoostType REAL = BoostType.Real;

		public const BoostType LOGIT = BoostType.Logit;

		public const BoostType GENTLE = BoostType.Gentle;

		public const BoostSplitCriteria DEFAULT = BoostSplitCriteria.Default;

		public const BoostSplitCriteria GINI = BoostSplitCriteria.Gini;

		public const BoostSplitCriteria MISCLASS = BoostSplitCriteria.Misclass;

		public const BoostSplitCriteria SQERR = BoostSplitCriteria.Sqerr;

		public CvBoost()
		{
			ptr = NativeMethods.ml_Boost_new();
		}

		public CvBoost(CvMat trainData, DTreeDataLayout tflag, CvMat responses, CvMat varIdx = null, CvMat sampleIdx = null, CvMat varType = null, CvMat missingMask = null, CvBoostParams param = null)
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
				param = new CvBoostParams();
			}
			ptr = NativeMethods.ml_Boost_new_CvMat(trainData.CvPtr, (int)tflag, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), Cv2.ToPtr(varType), Cv2.ToPtr(missingMask), param.CvPtr);
		}

		public CvBoost(Mat trainData, DTreeDataLayout tflag, Mat responses, Mat varIdx = null, Mat sampleIdx = null, Mat varType = null, Mat missingMask = null, CvBoostParams param = null)
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
				param = new CvBoostParams();
			}
			ptr = NativeMethods.ml_Boost_new_Mat(trainData.CvPtr, (int)tflag, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), Cv2.ToPtr(varType), Cv2.ToPtr(missingMask), param.CvPtr);
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
							NativeMethods.ml_Boost_delete(ptr);
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

		public virtual bool Train(CvMat trainData, DTreeDataLayout tflag, CvMat responses, CvMat varIdx = null, CvMat sampleIdx = null, CvMat varType = null, CvMat missingMask = null, CvBoostParams param = null, bool update = false)
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
				param = new CvBoostParams();
			}
			return NativeMethods.ml_Boost_train_CvMat(ptr, trainData.CvPtr, (int)tflag, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), Cv2.ToPtr(varType), Cv2.ToPtr(missingMask), param.CvPtr, update ? 1 : 0) != 0;
		}

		public virtual bool Train(Mat trainData, DTreeDataLayout tflag, Mat responses, Mat varIdx = null, Mat sampleIdx = null, Mat varType = null, Mat missingMask = null, CvBoostParams param = null, bool update = false)
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
				param = new CvBoostParams();
			}
			return NativeMethods.ml_Boost_train_Mat(ptr, trainData.CvPtr, (int)tflag, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), Cv2.ToPtr(varType), Cv2.ToPtr(missingMask), param.CvPtr, update ? 1 : 0) != 0;
		}

		public float Predict(CvMat sample, CvMat missing = null, CvMat weakResponses = null, CvSlice? slice = default(CvSlice?), bool rawMode = false, bool returnSum = false)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			CvSlice valueOrDefault = slice.GetValueOrDefault(CvSlice.WholeSeq);
			return NativeMethods.ml_Boost_predict_CvMat(ptr, sample.CvPtr, Cv2.ToPtr(missing), Cv2.ToPtr(weakResponses), valueOrDefault, rawMode ? 1 : 0, returnSum ? 1 : 0);
		}

		public float Predict(Mat sample, Mat missing = null, Range? slice = default(Range?), bool rawMode = false, bool returnSum = false)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			CvSlice slice2 = slice.GetValueOrDefault(CvSlice.WholeSeq);
			return NativeMethods.ml_Boost_predict_Mat(ptr, sample.CvPtr, Cv2.ToPtr(missing), slice2, rawMode ? 1 : 0, returnSum ? 1 : 0);
		}

		public virtual void Prune(Range slice)
		{
			NativeMethods.ml_Boost_prune(ptr, slice);
		}

		public CvMat GetWeights()
		{
			IntPtr intPtr = NativeMethods.ml_Boost_get_weights(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvMat(intPtr, isEnabledDispose: false);
		}

		public CvMat GetSubtreeWeights()
		{
			IntPtr intPtr = NativeMethods.ml_Boost_get_subtree_weights(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvMat(intPtr, isEnabledDispose: false);
		}

		public CvMat GetWeakResponse()
		{
			IntPtr intPtr = NativeMethods.ml_Boost_get_weak_response(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvMat(intPtr, isEnabledDispose: false);
		}

		public CvBoostParams GetParams()
		{
			IntPtr intPtr = NativeMethods.ml_Boost_get_params(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvBoostParams(intPtr, isEnabledDispose: false);
		}

		public CvSeq GetWeakPredictors()
		{
			IntPtr intPtr = NativeMethods.ml_Boost_get_weak_predictors(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvSeq(intPtr);
		}

		public override void Clear()
		{
			NativeMethods.ml_Boost_clear(ptr);
		}

		public override void Write(CvFileStorage storage, string name)
		{
			if (storage == null)
			{
				throw new ArgumentNullException("storage");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			NativeMethods.ml_Boost_write(ptr, storage.CvPtr, name);
		}

		public override void Read(CvFileStorage storage, CvFileNode node)
		{
			if (storage == null)
			{
				throw new ArgumentNullException("storage");
			}
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			NativeMethods.ml_Boost_read(ptr, storage.CvPtr, node.CvPtr);
		}
	}
}
