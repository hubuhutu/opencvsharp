namespace OpenCvSharp.CPlusPlus
{
	public class HierarchyIndex
	{
		public int Next
		{
			get;
			set;
		}

		public int Previous
		{
			get;
			set;
		}

		public int Child
		{
			get;
			set;
		}

		public int Parent
		{
			get;
			set;
		}

		public HierarchyIndex()
		{
			Next = 0;
			Previous = 0;
			Child = 0;
			Parent = 0;
		}

		public HierarchyIndex(int next, int previous, int child, int parent)
		{
			Next = next;
			Previous = previous;
			Child = child;
			Parent = parent;
		}

		public static HierarchyIndex FromVec4i(Vec4i vec)
		{
			return new HierarchyIndex
			{
				Next = vec.Item0,
				Previous = vec.Item1,
				Child = vec.Item2,
				Parent = vec.Item3
			};
		}

		public Vec4i ToVec4i()
		{
			return new Vec4i(Next, Previous, Child, Parent);
		}
	}
}
