using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
	public class CvMatND : CvArr, ICloneable
	{
		public struct Dimension
		{
			public int Size;

			public int Step;
		}

		private bool disposed;

		private PointerAccessor1D_Byte _dataArrayByte;

		private PointerAccessor1D_Int16 _dataArrayInt16;

		private PointerAccessor1D_Int32 _dataArrayInt32;

		private PointerAccessor1D_Single _dataArraySingle;

		private PointerAccessor1D_Double _dataArrayDouble;

		public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvMatND));

		public new unsafe int Dims { get { return  ((WCvMatND*)(void*)ptr)->dims;}}

        public unsafe int Type { get { return ((WCvMatND*)(void*)ptr)->type; } }

		public unsafe IntPtr RefCount
		{
			get
			{
				return new IntPtr(((WCvMatND*)(void*)ptr)->refcount);
			}
			internal set
			{
				((WCvMatND*)(void*)ptr)->refcount = (int*)(void*)value;
			}
		}

		public unsafe Dimension[] Dim
		{
			get
			{
				Dimension[] array = new Dimension[32];
				int* ptr = ((WCvMatND*)(void*)base.ptr)->dim;
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = new Dimension
					{
						Size = ptr[i * 2 + 0],
						Step = ptr[i * 2 + 1]
					};
				}
				return array;
			}
		}

		public unsafe IntPtr Data
		{
			get
			{
				return new IntPtr(((WCvMatND*)(void*)ptr)->data);
			}
			internal set
			{
				((WCvMatND*)(void*)ptr)->data = value.ToPointer();
			}
		}

		public unsafe byte* DataByte { get { return  (byte*)((WCvMatND*)(void*)ptr)->data;}}

		public unsafe short* DataInt16 { get { return  (short*)((WCvMatND*)(void*)ptr)->data;}}

		public unsafe int* DataInt32 { get { return  (int*)((WCvMatND*)(void*)ptr)->data;}}

		public unsafe float* DataSingle { get { return  (float*)((WCvMatND*)(void*)ptr)->data;}}

		public unsafe double* DataDouble { get { return  (double*)((WCvMatND*)(void*)ptr)->data;}}

		public unsafe PointerAccessor1D_Byte DataArrayByte
		{
			get
			{
				if (_dataArrayByte == null)
				{
					byte* data = (byte*)((WCvMatND*)(void*)ptr)->data;
					_dataArrayByte = new PointerAccessor1D_Byte(data);
				}
				return _dataArrayByte;
			}
		}

		public unsafe PointerAccessor1D_Int16 DataArrayInt16
		{
			get
			{
				if (_dataArrayInt16 == null)
				{
					short* data = (short*)((WCvMatND*)(void*)ptr)->data;
					_dataArrayInt16 = new PointerAccessor1D_Int16(data);
				}
				return _dataArrayInt16;
			}
		}

		public unsafe PointerAccessor1D_Int32 DataArrayInt32
		{
			get
			{
				if (_dataArrayInt32 == null)
				{
					int* data = (int*)((WCvMatND*)(void*)ptr)->data;
					_dataArrayInt32 = new PointerAccessor1D_Int32(data);
				}
				return _dataArrayInt32;
			}
		}

		public unsafe PointerAccessor1D_Single DataArraySingle
		{
			get
			{
				if (_dataArraySingle == null)
				{
					float* data = (float*)((WCvMatND*)(void*)ptr)->data;
					_dataArraySingle = new PointerAccessor1D_Single(data);
				}
				return _dataArraySingle;
			}
		}

		public unsafe PointerAccessor1D_Double DataArrayDouble
		{
			get
			{
				if (_dataArrayDouble == null)
				{
					double* data = (double*)((WCvMatND*)(void*)ptr)->data;
					_dataArrayDouble = new PointerAccessor1D_Double(data);
				}
				return _dataArrayDouble;
			}
		}

		public CvMatND(int dims, int[] sizes, MatrixType type)
		{
			if (sizes == null)
			{
				throw new ArgumentNullException("sizes");
			}
			ptr = NativeMethods.cvCreateMatND(dims, sizes, type);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create CvMat");
			}
		}

		public CvMatND(int dims, int[] sizes, MatrixType type, Array data)
			: this(dims, sizes, type)
		{
			GCHandle gCHandle = AllocGCHandle(data);
			NativeMethods.cvInitMatNDHeader(base.CvPtr, dims, sizes, type, gCHandle.AddrOfPinnedObject());
		}

		public CvMatND(IntPtr ptr)
			: this(ptr, isEnabledDispose: true)
		{
		}

		internal CvMatND(IntPtr ptr, bool isEnabledDispose)
			: base(isEnabledDispose)
		{
			base.ptr = ptr;
		}

		public CvMatND()
			: this(isEnabledDispose: true)
		{
		}

		internal CvMatND(bool isEnabledDispose)
			: base(isEnabledDispose)
		{
			ptr = AllocMemory(SizeOf);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.cvReleaseMat(ref ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static CvMatND operator +(CvMatND a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			return a.Clone();
		}

		public static CvMatND operator -(CvMatND a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMatND cvMatND = a.Clone();
			Cv.AddWeighted(a, -1.0, a, 0.0, 0.0, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator ~(CvMatND a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMatND cvMatND = a.Clone();
			Cv.Not(a, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator +(CvMatND a, CvMatND b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvMatND cvMatND = a.Clone();
			Cv.Add(a, b, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator +(CvMatND a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMatND cvMatND = a.Clone();
			Cv.AddS(a, b, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator -(CvMatND a, CvMatND b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvMatND cvMatND = a.Clone();
			Cv.Sub(a, b, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator -(CvMatND a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMatND cvMatND = a.Clone();
			Cv.SubS(a, b, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator *(CvMatND a, CvMatND b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvMatND cvMatND = a.Clone();
			Cv.MatMul(a, b, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator *(CvMatND a, double b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMatND cvMatND = a.Clone();
			Cv.AddWeighted(a, b, a, 0.0, 0.0, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator /(CvMatND a, double b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == 0.0)
			{
				throw new DivideByZeroException();
			}
			CvMatND cvMatND = a.Clone();
			Cv.AddWeighted(a, 1.0 / b, a, 0.0, 0.0, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator &(CvMatND a, CvMatND b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvMatND cvMatND = a.Clone();
			Cv.And(a, b, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator &(CvMatND a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMatND cvMatND = a.Clone();
			Cv.AndS(a, b, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator |(CvMatND a, CvMatND b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvMatND cvMatND = a.Clone();
			Cv.Or(a, b, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator |(CvMatND a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMatND cvMatND = a.Clone();
			Cv.OrS(a, b, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator ^(CvMatND a, CvMatND b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvMatND cvMatND = a.Clone();
			Cv.Xor(a, b, cvMatND);
			return cvMatND;
		}

		public static CvMatND operator ^(CvMatND a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMatND cvMatND = a.Clone();
			Cv.XorS(a, b, cvMatND);
			return cvMatND;
		}

		public CvMatND Clone()
		{
			return Cv.CloneMatND(this);
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public CvMatND InitMatNDHeader(int dims, int[] sizes, MatrixType type)
		{
			return Cv.InitMatNDHeader(this, dims, sizes, type);
		}

		public CvMatND InitMatNDHeader<T>(int dims, int[] sizes, MatrixType type, T[] data) where T : struct
		{
			return Cv.InitMatNDHeader(this, dims, sizes, type, data);
		}
	}
}
