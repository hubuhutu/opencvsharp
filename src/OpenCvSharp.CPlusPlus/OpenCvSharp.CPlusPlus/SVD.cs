using System;

namespace OpenCvSharp.CPlusPlus
{
	public class SVD : DisposableCvObject
	{
		private bool disposed;

		public Mat U
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("SVD");
				}
				return new Mat(NativeMethods.core_SVD_u(ptr));
			}
		}

		public Mat W
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("SVD");
				}
				return new Mat(NativeMethods.core_SVD_w(ptr));
			}
		}

		public Mat Vt
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("SVD");
				}
				return new Mat(NativeMethods.core_SVD_vt(ptr));
			}
		}

		public SVD()
		{
			ptr = NativeMethods.core_SVD_new();
		}

		public SVD(InputArray src, SVDFlag flags = SVDFlag.Zero)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			src.ThrowIfDisposed();
			ptr = NativeMethods.core_SVD_new(src.CvPtr, (int)flags);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (ptr != IntPtr.Zero)
					{
						NativeMethods.core_SVD_delete(ptr);
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

		public SVD Run(InputArray src, SVDFlag flags = SVDFlag.Zero)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("SVD");
			}
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			src.ThrowIfDisposed();
			NativeMethods.core_SVD_operatorThis(ptr, src.CvPtr, (int)flags);
			return this;
		}

		public void BackSubst(InputArray rhs, OutputArray dst)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("SVD");
			}
			if (rhs == null)
			{
				throw new ArgumentNullException("rhs");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			rhs.ThrowIfDisposed();
			dst.ThrowIfNotReady();
			NativeMethods.core_SVD_backSubst(ptr, rhs.CvPtr, dst.CvPtr);
		}

		public static void Compute(InputArray src, OutputArray w, OutputArray u, OutputArray vt, SVDFlag flags = SVDFlag.Zero)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (w == null)
			{
				throw new ArgumentNullException("w");
			}
			if (u == null)
			{
				throw new ArgumentNullException("u");
			}
			if (vt == null)
			{
				throw new ArgumentNullException("vt");
			}
			src.ThrowIfDisposed();
			w.ThrowIfNotReady();
			u.ThrowIfNotReady();
			vt.ThrowIfNotReady();
			NativeMethods.core_SVD_static_compute(src.CvPtr, w.CvPtr, u.CvPtr, vt.CvPtr, (int)flags);
			w.Fix();
			u.Fix();
			vt.Fix();
		}

		public static void Compute(InputArray src, OutputArray w, SVDFlag flags = SVDFlag.Zero)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (w == null)
			{
				throw new ArgumentNullException("w");
			}
			src.ThrowIfDisposed();
			w.ThrowIfNotReady();
			NativeMethods.core_SVD_static_compute(src.CvPtr, w.CvPtr, (int)flags);
			w.Fix();
		}

		public static void BackSubst(InputArray w, InputArray u, InputArray vt, InputArray rhs, OutputArray dst)
		{
			if (w == null)
			{
				throw new ArgumentNullException("w");
			}
			if (u == null)
			{
				throw new ArgumentNullException("u");
			}
			if (vt == null)
			{
				throw new ArgumentNullException("vt");
			}
			if (rhs == null)
			{
				throw new ArgumentNullException("rhs");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			w.ThrowIfDisposed();
			u.ThrowIfDisposed();
			vt.ThrowIfDisposed();
			rhs.ThrowIfDisposed();
			dst.ThrowIfNotReady();
			NativeMethods.core_SVD_static_backSubst(w.CvPtr, u.CvPtr, vt.CvPtr, rhs.CvPtr, dst.CvPtr);
			dst.Fix();
		}

		public static void SolveZ(InputArray src, OutputArray dst)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfNotReady();
			NativeMethods.core_SVD_static_solveZ(src.CvPtr, dst.CvPtr);
			dst.Fix();
		}
	}
}
