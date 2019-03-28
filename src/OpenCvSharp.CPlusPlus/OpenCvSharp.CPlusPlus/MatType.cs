using System;

namespace OpenCvSharp.CPlusPlus
{
	public struct MatType : IEquatable<MatType>, IEquatable<int>
	{
		public int Value;

		private const int CV_CN_MAX = 512;

		private const int CV_CN_SHIFT = 3;

		private const int CV_DEPTH_MAX = 8;

		public const int CV_8U = 0;

		public const int CV_8S = 1;

		public const int CV_16U = 2;

		public const int CV_16S = 3;

		public const int CV_32S = 4;

		public const int CV_32F = 5;

		public const int CV_64F = 6;

		public const int CV_USRTYPE1 = 7;

		public static readonly MatType CV_8UC1 = CV_8UC(1);

		public static readonly MatType CV_8UC2 = CV_8UC(2);

		public static readonly MatType CV_8UC3 = CV_8UC(3);

		public static readonly MatType CV_8UC4 = CV_8UC(4);

		public static readonly MatType CV_8SC1 = CV_8SC(1);

		public static readonly MatType CV_8SC2 = CV_8SC(2);

		public static readonly MatType CV_8SC3 = CV_8SC(3);

		public static readonly MatType CV_8SC4 = CV_8SC(4);

		public static readonly MatType CV_16UC1 = CV_16UC(1);

		public static readonly MatType CV_16UC2 = CV_16UC(2);

		public static readonly MatType CV_16UC3 = CV_16UC(3);

		public static readonly MatType CV_16UC4 = CV_16UC(4);

		public static readonly MatType CV_16SC1 = CV_16SC(1);

		public static readonly MatType CV_16SC2 = CV_16SC(2);

		public static readonly MatType CV_16SC3 = CV_16SC(3);

		public static readonly MatType CV_16SC4 = CV_16SC(4);

		public static readonly MatType CV_32SC1 = CV_32SC(1);

		public static readonly MatType CV_32SC2 = CV_32SC(2);

		public static readonly MatType CV_32SC3 = CV_32SC(3);

		public static readonly MatType CV_32SC4 = CV_32SC(4);

		public static readonly MatType CV_32FC1 = CV_32FC(1);

		public static readonly MatType CV_32FC2 = CV_32FC(2);

		public static readonly MatType CV_32FC3 = CV_32FC(3);

		public static readonly MatType CV_32FC4 = CV_32FC(4);

		public static readonly MatType CV_64FC1 = CV_64FC(1);

		public static readonly MatType CV_64FC2 = CV_64FC(2);

		public static readonly MatType CV_64FC3 = CV_64FC(3);

		public static readonly MatType CV_64FC4 = CV_64FC(4);

		public int Depth => Value & 7;

		public bool IsInteger => Depth < 5;

		public int Channels => (Value >> 3) + 1;

		public MatType(int value)
		{
			Value = value;
		}

		public static implicit operator int(MatType self)
		{
			return self.Value;
		}

		public static implicit operator MatType(int value)
		{
			return new MatType(value);
		}

		public bool Equals(MatType other)
		{
			return Value == other.Value;
		}

		public bool Equals(int other)
		{
			return Value == other;
		}

		public override bool Equals(object other)
		{
			if (other == null)
			{
				return false;
			}
			if (other.GetType() != typeof(MatType))
			{
				return false;
			}
			return Equals((MatType)other);
		}

		public static bool operator ==(MatType self, MatType other)
		{
			return self.Equals(other);
		}

		public static bool operator !=(MatType self, MatType other)
		{
			return !self.Equals(other);
		}

		public static bool operator ==(MatType self, int other)
		{
			return self.Equals(other);
		}

		public static bool operator !=(MatType self, int other)
		{
			return !self.Equals(other);
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public override string ToString()
		{
			string text;
			switch (Depth)
			{
			case 0:
				text = "CV_8U";
				break;
			case 1:
				text = "CV_8S";
				break;
			case 2:
				text = "CV_16U";
				break;
			case 3:
				text = "CV_16S";
				break;
			case 4:
				text = "CV_32S";
				break;
			case 5:
				text = "CV_32F";
				break;
			case 6:
				text = "CV_64F";
				break;
			case 7:
				text = "CV_USRTYPE1";
				break;
			default:
				throw new OpenCvSharpException("Unsupported CvType value: " + Value);
			}
			int channels = Channels;
			if (channels <= 4)
			{
				return text + "C" + channels;
			}
			return text + "C(" + channels + ")";
		}

		public static MatType CV_8UC(int ch)
		{
			return MakeType(0, ch);
		}

		public static MatType CV_8SC(int ch)
		{
			return MakeType(1, ch);
		}

		public static MatType CV_16UC(int ch)
		{
			return MakeType(2, ch);
		}

		public static MatType CV_16SC(int ch)
		{
			return MakeType(3, ch);
		}

		public static MatType CV_32SC(int ch)
		{
			return MakeType(4, ch);
		}

		public static MatType CV_32FC(int ch)
		{
			return MakeType(5, ch);
		}

		public static MatType CV_64FC(int ch)
		{
			return MakeType(6, ch);
		}

		public static MatType MakeType(int depth, int channels)
		{
			if (channels <= 0 || channels >= 512)
			{
				throw new OpenCvSharpException("Channels count should be 1.." + 511);
			}
			if (depth < 0 || depth >= 8)
			{
				throw new OpenCvSharpException("Data type depth should be 0.." + 7);
			}
			return (depth & 7) + (channels - 1 << 3);
		}
	}
}
