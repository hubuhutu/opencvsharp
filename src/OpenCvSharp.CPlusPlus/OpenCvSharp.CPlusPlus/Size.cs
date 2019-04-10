using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct Size : IEquatable<Size>
	{
		public int Width;

		public int Height;

        public static Size Zero { get { return default(Size); } }

		public Size(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public Size(double width, double height)
		{
			Width = (int)width;
			Height = (int)height;
		}

		public static implicit operator CvSize(Size self)
		{
			return new CvSize(self.Width, self.Height);
		}

		public static implicit operator Size(CvSize size)
		{
			return new Size(size.Width, size.Height);
		}

		public bool Equals(Size obj)
		{
			if (Width == obj.Width)
			{
				return Height == obj.Height;
			}
			return false;
		}

		public static bool operator ==(Size lhs, Size rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Size lhs, Size rhs)
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
