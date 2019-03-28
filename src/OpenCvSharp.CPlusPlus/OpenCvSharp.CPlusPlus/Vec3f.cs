using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Vec3f : IVec<float>
	{
		public float Item0;

		public float Item1;

		public float Item2;

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
				default:
					throw new ArgumentOutOfRangeException("i");
				}
			}
		}

		public Vec3f(float item0, float item1, float item2)
		{
			Item0 = item0;
			Item1 = item1;
			Item2 = item2;
		}
	}
}
