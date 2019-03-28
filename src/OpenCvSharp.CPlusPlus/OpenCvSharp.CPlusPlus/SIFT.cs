using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class SIFT : Feature2D
	{
		private bool disposed;

		private Ptr<SIFT> detectorPtr;

		public int DescriptorSize
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.nonfree_SIFT_descriptorSize(ptr);
			}
		}

		public int DescriptorType
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.nonfree_SIFT_descriptorType(ptr);
			}
		}

		public override IntPtr InfoPtr => NativeMethods.nonfree_SIFT_info(ptr);

		public SIFT(int nFeatures = 0, int nOctaveLayers = 3, double contrastThreshold = 0.04, double edgeThreshold = 10.0, double sigma = 1.6)
		{
			ptr = NativeMethods.nonfree_SIFT_new(nFeatures, nOctaveLayers, contrastThreshold, edgeThreshold, sigma);
		}

		internal SIFT(Ptr<SIFT> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal SIFT(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		public static SIFT CreateAlgorithm(string name)
		{
			IntPtr intPtr = NativeMethods.nonfree_SIFT_createAlgorithm(name);
			if (intPtr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Algorithm name [" + name + "] not found");
			}
			return FromPtr(intPtr);
		}

		internal new static SIFT FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<SIFT> pointer");
			}
			return new SIFT(new Ptr<SIFT>(ptr));
		}

		internal new static SIFT FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid SIFT pointer");
			}
			return new SIFT(ptr);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (detectorPtr != null)
					{
						detectorPtr.Dispose();
					}
					else if (ptr != IntPtr.Zero)
					{
						NativeMethods.nonfree_SIFT_delete(ptr);
					}
					detectorPtr = null;
					ptr = IntPtr.Zero;
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public KeyPoint[] Run(InputArray img, InputArray mask)
		{
			ThrowIfDisposed();
			if (img == null)
			{
				throw new ArgumentNullException("img");
			}
			img.ThrowIfDisposed();
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
			{
				NativeMethods.nonfree_SIFT_run1(ptr, img.CvPtr, Cv2.ToPtr(mask), vectorOfKeyPoint.CvPtr);
				return vectorOfKeyPoint.ToArray();
			}
		}

		public void Run(InputArray img, InputArray mask, out KeyPoint[] keypoints, OutputArray descriptors, bool useProvidedKeypoints = false)
		{
			ThrowIfDisposed();
			if (img == null)
			{
				throw new ArgumentNullException("img");
			}
			if (descriptors == null)
			{
				throw new ArgumentNullException("descriptors");
			}
			img.ThrowIfDisposed();
			descriptors.ThrowIfNotReady();
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
			{
				NativeMethods.nonfree_SIFT_run2_OutputArray(ptr, img.CvPtr, Cv2.ToPtr(mask), vectorOfKeyPoint.CvPtr, descriptors.CvPtr, useProvidedKeypoints ? 1 : 0);
				keypoints = vectorOfKeyPoint.ToArray();
			}
			descriptors.Fix();
		}

		public void Run(InputArray img, InputArray mask, out KeyPoint[] keypoints, out float[] descriptors, bool useProvidedKeypoints = false)
		{
			MatOfFloat matOfFloat = new MatOfFloat();
			Run(img, mask, out keypoints, matOfFloat, useProvidedKeypoints);
			descriptors = matOfFloat.ToArray();
		}

		public Mat[] BuildGaussianPyramid(Mat baseMat, int nOctaves)
		{
			ThrowIfDisposed();
			if (baseMat == null)
			{
				throw new ArgumentNullException("baseMat");
			}
			baseMat.ThrowIfDisposed();
			using (VectorOfMat vectorOfMat = new VectorOfMat())
			{
				NativeMethods.nonfree_SIFT_buildGaussianPyramid(ptr, baseMat.CvPtr, vectorOfMat.CvPtr, nOctaves);
				return vectorOfMat.ToArray();
			}
		}

		public Mat[] BuildDoGPyramid(IEnumerable<Mat> pyr)
		{
			ThrowIfDisposed();
			if (pyr == null)
			{
				throw new ArgumentNullException("pyr");
			}
			IntPtr[] array = EnumerableEx.SelectPtrs(pyr);
			using (VectorOfMat vectorOfMat = new VectorOfMat())
			{
				NativeMethods.nonfree_SIFT_buildDoGPyramid(ptr, array, array.Length, vectorOfMat.CvPtr);
				return vectorOfMat.ToArray();
			}
		}

		public KeyPoint[] FindScaleSpaceExtrema(IEnumerable<Mat> gaussPyr, IEnumerable<Mat> dogPyr)
		{
			ThrowIfDisposed();
			if (gaussPyr == null)
			{
				throw new ArgumentNullException("gaussPyr");
			}
			if (dogPyr == null)
			{
				throw new ArgumentNullException("dogPyr");
			}
			IntPtr[] array = EnumerableEx.SelectPtrs(gaussPyr);
			IntPtr[] array2 = EnumerableEx.SelectPtrs(dogPyr);
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
			{
				NativeMethods.nonfree_SIFT_findScaleSpaceExtrema(ptr, array, array.Length, array2, array2.Length, vectorOfKeyPoint.CvPtr);
				return vectorOfKeyPoint.ToArray();
			}
		}
	}
}
