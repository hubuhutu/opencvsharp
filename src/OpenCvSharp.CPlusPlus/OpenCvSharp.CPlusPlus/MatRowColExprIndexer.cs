namespace OpenCvSharp.CPlusPlus
{
	public abstract class MatRowColExprIndexer
	{
		protected readonly Mat parent;

		public abstract MatExpr this[int pos]
		{
			get;
			set;
		}

		public abstract MatExpr this[int start, int end]
		{
			get;
			set;
		}

		public virtual MatExpr this[Range range]
		{
			get
			{
				return this[range.Start, range.End];
			}
			set
			{
				this[range.Start, range.End] = value;
			}
		}

		protected internal MatRowColExprIndexer(Mat parent)
		{
			this.parent = parent;
		}

		public MatExpr Get(int pos)
		{
			return this[pos];
		}

		public MatExpr Get(int start, int end)
		{
			return this[start, end];
		}

		public MatExpr Get(Range range)
		{
			return this[range];
		}

		public void Set(int pos, MatExpr value)
		{
			this[pos] = value;
		}

		public void Set(int start, int end, MatExpr value)
		{
			this[start, end] = value;
		}

		public void Set(Range range, MatExpr value)
		{
			this[range] = value;
		}
	}
}
