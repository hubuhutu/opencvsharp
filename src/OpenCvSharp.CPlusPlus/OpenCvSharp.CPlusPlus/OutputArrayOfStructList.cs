using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	public sealed class OutputArrayOfStructList<T> : OutputArray where T : struct
	{
		private bool disposed;

		private List<T> list;

		internal OutputArrayOfStructList(List<T> list)
			: base(new Mat())
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			this.list = list;
		}

		public override void AssignResult()
		{
			if (!IsReady())
			{
				throw new NotSupportedException();
			}
			using (Mat mat = new Mat(NativeMethods.core_OutputArray_getMat(ptr)))
			{
				int num = mat.Rows * mat.Cols;
				T[] array = new T[num];
				using (ArrayAddress1<T> arrayAddress = new ArrayAddress1<T>(array))
				{
					int num2 = Marshal.SizeOf(typeof(T));
					Util.CopyMemory(arrayAddress.Pointer, mat.Data, num * num2);
				}
				list.Clear();
				list.AddRange(array);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				list = null;
				disposed = true;
				base.Dispose(disposing);
			}
		}
	}
}
