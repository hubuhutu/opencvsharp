using System;

namespace OpenCvSharp.CPlusPlus
{
	public class VideoWriter : DisposableCvObject
	{
		private bool disposed;

		public string FileName
		{
			get;
			private set;
		}

		public double Fps
		{
			get;
			private set;
		}

		public Size FrameSize
		{
			get;
			private set;
		}

		public bool IsColor
		{
			get;
			private set;
		}

		public VideoWriter()
		{
			FileName = null;
			Fps = -1.0;
			FrameSize = Size.Zero;
			IsColor = true;
			ptr = NativeMethods.highgui_VideoWriter_new1();
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create VideoWriter");
			}
		}

		public VideoWriter(string fileName, string fourcc, double fps, Size frameSize, bool isColor = true)
			: this(fileName, Cv.FOURCC(fourcc), fps, frameSize, isColor)
		{
		}

		public VideoWriter(string fileName, FourCC fourcc, double fps, Size frameSize, bool isColor = true)
			: this(fileName, (int)fourcc, fps, frameSize, isColor)
		{
		}

		public VideoWriter(string fileName, int fourcc, double fps, Size frameSize, bool isColor = true)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException();
			}
			FileName = fileName;
			Fps = fps;
			FrameSize = frameSize;
			IsColor = isColor;
			ptr = NativeMethods.highgui_VideoWriter_new2(fileName, fourcc, fps, frameSize, isColor ? 1 : 0);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create VideoWriter");
			}
		}

		internal VideoWriter(IntPtr ptr)
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
						NativeMethods.highgui_VideoWriter_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public void Open(string fileName, string fourcc, double fps, Size frameSize, bool isColor = true)
		{
			Open(fileName, Cv.FOURCC(fourcc), fps, frameSize, isColor);
		}

		public void Open(string fileName, FourCC fourcc, double fps, Size frameSize, bool isColor = true)
		{
			Open(fileName, (int)fourcc, fps, frameSize, isColor);
		}

		public void Open(string fileName, int fourcc, double fps, Size frameSize, bool isColor = true)
		{
			ThrowIfDisposed();
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			FileName = fileName;
			Fps = fps;
			FrameSize = frameSize;
			IsColor = isColor;
			NativeMethods.highgui_VideoWriter_open(ptr, fileName, fourcc, fps, frameSize, isColor ? 1 : 0);
		}

		public bool IsOpened()
		{
			ThrowIfDisposed();
			return NativeMethods.highgui_VideoWriter_isOpened(ptr) != 0;
		}

		public void Release()
		{
			ThrowIfDisposed();
			NativeMethods.highgui_VideoWriter_release(ptr);
		}

		public void Write(Mat image)
		{
			ThrowIfDisposed();
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfDisposed();
			NativeMethods.highgui_VideoWriter_write(ptr, image.CvPtr);
		}
	}
}
