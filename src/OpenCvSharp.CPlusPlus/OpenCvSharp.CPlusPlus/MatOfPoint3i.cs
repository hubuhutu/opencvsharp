using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfPoint3i : Mat<Point3i, MatOfPoint3i>
	{
		public new sealed class Indexer : MatIndexer<Point3i>
		{
			private unsafe readonly byte* ptr;

			public unsafe override Point3i this[int i0]
			{
				get
				{
					return *(Point3i*)(ptr + steps[0] * i0);
				}
				set
				{
					*(Point3i*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override Point3i this[int i0, int i1]
			{
				get
				{
					return *(Point3i*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(Point3i*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override Point3i this[int i0, int i1, int i2]
			{
				get
				{
					return *(Point3i*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(Point3i*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override Point3i this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(Point3i*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Point3i*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_32SC3;

		private const int ThisDepth = 4;

		private const int ThisChannels = 3;

		public MatOfPoint3i()
		{
		}

		public MatOfPoint3i(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfPoint3i(Mat mat)
			: base(mat)
		{
		}

		public MatOfPoint3i(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfPoint3i(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfPoint3i(int rows, int cols, Point3i s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint3i(Size size, Point3i s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint3i(MatOfPoint3i m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<Point3i, MatOfPoint3i>)m, rowRange, colRange)
		{
		}

		public MatOfPoint3i(MatOfPoint3i m, params Range[] ranges)
			: base((Mat<Point3i, MatOfPoint3i>)m, ranges)
		{
		}

		public MatOfPoint3i(MatOfPoint3i m, Rect roi)
			: base((Mat<Point3i, MatOfPoint3i>)m, roi)
		{
		}

		public MatOfPoint3i(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfPoint3i(int rows, int cols, Point3i[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfPoint3i(int rows, int cols, Point3i[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfPoint3i(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfPoint3i(IEnumerable<int> sizes, Point3i[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfPoint3i(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfPoint3i(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfPoint3i(IEnumerable<int> sizes, Point3i s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint3i(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfPoint3i(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<Point3i> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfPoint3i FromArray(params Point3i[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfPoint3i matOfPoint3i = new MatOfPoint3i(arr.Length, 1);
			matOfPoint3i.SetArray(0, 0, arr);
			return matOfPoint3i;
		}

		public static MatOfPoint3i FromArray(Point3i[,] arr)
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
			MatOfPoint3i matOfPoint3i = new MatOfPoint3i(length, length2);
			matOfPoint3i.SetArray(0, 0, arr);
			return matOfPoint3i;
		}

		public static MatOfPoint3i FromArray(IEnumerable<Point3i> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override Point3i[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new Point3i[0];
			}
			Point3i[] array = new Point3i[num];
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
			int[] array = new int[num * 3];
			GetArray(0, 0, array);
			return array;
		}

		public override Point3i[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new Point3i[0, 0];
			}
			Point3i[,] array = new Point3i[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<Point3i> GetEnumerator()
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

		public override void Add(Point3i value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Point3i(ptr, value);
		}
	}
}
