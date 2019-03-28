using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Vec6s : IVec<short>
	{
		public short Item0;

		public short Item1;

		public short Item2;

		public short Item3;

		public short Item4;

		public short Item5;

		public short this[int i]
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

		public Vec6s(short item0, short item1, short item2, short item3, short item4, short item5)
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
