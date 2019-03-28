using OpenCvSharp.Utilities;
using System;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfVectorKeyPoint : DisposableCvObject, IStdVector<KeyPoint[]>, IDisposable
	{
		private bool disposed;

		public int Size1 => NativeMethods.vector_vector_KeyPoint_getSize1(ptr).ToInt32();

		public int Size => Size1;

		public long[] Size2
		{
			get
			{
				int size = Size1;
				IntPtr[] array = new IntPtr[size];
				NativeMethods.vector_vector_KeyPoint_getSize2(ptr, array);
				long[] array2 = new long[size];
				for (int i = 0; i < size; i++)
				{
					array2[i] = array[i].ToInt64();
				}
				return array2;
			}
		}

		public IntPtr ElemPtr => NativeMethods.vector_vector_KeyPoint_getPointer(ptr);

		public VectorOfVectorKeyPoint()
		{
			ptr = NativeMethods.vector_vector_KeyPoint_new1();
		}

		public VectorOfVectorKeyPoint(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_vector_KeyPoint_new2(new IntPtr(size));
		}

		public VectorOfVectorKeyPoint(KeyPoint[][] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			using (ArrayAddress2<KeyPoint> arrayAddress = new ArrayAddress2<KeyPoint>(values))
			{
				ptr = NativeMethods.vector_vector_KeyPoint_new3(arrayAddress.Pointer, arrayAddress.Dim1Length, arrayAddress.Dim2Lengths);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_vector_KeyPoint_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public KeyPoint[][] ToArray()
		{
			int size = Size1;
			if (size == 0)
			{
				return new KeyPoint[0][];
			}
			long[] size2 = Size2;
			KeyPoint[][] array = new KeyPoint[size][];
			for (int i = 0; i < size; i++)
			{
				array[i] = new KeyPoint[size2[i]];
			}
			using (ArrayAddress2<KeyPoint> self = new ArrayAddress2<KeyPoint>(array))
			{
				NativeMethods.vector_vector_KeyPoint_copy(ptr, self);
				return array;
			}
		}
	}
}
