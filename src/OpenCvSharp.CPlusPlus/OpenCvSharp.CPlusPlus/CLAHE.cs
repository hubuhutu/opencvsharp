using System;

namespace OpenCvSharp.CPlusPlus
{
	public sealed class CLAHE : Algorithm
	{
		private bool disposed;

		private Ptr<CLAHE> ptrObj;

        public override IntPtr InfoPtr { get { return NativeMethods.imgproc_CLAHE_info(ptr); } }

		public double ClipLimit
		{
			get
			{
				return GetClipLimit();
			}
			set
			{
				SetClipLimit(value);
			}
		}

		public Size TilesGridSize
		{
			get
			{
				return GetTilesGridSize();
			}
			set
			{
				SetTilesGridSize(value);
			}
		}

		internal CLAHE()
		{
			ptr = IntPtr.Zero;
			ptrObj = null;
		}

		internal static CLAHE FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid CLAHE pointer");
			}
			Ptr<CLAHE> ptr2 = new Ptr<CLAHE>(ptr);
			return new CLAHE
			{
				ptr = ptr2.Obj,
				ptrObj = ptr2
			};
		}

		public static CLAHE Create(double clipLimit = 40.0, Size? tileGridSize = default(Size?))
		{
			return FromPtr(NativeMethods.imgproc_createCLAHE(clipLimit, tileGridSize.GetValueOrDefault(new Size(8, 8))));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						if (ptrObj != null)
						{
							ptrObj.Dispose();
						}
						ptrObj = null;
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

		public void Apply(InputArray src, OutputArray dst)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfNotReady();
			NativeMethods.imgproc_CLAHE_apply(ptr, src.CvPtr, dst.CvPtr);
			dst.Fix();
			GC.KeepAlive(src);
		}

		public void SetClipLimit(double clipLimit)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			NativeMethods.imgproc_CLAHE_setClipLimit(ptr, clipLimit);
		}

		public double GetClipLimit()
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			return NativeMethods.imgproc_CLAHE_getClipLimit(ptr);
		}

		public void SetTilesGridSize(Size tileGridSize)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			NativeMethods.imgproc_CLAHE_setTilesGridSize(ptr, tileGridSize);
		}

		public Size GetTilesGridSize()
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			return NativeMethods.imgproc_CLAHE_getTilesGridSize(ptr);
		}

		public void CollectGarbage()
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			NativeMethods.imgproc_CLAHE_collectGarbage(ptr);
		}
	}
}
