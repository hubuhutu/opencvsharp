using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public interface IDescriptorExtractor
	{
		void Compute(Mat image, ref KeyPoint[] keypoints, Mat descriptors);

		void Compute(IEnumerable<Mat> images, ref KeyPoint[][] keypoints, IEnumerable<Mat> descriptors);

		bool Empty();
	}
}
