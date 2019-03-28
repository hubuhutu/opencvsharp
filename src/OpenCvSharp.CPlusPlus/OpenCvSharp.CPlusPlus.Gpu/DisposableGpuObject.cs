using System;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public abstract class DisposableGpuObject : DisposableCvObject
	{
		private bool? isGpuAvailable;

		protected bool IsGpuCompatible
		{
			get
			{
				if (!isGpuAvailable.HasValue)
				{
					isGpuAvailable = (Cv2Gpu.GetCudaEnabledDeviceCount() >= 1 && new DeviceInfo(Cv2Gpu.GetDevice()).IsCompatible);
				}
				return isGpuAvailable.Value;
			}
		}

		protected DisposableGpuObject()
		{
		}

		protected DisposableGpuObject(IntPtr ptr)
			: base(ptr)
		{
		}

		protected DisposableGpuObject(bool isEnabledDispose)
			: base(isEnabledDispose)
		{
		}

		protected DisposableGpuObject(IntPtr ptr, bool isEnabledDispose)
			: base(ptr, isEnabledDispose)
		{
		}

		protected void ThrowIfNotAvailable()
		{
			if (base.IsDisposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (Cv2Gpu.GetCudaEnabledDeviceCount() < 1)
			{
				throw new OpenCvSharpException("Your OpenCV DLL does not support GPU module.");
			}
			if (!IsGpuCompatible)
			{
				throw new OpenCvSharpException("The selected GPU device is not compatible.");
			}
		}
	}
}
