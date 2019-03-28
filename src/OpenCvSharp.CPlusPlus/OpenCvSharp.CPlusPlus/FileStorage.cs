using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
	public class FileStorage : DisposableCvObject
	{
		private bool disposed;

		public FileNode this[string nodeName]
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				if (nodeName == null)
				{
					throw new ArgumentNullException("nodeName");
				}
				IntPtr intPtr = NativeMethods.core_FileStorage_indexer(ptr, nodeName);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new FileNode(intPtr);
			}
		}

		public unsafe string ElName
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				sbyte* ptr = NativeMethods.core_FileStorage_elname(base.ptr);
				if (ptr == null)
				{
					return null;
				}
				return new string(ptr);
			}
		}

		public byte[] Structs
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				IntPtr resultLength;
				IntPtr source = NativeMethods.core_FileStorage_structs(ptr, out resultLength);
				byte[] array = new byte[resultLength.ToInt32()];
				Marshal.Copy(source, array, 0, array.Length);
				return array;
			}
		}

		public int State
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				return NativeMethods.core_FileStorage_state(ptr);
			}
		}

		public FileStorage()
		{
			ptr = NativeMethods.core_FileStorage_new1();
		}

		public FileStorage(string source, FileStorageMode flags, string encoding = null)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			ptr = NativeMethods.core_FileStorage_new2(source, (int)flags, encoding);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (ptr != IntPtr.Zero)
					{
						NativeMethods.core_FileStorage_delete(ptr);
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

		public virtual bool Open(string fileName, FileStorageMode flags, string encoding = null)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("FileStorage");
			}
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			return NativeMethods.core_FileStorage_open(ptr, fileName, (int)flags, encoding) != 0;
		}

		public virtual bool IsOpened()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("FileStorage");
			}
			return NativeMethods.core_FileStorage_isOpened(ptr) != 0;
		}

		public virtual void Release()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("FileStorage");
			}
			Dispose();
		}

		public string ReleaseAndGetString()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("FileStorage");
			}
			StringBuilder stringBuilder = new StringBuilder(65536);
			NativeMethods.core_FileStorage_releaseAndGetString(ptr, stringBuilder, stringBuilder.Capacity);
			ptr = IntPtr.Zero;
			Dispose();
			return stringBuilder.ToString();
		}

		public FileNode GetFirstTopLevelNode()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("FileStorage");
			}
			IntPtr intPtr = NativeMethods.core_FileStorage_getFirstTopLevelNode(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new FileNode(intPtr);
		}

		public FileNode Root(int streamidx = 0)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("FileStorage");
			}
			IntPtr intPtr = NativeMethods.core_FileStorage_root(ptr, streamidx);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new FileNode(intPtr);
		}

		public static explicit operator CvFileStorage(FileStorage fs)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			return fs.ToLegacy();
		}

		public CvFileStorage ToLegacy()
		{
			return new CvFileStorage(NativeMethods.core_FileStorage_toLegacy(ptr))
			{
				IsEnabledDispose = false
			};
		}

		public void WriteRaw(string fmt, IntPtr vec, long len)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("FileStorage");
			}
		}

		public void WriteObj(string name, IntPtr obj)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("FileStorage");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			NativeMethods.core_FileStorage_writeObj(ptr, name, obj);
		}

		public static string GetDefaultObjectName(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException("", fileName);
			}
			StringBuilder stringBuilder = new StringBuilder(65536);
			NativeMethods.core_FileStorage_getDefaultObjectName(fileName, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}
	}
}
