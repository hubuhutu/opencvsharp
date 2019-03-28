using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
	public class CvMat : CvArr, ICloneable, IEnumerable<CvScalar>, IEnumerable
	{
		private bool disposed;

		private PointerAccessor1D_Byte dataArrayByte;

		private PointerAccessor1D_Int16 dataArrayInt16;

		private PointerAccessor1D_Int32 dataArrayInt32;

		private PointerAccessor1D_Single dataArraySingle;

		private PointerAccessor1D_Double dataArrayDouble;

		public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvMat));

		public unsafe int Type
		{
			get
			{
				return ((WCvMat*)(void*)ptr)->type;
			}
			set
			{
				((WCvMat*)(void*)ptr)->type = value;
			}
		}

		public unsafe int Step
		{
			get
			{
				return ((WCvMat*)(void*)ptr)->step;
			}
			set
			{
				((WCvMat*)(void*)ptr)->step = value;
			}
		}

		public unsafe IntPtr Data
		{
			get
			{
				return new IntPtr(((WCvMat*)(void*)ptr)->data);
			}
			set
			{
				((WCvMat*)(void*)ptr)->data = value.ToPointer();
			}
		}

		public unsafe byte* DataByte
		{
			get
			{
				return (byte*)((WCvMat*)(void*)ptr)->data;
			}
			set
			{
				((WCvMat*)(void*)ptr)->data = value;
			}
		}

		public unsafe short* DataInt16
		{
			get
			{
				return (short*)((WCvMat*)(void*)ptr)->data;
			}
			set
			{
				((WCvMat*)(void*)ptr)->data = value;
			}
		}

		public unsafe int* DataInt32
		{
			get
			{
				return (int*)((WCvMat*)(void*)ptr)->data;
			}
			set
			{
				((WCvMat*)(void*)ptr)->data = value;
			}
		}

		public unsafe float* DataSingle
		{
			get
			{
				return (float*)((WCvMat*)(void*)ptr)->data;
			}
			set
			{
				((WCvMat*)(void*)ptr)->data = value;
			}
		}

		public unsafe double* DataDouble
		{
			get
			{
				return (double*)((WCvMat*)(void*)ptr)->data;
			}
			set
			{
				((WCvMat*)(void*)ptr)->data = value;
			}
		}

		public unsafe PointerAccessor1D_Byte DataArrayByte
		{
			get
			{
				if (dataArrayByte == null)
				{
					byte* data = (byte*)((WCvMat*)(void*)ptr)->data;
					dataArrayByte = new PointerAccessor1D_Byte(data);
				}
				return dataArrayByte;
			}
		}

		public unsafe PointerAccessor1D_Int16 DataArrayInt16
		{
			get
			{
				if (dataArrayInt16 == null)
				{
					short* data = (short*)((WCvMat*)(void*)ptr)->data;
					dataArrayInt16 = new PointerAccessor1D_Int16(data);
				}
				return dataArrayInt16;
			}
		}

		public unsafe PointerAccessor1D_Int32 DataArrayInt32
		{
			get
			{
				if (dataArrayInt32 == null)
				{
					int* data = (int*)((WCvMat*)(void*)ptr)->data;
					dataArrayInt32 = new PointerAccessor1D_Int32(data);
				}
				return dataArrayInt32;
			}
		}

		public unsafe PointerAccessor1D_Single DataArraySingle
		{
			get
			{
				if (dataArraySingle == null)
				{
					float* data = (float*)((WCvMat*)(void*)ptr)->data;
					dataArraySingle = new PointerAccessor1D_Single(data);
				}
				return dataArraySingle;
			}
		}

		public unsafe PointerAccessor1D_Double DataArrayDouble
		{
			get
			{
				if (dataArrayDouble == null)
				{
					double* data = (double*)((WCvMat*)(void*)ptr)->data;
					dataArrayDouble = new PointerAccessor1D_Double(data);
				}
				return dataArrayDouble;
			}
		}

		public unsafe int Cols
		{
			get
			{
				return ((WCvMat*)(void*)ptr)->cols;
			}
			set
			{
				((WCvMat*)(void*)ptr)->cols = value;
			}
		}

		public unsafe int Height
		{
			get
			{
				return ((WCvMat*)(void*)ptr)->rows;
			}
			set
			{
				((WCvMat*)(void*)ptr)->rows = value;
			}
		}

		public unsafe int Rows
		{
			get
			{
				return ((WCvMat*)(void*)ptr)->rows;
			}
			set
			{
				((WCvMat*)(void*)ptr)->rows = value;
			}
		}

		public unsafe int Width
		{
			get
			{
				return ((WCvMat*)(void*)ptr)->cols;
			}
			set
			{
				((WCvMat*)(void*)ptr)->cols = value;
			}
		}

		public unsafe IntPtr RefCount
		{
			get
			{
				return new IntPtr(((WCvMat*)(void*)ptr)->refcount);
			}
			internal set
			{
				((WCvMat*)(void*)ptr)->refcount = (int*)(void*)value;
			}
		}

		public override int Dims => 2;

		public new double this[int row, int col]
		{
			get
			{
				return Cv.mGet(this, row, col);
			}
			set
			{
				Cv.mSet(this, row, col, value);
			}
		}

		public CvMat(int rows, int cols, MatrixType type)
		{
			ptr = NativeMethods.cvCreateMat(rows, cols, type);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create CvMat");
			}
		}

		public CvMat(int rows, int cols, MatrixType type, Array elements)
			: this(rows, cols, type, elements, copyData: false)
		{
		}

		public CvMat(int rows, int cols, MatrixType type, Array elements, bool copyData)
		{
			ptr = NativeMethods.cvCreateMatHeader(rows, cols, type);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create CvMat");
			}
			Array obj = (!copyData) ? elements : ((Array)elements.Clone());
			GCHandle gCHandle = AllocGCHandle(obj);
			NativeMethods.cvSetData(ptr, gCHandle.AddrOfPinnedObject(), int.MaxValue);
		}

		public CvMat(int rows, int cols, MatrixType type, IntPtr data)
			: this(rows, cols, type)
		{
			ptr = NativeMethods.cvCreateMatHeader(rows, cols, type);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create CvMat");
			}
			NativeMethods.cvSetData(ptr, data, int.MaxValue);
		}

		public CvMat(int rows, int cols, MatrixType type, CvScalar value)
		{
			ptr = NativeMethods.cvCreateMat(rows, cols, type);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create CvMat");
			}
			NativeMethods.cvSet(ptr, value, IntPtr.Zero);
		}

		public CvMat(string filename)
			: this(filename, LoadMode.Color)
		{
		}

		public CvMat(string filename, LoadMode flags)
		{
			if (string.IsNullOrEmpty(filename))
			{
				throw new ArgumentNullException("filename");
			}
			if (!File.Exists(filename))
			{
				throw new FileNotFoundException("", filename);
			}
			ptr = NativeMethods.cvLoadImageM(filename, flags);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create CvMat");
			}
		}

		public CvMat(IntPtr ptr)
			: this(ptr, isEnabledDispose: true)
		{
		}

		public CvMat(IntPtr p, bool isEnabledDispose)
			: base(isEnabledDispose)
		{
			ptr = p;
		}

		public unsafe CvMat(bool isEnabledDispose)
			: base(isEnabledDispose)
		{
			base.ptr = AllocMemory(SizeOf);
			WCvMat* ptr = (WCvMat*)(void*)base.ptr;
			ptr->type = 1111638016;
			ptr->refcount = null;
			ptr->hdr_refcount = 0;
		}

		public static CvMat FromArray(double[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return new CvMat(data.GetLength(0), 1, MatrixType.F64C1, data);
		}

		public static CvMat FromArray(float[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.F32C1, data);
		}

		public static CvMat FromArray(int[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.S32C1, data);
		}

		public static CvMat FromArray(short[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.S16C1, data);
		}

		public static CvMat FromArray(byte[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.U8C1, data);
		}

		public static CvMat FromArray<T>(T[] data, MatrixType type) where T : struct
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return new CvMat(data.GetLength(0), data.GetLength(1), type, data);
		}

		public static CvMat FromArray(double[,] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.F64C1, data);
		}

		public static CvMat FromArray(float[,] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.F32C1, data);
		}

		public static CvMat FromArray(int[,] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.S32C1, data);
		}

		public static CvMat FromArray(short[,] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.S16C1, data);
		}

		public static CvMat FromArray(byte[,] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.U8C1, data);
		}

		public static CvMat FromArray<T>(T[,] data, MatrixType type) where T : struct
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return new CvMat(data.GetLength(0), data.GetLength(1), type, data);
		}

		private static T[] ToLinearArtay<T>(T[,] array)
		{
			int length = array.GetLength(0);
			int length2 = array.GetLength(1);
			T[] array2 = new T[length * length2];
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					array2[i * length2 + j] = array[i, j];
				}
			}
			return array2;
		}

		public static CvMat FromFile(string filename)
		{
			return Cv.LoadImageM(filename);
		}

		public static CvMat LoadImageM(string filename, LoadMode flags)
		{
			return Cv.LoadImageM(filename, flags);
		}

		public static CvMat FromImageData(byte[] bytes, LoadMode mode)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			using (CvMat buf = new CvMat(bytes.Length, 1, MatrixType.U8C1, bytes, copyData: false))
			{
				return Cv.DecodeImageM(buf, mode);
			}
		}

		public static CvMat FromStream(Stream stream, LoadMode mode)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return FromImageData(array, mode);
		}

		public static CvMat AffineTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst)
		{
			return Cv.GetAffineTransform(src, dst);
		}

		public static CvMat PerspectiveTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst)
		{
			return Cv.GetPerspectiveTransform(src, dst);
		}

		public static CvMat Identity(int rows, int cols, MatrixType type)
		{
			return Identity(rows, cols, type, CvScalar.RealScalar(1.0));
		}

		public static CvMat Identity(int rows, int cols, MatrixType type, CvScalar value)
		{
			IntPtr intPtr = NativeMethods.cvCreateMatHeader(rows, cols, type);
			NativeMethods.cvCreateData(intPtr);
			NativeMethods.cvSetIdentity(intPtr, value);
			return new CvMat(intPtr);
		}

		public static CvMat RotationMatrix(CvPoint2D32f center, double angle, double scale)
		{
			return Cv._2DRotationMatrix(center, angle, scale);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.cvReleaseMat(ref ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static CvMat operator +(CvMat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			return a.Clone();
		}

		public static CvMat operator -(CvMat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMat cvMat = a.Clone();
			Cv.AddWeighted(a, -1.0, a, 0.0, 0.0, cvMat);
			return cvMat;
		}

		public static CvMat operator ~(CvMat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMat cvMat = a.Clone();
			Cv.Not(a, cvMat);
			return cvMat;
		}

		public static CvMat operator +(CvMat a, CvMat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvMat cvMat = a.Clone();
			Cv.Add(a, b, cvMat);
			return cvMat;
		}

		public static CvMat operator +(CvMat a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMat cvMat = a.Clone();
			Cv.AddS(a, b, cvMat);
			return cvMat;
		}

		public static CvMat operator -(CvMat a, CvMat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvMat cvMat = a.Clone();
			Cv.Sub(a, b, cvMat);
			return cvMat;
		}

		public static CvMat operator -(CvMat a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMat cvMat = a.Clone();
			Cv.SubS(a, b, cvMat);
			return cvMat;
		}

		public static CvMat operator *(CvMat a, CvMat b)
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
			if (a.Cols != b.Rows)
			{
				throw new ArgumentException("a.Cols must equal to b.Rows");
			}
			CvMat cvMat = new CvMat(a.Rows, b.Cols, a.ElemType);
			Cv.MatMul(a, b, cvMat);
			return cvMat;
		}

		public static CvMat operator *(CvMat a, double b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMat cvMat = a.Clone();
			Cv.AddWeighted(a, b, a, 0.0, 0.0, cvMat);
			return cvMat;
		}

		public static CvMat operator *(double a, CvMat b)
		{
			return b * a;
		}

		public static CvMat operator /(CvMat a, double b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == 0.0)
			{
				throw new DivideByZeroException();
			}
			CvMat cvMat = a.Clone();
			Cv.AddWeighted(a, 1.0 / b, a, 0.0, 0.0, cvMat);
			return cvMat;
		}

		public static CvMat operator &(CvMat a, CvMat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvMat cvMat = a.Clone();
			Cv.And(a, b, cvMat);
			return cvMat;
		}

		public static CvMat operator &(CvMat a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMat cvMat = a.Clone();
			Cv.AndS(a, b, cvMat);
			return cvMat;
		}

		public static CvMat operator |(CvMat a, CvMat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvMat cvMat = a.Clone();
			Cv.Or(a, b, cvMat);
			return cvMat;
		}

		public static CvMat operator |(CvMat a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMat cvMat = a.Clone();
			Cv.OrS(a, b, cvMat);
			return cvMat;
		}

		public static CvMat operator ^(CvMat a, CvMat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			CvMat cvMat = a.Clone();
			Cv.Xor(a, b, cvMat);
			return cvMat;
		}

		public static CvMat operator ^(CvMat a, CvScalar b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			CvMat cvMat = a.Clone();
			Cv.XorS(a, b, cvMat);
			return cvMat;
		}

		public void CalibrationMatrixValues(CvSize imageSize)
		{
			Cv.CalibrationMatrixValues(this, imageSize);
		}

		public void CalibrationMatrixValues(CvSize imageSize, double apertureWidth, double apertureHeight)
		{
			Cv.CalibrationMatrixValues(this, imageSize, apertureWidth, apertureHeight);
		}

		public void CalibrationMatrixValues(CvSize imageSize, double apertureWidth, double apertureHeight, out double fovx, out double fovy)
		{
			Cv.CalibrationMatrixValues(this, imageSize, apertureWidth, apertureHeight, out fovx, out fovy);
		}

		public void CalibrationMatrixValues(CvSize imageSize, double apertureWidth, double apertureHeight, out double fovx, out double fovy, out double focalLength)
		{
			Cv.CalibrationMatrixValues(this, imageSize, apertureWidth, apertureHeight, out fovx, out fovy, out focalLength);
		}

		public void CalibrationMatrixValues(CvSize imageSize, double apertureWidth, double apertureHeight, out double fovx, out double fovy, out double focalLength, out CvPoint2D64f principalPoint)
		{
			Cv.CalibrationMatrixValues(this, imageSize, apertureWidth, apertureHeight, out fovx, out fovy, out focalLength, out principalPoint);
		}

		public void CalibrationMatrixValues(CvSize imageSize, double apertureWidth, double apertureHeight, out double fovx, out double fovy, out double focalLength, out CvPoint2D64f principalPoint, out double pixelAspectRatio)
		{
			Cv.CalibrationMatrixValues(this, imageSize, apertureWidth, apertureHeight, out fovx, out fovy, out focalLength, out principalPoint, out pixelAspectRatio);
		}

		public CvMat Clone()
		{
			return Cv.CloneMat(this);
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public CvMat EmptyClone()
		{
			return new CvMat(Rows, Cols, (MatrixType)Type);
		}

		public void CompleteSymm()
		{
			Cv.CompleteSymm(this);
		}

		public void CompleteSymm(bool LtoR)
		{
			Cv.CompleteSymm(this, LtoR);
		}

		public void ComputeCorrespondEpilines(int whichImage, CvMat fundamentalMatrix, out CvMat correspondentLines)
		{
			Cv.ComputeCorrespondEpilines(this, whichImage, fundamentalMatrix, out correspondentLines);
		}

		public void ConvertPointsHomogenious(CvMat dst)
		{
			Cv.ConvertPointsHomogenious(this, dst);
		}

		public void ConvertPointsHomogeneous(CvMat dst)
		{
			Cv.ConvertPointsHomogeneous(this, dst);
		}

		public IplImage DecodeImage(LoadMode iscolor)
		{
			return Cv.DecodeImage(this, iscolor);
		}

		public CvMat DecodeImageM(LoadMode iscolor)
		{
			return Cv.DecodeImageM(this, iscolor);
		}

		public void DecomposeProjectionMatrix(CvMat calibMatr, CvMat rotMatr, CvMat posVect)
		{
			Cv.DecomposeProjectionMatrix(this, calibMatr, rotMatr, posVect);
		}

		public void DecomposeProjectionMatrix(CvMat calibMatr, CvMat rotMatr, CvMat posVect, CvMat rotMatrX, CvMat rotMatrY, CvMat rotMatrZ)
		{
			Cv.DecomposeProjectionMatrix(this, calibMatr, rotMatr, posVect, rotMatrX, rotMatrY, rotMatrZ);
		}

		public void DecomposeProjectionMatrix(CvMat calibMatr, CvMat rotMatr, CvMat posVect, CvMat rotMatrX, CvMat rotMatrY, CvMat rotMatrZ, out CvPoint3D64f eulerAngles)
		{
			Cv.DecomposeProjectionMatrix(this, calibMatr, rotMatr, posVect, rotMatrX, rotMatrY, rotMatrZ, out eulerAngles);
		}

		public CvMat EncodeImage(string ext, int[] prms)
		{
			return Cv.EncodeImage(ext, this, prms);
		}

		public CvMat EncodeImage(string ext, params ImageEncodingParam[] prms)
		{
			return Cv.EncodeImage(ext, this, prms);
		}

		public unsafe UnmanagedMemoryStream GetDataStream()
		{
			return new UnmanagedMemoryStream(DataByte, Rows * Step);
		}

		public CvMat InitMatHeader(int rows, int cols, MatrixType type)
		{
			return Cv.InitMatHeader(this, rows, cols, type);
		}

		public CvMat InitMatHeader<T>(int rows, int cols, MatrixType type, T[] data) where T : struct
		{
			return Cv.InitMatHeader(this, rows, cols, type, data);
		}

		public CvMat InitMatHeader<T>(int rows, int cols, MatrixType type, T[] data, int step) where T : struct
		{
			return Cv.InitMatHeader(this, rows, cols, type, data, step);
		}

		public double mGet(int row, int col)
		{
			return Cv.mGet(this, row, col);
		}

		public void mSet(int row, int col, double value)
		{
			Cv.mSet(this, row, col, value);
		}

		public int Rodrigues2(CvMat dst)
		{
			return Cv.Rodrigues2(this, dst);
		}

		public int Rodrigues2(CvMat dst, CvMat jacobian)
		{
			return Cv.Rodrigues2(this, dst, jacobian);
		}

		public void RQDecomp3x3(CvMat matrixR, CvMat matrixQ)
		{
			Cv.RQDecomp3x3(this, matrixR, matrixQ);
		}

		public void RQDecomp3x3(CvMat matrixR, CvMat matrixQ, CvMat matrixQx, CvMat matrixQy, CvMat matrixQz)
		{
			Cv.RQDecomp3x3(this, matrixR, matrixQ, matrixQx, matrixQy, matrixQz);
		}

		public void RQDecomp3x3(CvMat matrixR, CvMat matrixQ, CvMat matrixQx, CvMat matrixQy, CvMat matrixQz, out CvPoint3D64f eulerAngles)
		{
			Cv.RQDecomp3x3(this, matrixR, matrixQ, matrixQx, matrixQy, matrixQz, out eulerAngles);
		}

		public CvMat Transpose()
		{
			CvMat cvMat = new CvMat(Cols, Rows, ElemType);
			Cv.Transpose(this, cvMat);
			return cvMat;
		}

		public CvMat T()
		{
			return Transpose();
		}

		public void UndistortPoints(CvMat dst, CvMat cameraMatrix, CvMat distCoeffs, CvMat r, CvMat p)
		{
			Cv.UndistortPoints(this, dst, cameraMatrix, distCoeffs, r, p);
		}

		public CvScalar[] ToArray()
		{
			int rows = Rows;
			int cols = Cols;
			IntPtr cvPtr = base.CvPtr;
			CvScalar[] array = new CvScalar[cols * rows];
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					array[i * cols + j] = NativeMethods.cvGet2D(cvPtr, i, j);
				}
			}
			return array;
		}

		public CvScalar[,] ToRectangularArray()
		{
			int rows = Rows;
			int cols = Cols;
			IntPtr cvPtr = base.CvPtr;
			CvScalar[,] array = new CvScalar[rows, cols];
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					array[i, j] = NativeMethods.cvGet2D(cvPtr, i, j);
				}
			}
			return array;
		}

		public override string ToString()
		{
			if (ElemChannels == 1)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("CvMat(Rows={0}, Cols={1})\n", Rows, Cols);
				for (int i = 0; i < Rows; i++)
				{
					for (int j = 0; j < Cols; j++)
					{
						stringBuilder.Append(Cv.mGet(this, i, j));
						stringBuilder.Append("\t");
					}
					stringBuilder.AppendLine();
				}
				return stringBuilder.ToString();
			}
			return base.ToString();
		}

		public IEnumerator<CvScalar> GetEnumerator()
		{
			int rows = Rows;
			int cols = Cols;
			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					yield return NativeMethods.cvGet2D(ptr, r, c);
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
