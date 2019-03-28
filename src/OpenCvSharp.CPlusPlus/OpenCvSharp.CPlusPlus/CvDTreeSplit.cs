using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvDTreeSplit : CvObject
	{
		public unsafe int VarIdx => ((WCvDTreeSplit*)(void*)ptr)->var_idx;

		public unsafe bool Inversed => ((WCvDTreeSplit*)(void*)ptr)->inversed != 0;

		public unsafe float Quality => ((WCvDTreeSplit*)(void*)ptr)->quality;

		public unsafe CvDTreeSplit Next
		{
			get
			{
				IntPtr intPtr = new IntPtr(((WCvDTreeSplit*)(void*)ptr)->next);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvDTreeSplit(intPtr);
			}
		}

		public unsafe PointerAccessor1D_Int32 Subset
		{
			get
			{
				int* ptr = ((WCvDTreeSplit*)(void*)base.ptr)->subset;
				return new PointerAccessor1D_Int32(ptr);
			}
		}

		public unsafe float OrdC => BitConverter.ToSingle(BitConverter.GetBytes(*((WCvDTreeSplit*)(void*)ptr)->subset), 0);

		public unsafe int OrdSplitPoint => ((WCvDTreeSplit*)(void*)ptr)->subset[1];

		public CvDTreeSplit(IntPtr ptr)
			: base(ptr)
		{
		}
	}
}
