using OpenCvSharp.Utilities;
using System;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfVectorPoint2f : DisposableCvObject, IStdVector<Point2f[]>, IDisposable
	{
		private bool disposed;

		public int Size1 {get {return  NativeMethods.vector_vector_Point2f_getSize1(ptr).ToInt32();}}

		public int Size {get {return Size1;}}

		public long[] Size2
		{
			get
			{
				int size = Size1;
				IntPtr[] array = new IntPtr[size];
				NativeMethods.vector_vector_Point2f_getSize2(ptr, array);
				long[] array2 = new long[size];
				for (int i = 0; i < size; i++)
				{
					array2[i] = array[i].ToInt64();
				}
				return array2;
			}
		}

        public IntPtr ElemPtr { get { return NativeMethods.vector_vector_Point2f_getPointer(ptr); } }

		public VectorOfVectorPoint2f()
		{
			ptr = NativeMethods.vector_vector_Point2f_new1();
		}

		public VectorOfVectorPoint2f(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		public VectorOfVectorPoint2f(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_vector_Point2f_new2(new IntPtr(size));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_vector_Point2f_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public Point2f[][] ToArray()
		{
			int size = Size1;
			if (size == 0)
			{
				return new Point2f[0][];
			}
			long[] size2 = Size2;
			Point2f[][] array = new Point2f[size][];
			for (int i = 0; i < size; i++)
			{
				array[i] = new Point2f[size2[i]];
			}
			using (ArrayAddress2<Point2f> self = new ArrayAddress2<Point2f>(array))
			{
				NativeMethods.vector_vector_Point2f_copy(ptr, self);
				return array;
			}
		}
	}
}
