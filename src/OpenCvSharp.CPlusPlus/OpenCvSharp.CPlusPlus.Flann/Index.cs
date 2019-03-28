using System;

namespace OpenCvSharp.CPlusPlus.Flann
{
	public class Index : DisposableCvObject
	{
		private bool disposed;

		public Index(InputArray features, IndexParams @params, FlannDistance distType = FlannDistance.Euclidean)
		{
			if (features == null)
			{
				throw new ArgumentNullException("features");
			}
			if (@params == null)
			{
				throw new ArgumentNullException("params");
			}
			ptr = NativeMethods.flann_Index_new(features.CvPtr, @params.CvPtr, (int)distType);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create Index");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.flann_Index_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public void KnnSearch(float[] queries, out int[] indices, out float[] dists, int knn, SearchParams @params)
		{
			if (queries == null)
			{
				throw new ArgumentNullException("queries");
			}
			if (@params == null)
			{
				throw new ArgumentNullException("params");
			}
			if (queries.Length == 0)
			{
				throw new ArgumentException();
			}
			if (knn < 1)
			{
				throw new ArgumentOutOfRangeException("knn");
			}
			indices = new int[knn];
			dists = new float[knn];
			NativeMethods.flann_Index_knnSearch1(ptr, queries, queries.Length, indices, dists, knn, @params.CvPtr);
		}

		public void KnnSearch(Mat queries, Mat indices, Mat dists, int knn, SearchParams @params)
		{
			if (queries == null)
			{
				throw new ArgumentNullException("queries");
			}
			if (indices == null)
			{
				throw new ArgumentNullException("indices");
			}
			if (dists == null)
			{
				throw new ArgumentNullException("dists");
			}
			if (@params == null)
			{
				throw new ArgumentNullException("params");
			}
			NativeMethods.flann_Index_knnSearch2(ptr, queries.CvPtr, indices.CvPtr, dists.CvPtr, knn, @params.CvPtr);
		}

		public void KnnSearch(Mat queries, out int[] indices, out float[] dists, int knn, SearchParams @params)
		{
			if (queries == null)
			{
				throw new ArgumentNullException("queries");
			}
			if (@params == null)
			{
				throw new ArgumentNullException("params");
			}
			if (knn < 1)
			{
				throw new ArgumentOutOfRangeException("knn");
			}
			indices = new int[knn];
			dists = new float[knn];
			NativeMethods.flann_Index_knnSearch3(ptr, queries.CvPtr, indices, dists, knn, @params.CvPtr);
		}

		public void RadiusSearch(float[] queries, int[] indices, float[] dists, float radius, int maxResults, SearchParams @params)
		{
			if (queries == null)
			{
				throw new ArgumentNullException("queries");
			}
			if (indices == null)
			{
				throw new ArgumentNullException("indices");
			}
			if (dists == null)
			{
				throw new ArgumentNullException("dists");
			}
			if (@params == null)
			{
				throw new ArgumentNullException("params");
			}
			NativeMethods.flann_Index_radiusSearch1(ptr, queries, queries.Length, indices, indices.Length, dists, dists.Length, radius, maxResults, @params.CvPtr);
		}

		public void RadiusSearch(Mat queries, Mat indices, Mat dists, float radius, int maxResults, SearchParams @params)
		{
			if (queries == null)
			{
				throw new ArgumentNullException("queries");
			}
			if (indices == null)
			{
				throw new ArgumentNullException("indices");
			}
			if (dists == null)
			{
				throw new ArgumentNullException("dists");
			}
			if (@params == null)
			{
				throw new ArgumentNullException("params");
			}
			NativeMethods.flann_Index_radiusSearch2(ptr, queries.CvPtr, indices.CvPtr, dists.CvPtr, radius, maxResults, @params.CvPtr);
		}

		public void RadiusSearch(Mat queries, int[] indices, float[] dists, float radius, int maxResults, SearchParams @params)
		{
			if (queries == null)
			{
				throw new ArgumentNullException("queries");
			}
			if (indices == null)
			{
				throw new ArgumentNullException("indices");
			}
			if (dists == null)
			{
				throw new ArgumentNullException("dists");
			}
			if (@params == null)
			{
				throw new ArgumentNullException("params");
			}
			NativeMethods.flann_Index_radiusSearch3(ptr, queries.CvPtr, indices, indices.Length, dists, dists.Length, radius, maxResults, @params.CvPtr);
		}

		public void Save(string filename)
		{
			if (string.IsNullOrEmpty(filename))
			{
				throw new ArgumentNullException("filename");
			}
			NativeMethods.flann_Index_save(ptr, filename);
		}
	}
}
