namespace OpenCvSharp.CPlusPlus
{
	public abstract class MatExprRowColIndexer
	{
		protected readonly MatExpr parent;

		public abstract MatExpr this[int pos]
		{
			get;
		}

		protected internal MatExprRowColIndexer(MatExpr parent)
		{
			this.parent = parent;
		}

		public virtual MatExpr Get(int pos)
		{
			return this[pos];
		}
	}
}
