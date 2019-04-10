using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Range
	{
		public int Start;

		public int End;

        public static Range All { get { return new Range(int.MinValue, int.MaxValue); } }

		public Range(int start, int end)
		{
			Start = start;
			End = end;
		}

		public static implicit operator CvSlice(Range self)
		{
			return new CvSlice(self.Start, self.End);
		}

		public static implicit operator Range(CvSlice slice)
		{
			return new Range(slice.StartIndex, slice.EndIndex);
		}
	}
}
