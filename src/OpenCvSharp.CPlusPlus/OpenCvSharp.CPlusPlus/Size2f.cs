using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Size2f : IEquatable<Size2f>
	{
		public float Width;

		public float Height;

		public Size2f(float width, float height)
		{
			Width = width;
			Height = height;
		}

		public Size2f(double width, double height)
		{
			Width = (int)width;
			Height = (int)height;
		}

		public static implicit operator CvSize2D32f(Size2f self)
		{
			return new CvSize2D32f(self.Width, self.Height);
		}

		public static implicit operator Size2f(CvSize2D32f size)
		{
			return new Size2f(size.Width, size.Height);
		}

		public bool Equals(Size2f obj)
		{
			if (Width == obj.Width)
			{
				return Height == obj.Height;
			}
			return false;
		}

		public static bool operator ==(Size2f lhs, Size2f rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Size2f lhs, Size2f rhs)
		{
			return !lhs.Equals(rhs);
		}

		public override bool Equals(object obj)
		{
			return ((ValueType)this).Equals(obj);
		}

		public override int GetHashCode()
		{
			return Width.GetHashCode() ^ Height.GetHashCode();
		}

		public override string ToString()
		{
			return "(width:"+Width+" height:"+Height+")";
		}
	}
}
