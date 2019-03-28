using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
	public class CvChain : CvSeq<CvPoint>
	{
		public new static readonly int SizeOf = Marshal.SizeOf(typeof(WCvChain));

		public unsafe CvPoint Origin => ((WCvChain*)(void*)ptr)->origin;

		public CvChain(IntPtr ptr)
			: base(ptr)
		{
			base.ptr = ptr;
		}

		public CvSeq<CvPoint> ApproxChains(CvMemStorage storage)
		{
			return Cv.ApproxChains(this, storage);
		}

		public CvSeq<CvPoint> ApproxChains(CvMemStorage storage, ContourChain method)
		{
			return Cv.ApproxChains(this, storage, method);
		}

		public CvSeq<CvPoint> ApproxChains(CvMemStorage storage, ContourChain method, double parameter)
		{
			return Cv.ApproxChains(this, storage, method, parameter);
		}

		public CvSeq<CvPoint> ApproxChains(CvMemStorage storage, ContourChain method, double parameter, int minimalPerimeter)
		{
			return Cv.ApproxChains(this, storage, method, parameter, minimalPerimeter);
		}

		public CvSeq<CvPoint> ApproxChains(CvMemStorage storage, ContourChain method, double parameter, int minimalPerimeter, bool recursive)
		{
			return Cv.ApproxChains(this, storage, method, parameter, minimalPerimeter, recursive);
		}
	}
}
