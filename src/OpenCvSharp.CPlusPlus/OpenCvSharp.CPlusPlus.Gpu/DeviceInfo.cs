using System;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public sealed class DeviceInfo : DisposableGpuObject
	{
		private bool disposed;

		public int DeviceId => NativeMethods.gpu_DeviceInfo_deviceID(ptr);

		public string Name
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(65536);
				NativeMethods.gpu_DeviceInfo_name(ptr, stringBuilder, stringBuilder.Capacity);
				return stringBuilder.ToString();
			}
		}

		public int MajorVersion => NativeMethods.gpu_DeviceInfo_majorVersion(ptr);

		public int MinorVersion => NativeMethods.gpu_DeviceInfo_minorVersion(ptr);

		public int MultiProcessorCount => NativeMethods.gpu_DeviceInfo_multiProcessorCount(ptr);

		public long SharedMemPerBlock => (long)NativeMethods.gpu_DeviceInfo_sharedMemPerBlock(ptr);

		public long FreeMemory => (long)NativeMethods.gpu_DeviceInfo_freeMemory(ptr);

		public long TotalMemory => (long)NativeMethods.gpu_DeviceInfo_totalMemory(ptr);

		public bool IsCompatible => NativeMethods.gpu_DeviceInfo_isCompatible(ptr) != 0;

		public DeviceInfo()
		{
			Cv2Gpu.ThrowIfGpuNotAvailable();
			ptr = NativeMethods.gpu_DeviceInfo_new1();
		}

		public DeviceInfo(int deviceId)
		{
			Cv2Gpu.ThrowIfGpuNotAvailable();
			ptr = NativeMethods.gpu_DeviceInfo_new2(deviceId);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (ptr != IntPtr.Zero)
				{
					NativeMethods.gpu_DeviceInfo_delete(ptr);
				}
				ptr = IntPtr.Zero;
				disposed = true;
			}
			base.Dispose(disposing);
		}

		public void QueryMemory(out long totalMemory, out long freeMemory)
		{
			NativeMethods.gpu_DeviceInfo_queryMemory(ptr, out ulong totalMemory2, out ulong freeMemory2);
			totalMemory = (long)totalMemory2;
			freeMemory = (long)freeMemory2;
		}

		public bool Supports(FeatureSet featureSet)
		{
			return NativeMethods.gpu_DeviceInfo_supports(ptr, (int)featureSet) != 0;
		}
	}
}
