using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Vec6b : IVec<byte>
	{
		public byte Item0;

		public byte Item1;

		public byte Item2;

		public byte Item3;

		public byte Item4;

		public byte Item5;

		public byte this[int i]
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

		public Vec6b(byte item0, byte item1, byte item2, byte item3, byte item4, byte item5)
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
