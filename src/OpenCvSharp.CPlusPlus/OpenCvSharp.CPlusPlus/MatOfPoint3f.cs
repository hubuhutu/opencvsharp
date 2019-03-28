using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfPoint3f : Mat<Point3f, MatOfPoint3f>
	{
		public new sealed class Indexer : MatIndexer<Point3f>
		{
			private unsafe readonly byte* ptr;

			public unsafe override Point3f this[int i0]
			{
				get
				{
					return *(Point3f*)(ptr + steps[0] * i0);
				}
				set
				{
					*(Point3f*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override Point3f this[int i0, int i1]
			{
				get
				{
					return *(Point3f*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(Point3f*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override Point3f this[int i0, int i1, int i2]
			{
				get
				{
					return *(Point3f*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(Point3f*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override Point3f this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(Point3f*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Point3f*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_32FC3;

		private const int ThisDepth = 5;

		private const int ThisChannels = 3;

		public MatOfPoint3f()
		{
		}

		public MatOfPoint3f(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfPoint3f(Mat mat)
			: base(mat)
		{
		}

		public MatOfPoint3f(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfPoint3f(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfPoint3f(int rows, int cols, Point3f s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint3f(Size size, Point3f s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint3f(MatOfPoint3f m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<Point3f, MatOfPoint3f>)m, rowRange, colRange)
		{
		}

		public MatOfPoint3f(MatOfPoint3f m, params Range[] ranges)
			: base((Mat<Point3f, MatOfPoint3f>)m, ranges)
		{
		}

		public MatOfPoint3f(MatOfPoint3f m, Rect roi)
			: base((Mat<Point3f, MatOfPoint3f>)m, roi)
		{
		}

		public MatOfPoint3f(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfPoint3f(int rows, int cols, Point3f[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfPoint3f(int rows, int cols, Point3f[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfPoint3f(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfPoint3f(IEnumerable<int> sizes, Point3f[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfPoint3f(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfPoint3f(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfPoint3f(IEnumerable<int> sizes, Point3f s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfPoint3f(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfPoint3f(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<Point3f> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfPoint3f FromArray(params Point3f[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfPoint3f matOfPoint3f = new MatOfPoint3f(arr.Length, 1);
			matOfPoint3f.SetArray(0, 0, arr);
			return matOfPoint3f;
		}

		public static MatOfPoint3f FromArray(Point3f[,] arr)
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
			MatOfPoint3f matOfPoint3f = new MatOfPoint3f(length, length2);
			matOfPoint3f.SetArray(0, 0, arr);
			return matOfPoint3f;
		}

		public static MatOfPoint3f FromArray(IEnumerable<Point3f> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override Point3f[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new Point3f[0];
			}
			Point3f[] array = new Point3f[num];
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
			float[] array = new float[num * 3];
			GetArray(0, 0, array);
			return array;
		}

		public override Point3f[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new Point3f[0, 0];
			}
			Point3f[,] array = new Point3f[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<Point3f> GetEnumerator()
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

		public override void Add(Point3f value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Point3f(ptr, value);
		}
	}
}
