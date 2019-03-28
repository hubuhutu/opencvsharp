using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfPoint2d : Mat<Point2d, MatOfPoint2d>
	{
		public new sealed class Indexer : MatIndexer<Point2d>
		{
			private unsafe readonly byte* ptr;

			public unsafe override Point2d this[int i0]
			{
				get
				{
					return *(Point2d*)(ptr + steps[0] * i0);
				}
				set
				{
					*(Point2d*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override Point2d this[int i0, int i1]
			{
				get
				{
					return *(Point2d*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(Point2d*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override Point2d this[int i0, int i1, int i2]
			{
				get
				{
					return *(Point2d*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(Point2d*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override Point2d this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(Point2d*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Point2d*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_64FC2;

		private const int ThisDepth = 6;

		private const int ThisChannels = 2;

		public MatOfPoint2d()
		{
		}

		public MatOfPoint2d(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfPoint2d(Mat mat)
			: base(mat)
		{
		}

		public MatOfPoint2d(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfPoint2d(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfPoint2d(int rows, int cols, Point2d s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint2d(Size size, Point2d s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint2d(MatOfPoint2d m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<Point2d, MatOfPoint2d>)m, rowRange, colRange)
		{
		}

		public MatOfPoint2d(MatOfPoint2d m, params Range[] ranges)
			: base((Mat<Point2d, MatOfPoint2d>)m, ranges)
		{
		}

		public MatOfPoint2d(MatOfPoint2d m, Rect roi)
			: base((Mat<Point2d, MatOfPoint2d>)m, roi)
		{
		}

		public MatOfPoint2d(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfPoint2d(int rows, int cols, Point2d[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfPoint2d(int rows, int cols, Point2d[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfPoint2d(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfPoint2d(IEnumerable<int> sizes, Point2d[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfPoint2d(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfPoint2d(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfPoint2d(IEnumerable<int> sizes, Point2d s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint2d(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfPoint2d(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<Point2d> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfPoint2d FromArray(params Point2d[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfPoint2d matOfPoint2d = new MatOfPoint2d(arr.Length, 1);
			matOfPoint2d.SetArray(0, 0, arr);
			return matOfPoint2d;
		}

		public static MatOfPoint2d FromArray(Point2d[,] arr)
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
			MatOfPoint2d matOfPoint2d = new MatOfPoint2d(length, length2);
			matOfPoint2d.SetArray(0, 0, arr);
			return matOfPoint2d;
		}

		public static MatOfPoint2d FromArray(IEnumerable<Point2d> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override Point2d[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new Point2d[0];
			}
			Point2d[] array = new Point2d[num];
			GetArray(0, 0, array);
			return array;
		}

		public double[] ToPrimitiveArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new double[0];
			}
			double[] array = new double[num * 2];
			GetArray(0, 0, array);
			return array;
		}

		public override Point2d[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new Point2d[0, 0];
			}
			Point2d[,] array = new Point2d[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<Point2d> GetEnumerator()
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

		public override void Add(Point2d value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Point2d(ptr, value);
		}
	}
}
