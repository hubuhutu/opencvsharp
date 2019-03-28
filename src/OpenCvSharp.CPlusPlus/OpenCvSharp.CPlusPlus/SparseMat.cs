using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	public class SparseMat : DisposableCvObject, ICloneable
	{
		public sealed class Indexer<T> : SparseMatIndexer<T> where T : struct
		{
			public override T this[int i0, long? hashVal = default(long?)]
			{
				get
				{
					return (T)Marshal.PtrToStructure(parent.Ptr(i0, createMissing: true, hashVal), typeof(T));
				}
				set
				{
					IntPtr ptr = parent.Ptr(i0, createMissing: true, hashVal);
					Marshal.StructureToPtr(value, ptr, fDeleteOld: false);
				}
			}

			public override T this[int i0, int i1, long? hashVal = default(long?)]
			{
				get
				{
					return (T)Marshal.PtrToStructure(parent.Ptr(i0, i1, createMissing: true, hashVal), typeof(T));
				}
				set
				{
					IntPtr ptr = parent.Ptr(i0, i1, createMissing: true, hashVal);
					Marshal.StructureToPtr(value, ptr, fDeleteOld: false);
				}
			}

			public override T this[int i0, int i1, int i2, long? hashVal = default(long?)]
			{
				get
				{
					return (T)Marshal.PtrToStructure(parent.Ptr(i0, i1, i2, createMissing: true, hashVal), typeof(T));
				}
				set
				{
					IntPtr ptr = parent.Ptr(i0, i1, i2, createMissing: true, hashVal);
					Marshal.StructureToPtr(value, ptr, fDeleteOld: false);
				}
			}

			public override T this[int[] idx, long? hashVal = default(long?)]
			{
				get
				{
					return (T)Marshal.PtrToStructure(parent.Ptr(idx, createMissing: true, hashVal), typeof(T));
				}
				set
				{
					IntPtr ptr = parent.Ptr(idx, createMissing: true, hashVal);
					Marshal.StructureToPtr(value, ptr, fDeleteOld: false);
				}
			}

			internal Indexer(SparseMat parent)
				: base(parent)
			{
			}
		}

		private bool disposed;

		public static readonly int SizeOf = (int)NativeMethods.core_SparseMat_sizeof();

		public SparseMat(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Native object address is NULL");
			}
			base.ptr = ptr;
		}

		public SparseMat()
		{
			ptr = NativeMethods.core_SparseMat_new1();
		}

		public SparseMat(IEnumerable<int> sizes, MatType type)
		{
			if (sizes == null)
			{
				throw new ArgumentNullException("sizes");
			}
			int[] array = EnumerableEx.ToArray(sizes);
			ptr = NativeMethods.core_SparseMat_new2(array.Length, array, type);
		}

		public SparseMat(Mat m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			m.ThrowIfDisposed();
			ptr = NativeMethods.core_SparseMat_new3(m.CvPtr);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public SparseMat(CvSparseMat m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			m.ThrowIfDisposed();
			ptr = NativeMethods.core_SparseMat_new4(m.CvPtr);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public void Release()
		{
			Dispose();
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose && ptr != IntPtr.Zero)
					{
						NativeMethods.core_SparseMat_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static SparseMat FromMat(Mat mat)
		{
			return new SparseMat(mat);
		}

		public static SparseMat FromCvSparseMat(CvSparseMat mat)
		{
			return new SparseMat(mat);
		}

		public static explicit operator CvSparseMat(SparseMat self)
		{
			return self.ToCvSparseMat();
		}

		public CvSparseMat ToCvSparseMat()
		{
			ThrowIfDisposed();
			return new CvSparseMat(NativeMethods.core_SparseMat_operator_CvSparseMat(ptr));
		}

		public SparseMat AssignFrom(SparseMat m)
		{
			ThrowIfDisposed();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			NativeMethods.core_SparseMat_operatorAssign_SparseMat(ptr, m.CvPtr);
			return this;
		}

		public SparseMat AssignFrom(Mat m)
		{
			ThrowIfDisposed();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			NativeMethods.core_SparseMat_operatorAssign_Mat(ptr, m.CvPtr);
			return this;
		}

		public SparseMat Clone()
		{
			ThrowIfDisposed();
			return new SparseMat(NativeMethods.core_SparseMat_clone(ptr));
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public void CopyTo(SparseMat m)
		{
			ThrowIfDisposed();
			NativeMethods.core_SparseMat_copyTo_SparseMat(ptr, m.CvPtr);
		}

		public void CopyTo(Mat m)
		{
			ThrowIfDisposed();
			NativeMethods.core_SparseMat_copyTo_Mat(ptr, m.CvPtr);
		}

		public void ConvertTo(SparseMat m, int rtype, double alpha = 1.0)
		{
			ThrowIfDisposed();
			NativeMethods.core_SparseMat_convertTo_SparseMat(ptr, m.CvPtr, rtype, alpha);
		}

		public void ConvertTo(Mat m, int rtype, double alpha = 1.0, double beta = 0.0)
		{
			ThrowIfDisposed();
			NativeMethods.core_SparseMat_convertTo_SparseMat(ptr, m.CvPtr, rtype, alpha);
		}

		public void AssignTo(SparseMat m, int type = -1)
		{
			ThrowIfDisposed();
			NativeMethods.core_SparseMat_assignTo(ptr, m.CvPtr, type);
		}

		public void Create(MatType type, params int[] sizes)
		{
			ThrowIfDisposed();
			if (sizes == null)
			{
				throw new ArgumentNullException("sizes");
			}
			if (sizes.Length == 1)
			{
				throw new ArgumentException("sizes is empty");
			}
			NativeMethods.core_SparseMat_create(ptr, sizes.Length, sizes, type);
		}

		public void Clear()
		{
			ThrowIfDisposed();
			NativeMethods.core_SparseMat_clear(ptr);
		}

		public void Addref()
		{
			ThrowIfDisposed();
			NativeMethods.core_SparseMat_addref(ptr);
		}

		public int ElemSize()
		{
			ThrowIfDisposed();
			return NativeMethods.core_SparseMat_elemSize(ptr);
		}

		public int ElemSize1()
		{
			ThrowIfDisposed();
			return NativeMethods.core_SparseMat_elemSize1(ptr);
		}

		public MatType Type()
		{
			ThrowIfDisposed();
			return NativeMethods.core_SparseMat_type(ptr);
		}

		public int Depth()
		{
			ThrowIfDisposed();
			return NativeMethods.core_SparseMat_depth(ptr);
		}

		public int Dims()
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_dims(ptr);
		}

		public int Channels()
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_channels(ptr);
		}

		public int[] Size()
		{
			ThrowIfDisposed();
			IntPtr intPtr = NativeMethods.core_SparseMat_size1(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			int num = Dims();
			int[] array = new int[num];
			Marshal.Copy(intPtr, array, 0, num);
			return array;
		}

		public int Size(int dim)
		{
			ThrowIfDisposed();
			return NativeMethods.core_SparseMat_size2(ptr, dim);
		}

		public long Hash(int i0)
		{
			ThrowIfDisposed();
			return NativeMethods.core_SparseMat_hash_1d(ptr, i0).ToInt64();
		}

		public long Hash(int i0, int i1)
		{
			ThrowIfDisposed();
			return NativeMethods.core_SparseMat_hash_2d(ptr, i0, i1).ToInt64();
		}

		public long Hash(int i0, int i1, int i2)
		{
			ThrowIfDisposed();
			return NativeMethods.core_SparseMat_hash_3d(ptr, i0, i1, i2).ToInt64();
		}

		public long Hash(params int[] idx)
		{
			ThrowIfDisposed();
			return NativeMethods.core_SparseMat_hash_nd(ptr, idx).ToInt64();
		}

		public IntPtr Ptr(int i0, bool createMissing, long? hashVal = default(long?))
		{
			if (hashVal.HasValue)
			{
				ulong hashval = (ulong)hashVal.Value;
				return NativeMethods.core_SparseMat_ptr_1d(ptr, i0, createMissing ? 1 : 0, ref hashval);
			}
			return NativeMethods.core_SparseMat_ptr_1d(ptr, i0, createMissing ? 1 : 0, IntPtr.Zero);
		}

		public IntPtr Ptr(int i0, int i1, bool createMissing, long? hashVal = default(long?))
		{
			if (hashVal.HasValue)
			{
				ulong hashval = (ulong)hashVal.Value;
				return NativeMethods.core_SparseMat_ptr_2d(ptr, i0, i1, createMissing ? 1 : 0, ref hashval);
			}
			return NativeMethods.core_SparseMat_ptr_2d(ptr, i0, i1, createMissing ? 1 : 0, IntPtr.Zero);
		}

		public IntPtr Ptr(int i0, int i1, int i2, bool createMissing, long? hashVal = default(long?))
		{
			if (hashVal.HasValue)
			{
				ulong hashval = (ulong)hashVal.Value;
				return NativeMethods.core_SparseMat_ptr_3d(ptr, i0, i1, i2, createMissing ? 1 : 0, ref hashval);
			}
			return NativeMethods.core_SparseMat_ptr_3d(ptr, i0, i1, i2, createMissing ? 1 : 0, IntPtr.Zero);
		}

		public IntPtr Ptr(int[] idx, bool createMissing, long? hashVal = default(long?))
		{
			if (hashVal.HasValue)
			{
				ulong hashval = (ulong)hashVal.Value;
				return NativeMethods.core_SparseMat_ptr_nd(ptr, idx, createMissing ? 1 : 0, ref hashval);
			}
			return NativeMethods.core_SparseMat_ptr_nd(ptr, idx, createMissing ? 1 : 0, IntPtr.Zero);
		}

		public T? Find<T>(int i0, long? hashVal = default(long?)) where T : struct
		{
			IntPtr intPtr = Ptr(i0, createMissing: false, hashVal);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return (T)Marshal.PtrToStructure(intPtr, typeof(T));
		}

		public T? Find<T>(int i0, int i1, long? hashVal = default(long?)) where T : struct
		{
			IntPtr intPtr = Ptr(i0, i1, createMissing: false, hashVal);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return (T)Marshal.PtrToStructure(intPtr, typeof(T));
		}

		public T? Find<T>(int i0, int i1, int i2, long? hashVal = default(long?)) where T : struct
		{
			IntPtr intPtr = Ptr(i0, i1, i2, createMissing: false, hashVal);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return (T)Marshal.PtrToStructure(intPtr, typeof(T));
		}

		public T? Find<T>(int[] idx, long? hashVal = default(long?)) where T : struct
		{
			IntPtr intPtr = Ptr(idx, createMissing: false, hashVal);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return (T)Marshal.PtrToStructure(intPtr, typeof(T));
		}

		public T Value<T>(int i0, long? hashVal = default(long?)) where T : struct
		{
			IntPtr intPtr = Ptr(i0, createMissing: false, hashVal);
			if (intPtr == IntPtr.Zero)
			{
				return default(T);
			}
			return (T)Marshal.PtrToStructure(intPtr, typeof(T));
		}

		public T Value<T>(int i0, int i1, long? hashVal = default(long?)) where T : struct
		{
			IntPtr intPtr = Ptr(i0, i1, createMissing: false, hashVal);
			if (intPtr == IntPtr.Zero)
			{
				return default(T);
			}
			return (T)Marshal.PtrToStructure(intPtr, typeof(T));
		}

		public T Value<T>(int i0, int i1, int i2, long? hashVal = default(long?)) where T : struct
		{
			IntPtr intPtr = Ptr(i0, i1, i2, createMissing: false, hashVal);
			if (intPtr == IntPtr.Zero)
			{
				return default(T);
			}
			return (T)Marshal.PtrToStructure(intPtr, typeof(T));
		}

		public T Value<T>(int[] idx, long? hashVal = default(long?)) where T : struct
		{
			IntPtr intPtr = Ptr(idx, createMissing: false, hashVal);
			if (intPtr == IntPtr.Zero)
			{
				return default(T);
			}
			return (T)Marshal.PtrToStructure(intPtr, typeof(T));
		}

		public Indexer<T> Ref<T>() where T : struct
		{
			return new Indexer<T>(this);
		}

		public Indexer<T> GetIndexer<T>() where T : struct
		{
			return new Indexer<T>(this);
		}

		public T Get<T>(int i0, long? hashVal = default(long?)) where T : struct
		{
			return new Indexer<T>(this)[i0, hashVal];
		}

		public T Get<T>(int i0, int i1, long? hashVal = default(long?)) where T : struct
		{
			return new Indexer<T>(this)[i0, i1, hashVal];
		}

		public T Get<T>(int i0, int i1, int i2, long? hashVal = default(long?)) where T : struct
		{
			return new Indexer<T>(this)[i0, i1, i2, hashVal];
		}

		public T Get<T>(int[] idx, long? hashVal = default(long?)) where T : struct
		{
			return new Indexer<T>(this)[idx, hashVal];
		}

		public void Set<T>(int i0, T value, long? hashVal = default(long?)) where T : struct
		{
			new Indexer<T>(this)[i0, hashVal] = value;
		}

		public void Set<T>(int i0, int i1, T value, long? hashVal = default(long?)) where T : struct
		{
			new Indexer<T>(this)[i0, i1, hashVal] = value;
		}

		public void Set<T>(int i0, int i1, int i2, T value, long? hashVal = default(long?)) where T : struct
		{
			new Indexer<T>(this)[i0, i1, i2, hashVal] = value;
		}

		public void Set<T>(int[] idx, T value, long? hashVal = default(long?)) where T : struct
		{
			new Indexer<T>(this)[idx, hashVal] = value;
		}

		public override string ToString()
		{
			return "Mat [ Dims=" + Dims() + "Type=" + Type().ToString() + " ]";
		}
	}
}
