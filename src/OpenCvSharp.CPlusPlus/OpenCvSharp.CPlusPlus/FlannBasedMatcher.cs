using OpenCvSharp.CPlusPlus.Flann;
using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class FlannBasedMatcher : DescriptorMatcher
	{
		private bool disposed;

		private Ptr<FlannBasedMatcher> detectorPtr;

		public override IntPtr InfoPtr
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.features2d_FlannBasedMatcher_info(ptr);
			}
		}

		public FlannBasedMatcher(IndexParams indexParams = null, SearchParams searchParams = null)
		{
			ptr = NativeMethods.features2d_FlannBasedMatcher_new(Cv2.ToPtr(indexParams), Cv2.ToPtr(searchParams));
		}

		internal FlannBasedMatcher(Ptr<FlannBasedMatcher> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal FlannBasedMatcher(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		internal new static FlannBasedMatcher FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<FlannBasedMatcher> pointer");
			}
			return new FlannBasedMatcher(new Ptr<FlannBasedMatcher>(ptr));
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
							NativeMethods.features2d_FlannBasedMatcher_delete(ptr);
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

		public override bool IsMaskSupported()
		{
			ThrowIfDisposed();
			return NativeMethods.features2d_FlannBasedMatcher_isMaskSupported(ptr) != 0;
		}

		public override void Add(IEnumerable<Mat> descriptors)
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

		public override void Clear()
		{
			ThrowIfDisposed();
			NativeMethods.features2d_FlannBasedMatcher_clear(ptr);
		}

		public override void Train()
		{
			ThrowIfDisposed();
			NativeMethods.features2d_FlannBasedMatcher_train(ptr);
		}
	}
}
