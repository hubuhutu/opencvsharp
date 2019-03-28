using System;

namespace OpenCvSharp.CPlusPlus
{
	[Flags]
	public enum DftFlag2
	{
		None = 0x0,
		Inverse = 0x1,
		Scale = 0x2,
		Rows = 0x4,
		ComplexOutput = 0x10,
		RealOutput = 0x20
	}
}
