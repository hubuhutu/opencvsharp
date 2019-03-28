using OpenCvSharp.CPlusPlus.Gpu;
using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class InputArray : DisposableCvObject
	{
		private bool disposed;

		private object obj;

		public InOutArrayKind Kind
		{
			get
			{
				ThrowIfDisposed();
				return (InOutArrayKind)NativeMethods.core_InputArray_kind(ptr);
			}
		}

		internal InputArray(IntPtr ptr)
		{
			base.ptr = ptr;
			obj = null;
		}

		internal InputArray(Mat mat)
		{
			if (mat == null)
			{
				throw new ArgumentNullException("mat");
			}
			ptr = NativeMethods.core_InputArray_new_byMat(mat.CvPtr);
			obj = mat;
		}

		internal InputArray(MatExpr expr)
		{
			if (expr == null)
			{
				throw new ArgumentNullException("expr");
			}
			ptr = NativeMethods.core_InputArray_new_byMatExpr(expr.CvPtr);
			obj = null;
		}

		internal InputArray(Scalar val)
		{
			ptr = NativeMethods.core_InputArray_new_byScalar(val);
		}

		internal InputArray(double val)
		{
			ptr = NativeMethods.core_InputArray_new_byDouble(val);
		}

		internal InputArray(GpuMat mat)
		{
			if (mat == null)
			{
				throw new ArgumentNullException("mat");
			}
			ptr = NativeMethods.core_InputArray_new_byGpuMat(mat.CvPtr);
			obj = mat;
		}

		internal InputArray(IEnumerable<Mat> mat)
		{
			if (mat == null)
			{
				throw new ArgumentNullException("mat");
			}
			using (VectorOfMat vectorOfMat = new VectorOfMat(mat))
			{
				ptr = NativeMethods.core_InputArray_new_byVectorOfMat(vectorOfMat.CvPtr);
			}
			obj = mat;
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (ptr != IntPtr.Zero)
					{
						NativeMethods.core_InputArray_delete(ptr);
						ptr = IntPtr.Zero;
					}
					obj = null;
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static implicit operator InputArray(Mat mat)
		{
			return Create(mat);
		}

		public static implicit operator InputArray(MatExpr expr)
		{
			return Create(expr);
		}

		public static implicit operator InputArray(Scalar val)
		{
			return Create(val);
		}

		public static implicit operator InputArray(double val)
		{
			return Create(val);
		}

		public static implicit operator InputArray(GpuMat mat)
		{
			return Create(mat);
		}

		public static explicit operator InputArray(List<Mat> mats)
		{
			return Create(mats);
		}

		public static explicit operator InputArray(Mat[] mats)
		{
			return Create((IEnumerable<Mat>)mats);
		}

		public static InputArray Create(Mat mat)
		{
			return new InputArray(mat);
		}

		public static InputArray Create(MatExpr expr)
		{
			return new InputArray(expr);
		}

		public static InputArray Create(Scalar val)
		{
			return new InputArray(val);
		}

		public static InputArray Create(double val)
		{
			return new InputArray(val);
		}

		public static InputArray Create(GpuMat mat)
		{
			return new InputArray(mat);
		}

		public static InputArray Create(IEnumerable<Mat> matVector)
		{
			return new InputArray(matVector);
		}

		public static InputArray Create<T>(IEnumerable<T> enumerable) where T : struct
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}
			return Create(new List<T>(enumerable).ToArray());
		}

		public static InputArray Create<T>(IEnumerable<T> enumerable, MatType type) where T : struct
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}
			return Create(new List<T>(enumerable).ToArray(), type);
		}

		public static InputArray Create<T>(T[] array) where T : struct
		{
			MatType type = EstimateType(typeof(T));
			return Create(array, type);
		}

		public static InputArray Create<T>(T[] array, MatType type) where T : struct
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Length == 0)
			{
				throw new ArgumentException("array.Length == 0");
			}
			return new InputArray(new Mat(array.Length, 1, type, array, 0L));
		}

		public static InputArray Create<T>(T[,] array) where T : struct
		{
			MatType type = EstimateType(typeof(T));
			return Create(array, type);
		}

		public static InputArray Create<T>(T[,] array, MatType type) where T : struct
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int length = array.GetLength(0);
			int length2 = array.GetLength(1);
			if (length == 0)
			{
				throw new ArgumentException("array.GetLength(0) == 0");
			}
			if (length2 == 0)
			{
				throw new ArgumentException("array.GetLength(1) == 0");
			}
			return new InputArray(new Mat(length, length2, type, array, 0L));
		}

		private static MatType EstimateType(Type t)
		{
			if (!t.IsValueType)
			{
				throw new ArgumentException();
			}
			switch (Type.GetTypeCode(t))
			{
			case TypeCode.Byte:
				return MatType.CV_8UC1;
			case TypeCode.SByte:
				return MatType.CV_8SC1;
			case TypeCode.UInt16:
				return MatType.CV_16UC1;
			case TypeCode.Char:
			case TypeCode.Int16:
				return MatType.CV_16SC1;
			case TypeCode.Int32:
			case TypeCode.UInt32:
				return MatType.CV_32SC1;
			case TypeCode.Single:
				return MatType.CV_32FC1;
			case TypeCode.Double:
				return MatType.CV_64FC1;
			default:
				if (t == typeof(Point))
				{
					return MatType.CV_32SC2;
				}
				if (t == typeof(Point2f))
				{
					return MatType.CV_32FC2;
				}
				if (t == typeof(Point2d))
				{
					return MatType.CV_64FC2;
				}
				if (t == typeof(Point3i))
				{
					return MatType.CV_32SC3;
				}
				if (t == typeof(Point3f))
				{
					return MatType.CV_32FC3;
				}
				if (t == typeof(Point3d))
				{
					return MatType.CV_32FC3;
				}
				if (t == typeof(Range))
				{
					return MatType.CV_32SC2;
				}
				if (t == typeof(Rangef))
				{
					return MatType.CV_32FC2;
				}
				if (t == typeof(Rect))
				{
					return MatType.CV_32SC4;
				}
				if (t == typeof(Size))
				{
					return MatType.CV_32SC2;
				}
				if (t == typeof(Size2f))
				{
					return MatType.CV_32FC2;
				}
				if (t == typeof(Vec2b))
				{
					return MatType.CV_8UC2;
				}
				if (t == typeof(Vec3b))
				{
					return MatType.CV_8UC3;
				}
				if (t == typeof(Vec4b))
				{
					return MatType.CV_8UC4;
				}
				if (t == typeof(Vec6b))
				{
					return MatType.CV_8UC(6);
				}
				if (t == typeof(Vec2s))
				{
					return MatType.CV_16SC2;
				}
				if (t == typeof(Vec3s))
				{
					return MatType.CV_16SC3;
				}
				if (t == typeof(Vec4s))
				{
					return MatType.CV_16SC4;
				}
				if (t == typeof(Vec6s))
				{
					return MatType.CV_16SC(6);
				}
				if (t == typeof(Vec2w))
				{
					return MatType.CV_16UC2;
				}
				if (t == typeof(Vec3w))
				{
					return MatType.CV_16UC3;
				}
				if (t == typeof(Vec4w))
				{
					return MatType.CV_16UC4;
				}
				if (t == typeof(Vec6w))
				{
					return MatType.CV_16UC(6);
				}
				if (t == typeof(Vec2s))
				{
					return MatType.CV_32SC2;
				}
				if (t == typeof(Vec3s))
				{
					return MatType.CV_32SC3;
				}
				if (t == typeof(Vec4s))
				{
					return MatType.CV_32SC4;
				}
				if (t == typeof(Vec6s))
				{
					return MatType.CV_32SC(6);
				}
				if (t == typeof(Vec2f))
				{
					return MatType.CV_32FC2;
				}
				if (t == typeof(Vec3f))
				{
					return MatType.CV_32FC3;
				}
				if (t == typeof(Vec4f))
				{
					return MatType.CV_32FC4;
				}
				if (t == typeof(Vec6f))
				{
					return MatType.CV_32FC(6);
				}
				if (t == typeof(Vec2d))
				{
					return MatType.CV_64FC2;
				}
				if (t == typeof(Vec3d))
				{
					return MatType.CV_64FC3;
				}
				if (t == typeof(Vec4d))
				{
					return MatType.CV_64FC4;
				}
				if (t == typeof(Vec6d))
				{
					return MatType.CV_64FC(6);
				}
				throw new ArgumentException("Not supported value type for InputArray");
			}
		}
	}
}
