using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfFloat4 : Mat<Vec4f, MatOfFloat4>
	{
		public new sealed class Indexer : MatIndexer<Vec4f>
		{
			private unsafe readonly byte* ptr;

			public unsafe override Vec4f this[int i0]
			{
				get
				{
					return *(Vec4f*)(ptr + steps[0] * i0);
				}
				set
				{
					*(Vec4f*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override Vec4f this[int i0, int i1]
			{
				get
				{
					return *(Vec4f*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(Vec4f*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override Vec4f this[int i0, int i1, int i2]
			{
				get
				{
					return *(Vec4f*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(Vec4f*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override Vec4f this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(Vec4f*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Vec4f*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_32FC4;

		private const int ThisDepth = 5;

		private const int ThisChannels = 4;

		public MatOfFloat4()
		{
		}

		public MatOfFloat4(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfFloat4(Mat mat)
			: base(mat)
		{
		}

		public MatOfFloat4(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfFloat4(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfFloat4(int rows, int cols, Vec4f s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfFloat4(Size size, Vec4f s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfFloat4(MatOfFloat4 m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<Vec4f, MatOfFloat4>)m, rowRange, colRange)
		{
		}

		public MatOfFloat4(MatOfFloat4 m, params Range[] ranges)
			: base((Mat<Vec4f, MatOfFloat4>)m, ranges)
		{
		}

		public MatOfFloat4(MatOfFloat4 m, Rect roi)
			: base((Mat<Vec4f, MatOfFloat4>)m, roi)
		{
		}

		public MatOfFloat4(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfFloat4(int rows, int cols, Vec4f[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfFloat4(int rows, int cols, Vec4f[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfFloat4(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfFloat4(IEnumerable<int> sizes, Vec4f[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfFloat4(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfFloat4(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfFloat4(IEnumerable<int> sizes, Vec4f s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfFloat4(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfFloat4(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<Vec4f> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfFloat4 FromArray(params Vec4f[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfFloat4 matOfFloat = new MatOfFloat4(arr.Length, 1);
			matOfFloat.SetArray(0, 0, arr);
			return matOfFloat;
		}

		public static MatOfFloat4 FromArray(Vec4f[,] arr)
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
			MatOfFloat4 matOfFloat = new MatOfFloat4(length, length2);
			matOfFloat.SetArray(0, 0, arr);
			return matOfFloat;
		}

		public static MatOfFloat4 FromArray(IEnumerable<Vec4f> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override Vec4f[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new Vec4f[0];
			}
			Vec4f[] array = new Vec4f[num];
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
			float[] array = new float[num * 4];
			GetArray(0, 0, array);
			return array;
		}

		public override Vec4f[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new Vec4f[0, 0];
			}
			Vec4f[,] array = new Vec4f[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<Vec4f> GetEnumerator()
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

		public override void Add(Vec4f value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Vec4f(ptr, value);
		}
	}
}
