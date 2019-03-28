using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Rect : IEquatable<Rect>
	{
		public int X;

		public int Y;

		public int Width;

		public int Height;

		public const int SizeOf = 16;

		public static readonly Rect Empty;

		public int Top
		{
			get
			{
				return Y;
			}
			set
			{
				Y = value;
			}
		}

		public int Bottom => Y + Height - 1;

		public int Left
		{
			get
			{
				return X;
			}
			set
			{
				X = value;
			}
		}

		public int Right => X + Width - 1;

		public Point Location
		{
			get
			{
				return new Point(X, Y);
			}
			set
			{
				X = value.X;
				Y = value.Y;
			}
		}

		public Size Size
		{
			get
			{
				return new Size(Width, Height);
			}
			set
			{
				Width = value.Width;
				Height = value.Height;
			}
		}

		public Point TopLeft => new Point(X, Y);

		public Point BottomRight => new Point(X + Width - 1, Y + Height - 1);

		public Rect(int x, int y, int width, int height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		public Rect(Point location, Size size)
		{
			X = location.X;
			Y = location.Y;
			Width = size.Width;
			Height = size.Height;
		}

		public static Rect FromLTRB(int left, int top, int right, int bottom)
		{
			Rect rect = default(Rect);
			rect.X = left;
			rect.Y = top;
			rect.Width = right - left + 1;
			rect.Height = bottom - top + 1;
			Rect rect2 = rect;
			if (rect2.Width < 0)
			{
				throw new ArgumentException("right > left");
			}
			if (rect2.Height < 0)
			{
				throw new ArgumentException("bottom > top");
			}
			return rect2;
		}

		public static implicit operator CvRect(Rect self)
		{
			return new CvRect(self.X, self.Y, self.Width, self.Height);
		}

		public static implicit operator Rect(CvRect rect)
		{
			return new Rect(rect.X, rect.Y, rect.Width, rect.Height);
		}

		public bool Equals(Rect obj)
		{
			if (X == obj.X && Y == obj.Y && Width == obj.Width)
			{
				return Height == obj.Height;
			}
			return false;
		}

		public static bool operator ==(Rect lhs, Rect rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Rect lhs, Rect rhs)
		{
			return !lhs.Equals(rhs);
		}

		public static Rect operator +(Rect rect, Point pt)
		{
			return new Rect(rect.X + pt.X, rect.Y + pt.Y, rect.Width, rect.Height);
		}

		public static Rect operator -(Rect rect, Point pt)
		{
			return new Rect(rect.X - pt.X, rect.Y - pt.Y, rect.Width, rect.Height);
		}

		public static Rect operator +(Rect rect, Size size)
		{
			return new Rect(rect.X, rect.Y, rect.Width + size.Width, rect.Height + size.Height);
		}

		public static Rect operator -(Rect rect, Size size)
		{
			return new Rect(rect.X, rect.Y, rect.Width - size.Width, rect.Height - size.Height);
		}

		public static Rect operator &(Rect a, Rect b)
		{
			return Intersect(a, b);
		}

		public static Rect operator |(Rect a, Rect b)
		{
			return Union(a, b);
		}

		public bool Contains(int x, int y)
		{
			if (X <= x && Y <= y && X + Width - 1 > x)
			{
				return Y + Height - 1 > y;
			}
			return false;
		}

		public bool Contains(Point pt)
		{
			return Contains(pt.X, pt.Y);
		}

		public bool Contains(Rect rect)
		{
			if (X <= rect.X && rect.X + rect.Width <= X + Width && Y <= rect.Y)
			{
				return rect.Y + rect.Height <= Y + Height;
			}
			return false;
		}

		public void Inflate(int width, int height)
		{
			X -= width;
			Y -= height;
			Width += 2 * width;
			Height += 2 * height;
		}

		public void Inflate(Size size)
		{
			Inflate(size.Width, size.Height);
		}

		public static Rect Inflate(Rect rect, int x, int y)
		{
			rect.Inflate(x, y);
			return rect;
		}

		public static Rect Intersect(Rect a, Rect b)
		{
			int num = Math.Max(a.X, b.X);
			int num2 = Math.Min(a.X + a.Width, b.X + b.Width);
			int num3 = Math.Max(a.Y, b.Y);
			int num4 = Math.Min(a.Y + a.Height, b.Y + b.Height);
			if (num2 >= num && num4 >= num3)
			{
				return new Rect(num, num3, num2 - num, num4 - num3);
			}
			return Empty;
		}

		public Rect Intersect(Rect rect)
		{
			return Intersect(this, rect);
		}

		public bool IntersectsWith(Rect rect)
		{
			if (X < rect.X + rect.Width && X + Width > rect.X && Y < rect.Y + rect.Height)
			{
				return Y + Height > rect.Y;
			}
			return false;
		}

		public Rect Union(Rect rect)
		{
			return Union(this, rect);
		}

		public static Rect Union(Rect a, Rect b)
		{
			int num = Math.Min(a.X, b.X);
			int num2 = Math.Max(a.X + a.Width, b.X + b.Width);
			int num3 = Math.Min(a.Y, b.Y);
			int num4 = Math.Max(a.Y + a.Height, b.Y + b.Height);
			return new Rect(num, num3, num2 - num, num4 - num3);
		}

		public override bool Equals(object obj)
		{
			return ((ValueType)this).Equals(obj);
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
		}

		public override string ToString()
		{
			return $"(x:{X} y:{Y} width:{Width} height:{Height})";
		}
	}
}
