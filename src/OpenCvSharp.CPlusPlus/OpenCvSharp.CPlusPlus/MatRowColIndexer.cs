namespace OpenCvSharp.CPlusPlus
{
	public abstract class MatRowColIndexer
	{
		protected readonly Mat parent;

		public abstract Mat this[int pos]
		{
			get;
			set;
		}

		public abstract Mat this[int start, int end]
		{
			get;
			set;
		}

		public virtual Mat this[Range range]
		{
			get
			{
				return this[range.Start, range.End];
			}
		}

		protected internal MatRowColIndexer(Mat parent)
		{
			this.parent = parent;
		}

		public virtual Mat Get(int pos)
		{
			return this[pos];
		}

		public virtual Mat Get(int start, int end)
		{
			return this[start, end];
		}

		public virtual Mat Get(Range range)
		{
			return this[range];
		}

		public virtual void Set(int pos, Mat value)
		{
			this[pos] = value;
		}

		public virtual void Set(int start, int end, Mat value)
		{
			this[start, end] = value;
		}

		public virtual void Set(Range range, Mat value)
		{
			this[range.Start, range.End] = value;
		}
	}
}
