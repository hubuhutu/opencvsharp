namespace OpenCvSharp.CPlusPlus
{
	public struct WCvSVMParams
	{
		public int svm_type;

		public int kernel_type;

		public double degree;

		public double gamma;

		public double coef0;

		public double C;

		public double nu;

		public double p;

		public unsafe void* class_weights;

		public CvTermCriteria term_crit;
	}
}
