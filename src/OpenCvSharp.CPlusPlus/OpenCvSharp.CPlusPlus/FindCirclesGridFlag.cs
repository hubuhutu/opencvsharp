using System;

namespace OpenCvSharp.CPlusPlus
{
	[Flags]
	public enum FindCirclesGridFlag
	{
		SymmetricGrid = 0x1,
		AsymmetricGrid = 0x2,
		Clustering = 0x4
	}
}
