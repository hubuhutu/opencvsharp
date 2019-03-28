using System;

namespace OpenCvSharp.CPlusPlus
{
	[Flags]
	public enum DrawMatchesFlags
	{
		Default = 0x0,
		DrawOverOutImg = 0x1,
		NotDrawSinglePoints = 0x2,
		DrawRichKeypoints = 0x4
	}
}
