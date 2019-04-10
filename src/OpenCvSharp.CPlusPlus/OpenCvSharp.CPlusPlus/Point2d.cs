using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Point2d : IEquatable<Point2d>
	{
		public double X;

		public double Y;

		public const int SizeOf = 16;

		public Point2d(double x, double y)
		{
			X = x;
			Y = y;
		}

		public static implicit operator CvPoint2D64f(Point2d self)
		{
			return new CvPoint2D32f(self.X, self.Y);
		}

		public static implicit operator Point2d(CvPoint2D64f point)
		{
			return new Point2d(point.X, point.Y);
		}

		public static implicit operator Point(Point2d self)
		{
			return new Point((int)self.X, (int)self.Y);
		}

		public static implicit operator Point2d(Point point)
		{
			return new Point2d(point.X, point.Y);
		}

		public static implicit operator Vec2d(Point2d point)
		{
			return new Vec2d(point.X, point.Y);
		}

		public static implicit operator Point2d(Vec2d vec)
		{
			return new Point2d(vec.Item0, vec.Item1);
		}

		public bool Equals(Point2d obj)
		{
			if (X == obj.X)
			{
				return Y == obj.Y;
			}
			return false;
		}

		public static bool operator ==(Point2d lhs, Point2d rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Point2d lhs, Point2d rhs)
		{
			return !lhs.Equals(rhs);
		}

		public static Point2d operator +(Point2d pt)
		{
			return pt;
		}

		public static Point2d operator -(Point2d pt)
		{
			return new Point2d(0.0 - pt.X, 0.0 - pt.Y);
		}

		public static Point2d operator +(Point2d p1, Point2d p2)
		{
			return new Point2d(p1.X + p2.X, p1.Y + p2.Y);
		}

		public static Point2d operator -(Point2d p1, Point2d p2)
		{
			return new Point2d(p1.X - p2.X, p1.Y - p2.Y);
		}

		public static Point2d operator *(Point2d pt, double scale)
		{
			return new Point2d((float)(pt.X * scale), (float)(pt.Y * scale));
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

		public static double Distance(Point2d p1, Point2d p2)
		{
			return Math.Sqrt(Math.Pow(p2.X - p1.X, 2.0) + Math.Pow(p2.Y - p1.Y, 2.0));
		}

		public double DistanceTo(Point2d p)
		{
			return Distance(this, p);
		}

		public static double DotProduct(Point2d p1, Point2d p2)
		{
			return p1.X * p2.X + p1.Y * p2.Y;
		}

		public double DotProduct(Point2d p)
		{
			return DotProduct(this, p);
		}

		public static double CrossProduct(Point2d p1, Point2d p2)
		{
			return p1.X * p2.Y - p2.X * p1.Y;
		}

		public double CrossProduct(Point2d p)
		{
			return CrossProduct(this, p);
		}
	}
}
