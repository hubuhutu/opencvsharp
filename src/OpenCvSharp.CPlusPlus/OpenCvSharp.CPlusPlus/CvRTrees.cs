using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	public class CvRTrees : CvStatModel
	{
		private bool disposed;

		public CvRTrees()
		{
			ptr = NativeMethods.ml_CvRTrees_new();
		}

		internal CvRTrees(IntPtr ptr)
		{
			base.ptr = ptr;
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
							NativeMethods.ml_CvRTrees_delete(ptr);
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

		public virtual bool Train(CvMat trainData, DTreeDataLayout tflag, CvMat responses, CvMat varIdx = null, CvMat sampleIdx = null, CvMat varType = null, CvMat missingMask = null, CvRTParams param = null)
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
				param = new CvRTParams();
			}
			return NativeMethods.ml_CvRTrees_train_CvMat(ptr, trainData.CvPtr, (int)tflag, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), Cv2.ToPtr(varType), Cv2.ToPtr(missingMask), param.CvPtr) != 0;
		}

		public virtual bool Train(Mat trainData, DTreeDataLayout tflag, Mat responses, Mat varIdx = null, Mat sampleIdx = null, Mat varType = null, Mat missingMask = null, CvRTParams param = null)
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
				param = new CvRTParams();
			}
			return NativeMethods.ml_CvRTrees_train_Mat(ptr, trainData.CvPtr, (int)tflag, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), Cv2.ToPtr(varType), Cv2.ToPtr(missingMask), param.CvPtr) != 0;
		}

		public virtual double Predict(CvMat sample, CvMat missing = null)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			sample.ThrowIfDisposed();
			return NativeMethods.ml_CvRTrees_predict_CvMat(ptr, sample.CvPtr, Cv2.ToPtr(missing));
		}

		public virtual double Predict(Mat sample, Mat missing = null)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			sample.ThrowIfDisposed();
			return NativeMethods.ml_CvRTrees_predict_CvMat(ptr, sample.CvPtr, Cv2.ToPtr(missing));
		}

		public virtual double PredictProb(CvMat sample, CvMat missing = null)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			sample.ThrowIfDisposed();
			return NativeMethods.ml_CvRTrees_predict_prob_CvMat(ptr, sample.CvPtr, Cv2.ToPtr(missing));
		}

		public virtual double PredictProb(Mat sample, Mat missing = null)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			sample.ThrowIfDisposed();
			return NativeMethods.ml_CvRTrees_predict_prob_CvMat(ptr, sample.CvPtr, Cv2.ToPtr(missing));
		}

		public virtual Mat GetVarImportance()
		{
			IntPtr intPtr = NativeMethods.ml_CvRTrees_getVarImportance(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new Mat(intPtr);
		}

		public virtual float GetProximity(CvMat sample1, CvMat sample2, CvMat missing1 = null, CvMat missing2 = null)
		{
			if (sample1 == null)
			{
				throw new ArgumentNullException("sample1");
			}
			if (sample2 == null)
			{
				throw new ArgumentNullException("sample2");
			}
			return NativeMethods.ml_CvRTrees_get_proximity(ptr, sample1.CvPtr, sample2.CvPtr, Cv2.ToPtr(missing1), Cv2.ToPtr(missing2));
		}

		public CvMat GetActiveVarMask()
		{
			IntPtr intPtr = NativeMethods.ml_CvRTrees_get_active_var_mask(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvMat(intPtr, isEnabledDispose: false);
		}

		public CvRNG GetRng()
		{
			IntPtr intPtr = NativeMethods.ml_CvRTrees_get_rng(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvRNG(Marshal.ReadInt64(intPtr));
		}

		public int GetTreeCount()
		{
			return NativeMethods.ml_CvRTrees_get_tree_count(ptr);
		}

		public CvForestTree GetTree(int i)
		{
			IntPtr intPtr = NativeMethods.ml_CvRTrees_get_tree(ptr, i);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvForestTree(intPtr);
		}

		public override void Clear()
		{
			NativeMethods.ml_CvRTrees_clear(ptr);
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
			NativeMethods.ml_CvRTrees_write(ptr, storage.CvPtr, name);
		}

		public override void Read(CvFileStorage fs, CvFileNode node)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			NativeMethods.ml_CvRTrees_read(ptr, fs.CvPtr, node.CvPtr);
		}
	}
}
