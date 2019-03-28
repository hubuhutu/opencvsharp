using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfByte : DisposableCvObject, IStdVector<byte>, IDisposable
	{
		private bool disposed;

		public int Size => NativeMethods.vector_uchar_getSize(ptr).ToInt32();

		public IntPtr ElemPtr => NativeMethods.vector_uchar_getPointer(ptr);

		public VectorOfByte()
		{
			ptr = NativeMethods.vector_uchar_new1();
		}

		public VectorOfByte(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_uchar_new2(new IntPtr(size));
		}

		public VectorOfByte(IEnumerable<byte> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			byte[] array = Util.ToArray(data);
			ptr = NativeMethods.vector_uchar_new3(array, new IntPtr(array.Length));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_uchar_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public byte[] ToArray()
		{
			int size = Size;
			if (size == 0)
			{
				return new byte[0];
			}
			byte[] array = new byte[size];
			Marshal.Copy(ElemPtr, array, 0, array.Length);
			return array;
		}
	}
}
