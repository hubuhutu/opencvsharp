using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class MatOfFloat : Mat<float, MatOfFloat>
	{
		public new sealed class Indexer : MatIndexer<float>
		{
			private unsafe readonly byte* ptr;

			public unsafe override float this[int i0]
			{
				get
				{
					return *(float*)(ptr + steps[0] * i0);
				}
				set
				{
					*(float*)(ptr + steps[0] * i0) = value;
				}
			}

			public unsafe override float this[int i0, int i1]
			{
				get
				{
					return *(float*)(ptr + steps[0] * i0 + steps[1] * i1);
				}
				set
				{
					*(float*)(ptr + steps[0] * i0 + steps[1] * i1) = value;
				}
			}

			public unsafe override float this[int i0, int i1, int i2]
			{
				get
				{
					return *(float*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2);
				}
				set
				{
					*(float*)(ptr + steps[0] * i0 + steps[1] * i1 + steps[2] * i2) = value;
				}
			}

			public unsafe override float this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return *(float*)(ptr + num);
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					*(float*)(ptr + num) = value;
				}
			}

			internal unsafe Indexer(Mat parent)
				: base(parent)
			{
				ptr = (byte*)parent.Data.ToPointer();
			}
		}

		private static readonly MatType ThisType = MatType.CV_32FC1;

		private const int ThisDepth = 5;

		private const int ThisChannels = 1;

		public MatOfFloat()
		{
		}

		public MatOfFloat(IntPtr ptr)
			: base(ptr)
		{
		}

		public MatOfFloat(Mat mat)
			: base(mat)
		{
		}

		public MatOfFloat(int rows, int cols)
			: base(rows, cols, ThisType)
		{
		}

		public MatOfFloat(Size size)
			: base(size, ThisType)
		{
		}

		public MatOfFloat(int rows, int cols, float s)
			: base(rows, cols, ThisType, (Scalar)s)
		{
		}

		public MatOfFloat(Size size, float s)
			: base(size, ThisType, (Scalar)s)
		{
		}

		public MatOfFloat(MatOfFloat m, Range rowRange, Range? colRange = default(Range?))
			: base((Mat<float, MatOfFloat>)m, rowRange, colRange)
		{
		}

		public MatOfFloat(MatOfFloat m, params Range[] ranges)
			: base((Mat<float, MatOfFloat>)m, ranges)
		{
		}

		public MatOfFloat(MatOfFloat m, Rect roi)
			: base((Mat<float, MatOfFloat>)m, roi)
		{
		}

		public MatOfFloat(int rows, int cols, IntPtr data, long step = 0L)
			: base(rows, cols, ThisType, data, step)
		{
		}

		public MatOfFloat(int rows, int cols, float[] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfFloat(int rows, int cols, float[,] data, long step = 0L)
			: base(rows, cols, ThisType, (Array)data, step)
		{
		}

		public MatOfFloat(IEnumerable<int> sizes, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfFloat(IEnumerable<int> sizes, float[] data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, (Array)data, steps)
		{
		}

		public MatOfFloat(IEnumerable<int> sizes, Array data, IEnumerable<long> steps = null)
			: base(sizes, ThisType, data, steps)
		{
		}

		public MatOfFloat(IEnumerable<int> sizes)
			: base(sizes, ThisType)
		{
		}

		public MatOfFloat(IEnumerable<int> sizes, float s)
			: base(sizes, ThisType, (Scalar)s)
		{
		}

		public MatOfFloat(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		public MatOfFloat(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		public override MatIndexer<float> GetIndexer()
		{
			return new Indexer(this);
		}

		public static MatOfFloat FromArray(params float[] arr)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (arr.Length == 0)
			{
				throw new ArgumentException("arr.Length == 0");
			}
			MatOfFloat matOfFloat = new MatOfFloat(arr.Length / 1, 1);
			matOfFloat.SetArray(0, 0, arr);
			return matOfFloat;
		}

		public static MatOfFloat FromArray(float[,] arr)
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
			MatOfFloat matOfFloat = new MatOfFloat(length, length2);
			matOfFloat.SetArray(0, 0, arr);
			return matOfFloat;
		}

		public static MatOfFloat FromArray(IEnumerable<float> enumerable)
		{
			return FromArray(EnumerableEx.ToArray(enumerable));
		}

		public override float[] ToArray()
		{
			long num = Total();
			if (num == 0L)
			{
				return new float[0];
			}
			float[] array = new float[num];
			GetArray(0, 0, array);
			return array;
		}

		public override float[,] ToRectangularArray()
		{
			if (base.Rows == 0 || base.Cols == 0)
			{
				return new float[0, 0];
			}
			float[,] array = new float[base.Rows, base.Cols];
			GetArray(0, 0, array);
			return array;
		}

		public override IEnumerator<float> GetEnumerator()
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

		public override void Add(float value)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_float(ptr, value);
		}
	}
}
