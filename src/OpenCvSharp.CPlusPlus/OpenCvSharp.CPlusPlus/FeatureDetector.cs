using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class FeatureDetector : Algorithm
	{
		private bool disposed;

		private Ptr<FeatureDetector> detectorPtr;

		public override IntPtr InfoPtr => NativeMethods.features2d_FeatureDetector_info(ptr);

		internal FeatureDetector()
		{
			detectorPtr = null;
			ptr = IntPtr.Zero;
		}

		internal static FeatureDetector FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid FeatureDetector pointer");
			}
			Ptr<FeatureDetector> ptr2 = new Ptr<FeatureDetector>(ptr);
			return new FeatureDetector
			{
				detectorPtr = ptr2,
				ptr = ptr2.Obj
			};
		}

		internal static FeatureDetector FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid FeatureDetector pointer");
			}
			return new FeatureDetector
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

		public KeyPoint[] Detect(Mat image, Mat mask = null)
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
			{
				NativeMethods.features2d_FeatureDetector_detect(ptr, image.CvPtr, vectorOfKeyPoint.CvPtr, Cv2.ToPtr(mask));
				return vectorOfKeyPoint.ToArray();
			}
		}

		public KeyPoint[][] Detect(IEnumerable<Mat> images, IEnumerable<Mat> masks = null)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			Mat[] array = Util.ToArray(images);
			IntPtr[] array2 = new IntPtr[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = array[i].CvPtr;
			}
			using (VectorOfVectorKeyPoint vectorOfVectorKeyPoint = new VectorOfVectorKeyPoint())
			{
				if (masks == null)
				{
					NativeMethods.features2d_FeatureDetector_detect(ptr, array2, array.Length, vectorOfVectorKeyPoint.CvPtr, null);
				}
				else
				{
					IntPtr[] array3 = EnumerableEx.SelectPtrs(masks);
					if (array3.Length != array.Length)
					{
						throw new ArgumentException("masks.Length != images.Length");
					}
					NativeMethods.features2d_FeatureDetector_detect(ptr, array2, array.Length, vectorOfVectorKeyPoint.CvPtr, array3);
				}
				return vectorOfVectorKeyPoint.ToArray();
			}
		}

		public virtual bool Empty()
		{
			return NativeMethods.features2d_FeatureDetector_empty(ptr) != 0;
		}
	}
}
