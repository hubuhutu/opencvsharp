using System;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public sealed class DeviceInfo : DisposableGpuObject
	{
		private bool disposed;

		public int DeviceId {get {return  NativeMethods.gpu_DeviceInfo_deviceID(ptr);}}

		public string Name
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(65536);
				NativeMethods.gpu_DeviceInfo_name(ptr, stringBuilder, stringBuilder.Capacity);
				return stringBuilder.ToString();
			}
		}

		public int MajorVersion {get {return  NativeMethods.gpu_DeviceInfo_majorVersion(ptr);}}

		public int MinorVersion {get {return  NativeMethods.gpu_DeviceInfo_minorVersion(ptr);}}

		public int MultiProcessorCount {get {return  NativeMethods.gpu_DeviceInfo_multiProcessorCount(ptr);}}

		public long SharedMemPerBlock {get {return  (long)NativeMethods.gpu_DeviceInfo_sharedMemPerBlock(ptr);}}

		public long FreeMemory {get {return  (long)NativeMethods.gpu_DeviceInfo_freeMemory(ptr);}}

		public long TotalMemory {get {return  (long)NativeMethods.gpu_DeviceInfo_totalMemory(ptr);}}

        public bool IsCompatible { get { return NativeMethods.gpu_DeviceInfo_isCompatible(ptr) != 0; } }

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
            ulong totalMemory2,freeMemory2;
			NativeMethods.gpu_DeviceInfo_queryMemory(ptr, out totalMemory2, out freeMemory2);
			totalMemory = (long)totalMemory2;
			freeMemory = (long)freeMemory2;
		}

		public bool Supports(FeatureSet featureSet)
		{
			return NativeMethods.gpu_DeviceInfo_supports(ptr, (int)featureSet) != 0;
		}
	}
}
