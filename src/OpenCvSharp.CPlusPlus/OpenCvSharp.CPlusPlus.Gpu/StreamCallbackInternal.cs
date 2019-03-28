using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void StreamCallbackInternal(IntPtr stream, int status, IntPtr userData);
}
