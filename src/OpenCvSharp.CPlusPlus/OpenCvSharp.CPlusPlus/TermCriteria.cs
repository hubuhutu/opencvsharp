namespace OpenCvSharp.CPlusPlus
{
	public struct TermCriteria
	{
		public CriteriaType Type;

		public int MaxCount;

		public double Epsilon;

		public TermCriteria(CriteriaType type, int maxCount, double epsilon)
		{
			Type = type;
			MaxCount = maxCount;
			Epsilon = epsilon;
		}

		public static TermCriteria Both(int maxCount, double epsilon)
		{
			TermCriteria result = default(TermCriteria);
			result.Type = (CriteriaType.Iteration | CriteriaType.Epsilon);
			result.MaxCount = maxCount;
			result.Epsilon = epsilon;
			return result;
		}

		public TermCriteria(CvTermCriteria criteria)
		{
			Type = criteria.Type;
			MaxCount = criteria.MaxIter;
			Epsilon = criteria.Epsilon;
		}

		public static implicit operator CvTermCriteria(TermCriteria self)
		{
			return new CvTermCriteria(self.Type, self.MaxCount, self.Epsilon);
		}

		public static implicit operator TermCriteria(CvTermCriteria criteria)
		{
			return new TermCriteria(criteria);
		}
	}
}
