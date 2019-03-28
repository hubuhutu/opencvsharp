using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfUShort : Mat<ushort, MatOfUShort>
	{
		public new sealed class Indexer : MatIndexer<ushort>
		{
			private unsafe readonly byte* ptr;

			public unsafe override ushort this[int i0]
			{
				get
				{
					return *(ushort*)(ptr + steps[0] * i0);
				}
				set
				{
					*(ushort*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override ushort this[int i0, int i1]
			{
				get
				{
					return *(ushort*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(ushort*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override ushort this[int i0, int i1, int i2]
			{
				get
				{
					return *(ushort*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(ushort*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override ushort this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(ushort*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(ushort*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_16UC1;

		private const int ThisDepth = 2;

		private const int ThisChannels = 1;

		public MatOfUShort()
		{
		}

		public MatOfUShort(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfUShort(Mat mat)
			: base(mat)
		{
		}

		public MatOfUShort(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfUShort(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfUShort(int rows, int cols, ushort s)
			: base(rows, cols, ThisType, (Scalar)(int)s)
		{
		}

		public MatOfUShort(Size size, ushort s)
			: base(size, ThisType, (Scalar)(int)s)
		{
		}

		public MatOfUShort(MatOfUShort m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<ushort, MatOfUShort>)m, rowRange, colRange)
		{
		}

		public MatOfUShort(MatOfUShort m, params Range[] ranges)
			: base((Mat<ushort, MatOfUShort>)m, ranges)
		{
		}

		public MatOfUShort(MatOfUShort m, Rect roi)
			: base((Mat<ushort, MatOfUShort>)m, roi)
		{
		}

		public MatOfUShort(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfUShort(int rows, int cols, ushort[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfUShort(int rows, int cols, ushort[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfUShort(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfUShort(IEnumerable<int> sizes, ushort[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfUShort(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfUShort(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfUShort(IEnumerable<int> sizes, ushort s)
			: base(sizes, ThisType, (Scalar)(int)s)
		{
		}

		public MatOfUShort(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfUShort(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<ushort> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfUShort FromArray(params ushort[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfUShort matOfUShort = new MatOfUShort(arr.Length / 1, 1);
			matOfUShort.SetArray(0, 0, arr);
			return matOfUShort;
		}

		public static MatOfUShort FromArray(ushort[,] arr)
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
			MatOfUShort matOfUShort = new MatOfUShort(length, length2);
			matOfUShort.SetArray(0, 0, arr);
			return matOfUShort;
		}

		public static MatOfUShort FromArray(IEnumerable<ushort> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override ushort[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new ushort[0];
			}
			ushort[] array = new ushort[num];
			GetArray(0, 0, array);
			return array;
		}

		public override ushort[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new ushort[0, 0];
			}
			ushort[,] array = new ushort[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<ushort> GetEnumerator()
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

		public override void Add(ushort value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_ushort(ptr, value);
		}
	}
}
