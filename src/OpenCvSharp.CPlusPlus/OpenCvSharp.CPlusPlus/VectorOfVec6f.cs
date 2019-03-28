using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfVec6f : DisposableCvObject, IStdVector<Vec6f>, IDisposable
	{
		private bool disposed;

		public int Size => NativeMethods.vector_Vec6f_getSize(ptr).ToInt32();

		public IntPtr ElemPtr => NativeMethods.vector_Vec6f_getPointer(ptr);

		public VectorOfVec6f()
		{
			ptr = NativeMethods.vector_Vec6f_new1();
		}

		public VectorOfVec6f(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_Vec6f_new2(new IntPtr(size));
		}

		public VectorOfVec6f(IEnumerable<Vec6f> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			Vec6f[] array = Util.ToArray(data);
			ptr = NativeMethods.vector_Vec6f_new3(array, new IntPtr(array.Length));
		}

		public VectorOfVec6f(IntPtr p)
		{
			ptr = p;
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_Vec6f_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public Vec6f[] ToArray()
		{
			return ToArray<Vec6f>();
		}

		public T[] ToArray<T>() where T : struct
		{
			int num = Marshal.SizeOf(typeof(T));
			if (num != 24)
			{
				throw new OpenCvSharpException();
			}
			int size = Size;
			if (size == 0)
			{
				return new T[0];
			}
			T[] array = new T[size];
			using (ArrayAddress1<T> self = new ArrayAddress1<T>(array))
			{
				Util.CopyMemory(self, ElemPtr, num * array.Length);
				return array;
			}
		}
	}
}
