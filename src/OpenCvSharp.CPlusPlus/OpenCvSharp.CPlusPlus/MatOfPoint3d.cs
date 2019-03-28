using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfPoint3d : Mat<Point3d, MatOfPoint3d>
	{
		public new sealed class Indexer : MatIndexer<Point3d>
		{
			private unsafe readonly byte* ptr;

			public unsafe override Point3d this[int i0]
			{
				get
				{
					return *(Point3d*)(ptr + steps[0] * i0);
				}
				set
				{
					*(Point3d*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override Point3d this[int i0, int i1]
			{
				get
				{
					return *(Point3d*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(Point3d*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override Point3d this[int i0, int i1, int i2]
			{
				get
				{
					return *(Point3d*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(Point3d*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override Point3d this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(Point3d*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Point3d*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_64FC3;

		private const int ThisDepth = 6;

		private const int ThisChannels = 3;

		public MatOfPoint3d()
		{
		}

		public MatOfPoint3d(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfPoint3d(Mat mat)
			: base(mat)
		{
		}

		public MatOfPoint3d(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfPoint3d(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfPoint3d(int rows, int cols, Point3d s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint3d(Size size, Point3d s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint3d(MatOfPoint3d m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<Point3d, MatOfPoint3d>)m, rowRange, colRange)
		{
		}

		public MatOfPoint3d(MatOfPoint3d m, params Range[] ranges)
			: base((Mat<Point3d, MatOfPoint3d>)m, ranges)
		{
		}

		public MatOfPoint3d(MatOfPoint3d m, Rect roi)
			: base((Mat<Point3d, MatOfPoint3d>)m, roi)
		{
		}

		public MatOfPoint3d(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfPoint3d(int rows, int cols, Point3d[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfPoint3d(int rows, int cols, Point3d[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfPoint3d(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfPoint3d(IEnumerable<int> sizes, Point3d[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfPoint3d(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfPoint3d(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfPoint3d(IEnumerable<int> sizes, Point3d s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint3d(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfPoint3d(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<Point3d> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfPoint3d FromArray(params Point3d[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfPoint3d matOfPoint3d = new MatOfPoint3d(arr.Length, 1);
			matOfPoint3d.SetArray(0, 0, arr);
			return matOfPoint3d;
		}

		public static MatOfPoint3d FromArray(Point3d[,] arr)
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
			MatOfPoint3d matOfPoint3d = new MatOfPoint3d(length, length2);
			matOfPoint3d.SetArray(0, 0, arr);
			return matOfPoint3d;
		}

		public static MatOfPoint3d FromArray(IEnumerable<Point3d> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override Point3d[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new Point3d[0];
			}
			Point3d[] array = new Point3d[num];
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
			double[] array = new double[num * 3];
			GetArray(0, 0, array);
			return array;
		}

		public override Point3d[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new Point3d[0, 0];
			}
			Point3d[,] array = new Point3d[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<Point3d> GetEnumerator()
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

		public override void Add(Point3d value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Point3d(ptr, value);
		}
	}
}
