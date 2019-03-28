using System;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
	public class FileNode : DisposableCvObject
	{
		private bool disposed;

		public FileNode this[string nodeName]
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileNode");
				}
				if (nodeName == null)
				{
					throw new ArgumentNullException("nodeName");
				}
				IntPtr intPtr = NativeMethods.core_FileNode_operatorThis_byString(ptr, nodeName);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new FileNode(intPtr);
			}
		}

		public FileNode this[int i]
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileNode");
				}
				IntPtr intPtr = NativeMethods.core_FileNode_operatorThis_byInt(ptr, i);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new FileNode(intPtr);
			}
		}

		public bool Empty
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				return NativeMethods.core_FileNode_empty(ptr) != 0;
			}
		}

		public bool IsNone
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				return NativeMethods.core_FileNode_isNone(ptr) != 0;
			}
		}

		public bool IsSeq
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				return NativeMethods.core_FileNode_isSeq(ptr) != 0;
			}
		}

		public bool IsMap
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				return NativeMethods.core_FileNode_isMap(ptr) != 0;
			}
		}

		public bool IsInt
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				return NativeMethods.core_FileNode_isInt(ptr) != 0;
			}
		}

		public bool IsReal
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				return NativeMethods.core_FileNode_isReal(ptr) != 0;
			}
		}

		public bool IsString
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				return NativeMethods.core_FileNode_isString(ptr) != 0;
			}
		}

		public bool IsNamed
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				return NativeMethods.core_FileNode_isNamed(ptr) != 0;
			}
		}

		public string Name
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				StringBuilder stringBuilder = new StringBuilder(1024);
				NativeMethods.core_FileNode_name(ptr, stringBuilder, stringBuilder.Capacity);
				return stringBuilder.ToString();
			}
		}

		public long Size
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("FileStorage");
				}
				return NativeMethods.core_FileNode_size(ptr).ToInt64();
			}
		}

		public FileNode()
		{
			ptr = NativeMethods.core_FileNode_new1();
		}

		public FileNode(CvFileStorage fs, CvFileNode node)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			NativeMethods.core_FileNode_new2(fs.CvPtr, node.CvPtr);
		}

		public FileNode(FileNode node)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			NativeMethods.core_FileNode_new3(node.CvPtr);
		}

		public FileNode(IntPtr ptr)
		{
			base.ptr = ptr;
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (ptr != IntPtr.Zero)
					{
						NativeMethods.core_FileNode_delete(ptr);
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

		public static explicit operator int(FileNode node)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			return NativeMethods.core_FileNode_toInt(node.CvPtr);
		}

		public static explicit operator float(FileNode node)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			return NativeMethods.core_FileNode_toFloat(node.CvPtr);
		}

		public static explicit operator double(FileNode node)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			return NativeMethods.core_FileNode_toDouble(node.CvPtr);
		}

		public static explicit operator string(FileNode node)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			StringBuilder stringBuilder = new StringBuilder(65536);
			NativeMethods.core_FileNode_toString(node.CvPtr, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}

		public static explicit operator CvFileNode(FileNode fs)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			return fs.ToLegacy();
		}

		public CvFileNode ToLegacy()
		{
			return new CvFileNode(NativeMethods.core_FileNode_toLegacy(ptr));
		}

		public void ReadRaw(string fmt, IntPtr vec, long len)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("FileNode");
			}
			if (fmt == null)
			{
				throw new ArgumentNullException("fmt");
			}
			NativeMethods.core_FileNode_readRaw(ptr, fmt, vec, new IntPtr(len));
		}

		public IntPtr ReadObj()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("FileNode");
			}
			return NativeMethods.core_FileNode_readObj(ptr);
		}
	}
}
