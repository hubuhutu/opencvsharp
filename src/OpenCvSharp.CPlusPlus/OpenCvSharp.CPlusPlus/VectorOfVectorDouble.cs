using OpenCvSharp.Utilities;
using System;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfVectorDouble : DisposableCvObject, IStdVector<double[]>, IDisposable
	{
		private bool disposed;

		public int Size1 {get{return NativeMethods.vector_vector_double_getSize1(ptr).ToInt32();}}

		public int Size {get{return Size1;}}

		public long[] Size2
		{
			get
			{
				int size = Size1;
				IntPtr[] array = new IntPtr[size];
				NativeMethods.vector_vector_double_getSize2(ptr, array);
				long[] array2 = new long[size];
				for (int i = 0; i < size; i++)
				{
					array2[i] = array[i].ToInt64();
				}
				return array2;
			}
		}

        public IntPtr ElemPtr { get { return NativeMethods.vector_vector_double_getPointer(ptr); } }

		public VectorOfVectorDouble()
		{
			ptr = NativeMethods.vector_vector_double_new1();
		}

		public VectorOfVectorDouble(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_vector_double_new2(new IntPtr(size));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_vector_double_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public double[][] ToArray()
		{
			int size = Size1;
			if (size == 0)
			{
				return new double[0][];
			}
			long[] size2 = Size2;
			double[][] array = new double[size][];
			for (int i = 0; i < size; i++)
			{
				array[i] = new double[size2[i]];
			}
			using (ArrayAddress2<double> self = new ArrayAddress2<double>(array))
			{
				NativeMethods.vector_vector_double_copy(ptr, self);
				return array;
			}
		}
	}
}
