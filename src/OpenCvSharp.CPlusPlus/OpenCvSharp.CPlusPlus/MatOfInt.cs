using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfInt : Mat<int, MatOfInt>
	{
		public new sealed class Indexer : MatIndexer<int>
		{
			private unsafe readonly byte* ptr;

			public unsafe override int this[int i0]
			{
				get
				{
					return *(int*)(ptr + steps[0] * i0);
				}
				set
				{
					*(int*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override int this[int i0, int i1]
			{
				get
				{
					return *(int*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(int*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override int this[int i0, int i1, int i2]
			{
				get
				{
					return *(int*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(int*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override int this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(int*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(int*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_32SC1;

		private const int ThisDepth = 4;

		private const int ThisChannels = 1;

		public MatOfInt()
		{
		}

		public MatOfInt(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfInt(Mat mat)
			: base(mat)
		{
		}

		public MatOfInt(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfInt(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfInt(int rows, int cols, int s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfInt(Size size, int s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfInt(MatOfInt m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<int, MatOfInt>)m, rowRange, colRange)
		{
		}

		public MatOfInt(MatOfInt m, params Range[] ranges)
			: base((Mat<int, MatOfInt>)m, ranges)
		{
		}

		public MatOfInt(MatOfInt m, Rect roi)
			: base((Mat<int, MatOfInt>)m, roi)
		{
		}

		public MatOfInt(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfInt(int rows, int cols, int[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfInt(int rows, int cols, int[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfInt(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfInt(IEnumerable<int> sizes, int[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfInt(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfInt(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfInt(IEnumerable<int> sizes, int s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfInt(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfInt(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<int> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfInt FromArray(params int[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfInt matOfInt = new MatOfInt(arr.Length / 1, 1);
			matOfInt.SetArray(0, 0, arr);
			return matOfInt;
		}

		public static MatOfInt FromArray(int[,] arr)
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
			MatOfInt matOfInt = new MatOfInt(length, length2);
			matOfInt.SetArray(0, 0, arr);
			return matOfInt;
		}

		public static MatOfInt FromArray(IEnumerable<int> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override int[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new int[0];
			}
			int[] array = new int[num];
			GetArray(0, 0, array);
			return array;
		}

		public override int[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new int[0, 0];
			}
			int[,] array = new int[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<int> GetEnumerator()
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

		public override void Add(int value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_int(ptr, value);
		}
	}
}
