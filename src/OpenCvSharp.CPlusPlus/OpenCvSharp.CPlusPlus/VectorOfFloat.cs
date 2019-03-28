using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfFloat : DisposableCvObject, IStdVector<float>, IDisposable
	{
		private bool disposed;

		public int Size => NativeMethods.vector_float_getSize(ptr).ToInt32();

		public IntPtr ElemPtr => NativeMethods.vector_float_getPointer(ptr);

		public VectorOfFloat()
		{
			ptr = NativeMethods.vector_float_new1();
		}

		public VectorOfFloat(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_float_new2(new IntPtr(size));
		}

		public VectorOfFloat(IEnumerable<float> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			float[] array = Util.ToArray(data);
			ptr = NativeMethods.vector_float_new3(array, new IntPtr(array.Length));
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

		public float[] ToArray()
		{
			int size = Size;
			if (size == 0)
			{
				return new float[0];
			}
			float[] array = new float[size];
			Marshal.Copy(ElemPtr, array, 0, array.Length);
			return array;
		}
	}
}
