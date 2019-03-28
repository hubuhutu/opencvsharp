using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfDMatch : DisposableCvObject, IStdVector<DMatch>, IDisposable
	{
		private bool disposed;

		public int Size => NativeMethods.vector_DMatch_getSize(ptr).ToInt32();

		public IntPtr ElemPtr => NativeMethods.vector_DMatch_getPointer(ptr);

		public VectorOfDMatch()
		{
			ptr = NativeMethods.vector_DMatch_new1();
		}

		public VectorOfDMatch(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		public VectorOfDMatch(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_DMatch_new2(new IntPtr(size));
		}

		public VectorOfDMatch(IEnumerable<DMatch> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			DMatch[] array = EnumerableEx.ToArray(data);
			ptr = NativeMethods.vector_DMatch_new3(array, new IntPtr(array.Length));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_DMatch_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public DMatch[] ToArray()
		{
			int size = Size;
			if (size == 0)
			{
				return new DMatch[0];
			}
			DMatch[] array = new DMatch[size];
			using (ArrayAddress1<DMatch> self = new ArrayAddress1<DMatch>(array))
			{
				Util.CopyMemory(self, ElemPtr, Marshal.SizeOf(typeof(DMatch)) * array.Length);
				return array;
			}
		}
	}
}
