using System;

namespace OpenCvSharp.CPlusPlus
{
	[Flags]
	public enum MLPTrainingFlag
	{
		Zero = 0x0,
		UpdateWeights = 0x1,
		NoInputScale = 0x2,
		NoOutputScale = 0x4
	}
}
