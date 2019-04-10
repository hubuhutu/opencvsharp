using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfVec2f : DisposableCvObject, IStdVector<Vec2f>, IDisposable
	{
		private bool disposed;

		public int Size {get{return NativeMethods.vector_Vec2f_getSize(ptr).ToInt32();}}

        public IntPtr ElemPtr { get { return NativeMethods.vector_Vec2f_getPointer(ptr); } }

		public VectorOfVec2f()
		{
			ptr = NativeMethods.vector_Vec2f_new1();
		}

		public VectorOfVec2f(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_Vec2f_new2(new IntPtr(size));
		}

		public VectorOfVec2f(IEnumerable<Vec2f> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			Vec2f[] array = Util.ToArray(data);
			ptr = NativeMethods.vector_Vec2f_new3(array, new IntPtr(array.Length));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_Vec2f_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public Vec2f[] ToArray()
		{
			return ToArray<Vec2f>();
		}

		public T[] ToArray<T>() where T : struct
		{
			int num = Marshal.SizeOf(typeof(T));
			if (num != 8)
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
