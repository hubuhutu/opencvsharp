using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	public class VideoCapture : DisposableCvObject
	{
		[StructLayout(LayoutKind.Explicit)]
		private struct IntBytes
		{
			[FieldOffset(0)]
			public int Value;

			[FieldOffset(0)]
			public readonly byte B1;

			[FieldOffset(1)]
			public readonly byte B2;

			[FieldOffset(2)]
			public readonly byte B3;

			[FieldOffset(3)]
			public readonly byte B4;
		}

		private CaptureType captureType;

		private bool disposed;

		public CaptureType CaptureType {get {return  captureType;}}

		public int PosMsec
		{
			get
			{
				return (int)NativeMethods.highgui_VideoCapture_get(ptr, 0);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 0, value);
			}
		}

		public int PosFrames
		{
			get
			{
				return (int)NativeMethods.highgui_VideoCapture_get(ptr, 1);
			}
			set
			{
				if (captureType == CaptureType.Camera)
				{
					throw new NotSupportedException("Only for video files");
				}
				NativeMethods.highgui_VideoCapture_set(ptr, 1, value);
			}
		}

		public CapturePosAviRatio PosAviRatio
		{
			get
			{
				return (CapturePosAviRatio)NativeMethods.highgui_VideoCapture_get(ptr, 2);
			}
			set
			{
				if (captureType == CaptureType.Camera)
				{
					throw new NotSupportedException("Only for video files");
				}
				NativeMethods.highgui_VideoCapture_set(ptr, 2, (double)value);
			}
		}

		public int FrameWidth
		{
			get
			{
				return (int)NativeMethods.highgui_VideoCapture_get(ptr, 3);
			}
			set
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				NativeMethods.highgui_VideoCapture_set(ptr, 3, value);
			}
		}

		public int FrameHeight
		{
			get
			{
				return (int)NativeMethods.highgui_VideoCapture_get(ptr, 4);
			}
			set
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				NativeMethods.highgui_VideoCapture_set(ptr, 4, value);
			}
		}

		public double Fps
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 5);
			}
			set
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				NativeMethods.highgui_VideoCapture_set(ptr, 5, value);
			}
		}

		public string FourCC
		{
			get
			{
				int value = (int)NativeMethods.highgui_VideoCapture_get(ptr, 6);
				IntBytes intBytes = default(IntBytes);
				intBytes.Value = value;
				IntBytes intBytes2 = intBytes;
				return new string(new char[4]
				{
					Convert.ToChar(intBytes2.B1),
					Convert.ToChar(intBytes2.B2),
					Convert.ToChar(intBytes2.B3),
					Convert.ToChar(intBytes2.B4)
				});
			}
			set
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				if (value.Length != 4)
				{
					throw new ArgumentException("Length of the argument string must be 4");
				}
				byte c = Convert.ToByte(value[0]);
				byte c2 = Convert.ToByte(value[1]);
				byte c3 = Convert.ToByte(value[2]);
				byte c4 = Convert.ToByte(value[3]);
				int num = Cv.FOURCC(c, c2, c3, c4);
				NativeMethods.highgui_VideoCapture_set(ptr, 6, num);
			}
		}

		public int FrameCount {get {return  (int)NativeMethods.highgui_VideoCapture_get(ptr, 7);}}

		public double Brightness
		{
			get
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				return (int)NativeMethods.highgui_VideoCapture_get(ptr, 10);
			}
			set
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				NativeMethods.highgui_VideoCapture_set(ptr, 10, value);
			}
		}

		public double Contrast
		{
			get
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				return (int)NativeMethods.highgui_VideoCapture_get(ptr, 11);
			}
			set
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				NativeMethods.highgui_VideoCapture_set(ptr, 11, value);
			}
		}

		public double Saturation
		{
			get
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				return (int)NativeMethods.highgui_VideoCapture_get(ptr, 12);
			}
			set
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				NativeMethods.highgui_VideoCapture_set(ptr, 12, value);
			}
		}

		public double Hue
		{
			get
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				return (int)NativeMethods.highgui_VideoCapture_get(ptr, 13);
			}
			set
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				NativeMethods.highgui_VideoCapture_set(ptr, 13, value);
			}
		}

		public int Format
		{
			get
			{
				return (int)NativeMethods.highgui_VideoCapture_get(ptr, 8);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 8, value);
			}
		}

		public int Mode
		{
			get
			{
				return (int)NativeMethods.highgui_VideoCapture_get(ptr, 9);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 9, value);
			}
		}

		public double Gain
		{
			get
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				return NativeMethods.highgui_VideoCapture_get(ptr, 14);
			}
			set
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				NativeMethods.highgui_VideoCapture_set(ptr, 14, value);
			}
		}

		public double Exposure
		{
			get
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				return NativeMethods.highgui_VideoCapture_get(ptr, 15);
			}
			set
			{
				if (captureType == CaptureType.File)
				{
					throw new NotSupportedException("Only for cameras");
				}
				NativeMethods.highgui_VideoCapture_set(ptr, 15, value);
			}
		}

		public bool ConvertRgb
		{
			get
			{
				return (int)NativeMethods.highgui_VideoCapture_get(ptr, 16) != 0;
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 16, (!value) ? 1 : 0);
			}
		}

		public double WhiteBalance
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 17);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 17, value);
			}
		}

		public double Rectification
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 18);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 18, value);
			}
		}

		public double Monocrome
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 19);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 19, value);
			}
		}

		public double Sharpness
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 20);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 20, value);
			}
		}

		public double AutoExposure
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 21);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 21, value);
			}
		}

		public double Gamma
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 22);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 22, value);
			}
		}

		public double Temperature
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 23);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 23, value);
			}
		}

		public double Trigger
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 24);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 24, value);
			}
		}

		public double TriggerDelay
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 25);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 25, value);
			}
		}

		public double WhiteBalanceRedV
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 26);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 26, value);
			}
		}

		public double MaxDC1394
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 27);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 27, value);
			}
		}

		public double AutoGrab
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 1024);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 1024, value);
			}
		}

		public unsafe string SupportedPreviewSizesString
		{
			get
			{
				char* value = (char*)(long)NativeMethods.highgui_VideoCapture_get(ptr, 1025);
				return new string(value);
			}
		}

		public unsafe string PreviewFormat
		{
			get
			{
				char* value = (char*)(long)NativeMethods.highgui_VideoCapture_get(ptr, 1026);
				return new string(value);
			}
		}

		public double OpenNI_OutputMode
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 100);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 100, value);
			}
		}

		public double OpenNI_FrameMaxDepth
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 101);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 101, value);
			}
		}

		public double OpenNI_Baseline
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 102);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 102, value);
			}
		}

		public double OpenNI_FocalLength
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 103);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 103, value);
			}
		}

		public double OpenNI_RegistrationON
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 104);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 104, value);
			}
		}

		public double OpenNI_Registratiob
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 104);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 104, value);
			}
		}

		public double OpenNI_ImageGeneratorOutputMode
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, -2147483548);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, -2147483548, value);
			}
		}

		public double OpenNI_DepthGeneratorBaseline
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 102);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 102, value);
			}
		}

		public double OpenNI_DepthGeneratorFocalLength
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 103);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 103, value);
			}
		}

		public double OpenNI_DepthGeneratorRegistrationON
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 104);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 104, value);
			}
		}

		public double GStreamerQueueLength
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 200);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 200, value);
			}
		}

		public double PvAPIMulticastIP
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 300);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 300, value);
			}
		}

		public double XI_Downsampling
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 400);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 400, value);
			}
		}

        public double XI_DataFormat { get { return NativeMethods.highgui_VideoCapture_get(ptr, 401); } }

		public double XI_OffsetX
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 402);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 402, value);
			}
		}

		public double XI_OffsetY
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 403);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 403, value);
			}
		}

		public double XI_TrgSource
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 404);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 404, value);
			}
		}

		public double XI_TrgSoftware
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 405);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 405, value);
			}
		}

		public double XI_GpiSelector
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 406);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 406, value);
			}
		}

		public double XI_GpiMode
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 407);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 407, value);
			}
		}

		public double XI_GpiLevel
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 408);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 408, value);
			}
		}

		public double XI_GpoSelector
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 409);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 409, value);
			}
		}

		public double XI_GpoMode
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 410);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 410, value);
			}
		}

		public double XI_LedSelector
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 411);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 411, value);
			}
		}

		public double XI_LedMode
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 412);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 412, value);
			}
		}

		public double XI_ManualWB
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 413);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 413, value);
			}
		}

		public double XI_AutoWB
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 414);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 414, value);
			}
		}

		public double XI_AEAG
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 415);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 415, value);
			}
		}

		public double XI_ExpPriority
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 416);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 416, value);
			}
		}

		public double XI_AEMaxLimit
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 417);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 417, value);
			}
		}

		public double XI_AGMaxLimit
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 418);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 418, value);
			}
		}

		public double XI_AEAGLevel
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 419);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 419, value);
			}
		}

		public double XI_Timeout
		{
			get
			{
				return NativeMethods.highgui_VideoCapture_get(ptr, 420);
			}
			set
			{
				NativeMethods.highgui_VideoCapture_set(ptr, 420, value);
			}
		}

		public VideoCapture()
		{
			try
			{
				ptr = NativeMethods.highgui_VideoCapture_new();
			}
			catch (AccessViolationException innerException)
			{
				throw new OpenCvSharpException("Failed to create VideoCapture", innerException);
			}
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create VideoCapture");
			}
			captureType = CaptureType.NotSpecified;
		}

		public VideoCapture(int index)
		{
			try
			{
				ptr = NativeMethods.highgui_VideoCapture_new_fromDevice(index);
			}
			catch (AccessViolationException innerException)
			{
				throw new OpenCvSharpException("Failed to create VideoCapture", innerException);
			}
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create VideoCapture");
			}
			captureType = CaptureType.Camera;
		}

		public VideoCapture(CaptureDevice device)
			: this((int)device)
		{
		}

		public VideoCapture(CaptureDevice device, int index)
			: this((int)(device + index))
		{
		}

		public static VideoCapture FromCamera(int index)
		{
			return new VideoCapture(index);
		}

		public static VideoCapture FromCamera(CaptureDevice device)
		{
			return new VideoCapture(device);
		}

		public static VideoCapture FromCamera(CaptureDevice device, int index)
		{
			return new VideoCapture((int)(device + index));
		}

		public VideoCapture(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			ptr = NativeMethods.highgui_VideoCapture_new_fromFile(fileName);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create VideoCapture");
			}
			captureType = CaptureType.File;
		}

		public static VideoCapture FromFile(string fileName)
		{
			return new VideoCapture(fileName);
		}

		protected internal VideoCapture(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.highgui_VideoCapture_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public double Get(CaptureProperty propertyId)
		{
			return NativeMethods.highgui_VideoCapture_get(ptr, (int)propertyId);
		}

		public double Get(int propertyId)
		{
			return NativeMethods.highgui_VideoCapture_get(ptr, propertyId);
		}

		public bool Grab()
		{
			ThrowIfDisposed();
			return NativeMethods.highgui_VideoCapture_grab(ptr) != 0;
		}

		public bool Retrieve(Mat image, int channel = 0)
		{
			ThrowIfDisposed();
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfDisposed();
			return NativeMethods.highgui_VideoCapture_retrieve(ptr, image.CvPtr, channel) != 0;
		}

		public bool Retrieve(Mat image, CameraChannels streamIdx = CameraChannels.Zero)
		{
			ThrowIfDisposed();
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfDisposed();
			return NativeMethods.highgui_VideoCapture_retrieve(ptr, image.CvPtr, (int)streamIdx) != 0;
		}

		public bool Read(Mat image)
		{
			ThrowIfDisposed();
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfDisposed();
			return NativeMethods.highgui_VideoCapture_read(ptr, image.CvPtr) != 0;
		}

		public int Set(CaptureProperty propertyId, double value)
		{
			return NativeMethods.highgui_VideoCapture_set(ptr, (int)propertyId, value);
		}

		public int Set(int propertyId, double value)
		{
			return NativeMethods.highgui_VideoCapture_set(ptr, propertyId, value);
		}

		public void Open(string fileName)
		{
			ThrowIfDisposed();
			NativeMethods.highgui_VideoCapture_open_fromFile(ptr, fileName);
			captureType = CaptureType.File;
		}

		public void Open(int index)
		{
			ThrowIfDisposed();
			try
			{
				NativeMethods.highgui_VideoCapture_open_fromDevice(ptr, index);
			}
			catch (AccessViolationException innerException)
			{
				throw new OpenCvSharpException("Failed to create CvCapture", innerException);
			}
			captureType = CaptureType.Camera;
		}

		public void Open(CaptureDevice device)
		{
			Open((int)device);
		}

		public void Open(CaptureDevice device, int index)
		{
			Open((int)(device + index));
		}

		public void Release()
		{
			ThrowIfDisposed();
			NativeMethods.highgui_VideoCapture_release(ptr);
		}

		public bool IsOpened()
		{
			ThrowIfDisposed();
			return NativeMethods.highgui_VideoCapture_isOpened(ptr) != 0;
		}
	}
}
