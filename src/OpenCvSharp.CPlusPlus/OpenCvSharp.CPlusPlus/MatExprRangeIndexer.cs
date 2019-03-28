namespace OpenCvSharp.CPlusPlus
{
	public abstract class MatExprRangeIndexer
	{
		protected readonly Mat parent;

		public abstract MatExpr this[int rowStart, int rowEnd, int colStart, int colEnd]
		{
			get;
			set;
		}

		public abstract MatExpr this[Range rowRange, Range colRange]
		{
			get;
			set;
		}

		public virtual MatExpr this[Rect roi]
		{
			get
			{
				return this[roi.Top, roi.Bottom, roi.Left, roi.Right];
			}
			set
			{
				this[roi.Top, roi.Bottom, roi.Left, roi.Right] = value;
			}
		}

		public abstract MatExpr this[params Range[] ranges]
		{
			get;
			set;
		}

		protected internal MatExprRangeIndexer(Mat parent)
		{
			this.parent = parent;
		}

		public MatExpr Get(int rowStart, int rowEnd, int colStart, int colEnd)
		{
			return this[rowStart, rowEnd, colStart, colEnd];
		}

		public MatExpr Get(Range rowRange, Range colRange)
		{
			return this[rowRange, colRange];
		}

		public MatExpr Get(Rect roi)
		{
			return this[roi];
		}

		public void Set(int rowStart, int rowEnd, int colStart, int colEnd, MatExpr value)
		{
			this[rowStart, rowEnd, colStart, colEnd] = value;
		}

		public void Set(Range rowRange, Range colRange, MatExpr value)
		{
			this[rowRange, colRange] = value;
		}

		public void Set(Rect roi, MatExpr value)
		{
			this[roi] = value;
		}
	}
}
