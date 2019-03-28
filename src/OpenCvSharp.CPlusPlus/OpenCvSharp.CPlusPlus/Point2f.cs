using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Point2f : IEquatable<Point2f>
	{
		public float X;

		public float Y;

		public const int SizeOf = 8;

		public Point2f(float x, float y)
		{
			X = x;
			Y = y;
		}

		public static implicit operator CvPoint2D32f(Point2f self)
		{
			return new CvPoint2D32f(self.X, self.Y);
		}

		public static implicit operator Point2f(CvPoint2D32f point)
		{
			return new Point2f(point.X, point.Y);
		}

		public static implicit operator Point(Point2f self)
		{
			return new Point((int)self.X, (int)self.Y);
		}

		public static implicit operator Point2f(Point point)
		{
			return new Point2f(point.X, point.Y);
		}

		public static implicit operator Vec2f(Point2f point)
		{
			return new Vec2f(point.X, point.Y);
		}

		public static implicit operator Point2f(Vec2f vec)
		{
			return new Point2f(vec.Item0, vec.Item1);
		}

		public bool Equals(Point2f obj)
		{
			if (X == obj.X)
			{
				return Y == obj.Y;
			}
			return false;
		}

		public static bool operator ==(Point2f lhs, Point2f rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Point2f lhs, Point2f rhs)
		{
			return !lhs.Equals(rhs);
		}

		public static Point2f operator +(Point2f pt)
		{
			return pt;
		}

		public static Point2f operator -(Point2f pt)
		{
			return new Point2f(0f - pt.X, 0f - pt.Y);
		}

		public static Point2f operator +(Point2f p1, Point2f p2)
		{
			return new Point2f(p1.X + p2.X, p1.Y + p2.Y);
		}

		public static Point2f operator -(Point2f p1, Point2f p2)
		{
			return new Point2f(p1.X - p2.X, p1.Y - p2.Y);
		}

		public static Point2f operator *(Point2f pt, double scale)
		{
			return new Point2f((float)((double)pt.X * scale), (float)((double)pt.Y * scale));
		}

		public override bool Equals(object obj)
		{
			return ((ValueType)this).Equals(obj);
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode();
		}

		public override string ToString()
		{
			return $"(x:{X} y:{Y})";
		}

		public static double Distance(Point2f p1, Point2f p2)
		{
			return Math.Sqrt(Math.Pow(p2.X - p1.X, 2.0) + Math.Pow(p2.Y - p1.Y, 2.0));
		}

		public double DistanceTo(Point2f p)
		{
			return Distance(this, p);
		}

		public static double DotProduct(Point2f p1, Point2f p2)
		{
			return p1.X * p2.X + p1.Y * p2.Y;
		}

		public double DotProduct(Point2f p)
		{
			return DotProduct(this, p);
		}

		public static double CrossProduct(Point2f p1, Point2f p2)
		{
			return p1.X * p2.Y - p2.X * p1.Y;
		}

		public double CrossProduct(Point2f p)
		{
			return CrossProduct(this, p);
		}
	}
}
