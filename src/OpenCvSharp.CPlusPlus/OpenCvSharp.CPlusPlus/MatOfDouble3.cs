using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfDouble3 : Mat<Vec3d, MatOfDouble3>
	{
		public new sealed class Indexer : MatIndexer<Vec3d>
		{
			private unsafe readonly byte* ptr;

			public unsafe override Vec3d this[int i0]
			{
				get
				{
					return *(Vec3d*)(ptr + steps[0] * i0);
				}
				set
				{
					*(Vec3d*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override Vec3d this[int i0, int i1]
			{
				get
				{
					return *(Vec3d*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(Vec3d*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override Vec3d this[int i0, int i1, int i2]
			{
				get
				{
					return *(Vec3d*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(Vec3d*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override Vec3d this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(Vec3d*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Vec3d*)(ptr + num) = value;
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

		public MatOfDouble3()
		{
		}

		public MatOfDouble3(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfDouble3(Mat mat)
			: base(mat)
		{
		}

		public MatOfDouble3(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfDouble3(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfDouble3(int rows, int cols, Vec3d s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfDouble3(Size size, Vec3d s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfDouble3(MatOfDouble3 m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<Vec3d, MatOfDouble3>)m, rowRange, colRange)
		{
		}

		public MatOfDouble3(MatOfDouble3 m, params Range[] ranges)
			: base((Mat<Vec3d, MatOfDouble3>)m, ranges)
		{
		}

		public MatOfDouble3(MatOfDouble3 m, Rect roi)
			: base((Mat<Vec3d, MatOfDouble3>)m, roi)
		{
		}

		public MatOfDouble3(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfDouble3(int rows, int cols, Vec3d[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfDouble3(int rows, int cols, Vec3d[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfDouble3(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfDouble3(IEnumerable<int> sizes, Vec3d[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfDouble3(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfDouble3(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfDouble3(IEnumerable<int> sizes, Vec3d s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfDouble3(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfDouble3(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<Vec3d> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfDouble3 FromArray(params Vec3d[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfDouble3 matOfDouble = new MatOfDouble3(arr.Length, 1);
			matOfDouble.SetArray(0, 0, arr);
			return matOfDouble;
		}

		public static MatOfDouble3 FromArray(Vec3d[,] arr)
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
			MatOfDouble3 matOfDouble = new MatOfDouble3(length, length2);
			matOfDouble.SetArray(0, 0, arr);
			return matOfDouble;
		}

		public static MatOfDouble3 FromArray(IEnumerable<Vec3d> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override Vec3d[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new Vec3d[0];
			}
			Vec3d[] array = new Vec3d[num];
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

		public override Vec3d[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new Vec3d[0, 0];
			}
			Vec3d[,] array = new Vec3d[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<Vec3d> GetEnumerator()
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

		public override void Add(Vec3d value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Vec3d(ptr, value);
		}
	}
}
