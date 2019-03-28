using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfByte3 : Mat<Vec3b, MatOfByte3>
	{
		public new sealed class Indexer : MatIndexer<Vec3b>
		{
			private unsafe readonly byte* ptr;

			public unsafe override Vec3b this[int i0]
			{
				get
				{
					return *(Vec3b*)(ptr + steps[0] * i0);
				}
				set
				{
					*(Vec3b*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override Vec3b this[int i0, int i1]
			{
				get
				{
					return *(Vec3b*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(Vec3b*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override Vec3b this[int i0, int i1, int i2]
			{
				get
				{
					return *(Vec3b*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(Vec3b*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override Vec3b this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(Vec3b*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Vec3b*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_8UC3;

		private const int ThisDepth = 0;

		private const int ThisChannels = 3;

		public MatOfByte3()
		{
		}

		public MatOfByte3(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfByte3(Mat mat)
			: base(mat)
		{
		}

		public MatOfByte3(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfByte3(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfByte3(int rows, int cols, Vec3b s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfByte3(Size size, Vec3b s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfByte3(MatOfByte3 m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<Vec3b, MatOfByte3>)m, rowRange, colRange)
		{
		}

		public MatOfByte3(MatOfByte3 m, params Range[] ranges)
			: base((Mat<Vec3b, MatOfByte3>)m, ranges)
		{
		}

		public MatOfByte3(MatOfByte3 m, Rect roi)
			: base((Mat<Vec3b, MatOfByte3>)m, roi)
		{
		}

		public MatOfByte3(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfByte3(int rows, int cols, Vec3b[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfByte3(int rows, int cols, Vec3b[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfByte3(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfByte3(IEnumerable<int> sizes, Vec3b[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfByte3(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfByte3(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfByte3(IEnumerable<int> sizes, Vec3b s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfByte3(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfByte3(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<Vec3b> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfByte3 FromArray(params Vec3b[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfByte3 matOfByte = new MatOfByte3(arr.Length, 1);
			matOfByte.SetArray(0, 0, arr);
			return matOfByte;
		}

		public static MatOfByte3 FromArray(Vec3b[,] arr)
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
			MatOfByte3 matOfByte = new MatOfByte3(length, length2);
			matOfByte.SetArray(0, 0, arr);
			return matOfByte;
		}

		public static MatOfByte3 FromArray(IEnumerable<Vec3b> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override Vec3b[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new Vec3b[0];
			}
			Vec3b[] array = new Vec3b[num];
			GetArray(0, 0, array);
			return array;
		}

		public byte[] ToPrimitiveArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new byte[0];
			}
			byte[] array = new byte[num * 3];
			GetArray(0, 0, array);
			return array;
		}

		public override Vec3b[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new Vec3b[0, 0];
			}
			Vec3b[,] array = new Vec3b[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<Vec3b> GetEnumerator()
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

		public override void Add(Vec3b value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Vec3b(ptr, value);
		}
	}
}
