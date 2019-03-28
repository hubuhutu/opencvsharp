using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfPoint3f : DisposableCvObject, IStdVector<Point3f>, IDisposable
	{
		private bool disposed;

		public int Size => NativeMethods.vector_Point3f_getSize(ptr).ToInt32();

		public IntPtr ElemPtr => NativeMethods.vector_Point3f_getPointer(ptr);

		public VectorOfPoint3f()
		{
			ptr = NativeMethods.vector_Point2f_new1();
		}

		public VectorOfPoint3f(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_Point3f_new2(new IntPtr(size));
		}

		public VectorOfPoint3f(IEnumerable<Point3f> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			Point3f[] array = Util.ToArray(data);
			ptr = NativeMethods.vector_Point3f_new3(array, new IntPtr(array.Length));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_Point3f_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public Point3f[] ToArray()
		{
			int size = Size;
			if (size == 0)
			{
				return new Point3f[0];
			}
			Point3f[] array = new Point3f[size];
			using (ArrayAddress1<Point3f> self = new ArrayAddress1<Point3f>(array))
			{
				Util.CopyMemory(self, ElemPtr, 12 * array.Length);
				return array;
			}
		}
	}
}
