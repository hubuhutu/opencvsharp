using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
	public class CvSparseMat : CvArr, ICloneable
	{
		private bool disposed;

		public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSparseMat));

		public new unsafe int Dims => ((WCvSparseMat*)(void*)ptr)->dims;

		public unsafe int Type => ((WCvSparseMat*)(void*)ptr)->type;

		public unsafe int HashSize => ((WCvSparseMat*)(void*)ptr)->hashsize;

		public unsafe IntPtr HashTable => new IntPtr(((WCvSparseMat*)(void*)ptr)->hashtable);

		public unsafe IntPtr Heap => new IntPtr(((WCvSparseMat*)(void*)ptr)->heap);

		public unsafe int IdxOffset => ((WCvSparseMat*)(void*)ptr)->idxoffset;

		public unsafe int ValOffset => ((WCvSparseMat*)(void*)ptr)->valoffset;

		public unsafe int[] Size
		{
			get
			{
				int[] array = new int[32];
				Marshal.Copy(new IntPtr(((WCvSparseMat*)(void*)ptr)->size), array, 0, array.Length);
				return array;
			}
		}

		public CvSparseMat(IntPtr ptr)
			: this(ptr, isEnabledDispose: true)
		{
		}

		internal CvSparseMat(IntPtr ptr, bool isEnabledDispose)
			: base(isEnabledDispose)
		{
			base.ptr = ptr;
		}

		public CvSparseMat(int dims, int[] sizes, MatrixType type)
			: base(isEnabledDispose: true)
		{
			if (sizes == null)
			{
				throw new ArgumentNullException("sizes");
			}
			IntPtr intPtr = NativeMethods.cvCreateSparseMat(dims, sizes, type);
			if (intPtr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create CvSparseMat");
			}
			ptr = intPtr;
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.cvReleaseSparseMat(ref ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static CvSparseMat operator +(CvSparseMat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			return a.Clone();
		}

		public static CvSparseMat operator -(CvSparseMat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.AddWeighted(a, -1.0, a, 0.0, 0.0, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator ~(CvSparseMat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.Not(a, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator +(CvSparseMat a, CvSparseMat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.Add(a, b, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator +(CvSparseMat a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.AddS(a, b, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator -(CvSparseMat a, CvSparseMat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.Sub(a, b, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator -(CvSparseMat a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.SubS(a, b, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator *(CvSparseMat a, CvSparseMat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.MatMul(a, b, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator *(CvSparseMat a, double b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.AddWeighted(a, b, a, 0.0, 0.0, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator /(CvSparseMat a, double b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == 0.0)
			{
				throw new DivideByZeroException();
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.AddWeighted(a, 1.0 / b, a, 0.0, 0.0, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator &(CvSparseMat a, CvSparseMat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.And(a, b, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator &(CvSparseMat a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.AndS(a, b, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator |(CvSparseMat a, CvSparseMat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.Or(a, b, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator |(CvSparseMat a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.OrS(a, b, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator ^(CvSparseMat a, CvSparseMat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.Xor(a, b, cvSparseMat);
			return cvSparseMat;
		}

		public static CvSparseMat operator ^(CvSparseMat a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvSparseMat cvSparseMat = a.Clone();
			Cv.XorS(a, b, cvSparseMat);
			return cvSparseMat;
		}

		public CvSparseMat Clone()
		{
			return Cv.CloneSparseMat(this);
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public PointerAccessor1D_Int32 NodeIdx(CvSparseNode node)
		{
			return Cv.NODE_IDX(this, node);
		}

		public T NodeVal<T>(CvSparseNode node) where T : struct
		{
			return Cv.NODE_VAL<T>(this, node);
		}
	}
}
