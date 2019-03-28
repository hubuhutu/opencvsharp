using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfRect : DisposableCvObject, IStdVector<Rect>, IDisposable
	{
		private bool disposed;

		public int Size => NativeMethods.vector_Rect_getSize(ptr).ToInt32();

		public IntPtr ElemPtr => NativeMethods.vector_Rect_getPointer(ptr);

		public VectorOfRect()
		{
			ptr = NativeMethods.vector_Rect_new1();
		}

		public VectorOfRect(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_Rect_new2(new IntPtr(size));
		}

		public VectorOfRect(IEnumerable<Rect> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			Rect[] array = Util.ToArray(data);
			ptr = NativeMethods.vector_Rect_new3(array, new IntPtr(array.Length));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_Rect_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public Rect[] ToArray()
		{
			int size = Size;
			if (size == 0)
			{
				return new Rect[0];
			}
			Rect[] array = new Rect[size];
			using (ArrayAddress1<Rect> self = new ArrayAddress1<Rect>(array))
			{
				Util.CopyMemory(self, ElemPtr, 16 * array.Length);
				return array;
			}
		}
	}
}
