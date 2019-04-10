using OpenCvSharp.Utilities;
using System;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfVectorPoint : DisposableCvObject, IStdVector<Point[]>, IDisposable
	{
		private bool disposed;

		public int Size1 {get{return NativeMethods.vector_vector_Point_getSize1(ptr).ToInt32();}}

		public int Size {get{return Size1;}}

		public long[] Size2
		{
			get
			{
				int size = Size1;
				IntPtr[] array = new IntPtr[size];
				NativeMethods.vector_vector_Point_getSize2(ptr, array);
				long[] array2 = new long[size];
				for (int i = 0; i < size; i++)
				{
					array2[i] = array[i].ToInt64();
				}
				return array2;
			}
		}

        public IntPtr ElemPtr { get { return NativeMethods.vector_vector_Point_getPointer(ptr); } }

		public VectorOfVectorPoint()
		{
			ptr = NativeMethods.vector_vector_Point_new1();
		}

		public VectorOfVectorPoint(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		public VectorOfVectorPoint(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_vector_Point_new2(new IntPtr(size));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_vector_Point_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public Point[][] ToArray()
		{
			int size = Size1;
			if (size == 0)
			{
				return new Point[0][];
			}
			long[] size2 = Size2;
			Point[][] array = new Point[size][];
			for (int i = 0; i < size; i++)
			{
				array[i] = new Point[size2[i]];
			}
			using (ArrayAddress2<Point> self = new ArrayAddress2<Point>(array))
			{
				NativeMethods.vector_vector_Point_copy(ptr, self);
				return array;
			}
		}
	}
}
