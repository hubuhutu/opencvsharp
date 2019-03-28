using System;

namespace OpenCvSharp.CPlusPlus
{
	internal interface IStdVector<out T> : IDisposable
	{
		int Size
		{
			get;
		}

		IntPtr ElemPtr
		{
			get;
		}

		T[] ToArray();
	}
}
