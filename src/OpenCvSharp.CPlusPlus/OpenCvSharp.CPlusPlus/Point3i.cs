using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Point3i : IEquatable<Point3i>
	{
		public int X;

		public int Y;

		public int Z;

		public const int SizeOf = 12;

		public Point3i(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public static implicit operator Vec3i(Point3i point)
		{
			return new Vec3i(point.X, point.Y, point.Z);
		}

		public static implicit operator Point3i(Vec3i vec)
		{
			return new Point3i(vec.Item0, vec.Item1, vec.Item2);
		}

		public bool Equals(Point3i obj)
		{
			if (X == obj.X && Y == obj.Y)
			{
				return Z == obj.Z;
			}
			return false;
		}

		public static bool operator ==(Point3i lhs, Point3i rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Point3i lhs, Point3i rhs)
		{
			return !lhs.Equals(rhs);
		}

		public static Point3i operator +(Point3i pt)
		{
			return pt;
		}

		public static Point3i operator -(Point3i pt)
		{
			return new Point3i(-pt.X, -pt.Y, -pt.Z);
		}

		public static Point3i operator +(Point3i p1, Point3i p2)
		{
			return new Point3i(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
		}

		public static Point3i operator -(Point3i p1, Point3i p2)
		{
			return new Point3i(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
		}

		public static Point3i operator *(Point3i pt, double scale)
		{
			return new Point3i((int)((double)pt.X * scale), (int)((double)pt.Y * scale), (int)((double)pt.Z * scale));
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
			return "(x:"+X+" y:"+Y+" z:"+Z+")";
		}
	}
}
