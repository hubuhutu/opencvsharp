using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class Feature2D : FeatureDetector, IDescriptorExtractor
	{
		private bool disposed;

		private Ptr<Feature2D> detectorPtr;

		internal Feature2D()
		{
		}

		internal new static Feature2D FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<Feature2D> pointer");
			}
			Ptr<Feature2D> ptr2 = new Ptr<Feature2D>(ptr);
			return new Feature2D
			{
				detectorPtr = ptr2,
				ptr = ptr2.Obj
			};
		}

		internal new static Feature2D FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid Feature2D pointer");
			}
			return new Feature2D
			{
				detectorPtr = null,
				ptr = ptr
			};
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						if (detectorPtr != null)
						{
							detectorPtr.Dispose();
						}
						detectorPtr = null;
						ptr = IntPtr.Zero;
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public virtual void Compute(Mat image, ref KeyPoint[] keypoints, Mat descriptors)
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint(keypoints))
			{
				NativeMethods.features2d_Feature2D_compute(ptr, image.CvPtr, vectorOfKeyPoint.CvPtr, descriptors.CvPtr);
				keypoints = vectorOfKeyPoint.ToArray();
			}
		}

		public virtual void Compute(IEnumerable<Mat> images, ref KeyPoint[][] keypoints, IEnumerable<Mat> descriptors)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			if (descriptors == null)
			{
				throw new ArgumentNullException("descriptors");
			}
			IntPtr[] array = EnumerableEx.SelectPtrs(images);
			IntPtr[] array2 = EnumerableEx.SelectPtrs(descriptors);
			using (VectorOfVectorKeyPoint vectorOfVectorKeyPoint = new VectorOfVectorKeyPoint(keypoints))
			{
				NativeMethods.features2d_DescriptorExtractor_compute2(ptr, array, array.Length, vectorOfVectorKeyPoint.CvPtr, array2, array2.Length);
				keypoints = vectorOfVectorKeyPoint.ToArray();
			}
		}
	}
}
