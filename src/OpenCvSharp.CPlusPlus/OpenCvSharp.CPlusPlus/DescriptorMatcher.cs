using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class DescriptorMatcher : Algorithm
	{
		private bool disposed;

		private Ptr<DescriptorMatcher> detectorPtr;

		public override IntPtr InfoPtr => NativeMethods.features2d_DescriptorMatcher_info(ptr);

		protected DescriptorMatcher()
		{
			detectorPtr = null;
			ptr = IntPtr.Zero;
		}

		public static DescriptorMatcher Create(string descriptorMatcherType)
		{
			if (string.IsNullOrEmpty(descriptorMatcherType))
			{
				throw new ArgumentNullException("descriptorMatcherType");
			}
			switch (descriptorMatcherType)
			{
			case "FlannBased":
				return new FlannBasedMatcher();
			case "BruteForce":
				return new BFMatcher();
			case "BruteForce-SL2":
				return new BFMatcher(NormType.L2SQR);
			case "BruteForce-L1":
				return new BFMatcher(NormType.L1);
			case "BruteForce-Hamming":
			case "BruteForce-HammingLUT":
				return new BFMatcher(NormType.Hamming);
			case "BruteForce-Hamming(2)":
				return new BFMatcher(NormType.Hamming2);
			default:
				throw new OpenCvSharpException("Unknown matcher name '{0}'", descriptorMatcherType);
			}
		}

		internal static DescriptorMatcher FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<DescriptorMatcher> pointer");
			}
			Ptr<DescriptorMatcher> ptr2 = new Ptr<DescriptorMatcher>(ptr);
			return new DescriptorMatcher
			{
				detectorPtr = ptr2,
				ptr = ptr2.Obj
			};
		}

		internal static DescriptorMatcher FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid DescriptorMatcher pointer");
			}
			return new DescriptorMatcher
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

		public virtual void Add(IEnumerable<Mat> descriptors)
		{
			ThrowIfDisposed();
			if (descriptors == null)
			{
				throw new ArgumentNullException("descriptors");
			}
			Mat[] array = EnumerableEx.ToArray(descriptors);
			if (array.Length != 0)
			{
				IntPtr[] array2 = EnumerableEx.SelectPtrs(array);
				NativeMethods.features2d_DescriptorMatcher_add(ptr, array2, array2.Length);
			}
		}

		public Mat[] GetTrainDescriptors()
		{
			ThrowIfDisposed();
			using (VectorOfMat vectorOfMat = new VectorOfMat())
			{
				NativeMethods.features2d_DescriptorMatcher_getTrainDescriptors(ptr, vectorOfMat.CvPtr);
				return vectorOfMat.ToArray();
			}
		}

		public virtual void Clear()
		{
			ThrowIfDisposed();
			NativeMethods.features2d_DescriptorMatcher_clear(ptr);
		}

		public virtual bool Empty()
		{
			ThrowIfDisposed();
			return NativeMethods.features2d_DescriptorMatcher_empty(ptr) != 0;
		}

		public virtual bool IsMaskSupported()
		{
			ThrowIfDisposed();
			return NativeMethods.features2d_DescriptorMatcher_isMaskSupported(ptr) != 0;
		}

		public virtual void Train()
		{
			ThrowIfDisposed();
			NativeMethods.features2d_DescriptorMatcher_train(ptr);
		}

		public DMatch[] Match(Mat queryDescriptors, Mat trainDescriptors, Mat mask = null)
		{
			ThrowIfDisposed();
			if (queryDescriptors == null)
			{
				throw new ArgumentNullException("queryDescriptors");
			}
			if (trainDescriptors == null)
			{
				throw new ArgumentNullException("trainDescriptors");
			}
			using (VectorOfDMatch vectorOfDMatch = new VectorOfDMatch())
			{
				NativeMethods.features2d_DescriptorMatcher_match1(ptr, queryDescriptors.CvPtr, trainDescriptors.CvPtr, vectorOfDMatch.CvPtr, Cv2.ToPtr(mask));
				return vectorOfDMatch.ToArray();
			}
		}

		public DMatch[][] KnnMatch(Mat queryDescriptors, Mat trainDescriptors, int k, Mat mask = null, bool compactResult = false)
		{
			ThrowIfDisposed();
			if (queryDescriptors == null)
			{
				throw new ArgumentNullException("queryDescriptors");
			}
			if (trainDescriptors == null)
			{
				throw new ArgumentNullException("trainDescriptors");
			}
			using (VectorOfVectorDMatch vectorOfVectorDMatch = new VectorOfVectorDMatch())
			{
				NativeMethods.features2d_DescriptorMatcher_knnMatch1(ptr, queryDescriptors.CvPtr, trainDescriptors.CvPtr, vectorOfVectorDMatch.CvPtr, k, Cv2.ToPtr(mask), compactResult ? 1 : 0);
				return vectorOfVectorDMatch.ToArray();
			}
		}

		public DMatch[][] RadiusMatch(Mat queryDescriptors, Mat trainDescriptors, float maxDistance, Mat mask = null, bool compactResult = false)
		{
			ThrowIfDisposed();
			if (queryDescriptors == null)
			{
				throw new ArgumentNullException("queryDescriptors");
			}
			if (trainDescriptors == null)
			{
				throw new ArgumentNullException("trainDescriptors");
			}
			using (VectorOfVectorDMatch vectorOfVectorDMatch = new VectorOfVectorDMatch())
			{
				NativeMethods.features2d_DescriptorMatcher_radiusMatch1(ptr, queryDescriptors.CvPtr, trainDescriptors.CvPtr, vectorOfVectorDMatch.CvPtr, maxDistance, Cv2.ToPtr(mask), compactResult ? 1 : 0);
				return vectorOfVectorDMatch.ToArray();
			}
		}

		public DMatch[] Match(Mat queryDescriptors, Mat[] masks = null)
		{
			ThrowIfDisposed();
			if (queryDescriptors == null)
			{
				throw new ArgumentNullException("queryDescriptors");
			}
			IntPtr[] array = new IntPtr[0];
			if (masks != null)
			{
				array = EnumerableEx.SelectPtrs(masks);
			}
			using (VectorOfDMatch vectorOfDMatch = new VectorOfDMatch())
			{
				NativeMethods.features2d_DescriptorMatcher_match2(ptr, queryDescriptors.CvPtr, vectorOfDMatch.CvPtr, array, array.Length);
				return vectorOfDMatch.ToArray();
			}
		}

		public DMatch[][] KnnMatch(Mat queryDescriptors, int k, Mat[] masks = null, bool compactResult = false)
		{
			ThrowIfDisposed();
			if (queryDescriptors == null)
			{
				throw new ArgumentNullException("queryDescriptors");
			}
			IntPtr[] array = new IntPtr[0];
			if (masks != null)
			{
				array = EnumerableEx.SelectPtrs(masks);
			}
			using (VectorOfVectorDMatch vectorOfVectorDMatch = new VectorOfVectorDMatch())
			{
				NativeMethods.features2d_DescriptorMatcher_knnMatch2(ptr, queryDescriptors.CvPtr, vectorOfVectorDMatch.CvPtr, k, array, array.Length, compactResult ? 1 : 0);
				return vectorOfVectorDMatch.ToArray();
			}
		}

		public DMatch[][] RadiusMatch(Mat queryDescriptors, float maxDistance, Mat[] masks = null, bool compactResult = false)
		{
			ThrowIfDisposed();
			if (queryDescriptors == null)
			{
				throw new ArgumentNullException("queryDescriptors");
			}
			IntPtr[] array = new IntPtr[0];
			if (masks != null)
			{
				array = EnumerableEx.SelectPtrs(masks);
			}
			using (VectorOfVectorDMatch vectorOfVectorDMatch = new VectorOfVectorDMatch())
			{
				NativeMethods.features2d_DescriptorMatcher_radiusMatch2(ptr, queryDescriptors.CvPtr, vectorOfVectorDMatch.CvPtr, maxDistance, array, array.Length, compactResult ? 1 : 0);
				return vectorOfVectorDMatch.ToArray();
			}
		}
	}
}
