using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public sealed class OutputArrayOfMatList : OutputArray
	{
		private bool disposed;

		private List<Mat> list;

		internal OutputArrayOfMatList(List<Mat> list)
			: base(list)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			this.list = list;
		}

		public override IEnumerable<Mat> GetVectorOfMat()
		{
			return list;
		}

		public override void AssignResult()
		{
			if (!IsReady())
			{
				throw new NotSupportedException();
			}
			using (VectorOfMat vectorOfMat = new VectorOfMat())
			{
				NativeMethods.core_OutputArray_getVectorOfMat(ptr, vectorOfMat.CvPtr);
				list.Clear();
				list.AddRange(vectorOfMat.ToArray());
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
