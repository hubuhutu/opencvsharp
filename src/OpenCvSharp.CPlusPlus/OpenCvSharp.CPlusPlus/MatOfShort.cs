using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfShort : Mat<short, MatOfShort>
	{
		public new sealed class Indexer : MatIndexer<short>
		{
			private unsafe readonly byte* ptr;

			public unsafe override short this[int i0]
			{
				get
				{
					return *(short*)(ptr + steps[0] * i0);
				}
				set
				{
					*(short*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override short this[int i0, int i1]
			{
				get
				{
					return *(short*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(short*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override short this[int i0, int i1, int i2]
			{
				get
				{
					return *(short*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(short*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override short this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(short*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(short*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_16SC1;

		private const int ThisDepth = 3;

		private const int ThisChannels = 1;

		public MatOfShort()
		{
		}

		public MatOfShort(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfShort(Mat mat)
			: base(mat)
		{
		}

		public MatOfShort(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfShort(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfShort(int rows, int cols, short s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfShort(Size size, short s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfShort(MatOfShort m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<short, MatOfShort>)m, rowRange, colRange)
		{
		}

		public MatOfShort(MatOfShort m, params Range[] ranges)
			: base((Mat<short, MatOfShort>)m, ranges)
		{
		}

		public MatOfShort(MatOfShort m, Rect roi)
			: base((Mat<short, MatOfShort>)m, roi)
		{
		}

		public MatOfShort(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfShort(int rows, int cols, short[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfShort(int rows, int cols, short[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfShort(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfShort(IEnumerable<int> sizes, short[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfShort(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfShort(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfShort(IEnumerable<int> sizes, short s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfShort(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfShort(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<short> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfShort FromArray(params short[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfShort matOfShort = new MatOfShort(arr.Length / 1, 1);
			matOfShort.SetArray(0, 0, arr);
			return matOfShort;
		}

		public static MatOfShort FromArray(short[,] arr)
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
			MatOfShort matOfShort = new MatOfShort(length, length2);
			matOfShort.SetArray(0, 0, arr);
			return matOfShort;
		}

		public static MatOfShort FromArray(IEnumerable<short> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override short[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new short[0];
			}
			short[] array = new short[num];
			GetArray(0, 0, array);
			return array;
		}

		public override short[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new short[0, 0];
			}
			short[,] array = new short[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<short> GetEnumerator()
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

		public override void Add(short value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_short(ptr, value);
		}
	}
}
