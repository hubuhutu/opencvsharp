using OpenCvSharp.CPlusPlus.Detail;
using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	public sealed class Stitcher : DisposableCvObject
	{
		public enum Status
		{
			OK,
			ErrorNeedMoreImgs
		}

		private bool disposed;

		public const int ORIG_RESOL = -1;

		public double RegistrationResol
		{
			get
			{
				return NativeMethods.stitching_Stitcher_registrationResol(ptr);
			}
			set
			{
				NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, value);
			}
		}

		public double SeamEstimationResol
		{
			get
			{
				return NativeMethods.stitching_Stitcher_seamEstimationResol(ptr);
			}
			set
			{
				NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, value);
			}
		}

		public double CompositingResol
		{
			get
			{
				return NativeMethods.stitching_Stitcher_compositingResol(ptr);
			}
			set
			{
				NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, value);
			}
		}

		public double PanoConfidenceThresh
		{
			get
			{
				return NativeMethods.stitching_Stitcher_panoConfidenceThresh(ptr);
			}
			set
			{
				NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, value);
			}
		}

		public bool WaveCorrection
		{
			get
			{
				return NativeMethods.stitching_Stitcher_waveCorrection(ptr) != 0;
			}
			set
			{
				NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, value ? 1 : 0);
			}
		}

		public WaveCorrectKind WaveCorrectKind
		{
			get
			{
				return (WaveCorrectKind)NativeMethods.stitching_Stitcher_waveCorrectKind(ptr);
			}
			set
			{
				NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, (double)value);
			}
		}

		public FeaturesFinder FeaturesFinder
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public FeaturesMatcher FeaturesMatcher
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public Mat MatchingMask
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public BundleAdjusterBase BundleAdjuster
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public WarperCreator Warper
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public ExposureCompensator ExposureCompensator
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public SeamFinder SeamFinder
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public Blender Blender
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public int[] Component
		{
			get
			{
                IntPtr pointer;
                int length;
				NativeMethods.stitching_Stitcher_component(ptr, out pointer , out  length);
				int[] array = new int[length];
				Marshal.Copy(pointer, array, 0, length);
				return array;
			}
		}

		public CameraParams[] Cameras
		{
			get
			{
				throw new NotImplementedException();
			}
		}

        public double WorkScale { get { return NativeMethods.stitching_Stitcher_workScale(ptr); } }

		private Stitcher(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		public static Stitcher CreateDefault(bool tryUseGpu = false)
		{
			return new Stitcher(NativeMethods.stitching_Stitcher_createDefault(tryUseGpu ? 1 : 0));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (ptr != IntPtr.Zero)
					{
						NativeMethods.stitching_Stitcher_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public Status EstimateTransform(InputArray images)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			images.ThrowIfDisposed();
			return (Status)NativeMethods.stitching_Stitcher_estimateTransform_InputArray1(ptr, images.CvPtr);
		}

		public Status EstimateTransform(InputArray images, Rect[][] rois)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			if (rois == null)
			{
				throw new ArgumentNullException("rois");
			}
			images.ThrowIfDisposed();
			using (ArrayAddress2<Rect> arrayAddress = new ArrayAddress2<Rect>(rois))
			{
				return (Status)NativeMethods.stitching_Stitcher_estimateTransform_InputArray2(ptr, images.CvPtr, arrayAddress.Pointer, arrayAddress.Dim1Length, arrayAddress.Dim2Lengths);
			}
		}

		public Status EstimateTransform(IEnumerable<Mat> images)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			IntPtr[] array = EnumerableEx.SelectPtrs(images);
			return (Status)NativeMethods.stitching_Stitcher_estimateTransform_MatArray1(ptr, array, array.Length);
		}

		public Status EstimateTransform(IEnumerable<Mat> images, Rect[][] rois)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			if (rois == null)
			{
				throw new ArgumentNullException("rois");
			}
			IntPtr[] array = EnumerableEx.SelectPtrs(images);
			using (ArrayAddress2<Rect> arrayAddress = new ArrayAddress2<Rect>(rois))
			{
				return (Status)NativeMethods.stitching_Stitcher_estimateTransform_MatArray2(ptr, array, array.Length, arrayAddress.Pointer, arrayAddress.Dim1Length, arrayAddress.Dim2Lengths);
			}
		}

		public Status ComposePanorama(OutputArray pano)
		{
			if (pano == null)
			{
				throw new ArgumentNullException("pano");
			}
			pano.ThrowIfNotReady();
			int result = NativeMethods.stitching_Stitcher_composePanorama1(ptr, pano.CvPtr);
			pano.Fix();
			return (Status)result;
		}

		public Status ComposePanorama(InputArray images, OutputArray pano)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			if (pano == null)
			{
				throw new ArgumentNullException("pano");
			}
			images.ThrowIfDisposed();
			pano.ThrowIfNotReady();
			int result = NativeMethods.stitching_Stitcher_composePanorama2_InputArray(ptr, images.CvPtr, pano.CvPtr);
			pano.Fix();
			return (Status)result;
		}

		public Status ComposePanorama(IEnumerable<Mat> images, OutputArray pano)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			if (pano == null)
			{
				throw new ArgumentNullException("pano");
			}
			pano.ThrowIfNotReady();
			IntPtr[] array = EnumerableEx.SelectPtrs(images);
			int result = NativeMethods.stitching_Stitcher_composePanorama2_MatArray(ptr, array, array.Length, pano.CvPtr);
			pano.Fix();
			return (Status)result;
		}

		public Status Stitch(InputArray images, OutputArray pano)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			if (pano == null)
			{
				throw new ArgumentNullException("pano");
			}
			images.ThrowIfDisposed();
			pano.ThrowIfNotReady();
			int result = NativeMethods.stitching_Stitcher_stitch1_InputArray(ptr, images.CvPtr, pano.CvPtr);
			pano.Fix();
			return (Status)result;
		}

		public Status Stitch(IEnumerable<Mat> images, OutputArray pano)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			if (pano == null)
			{
				throw new ArgumentNullException("pano");
			}
			pano.ThrowIfNotReady();
			IntPtr[] array = EnumerableEx.SelectPtrs(images);
			int result = NativeMethods.stitching_Stitcher_stitch1_MatArray(ptr, array, array.Length, pano.CvPtr);
			pano.Fix();
			return (Status)result;
		}

		public Status Stitch(InputArray images, Rect[][] rois, OutputArray pano)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			if (rois == null)
			{
				throw new ArgumentNullException("rois");
			}
			if (pano == null)
			{
				throw new ArgumentNullException("pano");
			}
			images.ThrowIfDisposed();
			pano.ThrowIfNotReady();
			using (ArrayAddress2<Rect> arrayAddress = new ArrayAddress2<Rect>(rois))
			{
				int result = NativeMethods.stitching_Stitcher_stitch2_InputArray(ptr, images.CvPtr, arrayAddress.Pointer, arrayAddress.Dim1Length, arrayAddress.Dim2Lengths, pano.CvPtr);
				pano.Fix();
				return (Status)result;
			}
		}

		public Status Stitch(IEnumerable<Mat> images, Rect[][] rois, OutputArray pano)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			if (rois == null)
			{
				throw new ArgumentNullException("rois");
			}
			if (pano == null)
			{
				throw new ArgumentNullException("pano");
			}
			pano.ThrowIfNotReady();
			IntPtr[] array = EnumerableEx.SelectPtrs(images);
			using (ArrayAddress2<Rect> arrayAddress = new ArrayAddress2<Rect>(rois))
			{
				int result = NativeMethods.stitching_Stitcher_stitch2_MatArray(ptr, array, array.Length, arrayAddress.Pointer, arrayAddress.Dim1Length, arrayAddress.Dim2Lengths, pano.CvPtr);
				pano.Fix();
				return (Status)result;
			}
		}
	}
}
