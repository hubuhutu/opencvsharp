using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvForestTree : CvDTree
	{
		private bool disposed;

		public CvForestTree()
			: base(IntPtr.Zero)
		{
			ptr = NativeMethods.ml_CvForestTree_new();
		}

		internal CvForestTree(IntPtr ptr)
			: base(ptr)
		{
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
							NativeMethods.ml_CvForestTree_delete(ptr);
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

		public virtual bool Train(CvDTreeTrainData trainData, CvMat subsampleIdx, CvRTrees forest)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (subsampleIdx == null)
			{
				throw new ArgumentNullException("subsampleIdx");
			}
			if (forest == null)
			{
				throw new ArgumentNullException("forest");
			}
			return NativeMethods.ml_CvForestTree_train(ptr, trainData.CvPtr, subsampleIdx.CvPtr, forest.CvPtr) != 0;
		}

		public virtual int GetVarCount()
		{
			return NativeMethods.ml_CvForestTree_get_var_count(ptr);
		}

		public virtual void Read(CvFileStorage fs, CvFileNode node, CvRTrees forest, CvDTreeTrainData data)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			if (forest == null)
			{
				throw new ArgumentNullException("forest");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			NativeMethods.ml_CvForestTree_read(ptr, fs.CvPtr, node.CvPtr, forest.CvPtr, data.CvPtr);
		}
	}
}
