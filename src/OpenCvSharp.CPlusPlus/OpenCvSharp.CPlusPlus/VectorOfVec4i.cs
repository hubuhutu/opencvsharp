using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfVec4i : DisposableCvObject, IStdVector<Vec4i>, IDisposable
	{
		private bool disposed;

		public int Size => NativeMethods.vector_Vec4i_getSize(ptr).ToInt32();

		public IntPtr ElemPtr => NativeMethods.vector_Vec4i_getPointer(ptr);

		public VectorOfVec4i()
		{
			ptr = NativeMethods.vector_Vec4i_new1();
		}

		public VectorOfVec4i(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_Vec4i_new2(new IntPtr(size));
		}

		public VectorOfVec4i(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		public VectorOfVec4i(IEnumerable<Vec4i> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			Vec4i[] array = Util.ToArray(data);
			ptr = NativeMethods.vector_Vec4i_new3(array, new IntPtr(array.Length));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_Vec4i_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public Vec4i[] ToArray()
		{
			return ToArray<Vec4i>();
		}

		public T[] ToArray<T>() where T : struct
		{
			int num = Marshal.SizeOf(typeof(T));
			if (num != 16)
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
