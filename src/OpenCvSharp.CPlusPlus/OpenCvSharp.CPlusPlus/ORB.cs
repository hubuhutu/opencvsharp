using System;

namespace OpenCvSharp.CPlusPlus
{
	public class ORB : Feature2D
	{
		private bool disposed;

		private Ptr<ORB> detectorPtr;

        public override IntPtr InfoPtr { get { return NativeMethods.features2d_ORB_info(ptr); } }

		public ORB(int nFeatures = 500, float scaleFactor = 1.2f, int nLevels = 8, int edgeThreshold = 31, int firstLevel = 0, int wtaK = 2, ORBScore scoreType = ORBScore.Harris, int patchSize = 31)
		{
			ptr = NativeMethods.features2d_ORB_new(nFeatures, scaleFactor, nLevels, edgeThreshold, firstLevel, wtaK, (int)scoreType, patchSize);
		}

		internal ORB(Ptr<ORB> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal ORB(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		internal new static ORB FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<ORB> pointer");
			}
			return new ORB(new Ptr<ORB>(ptr));
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
							NativeMethods.features2d_ORB_delete(ptr);
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

		public int DescriptorSize()
		{
			ThrowIfDisposed();
			return NativeMethods.features2d_ORB_descriptorSize(ptr);
		}

		public int DescriptorType()
		{
			ThrowIfDisposed();
			return NativeMethods.features2d_ORB_descriptorType(ptr);
		}

		public KeyPoint[] Run(InputArray image, InputArray mask = null)
		{
			ThrowIfDisposed();
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfDisposed();
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
			{
				NativeMethods.features2d_ORB_run1(ptr, image.CvPtr, Cv2.ToPtr(mask), vectorOfKeyPoint.CvPtr);
				return vectorOfKeyPoint.ToArray();
			}
		}

		public void Run(InputArray image, InputArray mask, out KeyPoint[] keyPoints, OutputArray descriptors, bool useProvidedKeypoints = false)
		{
			ThrowIfDisposed();
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			if (descriptors == null)
			{
				throw new ArgumentNullException("descriptors");
			}
			image.ThrowIfDisposed();
			descriptors.ThrowIfNotReady();
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
			{
				NativeMethods.features2d_ORB_run2(ptr, image.CvPtr, Cv2.ToPtr(mask), vectorOfKeyPoint.CvPtr, descriptors.CvPtr, useProvidedKeypoints ? 1 : 0);
				keyPoints = vectorOfKeyPoint.ToArray();
			}
			descriptors.Fix();
		}

		public void Run(InputArray image, InputArray mask, out KeyPoint[] keyPoints, out float[] descriptors, bool useProvidedKeypoints = false)
		{
			MatOfFloat matOfFloat = new MatOfFloat();
			Run(image, mask, out keyPoints, matOfFloat, useProvidedKeypoints);
			descriptors = matOfFloat.ToArray();
		}
	}
}
