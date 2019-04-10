using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	internal class VectorOfKeyPoint : DisposableCvObject, IStdVector<KeyPoint>, IDisposable
	{
		private bool disposed;

		public int Size {get{return NativeMethods.vector_KeyPoint_getSize(ptr).ToInt32();}}

        public IntPtr ElemPtr { get { return NativeMethods.vector_KeyPoint_getPointer(ptr); } }

		public VectorOfKeyPoint()
		{
			ptr = NativeMethods.vector_KeyPoint_new1();
		}

		public VectorOfKeyPoint(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		public VectorOfKeyPoint(int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			ptr = NativeMethods.vector_KeyPoint_new2(new IntPtr(size));
		}

		public VectorOfKeyPoint(IEnumerable<KeyPoint> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			KeyPoint[] array = Util.ToArray(data);
			ptr = NativeMethods.vector_KeyPoint_new3(array, new IntPtr(array.Length));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.vector_KeyPoint_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public KeyPoint[] ToArray()
		{
			int size = Size;
			if (size == 0)
			{
				return new KeyPoint[0];
			}
			KeyPoint[] array = new KeyPoint[size];
			using (ArrayAddress1<KeyPoint> self = new ArrayAddress1<KeyPoint>(array))
			{
				Util.CopyMemory(self, ElemPtr, Marshal.SizeOf(typeof(KeyPoint)) * array.Length);
				return array;
			}
		}
	}
}
