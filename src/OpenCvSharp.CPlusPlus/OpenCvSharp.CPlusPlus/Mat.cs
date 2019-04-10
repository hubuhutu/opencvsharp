using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	public class Mat : DisposableCvObject, ICloneable
	{
		public class MatExprIndexer : MatExprRangeIndexer
		{
			public override MatExpr this[int rowStart, int rowEnd, int colStart, int colEnd]
			{
				get
				{
					return parent.SubMat(rowStart, rowEnd, colStart, colEnd);
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					NativeMethods.core_Mat_assignment_FromMatExpr(parent.SubMat(rowStart, rowEnd, colStart, colEnd).CvPtr, value.CvPtr);
				}
			}

			public override MatExpr this[Range rowRange, Range colRange]
			{
				get
				{
					return parent.SubMat(rowRange, colRange);
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					NativeMethods.core_Mat_assignment_FromMatExpr(parent.SubMat(rowRange, colRange).CvPtr, value.CvPtr);
				}
			}

			public override MatExpr this[Rect roi]
			{
				get
				{
					return parent.SubMat(roi);
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					NativeMethods.core_Mat_assignment_FromMatExpr(parent.SubMat(roi).CvPtr, value.CvPtr);
				}
			}

			public override MatExpr this[params Range[] ranges]
			{
				get
				{
					return parent.SubMat(ranges);
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					NativeMethods.core_Mat_assignment_FromMatExpr(parent.SubMat(ranges).CvPtr, value.CvPtr);
				}
			}

			protected internal MatExprIndexer(Mat parent)
				: base(parent)
			{
			}
		}

		public class ColExprIndexer : MatRowColExprIndexer
		{
			public override MatExpr this[int x]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new MatExpr(NativeMethods.core_Mat_col_toMatExpr(parent.ptr, x));
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					parent.ThrowIfDisposed();
					IntPtr intPtr = NativeMethods.core_Mat_col_toMat(parent.ptr, x);
					NativeMethods.core_Mat_assignment_FromMatExpr(intPtr, value.CvPtr);
					NativeMethods.core_Mat_delete(intPtr);
				}
			}

			public override MatExpr this[int startCol, int endCol]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new MatExpr(NativeMethods.core_Mat_colRange_toMatExpr(parent.ptr, startCol, endCol));
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					parent.ThrowIfDisposed();
					IntPtr intPtr = NativeMethods.core_Mat_colRange_toMat(parent.ptr, startCol, endCol);
					NativeMethods.core_Mat_assignment_FromMatExpr(intPtr, value.CvPtr);
					NativeMethods.core_Mat_delete(intPtr);
				}
			}

			protected internal ColExprIndexer(Mat parent)
				: base(parent)
			{
			}
		}

		public class RowExprIndexer : MatRowColExprIndexer
		{
			public override MatExpr this[int y]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new MatExpr(NativeMethods.core_Mat_row_toMatExpr(parent.ptr, y));
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					parent.ThrowIfDisposed();
					IntPtr intPtr = NativeMethods.core_Mat_row_toMat(parent.ptr, y);
					NativeMethods.core_Mat_assignment_FromMatExpr(intPtr, value.CvPtr);
					NativeMethods.core_Mat_delete(intPtr);
				}
			}

			public override MatExpr this[int startRow, int endRow]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new MatExpr(NativeMethods.core_Mat_rowRange_toMatExpr(parent.ptr, startRow, endRow));
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					parent.ThrowIfDisposed();
					NativeMethods.core_Mat_assignment_FromMatExpr(NativeMethods.core_Mat_rowRange_toMat(parent.ptr, startRow, endRow), value.CvPtr);
				}
			}

			protected internal RowExprIndexer(Mat parent)
				: base(parent)
			{
			}
		}

		public sealed class Indexer<T> : MatIndexer<T> where T : struct
		{
			private readonly long ptrVal;

			public override T this[int i0]
			{
				get
				{
					return (T)Marshal.PtrToStructure(new IntPtr(ptrVal + steps[0] * i0), typeof(T));
				}
				set
				{
					Marshal.StructureToPtr(ptr: new IntPtr(ptrVal + steps[0] * i0), structure: value, fDeleteOld: false);
				}
			}

			public override T this[int i0, int i1]
			{
				get
				{
					return (T)Marshal.PtrToStructure(new IntPtr(ptrVal + steps[0] * i0 + steps[1] * i1), typeof(T));
				}
				set
				{
					Marshal.StructureToPtr(ptr: new IntPtr(ptrVal + steps[0] * i0 + steps[1] * i1), structure: value, fDeleteOld: false);
				}
			}

			public override T this[int i0, int i1, int i2]
			{
				get
				{
					return (T)Marshal.PtrToStructure(new IntPtr(ptrVal + steps[0] * i0 + steps[1] * i1 + steps[2] * i2), typeof(T));
				}
				set
				{
					Marshal.StructureToPtr(ptr: new IntPtr(ptrVal + steps[0] * i0 + steps[1] * i1 + steps[2] * i2), structure: value, fDeleteOld: false);
				}
			}

			public override T this[params int[] idx]
			{
				get
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					return (T)Marshal.PtrToStructure(new IntPtr(ptrVal + num), typeof(T));
				}
				set
				{
					long num = 0L;
					for (int i = 0; i < idx.Length; i++)
					{
						num += steps[i] * idx[i];
					}
					Marshal.StructureToPtr(ptr: new IntPtr(ptrVal + num), structure: value, fDeleteOld: false);
				}
			}

			internal Indexer(Mat parent)
				: base(parent)
			{
				ptrVal = parent.Data.ToInt64();
			}
		}

		public class ColIndexer : MatRowColIndexer
		{
			public override Mat this[int x]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new Mat(NativeMethods.core_Mat_col_toMat(parent.ptr, x));
				}
				set
				{
					parent.ThrowIfDisposed();
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					value.ThrowIfDisposed();
					if (parent.Dims() != value.Dims())
					{
						throw new ArgumentException("Dimension mismatch");
					}
					Mat mat = new Mat(NativeMethods.core_Mat_col_toMat(parent.ptr, x));
					if (mat.Size() != value.Size())
					{
						throw new ArgumentException("Specified ROI != mat.Size()");
					}
					value.CopyTo(mat);
				}
			}

			public override Mat this[int startCol, int endCol]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new Mat(NativeMethods.core_Mat_colRange_toMat(parent.ptr, startCol, endCol));
				}
				set
				{
					parent.ThrowIfDisposed();
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					value.ThrowIfDisposed();
					if (parent.Dims() != value.Dims())
					{
						throw new ArgumentException("Dimension mismatch");
					}
					Mat mat = new Mat(NativeMethods.core_Mat_colRange_toMat(parent.ptr, startCol, endCol));
					if (mat.Size() != value.Size())
					{
						throw new ArgumentException("Specified ROI != mat.Size()");
					}
					value.CopyTo(mat);
				}
			}

			protected internal ColIndexer(Mat parent)
				: base(parent)
			{
			}
		}

		public class RowIndexer : MatRowColIndexer
		{
			public override Mat this[int x]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new Mat(NativeMethods.core_Mat_row_toMat(parent.ptr, x));
				}
				set
				{
					parent.ThrowIfDisposed();
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					value.ThrowIfDisposed();
					if (parent.Dims() != value.Dims())
					{
						throw new ArgumentException("Dimension mismatch");
					}
					Mat mat = new Mat(NativeMethods.core_Mat_row_toMat(parent.ptr, x));
					if (mat.Size() != value.Size())
					{
						throw new ArgumentException("Specified ROI != mat.Size()");
					}
					value.CopyTo(mat);
				}
			}

			public override Mat this[int startCol, int endCol]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new Mat(NativeMethods.core_Mat_rowRange_toMat(parent.ptr, startCol, endCol));
				}
				set
				{
					parent.ThrowIfDisposed();
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					value.ThrowIfDisposed();
					if (parent.Dims() != value.Dims())
					{
						throw new ArgumentException("Dimension mismatch");
					}
					Mat mat = new Mat(NativeMethods.core_Mat_rowRange_toMat(parent.ptr, startCol, endCol));
					if (mat.Size() != value.Size())
					{
						throw new ArgumentException("Specified ROI != mat.Size()");
					}
					value.CopyTo(mat);
				}
			}

			protected internal RowIndexer(Mat parent)
				: base(parent)
			{
			}
		}

		private bool disposed;

		public static readonly int SizeOf = (int)NativeMethods.core_Mat_sizeof();

		private MatExprIndexer matExprIndexer;

		private ColExprIndexer colExprIndexer;

		private RowExprIndexer rowExprIndexer;

		private ColIndexer colIndexer;

		private RowIndexer rowIndexer;

		public Mat this[int rowStart, int rowEnd, int colStart, int colEnd]
		{
			get
			{
				return SubMat(rowStart, rowEnd, colStart, colEnd);
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				value.ThrowIfDisposed();
				if (Dims() != value.Dims())
				{
					throw new ArgumentException("Dimension mismatch");
				}
				Mat mat = SubMat(rowStart, rowEnd, colStart, colEnd);
				if (mat.Size() != value.Size())
				{
					throw new ArgumentException("Specified ROI != mat.Size()");
				}
				value.CopyTo(mat);
			}
		}

		public Mat this[Range rowRange, Range colRange]
		{
			get
			{
				return SubMat(rowRange, colRange);
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				value.ThrowIfDisposed();
				if (Dims() != value.Dims())
				{
					throw new ArgumentException("Dimension mismatch");
				}
				Mat mat = SubMat(rowRange, colRange);
				if (mat.Size() != value.Size())
				{
					throw new ArgumentException("Specified ROI != mat.Size()");
				}
				value.CopyTo(mat);
			}
		}

		public Mat this[Rect roi]
		{
			get
			{
				return SubMat(roi);
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				value.ThrowIfDisposed();
				if (Dims() != value.Dims())
				{
					throw new ArgumentException("Dimension mismatch");
				}
				if (roi.Size != value.Size())
				{
					throw new ArgumentException("Specified ROI != mat.Size()");
				}
				Mat m = SubMat(roi);
				value.CopyTo(m);
			}
		}

		public Mat this[params Range[] ranges]
		{
			get
			{
				return SubMat(ranges);
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				value.ThrowIfDisposed();
				Mat mat = SubMat(ranges);
				int num = Dims();
				if (num != value.Dims())
				{
					throw new ArgumentException("Dimension mismatch");
				}
				for (int i = 0; i < num; i++)
				{
					if (mat.Size(i) != value.Size(i))
					{
						throw new ArgumentException("Size mismatch at dimension " + i);
					}
				}
				value.CopyTo(mat);
			}
		}

		public MatExprIndexer Expr {get{return matExprIndexer ?? (matExprIndexer = new MatExprIndexer(this));}}

		public ColExprIndexer ColExpr {get{return colExprIndexer ?? (colExprIndexer = new ColExprIndexer(this));}}

		public RowExprIndexer RowExpr {get{return rowExprIndexer ?? (rowExprIndexer = new RowExprIndexer(this));}}

		public int Cols {get{return NativeMethods.core_Mat_cols(ptr);}}

		public int Width {get{return NativeMethods.core_Mat_cols(ptr);}}

		public unsafe IntPtr Data {get{return new IntPtr(DataPointer);}}

		public unsafe byte* DataPointer
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.core_Mat_data(ptr);
			}
		}

		public IntPtr DataStart
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.core_Mat_datastart(ptr);
			}
		}

		public IntPtr DataEnd
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.core_Mat_dataend(ptr);
			}
		}

		public IntPtr DataLimit
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.core_Mat_datalimit(ptr);
			}
		}

		public IntPtr Refcount
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.core_Mat_refcount(ptr);
			}
		}

		public int Rows {get{return NativeMethods.core_Mat_rows(ptr);}}

		public int Height {get{return NativeMethods.core_Mat_rows(ptr);}}

		public ColIndexer Col {get{return colIndexer ?? (colIndexer = new ColIndexer(this));}}

		public RowIndexer Row {get{return rowIndexer ?? (rowIndexer = new RowIndexer(this));}}

		public MatExpr Abs()
		{
			return Cv2.Abs(this);
		}

		public Mat ConvertScaleAbs(double alpha = 1.0, double beta = 0.0)
		{
			Mat mat = new Mat();
			Cv2.ConvertScaleAbs(this, mat, alpha, beta);
			return mat;
		}

		public Mat LUT(InputArray lut, int interpolation = 0)
		{
			Mat mat = new Mat();
			Cv2.LUT(this, lut, mat, interpolation);
			return mat;
		}

		public Mat LUT(byte[] lut, int interpolation = 0)
		{
			Mat mat = new Mat();
			Cv2.LUT(this, lut, mat, interpolation);
			return mat;
		}

		public Scalar Sum()
		{
			return Cv2.Sum(this);
		}

		public int CountNonZero()
		{
			return Cv2.CountNonZero(this);
		}

		public Mat FindNonZero()
		{
			Mat mat = new Mat();
			Cv2.FindNonZero(this, mat);
			return mat;
		}

		public Scalar Mean(InputArray mask = null)
		{
			return Cv2.Mean(this, mask);
		}

		public void MeanStdDev(OutputArray mean, OutputArray stddev, InputArray mask = null)
		{
			Cv2.MeanStdDev(this, mean, stddev, mask);
		}

		public double Norm(NormType normType = NormType.L2, InputArray mask = null)
		{
			return Cv2.Norm(this, normType, mask);
		}

		public Mat Normalize(double alpha = 1.0, double beta = 0.0, NormType normType = NormType.L2, int dtype = -1, InputArray mask = null)
		{
			Mat mat = new Mat();
			Cv2.Normalize(this, mat, alpha, beta, normType, dtype, mask);
			return mat;
		}

		public void MinMaxLoc(out double minVal, out double maxVal)
		{
			Cv2.MinMaxLoc(this, out minVal, out maxVal);
		}

		public void MinMaxLoc(out Point minLoc, out Point maxLoc)
		{
			Cv2.MinMaxLoc(this, out minLoc, out maxLoc);
		}

		public void MinMaxLoc(out double minVal, out double maxVal, out Point minLoc, out Point maxLoc, InputArray mask = null)
		{
			Cv2.MinMaxLoc(this, out minVal, out maxVal, out minLoc, out maxLoc, mask);
		}

		public void MinMaxIdx(out double minVal, out double maxVal)
		{
			Cv2.MinMaxIdx(this, out minVal, out maxVal);
		}

		public void MinMaxIdx(out int minIdx, out int maxIdx)
		{
			Cv2.MinMaxIdx(this, out minIdx, out maxIdx);
		}

		public void MinMaxIdx(out double minVal, out double maxVal, out int minIdx, out int maxIdx, InputArray mask = null)
		{
			Cv2.MinMaxIdx(this, out minVal, out maxVal, out minIdx, out maxIdx, mask);
		}

		public Mat Reduce(ReduceDimension dim, ReduceOperation rtype, int dtype)
		{
			Mat mat = new Mat();
			Cv2.Reduce(this, mat, dim, rtype, dtype);
			return mat;
		}

		public Mat[] Split()
		{
			return Cv2.Split(this);
		}

		public Mat ExtractChannel(int coi)
		{
			Mat mat = new Mat();
			Cv2.ExtractChannel(this, mat, coi);
			return mat;
		}

		public void InsertChannel(InputOutputArray dst, int coi)
		{
			Cv2.InsertChannel(this, dst, coi);
		}

		public Mat Flip(FlipMode flipCode)
		{
			Mat mat = new Mat();
			Cv2.Flip(this, mat, flipCode);
			return mat;
		}

		public Mat Repeat(int ny, int nx)
		{
			Mat mat = new Mat();
			Cv2.Repeat(this, ny, nx, mat);
			return mat;
		}

		public Mat InRange(InputArray lowerb, InputArray upperb)
		{
			Mat mat = new Mat();
			Cv2.InRange(this, lowerb, upperb, mat);
			return mat;
		}

		public Mat InRange(Scalar lowerb, Scalar upperb)
		{
			Mat mat = new Mat();
			Cv2.InRange(this, lowerb, upperb, mat);
			return mat;
		}

		public Mat Sqrt()
		{
			Mat mat = new Mat();
			Cv2.Sqrt(this, mat);
			return mat;
		}

		public Mat Pow(double power)
		{
			Mat mat = new Mat();
			Cv2.Pow(this, power, mat);
			return mat;
		}

		public Mat Exp()
		{
			Mat mat = new Mat();
			Cv2.Exp(this, mat);
			return mat;
		}

		public Mat Log()
		{
			Mat mat = new Mat();
			Cv2.Log(this, mat);
			return mat;
		}

		public bool CheckRange(bool quiet = true)
		{
			return Cv2.CheckRange(this, quiet);
		}

		public bool CheckRange(bool quiet, out Point pos, double minVal = double.MinValue, double maxVal = double.MaxValue)
		{
			return Cv2.CheckRange(this, quiet, out pos, minVal, maxVal);
		}

		public void PatchNaNs(double val = 0.0)
		{
			Cv2.PatchNaNs(this, val);
		}

		public Mat MulTransposed(bool aTa, InputArray delta = null, double scale = 1.0, int dtype = -1)
		{
			Mat mat = new Mat();
			Cv2.MulTransposed(this, mat, aTa, delta, scale, dtype);
			return mat;
		}

		public Mat Transpose()
		{
			Mat mat = new Mat();
			Cv2.Transpose(this, mat);
			return mat;
		}

		public Mat Transform(InputArray m)
		{
			Mat mat = new Mat();
			Cv2.Transform(this, mat, m);
			return mat;
		}

		public Mat PerspectiveTransform(InputArray m)
		{
			Mat mat = new Mat();
			Cv2.PerspectiveTransform(this, mat, m);
			return mat;
		}

		public void CompleteSymm(bool lowerToUpper = false)
		{
			Cv2.CompleteSymm(this, lowerToUpper);
		}

		public void SetIdentity(Scalar? s = default(Scalar?))
		{
			Cv2.SetIdentity(this, s);
		}

		public double Determinant()
		{
			return Cv2.Determinant(this);
		}

		public Scalar Trace()
		{
			return Cv2.Trace(this);
		}

		public Mat Sort(SortFlag flags)
		{
			Mat mat = new Mat();
			Cv2.Sort(this, mat, flags);
			return mat;
		}

		public Mat SortIdx(SortFlag flags)
		{
			Mat mat = new Mat();
			Cv2.SortIdx(this, mat, flags);
			return mat;
		}

		public Mat Dft(DftFlag2 flags = DftFlag2.None, int nonzeroRows = 0)
		{
			Mat mat = new Mat();
			Cv2.Dft(this, mat, flags, nonzeroRows);
			return mat;
		}

		public Mat Idft(DftFlag2 flags = DftFlag2.None, int nonzeroRows = 0)
		{
			Mat mat = new Mat();
			Cv2.Idft(this, mat, flags, nonzeroRows);
			return mat;
		}

		public Mat Dct(DctFlag2 flags = DctFlag2.None)
		{
			Mat mat = new Mat();
			Cv2.Dct(this, mat, flags);
			return mat;
		}

		public Mat Idct(DctFlag2 flags = DctFlag2.None)
		{
			Mat mat = new Mat();
			Cv2.Idct(this, mat, flags);
			return mat;
		}

		public void Randu(InputArray low, InputArray high)
		{
			Cv2.Randu(this, low, high);
		}

		public void Randu(Scalar low, Scalar high)
		{
			Cv2.Randu(this, low, high);
		}

		public void Randn(InputArray mean, InputArray stddev)
		{
			Cv2.Randn(this, mean, stddev);
		}

		public void Randn(Scalar mean, Scalar stddev)
		{
			Cv2.Randn(this, mean, stddev);
		}

		public void RandShuffle(double iterFactor, RNG rng = null)
		{
			Cv2.RandShuffle(this, iterFactor, rng);
		}

		public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
		{
			Cv2.Line(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType, shift);
		}

		public void Line(Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
		{
			Cv2.Line(this, pt1, pt2, color, thickness, lineType, shift);
		}

		public void Rectangle(Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
		{
			Cv2.Rectangle(this, pt1, pt2, color, thickness, lineType, shift);
		}

		public void Rectangle(Rect rect, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
		{
			Cv2.Rectangle(this, rect, color, thickness, lineType, shift);
		}

		public void Circle(int centerX, int centerY, int radius, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
		{
			Cv2.Circle(this, centerX, centerY, radius, color, thickness, lineType, shift);
		}

		public void Circle(Point center, int radius, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
		{
			Cv2.Circle(this, center, radius, color, thickness, lineType, shift);
		}

		public void Ellipse(Point center, Size axes, double angle, double startAngle, double endAngle, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
		{
			Cv2.Ellipse(this, center, axes, angle, startAngle, endAngle, color, thickness, lineType, shift);
		}

		public void Ellipse(RotatedRect box, Scalar color, int thickness = 1, LineType lineType = LineType.Link8)
		{
			Cv2.Ellipse(this, box, color, thickness, lineType);
		}

		public void FillConvexPoly(IEnumerable<Point> pts, Scalar color, LineType lineType = LineType.Link8, int shift = 0)
		{
			Cv2.FillConvexPoly(this, pts, color, lineType, shift);
		}

		public void FillPoly(IEnumerable<IEnumerable<Point>> pts, Scalar color, LineType lineType = LineType.Link8, int shift = 0, Point? offset = default(Point?))
		{
			Cv2.FillPoly(this, pts, color, lineType, shift, offset);
		}

		public void Polylines(IEnumerable<IEnumerable<Point>> pts, bool isClosed, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
		{
			Cv2.Polylines(this, pts, isClosed, color, thickness, lineType, shift);
		}

		public void PutText(string text, Point org, FontFace fontFace, double fontScale, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, bool bottomLeftOrigin = false)
		{
			Cv2.PutText(this, text, org, fontFace, fontScale, color, thickness, lineType, bottomLeftOrigin);
		}

		public byte[] ImEncode(string ext = ".png", int[] prms = null)
		{
            byte[] buf;
			Cv2.ImEncode(ext, this, out buf, prms);
			return buf;
		}

		public byte[] ImEncode(string ext = ".png", params ImageEncodingParam[] prms)
		{
            byte[] buf;
			Cv2.ImEncode(ext, this, out  buf, prms);
			return buf;
		}

		public bool ImWrite(string fileName, int[] prms = null)
		{
			return Cv2.ImWrite(fileName, this, prms);
		}

		public bool ImWrite(string fileName, params ImageEncodingParam[] prms)
		{
			return Cv2.ImWrite(fileName, this, prms);
		}

		public bool SaveImage(string fileName, int[] prms = null)
		{
			return Cv2.ImWrite(fileName, this, prms);
		}

		public bool SaveImage(string fileName, params ImageEncodingParam[] prms)
		{
			return Cv2.ImWrite(fileName, this, prms);
		}

		public Mat CopyMakeBorder(int top, int bottom, int left, int right, BorderType borderType, Scalar? value = default(Scalar?))
		{
			Mat mat = new Mat();
			Cv2.CopyMakeBorder(this, mat, top, bottom, left, right, borderType, value);
			return mat;
		}

		public Mat MedianBlur(int ksize)
		{
			Mat mat = new Mat();
			Cv2.MedianBlur(this, mat, ksize);
			return mat;
		}

		public Mat GaussianBlur(Size ksize, double sigmaX, double sigmaY = 0.0, BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.GaussianBlur(this, mat, ksize, sigmaX, sigmaY, borderType);
			return mat;
		}

		public Mat BilateralFilter(int d, double sigmaColor, double sigmaSpace, BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.BilateralFilter(this, mat, d, sigmaColor, sigmaSpace, borderType);
			return mat;
		}

		public Mat AdaptiveBilateralFilter(Size ksize, double sigmaSpace, double maxSigmaColor = 20.0, Point? anchor = default(Point?), BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.AdaptiveBilateralFilter(this, mat, ksize, sigmaSpace, maxSigmaColor, anchor, borderType);
			return mat;
		}

		public Mat BoxFilter(MatType ddepth, Size ksize, Point? anchor = default(Point?), bool normalize = true, BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.BoxFilter(this, mat, ddepth, ksize, anchor, normalize, borderType);
			return mat;
		}

		public Mat Blur(Size ksize, Point? anchor = default(Point?), BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.Blur(this, mat, ksize, anchor, borderType);
			return mat;
		}

		public Mat Filter2D(MatType ddepth, InputArray kernel, Point? anchor = default(Point?), double delta = 0.0, BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.Filter2D(this, mat, ddepth, kernel, anchor, delta, borderType);
			return mat;
		}

		public Mat SepFilter2D(MatType ddepth, InputArray kernelX, InputArray kernelY, Point? anchor = default(Point?), double delta = 0.0, BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.SepFilter2D(this, mat, ddepth, kernelX, kernelY, anchor, delta, borderType);
			return mat;
		}

		public Mat Sobel(MatType ddepth, int xorder, int yorder, int ksize = 3, double scale = 1.0, double delta = 0.0, BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.Sobel(this, mat, ddepth, xorder, yorder, ksize, scale, delta, borderType);
			return mat;
		}

		public Mat Scharr(MatType ddepth, int xorder, int yorder, double scale = 1.0, double delta = 0.0, BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.Scharr(this, mat, ddepth, xorder, yorder, scale, delta, borderType);
			return mat;
		}

		public Mat Laplacian(MatType ddepth, int ksize = 1, double scale = 1.0, double delta = 0.0, BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.Laplacian(this, mat, ddepth, ksize, scale, delta, borderType);
			return mat;
		}

		public Mat Canny(double threshold1, double threshold2, int apertureSize = 3, bool L2gradient = false)
		{
			Mat mat = new Mat();
			Cv2.Canny(this, mat, threshold1, threshold2, apertureSize, L2gradient);
			return mat;
		}

		public Mat CornerEigenValsAndVecs(int blockSize, int ksize, BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.CornerEigenValsAndVecs(this, mat, blockSize, ksize, borderType);
			return mat;
		}

		public Mat PreCornerDetect(int ksize, BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.PreCornerDetect(this, mat, ksize, borderType);
			return mat;
		}

		public Point2f[] CornerSubPix(IEnumerable<Point2f> inputCorners, Size winSize, Size zeroZone, CvTermCriteria criteria)
		{
			return Cv2.CornerSubPix(this, inputCorners, winSize, zeroZone, criteria);
		}

		public Point2f[] GoodFeaturesToTrack(int maxCorners, double qualityLevel, double minDistance, InputArray mask, int blockSize, bool useHarrisDetector, double k)
		{
			return Cv2.GoodFeaturesToTrack(this, maxCorners, qualityLevel, minDistance, mask, blockSize, useHarrisDetector, k);
		}

		public CvLineSegmentPolar[] HoughLines(double rho, double theta, int threshold, double srn = 0.0, double stn = 0.0)
		{
			return Cv2.HoughLines(this, rho, theta, threshold, srn, stn);
		}

		public CvLineSegmentPoint[] HoughLinesP(double rho, double theta, int threshold, double minLineLength = 0.0, double maxLineGap = 0.0)
		{
			return Cv2.HoughLinesP(this, rho, theta, threshold, minLineLength, maxLineGap);
		}

		public CvCircleSegment[] HoughCircles(HoughCirclesMethod method, double dp, double minDist, double param1 = 100.0, double param2 = 100.0, int minRadius = 0, int maxRadius = 0)
		{
			return Cv2.HoughCircles(this, method, dp, minDist, param1, param2, minRadius, maxRadius);
		}

		public Mat Dilate(InputArray element, Point? anchor = default(Point?), int iterations = 1, BorderType borderType = BorderType.Constant, Scalar? borderValue = default(Scalar?))
		{
			Mat mat = new Mat();
			Cv2.Dilate(this, mat, element, anchor, iterations, borderType, borderValue);
			return mat;
		}

		public Mat Erode(InputArray element, CvPoint? anchor = default(CvPoint?), int iterations = 1, BorderType borderType = BorderType.Constant, CvScalar? borderValue = default(CvScalar?))
		{
			Mat mat = new Mat();
			Cv2.Erode(this, mat, element, anchor, iterations, borderType, borderValue);
			return mat;
		}

		public Mat MorphologyEx(MorphologyOperation op, InputArray element, CvPoint? anchor = default(CvPoint?), int iterations = 1, BorderType borderType = BorderType.Constant, CvScalar? borderValue = default(CvScalar?))
		{
			Mat mat = new Mat();
			Cv2.MorphologyEx(this, mat, op, element, anchor, iterations, borderType, borderValue);
			return mat;
		}

		public Mat Resize(Size dsize, double fx = 0.0, double fy = 0.0, Interpolation interpolation = Interpolation.Linear)
		{
			Mat mat = new Mat();
			Cv2.Resize(this, mat, dsize, fx, fy, interpolation);
			return mat;
		}

		public Mat WarpAffine(InputArray m, Size dsize, Interpolation flags = Interpolation.Linear, BorderType borderMode = BorderType.Constant, Scalar? borderValue = default(Scalar?))
		{
			Mat mat = new Mat();
			Cv2.WarpAffine(this, mat, m, dsize, flags, borderMode, borderValue);
			return mat;
		}

		public Mat WarpPerspective(Mat m, Size dsize, Interpolation flags = Interpolation.Linear, BorderType borderMode = BorderType.Constant, Scalar? borderValue = default(Scalar?))
		{
			Mat mat = new Mat();
			Cv2.WarpPerspective(this, mat, m, dsize, flags, borderMode, borderValue);
			return mat;
		}

		public Mat Remap(InputArray map1, InputArray map2, Interpolation interpolation = Interpolation.Linear, BorderType borderMode = BorderType.Constant, CvScalar? borderValue = default(CvScalar?))
		{
			Mat mat = new Mat();
			Cv2.Remap(this, mat, map1, map2, interpolation, borderMode, borderValue);
			return mat;
		}

		public Mat InvertAffineTransform()
		{
			Mat mat = new Mat();
			Cv2.InvertAffineTransform(this, mat);
			return mat;
		}

		public Mat GetRectSubPix(Size patchSize, Point2f center, int patchType = -1)
		{
			Mat mat = new Mat();
			Cv2.GetRectSubPix(this, patchSize, center, mat, patchType);
			return mat;
		}

		public Mat Accumulate(InputArray mask)
		{
			Mat mat = new Mat();
			Cv2.Accumulate(this, mat, mask);
			return mat;
		}

		public Mat AccumulateSquare(InputArray mask)
		{
			Mat mat = new Mat();
			Cv2.AccumulateSquare(this, mat, mask);
			return mat;
		}

		public void CreateHanningWindow(Size winSize, MatType type)
		{
			Cv2.CreateHanningWindow(this, winSize, type);
		}

		public Mat Threshold(double thresh, double maxval, ThresholdType type)
		{
			Mat mat = new Mat();
			Cv2.Threshold(this, mat, thresh, maxval, type);
			return mat;
		}

		public Mat AdaptiveThreshold(double maxValue, AdaptiveThresholdType adaptiveMethod, ThresholdType thresholdType, int blockSize, double c)
		{
			Mat mat = new Mat();
			Cv2.AdaptiveThreshold(this, mat, maxValue, adaptiveMethod, thresholdType, blockSize, c);
			return mat;
		}

		public Mat PyrDown(Size? dstSize = default(Size?), BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.PyrDown(this, mat, dstSize, borderType);
			return mat;
		}

		public Mat PyrUp(Size? dstSize = default(Size?), BorderType borderType = BorderType.Reflect101)
		{
			Mat mat = new Mat();
			Cv2.PyrUp(this, mat, dstSize, borderType);
			return mat;
		}

		public Mat Undistort(InputArray cameraMatrix, InputArray distCoeffs, InputArray newCameraMatrix = null)
		{
			Mat mat = new Mat();
			Cv2.Undistort(this, mat, cameraMatrix, distCoeffs, newCameraMatrix);
			return mat;
		}

		public Mat GetDefaultNewCameraMatrix(Size? imgSize = default(Size?), bool centerPrincipalPoint = false)
		{
			return Cv2.GetDefaultNewCameraMatrix(this, imgSize, centerPrincipalPoint);
		}

		public Mat UndistortPoints(InputArray cameraMatrix, InputArray distCoeffs, InputArray r = null, InputArray p = null)
		{
			Mat mat = new Mat();
			Cv2.UndistortPoints(this, mat, cameraMatrix, distCoeffs, r, p);
			return mat;
		}

		public Mat EqualizeHist()
		{
			Mat mat = new Mat();
			Cv2.EqualizeHist(this, mat);
			return mat;
		}

		public void Watershed(InputOutputArray markers)
		{
			Cv2.Watershed(this, markers);
		}

		public Mat PyrMeanShiftFiltering(double sp, double sr, int maxLevel = 1, TermCriteria? termcrit = default(TermCriteria?))
		{
			Mat mat = new Mat();
			Cv2.PyrMeanShiftFiltering(this, mat, sp, sr, maxLevel, termcrit);
			return mat;
		}

		public void GrabCut(InputOutputArray mask, Rect rect, InputOutputArray bgdModel, InputOutputArray fgdModel, int iterCount, GrabCutFlag mode)
		{
			Cv2.GrabCut(this, mask, rect, bgdModel, fgdModel, iterCount, mode);
		}

		public int FloodFill(Point seedPoint, Scalar newVal)
		{
			return Cv2.FloodFill(this, seedPoint, newVal);
		}

		public int FloodFill(Point seedPoint, Scalar newVal, out Rect rect, Scalar? loDiff = default(Scalar?), Scalar? upDiff = default(Scalar?), FloodFillFlag flags = FloodFillFlag.Link4)
		{
			return Cv2.FloodFill(this, seedPoint, newVal, out rect, loDiff, upDiff, flags);
		}

		public int FloodFill(InputOutputArray mask, Point seedPoint, Scalar newVal)
		{
			return Cv2.FloodFill(this, mask, seedPoint, newVal);
		}

		public int FloodFill(InputOutputArray mask, Point seedPoint, Scalar newVal, out Rect rect, Scalar? loDiff = default(Scalar?), Scalar? upDiff = default(Scalar?), FloodFillFlag flags = FloodFillFlag.Link4)
		{
			return Cv2.FloodFill(this, mask, seedPoint, newVal, out rect, loDiff, upDiff, flags);
		}

		public Mat CvtColor(ColorConversion code, int dstCn = 0)
		{
			Mat mat = new Mat();
			Cv2.CvtColor(this, mat, code, dstCn);
			return mat;
		}

		public Moments Moments(bool binaryImage = false)
		{
			return new Moments(this, binaryImage);
		}

		public Mat MatchTemplate(InputArray templ, MatchTemplateMethod method)
		{
			Mat mat = new Mat();
			Cv2.MatchTemplate(this, templ, mat, method);
			return mat;
		}

		public void FindContours(out Point[][] contours, out HierarchyIndex[] hierarchy, ContourRetrieval mode, ContourChain method, Point? offset = default(Point?))
		{
			Cv2.FindContours(this, out contours, out hierarchy, mode, method, offset);
		}

		public void FindContours(out Mat[] contours, OutputArray hierarchy, ContourRetrieval mode, ContourChain method, Point? offset = default(Point?))
		{
			Cv2.FindContours(this, out contours, hierarchy, mode, method, offset);
		}

		public Point[][] FindContoursAsArray(ContourRetrieval mode, ContourChain method, Point? offset = default(Point?))
		{
			return Cv2.FindContoursAsArray(this, mode, method, offset);
		}

		public MatOfPoint[] FindContoursAsMat(ContourRetrieval mode, ContourChain method, Point? offset = default(Point?))
		{
			return Cv2.FindContoursAsMat(this, mode, method, offset);
		}

		public void DrawContours(IEnumerable<IEnumerable<Point>> contours, int contourIdx, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, IEnumerable<HierarchyIndex> hierarchy = null, int maxLevel = int.MaxValue, Point? offset = default(Point?))
		{
			Cv2.DrawContours(this, contours, contourIdx, color, thickness, lineType, hierarchy, maxLevel, offset);
		}

		public void DrawContours(InputOutputArray image, IEnumerable<Mat> contours, int contourIdx, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, Mat hierarchy = null, int maxLevel = int.MaxValue, Point? offset = default(Point?))
		{
			Cv2.DrawContours(image, contours, contourIdx, color, thickness, lineType, hierarchy, maxLevel, offset);
		}

		public Mat ApproxPolyDP(double epsilon, bool closed)
		{
			Mat mat = new Mat();
			Cv2.ApproxPolyDP(this, mat, epsilon, closed);
			return mat;
		}

		public double ArcLength(bool closed)
		{
			return Cv2.ArcLength(this, closed);
		}

		public Rect BoundingRect()
		{
			return Cv2.BoundingRect(this);
		}

		public double ContourArea(bool oriented = false)
		{
			return Cv2.ContourArea(this, oriented);
		}

		public RotatedRect MinAreaRect()
		{
			return Cv2.MinAreaRect(this);
		}

		public void MinEnclosingCircle(out Point2f center, out float radius)
		{
			Cv2.MinEnclosingCircle(this, out center, out radius);
		}

		public Mat ConvexHull(InputArray points, bool clockwise = false, bool returnPoints = true)
		{
			Mat mat = new Mat();
			Cv2.ConvexHull(points, mat, clockwise, returnPoints);
			return mat;
		}

		public Point[] ConvexHullPoints(InputArray points, bool clockwise = false)
		{
			MatOfPoint matOfPoint = new MatOfPoint();
			Cv2.ConvexHull(points, matOfPoint, clockwise);
			return matOfPoint.ToArray();
		}

		public Point2f[] ConvexHullFloatPoints(InputArray points, bool clockwise = false)
		{
			MatOfPoint2f matOfPoint2f = new MatOfPoint2f();
			Cv2.ConvexHull(points, matOfPoint2f, clockwise);
			return matOfPoint2f.ToArray();
		}

		public int[] ConvexHullIndices(InputArray points, bool clockwise = false)
		{
			MatOfInt matOfInt = new MatOfInt();
			Cv2.ConvexHull(points, matOfInt, clockwise, returnPoints: false);
			return matOfInt.ToArray();
		}

		public Mat ConvexityDefects(InputArray convexHull)
		{
			Mat mat = new Mat();
			Cv2.ConvexityDefects(this, convexHull, mat);
			return mat;
		}

		public Vec4i[] ConvexityDefectsAsVec(InputArray convexHull)
		{
			MatOfInt4 matOfInt = new MatOfInt4();
			Cv2.ConvexityDefects(this, convexHull, matOfInt);
			return matOfInt.ToArray();
		}

		public bool IsContourConvex()
		{
			return Cv2.IsContourConvex(this);
		}

		public RotatedRect FitEllipse()
		{
			return Cv2.FitEllipse(this);
		}

		public CvLine2D FitLine2D(DistanceType distType, double param, double reps, double aeps)
		{
			MatOfFloat matOfFloat = new MatOfFloat();
			Cv2.FitLine(this, matOfFloat, distType, param, reps, aeps);
			return new CvLine2D(matOfFloat.ToArray());
		}

		public CvLine3D FitLine3D(DistanceType distType, double param, double reps, double aeps)
		{
			MatOfFloat matOfFloat = new MatOfFloat();
			Cv2.FitLine(this, matOfFloat, distType, param, reps, aeps);
			return new CvLine3D(matOfFloat.ToArray());
		}

		public double PointPolygonTest(Point2f pt, bool measureDist)
		{
			return Cv2.PointPolygonTest(this, pt, measureDist);
		}

		public MatOfFloat DistanceTransform(DistanceType distanceType, DistanceMaskSize maskSize)
		{
			MatOfFloat matOfFloat = new MatOfFloat();
			Cv2.DistanceTransform(this, matOfFloat, distanceType, maskSize);
			return matOfFloat;
		}

		public Mat(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Native object address is NULL");
			}
			base.ptr = ptr;
		}

		public Mat()
		{
			ptr = NativeMethods.core_Mat_new1();
		}

		public Mat(string fileName, LoadMode flags = LoadMode.Color)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException("", fileName);
			}
			ptr = NativeMethods.highgui_imread(fileName, (int)flags);
		}

		public Mat(int rows, int cols, MatType type)
		{
			ptr = NativeMethods.core_Mat_new2(rows, cols, type);
		}

		public Mat(Size size, MatType type)
		{
			ptr = NativeMethods.core_Mat_new2(size.Height, size.Width, type);
		}

		public Mat(int rows, int cols, MatType type, Scalar s)
		{
			ptr = NativeMethods.core_Mat_new3(rows, cols, type, s);
		}

		public Mat(Size size, MatType type, Scalar s)
		{
			ptr = NativeMethods.core_Mat_new3(size.Height, size.Width, type, s);
		}

		public Mat(Mat m, Range rowRange, Range? colRange = default(Range?))
		{
			if (colRange.HasValue)
			{
				ptr = NativeMethods.core_Mat_new4(m.ptr, rowRange, colRange.Value);
			}
			else
			{
				ptr = NativeMethods.core_Mat_new5(m.ptr, rowRange);
			}
		}

		public Mat(Mat m, params Range[] ranges)
		{
			ptr = NativeMethods.core_Mat_new6(m.ptr, ranges);
		}

		public Mat(Mat m, Rect roi)
		{
			ptr = NativeMethods.core_Mat_new7(m.ptr, roi);
		}

		public Mat(int rows, int cols, MatType type, IntPtr data, long step = 0L)
		{
			ptr = NativeMethods.core_Mat_new8(rows, cols, type, data, new IntPtr(step));
		}

		public Mat(int rows, int cols, MatType type, Array data, long step = 0L)
		{
			GCHandle gCHandle = AllocGCHandle(data);
			ptr = NativeMethods.core_Mat_new8(rows, cols, type, gCHandle.AddrOfPinnedObject(), new IntPtr(step));
		}

		public Mat(IEnumerable<int> sizes, MatType type, IntPtr data, IEnumerable<long> steps = null)
		{
			if (sizes == null)
			{
				throw new ArgumentNullException("sizes");
			}
			if (data == IntPtr.Zero)
			{
				throw new ArgumentNullException("data");
			}
			int[] array = EnumerableEx.ToArray(sizes);
			if (steps == null)
			{
				ptr = NativeMethods.core_Mat_new9(array.Length, array, type, data, IntPtr.Zero);
				return;
			}
			IntPtr[] steps2 = EnumerableEx.SelectToArray(steps, (long s) => new IntPtr(s));
			ptr = NativeMethods.core_Mat_new9(array.Length, array, type, data, steps2);
		}

		public Mat(IEnumerable<int> sizes, MatType type, Array data, IEnumerable<long> steps = null)
		{
			if (sizes == null)
			{
				throw new ArgumentNullException("sizes");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			GCHandle gCHandle = AllocGCHandle(data);
			int[] array = EnumerableEx.ToArray(sizes);
			if (steps == null)
			{
				ptr = NativeMethods.core_Mat_new9(array.Length, array, type, gCHandle.AddrOfPinnedObject(), IntPtr.Zero);
				return;
			}
			IntPtr[] steps2 = EnumerableEx.SelectToArray(steps, (long s) => new IntPtr(s));
			ptr = NativeMethods.core_Mat_new9(array.Length, array, type, gCHandle.AddrOfPinnedObject(), steps2);
		}

		public Mat(IEnumerable<int> sizes, MatType type)
		{
			if (sizes == null)
			{
				throw new ArgumentNullException("sizes");
			}
			int[] array = EnumerableEx.ToArray(sizes);
			ptr = NativeMethods.core_Mat_new10(array.Length, array, type);
		}

		public Mat(IEnumerable<int> sizes, MatType type, Scalar s)
		{
			if (sizes == null)
			{
				throw new ArgumentNullException("sizes");
			}
			int[] array = EnumerableEx.ToArray(sizes);
			ptr = NativeMethods.core_Mat_new11(array.Length, array, type, s);
		}

		public Mat(CvMat m, bool copyData = false)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			m.ThrowIfDisposed();
			ptr = NativeMethods.core_Mat_new_FromCvMat(m.CvPtr, copyData ? 1 : 0);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public Mat(IplImage img, bool copyData = false)
		{
			if (img == null)
			{
				throw new ArgumentNullException("img");
			}
			img.ThrowIfDisposed();
			ptr = NativeMethods.core_Mat_new_FromIplImage(img.CvPtr, copyData ? 1 : 0);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public void Release()
		{
			Dispose();
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						if (ptr != IntPtr.Zero)
						{
							NativeMethods.core_Mat_delete(ptr);
						}
						ptr = IntPtr.Zero;
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static Mat FromStream(Stream stream, LoadMode mode)
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

		public static Mat ImDecode(byte[] imageBytes, LoadMode mode = LoadMode.Color)
		{
			if (imageBytes == null)
			{
				throw new ArgumentNullException("imageBytes");
			}
			return Cv2.ImDecode(imageBytes, mode);
		}

		public static Mat FromImageData(byte[] imageBytes, LoadMode mode = LoadMode.Color)
		{
			return ImDecode(imageBytes, mode);
		}

		public static Mat Diag(Mat d)
		{
			return d.Diag();
		}

		public static MatExpr Eye(Size size, MatType type)
		{
			return Eye(size.Height, size.Width, type);
		}

		public static MatExpr Eye(int rows, int cols, MatType type)
		{
			return new MatExpr(NativeMethods.core_Mat_eye(rows, cols, type));
		}

		public static MatExpr Ones(int rows, int cols, MatType type)
		{
			return new MatExpr(NativeMethods.core_Mat_ones(rows, cols, type));
		}

		public static MatExpr Ones(Size size, MatType type)
		{
			return Ones(size.Height, size.Width, type);
		}

		public static MatExpr Ones(MatType type, params int[] sizes)
		{
			if (sizes == null)
			{
				throw new ArgumentNullException("sizes");
			}
			return new MatExpr(NativeMethods.core_Mat_ones(sizes.Length, sizes, type));
		}

		public static MatExpr Zeros(int rows, int cols, MatType type)
		{
			return new MatExpr(NativeMethods.core_Mat_zeros(rows, cols, type));
		}

		public static MatExpr Zeros(Size size, MatType type)
		{
			return Zeros(size.Height, size.Width, type);
		}

		public static MatExpr Zeros(MatType type, params int[] sizes)
		{
			if (sizes == null)
			{
				throw new ArgumentNullException("sizes");
			}
			return new MatExpr(NativeMethods.core_Mat_zeros(sizes.Length, sizes, type));
		}

		public static explicit operator IplImage(Mat self)
		{
			return self.ToIplImage(adjustAlignment: false);
		}

		public IplImage ToIplImage(bool adjustAlignment = true)
		{
			ThrowIfDisposed();
			if (adjustAlignment)
			{
                IntPtr outImage;
                NativeMethods.core_Mat_IplImage_alignment(ptr, out outImage);
				return new IplImage(outImage);
			}
			IplImage iplImage = new IplImage(isEnabledDispose: false);
			NativeMethods.core_Mat_IplImage(ptr, iplImage.CvPtr);
			return iplImage;
		}

		public static explicit operator CvMat(Mat self)
		{
			return self.ToCvMat();
		}

		public CvMat ToCvMat()
		{
			ThrowIfDisposed();
			CvMat cvMat = new CvMat(isEnabledDispose: false);
			NativeMethods.core_Mat_CvMat(ptr, cvMat.CvPtr);
			return cvMat;
		}

		public static MatExpr operator -(Mat mat)
		{
			return new MatExpr(NativeMethods.core_Mat_operatorUnaryMinus(mat.CvPtr));
		}

		public static Mat operator +(Mat mat)
		{
			return mat;
		}

		public static MatExpr operator +(Mat a, Mat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			a.ThrowIfDisposed();
			b.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorAdd_MatMat(a.CvPtr, b.CvPtr));
		}

		public static MatExpr operator +(Mat a, Scalar s)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorAdd_MatScalar(a.CvPtr, s));
		}

		public static MatExpr operator +(Scalar s, Mat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorAdd_ScalarMat(s, a.CvPtr));
		}

		public static MatExpr operator -(Mat a, Mat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			a.ThrowIfDisposed();
			b.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorSubtract_MatMat(a.CvPtr, b.CvPtr));
		}

		public static MatExpr operator -(Mat a, Scalar s)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorSubtract_MatScalar(a.CvPtr, s));
		}

		public static MatExpr operator -(Scalar s, Mat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorSubtract_ScalarMat(s, a.CvPtr));
		}

		public static MatExpr operator *(Mat a, Mat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			a.ThrowIfDisposed();
			b.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorMultiply_MatMat(a.CvPtr, b.CvPtr));
		}

		public static MatExpr operator *(Mat a, double s)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorMultiply_MatDouble(a.CvPtr, s));
		}

		public static MatExpr operator *(double s, Mat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorMultiply_DoubleMat(s, a.CvPtr));
		}

		public static MatExpr operator /(Mat a, Mat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			a.ThrowIfDisposed();
			b.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorDivide_MatMat(a.CvPtr, b.CvPtr));
		}

		public static MatExpr operator /(Mat a, double s)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorDivide_MatDouble(a.CvPtr, s));
		}

		public static MatExpr operator /(double s, Mat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorDivide_DoubleMat(s, a.CvPtr));
		}

		public static MatExpr operator &(Mat a, Mat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			a.ThrowIfDisposed();
			b.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorAnd_MatMat(a.CvPtr, b.CvPtr));
		}

		public static MatExpr operator &(Mat a, double s)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorAnd_MatDouble(a.CvPtr, s));
		}

		public static MatExpr operator &(double s, Mat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorAnd_DoubleMat(s, a.CvPtr));
		}

		public static MatExpr operator |(Mat a, Mat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			a.ThrowIfDisposed();
			b.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorOr_MatMat(a.CvPtr, b.CvPtr));
		}

		public static MatExpr operator |(Mat a, double s)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorOr_MatDouble(a.CvPtr, s));
		}

		public static MatExpr operator |(double s, Mat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorOr_DoubleMat(s, a.CvPtr));
		}

		public static MatExpr operator ^(Mat a, Mat b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			a.ThrowIfDisposed();
			b.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorXor_MatMat(a.CvPtr, b.CvPtr));
		}

		public static MatExpr operator ^(Mat a, double s)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorXor_MatDouble(a.CvPtr, s));
		}

		public static MatExpr operator ^(double s, Mat a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			a.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorXor_DoubleMat(s, a.CvPtr));
		}

		public static MatExpr operator ~(Mat m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			m.ThrowIfDisposed();
			return new MatExpr(NativeMethods.core_Mat_operatorNot(m.CvPtr));
		}

		public MatExpr LessThan(Mat m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			MatExpr result = new MatExpr(NativeMethods.core_Mat_operatorLT_MatMat(ptr, m.CvPtr));
			GC.KeepAlive(m);
			return result;
		}

		public MatExpr LessThan(double d)
		{
			return new MatExpr(NativeMethods.core_Mat_operatorLT_MatDouble(ptr, d));
		}

		public MatExpr LessThanOrEqual(Mat m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			MatExpr result = new MatExpr(NativeMethods.core_Mat_operatorLE_MatMat(ptr, m.CvPtr));
			GC.KeepAlive(m);
			return result;
		}

		public MatExpr LessThanOrEqual(double d)
		{
			return new MatExpr(NativeMethods.core_Mat_operatorLE_MatDouble(ptr, d));
		}

		public MatExpr Equals(Mat m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			MatExpr result = new MatExpr(NativeMethods.core_Mat_operatorEQ_MatMat(ptr, m.CvPtr));
			GC.KeepAlive(m);
			return result;
		}

		public MatExpr Equals(double d)
		{
			return new MatExpr(NativeMethods.core_Mat_operatorEQ_MatDouble(ptr, d));
		}

		public MatExpr NotEquals(Mat m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			MatExpr result = new MatExpr(NativeMethods.core_Mat_operatorNE_MatMat(ptr, m.CvPtr));
			GC.KeepAlive(m);
			return result;
		}

		public MatExpr NotEquals(double d)
		{
			return new MatExpr(NativeMethods.core_Mat_operatorNE_MatDouble(ptr, d));
		}

		public MatExpr GreaterThan(Mat m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			MatExpr result = new MatExpr(NativeMethods.core_Mat_operatorGT_MatMat(ptr, m.CvPtr));
			GC.KeepAlive(m);
			return result;
		}

		public MatExpr GreaterThan(double d)
		{
			return new MatExpr(NativeMethods.core_Mat_operatorGT_MatDouble(ptr, d));
		}

		public MatExpr GreaterThanOrEqual(Mat m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			MatExpr result = new MatExpr(NativeMethods.core_Mat_operatorGE_MatMat(ptr, m.CvPtr));
			GC.KeepAlive(m);
			return result;
		}

		public MatExpr GreaterThanOrEqual(double d)
		{
			return new MatExpr(NativeMethods.core_Mat_operatorGE_MatDouble(ptr, d));
		}

		public Mat AdjustROI(int dtop, int dbottom, int dleft, int dright)
		{
			ThrowIfDisposed();
			return new Mat(NativeMethods.core_Mat_adjustROI(ptr, dtop, dbottom, dleft, dright));
		}

		public void AssignTo(Mat m, MatType type)
		{
			ThrowIfDisposed();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			NativeMethods.core_Mat_assignTo(ptr, m.CvPtr, type);
		}

		public void AssignTo(Mat m)
		{
			NativeMethods.core_Mat_assignTo(ptr, m.CvPtr);
		}

		public int Channels()
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_channels(ptr);
		}

		public int CheckVector(int elemChannels)
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_checkVector(ptr, elemChannels);
		}

		public int CheckVector(int elemChannels, int depth)
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_checkVector(ptr, elemChannels, depth);
		}

		public int CheckVector(int elemChannels, int depth, bool requireContinuous)
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_checkVector(ptr, elemChannels, depth, requireContinuous ? 1 : 0);
		}

		public Mat Clone()
		{
			ThrowIfDisposed();
			return new Mat(NativeMethods.core_Mat_clone(ptr));
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public Mat Clone(Rect roi)
		{
			using (Mat mat = new Mat(this, roi))
			{
				return mat.Clone();
			}
		}

		public int Dims()
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_dims(ptr);
		}

		public void ConvertTo(Mat m, MatType rtype, double alpha = 1.0, double beta = 0.0)
		{
			ThrowIfDisposed();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			NativeMethods.core_Mat_convertTo(ptr, m.CvPtr, rtype, alpha, beta);
		}

		public void CopyTo(Mat m)
		{
			CopyTo(m, null);
		}

		public void CopyTo(Mat m, Mat mask)
		{
			ThrowIfDisposed();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			IntPtr mask2 = Cv2.ToPtr(mask);
			NativeMethods.core_Mat_copyTo(ptr, m.CvPtr, mask2);
		}

		public void Create(int rows, int cols, MatType type)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_create(ptr, rows, cols, type);
		}

		public void Create(Size size, MatType type)
		{
			Create(size.Height, size.Width, type);
		}

		public void Create(MatType type, params int[] sizes)
		{
			if (sizes == null)
			{
				throw new ArgumentNullException("sizes");
			}
			if (sizes.Length < 2)
			{
				throw new ArgumentException("sizes.Length < 2");
			}
			NativeMethods.core_Mat_create(ptr, sizes.Length, sizes, type);
		}

		public Mat Cross(Mat m)
		{
			ThrowIfDisposed();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			return new Mat(NativeMethods.core_Mat_cross(ptr, m.CvPtr));
		}

		public int Depth()
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_depth(ptr);
		}

		public Mat Diag(MatDiagType d = MatDiagType.Main)
		{
			ThrowIfDisposed();
			return new Mat(NativeMethods.core_Mat_diag(ptr, (int)d));
		}

		public double Dot(Mat m)
		{
			ThrowIfDisposed();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			return NativeMethods.core_Mat_dot(ptr, m.CvPtr);
		}

		public int ElemSize()
		{
			ThrowIfDisposed();
			return (int)NativeMethods.core_Mat_elemSize(ptr);
		}

		public int ElemSize1()
		{
			ThrowIfDisposed();
			return (int)NativeMethods.core_Mat_elemSize1(ptr);
		}

		public bool Empty()
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_empty(ptr) != 0;
		}

		public Mat Inv(MatrixDecomposition method = MatrixDecomposition.LU)
		{
			ThrowIfDisposed();
			return new Mat(NativeMethods.core_Mat_inv(ptr, (int)method));
		}

		public bool IsContinuous()
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_isContinuous(ptr) != 0;
		}

		public bool IsSubmatrix()
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_isSubmatrix(ptr) != 0;
		}

		public void LocateROI(out Size wholeSize, out Point ofs)
		{
			ThrowIfDisposed();
            CvSize wholeSize2;
            CvPoint ofs2;
            NativeMethods.core_Mat_locateROI(ptr, out wholeSize2, out ofs2);
			wholeSize = wholeSize2;
			ofs = ofs2;
		}

		public MatExpr Mul(Mat m, double scale = 1.0)
		{
			ThrowIfDisposed();
			if (m == null)
			{
				throw new ArgumentNullException();
			}
			IntPtr cvPtr = m.CvPtr;
			return new MatExpr(NativeMethods.core_Mat_mul(ptr, cvPtr, scale));
		}

		public Mat Reshape(int cn, int rows = 0)
		{
			ThrowIfDisposed();
			return new Mat(NativeMethods.core_Mat_reshape(ptr, cn, rows));
		}

		public Mat Reshape(int cn, params int[] newDims)
		{
			ThrowIfDisposed();
			if (newDims == null)
			{
				throw new ArgumentNullException("newDims");
			}
			return new Mat(NativeMethods.core_Mat_reshape(ptr, cn, newDims.Length, newDims));
		}

		public Mat SetTo(Scalar value, InputArray mask = null)
		{
			ThrowIfDisposed();
			IntPtr mask2 = Cv2.ToPtr(mask);
			return new Mat(NativeMethods.core_Mat_setTo(ptr, value, mask2));
		}

		public Mat SetTo(InputArray value, InputArray mask = null)
		{
			ThrowIfDisposed();
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			value.ThrowIfDisposed();
			IntPtr mask2 = Cv2.ToPtr(mask);
			return new Mat(NativeMethods.core_Mat_setTo(ptr, value.CvPtr, mask2));
		}

		public Size Size()
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_size(ptr);
		}

		public int Size(int dim)
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_sizeAt(ptr, dim);
		}

		public long Step()
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_step(ptr);
		}

		public long Step(int i)
		{
			ThrowIfDisposed();
			return (long)NativeMethods.core_Mat_stepAt(ptr, i);
		}

		public long Step1()
		{
			ThrowIfDisposed();
			return (long)NativeMethods.core_Mat_step1(ptr);
		}

		public long Step1(int i)
		{
			ThrowIfDisposed();
			return (long)NativeMethods.core_Mat_step1(ptr, i);
		}

		public Mat T()
		{
			ThrowIfDisposed();
			return new Mat(NativeMethods.core_Mat_t(ptr));
		}

		public long Total()
		{
			ThrowIfDisposed();
			return (long)NativeMethods.core_Mat_total(ptr);
		}

		public MatType Type()
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_type(ptr);
		}

		public override string ToString()
		{
			return "Mat [ " + Rows + "*" + Cols + "*" + Type().ToString() + ", IsContinuous=" + IsContinuous().ToString() + ", IsSubmatrix=" + IsSubmatrix().ToString() + ", Ptr=0x" + Convert.ToString(ptr.ToInt64(), 16) + ", Data=0x" + Convert.ToString(Data.ToInt64(), 16) + " ]";
		}

		public unsafe string Dump(DumpFormat format = DumpFormat.Default)
		{
			ThrowIfDisposed();
			string dumpFormatString = GetDumpFormatString(format);
			sbyte* ptr = null;
			try
			{
				ptr = NativeMethods.core_Mat_dump(base.ptr, dumpFormatString);
				return new string(ptr);
			}
			finally
			{
				if (ptr != null)
				{
					NativeMethods.core_Mat_dump_delete(ptr);
				}
			}
		}

		private static string GetDumpFormatString(DumpFormat format)
		{
			if (format == DumpFormat.Default)
			{
				return null;
			}
			string name = Enum.GetName(typeof(DumpFormat), format);
			if (name == null)
			{
				throw new ArgumentException();
			}
			return name.ToLower();
		}

		public Mat EmptyClone()
		{
			return new Mat(Size(), Type());
		}

		public IntPtr Ptr(int i0)
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_ptr1d(ptr, i0);
		}

		public IntPtr Ptr(int i0, int i1)
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_ptr2d(ptr, i0, i1);
		}

		public IntPtr Ptr(int i0, int i1, int i2)
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_ptr3d(ptr, i0, i1, i2);
		}

		public IntPtr Ptr(params int[] idx)
		{
			ThrowIfDisposed();
			return NativeMethods.core_Mat_ptrnd(ptr, idx);
		}

		public Indexer<T> GetGenericIndexer<T>() where T : struct
		{
			return new Indexer<T>(this);
		}

		public T Get<T>(int i0) where T : struct
		{
			return new Indexer<T>(this)[i0];
		}

		public T Get<T>(int i0, int i1) where T : struct
		{
			return new Indexer<T>(this)[i0, i1];
		}

		public T Get<T>(int i0, int i1, int i2) where T : struct
		{
			return new Indexer<T>(this)[i0, i1, i2];
		}

		public T Get<T>(params int[] idx) where T : struct
		{
			return new Indexer<T>(this)[idx];
		}

		public T At<T>(int i0) where T : struct
		{
			return new Indexer<T>(this)[i0];
		}

		public T At<T>(int i0, int i1) where T : struct
		{
			return new Indexer<T>(this)[i0, i1];
		}

		public T At<T>(int i0, int i1, int i2) where T : struct
		{
			return new Indexer<T>(this)[i0, i1, i2];
		}

		public T At<T>(params int[] idx) where T : struct
		{
			return new Indexer<T>(this)[idx];
		}

		public void Set<T>(int i0, T value) where T : struct
		{
			new Indexer<T>(this)[i0] = value;
		}

		public void Set<T>(int i0, int i1, T value) where T : struct
		{
			new Indexer<T>(this)[i0, i1] = value;
		}

		public void Set<T>(int i0, int i1, int i2, T value) where T : struct
		{
			new Indexer<T>(this)[i0, i1, i2] = value;
		}

		public void Set<T>(int[] idx, T value) where T : struct
		{
			new Indexer<T>(this)[idx] = value;
		}

		public Mat ColRange(int startCol, int endCol)
		{
			ThrowIfDisposed();
			return new Mat(NativeMethods.core_Mat_colRange_toMat(ptr, startCol, endCol));
		}

		public Mat ColRange(Range range)
		{
			return ColRange(range.Start, range.End);
		}

		public Mat RowRange(int startRow, int endRow)
		{
			ThrowIfDisposed();
			return new Mat(NativeMethods.core_Mat_rowRange_toMat(ptr, startRow, endRow));
		}

		public Mat RowRange(Range range)
		{
			return RowRange(range.Start, range.End);
		}

		public Mat SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
		{
			if (rowStart >= rowEnd)
			{
				throw new ArgumentException("rowStart >= rowEnd");
			}
			if (colStart >= colEnd)
			{
				throw new ArgumentException("colStart >= colEnd");
			}
			ThrowIfDisposed();
			return new Mat(NativeMethods.core_Mat_subMat(ptr, rowStart, rowEnd, colStart, colEnd));
		}

		public Mat SubMat(Range rowRange, Range colRange)
		{
			return SubMat(rowRange.Start, rowRange.End, colRange.Start, colRange.End);
		}

		public Mat SubMat(Rect roi)
		{
			return SubMat(roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);
		}

		public Mat SubMat(params Range[] ranges)
		{
			if (ranges == null)
			{
				throw new ArgumentNullException();
			}
			ThrowIfDisposed();
			CvSlice[] array = new CvSlice[ranges.Length];
			for (int i = 0; i < ranges.Length; i++)
			{
				array[i] = ranges[i];
			}
			return new Mat(NativeMethods.core_Mat_subMat(ptr, array.Length, array));
		}

		private void CheckArgumentsForConvert(int row, int col, Array data, params MatType[] acceptableTypes)
		{
			ThrowIfDisposed();
			if (row < 0 || row >= Rows)
			{
				throw new ArgumentOutOfRangeException("row");
			}
			if (col < 0 || col >= Cols)
			{
				throw new ArgumentOutOfRangeException("col");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			MatType t = Type();
			if (data == null || data.Length % t.Channels != 0)
			{
				throw new OpenCvSharpException("Provided data element number ({0}) should be multiple of the Mat channels count ({1})", data.Length, t.Channels);
			}
			if (acceptableTypes != null && acceptableTypes.Length != 0 && !EnumerableEx.Any(acceptableTypes, (MatType type) => type == t))
			{
				throw new OpenCvSharpException("Mat data type is not compatible: " + t);
			}
		}

		public void GetArray(int row, int col, byte[] data)
		{
			CheckArgumentsForConvert(row, col, data, 1, 0);
			NativeMethods.core_Mat_nGetB(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, byte[,] data)
		{
			CheckArgumentsForConvert(row, col, data, 1, 0);
			NativeMethods.core_Mat_nGetB(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, short[] data)
		{
			CheckArgumentsForConvert(row, col, data, 3, 2);
			NativeMethods.core_Mat_nGetS(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, short[,] data)
		{
			CheckArgumentsForConvert(row, col, data, 3, 2);
			NativeMethods.core_Mat_nGetS(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, ushort[] data)
		{
			CheckArgumentsForConvert(row, col, data, 3, 2);
			NativeMethods.core_Mat_nGetS(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, ushort[,] data)
		{
			CheckArgumentsForConvert(row, col, data, 3, 2);
			NativeMethods.core_Mat_nGetS(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, int[] data)
		{
			CheckArgumentsForConvert(row, col, data, 4);
			NativeMethods.core_Mat_nGetI(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, int[,] data)
		{
			CheckArgumentsForConvert(row, col, data, 4);
			NativeMethods.core_Mat_nGetI(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, float[] data)
		{
			CheckArgumentsForConvert(row, col, data, 5);
			NativeMethods.core_Mat_nGetF(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, float[,] data)
		{
			CheckArgumentsForConvert(row, col, data, 5);
			NativeMethods.core_Mat_nGetF(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, double[] data)
		{
			CheckArgumentsForConvert(row, col, data, 6);
			NativeMethods.core_Mat_nGetD(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, double[,] data)
		{
			CheckArgumentsForConvert(row, col, data, 6);
			NativeMethods.core_Mat_nGetD(ptr, row, col, data, data.Length);
		}

		public double[] GetArray(int row, int col)
		{
			ThrowIfDisposed();
			if (row < 0 || row >= Rows)
			{
				throw new ArgumentOutOfRangeException("row");
			}
			if (col < 0 || col >= Cols)
			{
				throw new ArgumentOutOfRangeException("col");
			}
			double[] array = new double[Channels()];
			NativeMethods.core_Mat_nGetD(ptr, row, col, array, array.Length);
			return array;
		}

		public void GetArray(int row, int col, Vec3b[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_8UC3);
			NativeMethods.core_Mat_nGetVec3b(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Vec3b[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_8UC3);
			NativeMethods.core_Mat_nGetVec3b(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Vec3d[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
			NativeMethods.core_Mat_nGetVec3d(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Vec3d[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
			NativeMethods.core_Mat_nGetVec3d(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Vec4f[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC4);
			NativeMethods.core_Mat_nGetVec4f(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Vec4f[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC4);
			NativeMethods.core_Mat_nGetVec4f(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Vec6f[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC(6));
			NativeMethods.core_Mat_nGetVec6f(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Vec6f[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC(6));
			NativeMethods.core_Mat_nGetVec6f(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Vec4i[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC4);
			NativeMethods.core_Mat_nGetVec4i(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Vec4i[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC4);
			NativeMethods.core_Mat_nGetVec4i(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Point[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC2);
			NativeMethods.core_Mat_nGetPoint(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Point[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC2);
			NativeMethods.core_Mat_nGetPoint(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Point2f[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC2);
			NativeMethods.core_Mat_nGetPoint2f(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Point2f[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC2);
			NativeMethods.core_Mat_nGetPoint2f(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Point2d[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_64FC2);
			NativeMethods.core_Mat_nGetPoint2d(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Point2d[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_64FC2);
			NativeMethods.core_Mat_nGetPoint2d(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Point3i[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC3);
			NativeMethods.core_Mat_nGetPoint3i(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Point3i[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC3);
			NativeMethods.core_Mat_nGetPoint3i(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Point3f[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC3);
			NativeMethods.core_Mat_nGetPoint3f(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Point3f[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC3);
			NativeMethods.core_Mat_nGetPoint3f(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Point3d[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
			NativeMethods.core_Mat_nGetPoint3d(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Point3d[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
			NativeMethods.core_Mat_nGetPoint3d(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Rect[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC4);
			NativeMethods.core_Mat_nGetRect(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, Rect[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC4);
			NativeMethods.core_Mat_nGetRect(ptr, row, col, data, data.Length);
		}

		public void GetArray(int row, int col, DMatch[] data)
		{
			CheckArgumentsForConvert(row, col, data);
			Vec4f[] array = new Vec4f[data.Length];
			NativeMethods.core_Mat_nGetVec4f(ptr, row, col, array, array.Length);
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = (DMatch)array[i];
			}
		}

		public void GetArray(int row, int col, DMatch[,] data)
		{
			CheckArgumentsForConvert(row, col, data);
			int length = data.GetLength(0);
			int length2 = data.GetLength(1);
			Vec4f[,] array = new Vec4f[length, length2];
			NativeMethods.core_Mat_nGetVec4f(ptr, row, col, array, array.Length);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					data[i, j] = (DMatch)array[i, j];
				}
			}
		}

		public void SetArray(int row, int col, params byte[] data)
		{
			CheckArgumentsForConvert(row, col, data, 0);
			NativeMethods.core_Mat_nSetB(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, byte[,] data)
		{
			CheckArgumentsForConvert(row, col, data, 0);
			NativeMethods.core_Mat_nSetB(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params short[] data)
		{
			CheckArgumentsForConvert(row, col, data, 3, 2);
			NativeMethods.core_Mat_nSetS(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, short[,] data)
		{
			CheckArgumentsForConvert(row, col, data, 3, 2);
			NativeMethods.core_Mat_nSetS(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params ushort[] data)
		{
			CheckArgumentsForConvert(row, col, data, 3, 2);
			NativeMethods.core_Mat_nSetS(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, ushort[,] data)
		{
			CheckArgumentsForConvert(row, col, data, 3, 2);
			NativeMethods.core_Mat_nSetS(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params int[] data)
		{
			CheckArgumentsForConvert(row, col, data, 4);
			NativeMethods.core_Mat_nSetI(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, int[,] data)
		{
			CheckArgumentsForConvert(row, col, data, 4);
			NativeMethods.core_Mat_nSetI(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params float[] data)
		{
			CheckArgumentsForConvert(row, col, data, 5);
			NativeMethods.core_Mat_nSetF(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, float[,] data)
		{
			CheckArgumentsForConvert(row, col, data, 5);
			NativeMethods.core_Mat_nSetF(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params double[] data)
		{
			CheckArgumentsForConvert(row, col, data, 6);
			NativeMethods.core_Mat_nSetD(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, double[,] data)
		{
			CheckArgumentsForConvert(row, col, data, 6);
			NativeMethods.core_Mat_nSetD(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params Vec3b[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_8UC3);
			NativeMethods.core_Mat_nSetVec3b(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, Vec3b[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_8UC3);
			NativeMethods.core_Mat_nSetVec3b(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params Vec3d[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
			NativeMethods.core_Mat_nSetVec3d(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, Vec3d[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
			NativeMethods.core_Mat_nSetVec3d(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params Vec4f[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC4);
			NativeMethods.core_Mat_nSetVec4f(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, Vec4f[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC4);
			NativeMethods.core_Mat_nSetVec4f(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params Vec6f[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC(6));
			NativeMethods.core_Mat_nSetVec6f(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, Vec6f[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC(6));
			NativeMethods.core_Mat_nSetVec6f(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params Vec4i[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC4);
			NativeMethods.core_Mat_nSetVec4i(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, Vec4i[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC4);
			NativeMethods.core_Mat_nSetVec4i(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params Point[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC2);
			NativeMethods.core_Mat_nSetPoint(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, Point[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC2);
			NativeMethods.core_Mat_nSetPoint(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params Point2f[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC2);
			NativeMethods.core_Mat_nSetPoint2f(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, Point2f[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC2);
			NativeMethods.core_Mat_nSetPoint2f(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params Point2d[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_64FC2);
			NativeMethods.core_Mat_nSetPoint2d(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, Point2d[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_64FC2);
			NativeMethods.core_Mat_nSetPoint2d(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params Point3i[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC3);
			NativeMethods.core_Mat_nSetPoint3i(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, Point3i[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC3);
			NativeMethods.core_Mat_nSetPoint3i(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params Point3f[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC3);
			NativeMethods.core_Mat_nSetPoint3f(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, Point3f[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32FC3);
			NativeMethods.core_Mat_nSetPoint3f(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params Point3d[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
			NativeMethods.core_Mat_nSetPoint3d(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, Point3d[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_64FC3);
			NativeMethods.core_Mat_nSetPoint3d(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params Rect[] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC4);
			NativeMethods.core_Mat_nSetRect(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, Rect[,] data)
		{
			CheckArgumentsForConvert(row, col, data, MatType.CV_32SC4);
			NativeMethods.core_Mat_nSetRect(ptr, row, col, data, data.Length);
		}

		public void SetArray(int row, int col, params DMatch[] data)
		{
			CheckArgumentsForConvert(row, col, data);
			Vec4f[] array = EnumerableEx.SelectToArray(data, (DMatch d) => (Vec4f)d);
			NativeMethods.core_Mat_nSetVec4f(ptr, row, col, array, array.Length);
		}

		public void SetArray(int row, int col, DMatch[,] data)
		{
			CheckArgumentsForConvert(row, col, data);
			Vec4f[] array = EnumerableEx.SelectToArray(data, (DMatch d) => (Vec4f)d);
			NativeMethods.core_Mat_nSetVec4f(ptr, row, col, array, array.Length);
		}

		public void Reserve(long sz)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_reserve(ptr, new IntPtr(sz));
		}

		public void Resize(long sz)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_resize1(ptr, new IntPtr(sz));
		}

		public void Resize(long sz, Scalar s)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_resize2(ptr, new IntPtr(sz), s);
		}

		public void Add(Mat m)
		{
			ThrowIfDisposed();
			if (m == null)
			{
				throw new ArgumentNullException();
			}
			m.ThrowIfDisposed();
			NativeMethods.core_Mat_push_back_Mat(ptr, m.CvPtr);
		}

		public void PushBack(Mat m)
		{
			Add(m);
		}

		public void PopBack(long nElems = 1L)
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_pop_back(ptr, new IntPtr(nElems));
		}

		public byte[] ToBytes(string ext = ".png", int[] prms = null)
		{
			return ImEncode(ext, prms);
		}

		public byte[] ToBytes(string ext = ".png", params ImageEncodingParam[] prms)
		{
			return ImEncode(ext, prms);
		}

		public MemoryStream ToMemoryStream(string ext = ".png", params ImageEncodingParam[] prms)
		{
			return new MemoryStream(ToBytes(ext, prms));
		}

		public void WriteToStream(Stream stream, string ext = ".png", params ImageEncodingParam[] prms)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			byte[] array = ToBytes(ext, prms);
			stream.Write(array, 0, array.Length);
		}

		public Mat Alignment(int n = 4)
		{
			int cols = Cv2.AlignSize(Cols, n);
			Mat mat = new Mat(new Mat(Rows, cols, Type()), new Rect(0, 0, Cols, Rows));
			CopyTo(mat);
			return mat;
		}

		public TMat Cast<TMat>() where TMat : Mat, new()
		{
			Type typeFromHandle = typeof(TMat);
			ConstructorInfo constructor = typeFromHandle.GetConstructor(new Type[1]
			{
				typeof(Mat)
			});
			if (constructor == null)
			{
				throw new OpenCvSharpException("Failed to cast to {0}", typeFromHandle.Name);
			}
			return (TMat)constructor.Invoke(new object[1]
			{
				this
			});
		}
	}
	public abstract class Mat<TElem, TInherit> : Mat, ICollection<TElem>, IEnumerable<TElem>, IEnumerable where TElem : struct where TInherit : Mat, new()
	{
		private bool disposed;

		private Mat sourceMat;

		public new TInherit this[int rowStart, int rowEnd, int colStart, int colEnd]
		{
			get
			{
				Mat mat = base[rowStart, rowEnd, colStart, colEnd];
				return Wrap(mat);
			}
			set
			{
				base[rowStart, rowEnd, colStart, colEnd] = value;
			}
		}

		public new TInherit this[Range rowRange, Range colRange]
		{
			get
			{
				Mat mat = base[rowRange, colRange];
				return Wrap(mat);
			}
			set
			{
				base[rowRange, colRange] = value;
			}
		}

		public new TInherit this[Rect roi]
		{
			get
			{
				Mat mat = base[roi];
				return Wrap(mat);
			}
			set
			{
				base[roi] = value;
			}
		}

		public new TInherit this[params Range[] ranges]
		{
			get
			{
				Mat mat = base[ranges];
				return Wrap(mat);
			}
			set
			{
				base[ranges] = value;
			}
		}

		public int Count
		{
			get
			{
				ThrowIfDisposed();
				return (int)NativeMethods.core_Mat_total(ptr);
			}
		}

        public bool IsReadOnly { get { return false; } }

		protected Mat()
		{
		}

		protected Mat(IntPtr ptr)
			: base(ptr)
		{
		}

		protected Mat(Mat mat)
			: base(mat.CvPtr)
		{
			sourceMat = mat;
		}

		protected Mat(int rows, int cols, MatType type)
			: base(rows, cols, type)
		{
		}

		protected Mat(Size size, MatType type)
			: base(size, type)
		{
		}

		protected Mat(int rows, int cols, MatType type, Scalar s)
			: base(rows, cols, type, s)
		{
		}

		protected Mat(Size size, MatType type, Scalar s)
			: base(size, type, s)
		{
		}

		protected Mat(Mat<TElem, TInherit> m, Range rowRange, Range? colRange = default(Range?))
			: base(m, rowRange, colRange)
		{
		}

		protected Mat(Mat<TElem, TInherit> m, params Range[] ranges)
			: base(m, ranges)
		{
		}

		protected Mat(Mat<TElem, TInherit> m, Rect roi)
			: base(m, roi)
		{
		}

		protected Mat(int rows, int cols, MatType type, IntPtr data, long step = 0L)
			: base(rows, cols, type, data, step)
		{
		}

		protected Mat(int rows, int cols, MatType type, Array data, long step = 0L)
			: base(rows, cols, type, data, step)
		{
		}

		protected Mat(IEnumerable<int> sizes, MatType type, IntPtr data, IEnumerable<long> steps = null)
			: base(sizes, type, data, steps)
		{
		}

		protected Mat(IEnumerable<int> sizes, MatType type, Array data, IEnumerable<long> steps = null)
			: base(sizes, type, data, steps)
		{
		}

		protected Mat(IEnumerable<int> sizes, MatType type)
			: base(sizes, type)
		{
		}

		protected Mat(IEnumerable<int> sizes, MatType type, Scalar s)
			: base(sizes, type, s)
		{
		}

		protected Mat(CvMat m, bool copyData = false)
			: base(m, copyData)
		{
		}

		protected Mat(IplImage img, bool copyData = false)
			: base(img, copyData)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (sourceMat == null)
				{
					base.Dispose(disposing);
				}
				sourceMat = null;
				disposed = true;
			}
		}

		public abstract MatIndexer<TElem> GetIndexer();

		public abstract IEnumerator<TElem> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public abstract TElem[] ToArray();

		public abstract TElem[,] ToRectangularArray();

		protected TInherit Wrap(Mat mat)
		{
			TInherit val = new TInherit();
			mat.AssignTo(val);
			return val;
		}

		public new TInherit Clone()
		{
			Mat mat = base.Clone();
			return Wrap(mat);
		}

		public TInherit Reshape(int rows)
		{
			Mat mat = base.Reshape(0, rows);
			return Wrap(mat);
		}

		public TInherit Reshape(params int[] newDims)
		{
			Mat mat = Reshape(0, newDims);
			return Wrap(mat);
		}

		public new TInherit T()
		{
			Mat mat = base.T();
			return Wrap(mat);
		}

		public new TInherit SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
		{
			Mat mat = base.SubMat(rowStart, rowEnd, colStart, colEnd);
			return Wrap(mat);
		}

		public new TInherit SubMat(Range rowRange, Range colRange)
		{
			return SubMat(rowRange.Start, rowRange.End, colRange.Start, colRange.End);
		}

		public new TInherit SubMat(Rect roi)
		{
			return SubMat(roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);
		}

		public new TInherit SubMat(params Range[] ranges)
		{
			Mat mat = base.SubMat(ranges);
			return Wrap(mat);
		}

		public abstract void Add(TElem value);

		public bool Remove(TElem item)
		{
			throw new NotImplementedException();
		}

		public bool Contains(TElem item)
		{
			return IndexOf(item) >= 0;
		}

		public int IndexOf(TElem item)
		{
			return Array.IndexOf(ToArray(), item);
		}

		public void Clear()
		{
			ThrowIfDisposed();
			NativeMethods.core_Mat_pop_back(ptr, new IntPtr(Total()));
		}

		public void CopyTo(TElem[] array, int arrayIndex)
		{
			ThrowIfDisposed();
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			TElem[] array2 = ToArray();
			if (array.Length >= array2.Length + arrayIndex)
			{
				throw new ArgumentException("Too short array.Length");
			}
			Array.Copy(array2, 0, array, arrayIndex, array2.Length);
		}
	}
}
