using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class FREAK : DescriptorExtractor
	{
		private bool disposed;

		private Ptr<FREAK> detectorPtr;

        public override IntPtr InfoPtr { get { return NativeMethods.features2d_FREAK_info(ptr); } }

		public FREAK(bool orientationNormalized = true, bool scaleNormalized = true, float patternScale = 22f, int nOctaves = 4, IEnumerable<int> selectedPairs = null)
		{
			int[] array = EnumerableEx.ToArray(selectedPairs);
			int selectedPairsLength = (selectedPairs != null) ? array.Length : 0;
			ptr = NativeMethods.features2d_FREAK_new(orientationNormalized ? 1 : 0, scaleNormalized ? 1 : 0, patternScale, nOctaves, array, selectedPairsLength);
		}

		internal FREAK(Ptr<FREAK> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal FREAK(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		internal new static FREAK FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<FREAK> pointer");
			}
			return new FREAK(new Ptr<FREAK>(ptr));
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
						detectorPtr = null;
					}
					else
					{
						if (ptr != IntPtr.Zero)
						{
							NativeMethods.features2d_FREAK_delete(ptr);
						}
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

		public override int DescriptorSize()
		{
			ThrowIfDisposed();
			return NativeMethods.features2d_FREAK_descriptorSize(ptr);
		}

		public override int DescriptorType()
		{
			ThrowIfDisposed();
			return NativeMethods.features2d_FREAK_descriptorType(ptr);
		}

		public int[] SelectPairs(IEnumerable<Mat> images, out KeyPoint[][] keypoints, double corrThresh = 0.7, bool verbose = true)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			IntPtr[] array = EnumerableEx.SelectPtrs(images);
			using (VectorOfInt32 vectorOfInt = new VectorOfInt32())
			{
				using (VectorOfVectorKeyPoint vectorOfVectorKeyPoint = new VectorOfVectorKeyPoint())
				{
					NativeMethods.features2d_FREAK_selectPairs(ptr, array, array.Length, vectorOfVectorKeyPoint.CvPtr, corrThresh, verbose ? 1 : 0, vectorOfInt.CvPtr);
					keypoints = vectorOfVectorKeyPoint.ToArray();
					return vectorOfInt.ToArray();
				}
			}
		}
	}
}
