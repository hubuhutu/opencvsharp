using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvERTrees : CvRTrees
	{
		private bool disposed;

		public CvERTrees()
			: this(IntPtr.Zero)
		{
			ptr = NativeMethods.ml_CvERTrees_new();
		}

		internal CvERTrees(IntPtr ptr)
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
						NativeMethods.ml_CvERTrees_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public virtual bool Train(CvMat trainData, int tflag, CvMat responses, CvMat varIdx = null, CvMat sampleIdx = null, CvMat varType = null, CvMat missingMask = null, CvRTParams param = null)
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
				param = new CvRTParams();
			}
			return NativeMethods.ml_CvERTrees_train1(ptr, trainData.CvPtr, tflag, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), Cv2.ToPtr(varType), Cv2.ToPtr(missingMask), param.CvPtr) != 0;
		}

		public bool Train(CvMLData data)
		{
			return Train(data, new CvRTParams());
		}

		public bool Train(CvMLData data, CvRTParams param)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (param == null)
			{
				param = new CvRTParams();
			}
			return NativeMethods.ml_CvERTrees_train2(ptr, data.CvPtr, param.CvPtr) != 0;
		}

		protected bool GrowForest(CvTermCriteria termCrit)
		{
			return NativeMethods.ml_CvERTrees_grow_forest(ptr, termCrit) != 0;
		}
	}
}
