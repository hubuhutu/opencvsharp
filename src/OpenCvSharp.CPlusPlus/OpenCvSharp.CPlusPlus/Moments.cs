using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class Moments
	{
		public double M00;

		public double M10;

		public double M01;

		public double M20;

		public double M11;

		public double M02;

		public double M30;

		public double M21;

		public double M12;

		public double M03;

		public double Mu20;

		public double Mu11;

		public double Mu02;

		public double Mu30;

		public double Mu21;

		public double Mu12;

		public double Mu03;

		public double Nu20;

		public double Nu11;

		public double Nu02;

		public double Nu30;

		public double Nu21;

		public double Nu12;

		public double Nu03;

		public Moments()
		{
			M00 = (M10 = (M01 = (M20 = (M11 = (M02 = (M30 = (M21 = (M12 = (M03 = (Mu20 = (Mu11 = (Mu02 = (Mu30 = (Mu21 = (Mu12 = (Mu03 = (Nu20 = (Nu11 = (Nu02 = (Nu30 = (Nu21 = (Nu12 = (Nu03 = 0.0)))))))))))))))))))))));
		}

		public Moments(double m00, double m10, double m01, double m20, double m11, double m02, double m30, double m21, double m12, double m03)
		{
			Initialize(m00, m10, m01, m20, m11, m02, m30, m21, m12, m03);
		}

		public Moments(InputArray array, bool binaryImage = false)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			array.ThrowIfDisposed();
			InitializeFromInputArray(array, binaryImage);
		}

		public Moments(byte[,] array, bool binaryImage = false)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int length = array.GetLength(0);
			int length2 = array.GetLength(1);
			using (Mat mat = new Mat(length, length2, MatType.CV_8UC1, array, 0L))
			{
				InitializeFromInputArray(mat, binaryImage);
			}
		}

		public Moments(float[,] array, bool binaryImage = false)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int length = array.GetLength(0);
			int length2 = array.GetLength(1);
			using (Mat mat = new Mat(length, length2, MatType.CV_32FC1, array, 0L))
			{
				InitializeFromInputArray(mat, binaryImage);
			}
		}

		public Moments(IEnumerable<Point> array, bool binaryImage = false)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			Point[] array2 = EnumerableEx.ToArray(array);
			using (Mat mat = new Mat(array2.Length, 1, MatType.CV_32SC2, array2, 0L))
			{
				InitializeFromInputArray(mat, binaryImage);
			}
		}

		public Moments(IEnumerable<Point2f> array, bool binaryImage = false)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			Point2f[] array2 = EnumerableEx.ToArray(array);
			using (Mat mat = new Mat(array2.Length, 1, MatType.CV_32FC2, array2, 0L))
			{
				InitializeFromInputArray(mat, binaryImage);
			}
		}

		private void InitializeFromInputArray(InputArray array, bool binaryImage)
		{
			WCvMoments wCvMoments = NativeMethods.imgproc_moments(array.CvPtr, binaryImage ? 1 : 0);
			Initialize(wCvMoments.m00, wCvMoments.m10, wCvMoments.m01, wCvMoments.m20, wCvMoments.m11, wCvMoments.m02, wCvMoments.m30, wCvMoments.m21, wCvMoments.m12, wCvMoments.m03);
		}

		private void Initialize(double m00, double m10, double m01, double m20, double m11, double m02, double m30, double m21, double m12, double m03)
		{
			M00 = m00;
			M10 = m10;
			M01 = m01;
			M20 = m20;
			M11 = m11;
			M02 = m02;
			M30 = m30;
			M21 = m21;
			M12 = m12;
			M03 = m03;
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			if (Math.Abs(M00) > double.Epsilon)
			{
				num3 = 1.0 / M00;
				num = M10 * num3;
				num2 = M01 * num3;
			}
			Mu20 = M20 - M10 * num;
			Mu11 = M11 - M10 * num2;
			Mu02 = M02 - M01 * num2;
			Mu30 = M30 - num * (3.0 * Mu20 + num * M10);
			Mu21 = M21 - num * (2.0 * Mu11 + num * M01) - num2 * Mu20;
			Mu12 = M12 - num2 * (2.0 * Mu11 + num2 * M10) - num * Mu02;
			Mu03 = M03 - num2 * (3.0 * Mu02 + num2 * M01);
			double num4 = Math.Sqrt(Math.Abs(num3));
			double num5 = num3 * num3;
			double num6 = num5 * num4;
			Nu20 = Mu20 * num5;
			Nu11 = Mu11 * num5;
			Nu02 = Mu02 * num5;
			Nu30 = Mu30 * num6;
			Nu21 = Mu21 * num6;
			Nu12 = Mu12 * num6;
			Nu03 = Mu03 * num6;
		}

		public static explicit operator CvMoments(Moments self)
		{
			if (self == null)
			{
				throw new ArgumentNullException("self");
			}
			double num = Math.Abs(self.M00);
			return new CvMoments
			{
				M00 = self.M00,
				M10 = self.M10,
				M01 = self.M01,
				M20 = self.M20,
				M11 = self.M11,
				M02 = self.M02,
				M30 = self.M30,
				M21 = self.M21,
				M12 = self.M12,
				M03 = self.M03,
				Mu20 = self.Mu20,
				Mu11 = self.Mu11,
				Mu02 = self.Mu02,
				Mu30 = self.Mu30,
				Mu21 = self.Mu21,
				Mu12 = self.Mu12,
				Mu03 = self.Mu03,
				InvSqrtM00 = ((num > double.Epsilon) ? (1.0 / Math.Sqrt(num)) : 0.0)
			};
		}

		public static explicit operator Moments(CvMoments m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			return new Moments(m.M00, m.M10, m.M01, m.M20, m.M11, m.M02, m.M30, m.M21, m.M12, m.M03);
		}

		public double[] HuMoments()
		{
			double[] obj = new double[7];
			double num = Nu30 + Nu12;
			double num2 = Nu21 + Nu03;
			double num3 = num * num;
			double num4 = num2 * num2;
			double num5 = 4.0 * Nu11;
			double num6 = Nu20 + Nu02;
			double num7 = Nu20 - Nu02;
			obj[0] = num6;
			obj[1] = num7 * num7 + num5 * Nu11;
			obj[3] = num3 + num4;
			obj[5] = num7 * (num3 - num4) + num5 * num * num2;
			num *= num3 - 3.0 * num4;
			num2 *= 3.0 * num3 - num4;
			num3 = Nu30 - 3.0 * Nu12;
			num4 = 3.0 * Nu21 - Nu03;
			obj[2] = num3 * num3 + num4 * num4;
			obj[4] = num3 * num + num4 * num2;
			obj[6] = num4 * num - num3 * num2;
			return obj;
		}
	}
}
