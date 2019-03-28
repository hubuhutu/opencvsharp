using System;

namespace OpenCvSharp.CPlusPlus
{
	public class PCA : DisposableCvObject
	{
		private bool disposed;

		public Mat Eigenvectors
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("PCA");
				}
				return new Mat(NativeMethods.core_PCA_eigenvectors(ptr));
			}
		}

		public Mat Eigenvalues
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("PCA");
				}
				return new Mat(NativeMethods.core_PCA_eigenvalues(ptr));
			}
		}

		public Mat Mean
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("PCA");
				}
				return new Mat(NativeMethods.core_PCA_mean(ptr));
			}
		}

		public PCA()
		{
			ptr = NativeMethods.core_PCA_new1();
		}

		public PCA(InputArray data, InputArray mean, PCAFlag flags, int maxComponents = 0)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (mean == null)
			{
				throw new ArgumentNullException("mean");
			}
			data.ThrowIfDisposed();
			mean.ThrowIfDisposed();
			ptr = NativeMethods.core_PCA_new2(data.CvPtr, mean.CvPtr, (int)flags, maxComponents);
		}

		public PCA(InputArray data, InputArray mean, PCAFlag flags, double retainedVariance)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (mean == null)
			{
				throw new ArgumentNullException("mean");
			}
			data.ThrowIfDisposed();
			mean.ThrowIfDisposed();
			ptr = NativeMethods.core_PCA_new3(data.CvPtr, mean.CvPtr, (int)flags, retainedVariance);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (ptr != IntPtr.Zero)
					{
						NativeMethods.core_PCA_delete(ptr);
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

		public PCA Compute(InputArray data, InputArray mean, PCAFlag flags, int maxComponents = 0)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("PCA");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (mean == null)
			{
				throw new ArgumentNullException("mean");
			}
			data.ThrowIfDisposed();
			mean.ThrowIfDisposed();
			NativeMethods.core_PCA_operatorThis(ptr, data.CvPtr, mean.CvPtr, (int)flags, maxComponents);
			return this;
		}

		public PCA ComputeVar(InputArray data, InputArray mean, PCAFlag flags, double retainedVariance)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("PCA");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (mean == null)
			{
				throw new ArgumentNullException("mean");
			}
			data.ThrowIfDisposed();
			mean.ThrowIfDisposed();
			NativeMethods.core_PCA_computeVar(ptr, data.CvPtr, mean.CvPtr, (int)flags, retainedVariance);
			return this;
		}

		public Mat Project(InputArray vec)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("PCA");
			}
			if (vec == null)
			{
				throw new ArgumentNullException("vec");
			}
			vec.ThrowIfDisposed();
			return new Mat(NativeMethods.core_PCA_project(ptr, vec.CvPtr));
		}

		public void Project(InputArray vec, OutputArray result)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("PCA");
			}
			if (vec == null)
			{
				throw new ArgumentNullException("vec");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			vec.ThrowIfDisposed();
			result.ThrowIfNotReady();
			NativeMethods.core_PCA_project(ptr, vec.CvPtr, result.CvPtr);
			result.Fix();
		}

		public Mat BackProject(InputArray vec)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("PCA");
			}
			if (vec == null)
			{
				throw new ArgumentNullException("vec");
			}
			vec.ThrowIfDisposed();
			return new Mat(NativeMethods.core_PCA_backProject(ptr, vec.CvPtr));
		}

		public void BackProject(InputArray vec, OutputArray result)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("PCA");
			}
			if (vec == null)
			{
				throw new ArgumentNullException("vec");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			vec.ThrowIfDisposed();
			result.ThrowIfNotReady();
			NativeMethods.core_PCA_backProject(ptr, vec.CvPtr, result.CvPtr);
			result.Fix();
		}
	}
}
