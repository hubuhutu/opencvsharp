using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvNormalBayesClassifier : CvStatModel
	{
		private bool disposed;

		public CvNormalBayesClassifier()
		{
			ptr = NativeMethods.ml_CvNormalBayesClassifier_new1();
		}

		public CvNormalBayesClassifier(CvMat trainData, CvMat responses, CvMat varIdx = null, CvMat sampleIdx = null)
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
			ptr = NativeMethods.ml_CvNormalBayesClassifier_new2_CvMat(trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx));
		}

		public CvNormalBayesClassifier(Mat trainData, Mat responses, Mat varIdx = null, Mat sampleIdx = null)
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
			ptr = NativeMethods.ml_CvNormalBayesClassifier_new2_Mat(trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.ml_CvNormalBayesClassifier_destruct(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public virtual bool Train(CvMat trainData, CvMat responses, CvMat varIdx, CvMat sampleIdx, bool update = false)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (responses == null)
			{
				throw new ArgumentNullException("responses");
			}
			return NativeMethods.ml_CvNormalBayesClassifier_train_CvMat(ptr, trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), update ? 1 : 0) != 0;
		}

		public virtual bool Train(Mat trainData, Mat responses, Mat varIdx, Mat sampleIdx, bool update = false)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (responses == null)
			{
				throw new ArgumentNullException("responses");
			}
			return NativeMethods.ml_CvNormalBayesClassifier_train_Mat(ptr, trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), update ? 1 : 0) != 0;
		}

		public virtual float Predict(CvMat sample, CvMat results = null)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			sample.ThrowIfDisposed();
			return NativeMethods.ml_CvNormalBayesClassifier_predict_CvMat(ptr, sample.CvPtr, Cv2.ToPtr(results));
		}

		public virtual float Predict(Mat sample, Mat results = null)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			sample.ThrowIfDisposed();
			return NativeMethods.ml_CvNormalBayesClassifier_predict_Mat(ptr, sample.CvPtr, Cv2.ToPtr(results));
		}

		public override void Clear()
		{
			NativeMethods.ml_CvNormalBayesClassifier_clear(ptr);
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
			NativeMethods.ml_CvNormalBayesClassifier_write(ptr, storage.CvPtr, name);
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
			NativeMethods.ml_CvNormalBayesClassifier_read(ptr, storage.CvPtr, node.CvPtr);
		}
	}
}
