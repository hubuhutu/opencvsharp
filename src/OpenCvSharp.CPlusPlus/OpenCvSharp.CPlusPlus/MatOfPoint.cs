using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfPoint : Mat<Point, MatOfPoint>
	{
		public new sealed class Indexer : MatIndexer<Point>
		{
			private unsafe readonly byte* ptr;

			public unsafe override Point this[int i0]
			{
				get
				{
					return *(Point*)(ptr + steps[0] * i0);
				}
				set
				{
					*(Point*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override Point this[int i0, int i1]
			{
				get
				{
					return *(Point*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(Point*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override Point this[int i0, int i1, int i2]
			{
				get
				{
					return *(Point*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(Point*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override Point this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(Point*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Point*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_32SC2;

		private const int ThisDepth = 4;

		private const int ThisChannels = 2;

		public MatOfPoint()
		{
		}

		public MatOfPoint(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfPoint(Mat mat)
			: base(mat)
		{
		}

		public MatOfPoint(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfPoint(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfPoint(int rows, int cols, Point s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint(Size size, Point s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint(MatOfPoint m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<Point, MatOfPoint>)m, rowRange, colRange)
		{
		}

		public MatOfPoint(MatOfPoint m, params Range[] ranges)
			: base((Mat<Point, MatOfPoint>)m, ranges)
		{
		}

		public MatOfPoint(MatOfPoint m, Rect roi)
			: base((Mat<Point, MatOfPoint>)m, roi)
		{
		}

		public MatOfPoint(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfPoint(int rows, int cols, Point[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfPoint(int rows, int cols, Point[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfPoint(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfPoint(IEnumerable<int> sizes, Point[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfPoint(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfPoint(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfPoint(IEnumerable<int> sizes, Point s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfPoint(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<Point> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfPoint FromArray(params Point[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfPoint matOfPoint = new MatOfPoint(arr.Length, 1);
			matOfPoint.SetArray(0, 0, arr);
			return matOfPoint;
		}

		public static MatOfPoint FromArray(Point[,] arr)
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
			MatOfPoint matOfPoint = new MatOfPoint(length, length2);
			matOfPoint.SetArray(0, 0, arr);
			return matOfPoint;
		}

		public static MatOfPoint FromArray(IEnumerable<Point> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override Point[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new Point[0];
			}
			Point[] array = new Point[num];
			GetArray(0, 0, array);
			return array;
		}

		public int[] ToPrimitiveArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new int[0];
			}
			int[] array = new int[num * 2];
			GetArray(0, 0, array);
			return array;
		}

		public override Point[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new Point[0, 0];
			}
			Point[,] array = new Point[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<Point> GetEnumerator()
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

		public override void Add(Point value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Point(ptr, value);
		}
	}
}
