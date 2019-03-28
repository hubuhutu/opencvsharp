using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Vec4s : IVec<short>
	{
		public short Item0;

		public short Item1;

		public short Item2;

		public short Item3;

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
				default:
					throw new ArgumentOutOfRangeException("i");
				}
			}
		}

		public Vec4s(short item0, short item1, short item2, short item3)
		{
			Item0 = item0;
			Item1 = item1;
			Item2 = item2;
			Item3 = item3;
		}
	}
}
