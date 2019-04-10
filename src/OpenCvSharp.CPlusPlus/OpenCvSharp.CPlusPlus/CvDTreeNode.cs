using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvDTreeNode : CvObject
	{
		public unsafe int ClassIdx {get{return ((WCvDTreeNode*)(void*)ptr)->class_idx;}}

		public unsafe int Tn {get{return ((WCvDTreeNode*)(void*)ptr)->Tn;}}

		public unsafe double Value {get{return ((WCvDTreeNode*)(void*)ptr)->value;}}

		public unsafe CvDTreeNode Parent
		{
			get
			{
				IntPtr intPtr = new IntPtr(((WCvDTreeNode*)(void*)ptr)->parent);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvDTreeNode(intPtr);
			}
		}

		public unsafe CvDTreeNode Left
		{
			get
			{
				IntPtr intPtr = new IntPtr(((WCvDTreeNode*)(void*)ptr)->left);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvDTreeNode(intPtr);
			}
		}

		public unsafe CvDTreeNode Right
		{
			get
			{
				IntPtr intPtr = new IntPtr(((WCvDTreeNode*)(void*)ptr)->right);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvDTreeNode(intPtr);
			}
		}

		public unsafe CvDTreeSplit Split
		{
			get
			{
				IntPtr intPtr = new IntPtr(((WCvDTreeNode*)(void*)ptr)->split);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvDTreeSplit(intPtr);
			}
		}

		public unsafe int SampleCount {get{return ((WCvDTreeNode*)(void*)ptr)->sample_count;}}

        public unsafe int Depth { get { return ((WCvDTreeNode*)(void*)ptr)->depth; } }

		public CvDTreeNode(IntPtr ptr)
			: base(ptr)
		{
		}
	}
}
