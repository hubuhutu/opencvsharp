namespace OpenCvSharp.CPlusPlus
{
	internal struct WCvDTreeNode
	{
		public int class_idx;

		public int Tn;

		public double value;

		public unsafe void* parent;

		public unsafe void* left;

		public unsafe void* right;

		public unsafe void* split;

		public int sample_count;

		public int depth;

		public unsafe int* num_valid;

		public int offset;

		public int buf_idx;

		public double maxlr;

		public int complexity;

		public double alpha;

		public double node_risk;

		public double tree_risk;

		public double tree_error;

		public unsafe int* cv_Tn;

		public unsafe double* cv_node_risk;

		public unsafe double* cv_node_error;
	}
}
