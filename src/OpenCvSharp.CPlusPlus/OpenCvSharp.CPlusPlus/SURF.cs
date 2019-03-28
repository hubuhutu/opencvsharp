using System;

namespace OpenCvSharp.CPlusPlus
{
	public class SURF : Feature2D
	{
		private bool disposed;

		private Ptr<SURF> detectorPtr;

		public int DescriptorSize
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.nonfree_SURF_descriptorSize(ptr);
			}
		}

		public int DescriptorType
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.nonfree_SURF_descriptorType(ptr);
			}
		}

		public double HessianThreshold
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.nonfree_SURF_hessianThreshold_get(ptr);
			}
			set
			{
				ThrowIfDisposed();
				NativeMethods.nonfree_SURF_hessianThreshold_set(ptr, value);
			}
		}

		public int NOctaves
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.nonfree_SURF_nOctaves_get(ptr);
			}
			set
			{
				ThrowIfDisposed();
				NativeMethods.nonfree_SURF_nOctaves_set(ptr, value);
			}
		}

		public int NOctaveLayers
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.nonfree_SURF_nOctaveLayers_get(ptr);
			}
			set
			{
				ThrowIfDisposed();
				NativeMethods.nonfree_SURF_nOctaveLayers_set(ptr, value);
			}
		}

		public bool Extended
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.nonfree_SURF_extended_get(ptr) != 0;
			}
			set
			{
				ThrowIfDisposed();
				NativeMethods.nonfree_SURF_extended_set(ptr, value ? 1 : 0);
			}
		}

		public bool Upright
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.nonfree_SURF_upright_get(ptr) != 0;
			}
			set
			{
				ThrowIfDisposed();
				NativeMethods.nonfree_SURF_upright_set(ptr, value ? 1 : 0);
			}
		}

		public override IntPtr InfoPtr => NativeMethods.nonfree_SURF_info(ptr);

		public SURF()
		{
			ptr = NativeMethods.nonfree_SURF_new();
			detectorPtr = null;
		}

		public SURF(double hessianThreshold, int nOctaves = 4, int nOctaveLayers = 2, bool extended = true, bool upright = false)
		{
			ptr = NativeMethods.nonfree_SURF_new(hessianThreshold, nOctaves, nOctaveLayers, extended ? 1 : 0, upright ? 1 : 0);
			detectorPtr = null;
		}

		internal SURF(Ptr<SURF> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal SURF(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		internal new static SURF FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<SURF> pointer");
			}
			return new SURF(new Ptr<SURF>(ptr));
		}

		internal new static SURF FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid SURF pointer");
			}
			return new SURF(ptr);
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
						NativeMethods.nonfree_SURF_delete(ptr);
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

		public KeyPoint[] Run(InputArray img, Mat mask)
		{
			ThrowIfDisposed();
			if (img == null)
			{
				throw new ArgumentNullException("img");
			}
			img.ThrowIfDisposed();
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
			{
				NativeMethods.nonfree_SURF_run1(ptr, img.CvPtr, Cv2.ToPtr(mask), vectorOfKeyPoint.CvPtr);
				return vectorOfKeyPoint.ToArray();
			}
		}

		public void Run(InputArray img, InputArray mask, out KeyPoint[] keypoints, out float[] descriptors, bool useProvidedKeypoints = false)
		{
			ThrowIfDisposed();
			if (img == null)
			{
				throw new ArgumentNullException("img");
			}
			img.ThrowIfDisposed();
			using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
			{
				using (VectorOfFloat vectorOfFloat = new VectorOfFloat())
				{
					NativeMethods.nonfree_SURF_run2_vector(ptr, img.CvPtr, Cv2.ToPtr(mask), vectorOfKeyPoint.CvPtr, vectorOfFloat.CvPtr, useProvidedKeypoints ? 1 : 0);
					keypoints = vectorOfKeyPoint.ToArray();
					descriptors = vectorOfFloat.ToArray();
				}
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
				NativeMethods.nonfree_SURF_run2_OutputArray(ptr, img.CvPtr, Cv2.ToPtr(mask), vectorOfKeyPoint.CvPtr, descriptors.CvPtr, useProvidedKeypoints ? 1 : 0);
				keypoints = vectorOfKeyPoint.ToArray();
			}
		}
	}
}
