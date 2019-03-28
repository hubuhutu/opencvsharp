using OpenCvSharp.Utilities;
using System;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfVectorFloat : DisposableCvObject, IStdVector<float[]>, IDisposable
	{
		private bool disposed;

		public int Size1 => NativeMethods.vector_vector_float_getSize1(ptr).ToInt32();

		public int Size => Size1;

		public long[] Size2
		{
			get
			{
				int size = Size1;
				IntPtr[] array = new IntPtr[size];
				NativeMethods.vector_vector_float_getSize2(ptr, array);
				long[] array2 = new long[size];
				for (int i = 0; i < size; i++)
				{
					array2[i] = array[i].ToInt64();
				}
				return array2;
			}
		}

		public IntPtr ElemPtr => NativeMethods.vector_vector_float_getPointer(ptr);

		public VectorOfVectorFloat()
		{
			ptr = NativeMethods.vector_vector_float_new1();
		}

		public VectorOfVectorFloat(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_vector_float_new2(new IntPtr(size));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_vector_float_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public float[][] ToArray()
		{
			int size = Size1;
			if (size == 0)
			{
				return new float[0][];
			}
			long[] size2 = Size2;
			float[][] array = new float[size][];
			for (int i = 0; i < size; i++)
			{
				array[i] = new float[size2[i]];
			}
			using (ArrayAddress2<float> self = new ArrayAddress2<float>(array))
			{
				NativeMethods.vector_vector_float_copy(ptr, self);
				return array;
			}
		}
	}
}
