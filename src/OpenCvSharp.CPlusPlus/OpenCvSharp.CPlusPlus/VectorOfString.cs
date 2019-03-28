using System;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfString : DisposableCvObject, IStdVector<string>, IDisposable
	{
		private bool disposed;

		public int Size => NativeMethods.vector_string_getSize(ptr).ToInt32();

		public IntPtr ElemPtr => NativeMethods.vector_string_getPointer(ptr);

		public VectorOfString()
		{
			ptr = NativeMethods.vector_string_new1();
		}

		public VectorOfString(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		public VectorOfString(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_string_new2(new IntPtr(size));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_string_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public unsafe string[] ToArray()
		{
			int size = Size;
			if (size == 0)
			{
				return new string[0];
			}
			string[] array = new string[size];
			for (int i = 0; i < size; i++)
			{
				sbyte* value = NativeMethods.vector_string_elemAt(ptr, i);
				array[i] = new string(value);
			}
			return array;
		}
	}
}
