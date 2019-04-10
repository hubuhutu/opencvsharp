using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfPoint : DisposableCvObject, IStdVector<Point>, IDisposable
	{
		private bool disposed;

		public int Size {get{return NativeMethods.vector_Point2i_getSize(ptr).ToInt32();}}

        public IntPtr ElemPtr { get { return NativeMethods.vector_Point2i_getPointer(ptr); } }

		public VectorOfPoint()
		{
			ptr = NativeMethods.vector_Point2i_new1();
		}

		public VectorOfPoint(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_Point2i_new2(new IntPtr(size));
		}

		public VectorOfPoint(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		public VectorOfPoint(IEnumerable<Point> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			Point[] array = Util.ToArray(data);
			ptr = NativeMethods.vector_Point2i_new3(array, new IntPtr(array.Length));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_Point2i_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public Point[] ToArray()
		{
			int size = Size;
			if (size == 0)
			{
				return new Point[0];
			}
			Point[] array = new Point[size];
			using (ArrayAddress1<Point> self = new ArrayAddress1<Point>(array))
			{
				Util.CopyMemory(self, ElemPtr, 8 * array.Length);
				return array;
			}
		}
	}
}
