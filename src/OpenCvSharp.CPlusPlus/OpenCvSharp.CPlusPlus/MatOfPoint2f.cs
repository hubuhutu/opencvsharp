using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfPoint2f : Mat<Point2f, MatOfPoint2f>
	{
		public new sealed class Indexer : MatIndexer<Point2f>
		{
			private unsafe readonly byte* ptr;

			public unsafe override Point2f this[int i0]
			{
				get
				{
					return *(Point2f*)(ptr + steps[0] * i0);
				}
				set
				{
					*(Point2f*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override Point2f this[int i0, int i1]
			{
				get
				{
					return *(Point2f*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(Point2f*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override Point2f this[int i0, int i1, int i2]
			{
				get
				{
					return *(Point2f*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(Point2f*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override Point2f this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(Point2f*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Point2f*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_32FC2;

		private const int ThisDepth = 5;

		private const int ThisChannels = 2;

		public MatOfPoint2f()
		{
		}

		public MatOfPoint2f(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfPoint2f(Mat mat)
			: base(mat)
		{
		}

		public MatOfPoint2f(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfPoint2f(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfPoint2f(int rows, int cols, Point2f s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint2f(Size size, Point2f s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint2f(MatOfPoint2f m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<Point2f, MatOfPoint2f>)m, rowRange, colRange)
		{
		}

		public MatOfPoint2f(MatOfPoint2f m, params Range[] ranges)
			: base((Mat<Point2f, MatOfPoint2f>)m, ranges)
		{
		}

		public MatOfPoint2f(MatOfPoint2f m, Rect roi)
			: base((Mat<Point2f, MatOfPoint2f>)m, roi)
		{
		}

		public MatOfPoint2f(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfPoint2f(int rows, int cols, Point2f[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfPoint2f(int rows, int cols, Point2f[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfPoint2f(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfPoint2f(IEnumerable<int> sizes, Point2f[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfPoint2f(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfPoint2f(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfPoint2f(IEnumerable<int> sizes, Point2f s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint2f(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfPoint2f(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<Point2f> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfPoint2f FromArray(params Point2f[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfPoint2f matOfPoint2f = new MatOfPoint2f(arr.Length, 1);
			matOfPoint2f.SetArray(0, 0, arr);
			return matOfPoint2f;
		}

		public static MatOfPoint2f FromArray(Point2f[,] arr)
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
			MatOfPoint2f matOfPoint2f = new MatOfPoint2f(length, length2);
			matOfPoint2f.SetArray(0, 0, arr);
			return matOfPoint2f;
		}

		public static MatOfPoint2f FromArray(IEnumerable<Point2f> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override Point2f[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new Point2f[0];
			}
			Point2f[] array = new Point2f[num];
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
			float[] array = new float[num * 2];
			GetArray(0, 0, array);
			return array;
		}

		public override Point2f[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new Point2f[0, 0];
			}
			Point2f[,] array = new Point2f[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<Point2f> GetEnumerator()
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

		public override void Add(Point2f value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Point2f(ptr, value);
		}
	}
}
