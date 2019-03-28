namespace OpenCvSharp.CPlusPlus
{
	public abstract class DenseOpticalFlowExt : Algorithm
	{
		public static DenseOpticalFlowExt CreateFarneback()
		{
			return DenseOpticalFlowExtImpl.FromPtr(NativeMethods.superres_createOptFlow_Farneback());
		}

		public static DenseOpticalFlowExt CreateFarneback_GPU()
		{
			return DenseOpticalFlowExtImpl.FromPtr(NativeMethods.superres_createOptFlow_Farneback_GPU());
		}

		public static DenseOpticalFlowExt CreateFarneback_OCL()
		{
			return DenseOpticalFlowExtImpl.FromPtr(NativeMethods.superres_createOptFlow_Farneback_OCL());
		}

		public static DenseOpticalFlowExt CreateSimple()
		{
			return DenseOpticalFlowExtImpl.FromPtr(NativeMethods.superres_createOptFlow_Simple());
		}

		public static DenseOpticalFlowExt CreateDualTVL1()
		{
			return DenseOpticalFlowExtImpl.FromPtr(NativeMethods.superres_createOptFlow_DualTVL1());
		}

		public static DenseOpticalFlowExt CreateDualTVL1_GPU()
		{
			return DenseOpticalFlowExtImpl.FromPtr(NativeMethods.superres_createOptFlow_DualTVL1_GPU());
		}

		public static DenseOpticalFlowExt CreateDualTVL1_OCL()
		{
			return DenseOpticalFlowExtImpl.FromPtr(NativeMethods.superres_createOptFlow_DualTVL1_OCL());
		}

		public static DenseOpticalFlowExt CreateBrox_GPU()
		{
			return DenseOpticalFlowExtImpl.FromPtr(NativeMethods.superres_createOptFlow_Brox_GPU());
		}

		public static DenseOpticalFlowExt CreatePyrLK_GPU()
		{
			return DenseOpticalFlowExtImpl.FromPtr(NativeMethods.superres_createOptFlow_PyrLK_GPU());
		}

		public static DenseOpticalFlowExt CreatePyrLK_OCL()
		{
			return DenseOpticalFlowExtImpl.FromPtr(NativeMethods.superres_createOptFlow_PyrLK_OCL());
		}

		public virtual void CollectGarbage()
		{
		}

		public abstract void Calc(InputArray frame0, InputArray frame1, OutputArray flow1, OutputArray flow2 = null);
	}
}
