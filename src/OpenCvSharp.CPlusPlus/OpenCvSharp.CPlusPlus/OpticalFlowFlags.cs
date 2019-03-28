using System;

namespace OpenCvSharp.CPlusPlus
{
	[Flags]
	public enum OpticalFlowFlags
	{
		None = 0x0,
		PyrAReady = 0x1,
		PyrBReady = 0x2,
		UseInitialFlow = 0x4,
		LkGetMinEigenvals = 0x8,
		FarnebackGaussian = 0x100
	}
}
