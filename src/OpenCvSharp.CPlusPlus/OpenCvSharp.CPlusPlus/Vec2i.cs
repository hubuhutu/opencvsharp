using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Vec2i : IVec<int>
	{
		public int Item0;

		public int Item1;

		public int this[int i]
		{
			get
			{
				switch (i)
				{
				case 0:
					return Item0;
				case 1:
					return Item1;
				default:
					throw new ArgumentOutOfRangeException("i");
				}
			}
			set
			{
				switch (i)
				{
				case 0:
					Item0 = value;
					break;
				case 1:
					Item1 = value;
					break;
				default:
					throw new ArgumentOutOfRangeException("i");
				}
			}
		}

		public Vec2i(int item0, int item1)
		{
			Item0 = item0;
			Item1 = item1;
		}
	}
}
