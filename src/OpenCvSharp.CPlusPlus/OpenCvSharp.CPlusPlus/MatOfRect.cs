using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfRect : Mat<Rect, MatOfRect>
	{
		public new sealed class Indexer : MatIndexer<Rect>
		{
			private unsafe readonly byte* ptr;

			public unsafe override Rect this[int i0]
			{
				get
				{
					return *(Rect*)(ptr + steps[0] * i0);
				}
				set
				{
					*(Rect*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override Rect this[int i0, int i1]
			{
				get
				{
					return *(Rect*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(Rect*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override Rect this[int i0, int i1, int i2]
			{
				get
				{
					return *(Rect*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(Rect*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override Rect this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(Rect*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Rect*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_32SC4;

		private const int ThisDepth = 4;

		private const int ThisChannels = 4;

		public MatOfRect()
		{
		}

		public MatOfRect(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfRect(Mat mat)
			: base(mat)
		{
		}

		public MatOfRect(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfRect(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfRect(int rows, int cols, Rect s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfRect(Size size, Rect s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfRect(MatOfRect m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<Rect, MatOfRect>)m, rowRange, colRange)
		{
		}

		public MatOfRect(MatOfRect m, params Range[] ranges)
			: base((Mat<Rect, MatOfRect>)m, ranges)
		{
		}

		public MatOfRect(MatOfRect m, Rect roi)
			: base((Mat<Rect, MatOfRect>)m, roi)
		{
		}

		public MatOfRect(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfRect(int rows, int cols, Rect[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfRect(int rows, int cols, Rect[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfRect(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfRect(IEnumerable<int> sizes, Rect[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfRect(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfRect(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfRect(IEnumerable<int> sizes, Rect s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfRect(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfRect(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<Rect> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfRect FromArray(params Rect[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfRect matOfRect = new MatOfRect(arr.Length, 1);
			matOfRect.SetArray(0, 0, arr);
			return matOfRect;
		}

		public static MatOfRect FromArray(Rect[,] arr)
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
			MatOfRect matOfRect = new MatOfRect(length, length2);
			matOfRect.SetArray(0, 0, arr);
			return matOfRect;
		}

		public static MatOfRect FromArray(IEnumerable<Rect> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override Rect[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new Rect[0];
			}
			Rect[] array = new Rect[num];
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
			int[] array = new int[num * 4];
			GetArray(0, 0, array);
			return array;
		}

		public override Rect[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new Rect[0, 0];
			}
			Rect[,] array = new Rect[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<Rect> GetEnumerator()
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

		public override void Add(Rect value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Rect(ptr, value);
		}
	}
}
