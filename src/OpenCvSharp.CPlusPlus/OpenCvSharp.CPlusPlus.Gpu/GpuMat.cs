using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public class GpuMat : DisposableCvObject, ICloneable
	{
		public sealed class Indexer<T> : GpuMatIndexer<T> where T : struct
		{
			private readonly long ptrVal;

			public override T this[int i0, int i1]
			{
				get
				{
					return (T)Marshal.PtrToStructure(new IntPtr(ptrVal + step * i0 + sizeOfT * i1), typeof(T));
				}
				set
				{
					Marshal.StructureToPtr(ptr: new IntPtr(ptrVal + step * i0 + sizeOfT * i1), structure: value, fDeleteOld: false);
				}
			}

			internal Indexer(GpuMat parent)
				: base(parent)
			{
				ptrVal = parent.Data.ToInt64();
			}
		}

		public class ColIndexer : GpuMatRowColIndexer
		{
			public override GpuMat this[int x]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new GpuMat(NativeMethods.gpu_GpuMat_col(parent.ptr, x));
				}
				set
				{
					parent.ThrowIfDisposed();
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					value.ThrowIfDisposed();
					GpuMat gpuMat = new GpuMat(NativeMethods.gpu_GpuMat_col(parent.ptr, x));
					if (gpuMat.Size() != value.Size())
					{
						throw new ArgumentException("Specified ROI != mat.Size()");
					}
					value.CopyTo(gpuMat);
				}
			}

			public override GpuMat this[int startCol, int endCol]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new GpuMat(NativeMethods.gpu_GpuMat_colRange(parent.ptr, startCol, endCol));
				}
				set
				{
					parent.ThrowIfDisposed();
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					value.ThrowIfDisposed();
					GpuMat gpuMat = new GpuMat(NativeMethods.gpu_GpuMat_colRange(parent.ptr, startCol, endCol));
					if (gpuMat.Size() != value.Size())
					{
						throw new ArgumentException("Specified ROI != mat.Size()");
					}
					value.CopyTo(gpuMat);
				}
			}

			protected internal ColIndexer(GpuMat parent)
				: base(parent)
			{
			}
		}

		public class RowIndexer : GpuMatRowColIndexer
		{
			public override GpuMat this[int x]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new GpuMat(NativeMethods.gpu_GpuMat_row(parent.ptr, x));
				}
				set
				{
					parent.ThrowIfDisposed();
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					value.ThrowIfDisposed();
					GpuMat gpuMat = new GpuMat(NativeMethods.gpu_GpuMat_row(parent.ptr, x));
					if (gpuMat.Size() != value.Size())
					{
						throw new ArgumentException("Specified ROI != mat.Size()");
					}
					value.CopyTo(gpuMat);
				}
			}

			public override GpuMat this[int startCol, int endCol]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new GpuMat(NativeMethods.gpu_GpuMat_rowRange(parent.ptr, startCol, endCol));
				}
				set
				{
					parent.ThrowIfDisposed();
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					value.ThrowIfDisposed();
					GpuMat gpuMat = new GpuMat(NativeMethods.gpu_GpuMat_rowRange(parent.ptr, startCol, endCol));
					if (gpuMat.Size() != value.Size())
					{
						throw new ArgumentException("Specified ROI != mat.Size()");
					}
					value.CopyTo(gpuMat);
				}
			}

			protected internal RowIndexer(GpuMat parent)
				: base(parent)
			{
			}
		}

		private bool disposed;

		private ColIndexer colIndexer;

		private RowIndexer rowIndexer;

		public int Flags
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_GpuMat_flags(ptr);
			}
		}

		public int Rows
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_GpuMat_rows(ptr);
			}
		}

		public int Cols
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_GpuMat_cols(ptr);
			}
		}

		public int Height
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_GpuMat_rows(ptr);
			}
		}

		public int Width
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_GpuMat_cols(ptr);
			}
		}

		public unsafe IntPtr Data
		{
			get
			{
				ThrowIfDisposed();
				return (IntPtr)(void*)NativeMethods.gpu_GpuMat_data(ptr);
			}
		}

		public IntPtr RefCount
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_GpuMat_refcount(ptr);
			}
		}

		public IntPtr DataStart
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_GpuMat_datastart(ptr);
			}
		}

		public IntPtr DataEnd
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_GpuMat_dataend(ptr);
			}
		}

		public int Bpp {get {return  (int)Math.Pow(2.0, Depth() / 2 + 1 + 2);}}

		public virtual GpuMat this[Rect roi]
		{
			get
			{
				return new GpuMat(NativeMethods.gpu_GpuMat_opRange1(ptr, roi));
			}
		}

		public virtual GpuMat this[Range rowRange, Range colRange]
		{
			get
			{
				return new GpuMat(NativeMethods.gpu_GpuMat_opRange2(ptr, rowRange, colRange));
			}
		}

		public GpuMat this[int rowStart, int rowEnd, int colStart, int colEnd]
		{
			get
			{
				return this[new Range(rowStart, rowEnd), new Range(colStart, colEnd)];
			}
		}

		public ColIndexer Col {get{return colIndexer ?? (colIndexer = new ColIndexer(this));}}

        public RowIndexer Row { get { return rowIndexer ?? (rowIndexer = new RowIndexer(this)); } }

		private void ThrowIfNotAvailable()
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (Cv2Gpu.GetCudaEnabledDeviceCount() < 1)
			{
				throw new OpenCvSharpException("GPU module cannot be used.");
			}
		}

		public GpuMat(IntPtr ptr)
		{
			ThrowIfNotAvailable();
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Native object address is NULL");
			}
			base.ptr = ptr;
		}

		public GpuMat()
		{
			ThrowIfNotAvailable();
			ptr = NativeMethods.gpu_GpuMat_new1();
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public GpuMat(int rows, int cols, MatType type)
		{
			ThrowIfNotAvailable();
			if (rows <= 0)
			{
				throw new ArgumentOutOfRangeException("rows");
			}
			if (cols <= 0)
			{
				throw new ArgumentOutOfRangeException("cols");
			}
			ptr = NativeMethods.gpu_GpuMat_new2(rows, cols, type);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public GpuMat(int rows, int cols, MatType type, IntPtr data, long step)
		{
			ThrowIfNotAvailable();
			if (rows <= 0)
			{
				throw new ArgumentOutOfRangeException("rows");
			}
			if (cols <= 0)
			{
				throw new ArgumentOutOfRangeException("cols");
			}
			ptr = NativeMethods.gpu_GpuMat_new3(rows, cols, type, data, (ulong)step);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public GpuMat(Size size, MatType type)
		{
			ThrowIfNotAvailable();
			ptr = NativeMethods.gpu_GpuMat_new6(size, type);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public GpuMat(Size size, MatType type, IntPtr data, long step = 0L)
		{
			ThrowIfNotAvailable();
			ptr = NativeMethods.gpu_GpuMat_new7(size, type, data, (ulong)step);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public GpuMat(Mat m)
		{
			ThrowIfNotAvailable();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			ptr = NativeMethods.gpu_GpuMat_new4(m.CvPtr);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public GpuMat(GpuMat m)
		{
			ThrowIfNotAvailable();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			ptr = NativeMethods.gpu_GpuMat_new5(m.CvPtr);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public GpuMat(int rows, int cols, MatType type, Scalar s)
		{
			ThrowIfNotAvailable();
			if (rows <= 0)
			{
				throw new ArgumentOutOfRangeException("rows");
			}
			if (cols <= 0)
			{
				throw new ArgumentOutOfRangeException("cols");
			}
			ptr = NativeMethods.gpu_GpuMat_new8(rows, cols, type, s);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public GpuMat(Size size, MatType type, Scalar s)
		{
			ThrowIfNotAvailable();
			ptr = NativeMethods.gpu_GpuMat_new11(size, type, s);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public GpuMat(GpuMat m, Range rowRange, Range colRange)
		{
			ThrowIfNotAvailable();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			ptr = NativeMethods.gpu_GpuMat_new9(m.CvPtr, rowRange, colRange);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public GpuMat(GpuMat m, Rect roi)
		{
			ThrowIfNotAvailable();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			ptr = NativeMethods.gpu_GpuMat_new10(m.CvPtr, roi);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public void Release()
		{
			Dispose(disposing: true);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.gpu_GpuMat_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static explicit operator GpuMat(Mat mat)
		{
			if (mat == null)
			{
				return null;
			}
			return new GpuMat(NativeMethods.gpu_GpuMat_opToGpuMat(mat.CvPtr));
		}

		public static implicit operator Mat(GpuMat gpumat)
		{
			if (gpumat == null)
			{
				return null;
			}
			return new Mat(NativeMethods.gpu_GpuMat_opToMat(gpumat.CvPtr));
		}

		public Indexer<T> GetGenericIndexer<T>() where T : struct
		{
			return new Indexer<T>(this);
		}

		public T Get<T>(int i0, int i1) where T : struct
		{
			return new Indexer<T>(this)[i0, i1];
		}

		public T At<T>(int i0, int i1) where T : struct
		{
			return new Indexer<T>(this)[i0, i1];
		}

		public void Set<T>(int i0, int i1, T value) where T : struct
		{
			new Indexer<T>(this)[i0, i1] = value;
		}

		public GpuMat ColRange(int startcol, int endcol)
		{
			ThrowIfDisposed();
			return new GpuMat(NativeMethods.gpu_GpuMat_colRange(ptr, startcol, endcol));
		}

		public GpuMat ColRange(Range r)
		{
			return ColRange(r.Start, r.End);
		}

		public GpuMat RowRange(int startrow, int endrow)
		{
			ThrowIfDisposed();
			return new GpuMat(NativeMethods.gpu_GpuMat_rowRange(ptr, startrow, endrow));
		}

		public GpuMat RowRange(Range r)
		{
			return RowRange(r.Start, r.End);
		}

		public bool IsContinuous()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_GpuMat_isContinuous(ptr) != 0;
		}

		public int Channels()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_GpuMat_channels(ptr);
		}

		public int Depth()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_GpuMat_depth(ptr);
		}

		public long ElemSize()
		{
			ThrowIfDisposed();
			return (long)NativeMethods.gpu_GpuMat_elemSize(ptr);
		}

		public long ElemSize1()
		{
			ThrowIfDisposed();
			return (long)NativeMethods.gpu_GpuMat_elemSize1(ptr);
		}

		public Size Size()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_GpuMat_size(ptr);
		}

		public long Step()
		{
			ThrowIfDisposed();
			return (long)NativeMethods.gpu_GpuMat_step(ptr);
		}

		public long Step1()
		{
			ThrowIfDisposed();
			return (long)NativeMethods.gpu_GpuMat_step1(ptr);
		}

		public MatType Type()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_GpuMat_type(ptr);
		}

		public bool Empty()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_GpuMat_empty(ptr) != 0;
		}

		public void Upload(Mat m)
		{
			ThrowIfDisposed();
			NativeMethods.gpu_GpuMat_upload(ptr, m.CvPtr);
		}

		public void Download(Mat m)
		{
			ThrowIfDisposed();
			NativeMethods.gpu_GpuMat_download(ptr, m.CvPtr);
		}

		public GpuMat Clone()
		{
			ThrowIfDisposed();
			return new GpuMat(NativeMethods.gpu_GpuMat_clone(ptr));
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public void CopyTo(GpuMat m)
		{
			ThrowIfDisposed();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			NativeMethods.gpu_GpuMat_copyTo1(ptr, m.CvPtr);
		}

		public void CopyTo(GpuMat m, GpuMat mask)
		{
			ThrowIfDisposed();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			if (mask == null)
			{
				throw new ArgumentNullException("mask");
			}
			NativeMethods.gpu_GpuMat_copyTo2(ptr, m.CvPtr, mask.CvPtr);
		}

		public void ConvertTo(GpuMat dst, MatType rtype, double alpha = 1.0, double beta = 0.0)
		{
			ThrowIfDisposed();
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			NativeMethods.gpu_GpuMat_convertTo(ptr, dst.CvPtr, rtype, alpha, beta);
		}

		public void AssignTo(GpuMat m)
		{
			ThrowIfDisposed();
			NativeMethods.gpu_GpuMat_assignTo(ptr, m.CvPtr, -1);
		}

		public void AssignTo(GpuMat m, MatType type)
		{
			ThrowIfDisposed();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			NativeMethods.gpu_GpuMat_assignTo(ptr, m.CvPtr, type);
		}

		public GpuMat SetTo(Scalar s, GpuMat mask = null)
		{
			ThrowIfDisposed();
			return new GpuMat(NativeMethods.gpu_GpuMat_setTo(ptr, s, Cv2.ToPtr(mask)));
		}

		public GpuMat Reshape(int cn, int rows)
		{
			ThrowIfDisposed();
			return new GpuMat(NativeMethods.gpu_GpuMat_reshape(ptr, cn, rows));
		}

		public void Create(int rows, int cols, MatType type)
		{
			ThrowIfDisposed();
			NativeMethods.gpu_GpuMat_create1(ptr, rows, cols, type);
		}

		public void Create(Size size, MatType type)
		{
			ThrowIfDisposed();
			NativeMethods.gpu_GpuMat_create2(ptr, size, type);
		}

		public void Swap(GpuMat mat)
		{
			ThrowIfDisposed();
			if (mat == null)
			{
				throw new ArgumentNullException("mat");
			}
			NativeMethods.gpu_GpuMat_swap(ptr, mat.CvPtr);
		}

		public void LocateROI(out CvSize wholeSize, out CvPoint ofs)
		{
			ThrowIfDisposed();
			NativeMethods.gpu_GpuMat_locateROI(ptr, out wholeSize, out ofs);
		}

		public GpuMat AdjustROI(int dtop, int dbottom, int dleft, int dright)
		{
			ThrowIfDisposed();
			return new GpuMat(NativeMethods.gpu_GpuMat_adjustROI(ptr, dtop, dbottom, dleft, dright));
		}

		public unsafe byte* Ptr(int y = 0)
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_GpuMat_ptr(ptr, y);
		}

		public override string ToString()
		{
			return "Mat [ " + Rows + "*" + Cols + "*" + Type().ToString() + ", IsContinuous=" + IsContinuous().ToString() + ", Ptr=0x" + Convert.ToString(ptr.ToInt64(), 16) + ", Data=0x" + Convert.ToString(Data.ToInt64(), 16) + " ]";
		}
	}
}
