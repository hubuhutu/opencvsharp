using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvDTree : CvStatModel
	{
		private bool disposed;

		public CvDTree()
		{
			ptr = NativeMethods.ml_CvDTree_new();
		}

		internal CvDTree(IntPtr ptr)
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
						NativeMethods.ml_CvDTree_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public virtual bool Train(CvMat trainData, DTreeDataLayout tflag, CvMat responses, CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask, CvDTreeParams param)
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
			return NativeMethods.ml_CvDTree_train1(ptr, trainData.CvPtr, (int)tflag, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), Cv2.ToPtr(varType), Cv2.ToPtr(missingMask), param.CvPtr) != 0;
		}

		public virtual bool Train(Mat trainData, DTreeDataLayout tflag, Mat responses, Mat varIdx, Mat sampleIdx, Mat varType, Mat missingMask, CvDTreeParams param)
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
			return NativeMethods.ml_CvDTree_train_Mat(ptr, trainData.CvPtr, (int)tflag, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), Cv2.ToPtr(varType), Cv2.ToPtr(missingMask), param.CvPtr) != 0;
		}

		public virtual bool Train(CvDTreeTrainData trainData, CvMat subsampleIdx)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (subsampleIdx == null)
			{
				throw new ArgumentNullException("subsampleIdx");
			}
			return NativeMethods.ml_CvDTree_train2(ptr, trainData.CvPtr, subsampleIdx.CvPtr) != 0;
		}

		public virtual bool Train(CvMLData trainData, CvDTreeParams param)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (param == null)
			{
				param = new CvDTreeParams();
			}
			return NativeMethods.ml_CvDTree_train3(ptr, trainData.CvPtr, param.CvPtr) != 0;
		}

		public virtual CvDTreeNode Predict(CvMat sample, CvMat missingDataMask = null, bool preprocessedInput = false)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			sample.ThrowIfDisposed();
			IntPtr intPtr = NativeMethods.ml_CvDTree_predict_CvMat(ptr, sample.CvPtr, Cv2.ToPtr(missingDataMask), preprocessedInput ? 1 : 0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvDTreeNode(intPtr);
		}

		public virtual CvDTreeNode Predict(Mat sample, Mat missingDataMask = null, bool preprocessedInput = false)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			sample.ThrowIfDisposed();
			IntPtr intPtr = NativeMethods.ml_CvDTree_predict_Mat(ptr, sample.CvPtr, Cv2.ToPtr(missingDataMask), preprocessedInput ? 1 : 0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvDTreeNode(intPtr);
		}

		public virtual Mat GetVarImportance()
		{
			IntPtr intPtr = NativeMethods.ml_CvDTree_getVarImportance(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new Mat(intPtr);
		}

		public CvDTreeNode GetRoot()
		{
			IntPtr intPtr = NativeMethods.ml_CvDTree_get_root(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvDTreeNode(intPtr);
		}

		public int GetPrunedTreeIdx()
		{
			return NativeMethods.ml_CvDTree_get_pruned_tree_idx(ptr);
		}

		public CvDTreeTrainData GetData()
		{
			IntPtr intPtr = NativeMethods.ml_CvDTree_get_data(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvDTreeTrainData(intPtr);
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
			NativeMethods.ml_CvDTree_read(ptr, fs.CvPtr, node.CvPtr);
		}

		public virtual void Read(CvFileStorage fs, CvFileNode node, CvDTreeTrainData data)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			NativeMethods.ml_CvDTree_read(ptr, fs.CvPtr, node.CvPtr, data.CvPtr);
		}

		public virtual void Write(CvFileStorage fs)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			NativeMethods.ml_CvDTree_write(ptr, fs.CvPtr);
		}

		public override void Write(CvFileStorage fs, string name)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			NativeMethods.ml_CvDTree_write(ptr, fs.CvPtr, name);
		}

		public override void Clear()
		{
			NativeMethods.ml_CvDTree_clear(ptr);
		}
	}
}
