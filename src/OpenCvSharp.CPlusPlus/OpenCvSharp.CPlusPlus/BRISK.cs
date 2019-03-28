using System;

namespace OpenCvSharp.CPlusPlus
{
	public class BRISK : Feature2D
	{
		private bool disposed;

		private Ptr<BRISK> detectorPtr;

		public override IntPtr InfoPtr => NativeMethods.features2d_BRISK_info(ptr);

		public BRISK(int thresh = 30, int octaves = 3, float patternScale = 1f)
		{
			ptr = NativeMethods.features2d_BRISK_new(thresh, octaves, patternScale);
		}

		internal BRISK(Ptr<BRISK> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal BRISK(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		internal new static BRISK FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<BRISK> pointer");
			}
			return new BRISK(new Ptr<BRISK>(ptr));
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
							NativeMethods.features2d_BRISK_delete(ptr);
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
			return NativeMethods.features2d_BRISK_descriptorSize(ptr);
		}

		public int DescriptorType()
		{
			ThrowIfDisposed();
			return NativeMethods.features2d_BRISK_descriptorType(ptr);
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
				NativeMethods.features2d_BRISK_run1(ptr, image.CvPtr, Cv2.ToPtr(mask), vectorOfKeyPoint.CvPtr);
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
				NativeMethods.features2d_BRISK_run2(ptr, image.CvPtr, Cv2.ToPtr(mask), vectorOfKeyPoint.CvPtr, descriptors.CvPtr, useProvidedKeypoints ? 1 : 0);
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
