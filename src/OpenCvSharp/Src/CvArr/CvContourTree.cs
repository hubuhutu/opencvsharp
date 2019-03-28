using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
	public class CvContourTree : CvSeq
	{
		public new static readonly int SizeOf = Marshal.SizeOf(typeof(WCvContourTree));

		public unsafe CvPoint P1 => ((WCvContourTree*)(void*)ptr)->p1;

		public unsafe CvPoint P2 => ((WCvContourTree*)(void*)ptr)->p2;

		public CvContourTree(IntPtr ptr)
			: base(ptr)
		{
			base.ptr = ptr;
		}

		public CvContourTree(CvSeq contour, CvMemStorage storage, double threshold)
			: base(NativeMethods.cvCreateContourTree(contour.CvPtr, storage.CvPtr, threshold))
		{
		}

		public CvSeq ContourFromContourTree(CvMemStorage storage, CvTermCriteria criteria)
		{
			return Cv.ContourFromContourTree(this, storage, criteria);
		}
	}
}
