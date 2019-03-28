using System;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public static class Cv2Gpu
	{
		public static int GetCudaEnabledDeviceCount()
		{
			return NativeMethods.gpu_getCudaEnabledDeviceCount();
		}

		public static int GetDevice()
		{
			ThrowIfGpuNotAvailable();
			return NativeMethods.gpu_getDevice();
		}

		public static int SetDevice(int device)
		{
			ThrowIfGpuNotAvailable();
			return NativeMethods.gpu_getDevice();
		}

		public static void ResetDevice()
		{
			ThrowIfGpuNotAvailable();
			NativeMethods.gpu_resetDevice();
		}

		public static void PrintCudaDeviceInfo(int device)
		{
			ThrowIfGpuNotAvailable();
			NativeMethods.gpu_printCudaDeviceInfo(device);
		}

		public static void PrintShortCudaDeviceInfo(int device)
		{
			ThrowIfGpuNotAvailable();
			NativeMethods.gpu_printShortCudaDeviceInfo(device);
		}

		public static void RegisterPageLocked(Mat m)
		{
			ThrowIfGpuNotAvailable();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			NativeMethods.gpu_registerPageLocked(m.CvPtr);
		}

		public static void UnregisterPageLocked(Mat m)
		{
			ThrowIfGpuNotAvailable();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			NativeMethods.gpu_unregisterPageLocked(m.CvPtr);
		}

		public static void CreateContinuous(int rows, int cols, MatType type, GpuMat m)
		{
			ThrowIfGpuNotAvailable();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			NativeMethods.gpu_createContinuous1(rows, cols, type, m.CvPtr);
		}

		public static GpuMat CreateContinuous(int rows, int cols, MatType type)
		{
			ThrowIfGpuNotAvailable();
			return new GpuMat(NativeMethods.gpu_createContinuous2(rows, cols, type));
		}

		public static void CreateContinuous(Size size, MatType type, GpuMat m)
		{
			ThrowIfGpuNotAvailable();
			CreateContinuous(size.Height, size.Width, type, m);
		}

		public static GpuMat CreateContinuous(Size size, MatType type)
		{
			ThrowIfGpuNotAvailable();
			return CreateContinuous(size.Height, size.Width, type);
		}

		public static void EnsureSizeIsEnough(int rows, int cols, MatType type, GpuMat m)
		{
			ThrowIfGpuNotAvailable();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			NativeMethods.gpu_ensureSizeIsEnough(rows, cols, type, m.CvPtr);
		}

		public static void EnsureSizeIsEnough(Size size, MatType type, GpuMat m)
		{
			ThrowIfGpuNotAvailable();
			EnsureSizeIsEnough(size.Height, size.Width, type, m);
		}

		public static GpuMat AllocMatFromBuf(int rows, int cols, MatType type, GpuMat mat)
		{
			ThrowIfGpuNotAvailable();
			if (mat == null)
			{
				throw new ArgumentNullException("mat");
			}
			return new GpuMat(NativeMethods.gpu_allocMatFromBuf(rows, cols, type, mat.CvPtr));
		}

		public static void BoxFilter(GpuMat src, GpuMat dst, int ddepth, Size ksize, Point? anchor, Stream stream = null)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
			NativeMethods.gpu_boxFilter(src.CvPtr, dst.CvPtr, ddepth, ksize, valueOrDefault, Cv2.ToPtr(stream));
		}

		public static void Blur(GpuMat src, GpuMat dst, Size ksize, Point? anchor, Stream stream = null)
		{
			BoxFilter(src, dst, -1, ksize, anchor, stream);
		}

		public static void Erode(GpuMat src, GpuMat dst, Mat kernel, Point? anchor = default(Point?), int iterations = 1)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (kernel == null)
			{
				throw new ArgumentNullException("kernel");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			kernel.ThrowIfDisposed();
			Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
			NativeMethods.gpu_erode1(src.CvPtr, dst.CvPtr, kernel.CvPtr, valueOrDefault, iterations);
		}

		public static void Erode(GpuMat src, GpuMat dst, Mat kernel, GpuMat buf, Point? anchor = default(Point?), int iterations = 1, Stream stream = null)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (kernel == null)
			{
				throw new ArgumentNullException("kernel");
			}
			if (buf == null)
			{
				throw new ArgumentNullException("buf");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			kernel.ThrowIfDisposed();
			buf.ThrowIfDisposed();
			Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
			NativeMethods.gpu_erode2(src.CvPtr, dst.CvPtr, kernel.CvPtr, buf.CvPtr, valueOrDefault, iterations, Cv2.ToPtr(stream));
		}

		public static void Dilate(GpuMat src, GpuMat dst, Mat kernel, Point? anchor = default(Point?), int iterations = 1)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (kernel == null)
			{
				throw new ArgumentNullException("kernel");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			kernel.ThrowIfDisposed();
			Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
			NativeMethods.gpu_dilate1(src.CvPtr, dst.CvPtr, kernel.CvPtr, valueOrDefault, iterations);
		}

		public static void Dilate(GpuMat src, GpuMat dst, Mat kernel, GpuMat buf, Point? anchor, int iterations = 1, Stream stream = null)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (kernel == null)
			{
				throw new ArgumentNullException("kernel");
			}
			if (buf == null)
			{
				throw new ArgumentNullException("buf");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			kernel.ThrowIfDisposed();
			buf.ThrowIfDisposed();
			Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
			NativeMethods.gpu_dilate2(src.CvPtr, dst.CvPtr, kernel.CvPtr, buf.CvPtr, valueOrDefault, iterations, Cv2.ToPtr(stream));
		}

		public static void MorphologyEx(GpuMat src, GpuMat dst, MorphologyOperation op, Mat kernel, Point? anchor = default(Point?), int iterations = 1)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (kernel == null)
			{
				throw new ArgumentNullException("kernel");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			kernel.ThrowIfDisposed();
			Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
			NativeMethods.gpu_morphologyEx1(src.CvPtr, dst.CvPtr, (int)op, kernel.CvPtr, valueOrDefault, iterations);
		}

		public static void MorphologyEx(GpuMat src, GpuMat dst, MorphologyOperation op, Mat kernel, GpuMat buf1, GpuMat buf2, Point? anchor = default(Point?), int iterations = 1, Stream stream = null)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (kernel == null)
			{
				throw new ArgumentNullException("kernel");
			}
			if (buf1 == null)
			{
				throw new ArgumentNullException("buf1");
			}
			if (buf2 == null)
			{
				throw new ArgumentNullException("buf2");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			kernel.ThrowIfDisposed();
			buf1.ThrowIfDisposed();
			buf2.ThrowIfDisposed();
			Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
			NativeMethods.gpu_morphologyEx2(src.CvPtr, dst.CvPtr, (int)op, kernel.CvPtr, buf1.CvPtr, buf2.CvPtr, valueOrDefault, iterations, Cv2.ToPtr(stream));
		}

		public static void Filter2D(GpuMat src, GpuMat dst, int ddepth, Mat kernel, Point? anchor, BorderType borderType = BorderType.Reflect101, Stream stream = null)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (kernel == null)
			{
				throw new ArgumentNullException("kernel");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			kernel.ThrowIfDisposed();
			Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
			NativeMethods.gpu_filter2D(src.CvPtr, dst.CvPtr, ddepth, kernel.CvPtr, valueOrDefault, (int)borderType, Cv2.ToPtr(stream));
		}

		public static void SepFilter2D(GpuMat src, GpuMat dst, int ddepth, Mat kernelX, Mat kernelY, Point? anchor = default(Point?), BorderType rowBorderType = BorderType.Reflect101, BorderType columnBorderType = BorderType.Auto)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (kernelX == null)
			{
				throw new ArgumentNullException("kernelX");
			}
			if (kernelY == null)
			{
				throw new ArgumentNullException("kernelY");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			kernelX.ThrowIfDisposed();
			kernelY.ThrowIfDisposed();
			Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
			NativeMethods.gpu_sepFilter2D1(src.CvPtr, dst.CvPtr, ddepth, kernelX.CvPtr, kernelY.CvPtr, valueOrDefault, (int)rowBorderType, (int)columnBorderType);
		}

		public static void SepFilter2D(GpuMat src, GpuMat dst, int ddepth, Mat kernelX, Mat kernelY, GpuMat buf, Point? anchor = default(Point?), BorderType rowBorderType = BorderType.Reflect101, BorderType columnBorderType = BorderType.Auto, Stream stream = null)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (kernelX == null)
			{
				throw new ArgumentNullException("kernelX");
			}
			if (kernelY == null)
			{
				throw new ArgumentNullException("kernelY");
			}
			if (buf == null)
			{
				throw new ArgumentNullException("buf");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			kernelX.ThrowIfDisposed();
			kernelY.ThrowIfDisposed();
			buf.ThrowIfDisposed();
			Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
			NativeMethods.gpu_sepFilter2D2(src.CvPtr, dst.CvPtr, ddepth, kernelX.CvPtr, kernelY.CvPtr, buf.CvPtr, valueOrDefault, (int)rowBorderType, (int)columnBorderType, Cv2.ToPtr(stream));
		}

		public static void Sobel(GpuMat src, GpuMat dst, int ddepth, int dx, int dy, int ksize = 3, double scale = 1.0, BorderType rowBorderType = BorderType.Reflect101, BorderType columnBorderType = BorderType.Auto)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			NativeMethods.gpu_Sobel1(src.CvPtr, dst.CvPtr, ddepth, dx, dy, ksize, scale, (int)rowBorderType, (int)columnBorderType);
		}

		public static void Sobel(GpuMat src, GpuMat dst, int ddepth, int dx, int dy, GpuMat buf, int ksize = 3, double scale = 1.0, BorderType rowBorderType = BorderType.Reflect101, BorderType columnBorderType = BorderType.Auto, Stream stream = null)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (buf == null)
			{
				throw new ArgumentNullException("buf");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			buf.ThrowIfDisposed();
			NativeMethods.gpu_Sobel2(src.CvPtr, dst.CvPtr, ddepth, dx, dy, buf.CvPtr, ksize, scale, (int)rowBorderType, (int)columnBorderType, Cv2.ToPtr(stream));
		}

		public static void Scharr(GpuMat src, GpuMat dst, int ddepth, int dx, int dy, double scale = 1.0, BorderType rowBorderType = BorderType.Reflect101, BorderType columnBorderType = BorderType.Auto)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			NativeMethods.gpu_Scharr1(src.CvPtr, dst.CvPtr, ddepth, dx, dy, scale, (int)rowBorderType, (int)columnBorderType);
		}

		public static void Scharr(GpuMat src, GpuMat dst, int ddepth, int dx, int dy, GpuMat buf, double scale = 1.0, BorderType rowBorderType = BorderType.Reflect101, BorderType columnBorderType = BorderType.Auto, Stream stream = null)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (buf == null)
			{
				throw new ArgumentNullException("buf");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			buf.ThrowIfDisposed();
			NativeMethods.gpu_Scharr2(src.CvPtr, dst.CvPtr, ddepth, dx, dy, buf.CvPtr, scale, (int)rowBorderType, (int)columnBorderType, Cv2.ToPtr(stream));
		}

		public static void GaussianBlur(GpuMat src, GpuMat dst, Size ksize, double sigma1, double sigma2 = 0.0, BorderType rowBorderType = BorderType.Reflect101, BorderType columnBorderType = BorderType.Auto)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			NativeMethods.gpu_GaussianBlur1(src.CvPtr, dst.CvPtr, ksize, sigma1, sigma2, (int)rowBorderType, (int)columnBorderType);
		}

		public static void GaussianBlur(GpuMat src, GpuMat dst, Size ksize, GpuMat buf, double sigma1, double sigma2 = 0.0, BorderType rowBorderType = BorderType.Reflect101, BorderType columnBorderType = BorderType.Auto, Stream stream = null)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (buf == null)
			{
				throw new ArgumentNullException("buf");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			buf.ThrowIfDisposed();
			NativeMethods.gpu_GaussianBlur2(src.CvPtr, dst.CvPtr, ksize, buf.CvPtr, sigma1, sigma2, (int)rowBorderType, (int)columnBorderType, Cv2.ToPtr(stream));
		}

		public static void Laplacian(GpuMat src, GpuMat dst, int ddepth, int ksize = 1, double scale = 1.0, BorderType borderType = BorderType.Reflect101, Stream stream = null)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			NativeMethods.gpu_Laplacian(src.CvPtr, dst.CvPtr, ddepth, ksize, scale, (int)borderType, Cv2.ToPtr(stream));
		}

		public static void MinMaxLoc(GpuMat src, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc, GpuMat mask = null)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			src.ThrowIfDisposed();
			NativeMethods.gpu_minMaxLoc1(src.CvPtr, out minVal, out maxVal, out minLoc, out maxLoc, Cv2.ToPtr(mask));
		}

		public static void MinMaxLoc(GpuMat src, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc, GpuMat mask, GpuMat valbuf, GpuMat locbuf)
		{
			ThrowIfGpuNotAvailable();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (valbuf == null)
			{
				throw new ArgumentNullException("valbuf");
			}
			if (locbuf == null)
			{
				throw new ArgumentNullException("locbuf");
			}
			src.ThrowIfDisposed();
			valbuf.ThrowIfDisposed();
			locbuf.ThrowIfDisposed();
			NativeMethods.gpu_minMaxLoc2(src.CvPtr, out minVal, out maxVal, out minLoc, out maxLoc, Cv2.ToPtr(mask), valbuf.CvPtr, locbuf.CvPtr);
		}

		public static void MatchTemplate(GpuMat image, GpuMat templ, GpuMat result, MatchTemplateMethod method, Stream stream = null)
		{
			ThrowIfGpuNotAvailable();
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			if (templ == null)
			{
				throw new ArgumentNullException("templ");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			image.ThrowIfDisposed();
			templ.ThrowIfDisposed();
			result.ThrowIfDisposed();
			NativeMethods.gpu_matchTemplate1(image.CvPtr, templ.CvPtr, result.CvPtr, (int)method, Cv2.ToPtr(stream));
		}

		public static void ThrowIfGpuNotAvailable()
		{
			if (GetCudaEnabledDeviceCount() < 1)
			{
				throw new OpenCvSharpException("GPU module cannot be used.");
			}
		}
	}
}
