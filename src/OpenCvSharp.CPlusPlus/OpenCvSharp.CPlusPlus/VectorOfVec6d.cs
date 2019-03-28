using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfVec6d : DisposableCvObject, IStdVector<Vec6d>, IDisposable
	{
		private bool disposed;

		public int Size => NativeMethods.vector_Vec6d_getSize(ptr).ToInt32();

		public IntPtr ElemPtr => NativeMethods.vector_Vec6d_getPointer(ptr);

		public VectorOfVec6d()
		{
			ptr = NativeMethods.vector_Vec6d_new1();
		}

		public VectorOfVec6d(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_Vec6d_new2(new IntPtr(size));
		}

		public VectorOfVec6d(IEnumerable<Vec6d> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			Vec6d[] array = EnumerableEx.ToArray(data);
			ptr = NativeMethods.vector_Vec6d_new3(array, new IntPtr(array.Length));
		}

		public VectorOfVec6d(IntPtr p)
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
						NativeMethods.vector_Vec6d_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public Vec6d[] ToArray()
		{
			return ToArray<Vec6d>();
		}

		public T[] ToArray<T>() where T : struct
		{
			int num = Marshal.SizeOf(typeof(T));
			if (num != 48)
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
