using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace OpenCvSharp
{
	[Serializable]
	public class IplImage : CvArr, ICloneable, ISerializable
	{
		private bool disposed;

		public static readonly int SizeOf = Marshal.SizeOf(typeof(WIplImage));

		[Obsolete]
		public unsafe int Align
		{
			get
			{
				return ((WIplImage*)(void*)ptr)->align;
			}
		}

		[Obsolete]
		public unsafe int AlphaChannel
		{
			get
			{
				return ((WIplImage*)(void*)ptr)->alphaChannel;
			}
		}

		[Obsolete]
		public unsafe IntPtr BorderMode
		{
			get
			{
				return new IntPtr(((WIplImage*)(void*)ptr)->BorderMode);
			}
		}

		[Obsolete]
		public unsafe IntPtr BorderConst
		{
			get
			{
				return new IntPtr(((WIplImage*)(void*)ptr)->BorderConst);
			}
		}

		[Obsolete]
		public unsafe IntPtr ColorModel
		{
			get
			{
				return new IntPtr(((WIplImage*)(void*)ptr)->colorModel);
			}
		}

		[Obsolete]
		public unsafe IntPtr ChannelSeq
		{
			get
			{
				return new IntPtr(((WIplImage*)(void*)ptr)->channelSeq);
			}
		}

		public unsafe int DataOrder { get { return  ((WIplImage*)(void*)ptr)->dataOrder;}}

		public unsafe BitDepth Depth { get { return  (BitDepth)((WIplImage*)(void*)ptr)->depth;}}

		public unsafe int Height { get { return  ((WIplImage*)(void*)ptr)->height;}}

		public unsafe int ID { get { return  ((WIplImage*)(void*)ptr)->ID;}}

		public unsafe IntPtr ImageData { get { return  new IntPtr(((WIplImage*)(void*)ptr)->imageData);}}

		public unsafe byte* ImageDataPtr { get { return  ((WIplImage*)(void*)ptr)->imageData;}}

		public unsafe IntPtr ImageDataOrigin { get { return  new IntPtr(((WIplImage*)(void*)ptr)->imageDataOrigin);}}

		public unsafe int ImageSize { get { return  ((WIplImage*)(void*)ptr)->imageSize;}}

		[Obsolete]
		public unsafe IntPtr MaskROI
		{
			get
			{
				return new IntPtr(((WIplImage*)(void*)ptr)->maskROI);
			}
		}

		public unsafe int NChannels { get { return  ((WIplImage*)(void*)ptr)->nChannels;}}

		public unsafe int NSize { get { return  ((WIplImage*)(void*)ptr)->nSize;}}

		public unsafe ImageOrigin Origin { get { return  (ImageOrigin)((WIplImage*)(void*)ptr)->origin;}}

		public unsafe IntPtr ROIPointer { get { return  new IntPtr(((WIplImage*)(void*)ptr)->roi);}}

		public unsafe IplROI ROIValue { get { return  (IplROI)Marshal.PtrToStructure(new IntPtr(((WIplImage*)(void*)ptr)->roi), typeof(IplROI));}}

		public unsafe int Width { get { return  ((WIplImage*)(void*)ptr)->width;}}

		public unsafe int WidthStep { get { return  ((WIplImage*)(void*)ptr)->widthStep;}}

		public unsafe IntPtr TileInfo { get { return  new IntPtr(((WIplImage*)(void*)ptr)->tileInfo);}}

		public unsafe CvSize Size
		{
			get
			{
				WIplImage* ptr = (WIplImage*)(void*)base.ptr;
				return new CvSize(ptr->width, ptr->height);
			}
		}

		public int COI
		{
			get
			{
				return Cv.GetImageCOI(this);
			}
			set
			{
				Cv.SetImageCOI(this, value);
			}
		}

		public CvRect ROI
		{
			get
			{
				return Cv.GetImageROI(this);
			}
			set
			{
				Cv.SetImageROI(this, value);
			}
		}

		public override int Dims { get { return  2;}}

		public unsafe int Bpp
		{
			get
			{
				WIplImage* ptr = (WIplImage*)(void*)base.ptr;
				return (ptr->depth & 0xFF) * ptr->nChannels;
			}
		}

		public IplImage()
			: this(isEnabledDispose: true)
		{
		}

		public IplImage(bool isEnabledDispose)
			: base(isEnabledDispose)
		{
			ptr = AllocMemory(SizeOf);
		}

		public IplImage(string fileName)
			: this(fileName, LoadMode.Color)
		{
		}

		public IplImage(string fileName, LoadMode flags)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(string.Format("Not found '{0}'", fileName));
			}
			ptr = NativeMethods.cvLoadImage(fileName, flags);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create IplImage");
			}
		}

		public IplImage(CvSize size, BitDepth depth, int channels)
		{
			ptr = NativeMethods.cvCreateImage(size, depth, channels);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create IplImage");
			}
		}

		public IplImage(int width, int height, BitDepth depth, int channels)
			: this(new CvSize(width, height), depth, channels)
		{
		}

		public IplImage(IntPtr ptr)
			: this(ptr, isEnabledDispose: true)
		{
		}

		public IplImage(IntPtr ptr, bool isEnabledDispose)
			: base(isEnabledDispose)
		{
			base.ptr = ptr;
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose && (!(base.AllocatedMemory != IntPtr.Zero) || base.AllocatedMemorySize == 0L))
					{
						NativeMethods.cvReleaseImage(ref ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static IplImage FromFile(string fileName)
		{
			return FromFile(fileName, LoadMode.Color);
		}

		public static IplImage FromFile(string fileName, LoadMode flags)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException("", fileName);
			}
			IntPtr intPtr = NativeMethods.cvLoadImage(fileName, flags);
			if (intPtr != IntPtr.Zero)
			{
				return new IplImage(intPtr);
			}
			byte[] array = File.ReadAllBytes(fileName);
			using (CvMat buf = new CvMat(array.Length, 1, MatrixType.S8C1, array))
			{
				return Cv.DecodeImage(buf, flags);
			}
		}

		public static IplImage FromImageData(byte[] bytes, LoadMode mode)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			using (CvMat buf = new CvMat(bytes.Length, 1, MatrixType.U8C1, bytes, copyData: false))
			{
				return Cv.DecodeImage(buf, mode);
			}
		}

		public static IplImage FromStream(Stream stream, LoadMode mode)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (stream.Length > int.MaxValue)
			{
				throw new ArgumentException("Not supported stream (too long)");
			}
			byte[] array = new byte[stream.Length];
			long position = stream.Position;
			stream.Position = 0L;
			stream.Read(array, 0, array.Length);
			stream.Position = position;
			return FromImageData(array, mode);
		}

		public static IplImage FromPixelData(CvSize size, int channels, IntPtr data)
		{
			return FromPixelData(size.Width, size.Height, channels, data);
		}

		public static IplImage FromPixelData(int width, int height, int channels, IntPtr data)
		{
			if (data == IntPtr.Zero)
			{
				throw new ArgumentNullException("data");
			}
			IplImage iplImage = new IplImage(width, height, BitDepth.U8, channels);
			Util.CopyMemory(iplImage.ImageData, data, iplImage.ImageSize);
			return iplImage;
		}

		public static IplImage FromPixelData(CvSize size, BitDepth depth, int channels, Array data)
		{
			return FromPixelData(size.Width, size.Height, depth, channels, data);
		}

		public static IplImage FromPixelData(int width, int height, BitDepth depth, int channels, Array data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			IplImage iplImage = new IplImage(width, height, depth, channels);
			using (ScopedGCHandle scopedGCHandle = ScopedGCHandle.Alloc(data, GCHandleType.Pinned))
			{
				Util.CopyMemory(iplImage.ImageData, scopedGCHandle.AddrOfPinnedObject(), iplImage.ImageSize);
				return iplImage;
			}
		}

		public static IplImage FromPixelData(CvSize size, int channels, byte[] data)
		{
			return FromPixelData(size.Width, size.Height, channels, data);
		}

		public static IplImage FromPixelData(int width, int height, int channels, byte[] data)
		{
			return FromPixelData(width, height, BitDepth.U8, channels, data);
		}

		public static IplImage FromPixelData(CvSize size, int channels, short[] data)
		{
			return FromPixelData(size.Width, size.Height, channels, data);
		}

		public static IplImage FromPixelData(int width, int height, int channels, short[] data)
		{
			return FromPixelData(width, height, BitDepth.U16, channels, data);
		}

		public static IplImage operator +(IplImage a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			return a.Clone();
		}

		public static IplImage operator -(IplImage a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			IplImage iplImage = a.Clone();
			Cv.AddWeighted(a, -1.0, a, 0.0, 0.0, iplImage);
			return iplImage;
		}

		public static IplImage operator ~(IplImage a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			IplImage iplImage = a.Clone();
			Cv.Not(a, iplImage);
			return iplImage;
		}

		public static IplImage operator +(IplImage a, IplImage b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			IplImage iplImage = a.Clone();
			Cv.Add(a, b, iplImage);
			return iplImage;
		}

		public static IplImage operator +(IplImage a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			IplImage iplImage = a.Clone();
			Cv.AddS(a, b, iplImage);
			return iplImage;
		}

		public static IplImage operator -(IplImage a, IplImage b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			IplImage iplImage = a.Clone();
			Cv.Sub(a, b, iplImage);
			return iplImage;
		}

		public static IplImage operator -(IplImage a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			IplImage iplImage = a.Clone();
			Cv.SubS(a, b, iplImage);
			return iplImage;
		}

		public static IplImage operator *(IplImage a, IplImage b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (a.ElemType != b.ElemType)
			{
				throw new ArgumentException("a.ElemType must equal to b.ElemType");
			}
			if (a.Width != b.Height)
			{
				throw new ArgumentException("a.Width must equal to b.Height");
			}
			IplImage iplImage = new IplImage(b.Width, a.Height, a.Depth, a.NChannels);
			Cv.MatMul(a, b, iplImage);
			return iplImage;
		}

		public static IplImage operator *(IplImage a, double b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			IplImage iplImage = a.Clone();
			Cv.AddWeighted(a, b, a, 0.0, 0.0, iplImage);
			return iplImage;
		}

		public static IplImage operator /(IplImage a, double b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (Math.Abs(b - 0.0) < 1E-15)
			{
				throw new DivideByZeroException();
			}
			IplImage iplImage = a.Clone();
			Cv.AddWeighted(a, 1.0 / b, a, 0.0, 0.0, iplImage);
			return iplImage;
		}

		public static IplImage operator &(IplImage a, IplImage b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			IplImage iplImage = a.Clone();
			Cv.And(a, b, iplImage);
			return iplImage;
		}

		public static IplImage operator &(IplImage a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			IplImage iplImage = a.Clone();
			Cv.AndS(a, b, iplImage);
			return iplImage;
		}

		public static IplImage operator |(IplImage a, IplImage b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			IplImage iplImage = a.Clone();
			Cv.Or(a, b, iplImage);
			return iplImage;
		}

		public static IplImage operator |(IplImage a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			IplImage iplImage = a.Clone();
			Cv.OrS(a, b, iplImage);
			return iplImage;
		}

		public static IplImage operator ^(IplImage a, IplImage b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			IplImage iplImage = a.Clone();
			Cv.Xor(a, b, iplImage);
			return iplImage;
		}

		public static IplImage operator ^(IplImage a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			IplImage iplImage = a.Clone();
			Cv.XorS(a, b, iplImage);
			return iplImage;
		}

		public int CheckChessboard(CvSize size)
		{
			return Cv.CheckChessboard(this, size);
		}

		public IplImage Clone()
		{
			return Cv.CloneImage(this);
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public IplImage Clone(CvRect roi)
		{
			if (roi.X < 0 || roi.Y < 0 || roi.X + roi.Width > Width || roi.Y + roi.Height > Height)
			{
				throw new ArgumentException("roi is out of image size", "roi");
			}
			if (roi.X == 0 && roi.Y == 0 && roi.Size == Size)
			{
				return Cv.CloneImage(this);
			}
			IplImage iplImage = new IplImage(roi.Size, Depth, NChannels);
			CvRect rOI = ROI;
			SetROI(roi);
			Cv.Copy(this, iplImage);
			SetROI(rOI);
			return iplImage;
		}

		public IplImage EmptyClone()
		{
			return new IplImage(Size, Depth, NChannels);
		}

		public static IplImage CreateHeader(CvSize size, BitDepth depth, int channels)
		{
			return Cv.CreateImageHeader(size, depth, channels);
		}

		public void DeleteMoire()
		{
			Cv.DeleteMoire(this);
		}

		public CvSeq<CvFaceData> FindFace(CvMemStorage storage)
		{
			return Cv.FindFace(this, storage);
		}

		public int GetCOI()
		{
			return Cv.GetImageCOI(this);
		}

		public CvRect GetROI()
		{
			return Cv.GetImageROI(this);
		}

		public unsafe UnmanagedMemoryStream GetDataStream(string ext, int[] prms)
		{
			return new UnmanagedMemoryStream(ImageDataPtr, Width * Height);
		}

		public static IplImage InitImageHeader(CvSize size, BitDepth depth, int channels)
		{
			IplImage image;
			return Cv.InitImageHeader(out image, size, depth, channels);
		}

		public static IplImage InitImageHeader(CvSize size, BitDepth depth, int channels, ImageOrigin origin)
		{
			IplImage image;
			return Cv.InitImageHeader(out image, size, depth, channels, origin);
		}

		public static IplImage InitImageHeader(CvSize size, BitDepth depth, int channels, ImageOrigin origin, int align)
		{
			IplImage image;
			return Cv.InitImageHeader(out image, size, depth, channels, origin, align);
		}

		public CvSeq<CvFaceData> PostBoostingFindFace(CvMemStorage storage)
		{
			return Cv.PostBoostingFindFace(this, storage);
		}

		public void PyrSegmentation(IplImage dst, int level, double threshold1, double threshold2)
		{
			Cv.PyrSegmentation(this, dst, level, threshold1, threshold2);
		}

		public void PyrSegmentation(IplImage dst, CvMemStorage storage, out CvSeq comp, int level, double threshold1, double threshold2)
		{
			Cv.PyrSegmentation(this, dst, storage, out comp, level, threshold1, threshold2);
		}

		public void ResetROI()
		{
			Cv.ResetImageROI(this);
		}

		public void SetImageCOI(int coi)
		{
			Cv.SetImageCOI(this, coi);
		}

		public void SetROI(CvRect rect)
		{
			Cv.SetImageROI(this, rect);
		}

		public void SetROI(int x, int y, int width, int height)
		{
			Cv.SetImageROI(this, new CvRect(x, y, width, height));
		}

		public void SnakeImage(CvPoint[] points, float alpha, float beta, float gamma, CvSize win, CvTermCriteria criteria)
		{
			Cv.SnakeImage(this, points, alpha, beta, gamma, win, criteria);
		}

		public void SnakeImage(CvPoint[] points, float alpha, float beta, float gamma, CvSize win, CvTermCriteria criteria, bool calcGradient)
		{
			Cv.SnakeImage(this, points, alpha, beta, gamma, win, criteria, calcGradient);
		}

		public void SnakeImage(CvPoint[] points, float[] alpha, float[] beta, float[] gamma, CvSize win, CvTermCriteria criteria)
		{
			Cv.SnakeImage(this, points, alpha, beta, gamma, win, criteria);
		}

		public void SnakeImage(CvPoint[] points, float[] alpha, float[] beta, float[] gamma, CvSize win, CvTermCriteria criteria, bool calcGradient)
		{
			Cv.SnakeImage(this, points, alpha, beta, gamma, win, criteria, calcGradient);
		}

		public IplImage[] Split()
		{
			List<IplImage> list = new List<IplImage>(4);
			int width = ROI.Width;
			int height = ROI.Height;
			for (int i = 1; i <= 4; i++)
			{
				if (i <= NChannels)
				{
					list.Add(new IplImage(width, height, Depth, 1));
				}
				else
				{
					list.Add(null);
				}
			}
			Cv.Split(this, list[0], list[1], list[2], list[3]);
			list.RemoveAll((IplImage obj) =>  obj == null);
			return list.ToArray();
		}

		public IplImage Transpose()
		{
			IplImage iplImage = new IplImage(Height, Width, Depth, NChannels);
			Cv.Transpose(this, iplImage);
			return iplImage;
		}

		public IplImage T()
		{
			return Transpose();
		}

		public void CopyPixelData(Array data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			using (ScopedGCHandle scopedGCHandle = ScopedGCHandle.Alloc(data, GCHandleType.Pinned))
			{
				CopyPixelData(scopedGCHandle.AddrOfPinnedObject());
			}
		}

		public void CopyPixelData(IntPtr data)
		{
			if (data == IntPtr.Zero)
			{
				throw new ArgumentNullException("data");
			}
			Util.CopyMemory(ImageData, data, ImageSize);
		}

		public IplImage GetSubImage(CvRect rect)
		{
			if (rect.Width < 0)
			{
				throw new ArgumentException();
			}
			if (rect.Height < 0)
			{
				throw new ArgumentException();
			}
			if (rect.X + rect.Width >= Width)
			{
				rect.Width = Width - rect.X - 1;
			}
			if (rect.Y + rect.Height >= Height)
			{
				rect.Height = Height - rect.Y - 1;
			}
			if (rect.X < 0)
			{
				rect.Width += rect.X;
				rect.X = 0;
			}
			if (rect.Y < 0)
			{
				rect.Height += rect.Y;
				rect.Y = 0;
			}
			IplImage iplImage = new IplImage(rect.Size, Depth, NChannels);
			SetROI(rect);
			Cv.Copy(this, iplImage);
			ResetROI();
			return iplImage;
		}

		public void DrawImage(CvRect roi, CvArr image)
		{
			CvRect imageROI = Cv.GetImageROI(this);
			Cv.SetImageROI(this, roi);
			Cv.Copy(image, this);
			Cv.SetImageROI(this, imageROI);
		}

		public void DrawImage(int x, int y, int width, int height, CvArr image)
		{
			DrawImage(new CvRect(x, y, width, height), image);
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			info.AddValue("Size", Size);
			info.AddValue("Depth", Depth);
			info.AddValue("ROI", ROI);
			info.AddValue("COI", COI);
			info.AddValue("NChannels", NChannels);
			byte[] array = new byte[524288];
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress))
				{
					for (int i = 0; i < ImageSize; i += 524288)
					{
						int num = (i + 524288 < ImageSize) ? 524288 : (ImageSize - i);
						Marshal.Copy(new IntPtr(ImageData.ToInt64() + i), array, 0, num);
						deflateStream.Write(array, 0, num);
					}
					info.AddValue("ImageData", memoryStream.ToArray());
				}
			}
		}

		protected IplImage(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			CvSize size = (CvSize)info.GetValue("Size", typeof(CvSize));
			BitDepth depth = (BitDepth)info.GetValue("Depth", typeof(BitDepth));
			int @int = info.GetInt32("NChannels");
			CvRect rOI = (CvRect)info.GetValue("ROI", typeof(CvRect));
			int int2 = info.GetInt32("COI");
			byte[] buffer = (byte[])info.GetValue("ImageData", typeof(byte[]));
			ptr = NativeMethods.cvCreateImage(size, depth, @int);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create IplImage");
			}
			ROI = rOI;
			COI = int2;
			byte[] array = new byte[524288];
			IntPtr destination = ImageData;
			using (MemoryStream stream = new MemoryStream(buffer))
			{
				using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress))
				{
					while (true)
					{
						int num = deflateStream.Read(array, 0, array.Length);
						if (num == 0)
						{
							break;
						}
						Marshal.Copy(array, 0, destination, num);
						destination = new IntPtr(destination.ToInt64() + num);
					}
				}
			}
		}
	}
}
