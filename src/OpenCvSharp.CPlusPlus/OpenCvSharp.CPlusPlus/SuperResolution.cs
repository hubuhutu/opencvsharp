namespace OpenCvSharp.CPlusPlus
{
	public abstract class SuperResolution : Algorithm
	{
		protected FrameSource frameSource;

		protected bool firstCall;

		protected SuperResolution()
		{
			frameSource = null;
			firstCall = true;
		}

		public static SuperResolution CreateBTVL1()
		{
			return SuperResolutionImpl.FromPtr(NativeMethods.superres_createSuperResolution_BTVL1());
		}

		public static SuperResolution CreateBTVL1_GPU()
		{
			return SuperResolutionImpl.FromPtr(NativeMethods.superres_createSuperResolution_BTVL1_GPU());
		}

		public static SuperResolution CreateBTVL1_OCL()
		{
			return SuperResolutionImpl.FromPtr(NativeMethods.superres_createSuperResolution_BTVL1_OCL());
		}

		public virtual void SetInput(FrameSource fs)
		{
			frameSource = fs;
		}

		public virtual void NextFrame(OutputArray frame)
		{
			if (firstCall)
			{
				InitImpl(frameSource);
				firstCall = false;
			}
			ProcessImpl(frameSource, frame);
		}

		public virtual void Reset()
		{
			frameSource.Reset();
			firstCall = true;
		}

		public virtual void CollectGarbage()
		{
		}

		protected abstract void InitImpl(FrameSource fs);

		protected abstract void ProcessImpl(FrameSource fs, OutputArray output);
	}
}
