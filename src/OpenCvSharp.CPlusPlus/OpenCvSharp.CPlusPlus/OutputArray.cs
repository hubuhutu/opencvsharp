using OpenCvSharp.CPlusPlus.Gpu;
using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class OutputArray : DisposableCvObject
	{
		private bool disposed;

		private readonly object obj;

		internal OutputArray(Mat mat)
		{
			if (mat == null)
			{
				throw new ArgumentNullException("mat");
			}
			ptr = NativeMethods.core_OutputArray_new_byMat(mat.CvPtr);
			obj = mat;
		}

		internal OutputArray(GpuMat mat)
		{
			if (mat == null)
			{
				throw new ArgumentNullException("mat");
			}
			ptr = NativeMethods.core_OutputArray_new_byGpuMat(mat.CvPtr);
			obj = mat;
		}

		internal OutputArray(IEnumerable<Mat> mat)
		{
			if (mat == null)
			{
				throw new ArgumentNullException("mat");
			}
			using (VectorOfMat vectorOfMat = new VectorOfMat(mat))
			{
				ptr = NativeMethods.core_OutputArray_new_byVectorOfMat(vectorOfMat.CvPtr);
			}
			obj = mat;
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (ptr != IntPtr.Zero)
					{
						NativeMethods.core_OutputArray_delete(ptr);
						ptr = IntPtr.Zero;
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static implicit operator OutputArray(Mat mat)
		{
			return new OutputArray(mat);
		}

		public static implicit operator OutputArray(GpuMat mat)
		{
			return new OutputArray(mat);
		}

		public bool IsMat()
		{
			return obj is Mat;
		}

		public virtual Mat GetMat()
		{
			return obj as Mat;
		}

		public bool IsGpuMat()
		{
			return obj is GpuMat;
		}

		public virtual Mat GetGpuMat()
		{
			return obj as GpuMat;
		}

		public bool IsVectorOfMat()
		{
			return obj is IEnumerable<Mat>;
		}

		public virtual IEnumerable<Mat> GetVectorOfMat()
		{
			return obj as IEnumerable<Mat>;
		}

		public virtual void AssignResult()
		{
			if (!IsReady())
			{
				throw new NotSupportedException();
			}
			if (!IsMat() && !IsGpuMat())
			{
				throw new OpenCvSharpException("Not supported OutputArray-compatible type");
			}
		}

		public void Fix()
		{
			AssignResult();
			Dispose();
		}

		public bool IsReady()
		{
			if (ptr != IntPtr.Zero && !disposed && obj != null)
			{
				if (!IsMat())
				{
					return IsGpuMat();
				}
				return true;
			}
			return false;
		}

		public void ThrowIfNotReady()
		{
			if (!IsReady())
			{
				throw new OpenCvSharpException("Invalid OutputArray");
			}
		}

		public static OutputArray Create(Mat mat)
		{
			return new OutputArray(mat);
		}

		public static OutputArray Create(GpuMat mat)
		{
			return new OutputArray(mat);
		}

		public static OutputArrayOfStructList<T> Create<T>(List<T> list) where T : struct
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			return new OutputArrayOfStructList<T>(list);
		}

		public static OutputArrayOfMatList Create(List<Mat> list)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			return new OutputArrayOfMatList(list);
		}
	}
}
