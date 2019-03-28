using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
	public class CvContour : CvSeq<CvPoint>
	{
		public new static readonly int SizeOf = Marshal.SizeOf(typeof(WCvContour));

		public unsafe CvRect Rect => ((WCvContour*)(void*)ptr)->rect;

		public unsafe int Color => ((WCvContour*)(void*)ptr)->color;

		public CvContour(IntPtr ptr)
			: base(ptr)
		{
			base.ptr = ptr;
		}
	}
}
