using System;
using System.IO;

namespace OpenCvSharp.CPlusPlus
{
	public abstract class FrameSource : DisposableCvObject
	{
		public static FrameSource CreateEmptySource()
		{
			return FrameSourceImpl.FromPtr(NativeMethods.superres_createFrameSource_Empty());
		}

		public static FrameSource CreateVideoSource(string fileName)
		{
			if (string.IsNullOrEmpty("fileName"))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException("", fileName);
			}
			return FrameSourceImpl.FromPtr(NativeMethods.superres_createFrameSource_Video(fileName));
		}

		public static FrameSource CreateVideoSourceGpu(string fileName)
		{
			if (string.IsNullOrEmpty("fileName"))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException("", fileName);
			}
			return FrameSourceImpl.FromPtr(NativeMethods.superres_createFrameSource_Video_GPU(fileName));
		}

		public static FrameSource CreateCameraSource(int deviceId)
		{
			return FrameSourceImpl.FromPtr(NativeMethods.superres_createFrameSource_Camera(deviceId));
		}

		public abstract void NextFrame(OutputArray frame);

		public abstract void Reset();
	}
}
