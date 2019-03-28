using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Vec2w : IVec<ushort>
	{
		public ushort Item0;

		public ushort Item1;

		public ushort this[int i]
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

		public Vec2w(ushort item0, ushort item1)
		{
			Item0 = item0;
			Item1 = item1;
		}
	}
}
