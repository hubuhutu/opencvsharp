using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Scalar : ICloneable, IEquatable<Scalar>
	{
		public double Val0;

		public double Val1;

		public double Val2;

		public double Val3;

		private static readonly Random random = new Random();

		public static readonly Scalar AliceBlue = FromRgb(240, 248, 255);

		public static readonly Scalar AntiqueWhite = FromRgb(250, 235, 215);

		public static readonly Scalar Aqua = FromRgb(0, 255, 255);

		public static readonly Scalar Aquamarine = FromRgb(127, 255, 212);

		public static readonly Scalar Azure = FromRgb(240, 255, 255);

		public static readonly Scalar Beige = FromRgb(245, 245, 220);

		public static readonly Scalar Bisque = FromRgb(255, 228, 196);

		public static readonly Scalar Black = FromRgb(0, 0, 0);

		public static readonly Scalar BlanchedAlmond = FromRgb(255, 235, 205);

		public static readonly Scalar Blue = FromRgb(0, 0, 255);

		public static readonly Scalar BlueViolet = FromRgb(138, 43, 226);

		public static readonly Scalar Brown = FromRgb(165, 42, 42);

		public static readonly Scalar BurlyWood = FromRgb(222, 184, 135);

		public static readonly Scalar CadetBlue = FromRgb(95, 158, 160);

		public static readonly Scalar Chartreuse = FromRgb(127, 255, 0);

		public static readonly Scalar Chocolate = FromRgb(210, 105, 30);

		public static readonly Scalar Coral = FromRgb(255, 127, 80);

		public static readonly Scalar CornflowerBlue = FromRgb(100, 149, 237);

		public static readonly Scalar Cornsilk = FromRgb(255, 248, 220);

		public static readonly Scalar Crimson = FromRgb(220, 20, 60);

		public static readonly Scalar Cyan = FromRgb(0, 255, 255);

		public static readonly Scalar DarkBlue = FromRgb(0, 0, 139);

		public static readonly Scalar DarkCyan = FromRgb(0, 139, 139);

		public static readonly Scalar DarkGoldenrod = FromRgb(184, 134, 11);

		public static readonly Scalar DarkGray = FromRgb(169, 169, 169);

		public static readonly Scalar DarkGreen = FromRgb(0, 100, 0);

		public static readonly Scalar DarkKhaki = FromRgb(189, 183, 107);

		public static readonly Scalar DarkMagenta = FromRgb(139, 0, 139);

		public static readonly Scalar DarkOliveGreen = FromRgb(85, 107, 47);

		public static readonly Scalar DarkOrange = FromRgb(255, 140, 0);

		public static readonly Scalar DarkOrchid = FromRgb(153, 50, 204);

		public static readonly Scalar DarkRed = FromRgb(139, 0, 0);

		public static readonly Scalar DarkSalmon = FromRgb(233, 150, 122);

		public static readonly Scalar DarkSeaGreen = FromRgb(143, 188, 139);

		public static readonly Scalar DarkSlateBlue = FromRgb(72, 61, 139);

		public static readonly Scalar DarkSlateGray = FromRgb(47, 79, 79);

		public static readonly Scalar DarkTurquoise = FromRgb(0, 206, 209);

		public static readonly Scalar DarkViolet = FromRgb(148, 0, 211);

		public static readonly Scalar DeepPink = FromRgb(255, 20, 147);

		public static readonly Scalar DeepSkyBlue = FromRgb(0, 191, 255);

		public static readonly Scalar DimGray = FromRgb(105, 105, 105);

		public static readonly Scalar DodgerBlue = FromRgb(30, 144, 255);

		public static readonly Scalar Firebrick = FromRgb(178, 34, 34);

		public static readonly Scalar FloralWhite = FromRgb(255, 250, 240);

		public static readonly Scalar ForestGreen = FromRgb(34, 139, 34);

		public static readonly Scalar Fuchsia = FromRgb(255, 0, 255);

		public static readonly Scalar Gainsboro = FromRgb(220, 220, 220);

		public static readonly Scalar GhostWhite = FromRgb(248, 248, 255);

		public static readonly Scalar Gold = FromRgb(255, 215, 0);

		public static readonly Scalar Goldenrod = FromRgb(218, 165, 32);

		public static readonly Scalar Gray = FromRgb(128, 128, 128);

		public static readonly Scalar Green = FromRgb(0, 128, 0);

		public static readonly Scalar GreenYellow = FromRgb(173, 255, 47);

		public static readonly Scalar Honeydew = FromRgb(240, 255, 240);

		public static readonly Scalar HotPink = FromRgb(255, 105, 180);

		public static readonly Scalar IndianRed = FromRgb(205, 92, 92);

		public static readonly Scalar Indigo = FromRgb(75, 0, 130);

		public static readonly Scalar Ivory = FromRgb(255, 255, 240);

		public static readonly Scalar Khaki = FromRgb(240, 230, 140);

		public static readonly Scalar Lavender = FromRgb(230, 230, 250);

		public static readonly Scalar LavenderBlush = FromRgb(255, 240, 245);

		public static readonly Scalar LawnGreen = FromRgb(124, 252, 0);

		public static readonly Scalar LemonChiffon = FromRgb(255, 250, 205);

		public static readonly Scalar LightBlue = FromRgb(173, 216, 230);

		public static readonly Scalar LightCoral = FromRgb(240, 128, 128);

		public static readonly Scalar LightCyan = FromRgb(224, 255, 255);

		public static readonly Scalar LightGoldenrodYellow = FromRgb(250, 250, 210);

		public static readonly Scalar LightGray = FromRgb(211, 211, 211);

		public static readonly Scalar LightGreen = FromRgb(144, 238, 144);

		public static readonly Scalar LightPink = FromRgb(255, 182, 193);

		public static readonly Scalar LightSalmon = FromRgb(255, 160, 122);

		public static readonly Scalar LightSeaGreen = FromRgb(32, 178, 170);

		public static readonly Scalar LightSkyBlue = FromRgb(135, 206, 250);

		public static readonly Scalar LightSlateGray = FromRgb(119, 136, 153);

		public static readonly Scalar LightSteelBlue = FromRgb(176, 196, 222);

		public static readonly Scalar LightYellow = FromRgb(255, 255, 224);

		public static readonly Scalar Lime = FromRgb(0, 255, 0);

		public static readonly Scalar LimeGreen = FromRgb(50, 205, 50);

		public static readonly Scalar Linen = FromRgb(250, 240, 230);

		public static readonly Scalar Magenta = FromRgb(255, 0, 255);

		public static readonly Scalar Maroon = FromRgb(128, 0, 0);

		public static readonly Scalar MediumAquamarine = FromRgb(102, 205, 170);

		public static readonly Scalar MediumBlue = FromRgb(0, 0, 205);

		public static readonly Scalar MediumOrchid = FromRgb(186, 85, 211);

		public static readonly Scalar MediumPurple = FromRgb(147, 112, 219);

		public static readonly Scalar MediumSeaGreen = FromRgb(60, 179, 113);

		public static readonly Scalar MediumSlateBlue = FromRgb(123, 104, 238);

		public static readonly Scalar MediumSpringGreen = FromRgb(0, 250, 154);

		public static readonly Scalar MediumTurquoise = FromRgb(72, 209, 204);

		public static readonly Scalar MediumVioletRed = FromRgb(199, 21, 133);

		public static readonly Scalar MidnightBlue = FromRgb(25, 25, 112);

		public static readonly Scalar MintCream = FromRgb(245, 255, 250);

		public static readonly Scalar MistyRose = FromRgb(255, 228, 225);

		public static readonly Scalar Moccasin = FromRgb(255, 228, 181);

		public static readonly Scalar NavajoWhite = FromRgb(255, 222, 173);

		public static readonly Scalar Navy = FromRgb(0, 0, 128);

		public static readonly Scalar OldLace = FromRgb(253, 245, 230);

		public static readonly Scalar Olive = FromRgb(128, 128, 0);

		public static readonly Scalar OliveDrab = FromRgb(107, 142, 35);

		public static readonly Scalar Orange = FromRgb(255, 165, 0);

		public static readonly Scalar OrangeRed = FromRgb(255, 69, 0);

		public static readonly Scalar Orchid = FromRgb(218, 112, 214);

		public static readonly Scalar PaleGoldenrod = FromRgb(238, 232, 170);

		public static readonly Scalar PaleGreen = FromRgb(152, 251, 152);

		public static readonly Scalar PaleTurquoise = FromRgb(175, 238, 238);

		public static readonly Scalar PaleVioletRed = FromRgb(219, 112, 147);

		public static readonly Scalar PapayaWhip = FromRgb(255, 239, 213);

		public static readonly Scalar PeachPuff = FromRgb(255, 218, 185);

		public static readonly Scalar Peru = FromRgb(205, 133, 63);

		public static readonly Scalar Pink = FromRgb(255, 192, 203);

		public static readonly Scalar Plum = FromRgb(221, 160, 221);

		public static readonly Scalar PowderBlue = FromRgb(176, 224, 230);

		public static readonly Scalar Purple = FromRgb(128, 0, 128);

		public static readonly Scalar Red = FromRgb(255, 0, 0);

		public static readonly Scalar RosyBrown = FromRgb(188, 143, 143);

		public static readonly Scalar RoyalBlue = FromRgb(65, 105, 225);

		public static readonly Scalar SaddleBrown = FromRgb(139, 69, 19);

		public static readonly Scalar Salmon = FromRgb(250, 128, 114);

		public static readonly Scalar SandyBrown = FromRgb(244, 164, 96);

		public static readonly Scalar SeaGreen = FromRgb(46, 139, 87);

		public static readonly Scalar SeaShell = FromRgb(255, 245, 238);

		public static readonly Scalar Sienna = FromRgb(160, 82, 45);

		public static readonly Scalar Silver = FromRgb(192, 192, 192);

		public static readonly Scalar SkyBlue = FromRgb(135, 206, 235);

		public static readonly Scalar SlateBlue = FromRgb(106, 90, 205);

		public static readonly Scalar SlateGray = FromRgb(112, 128, 144);

		public static readonly Scalar Snow = FromRgb(255, 250, 250);

		public static readonly Scalar SpringGreen = FromRgb(0, 255, 127);

		public static readonly Scalar SteelBlue = FromRgb(70, 130, 180);

		public static readonly Scalar Tan = FromRgb(210, 180, 140);

		public static readonly Scalar Teal = FromRgb(0, 128, 128);

		public static readonly Scalar Thistle = FromRgb(216, 191, 216);

		public static readonly Scalar Tomato = FromRgb(255, 99, 71);

		public static readonly Scalar Turquoise = FromRgb(64, 224, 208);

		public static readonly Scalar Violet = FromRgb(238, 130, 238);

		public static readonly Scalar Wheat = FromRgb(245, 222, 179);

		public static readonly Scalar White = FromRgb(255, 255, 255);

		public static readonly Scalar WhiteSmoke = FromRgb(245, 245, 245);

		public static readonly Scalar Yellow = FromRgb(255, 255, 0);

		public static readonly Scalar YellowGreen = FromRgb(154, 205, 50);

		public double this[int i]
		{
			get
			{
				switch (i)
				{
				case 0:
					return Val0;
				case 1:
					return Val1;
				case 2:
					return Val2;
				case 3:
					return Val3;
				default:
					throw new IndexOutOfRangeException();
				}
			}
			set
			{
				switch (i)
				{
				case 0:
					Val0 = value;
					break;
				case 1:
					Val1 = value;
					break;
				case 2:
					Val2 = value;
					break;
				case 3:
					Val3 = value;
					break;
				default:
					throw new IndexOutOfRangeException();
				}
			}
		}

		public Scalar(double v0)
		{
			this = new Scalar(v0, 0.0, 0.0, 0.0);
		}

		public Scalar(double v0, double v1)
		{
			this = new Scalar(v0, v1, 0.0, 0.0);
		}

		public Scalar(double v0, double v1, double v2)
		{
			this = new Scalar(v0, v1, v2, 0.0);
		}

		public Scalar(double v0, double v1, double v2, double v3)
		{
			Val0 = v0;
			Val1 = v1;
			Val2 = v2;
			Val3 = v3;
		}

		public static Scalar FromRgb(int r, int g, int b)
		{
			return new Scalar(b, g, r);
		}

		public static Scalar RandomColor()
		{
			byte[] array = new byte[3];
			random.NextBytes(array);
			return new Scalar((int)array[0], (int)array[1], (int)array[2]);
		}

		public static implicit operator CvScalar(Scalar self)
		{
			return new CvScalar(self.Val0, self.Val1, self.Val2, self.Val3);
		}

		public static implicit operator Scalar(CvScalar scalar)
		{
			return new Scalar(scalar.Val0, scalar.Val1, scalar.Val2, scalar.Val3);
		}

		public static explicit operator double(Scalar self)
		{
			return self.Val0;
		}

		public static implicit operator Scalar(double val)
		{
			return new Scalar(val);
		}

		public static implicit operator CvColor(Scalar self)
		{
			return new CvColor((byte)self.Val2, (byte)self.Val1, (byte)self.Val0);
		}

		public static implicit operator Scalar(CvColor color)
		{
			return new Scalar((int)color.B, (int)color.G, (int)color.R, 0.0);
		}

		public static explicit operator Scalar(DMatch d)
		{
			return new Scalar(d.QueryIdx, d.TrainIdx, d.ImgIdx, d.Distance);
		}

		public static explicit operator DMatch(Scalar self)
		{
			return new DMatch((int)self.Val0, (int)self.Val1, (int)self.Val2, (float)self.Val3);
		}

		public static explicit operator Scalar(Vec3b v)
		{
			return new Scalar((int)v.Item0, (int)v.Item1, (int)v.Item2);
		}

		public static explicit operator Scalar(Vec3f v)
		{
			return new Scalar(v.Item0, v.Item1, v.Item2);
		}

		public static explicit operator Scalar(Vec4f v)
		{
			return new Scalar(v.Item0, v.Item1, v.Item2, v.Item3);
		}

		public static explicit operator Scalar(Vec6f v)
		{
			return new Scalar(v.Item0, v.Item1, v.Item2, v.Item3);
		}

		public static explicit operator Scalar(Vec3d v)
		{
			return new Scalar(v.Item0, v.Item1, v.Item2);
		}

		public static explicit operator Scalar(Vec4d v)
		{
			return new Scalar(v.Item0, v.Item1, v.Item2, v.Item3);
		}

		public static explicit operator Scalar(Vec6d v)
		{
			return new Scalar(v.Item0, v.Item1, v.Item2, v.Item3);
		}

		public static explicit operator Scalar(Point p)
		{
			return new Scalar(p.X, p.Y);
		}

		public static explicit operator Scalar(Point2f p)
		{
			return new Scalar(p.X, p.Y);
		}

		public static explicit operator Scalar(Point2d p)
		{
			return new Scalar(p.X, p.Y);
		}

		public static explicit operator Scalar(Point3i p)
		{
			return new Scalar(p.X, p.Y, p.Z);
		}

		public static explicit operator Scalar(Point3f p)
		{
			return new Scalar(p.X, p.Y, p.Z);
		}

		public static explicit operator Scalar(Point3d p)
		{
			return new Scalar(p.X, p.Y, p.Z);
		}

		public static explicit operator Scalar(Rect p)
		{
			return new Scalar(p.X, p.Y, p.Width, p.Height);
		}

		public override bool Equals(object obj)
		{
			return ((ValueType)this).Equals(obj);
		}

		public override int GetHashCode()
		{
			return Val0.GetHashCode() ^ Val1.GetHashCode() ^ Val2.GetHashCode() ^ Val3.GetHashCode();
		}

		public override string ToString()
		{
			return $"[{Val0}, {Val1}, {Val2}, {Val3}]";
		}

		public static bool operator ==(Scalar s1, Scalar s2)
		{
			return s1.Equals(s2);
		}

		public static bool operator !=(Scalar s1, Scalar s2)
		{
			return !s1.Equals(s2);
		}

		public static Scalar All(double v)
		{
			return new Scalar(v, v, v, v);
		}

		public Scalar Clone()
		{
			return new Scalar(Val0, Val1, Val2, Val3);
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public Scalar Mul(Scalar it, double scale)
		{
			return new Scalar(Val0 * it.Val0 * scale, Val1 * it.Val1 * scale, Val2 * it.Val2 * scale, Val3 * it.Val3 * scale);
		}

		public Scalar Mul(Scalar it)
		{
			return Mul(it, 1.0);
		}

		public Scalar Conj()
		{
			return new Scalar(Val0, 0.0 - Val1, 0.0 - Val2, 0.0 - Val3);
		}

		public bool IsReal()
		{
			if (Val1 == 0.0 && Val2 == 0.0)
			{
				return Val3 == 0.0;
			}
			return false;
		}

		public bool Equals(Scalar other)
		{
			if (Val0 == other.Val0 && Val1 == other.Val1 && Val2 == other.Val2)
			{
				return Val3 == other.Val3;
			}
			return false;
		}
	}
}
