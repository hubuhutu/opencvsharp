namespace OpenCvSharp.CPlusPlus
{
	public abstract class SparseMatIndexer<T> where T : struct
	{
		protected readonly SparseMat parent;

		public abstract T this[int i0, long? hashVal = default(long?)]
		{
			get;
			set;
		}

		public abstract T this[int i0, int i1, long? hashVal = default(long?)]
		{
			get;
			set;
		}

		public abstract T this[int i0, int i1, int i2, long? hashVal = default(long?)]
		{
			get;
			set;
		}

		public abstract T this[int[] idx, long? hashVal = default(long?)]
		{
			get;
			set;
		}

		internal SparseMatIndexer(SparseMat parent)
		{
			this.parent = parent;
		}
	}
}
