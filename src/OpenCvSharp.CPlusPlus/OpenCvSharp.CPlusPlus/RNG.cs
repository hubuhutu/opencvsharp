using System;

namespace OpenCvSharp.CPlusPlus
{
	public class RNG
	{
		public ulong State
		{
			get;
			set;
		}

		public RNG()
		{
			State = NativeMethods.core_RNG_new();
		}

		public RNG(ulong state)
		{
			State = NativeMethods.core_RNG_new(state);
		}

		public static explicit operator byte(RNG self)
		{
			if (self == null)
			{
				throw new ArgumentNullException("self");
			}
			return NativeMethods.core_RNG_operator_uchar(self.State);
		}

		public static explicit operator sbyte(RNG self)
		{
			if (self == null)
			{
				throw new ArgumentNullException("self");
			}
			return NativeMethods.core_RNG_operator_schar(self.State);
		}

		public static explicit operator ushort(RNG self)
		{
			if (self == null)
			{
				throw new ArgumentNullException("self");
			}
			return NativeMethods.core_RNG_operator_ushort(self.State);
		}

		public static explicit operator short(RNG self)
		{
			if (self == null)
			{
				throw new ArgumentNullException("self");
			}
			return NativeMethods.core_RNG_operator_short(self.State);
		}

		public static explicit operator uint(RNG self)
		{
			if (self == null)
			{
				throw new ArgumentNullException("self");
			}
			return NativeMethods.core_RNG_operator_uint(self.State);
		}

		public static explicit operator int(RNG self)
		{
			if (self == null)
			{
				throw new ArgumentNullException("self");
			}
			return NativeMethods.core_RNG_operator_int(self.State);
		}

		public static explicit operator float(RNG self)
		{
			if (self == null)
			{
				throw new ArgumentNullException("self");
			}
			return NativeMethods.core_RNG_operator_float(self.State);
		}

		public static explicit operator double(RNG self)
		{
			if (self == null)
			{
				throw new ArgumentNullException("self");
			}
			return NativeMethods.core_RNG_operator_double(self.State);
		}

		public uint Next()
		{
			return NativeMethods.core_RNG_next(State);
		}

		public uint Run(uint n)
		{
			return NativeMethods.core_RNG_operatorThis(State, n);
		}

		public uint Run()
		{
			return NativeMethods.core_RNG_operatorThis(State);
		}

		public int Uniform(int a, int b)
		{
			return NativeMethods.core_RNG_uniform(State, a, b);
		}

		public float Uniform(float a, float b)
		{
			return NativeMethods.core_RNG_uniform(State, a, b);
		}

		public double Uniform(double a, double b)
		{
			return NativeMethods.core_RNG_uniform(State, a, b);
		}

		public void Fill(InputOutputArray mat, DistributionType distType, InputArray a, InputArray b, bool saturateRange = false)
		{
			if (mat == null)
			{
				throw new ArgumentNullException("mat");
			}
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			mat.ThrowIfNotReady();
			a.ThrowIfDisposed();
			b.ThrowIfDisposed();
			NativeMethods.core_RNG_fill(State, mat.CvPtr, (int)distType, a.CvPtr, b.CvPtr, saturateRange ? 1 : 0);
			mat.Fix();
		}

		public double Gaussian(double sigma)
		{
			return NativeMethods.core_RNG_gaussian(State, sigma);
		}
	}
}
