namespace OpenCvSharp.CPlusPlus
{
	public struct WCvANN_MLP_TrainParams
	{
		public CvTermCriteria term_crit;

		public int train_method;

		public double bp_dw_scale;

		public double bp_moment_scale;

		public double rp_dw0;

		public double rp_dw_plus;

		public double rp_dw_minus;

		public double rp_dw_min;

		public double rp_dw_max;
	}
}
