using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfDouble : DisposableCvObject, IStdVector<double>, IDisposable
	{
		private bool disposed;

		public int Size {get{return NativeMethods.vector_double_getSize(ptr).ToInt32();
        }}

        public IntPtr ElemPtr { get { return NativeMethods.vector_double_getPointer(ptr); } }

		public VectorOfDouble()
		{
			ptr = NativeMethods.vector_double_new1();
		}

		public VectorOfDouble(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_double_new2(new IntPtr(size));
		}

		public VectorOfDouble(IEnumerable<double> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			double[] array = EnumerableEx.ToArray(data);
			ptr = NativeMethods.vector_double_new3(array, new IntPtr(array.Length));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_double_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public double[] ToArray()
		{
			int size = Size;
			if (size == 0)
			{
				return new double[0];
			}
			double[] array = new double[size];
			Marshal.Copy(ElemPtr, array, 0, array.Length);
			return array;
		}
	}
}
