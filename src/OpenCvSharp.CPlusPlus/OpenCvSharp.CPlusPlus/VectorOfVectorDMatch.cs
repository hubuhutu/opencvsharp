using OpenCvSharp.Utilities;
using System;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfVectorDMatch : DisposableCvObject, IStdVector<DMatch[]>, IDisposable
	{
		private bool disposed;

		public int Size1 => NativeMethods.vector_vector_DMatch_getSize1(ptr).ToInt32();

		public int Size => Size1;

		public long[] Size2
		{
			get
			{
				int size = Size1;
				IntPtr[] array = new IntPtr[size];
				NativeMethods.vector_vector_DMatch_getSize2(ptr, array);
				long[] array2 = new long[size];
				for (int i = 0; i < size; i++)
				{
					array2[i] = array[i].ToInt64();
				}
				return array2;
			}
		}

		public IntPtr ElemPtr => NativeMethods.vector_vector_DMatch_getPointer(ptr);

		public VectorOfVectorDMatch()
		{
			ptr = NativeMethods.vector_vector_DMatch_new1();
		}

		public VectorOfVectorDMatch(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_vector_DMatch_new2(new IntPtr(size));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_vector_DMatch_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public DMatch[][] ToArray()
		{
			int size = Size1;
			if (size == 0)
			{
				return new DMatch[0][];
			}
			long[] size2 = Size2;
			DMatch[][] array = new DMatch[size][];
			for (int i = 0; i < size; i++)
			{
				array[i] = new DMatch[size2[i]];
			}
			using (ArrayAddress2<DMatch> self = new ArrayAddress2<DMatch>(array))
			{
				NativeMethods.vector_vector_DMatch_copy(ptr, self);
				return array;
			}
		}
	}
}
