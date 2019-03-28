using OpenCvSharp.Utilities;
using System;

namespace OpenCvSharp.CPlusPlus
{
	public sealed class MatExpr : DisposableCvObject
	{
		public class ColIndexer : MatExprRowColIndexer
		{
			public override MatExpr this[int x]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new MatExpr(NativeMethods.core_MatExpr_col(parent.CvPtr, x));
				}
			}

			protected internal ColIndexer(MatExpr parent)
				: base(parent)
			{
			}
		}

		public class RowIndexer : MatExprRowColIndexer
		{
			public override MatExpr this[int y]
			{
				get
				{
					parent.ThrowIfDisposed();
					return new MatExpr(NativeMethods.core_MatExpr_row(parent.CvPtr, y));
				}
			}

			protected internal RowIndexer(MatExpr parent)
				: base(parent)
			{
			}
		}

		private bool disposed;

		private ColIndexer col;

		private RowIndexer row;

		public MatExpr this[int rowStart, int rowEnd, int colStart, int colEnd]
		{
			get
			{
				return SubMat(rowStart, rowEnd, colStart, colEnd);
			}
		}

		public MatExpr this[Range rowRange, Range colRange]
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
				NativeMethods.core_Mat_assignment_FromMatExpr(SubMat(rowRange, colRange).CvPtr, value.CvPtr);
			}
		}

		public MatExpr this[Rect roi]
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
				NativeMethods.core_Mat_assignment_FromMatExpr(SubMat(roi).CvPtr, value.CvPtr);
			}
		}

		public ColIndexer Col
		{
			get
			{
				if (col == null)
				{
					col = new ColIndexer(this);
				}
				return col;
			}
		}

		public RowIndexer Row
		{
			get
			{
				if (row == null)
				{
					row = new RowIndexer(this);
				}
				return row;
			}
		}

		public Size Size
		{
			get
			{
				ThrowIfDisposed();
				try
				{
					return NativeMethods.core_MatExpr_size(ptr);
				}
				catch (BadImageFormatException ex)
				{
					throw PInvokeHelper.CreateException(ex);
				}
			}
		}

		public MatrixType Type
		{
			get
			{
				ThrowIfDisposed();
				try
				{
					return (MatrixType)NativeMethods.core_MatExpr_type(ptr);
				}
				catch (BadImageFormatException ex)
				{
					throw PInvokeHelper.CreateException(ex);
				}
			}
		}

		public MatExpr Abs()
		{
			return Cv2.Abs(this);
		}

		internal MatExpr(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		internal MatExpr(Mat mat)
		{
			if (mat == null)
			{
				throw new ArgumentNullException("mat");
			}
			ptr = NativeMethods.core_MatExpr_new(mat.CvPtr);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (ptr != IntPtr.Zero)
					{
						NativeMethods.core_MatExpr_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static implicit operator Mat(MatExpr self)
		{
			try
			{
				return new Mat(NativeMethods.core_MatExpr_toMat(self.ptr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public Mat ToMat()
		{
			return this;
		}

		public static implicit operator MatExpr(Mat mat)
		{
			return new MatExpr(mat);
		}

		public static MatExpr FromMat(Mat mat)
		{
			return new MatExpr(mat);
		}

		public static MatExpr operator +(MatExpr e)
		{
			return e;
		}

		public static MatExpr operator -(MatExpr e)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorUnaryMinus_MatExpr(e.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator ~(MatExpr e)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorUnaryNot_MatExpr(e.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator +(MatExpr e, Mat m)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			e.ThrowIfDisposed();
			m.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorAdd_MatExprMat(e.CvPtr, m.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator +(Mat m, MatExpr e)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			m.ThrowIfDisposed();
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorAdd_MatMatExpr(m.CvPtr, e.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator +(MatExpr e, Scalar s)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorAdd_MatExprScalar(e.CvPtr, s));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator +(Scalar s, MatExpr e)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorAdd_ScalarMatExpr(s, e.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator +(MatExpr e1, MatExpr e2)
		{
			if (e1 == null)
			{
				throw new ArgumentNullException("e1");
			}
			if (e2 == null)
			{
				throw new ArgumentNullException("e2");
			}
			e1.ThrowIfDisposed();
			e2.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorAdd_MatExprMatExpr(e1.CvPtr, e2.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator -(MatExpr e, Mat m)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			e.ThrowIfDisposed();
			m.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorSubtract_MatExprMat(e.CvPtr, m.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator -(Mat m, MatExpr e)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			m.ThrowIfDisposed();
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorSubtract_MatMatExpr(m.CvPtr, e.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator -(MatExpr e, Scalar s)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorSubtract_MatExprScalar(e.CvPtr, s));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator -(Scalar s, MatExpr e)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorSubtract_ScalarMatExpr(s, e.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator -(MatExpr e1, MatExpr e2)
		{
			if (e1 == null)
			{
				throw new ArgumentNullException("e1");
			}
			if (e2 == null)
			{
				throw new ArgumentNullException("e2");
			}
			e1.ThrowIfDisposed();
			e2.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorSubtract_MatExprMatExpr(e1.CvPtr, e2.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator *(MatExpr e, Mat m)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			e.ThrowIfDisposed();
			m.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorMultiply_MatExprMat(e.CvPtr, m.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator *(Mat m, MatExpr e)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			m.ThrowIfDisposed();
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorMultiply_MatMatExpr(m.CvPtr, e.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator *(MatExpr e, double s)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorMultiply_MatExprDouble(e.CvPtr, s));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator *(double s, MatExpr e)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorMultiply_DoubleMatExpr(s, e.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator *(MatExpr e1, MatExpr e2)
		{
			if (e1 == null)
			{
				throw new ArgumentNullException("e1");
			}
			if (e2 == null)
			{
				throw new ArgumentNullException("e2");
			}
			e1.ThrowIfDisposed();
			e2.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorMultiply_MatExprMatExpr(e1.CvPtr, e2.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator /(MatExpr e, Mat m)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			e.ThrowIfDisposed();
			m.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorDivide_MatExprMat(e.CvPtr, m.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator /(Mat m, MatExpr e)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			m.ThrowIfDisposed();
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorDivide_MatMatExpr(m.CvPtr, e.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator /(MatExpr e, double s)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorDivide_MatExprDouble(e.CvPtr, s));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator /(double s, MatExpr e)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorDivide_DoubleMatExpr(s, e.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public static MatExpr operator /(MatExpr e1, MatExpr e2)
		{
			if (e1 == null)
			{
				throw new ArgumentNullException("e1");
			}
			if (e2 == null)
			{
				throw new ArgumentNullException("e2");
			}
			e1.ThrowIfDisposed();
			e2.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_operatorDivide_MatExprMatExpr(e1.CvPtr, e2.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public Mat Cross(Mat m)
		{
			ThrowIfDisposed();
			m.ThrowIfDisposed();
			try
			{
				return new Mat(NativeMethods.core_MatExpr_cross(ptr, m.CvPtr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public MatExpr Diag(int d = 0)
		{
			ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_MatExpr_diag(ptr, d));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public double Dot(Mat m)
		{
			ThrowIfDisposed();
			m.ThrowIfDisposed();
			try
			{
				return NativeMethods.core_MatExpr_dot(ptr, m.CvPtr);
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public MatExpr Inv(MatrixDecomposition method = MatrixDecomposition.LU)
		{
			ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_MatExpr_inv(ptr, (int)method));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public MatExpr Mul(MatExpr e, double scale = 1.0)
		{
			ThrowIfDisposed();
			e.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_MatExpr_mul_toMatExpr(ptr, e.CvPtr, scale));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public MatExpr Mul(Mat m, double scale = 1.0)
		{
			ThrowIfDisposed();
			m.ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_MatExpr_mul_toMat(ptr, m.CvPtr, scale));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public MatExpr SubMat(int rowStart, int rowEnd, int colStart, int colEnd)
		{
			ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_MatExpr_submat(ptr, rowStart, rowEnd, colStart, colEnd));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}

		public MatExpr SubMat(Range rowRange, Range colRange)
		{
			return SubMat(rowRange.Start, rowRange.End, colRange.Start, colRange.End);
		}

		public MatExpr SubMat(Rect roi)
		{
			return SubMat(roi.Y, roi.Y + roi.Height, roi.X, roi.X + roi.Width);
		}

		public MatExpr T()
		{
			ThrowIfDisposed();
			try
			{
				return new MatExpr(NativeMethods.core_MatExpr_t(ptr));
			}
			catch (BadImageFormatException ex)
			{
				throw PInvokeHelper.CreateException(ex);
			}
		}
	}
}
