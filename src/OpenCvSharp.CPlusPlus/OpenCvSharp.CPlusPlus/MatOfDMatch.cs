using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfDMatch : Mat<DMatch, MatOfDMatch>
	{
		public new sealed class Indexer : MatIndexer<DMatch>
		{
			private unsafe readonly byte* ptr;

			public unsafe override DMatch this[int i0]
			{
				get
				{
					return (DMatch)(*(Vec4f*)(ptr + steps[0] * i0));
				}
				set
				{
					*(Vec4f*)(ptr + steps[0] * i0) = (Vec4f)value;
				}
			}

			public unsafe override DMatch this[int i0, int i1]
			{
				get
				{
					return (DMatch)(*(Vec4f*)(ptr + steps[0] * i0 + steps[1] * i1));
				}
				set
				{
					*(Vec4f*)(ptr + steps[0] * i0 + steps[1] * i1) = (Vec4f)value;
				}
			}

			public unsafe override DMatch this[int i0, int i1, int i2]
			{
				get
				{
					return (DMatch)(*(Vec4f*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2));
				}
				set
				{
					*(Vec4f*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = (Vec4f)value;
				}
			}

			public unsafe override DMatch this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return (DMatch)(*(Vec4f*)(ptr + num));
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(Vec4f*)(ptr + num) = (Vec4f)value;
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

		public MatOfDMatch()
		{
		}

		public MatOfDMatch(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfDMatch(Mat mat)
			: base(mat)
		{
		}

		public MatOfDMatch(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfDMatch(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfDMatch(int rows, int cols, DMatch s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfDMatch(Size size, DMatch s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfDMatch(MatOfDMatch m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<DMatch, MatOfDMatch>)m, rowRange, colRange)
		{
		}

		public MatOfDMatch(MatOfDMatch m, params Range[] ranges)
			: base((Mat<DMatch, MatOfDMatch>)m, ranges)
		{
		}

		public MatOfDMatch(MatOfDMatch m, Rect roi)
			: base((Mat<DMatch, MatOfDMatch>)m, roi)
		{
		}

		public MatOfDMatch(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfDMatch(IEnumerable<int> sizes, DMatch s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public override MatIndexer<DMatch> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfDMatch FromArray(params DMatch[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfDMatch matOfDMatch = new MatOfDMatch(arr.Length, 1);
			matOfDMatch.SetArray(0, 0, arr);
			return matOfDMatch;
		}

		public static MatOfDMatch FromArray(DMatch[,] arr)
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
			MatOfDMatch matOfDMatch = new MatOfDMatch(length, length2);
			matOfDMatch.SetArray(0, 0, arr);
			return matOfDMatch;
		}

		public static MatOfDMatch FromArray(IEnumerable<DMatch> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override DMatch[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new DMatch[0];
			}
			DMatch[] array = new DMatch[num];
			GetArray(0, 0, array);
			return array;
		}

		public override DMatch[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new DMatch[0, 0];
			}
			DMatch[,] array = new DMatch[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<DMatch> GetEnumerator()
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

		public override void Add(DMatch value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Vec4f(ptr, (Vec4f)value);
		}
	}
}
