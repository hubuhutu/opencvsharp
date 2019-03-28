using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfByte : Mat<byte, MatOfByte>
	{
		public new sealed class Indexer : MatIndexer<byte>
		{
			private unsafe readonly byte* ptr;

			public unsafe override byte this[int i0]
			{
				get
				{
					return ptr[steps[0] * i0];
				}
				set
				{
					ptr[steps[0] * i0] = value;
				}
			}

			public unsafe override byte this[int i0, int i1]
			{
				get
				{
					return (ptr + steps[0] * i0)[steps[1] * i1];
				}
				set
				{
					(ptr + steps[0] * i0)[steps[1] * i1] = value;
				}
			}

			public unsafe override byte this[int i0, int i1, int i2]
			{
				get
				{
					return (ptr + steps[0] * i0 + steps[1] * i1)[steps[2] * i2];
				}
				set
				{
					(ptr + steps[0] * i0 + steps[1] * i1)[steps[2] * i2] = value;
				}
			}

			public unsafe override byte this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return ptr[num];
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					ptr[num] = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_8UC1;

		private const int ThisDepth = 0;

		private const int ThisChannels = 1;

		public MatOfByte()
		{
		}

		public MatOfByte(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfByte(Mat mat)
			: base(mat)
		{
		}

		public MatOfByte(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfByte(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfByte(int rows, int cols, byte s)
			: base(rows, cols, ThisType, (Scalar)(int)s)
		{
		}

		public MatOfByte(Size size, byte s)
			: base(size, ThisType, (Scalar)(int)s)
		{
		}

		public MatOfByte(MatOfByte m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<byte, MatOfByte>)m, rowRange, colRange)
		{
		}

		public MatOfByte(MatOfByte m, params Range[] ranges)
			: base((Mat<byte, MatOfByte>)m, ranges)
		{
		}

		public MatOfByte(MatOfByte m, Rect roi)
			: base((Mat<byte, MatOfByte>)m, roi)
		{
		}

		public MatOfByte(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfByte(int rows, int cols, byte[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfByte(int rows, int cols, byte[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfByte(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfByte(IEnumerable<int> sizes, byte[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfByte(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfByte(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfByte(IEnumerable<int> sizes, byte s)
			: base(sizes, ThisType, (Scalar)(int)s)
		{
		}

		public MatOfByte(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfByte(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<byte> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfByte FromArray(params byte[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfByte matOfByte = new MatOfByte(arr.Length / 1, 1);
			matOfByte.SetArray(0, 0, arr);
			return matOfByte;
		}

		public static MatOfByte FromArray(byte[,] arr)
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
			MatOfByte matOfByte = new MatOfByte(length, length2);
			matOfByte.SetArray(0, 0, arr);
			return matOfByte;
		}

		public static MatOfByte FromArray(IEnumerable<byte> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override byte[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new byte[0];
			}
			byte[] array = new byte[num];
			GetArray(0, 0, array);
			return array;
		}

		public override byte[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new byte[0, 0];
			}
			byte[,] array = new byte[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<byte> GetEnumerator()
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

		public override void Add(byte value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_uchar(ptr, value);
		}

		public void Add(sbyte value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_char(ptr, value);
		}
	}
}
