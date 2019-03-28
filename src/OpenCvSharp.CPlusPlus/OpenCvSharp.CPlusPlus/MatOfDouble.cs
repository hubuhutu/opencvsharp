using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfDouble : Mat<double, MatOfDouble>
	{
		public new sealed class Indexer : MatIndexer<double>
		{
			private unsafe readonly byte* ptr;

			public unsafe override double this[int i0]
			{
				get
				{
					return *(double*)(ptr + steps[0] * i0);
				}
				set
				{
					*(double*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override double this[int i0, int i1]
			{
				get
				{
					return *(double*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(double*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override double this[int i0, int i1, int i2]
			{
				get
				{
					return *(double*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(double*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override double this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(double*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(double*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_64FC1;

		private const int ThisDepth = 6;

		private const int ThisChannels = 1;

		public MatOfDouble()
		{
		}

		public MatOfDouble(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfDouble(Mat mat)
			: base(mat)
		{
		}

		public MatOfDouble(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfDouble(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfDouble(int rows, int cols, double s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfDouble(Size size, double s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfDouble(MatOfDouble m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<double, MatOfDouble>)m, rowRange, colRange)
		{
		}

		public MatOfDouble(MatOfDouble m, params Range[] ranges)
			: base((Mat<double, MatOfDouble>)m, ranges)
		{
		}

		public MatOfDouble(MatOfDouble m, Rect roi)
			: base((Mat<double, MatOfDouble>)m, roi)
		{
		}

		public MatOfDouble(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfDouble(int rows, int cols, double[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfDouble(int rows, int cols, double[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfDouble(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfDouble(IEnumerable<int> sizes, double[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfDouble(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfDouble(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfDouble(IEnumerable<int> sizes, double s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfDouble(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfDouble(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<double> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfDouble FromArray(params double[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfDouble matOfDouble = new MatOfDouble(arr.Length / 1, 1);
			matOfDouble.SetArray(0, 0, arr);
			return matOfDouble;
		}

		public static MatOfDouble FromArray(double[,] arr)
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
			MatOfDouble matOfDouble = new MatOfDouble(length, length2);
			matOfDouble.SetArray(0, 0, arr);
			return matOfDouble;
		}

		public static MatOfDouble FromArray(IEnumerable<double> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override double[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new double[0];
			}
			double[] array = new double[num];
			GetArray(0, 0, array);
			return array;
		}

		public override double[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new double[0, 0];
			}
			double[,] array = new double[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<double> GetEnumerator()
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

		public override void Add(double value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_double(ptr, value);
		}
	}
}
