using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct CvParamGrid
	{
		public double MinVal;

		public double MaxVal;

		public double Step;

		public const int SVM_C = 0;

		public const int SVM_GAMMA = 1;

		public const int SVM_P = 2;

		public const int SVM_NU = 3;

		public const int SVM_COEF = 4;

		public const int SVM_DEGREE = 5;

		public CvParamGrid(double minVal, double maxVal, double logStep)
		{
			MinVal = minVal;
			MaxVal = maxVal;
			Step = logStep;
		}

		public bool Check()
		{
			return NativeMethods.ml_CvParamGrid_check(this) != 0;
		}
	}
}
