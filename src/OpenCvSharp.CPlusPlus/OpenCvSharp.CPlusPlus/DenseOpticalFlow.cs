namespace OpenCvSharp.CPlusPlus
{
	public abstract class DenseOpticalFlow : Algorithm
	{
		public static DenseOpticalFlow CreateOptFlow_DualTVL1()
		{
			return DenseOpticalFlowImpl.FromPtr(NativeMethods.video_createOptFlow_DualTVL1());
		}

		public virtual void CollectGarbage()
		{
		}

		public abstract void Calc(InputArray frame0, InputArray frame1, OutputArray flow);
	}
}
