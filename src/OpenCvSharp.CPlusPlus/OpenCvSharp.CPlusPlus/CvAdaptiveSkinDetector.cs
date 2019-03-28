using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvAdaptiveSkinDetector : DisposableCvObject
	{
		private bool disposed;

		public CvAdaptiveSkinDetector(int samplingDivider = 1, MorphingMethod morphingMethod = MorphingMethod.None)
		{
			ptr = NativeMethods.contrib_CvAdaptiveSkinDetector_new(samplingDivider, (int)morphingMethod);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.contrib_CvAdaptiveSkinDetector_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public virtual void Process(IplImage inputBgrImage, IplImage outputHueMask)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CvAdaptiveSkinDetector");
			}
			if (inputBgrImage == null)
			{
				throw new ArgumentNullException("inputBgrImage");
			}
			if (outputHueMask == null)
			{
				throw new ArgumentNullException("outputHueMask");
			}
			inputBgrImage.ThrowIfDisposed();
			outputHueMask.ThrowIfDisposed();
			NativeMethods.contrib_CvAdaptiveSkinDetector_process(ptr, inputBgrImage.CvPtr, outputHueMask.CvPtr);
		}
	}
}
