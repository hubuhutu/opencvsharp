using System;

namespace OpenCvSharp.CPlusPlus
{
	public abstract class CvStatModel : DisposableCvObject
	{
		private bool disposed;

		public const int CV_VAR_NUMERICAL = 0;

		public const int CV_VAR_ORDERED = 0;

		public const int CV_VAR_CATEGORICAL = 1;

		public const string CV_TYPE_NAME_ML_SVM = "opencv-ml-svm";

		public const string CV_TYPE_NAME_ML_KNN = "opencv-ml-knn";

		public const string CV_TYPE_NAME_ML_NBAYES = "opencv-ml-bayesian";

		public const string CV_TYPE_NAME_ML_EM = "opencv-ml-em";

		public const string CV_TYPE_NAME_ML_BOOSTING = "opencv-ml-boost-tree";

		public const string CV_TYPE_NAME_ML_TREE = "opencv-ml-tree";

		public const string CV_TYPE_NAME_ML_ANN_MLP = "opencv-ml-ann-mlp";

		public const string CV_TYPE_NAME_ML_CNN = "opencv-ml-cnn";

		public const string CV_TYPE_NAME_ML_RTREES = "opencv-ml-random-trees";

		protected CvStatModel()
		{
			disposed = false;
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				disposed = true;
				base.Dispose(disposing);
			}
		}

		public virtual void Clear()
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			NativeMethods.ml_CvStatModel_clear(ptr);
		}

		public virtual void Save(string filename)
		{
			Save(filename, null);
		}

		public virtual void Save(string filename, string name)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (string.IsNullOrEmpty(filename))
			{
				throw new ArgumentNullException("filename");
			}
			NativeMethods.ml_CvStatModel_save(ptr, filename, name);
		}

		public virtual void Load(string filename)
		{
			Load(filename, null);
		}

		public virtual void Load(string filename, string name)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (string.IsNullOrEmpty(filename))
			{
				throw new ArgumentNullException("filename");
			}
			NativeMethods.ml_CvStatModel_load(ptr, filename, name);
		}

		public virtual void Write(CvFileStorage storage, string name)
		{
			throw new NotImplementedException();
		}

		public virtual void Read(CvFileStorage storage, CvFileNode node)
		{
			throw new NotImplementedException();
		}
	}
}
