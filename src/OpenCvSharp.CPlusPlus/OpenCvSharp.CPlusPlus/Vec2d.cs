using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Vec2d : IVec<double>
	{
		public double Item0;

		public double Item1;

		public double this[int i]
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

		public Vec2d(double item0, double item1)
		{
			Item0 = item0;
			Item1 = item1;
		}
	}
}
