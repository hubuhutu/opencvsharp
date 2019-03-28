using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Point3d : IEquatable<Point3d>
	{
		public double X;

		public double Y;

		public double Z;

		public const int SizeOf = 24;

		public Point3d(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public static implicit operator CvPoint3D64f(Point3d self)
		{
			return new CvPoint3D32f(self.X, self.Y, self.Z);
		}

		public static implicit operator Point3d(CvPoint3D64f point)
		{
			return new Point3d(point.X, point.Y, point.Z);
		}

		public static implicit operator Vec3d(Point3d point)
		{
			return new Vec3d(point.X, point.Y, point.Z);
		}

		public static implicit operator Point3d(Vec3d vec)
		{
			return new Point3d(vec.Item0, vec.Item1, vec.Item2);
		}

		public bool Equals(Point3d obj)
		{
			if (X == obj.X && Y == obj.Y)
			{
				return Z == obj.Z;
			}
			return false;
		}

		public static bool operator ==(Point3d lhs, Point3d rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Point3d lhs, Point3d rhs)
		{
			return !lhs.Equals(rhs);
		}

		public static Point3d operator +(Point3d pt)
		{
			return pt;
		}

		public static Point3d operator -(Point3d pt)
		{
			return new Point3d(0.0 - pt.X, 0.0 - pt.Y, 0.0 - pt.Z);
		}

		public static Point3d operator +(Point3d p1, Point3d p2)
		{
			return new Point3d(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
		}

		public static Point3d operator -(Point3d p1, Point3d p2)
		{
			return new Point3d(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
		}

		public static Point3d operator *(Point3d pt, double scale)
		{
			return new Point3d(pt.X * scale, pt.Y * scale, pt.Z * scale);
		}

		public override bool Equals(object obj)
		{
			return ((ValueType)this).Equals(obj);
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
		}

		public override string ToString()
		{
			return $"(x:{X} y:{Y} z:{Z})";
		}
	}
}
