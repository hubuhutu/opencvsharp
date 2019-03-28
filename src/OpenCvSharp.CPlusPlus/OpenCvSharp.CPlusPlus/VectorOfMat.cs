using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfMat : DisposableCvObject, IStdVector<Mat>, IDisposable
	{
		private bool disposed;

		public int Size => NativeMethods.vector_Mat_getSize(ptr).ToInt32();

		public IntPtr ElemPtr => NativeMethods.vector_Mat_getPointer(ptr);

		public VectorOfMat()
		{
			ptr = NativeMethods.vector_Mat_new1();
		}

		public VectorOfMat(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_Mat_new2(new IntPtr(size));
		}

		public VectorOfMat(IEnumerable<Mat> mats)
		{
			if (mats == null)
			{
				throw new ArgumentNullException("mats");
			}
			IntPtr[] array = EnumerableEx.SelectPtrs(mats);
			using (ArrayAddress1<IntPtr> arrayAddress = new ArrayAddress1<IntPtr>(array))
			{
				ptr = NativeMethods.vector_Mat_new3(arrayAddress.Pointer, new IntPtr(array.Length));
			}
		}

		public VectorOfMat(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_Mat_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public Mat[] ToArray()
		{
			return ToArray<Mat>();
		}

		public T[] ToArray<T>() where T : Mat, new()
		{
			int size = Size;
			if (size == 0)
			{
				return new T[0];
			}
			T[] array = new T[size];
			IntPtr[] array2 = new IntPtr[size];
			for (int i = 0; i < size; i++)
			{
				array2[i] = (array[i] = new T()).CvPtr;
			}
			NativeMethods.vector_Mat_assignToArray(ptr, array2);
			return array;
		}

		public void AddRef()
		{
			NativeMethods.vector_Mat_addref(ptr);
		}
	}
}
