using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfFloat6 : Mat<Vec6f, MatOfFloat6>
	{
		public new sealed class Indexer : MatIndexer<Vec6f>
		{
			private unsafe readonly byte* ptr;

			public unsafe override Vec6f this[int i0]
			{
				get
				{
					return *(Vec6f*)(ptr + steps[0] * i0);
				}
				set
				{
					*(Vec6f*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override Vec6f this[int i0, int i1]
			{
				get
				{
					return *(Vec6f*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(Vec6f*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override Vec6f this[int i0, int i1, int i2]
			{
				get
				{
					return *(Vec6f*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(Vec6f*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override Vec6f this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(Vec6f*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Vec6f*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_32FC(6);

		private const int ThisDepth = 5;

		private const int ThisChannels = 6;

		public MatOfFloat6()
		{
		}

		public MatOfFloat6(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfFloat6(Mat mat)
			: base(mat)
		{
		}

		public MatOfFloat6(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfFloat6(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfFloat6(int rows, int cols, Vec6f s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfFloat6(Size size, Vec6f s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfFloat6(MatOfFloat6 m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<Vec6f, MatOfFloat6>)m, rowRange, colRange)
		{
		}

		public MatOfFloat6(MatOfFloat6 m, params Range[] ranges)
			: base((Mat<Vec6f, MatOfFloat6>)m, ranges)
		{
		}

		public MatOfFloat6(MatOfFloat6 m, Rect roi)
			: base((Mat<Vec6f, MatOfFloat6>)m, roi)
		{
		}

		public MatOfFloat6(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfFloat6(int rows, int cols, Vec6f[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfFloat6(int rows, int cols, Vec6f[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfFloat6(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfFloat6(IEnumerable<int> sizes, Vec6f[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfFloat6(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfFloat6(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfFloat6(IEnumerable<int> sizes, Vec6f s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfFloat6(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfFloat6(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<Vec6f> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfFloat6 FromArray(params Vec6f[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfFloat6 matOfFloat = new MatOfFloat6(arr.Length, 1);
			matOfFloat.SetArray(0, 0, arr);
			return matOfFloat;
		}

		public static MatOfFloat6 FromArray(Vec6f[,] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			int length = arr.GetLength(0);
			int length2 = arr.GetLength(1);
			MatOfFloat6 matOfFloat = new MatOfFloat6(length, length2);
			matOfFloat.SetArray(0, 0, arr);
			return matOfFloat;
		}

		public static MatOfFloat6 FromArray(IEnumerable<Vec6f> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override Vec6f[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new Vec6f[0];
			}
			Vec6f[] array = new Vec6f[num];
			GetArray(0, 0, array);
			return array;
		}

		public float[] ToPrimitiveArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new float[0];
			}
			float[] array = new float[num * 6];
			GetArray(0, 0, array);
			return array;
		}

		public override Vec6f[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new Vec6f[0, 0];
			}
			Vec6f[,] array = new Vec6f[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<Vec6f> GetEnumerator()
		{
			ThrowIfDisposed();
			Indexer indexer = new Indexer(this);
			if (Dims() == 2)
			{
				int rows = Rows;
				int cols = Cols;
				for (int r = 0; r < rows; r++)
				{
					for (int c = 0; c < cols; c++)
					{
						yield return indexer[r, c];
					}
				}
				yield break;
			}
			throw new NotImplementedException("GetEnumerator supports only 2-dimensional Mat");
		}

		public override void Add(Vec6f value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Vec6f(ptr, value);
		}
	}
}
