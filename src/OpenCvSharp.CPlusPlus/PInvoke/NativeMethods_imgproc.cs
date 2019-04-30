using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    [SuppressUnmanagedCodeSecurity]
    public static partial class NativeMethods
	{

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_connectedComponents(
            IntPtr image, IntPtr labels, int connectivity, int ltype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_connectedComponentsWithStats(
            IntPtr image, IntPtr labels, IntPtr stats, IntPtr centroids, int connectivity, int ltype);

	}
}
