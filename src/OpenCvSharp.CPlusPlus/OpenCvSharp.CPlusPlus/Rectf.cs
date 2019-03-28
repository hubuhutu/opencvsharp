using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Rectf : IEquatable<Rectf>
	{
		public float X;

		public float Y;

		public float Width;

		public float Height;

		public const int SizeOf = 16;

		public static readonly Rectf Empty;

		public float Top
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

		public float Bottom => Y + Height - 1f;

		public float Left
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

		public float Right => X + Width - 1f;

		public Point2f Location
		{
			get
			{
				return new Point2f(X, Y);
			}
			set
			{
				X = value.X;
				Y = value.Y;
			}
		}

		public Size2f Size
		{
			get
			{
				return new Size2f(Width, Height);
			}
			set
			{
				Width = value.Width;
				Height = value.Height;
			}
		}

		public Point2f TopLeft => new Point2f(X, Y);

		public Point2f BottomRight => new Point2f(X + Width - 1f, Y + Height - 1f);

		public Rectf(float x, float y, float width, float height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		public Rectf(Point2f location, Size2f size)
		{
			X = location.X;
			Y = location.Y;
			Width = size.Width;
			Height = size.Height;
		}

		public static Rectf FromLTRB(float left, float top, float right, float bottom)
		{
			Rectf rectf = default(Rectf);
			rectf.X = left;
			rectf.Y = top;
			rectf.Width = right - left + 1f;
			rectf.Height = bottom - top + 1f;
			Rectf rectf2 = rectf;
			if (rectf2.Width < 0f)
			{
				throw new ArgumentException("right > left");
			}
			if (rectf2.Height < 0f)
			{
				throw new ArgumentException("bottom > top");
			}
			return rectf2;
		}

		public bool Equals(Rectf obj)
		{
			if (X == obj.X && Y == obj.Y && Width == obj.Width)
			{
				return Height == obj.Height;
			}
			return false;
		}

		public static bool operator ==(Rectf lhs, Rectf rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Rectf lhs, Rectf rhs)
		{
			return !lhs.Equals(rhs);
		}

		public static Rectf operator +(Rectf rect, Point2f pt)
		{
			return new Rectf(rect.X + pt.X, rect.Y + pt.Y, rect.Width, rect.Height);
		}

		public static Rectf operator -(Rectf rect, Point2f pt)
		{
			return new Rectf(rect.X - pt.X, rect.Y - pt.Y, rect.Width, rect.Height);
		}

		public static Rectf operator +(Rectf rect, Size2f size)
		{
			return new Rectf(rect.X, rect.Y, rect.Width + size.Width, rect.Height + size.Height);
		}

		public static Rectf operator -(Rectf rect, Size2f size)
		{
			return new Rectf(rect.X, rect.Y, rect.Width - size.Width, rect.Height - size.Height);
		}

		public static Rectf operator &(Rectf a, Rectf b)
		{
			return Intersect(a, b);
		}

		public static Rectf operator |(Rectf a, Rectf b)
		{
			return Union(a, b);
		}

		public bool Contains(float x, float y)
		{
			if (X <= x && Y <= y && X + Width - 1f > x)
			{
				return Y + Height - 1f > y;
			}
			return false;
		}

		public bool Contains(Point2f pt)
		{
			return Contains(pt.X, pt.Y);
		}

		public bool Contains(Rectf rect)
		{
			if (X <= rect.X && rect.X + rect.Width <= X + Width && Y <= rect.Y)
			{
				return rect.Y + rect.Height <= Y + Height;
			}
			return false;
		}

		public void Inflate(float width, float height)
		{
			X -= width;
			Y -= height;
			Width += 2f * width;
			Height += 2f * height;
		}

		public void Inflate(Size2f size)
		{
			Inflate(size.Width, size.Height);
		}

		public static Rect Inflate(Rect rect, int x, int y)
		{
			rect.Inflate(x, y);
			return rect;
		}

		public static Rectf Intersect(Rectf a, Rectf b)
		{
			float num = Math.Max(a.X, b.X);
			float num2 = Math.Min(a.X + a.Width, b.X + b.Width);
			float num3 = Math.Max(a.Y, b.Y);
			float num4 = Math.Min(a.Y + a.Height, b.Y + b.Height);
			if (num2 >= num && num4 >= num3)
			{
				return new Rectf(num, num3, num2 - num, num4 - num3);
			}
			return Empty;
		}

		public Rectf Intersect(Rectf rect)
		{
			return Intersect(this, rect);
		}

		public bool IntersectsWith(Rectf rect)
		{
			if (X < rect.X + rect.Width && X + Width > rect.X && Y < rect.Y + rect.Height)
			{
				return Y + Height > rect.Y;
			}
			return false;
		}

		public Rectf Union(Rectf rect)
		{
			return Union(this, rect);
		}

		public static Rectf Union(Rectf a, Rectf b)
		{
			float num = Math.Min(a.X, b.X);
			float num2 = Math.Max(a.X + a.Width, b.X + b.Width);
			float num3 = Math.Min(a.Y, b.Y);
			float num4 = Math.Max(a.Y + a.Height, b.Y + b.Height);
			return new Rectf(num, num3, num2 - num, num4 - num3);
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
