using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Rangef
	{
		public float Start;

		public float End;

        public static Range All { get { return new Range(int.MinValue, int.MaxValue); } }

		public Rangef(float start, float end)
		{
			Start = start;
			End = end;
		}

		public static implicit operator Range(Rangef range)
		{
			return new Range((int)range.Start, (int)range.End);
		}
	}
}
