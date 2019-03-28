using System;

namespace OpenCvSharp.CPlusPlus
{
	[Flags]
	public enum InOutArrayKind
	{
		None = 0x0,
		Mat = 0x10000,
		Matx = 0x20000,
		StdVector = 0x30000,
		VectorVector = 0x40000,
		VectorMat = 0x50000,
		Expr = 0x60000,
		OpenGLBuffer = 0x70000,
		OpenGLTexture = 0x80000,
		GpuMat = 0x90000,
		OclMat = 0xA0000,
		FixedType = int.MinValue,
		FixedSize = 0x40000000
	}
}
