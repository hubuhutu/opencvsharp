using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Point : IEquatable<Point>
	{
		public int X;

		public int Y;

		public const int SizeOf = 8;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public Point(double x, double y)
		{
			X = (int)x;
			Y = (int)y;
		}

		public static implicit operator CvPoint(Point self)
		{
			return new CvPoint(self.X, self.Y);
		}

		public static implicit operator Point(CvPoint point)
		{
			return new Point(point.X, point.Y);
		}

		public static implicit operator Vec2i(Point point)
		{
			return new Vec2i(point.X, point.Y);
		}

		public static implicit operator Point(Vec2i vec)
		{
			return new Point(vec.Item0, vec.Item1);
		}

		public bool Equals(Point obj)
		{
			if (X == obj.X)
			{
				return Y == obj.Y;
			}
			return false;
		}

		public static bool operator ==(Point lhs, Point rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Point lhs, Point rhs)
		{
			return !lhs.Equals(rhs);
		}

		public static Point operator +(Point pt)
		{
			return pt;
		}

		public static Point operator -(Point pt)
		{
			return new Point(-pt.X, -pt.Y);
		}

		public static Point operator +(Point p1, Point p2)
		{
			return new Point(p1.X + p2.X, p1.Y + p2.Y);
		}

		public static Point operator -(Point p1, Point p2)
		{
			return new Point(p1.X - p2.X, p1.Y - p2.Y);
		}

		public static Point operator *(Point pt, double scale)
		{
			return new Point((int)((double)pt.X * scale), (int)((double)pt.Y * scale));
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
			return "(x:"+X+" y:"+Y+")";
		}

		public static double Distance(Point p1, Point p2)
		{
			return Math.Sqrt(Math.Pow(p2.X - p1.X, 2.0) + Math.Pow(p2.Y - p1.Y, 2.0));
		}

		public double DistanceTo(Point p)
		{
			return Distance(this, p);
		}

		public static double DotProduct(Point p1, Point p2)
		{
			return p1.X * p2.X + p1.Y * p2.Y;
		}

		public double DotProduct(Point p)
		{
			return DotProduct(this, p);
		}

		public static double CrossProduct(Point p1, Point p2)
		{
			return p1.X * p2.Y - p2.X * p1.Y;
		}

		public double CrossProduct(Point p)
		{
			return CrossProduct(this, p);
		}
	}
}
