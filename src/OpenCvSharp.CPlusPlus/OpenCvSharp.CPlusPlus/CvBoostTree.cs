using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvBoostTree : CvDTree
	{
		private bool disposed;

		public CvBoostTree()
			: base(IntPtr.Zero)
		{
			ptr = NativeMethods.ml_CvBoostTree_new();
		}

		internal CvBoostTree(IntPtr ptr)
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
						NativeMethods.ml_CvBoostTree_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public virtual bool Train(CvDTreeTrainData trainData, CvMat subsampleIdx, CvBoost ensemble)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (subsampleIdx == null)
			{
				throw new ArgumentNullException("subsampleIdx");
			}
			return NativeMethods.ml_CvBoostTree_train(ptr, trainData.CvPtr, subsampleIdx.CvPtr, Cv2.ToPtr(ensemble)) != 0;
		}

		public virtual void Scale(double s)
		{
			NativeMethods.ml_CvBoostTree_scale(ptr, s);
		}

		public virtual void Read(CvFileStorage fs, CvFileNode node, CvBoost ensemble, CvDTreeTrainData data)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			if (ensemble == null)
			{
				throw new ArgumentNullException("ensemble");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			NativeMethods.ml_CvBoostTree_read(ptr, fs.CvPtr, node.CvPtr, ensemble.CvPtr, data.CvPtr);
		}

		public override void Clear()
		{
			NativeMethods.ml_CvBoostTree_clear(ptr);
		}
	}
}
