namespace OpenCvSharp.CPlusPlus
{
	public abstract class MatIndexer<T> where T : struct
	{
		protected readonly Mat parent;

		protected readonly long[] steps;

		public abstract T this[int i0]
		{
			get;
			set;
		}

		public abstract T this[int i0, int i1]
		{
			get;
			set;
		}

		public abstract T this[int i0, int i1, int i2]
		{
			get;
			set;
		}

		public abstract T this[params int[] idx]
		{
			get;
			set;
		}

		internal MatIndexer(Mat parent)
		{
			this.parent = parent;
			int num = parent.Dims();
			steps = new long[num];
			for (int i = 0; i < num; i++)
			{
				steps[i] = parent.Step(i);
			}
		}
	}
}
