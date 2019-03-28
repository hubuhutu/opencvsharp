using OpenCvSharp.Utilities;
using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvKNearest : CvStatModel
	{
		private bool disposed;

		public CvKNearest()
		{
			ptr = NativeMethods.ml_CvKNearest_new1();
		}

		public CvKNearest(CvMat trainData, CvMat responses, CvMat sampleIdx = null, bool isRegression = false, int maxK = 32)
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
			ptr = NativeMethods.ml_CvKNearest_new2_CvMat(trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(sampleIdx), isRegression ? 1 : 0, maxK);
		}

		public CvKNearest(Mat trainData, Mat responses, Mat sampleIdx = null, bool isRegression = false, int maxK = 32)
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
			ptr = NativeMethods.ml_CvKNearest_new2_Mat(trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(sampleIdx), isRegression ? 1 : 0, maxK);
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
							NativeMethods.ml_CvKNearest_delete(ptr);
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

		public virtual bool Train(CvMat trainData, CvMat responses, CvMat sampleIdx = null, bool isRegression = false, int maxK = 32, bool updateBase = false)
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
			return NativeMethods.ml_CvKNearest_train_CvMat(ptr, trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(sampleIdx), isRegression ? 1 : 0, maxK, updateBase ? 1 : 0) != 0;
		}

		public virtual bool Train(Mat trainData, Mat responses, Mat sampleIdx = null, bool isRegression = false, int maxK = 32, bool updateBase = false)
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
			return NativeMethods.ml_CvKNearest_train_Mat(ptr, trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(sampleIdx), isRegression ? 1 : 0, maxK, updateBase ? 1 : 0) != 0;
		}

		public virtual float FindNearest(CvMat samples, int k, CvMat results = null, float[][] neighbors = null, CvMat neighborResponses = null, CvMat dist = null)
		{
			if (samples == null)
			{
				throw new ArgumentNullException("samples");
			}
			if (neighbors == null)
			{
				return NativeMethods.ml_CvKNearest_find_nearest_CvMat(ptr, samples.CvPtr, k, Cv2.ToPtr(results), null, Cv2.ToPtr(neighborResponses), Cv2.ToPtr(dist));
			}
			using (ArrayAddress2<float> arrayAddress = new ArrayAddress2<float>(neighbors))
			{
				return NativeMethods.ml_CvKNearest_find_nearest_CvMat(ptr, samples.CvPtr, k, Cv2.ToPtr(results), arrayAddress.Pointer, Cv2.ToPtr(neighborResponses), Cv2.ToPtr(dist));
			}
		}

		public virtual float FindNearest(Mat samples, int k, Mat results, Mat neighborResponses, Mat dists)
		{
			if (samples == null)
			{
				throw new ArgumentNullException("samples");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (neighborResponses == null)
			{
				throw new ArgumentNullException("neighborResponses");
			}
			if (dists == null)
			{
				throw new ArgumentNullException("dists");
			}
			samples.ThrowIfDisposed();
			results.ThrowIfDisposed();
			neighborResponses.ThrowIfDisposed();
			dists.ThrowIfDisposed();
			return NativeMethods.ml_CvKNearest_find_nearest_Mat(ptr, samples.CvPtr, k, results.CvPtr, neighborResponses.CvPtr, dists.CvPtr);
		}

		public int GetMaxK()
		{
			return NativeMethods.ml_CvKNearest_get_max_k(ptr);
		}

		public int GetVarCount()
		{
			return NativeMethods.ml_CvKNearest_get_var_count(ptr);
		}

		public int GetSampleCount()
		{
			return NativeMethods.ml_CvKNearest_get_sample_count(ptr);
		}

		public bool IsRegression()
		{
			return NativeMethods.ml_CvKNearest_is_regression(ptr) != 0;
		}

		public override void Clear()
		{
			NativeMethods.ml_CvKNearest_clear(ptr);
		}
	}
}
