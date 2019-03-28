using System;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	[Flags]
	public enum CudaMemAllocType
	{
		Locked = 0x1,
		ZeroCopy = 0x2,
		WhiteCombined = 0x4
	}
}
