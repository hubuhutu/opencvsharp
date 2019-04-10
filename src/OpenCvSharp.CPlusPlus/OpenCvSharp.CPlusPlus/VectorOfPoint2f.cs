using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfPoint2f : DisposableCvObject, IStdVector<Point2f>, IDisposable
	{
		private bool disposed;

		public int Size {get{return NativeMethods.vector_Point2f_getSize(ptr).ToInt32();}}

        public IntPtr ElemPtr { get { return NativeMethods.vector_Point2f_getPointer(ptr); } }

		public VectorOfPoint2f()
		{
			ptr = NativeMethods.vector_Point2f_new1();
		}

		public VectorOfPoint2f(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		public VectorOfPoint2f(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_Point2f_new2(new IntPtr(size));
		}

		public VectorOfPoint2f(IEnumerable<Point2f> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			Point2f[] array = Util.ToArray(data);
			ptr = NativeMethods.vector_Point2f_new3(array, new IntPtr(array.Length));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_Point2f_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public Point2f[] ToArray()
		{
			int size = Size;
			if (size == 0)
			{
				return new Point2f[0];
			}
			Point2f[] array = new Point2f[size];
			using (ArrayAddress1<Point2f> self = new ArrayAddress1<Point2f>(array))
			{
				Util.CopyMemory(self, ElemPtr, 8 * array.Length);
				return array;
			}
		}
	}
}
