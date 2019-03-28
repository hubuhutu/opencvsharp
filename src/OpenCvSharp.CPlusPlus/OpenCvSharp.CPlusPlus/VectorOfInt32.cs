using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfInt32 : DisposableCvObject, IStdVector<int>, IDisposable
	{
		private bool disposed;

		public int Size => NativeMethods.vector_int32_getSize(ptr).ToInt32();

		public IntPtr ElemPtr => NativeMethods.vector_int32_getPointer(ptr);

		public VectorOfInt32()
		{
			ptr = NativeMethods.vector_int32_new1();
		}

		public VectorOfInt32(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_int32_new2(new IntPtr(size));
		}

		public VectorOfInt32(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		public VectorOfInt32(IEnumerable<int> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			int[] array = EnumerableEx.ToArray(data);
			ptr = NativeMethods.vector_int32_new3(array, new IntPtr(array.Length));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_float_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public int[] ToArray()
		{
			int size = Size;
			if (size == 0)
			{
				return new int[0];
			}
			int[] array = new int[size];
			Marshal.Copy(ElemPtr, array, 0, array.Length);
			return array;
		}
	}
}
