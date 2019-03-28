using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Vec6f : IVec<float>
	{
		public float Item0;

		public float Item1;

		public float Item2;

		public float Item3;

		public float Item4;

		public float Item5;

		public float this[int i]
		{
			get
			{
				switch (i)
				{
				case 0:
					return Item0;
				case 1:
					return Item1;
				case 2:
					return Item2;
				case 3:
					return Item3;
				case 4:
					return Item4;
				case 5:
					return Item5;
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
				case 2:
					Item2 = value;
					break;
				case 3:
					Item3 = value;
					break;
				case 4:
					Item4 = value;
					break;
				case 5:
					Item5 = value;
					break;
				default:
					throw new ArgumentOutOfRangeException("i");
				}
			}
		}

		public Vec6f(float item0, float item1, float item2, float item3, float item4, float item5)
		{
			Item0 = item0;
			Item1 = item1;
			Item2 = item2;
			Item3 = item3;
			Item4 = item4;
			Item5 = item5;
		}
	}
}
