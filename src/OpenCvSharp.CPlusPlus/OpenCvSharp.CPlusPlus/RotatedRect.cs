using System;

namespace OpenCvSharp.CPlusPlus
{
	public struct RotatedRect
	{
		public Point2f Center;

		public Size2f Size;

		public float Angle;

		public RotatedRect(Point2f center, Size2f size, float angle)
		{
			Center = center;
			Size = size;
			Angle = angle;
		}

		public RotatedRect(CvBox2D box)
		{
			Center = box.Center;
			Size = box.Size;
			Angle = box.Angle;
		}

		public Point2f[] Points()
		{
			double num = (double)Angle * Math.PI / 180.0;
			float num2 = (float)Math.Cos(num) * 0.5f;
			float num3 = (float)Math.Sin(num) * 0.5f;
			Point2f[] array = new Point2f[4];
			array[0].X = Center.X - num3 * Size.Height - num2 * Size.Width;
			array[0].Y = Center.Y + num2 * Size.Height - num3 * Size.Width;
			array[1].X = Center.X + num3 * Size.Height - num2 * Size.Width;
			array[1].Y = Center.Y - num2 * Size.Height - num3 * Size.Width;
			array[2].X = 2f * Center.X - array[0].X;
			array[2].Y = 2f * Center.Y - array[0].Y;
			array[3].X = 2f * Center.X - array[1].X;
			array[3].Y = 2f * Center.Y - array[1].Y;
			return array;
		}

		public Rect BoundingRect()
		{
			Point2f[] array = Points();
			Rect rect = default(Rect);
			rect.X = Cv.Floor(Math.Min(Math.Min(Math.Min(array[0].X, array[1].X), array[2].X), array[3].X));
			rect.Y = Cv.Floor(Math.Min(Math.Min(Math.Min(array[0].Y, array[1].Y), array[2].Y), array[3].Y));
			rect.Width = Cv.Ceil(Math.Max(Math.Max(Math.Max(array[0].X, array[1].X), array[2].X), array[3].X));
			rect.Height = Cv.Ceil(Math.Max(Math.Max(Math.Max(array[0].Y, array[1].Y), array[2].Y), array[3].Y));
			Rect rect2 = rect;
			rect2.Width -= rect2.X - 1;
			rect2.Height -= rect2.Y - 1;
			return rect2;
		}

		public static implicit operator CvBox2D(RotatedRect self)
		{
			return new CvBox2D(self.Center, self.Size, self.Angle);
		}

		public static implicit operator RotatedRect(CvBox2D box)
		{
			return new RotatedRect(box);
		}
	}
}
