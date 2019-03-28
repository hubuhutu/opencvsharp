using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public sealed class Stream : DisposableGpuObject
	{
		private bool disposed;

		private StreamCallbackInternal callbackInternal;

		private GCHandle callbackHandle;

		private GCHandle userDataHandle;

		private static Stream nullObject;

		public static Stream Null
		{
			get
			{
				if (nullObject == null)
				{
					nullObject = new Stream(NativeMethods.gpu_Stream_Null())
					{
						IsEnabledDispose = false
					};
				}
				return nullObject;
			}
		}

		public Stream(IntPtr ptr)
		{
			ThrowIfNotAvailable();
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Native object address is NULL");
			}
			base.ptr = ptr;
		}

		public Stream()
		{
			ThrowIfNotAvailable();
			ptr = NativeMethods.gpu_Stream_new1();
		}

		public Stream(Stream m)
		{
			ThrowIfNotAvailable();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			ptr = NativeMethods.gpu_Stream_new2(m.CvPtr);
		}

		public void Release()
		{
			Dispose(disposing: true);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.gpu_Stream_delete(ptr);
						if (callbackHandle.IsAllocated)
						{
							callbackHandle.Free();
						}
						if (userDataHandle.IsAllocated)
						{
							userDataHandle.Free();
						}
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static explicit operator bool(Stream self)
		{
			self.ThrowIfDisposed();
			return NativeMethods.gpu_Stream_bool(self.ptr) != 0;
		}

		public bool QueryIfComplete()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_Stream_queryIfComplete(ptr) != 0;
		}

		public void WaitForCompletion()
		{
			ThrowIfDisposed();
			NativeMethods.gpu_Stream_waitForCompletion(ptr);
		}

		public void EnqueueDownload(GpuMat src, CudaMem dst)
		{
			ThrowIfDisposed();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			NativeMethods.gpu_Stream_enqueueDownload_CudaMem(ptr, src.CvPtr, dst.CvPtr);
		}

		public void EnqueueDownload(GpuMat src, Mat dst)
		{
			ThrowIfDisposed();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			NativeMethods.gpu_Stream_enqueueDownload_Mat(ptr, src.CvPtr, dst.CvPtr);
		}

		public void EnqueueUpload(CudaMem src, GpuMat dst)
		{
			ThrowIfDisposed();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			NativeMethods.gpu_Stream_enqueueUpload_CudaMem(ptr, src.CvPtr, dst.CvPtr);
		}

		public void EnqueueUpload(Mat src, GpuMat dst)
		{
			ThrowIfDisposed();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			NativeMethods.gpu_Stream_enqueueUpload_Mat(ptr, src.CvPtr, dst.CvPtr);
		}

		public void EnqueueCopy(GpuMat src, GpuMat dst)
		{
			ThrowIfDisposed();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			NativeMethods.gpu_Stream_enqueueCopy(ptr, src.CvPtr, dst.CvPtr);
		}

		public void EnqueueMemSet(GpuMat src, Scalar val)
		{
			ThrowIfDisposed();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			src.ThrowIfDisposed();
			NativeMethods.gpu_Stream_enqueueMemSet(ptr, src.CvPtr, val);
		}

		public void EnqueueMemSet(GpuMat src, Scalar val, GpuMat mask)
		{
			ThrowIfDisposed();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			src.ThrowIfDisposed();
			NativeMethods.gpu_Stream_enqueueMemSet_WithMask(ptr, src.CvPtr, val, Cv2.ToPtr(mask));
		}

		public void EnqueueConvert(GpuMat src, GpuMat dst, int dtype, double a = 1.0, double b = 0.0)
		{
			ThrowIfDisposed();
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			src.ThrowIfDisposed();
			dst.ThrowIfDisposed();
			NativeMethods.gpu_Stream_enqueueConvert(ptr, src.CvPtr, dst.CvPtr, dtype, a, b);
		}

		public void EnqueueHostCallback(StreamCallback callback, object userData = null)
		{
			ThrowIfDisposed();
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			if (callbackHandle.IsAllocated)
			{
				callbackHandle.Free();
			}
			if (userDataHandle.IsAllocated)
			{
				userDataHandle.Free();
			}
			IntPtr userData2 = IntPtr.Zero;
			if (userData != null)
			{
				userDataHandle = GCHandle.Alloc(userData);
				userData2 = GCHandle.ToIntPtr(userDataHandle);
			}
			callbackInternal = delegate(IntPtr rawStream, int status, IntPtr rawUserData)
			{
				Stream stream = new Stream(rawStream)
				{
					IsEnabledDispose = false
				};
				object target = GCHandle.FromIntPtr(rawUserData).Target;
				callback(stream, status, target);
			};
			callbackHandle = GCHandle.Alloc(callbackInternal);
			IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(callbackInternal);
			NativeMethods.gpu_Stream_enqueueHostCallback(ptr, functionPointerForDelegate, userData2);
		}
	}
}
