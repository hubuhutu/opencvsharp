using System;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public sealed class CudaMem : DisposableGpuObject, ICloneable
	{
		private bool disposed;

		public int Flags
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_CudaMem_flags(ptr);
			}
		}

		public int Rows
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_CudaMem_rows(ptr);
			}
		}

		public int Cols
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_CudaMem_cols(ptr);
			}
		}

		public int Height
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_CudaMem_rows(ptr);
			}
		}

		public int Width
		{
			get
			{
				ThrowIfDisposed();
				return NativeMethods.gpu_CudaMem_cols(ptr);
			}
		}

		public unsafe IntPtr Data
		{
			get
			{
				ThrowIfDisposed();
				return (IntPtr)(void*)NativeMethods.gpu_CudaMem_data(ptr);
			}
		}

		public unsafe IntPtr RefCount
		{
			get
			{
				ThrowIfDisposed();
				return (IntPtr)(void*)NativeMethods.gpu_CudaMem_refcount(ptr);
			}
		}

		public unsafe IntPtr DataStart
		{
			get
			{
				ThrowIfDisposed();
				return (IntPtr)(void*)NativeMethods.gpu_CudaMem_datastart(ptr);
			}
		}

		public unsafe IntPtr DataEnd
		{
			get
			{
				ThrowIfDisposed();
				return (IntPtr)(void*)NativeMethods.gpu_CudaMem_dataend(ptr);
			}
		}

		public CudaMemAllocType AllocType
		{
			get
			{
				ThrowIfDisposed();
				return (CudaMemAllocType)NativeMethods.gpu_CudaMem_alloc_type(ptr);
			}
		}

		public CudaMem(IntPtr ptr)
		{
			ThrowIfNotAvailable();
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Native object address is NULL");
			}
			base.ptr = ptr;
		}

		public CudaMem()
		{
			ThrowIfNotAvailable();
			ptr = NativeMethods.gpu_CudaMem_new1();
		}

		public CudaMem(CudaMem m)
		{
			ThrowIfNotAvailable();
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			ptr = NativeMethods.gpu_CudaMem_new2(m.CvPtr);
		}

		public CudaMem(int rows, int cols, MatType type, CudaMemAllocType allocType = CudaMemAllocType.Locked)
		{
			ThrowIfNotAvailable();
			ptr = NativeMethods.gpu_CudaMem_new3(rows, cols, type, (int)allocType);
		}

		public CudaMem(Size size, MatType type, CudaMemAllocType allocType = CudaMemAllocType.Locked)
			: this(size.Height, size.Width, type, allocType)
		{
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
						NativeMethods.gpu_CudaMem_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public static explicit operator Mat(CudaMem self)
		{
			return self?.CreateMatHeader();
		}

		public static implicit operator GpuMat(CudaMem self)
		{
			return self?.CreateGpuMatHeader();
		}

		public bool IsContinuous()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_CudaMem_isContinuous(ptr) != 0;
		}

		public int Channels()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_CudaMem_channels(ptr);
		}

		public int Depth()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_CudaMem_depth(ptr);
		}

		public long ElemSize()
		{
			ThrowIfDisposed();
			return (long)NativeMethods.gpu_CudaMem_elemSize(ptr);
		}

		public long ElemSize1()
		{
			ThrowIfDisposed();
			return (long)NativeMethods.gpu_CudaMem_elemSize1(ptr);
		}

		public Size Size()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_CudaMem_size(ptr);
		}

		public long Step()
		{
			ThrowIfDisposed();
			return (long)NativeMethods.gpu_CudaMem_step(ptr);
		}

		public long Step1()
		{
			ThrowIfDisposed();
			return (long)NativeMethods.gpu_CudaMem_step1(ptr);
		}

		public MatType Type()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_CudaMem_type(ptr);
		}

		public bool Empty()
		{
			ThrowIfDisposed();
			return NativeMethods.gpu_CudaMem_empty(ptr) != 0;
		}

		public CudaMem Clone()
		{
			ThrowIfDisposed();
			return new CudaMem(NativeMethods.gpu_CudaMem_clone(ptr));
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public void AssignTo(CudaMem target)
		{
			ThrowIfDisposed();
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			NativeMethods.gpu_CudaMem_opAssign(target.CvPtr, ptr);
		}

		public void Create(int rows, int cols, MatType type, CudaMemAllocType allocType = CudaMemAllocType.Locked)
		{
			ThrowIfDisposed();
			NativeMethods.gpu_CudaMem_create(ptr, rows, cols, type, (int)allocType);
		}

		public Mat CreateMatHeader()
		{
			ThrowIfDisposed();
			return new Mat(NativeMethods.gpu_CudaMem_createMatHeader(ptr));
		}

		public GpuMat CreateGpuMatHeader()
		{
			ThrowIfDisposed();
			return new GpuMat(NativeMethods.gpu_CudaMem_createGpuMatHeader(ptr));
		}

		public static bool CanMapHostMemory()
		{
			return NativeMethods.gpu_CudaMem_canMapHostMemory() != 0;
		}
	}
}
