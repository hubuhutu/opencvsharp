using System;

namespace OpenCvSharp.CPlusPlus
{
	[Serializable]
	public struct KeyPoint : IEquatable<KeyPoint>
	{
		public Point2f Pt;

		public float Size;

		public float Angle;

		public float Response;

		public int Octave;

		public int ClassID;

		public KeyPoint(CvPoint2D32f pt, float size, float angle = -1f, float response = 0f, int octave = 0, int class_id = -1)
		{
			Pt = pt;
			Size = size;
			Angle = angle;
			Response = response;
			Octave = octave;
			ClassID = class_id;
		}

		public KeyPoint(float x, float y, float size, float angle = -1f, float response = 0f, int octave = 0, int class_id = -1)
		{
			this = new KeyPoint(new CvPoint2D32f(x, y), size, angle, response, octave, class_id);
		}

		public bool Equals(KeyPoint obj)
		{
			if (Pt == obj.Pt && Size == obj.Size && Angle == obj.Angle && Response == obj.Response && Octave == obj.Octave)
			{
				return ClassID == obj.ClassID;
			}
			return false;
		}

		public static bool operator ==(KeyPoint lhs, KeyPoint rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(KeyPoint lhs, KeyPoint rhs)
		{
			return !lhs.Equals(rhs);
		}

		public override bool Equals(object obj)
		{
			return ((ValueType)this).Equals(obj);
		}

		public override int GetHashCode()
		{
			return Pt.GetHashCode() + Size.GetHashCode() + Angle.GetHashCode() + Response.GetHashCode() + Octave.GetHashCode() + ClassID.GetHashCode();
		}

		public override string ToString()
		{
            return "[Pt:" + Pt + ", Size:" + Size + ", Angle" + Angle + ", Response" + Response + ", Octave" + Octave + ", ClassID" + ClassID + "]";
		}
	}
}
