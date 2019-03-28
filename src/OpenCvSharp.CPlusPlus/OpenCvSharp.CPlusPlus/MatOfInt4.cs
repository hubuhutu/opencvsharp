using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfInt4 : Mat<Vec4i, MatOfInt4>
	{
		public new sealed class Indexer : MatIndexer<Vec4i>
		{
			private unsafe readonly byte* ptr;

			public unsafe override Vec4i this[int i0]
			{
				get
				{
					return *(Vec4i*)(ptr + steps[0] * i0);
				}
				set
				{
					*(Vec4i*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override Vec4i this[int i0, int i1]
			{
				get
				{
					return *(Vec4i*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(Vec4i*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override Vec4i this[int i0, int i1, int i2]
			{
				get
				{
					return *(Vec4i*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(Vec4i*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override Vec4i this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(Vec4i*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Vec4i*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_32SC4;

		private const int ThisDepth = 4;

		private const int ThisChannels = 4;

		public MatOfInt4()
		{
		}

		public MatOfInt4(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfInt4(Mat mat)
			: base(mat)
		{
		}

		public MatOfInt4(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfInt4(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfInt4(int rows, int cols, int s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfInt4(Size size, int s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfInt4(MatOfInt4 m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<Vec4i, MatOfInt4>)m, rowRange, colRange)
		{
		}

		public MatOfInt4(MatOfInt4 m, params Range[] ranges)
			: base((Mat<Vec4i, MatOfInt4>)m, ranges)
		{
		}

		public MatOfInt4(MatOfInt4 m, Rect roi)
			: base((Mat<Vec4i, MatOfInt4>)m, roi)
		{
		}

		public MatOfInt4(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfInt4(int rows, int cols, Vec4i[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfInt4(int rows, int cols, Vec4i[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfInt4(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfInt4(IEnumerable<int> sizes, Vec4i[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfInt4(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfInt4(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfInt4(IEnumerable<int> sizes, Vec4i s)
			: base(sizes, ThisType, new Scalar(s.Item0, s.Item1, s.Item2, s.Item3))
		{
		}

		public MatOfInt4(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfInt4(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<Vec4i> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfInt4 FromArray(params Vec4i[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfInt4 matOfInt = new MatOfInt4(arr.Length, 1);
			matOfInt.SetArray(0, 0, arr);
			return matOfInt;
		}

		public static MatOfInt4 FromArray(Vec4i[,] arr)
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
			MatOfInt4 matOfInt = new MatOfInt4(length, length2);
			matOfInt.SetArray(0, 0, arr);
			return matOfInt;
		}

		public static MatOfInt4 FromArray(IEnumerable<Vec4i> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override Vec4i[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new Vec4i[0];
			}
			Vec4i[] array = new Vec4i[num];
			GetArray(0, 0, array);
			return array;
		}

		public override Vec4i[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new Vec4i[0, 0];
			}
			Vec4i[,] array = new Vec4i[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<Vec4i> GetEnumerator()
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

		public override void Add(Vec4i value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Vec4i(ptr, value);
		}
	}
}
