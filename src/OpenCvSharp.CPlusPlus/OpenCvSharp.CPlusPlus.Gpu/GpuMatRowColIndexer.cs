namespace OpenCvSharp.CPlusPlus.Gpu
{
	public abstract class GpuMatRowColIndexer
	{
		protected readonly GpuMat parent;

		public abstract GpuMat this[int pos]
		{
			get;
			set;
		}

		public abstract GpuMat this[int start, int end]
		{
			get;
			set;
		}

		public virtual GpuMat this[Range range]
		{
			get
			{
				return this[range.Start, range.End];
			}
		}

		protected internal GpuMatRowColIndexer(GpuMat parent)
		{
			this.parent = parent;
		}

		public virtual GpuMat Get(int pos)
		{
			return this[pos];
		}

		public virtual GpuMat Get(int start, int end)
		{
			return this[start, end];
		}

		public virtual GpuMat Get(Range range)
		{
			return this[range];
		}

		public virtual void Set(int pos, GpuMat value)
		{
			this[pos] = value;
		}

		public virtual void Set(int start, int end, GpuMat value)
		{
			this[start, end] = value;
		}

		public virtual void Set(Range range, GpuMat value)
		{
			this[range.Start, range.End] = value;
		}
	}
}
