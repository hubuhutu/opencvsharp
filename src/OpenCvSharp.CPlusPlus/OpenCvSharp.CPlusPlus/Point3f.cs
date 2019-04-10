using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Point3f : IEquatable<Point3f>
	{
		public float X;

		public float Y;

		public float Z;

		public const int SizeOf = 12;

		public Point3f(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public static implicit operator CvPoint3D32f(Point3f self)
		{
			return new CvPoint3D32f(self.X, self.Y, self.Z);
		}

		public static implicit operator Point3f(CvPoint3D32f point)
		{
			return new Point3f(point.X, point.Y, point.Z);
		}

		public static implicit operator Vec3f(Point3f point)
		{
			return new Vec3f(point.X, point.Y, point.Z);
		}

		public static implicit operator Point3f(Vec3f vec)
		{
			return new Point3f(vec.Item0, vec.Item1, vec.Item2);
		}

		public bool Equals(Point3f obj)
		{
			if (X == obj.X && Y == obj.Y)
			{
				return Z == obj.Z;
			}
			return false;
		}

		public static bool operator ==(Point3f lhs, Point3f rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Point3f lhs, Point3f rhs)
		{
			return !lhs.Equals(rhs);
		}

		public static Point3f operator +(Point3f pt)
		{
			return pt;
		}

		public static Point3f operator -(Point3f pt)
		{
			return new Point3f(0f - pt.X, 0f - pt.Y, 0f - pt.Z);
		}

		public static Point3f operator +(Point3f p1, Point3f p2)
		{
			return new Point3f(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
		}

		public static Point3f operator -(Point3f p1, Point3f p2)
		{
			return new Point3f(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
		}

		public static Point3f operator *(Point3f pt, double scale)
		{
			return new Point3f((float)((double)pt.X * scale), (float)((double)pt.Y * scale), (float)((double)pt.Z * scale));
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
            return "(x:" + X + " y:" + Y + " z:" + Z + ")";
		}
	}
}
