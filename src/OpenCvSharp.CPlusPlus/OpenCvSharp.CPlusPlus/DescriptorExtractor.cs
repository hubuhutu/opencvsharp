using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class DescriptorExtractor : Algorithm, IDescriptorExtractor
	{
		private bool disposed;

		private Ptr<DescriptorExtractor> extractorPtr;

		public override IntPtr InfoPtr => NativeMethods.features2d_DescriptorExtractor_info(ptr);

		internal DescriptorExtractor()
		{
			extractorPtr = null;
			ptr = IntPtr.Zero;
		}

		internal static DescriptorExtractor FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid DescriptorExtractor pointer");
			}
			Ptr<DescriptorExtractor> ptr2 = new Ptr<DescriptorExtractor>(ptr);
			return new DescriptorExtractor
			{
				extractorPtr = ptr2,
				ptr = ptr2.Obj
			};
		}

		internal static DescriptorExtractor FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid DescriptorExtractor pointer");
			}
			return new DescriptorExtractor
			{
				extractorPtr = null,
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
						if (extractorPtr != null)
						{
							extractorPtr.Dispose();
						}
						extractorPtr = null;
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
			if (descriptors == null)
			{
				throw new ArgumentNullException("descriptors");
			}
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint(keypoints))
			{
				NativeMethods.features2d_DescriptorExtractor_compute1(ptr, image.CvPtr, vectorOfKeyPoint.CvPtr, descriptors.CvPtr);
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

		public virtual bool Empty()
		{
			return NativeMethods.features2d_DescriptorExtractor_empty(ptr) != 0;
		}

		public virtual int DescriptorSize()
		{
			throw new NotImplementedException();
		}

		public virtual int DescriptorType()
		{
			throw new NotImplementedException();
		}
	}
}
