using OpenCvSharp.CPlusPlus.Flann;
using OpenCvSharp.CPlusPlus.Gpu;
using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
	[SuppressUnmanagedCodeSecurity]
	public static partial class NativeMethods
	{
		private static bool tried;

		public const string DllExtern = "OpenCvSharpExtern";

		public const string Version = "2413";

		public const string DllContrib = "opencv_contrib"+ Version;

		public const string DllGpu = "opencv_gpu"+ Version;

		public const string DllNonfree = "opencv_nonfree"+ Version;

		public const string DllOcl = "opencv_ocl"+ Version;

		public const string DllStitching = "opencv_stitching"+ Version;

		public const string DllSuperres = "opencv_superres"+ Version;

		public const string DllVideoStab = "opencv_videostab"+ Version;

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Algorithm_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Algorithm_delete(IntPtr self);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_Algorithm_name(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Ptr_Algorithm_new(IntPtr rawPtr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Ptr_Algorithm_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Ptr_Algorithm_obj(IntPtr ptr);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern int core_Algorithm_getInt(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern double core_Algorithm_getDouble(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern int core_Algorithm_getBool(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_Algorithm_getString(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int maxLength);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr core_Algorithm_getMat(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_Algorithm_getMatVector(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr outVec);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr core_Algorithm_getAlgorithm(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_Algorithm_setInt(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, int value);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_Algorithm_setDouble(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, double value);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_Algorithm_setBool(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.Bool)] bool value);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_Algorithm_setString(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_Algorithm_setMat(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_Algorithm_setMatVector(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr[] value, int valueLength);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_Algorithm_setAlgorithm(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_Algorithm_paramHelp(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern int core_Algorithm_paramType(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Algorithm_getParams(IntPtr obj, IntPtr names);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Algorithm_getList(IntPtr algorithms);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr core_Algorithm_create([MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Algorithm_info(IntPtr obj);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_AlgorithmInfo_paramHelp(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, StringBuilder dst, int dstLength);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern int core_AlgorithmInfo_paramType(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_AlgorithmInfo_name(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] StringBuilder dst, int dstLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_AlgorithmInfo_getParams(IntPtr obj, IntPtr names);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_AlgorithmInfo_get(IntPtr obj, IntPtr algo, [MarshalAs(UnmanagedType.LPStr)] string name, int argType, IntPtr value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_AlgorithmInfo_getInt(IntPtr obj, IntPtr algo, [MarshalAs(UnmanagedType.LPStr)] string name, int argType, ref int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_AlgorithmInfo_getDouble(IntPtr obj, IntPtr algo, [MarshalAs(UnmanagedType.LPStr)] string name, int argType, ref double value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_AlgorithmInfo_getBool(IntPtr obj, IntPtr algo, [MarshalAs(UnmanagedType.LPStr)] string name, int argType, ref int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_AlgorithmInfo_getString(IntPtr obj, IntPtr algo, [MarshalAs(UnmanagedType.LPStr)] string name, int argType, [MarshalAs(UnmanagedType.LPStr)] StringBuilder value, int valueLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_AlgorithmInfo_getMat(IntPtr obj, IntPtr algo, [MarshalAs(UnmanagedType.LPStr)] string name, int argType, IntPtr value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_AlgorithmInfo_setInt(IntPtr obj, IntPtr algo, [MarshalAs(UnmanagedType.LPStr)] string name, int argType, int value, int force);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_AlgorithmInfo_setDouble(IntPtr obj, IntPtr algo, [MarshalAs(UnmanagedType.LPStr)] string name, int argType, double value, int force);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_AlgorithmInfo_setBool(IntPtr obj, IntPtr algo, [MarshalAs(UnmanagedType.LPStr)] string name, int argType, int value, int force);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_AlgorithmInfo_setString(IntPtr obj, IntPtr algo, [MarshalAs(UnmanagedType.LPStr)] string name, int argType, [MarshalAs(UnmanagedType.LPStr)] string value, int force);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_AlgorithmInfo_setMat(IntPtr obj, IntPtr algo, [MarshalAs(UnmanagedType.LPStr)] string name, int argType, IntPtr value, int force);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_InputArray_new_byMat(IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_InputArray_new_byMatExpr(IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_InputArray_new_byScalar(Scalar val);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_InputArray_new_byDouble(double val);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_InputArray_new_byGpuMat(IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_InputArray_new_byVectorOfMat(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_InputArray_delete(IntPtr ia);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_OutputArray_new_byMat(IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_OutputArray_new_byGpuMat(IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_OutputArray_new_byScalar(CvScalar val);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_OutputArray_new_byVectorOfMat(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_OutputArray_delete(IntPtr oa);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_InputArray_kind(IntPtr ia);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_OutputArray_getMat(IntPtr oa);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvScalar core_OutputArray_getScalar(IntPtr oa);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_OutputArray_getVectorOfMat(IntPtr oa, IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileStorage_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileStorage_new2([MarshalAs(UnmanagedType.LPStr)] string source, int flags, [MarshalAs(UnmanagedType.LPStr)] string encoding);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileStorage_newFromLegacy(IntPtr fs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_FileStorage_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileStorage_open(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, int flags, [MarshalAs(UnmanagedType.LPStr)] string encoding);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileStorage_isOpened(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_FileStorage_release(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_FileStorage_releaseAndGetString(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileStorage_getFirstTopLevelNode(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileStorage_root(IntPtr obj, int streamIdx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileStorage_indexer(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string nodeName);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileStorage_toLegacy(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_FileStorage_writeRaw(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fmt, IntPtr vec, IntPtr len);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_FileStorage_writeObj(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_FileStorage_getDefaultObjectName([MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern sbyte* core_FileStorage_elname(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileStorage_structs(IntPtr obj, out IntPtr resultLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileStorage_state(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileNode_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileNode_new2(IntPtr fs, IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileNode_new3(IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_FileNode_delete(IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileNode_operatorThis_byString(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string nodeName);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileNode_operatorThis_byInt(IntPtr obj, int i);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileNode_type(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileNode_empty(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileNode_isNone(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileNode_isSeq(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileNode_isMap(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileNode_isInt(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileNode_isReal(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileNode_isString(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileNode_isNamed(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_FileNode_name(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileNode_size(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_FileNode_toInt(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float core_FileNode_toFloat(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double core_FileNode_toDouble(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_FileNode_toString(IntPtr obj, StringBuilder buf, int bufLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileNode_toLegacy(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_FileNode_readRaw(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fmt, IntPtr vec, IntPtr len);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_FileNode_readObj(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_PCA_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_PCA_new2(IntPtr data, IntPtr mean, int flags, int maxComponents);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_PCA_new3(IntPtr data, IntPtr mean, int flags, double retainedVariance);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_PCA_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_PCA_operatorThis(IntPtr obj, IntPtr data, IntPtr mean, int flags, int maxComponents);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_PCA_computeVar(IntPtr obj, IntPtr data, IntPtr mean, int flags, double retainedVariance);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_PCA_project1")]
		public static extern IntPtr core_PCA_project(IntPtr obj, IntPtr vec);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_PCA_project2")]
		public static extern void core_PCA_project(IntPtr obj, IntPtr vec, IntPtr result);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_PCA_backProject1")]
		public static extern IntPtr core_PCA_backProject(IntPtr obj, IntPtr vec);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_PCA_backProject2")]
		public static extern void core_PCA_backProject(IntPtr obj, IntPtr vec, IntPtr result);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_PCA_eigenvectors(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_PCA_eigenvalues(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_PCA_mean(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_new1")]
		public static extern ulong core_RNG_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_new2")]
		public static extern ulong core_RNG_new(ulong state);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint core_RNG_next(ulong state);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte core_RNG_operator_uchar(ulong state);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern sbyte core_RNG_operator_schar(ulong state);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort core_RNG_operator_ushort(ulong state);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern short core_RNG_operator_short(ulong state);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint core_RNG_operator_uint(ulong state);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_operatorThis1")]
		public static extern uint core_RNG_operatorThis(ulong state, uint n);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_operatorThis2")]
		public static extern uint core_RNG_operatorThis(ulong state);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_RNG_operator_int(ulong state);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float core_RNG_operator_float(ulong state);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double core_RNG_operator_double(ulong state);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_uniform_int")]
		public static extern int core_RNG_uniform(ulong state, int a, int b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_uniform_float")]
		public static extern float core_RNG_uniform(ulong state, float a, float b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_RNG_uniform_double")]
		public static extern double core_RNG_uniform(ulong state, double a, double b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_RNG_fill(ulong state, IntPtr mat, int distType, IntPtr a, IntPtr b, int saturateRange);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double core_RNG_gaussian(ulong state, double sigma);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_SVD_new1")]
		public static extern IntPtr core_SVD_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_SVD_new2")]
		public static extern IntPtr core_SVD_new(IntPtr src, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SVD_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SVD_operatorThis(IntPtr obj, IntPtr src, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SVD_backSubst(IntPtr obj, IntPtr rhs, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_SVD_static_compute1")]
		public static extern void core_SVD_static_compute(IntPtr src, IntPtr w, IntPtr u, IntPtr vt, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_SVD_static_compute2")]
		public static extern void core_SVD_static_compute(IntPtr src, IntPtr w, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SVD_static_backSubst(IntPtr w, IntPtr u, IntPtr vt, IntPtr rhs, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SVD_static_solveZ(IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SVD_u(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SVD_w(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SVD_vt(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong core_SparseMat_sizeof();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_new2(int dims, int[] sizes, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_new3(IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_new4(IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SparseMat_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SparseMat_operatorAssign_SparseMat(IntPtr obj, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SparseMat_operatorAssign_Mat(IntPtr obj, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_clone(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SparseMat_copyTo_SparseMat(IntPtr obj, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SparseMat_copyTo_Mat(IntPtr obj, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SparseMat_convertTo_SparseMat(IntPtr obj, IntPtr m, int rtype, double alpha);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SparseMat_convertTo_Mat(IntPtr obj, IntPtr m, int rtype, double alpha, double beta);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SparseMat_assignTo(IntPtr obj, IntPtr m, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SparseMat_create(IntPtr obj, int dims, int[] sizes, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SparseMat_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SparseMat_addref(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SparseMat_release(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_operator_CvSparseMat(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_SparseMat_elemSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_SparseMat_elemSize1(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_SparseMat_type(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_SparseMat_depth(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_SparseMat_channels(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_size1(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_SparseMat_size2(IntPtr obj, int i);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_SparseMat_dims(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_nzcount(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_hash_1d(IntPtr obj, int i0);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_hash_2d(IntPtr obj, int i0, int i1);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_hash_3d(IntPtr obj, int i0, int i1, int i2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_hash_nd(IntPtr obj, int[] idx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_ptr_1d(IntPtr obj, int i0, int createMissing, ref ulong hashval);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_ptr_1d(IntPtr obj, int i0, int createMissing, IntPtr hashval);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_ptr_2d(IntPtr obj, int i0, int i1, int createMissing, ref ulong hashval);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_ptr_2d(IntPtr obj, int i0, int i1, int createMissing, IntPtr hashval);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_ptr_3d(IntPtr obj, int i0, int i1, int i2, int createMissing, ref ulong hashval);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_ptr_3d(IntPtr obj, int i0, int i1, int i2, int createMissing, IntPtr hashval);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_ptr_nd(IntPtr obj, int[] idx, int createMissing, ref ulong hashval);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_SparseMat_ptr_nd(IntPtr obj, int[] idx, int createMissing, IntPtr hashval);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvERTrees_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvERTrees_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern int ml_CvERTrees_train1(IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern int ml_CvERTrees_train2(IntPtr obj, IntPtr data, IntPtr param);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern int ml_CvERTrees_grow_forest(IntPtr obj, CvTermCriteria termCrit);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvRTParams_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvRTParams_new2(int maxDepth, int minSampleCount, float regressionAccuracy, int useSurrogates, int maxCategories, IntPtr priors, int calcVarImportance, int nactiveVars, int maxNumOfTreesInTheForest, float forestAccuracy, int termcritType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvRTParams_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvRTParams_calc_var_importance_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvRTParams_calc_var_importance_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvRTParams_nactive_vars_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvRTParams_nactive_vars_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvTermCriteria ml_CvRTParams_term_crit_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvRTParams_term_crit_set(IntPtr obj, CvTermCriteria value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvRTrees_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvRTrees_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvRTrees_train_CvMat(IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvRTrees_train_Mat(IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvRTrees_train_MLData(IntPtr obj, IntPtr data, IntPtr param);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvRTrees_predict_CvMat(IntPtr obj, IntPtr sample, IntPtr missing);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvRTrees_predict_Mat(IntPtr obj, IntPtr sample, IntPtr missing);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvRTrees_predict_prob_CvMat(IntPtr obj, IntPtr sample, IntPtr missing);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvRTrees_predict_prob_Mat(IntPtr obj, IntPtr sample, IntPtr missing);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvRTrees_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvRTrees_getVarImportance(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvRTrees_get_proximity(IntPtr obj, IntPtr sample1, IntPtr sample2, IntPtr missing1, IntPtr missing2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvRTrees_read(IntPtr obj, IntPtr fs, IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvRTrees_write(IntPtr obj, IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvRTrees_get_active_var_mask(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvRTrees_get_rng(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvRTrees_get_tree_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvRTrees_get_tree(IntPtr obj, int i);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvForestTree_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvForestTree_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvForestTree_train(IntPtr obj, IntPtr _train_data, IntPtr _subsample_idx, IntPtr forest);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvForestTree_get_var_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvForestTree_read(IntPtr obj, IntPtr fs, IntPtr node, IntPtr forest, IntPtr _data);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvNormalBayesClassifier_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvNormalBayesClassifier_new2_CvMat(IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvNormalBayesClassifier_new2_Mat(IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvNormalBayesClassifier_destruct(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvNormalBayesClassifier_train_CvMat(IntPtr obj, IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, int update);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvNormalBayesClassifier_train_Mat(IntPtr obj, IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, int update);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvNormalBayesClassifier_predict_CvMat(IntPtr obj, IntPtr samples, IntPtr results);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvNormalBayesClassifier_predict_Mat(IntPtr obj, IntPtr samples, IntPtr results);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvNormalBayesClassifier_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvNormalBayesClassifier_write(IntPtr obj, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvNormalBayesClassifier_read(IntPtr obj, IntPtr storage, IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_boxFilter(IntPtr src, IntPtr dst, int ddepth, Size ksize, Point anchor, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_erode1(IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_erode2(IntPtr src, IntPtr dst, IntPtr kernel, IntPtr buf, Point anchor, int iterations, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_dilate1(IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_dilate2(IntPtr src, IntPtr dst, IntPtr kernel, IntPtr buf, Point anchor, int iterations, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_morphologyEx1(IntPtr src, IntPtr dst, int op, IntPtr kernel, Point anchor, int iterations);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_morphologyEx2(IntPtr src, IntPtr dst, int op, IntPtr kernel, IntPtr buf1, IntPtr buf2, Point anchor, int iterations, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_filter2D(IntPtr src, IntPtr dst, int ddepth, IntPtr kernel, Point anchor, int borderType, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_sepFilter2D1(IntPtr src, IntPtr dst, int ddepth, IntPtr kernelX, IntPtr kernelY, Point anchor, int rowBorderType, int columnBorderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_sepFilter2D2(IntPtr src, IntPtr dst, int ddepth, IntPtr kernelX, IntPtr kernelY, IntPtr buf, Point anchor, int rowBorderType, int columnBorderType, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Sobel1(IntPtr src, IntPtr dst, int ddepth, int dx, int dy, int ksize, double scale, int rowBorderType, int columnBorderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Sobel2(IntPtr src, IntPtr dst, int ddepth, int dx, int dy, IntPtr buf, int ksize, double scale, int rowBorderType, int columnBorderType, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Scharr1(IntPtr src, IntPtr dst, int ddepth, int dx, int dy, double scale, int rowBorderType, int columnBorderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Scharr2(IntPtr src, IntPtr dst, int ddepth, int dx, int dy, IntPtr buf, double scale, int rowBorderType, int columnBorderType, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GaussianBlur1(IntPtr src, IntPtr dst, Size ksize, double sigma1, double sigma2, int rowBorderType, int columnBorderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GaussianBlur2(IntPtr src, IntPtr dst, Size ksize, IntPtr buf, double sigma1, double sigma2, int rowBorderType, int columnBorderType, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Laplacian(IntPtr src, IntPtr dst, int ddepth, int ksize, double scale, int borderType, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_minMaxLoc1(IntPtr src, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_minMaxLoc2(IntPtr src, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc, IntPtr mask, IntPtr valbuf, IntPtr locbuf);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_matchTemplate1(IntPtr image, IntPtr templ, IntPtr result, int method, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_matchTemplate2(IntPtr image, IntPtr templ, IntPtr result, int method, IntPtr buf, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_new2(int rows, int cols, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_new3(int rows, int cols, int type, IntPtr data, ulong step);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_new4(IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_new5(IntPtr gpumat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_new6(CvSize size, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_new7(CvSize size, int type, IntPtr data, ulong step);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_new8(int rows, int cols, int type, CvScalar s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_new9(IntPtr m, CvSlice rowRange, CvSlice colRange);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_new10(IntPtr m, CvRect roi);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_new11(CvSize size, int type, CvScalar s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_opToMat(IntPtr src);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_opToGpuMat(IntPtr src);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_opAssign(IntPtr left, IntPtr right);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_opRange1(IntPtr src, CvRect roi);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_opRange2(IntPtr src, CvSlice rowRange, CvSlice colRange);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_GpuMat_flags(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_GpuMat_rows(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_GpuMat_cols(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_GpuMat_step(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern byte* gpu_GpuMat_data(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_refcount(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_datastart(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_dataend(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_upload(IntPtr obj, IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_download(IntPtr obj, IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_row(IntPtr obj, int y);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_col(IntPtr obj, int x);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_rowRange(IntPtr obj, int startrow, int endrow);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_colRange(IntPtr obj, int startcol, int endcol);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_clone(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_copyTo1(IntPtr obj, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_copyTo2(IntPtr obj, IntPtr m, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_convertTo(IntPtr obj, IntPtr m, int rtype, double alpha, double beta);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_assignTo(IntPtr obj, IntPtr m, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_setTo(IntPtr obj, CvScalar s, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_reshape(IntPtr obj, int cn, int rows);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_create1(IntPtr obj, int rows, int cols, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_create2(IntPtr obj, CvSize size, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_release(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_swap(IntPtr obj, IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_GpuMat_locateROI(IntPtr obj, out CvSize wholeSize, out CvPoint ofs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_GpuMat_adjustROI(IntPtr obj, int dtop, int dbottom, int dleft, int drightt);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_GpuMat_isContinuous(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_GpuMat_elemSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_GpuMat_elemSize1(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_GpuMat_type(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_GpuMat_depth(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_GpuMat_channels(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_GpuMat_step1(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize gpu_GpuMat_size(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_GpuMat_empty(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern byte* gpu_GpuMat_ptr(IntPtr obj, int y);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_createContinuous1(int rows, int cols, int type, IntPtr gm);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_createContinuous2(int rows, int cols, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_ensureSizeIsEnough(int rows, int cols, int type, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_allocMatFromBuf(int rows, int cols, int type, IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_getCudaEnabledDeviceCount();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_setDevice(int device);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_getDevice();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_resetDevice();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_deviceSupports(int feature_set);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_TargetArchs_builtWith(int feature_set);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_TargetArchs_has(int major, int minor);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_TargetArchs_hasPtx(int major, int minor);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_TargetArchs_hasBin(int major, int minor);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_TargetArchs_hasEqualOrLessPtx(int major, int minor);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_TargetArchs_hasEqualOrGreater(int major, int minor);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_TargetArchs_hasEqualOrGreaterPtx(int major, int minor);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_TargetArchs_hasEqualOrGreaterBin(int major, int minor);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_DeviceInfo_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_DeviceInfo_new2(int deviceId);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_DeviceInfo_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern void gpu_DeviceInfo_name(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_DeviceInfo_majorVersion(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_DeviceInfo_minorVersion(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_DeviceInfo_multiProcessorCount(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_DeviceInfo_sharedMemPerBlock(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_DeviceInfo_queryMemory(IntPtr obj, out ulong totalMemory, out ulong freeMemory);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_DeviceInfo_freeMemory(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_DeviceInfo_totalMemory(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_DeviceInfo_supports(IntPtr obj, int featureSet);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_DeviceInfo_isCompatible(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_DeviceInfo_deviceID(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_printCudaDeviceInfo(int device);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_printShortCudaDeviceInfo(int device);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_registerPageLocked(IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_unregisterPageLocked(IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_CudaMem_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_CudaMem_new2(IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_CudaMem_new3(int rows, int cols, int type, int allocType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_CudaMem_new4(IntPtr m, int allocType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_CudaMem_delete(IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_CudaMem_opAssign(IntPtr left, IntPtr right);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_CudaMem_clone(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_CudaMem_create(IntPtr obj, int rows, int cols, int type, int allocType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_CudaMem_release(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_CudaMem_createMatHeader(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_CudaMem_createGpuMatHeader(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CudaMem_canMapHostMemory();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CudaMem_isContinuous(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_CudaMem_elemSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_CudaMem_elemSize1(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CudaMem_type(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CudaMem_depth(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CudaMem_channels(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_CudaMem_step1(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize gpu_CudaMem_size(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CudaMem_empty(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CudaMem_flags(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CudaMem_rows(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CudaMem_cols(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_CudaMem_step(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern byte* gpu_CudaMem_data(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* gpu_CudaMem_refcount(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern byte* gpu_CudaMem_datastart(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern byte* gpu_CudaMem_dataend(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CudaMem_alloc_type(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_Stream_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_Stream_new2(IntPtr s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Stream_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Stream_opAssign(IntPtr left, IntPtr right);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_Stream_queryIfComplete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Stream_waitForCompletion(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Stream_enqueueDownload_CudaMem(IntPtr obj, IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Stream_enqueueDownload_Mat(IntPtr obj, IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Stream_enqueueUpload_CudaMem(IntPtr obj, IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Stream_enqueueUpload_Mat(IntPtr obj, IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Stream_enqueueCopy(IntPtr obj, IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Stream_enqueueMemSet(IntPtr obj, IntPtr src, CvScalar val);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Stream_enqueueMemSet_WithMask(IntPtr obj, IntPtr src, CvScalar val, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Stream_enqueueConvert(IntPtr obj, IntPtr src, IntPtr dst, int dtype, double a, double b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_Stream_enqueueHostCallback(IntPtr obj, IntPtr callback, IntPtr userData);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_Stream_Null();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_Stream_bool(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_CascadeClassifier_GPU_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_CascadeClassifier_GPU_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_CascadeClassifier_GPU_new2(string filename);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CascadeClassifier_GPU_empty(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CascadeClassifier_GPU_load(IntPtr obj, string filename);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_CascadeClassifier_GPU_release(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CascadeClassifier_GPU_detectMultiScale1(IntPtr obj, IntPtr image, IntPtr objectsBuf, double scaleFactor, int minNeighbors, CvSize minSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CascadeClassifier_GPU_detectMultiScale2(IntPtr obj, IntPtr image, IntPtr objectsBuf, CvSize maxObjectSize, CvSize minSize, double scaleFactor, int minNeighbors);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CascadeClassifier_GPU_findLargestObject_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_CascadeClassifier_GPU_findLargestObject_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_CascadeClassifier_GPU_visualizeInPlace_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_CascadeClassifier_GPU_visualizeInPlace_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize gpu_CascadeClassifier_GPU_getClassifierSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_HOGDescriptor_sizeof();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_HOGDescriptor_new(CvSize win_size, CvSize block_size, CvSize block_stride, CvSize cell_size, int nbins, double winSigma, double threshold_L2Hys, bool gamma_correction, int nlevels);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_HOGDescriptor_getDescriptorSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong gpu_HOGDescriptor_getBlockHistogramSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_HOGDescriptor_checkDetectorSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double gpu_HOGDescriptor_getWinSigma(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_setSVMDetector(IntPtr obj, IntPtr svmdetector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_detect(IntPtr obj, IntPtr img, IntPtr found_locations, double hit_threshold, CvSize win_stride, CvSize padding);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_detectMultiScale(IntPtr obj, IntPtr img, IntPtr found_locations, double hit_threshold, CvSize win_stride, CvSize padding, double scale, int group_threshold);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void HOGDescriptor_getDescriptors(IntPtr obj, IntPtr img, CvSize win_stride, IntPtr descriptors, [MarshalAs(UnmanagedType.I4)] DescriptorFormat descr_format);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize gpu_HOGDescriptor_win_size_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize gpu_HOGDescriptor_block_size_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize gpu_HOGDescriptor_block_stride_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize gpu_HOGDescriptor_cell_size_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_HOGDescriptor_nbins_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double gpu_HOGDescriptor_win_sigma_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double gpu_HOGDescriptor_threshold_L2hys_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_HOGDescriptor_nlevels_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_HOGDescriptor_gamma_correction_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_win_size_set(IntPtr obj, CvSize value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_block_size_set(IntPtr obj, CvSize value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_block_stride_set(IntPtr obj, CvSize value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_cell_size_set(IntPtr obj, CvSize value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_nbins_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_win_sigma_set(IntPtr obj, double value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_threshold_L2hys_set(IntPtr obj, double value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_nlevels_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_HOGDescriptor_gamma_correction_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_MOG_GPU_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_MOG_GPU_new(int nmixtures);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_MOG_GPU_initialize(IntPtr obj, CvSize frameSize, int frameType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_MOG_GPU_operator(IntPtr obj, IntPtr frame, IntPtr fgmask, float learningRate, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_MOG_GPU_getBackgroundImage(IntPtr obj, IntPtr backgroundImage, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_MOG_GPU_release(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* gpu_MOG_GPU_history(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* gpu_MOG_GPU_varThreshold(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* gpu_MOG_GPU_backgroundRatio(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* gpu_MOG_GPU_noiseSigma(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_MOG2_GPU_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_MOG2_GPU_new(int nmixtures);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_MOG2_GPU_initialize(IntPtr obj, CvSize frameSize, int frameType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_MOG2_GPU_operator(IntPtr obj, IntPtr frame, IntPtr fgmask, float learningRate, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_MOG2_GPU_getBackgroundImage(IntPtr obj, IntPtr backgroundImage, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_MOG2_GPU_release(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* gpu_MOG2_GPU_history(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* gpu_MOG2_GPU_varThreshold(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* gpu_MOG2_GPU_backgroundRatio(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* gpu_MOG2_GPU_varThresholdGen(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* gpu_MOG2_GPU_fVarInit(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* gpu_MOG2_GPU_fVarMin(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* gpu_MOG2_GPU_fVarMax(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* gpu_MOG2_GPU_fCT(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_MOG2_GPU_bShadowDetection_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_MOG2_GPU_bShadowDetection_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern byte* gpu_MOG2_GPU_nShadowDetection(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* gpu_MOG2_GPU_fTau(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_StereoBM_GPU_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_StereoBM_GPU_new2(int preset, int ndisparities, int winSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_StereoBM_GPU_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_StereoBM_GPU_run1(IntPtr obj, IntPtr left, IntPtr right, IntPtr disparity);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_StereoBM_GPU_run2(IntPtr obj, IntPtr left, IntPtr right, IntPtr disparity, IntPtr stream);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_StereoBM_GPU_checkIfGpuCallReasonable();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* gpu_StereoBM_GPU_preset(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* gpu_StereoBM_GPU_ndisp(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* gpu_StereoBM_GPU_winSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* gpu_StereoBM_GPU_avergeTexThreshold(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_FAST_GPU_new(int threshold, int nonmaxSuppression, double keypointsRatio);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_FAST_GPU_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_FAST_GPU_operator1(IntPtr obj, IntPtr image, IntPtr mask, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_FAST_GPU_operator2(IntPtr obj, IntPtr image, IntPtr mask, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_FAST_GPU_downloadKeypoints(IntPtr obj, IntPtr d_keypoints, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_FAST_GPU_convertKeypoints(IntPtr obj, IntPtr h_keypoints, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_FAST_GPU_release(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_FAST_GPU_nonmaxSuppression_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_FAST_GPU_nonmaxSuppression_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_FAST_GPU_threshold_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_FAST_GPU_threshold_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double gpu_FAST_GPU_keypointsRatio_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_FAST_GPU_keypointsRatio_set(IntPtr obj, double value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_FAST_GPU_calcKeyPointsLocation(IntPtr obj, IntPtr image, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_FAST_GPU_getKeyPoints(IntPtr obj, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr gpu_ORB_GPU_new(int nFeatures, float scaleFactor, int nLevels, int edgeThreshold, int firstLevel, int WTA_K, int scoreType, int patchSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_ORB_GPU_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_ORB_GPU_operator1(IntPtr obj, IntPtr image, IntPtr mask, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_ORB_GPU_operator2(IntPtr obj, IntPtr image, IntPtr mask, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_ORB_GPU_operator3(IntPtr obj, IntPtr image, IntPtr mask, IntPtr keypoints, IntPtr descriptors);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_ORB_GPU_operator4(IntPtr obj, IntPtr image, IntPtr mask, IntPtr keypoints, IntPtr descriptors);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_ORB_GPU_downloadKeyPoints(IntPtr obj, IntPtr d_keypoints, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_ORB_GPU_convertKeyPoints(IntPtr obj, IntPtr h_keypoints, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_ORB_GPU_descriptorSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_ORB_GPU_release(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_ORB_GPU_setFastParams(IntPtr obj, int threshold, int nonmaxSuppression);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpu_ORB_GPU_blurForDescriptor_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gpu_ORB_GPU_blurForDescriptor_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorMatcher_add(IntPtr obj, IntPtr[] descriptors, int descriptorLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorMatcher_getTrainDescriptors(IntPtr obj, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorMatcher_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_DescriptorMatcher_empty(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_DescriptorMatcher_isMaskSupported(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorMatcher_train(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorMatcher_match1(IntPtr obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorMatcher_knnMatch1(IntPtr obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, int k, IntPtr mask, int compactResult);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorMatcher_radiusMatch1(IntPtr obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, float maxDistance, IntPtr mask, int compactResult);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorMatcher_match2(IntPtr obj, IntPtr queryDescriptors, IntPtr matches, IntPtr[] masks, int masksSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorMatcher_knnMatch2(IntPtr obj, IntPtr queryDescriptors, IntPtr matches, int k, IntPtr[] masks, int masksSize, int compactResult);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorMatcher_radiusMatch2(IntPtr obj, IntPtr queryDescriptors, IntPtr matches, float maxDistance, IntPtr[] masks, int masksSize, int compactResult);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr features2d_DescriptorMatcher_create([MarshalAs(UnmanagedType.LPStr)] string descriptorMatcherType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_DescriptorMatcher_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_DescriptorMatcher_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_DescriptorMatcher_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_BFMatcher_new(int normType, int crossCheck);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_BFMatcher_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_BFMatcher_isMaskSupported(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_BFMatcher_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_BFMatcher_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_BFMatcher_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_FlannBasedMatcher_new(IntPtr indexParams, IntPtr searchParams);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_FlannBasedMatcher_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_FlannBasedMatcher_add(IntPtr obj, IntPtr[] descriptors, int descriptorsSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_FlannBasedMatcher_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_FlannBasedMatcher_train(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_FlannBasedMatcher_isMaskSupported(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_FlannBasedMatcher_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_FlannBasedMatcher_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_FlannBasedMatcher_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvBoostTree_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvBoostTree_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvBoostTree_train(IntPtr obj, IntPtr trainData, IntPtr subsampleIdx, IntPtr ensemble);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvBoostTree_scale(IntPtr obj, double s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvBoostTree_read(IntPtr obj, IntPtr fs, IntPtr node, IntPtr ensemble, IntPtr data);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvBoostTree_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_EM_new(int nclusters, int covMatType, CvTermCriteria termCrit);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_EM_delete(IntPtr model);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_EM_clear(IntPtr model);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_EM_train(IntPtr model, IntPtr samples, IntPtr logLikelihoods, IntPtr labels, IntPtr probs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_EM_trainE(IntPtr model, IntPtr samples, IntPtr means0, IntPtr covs0, IntPtr weights0, IntPtr logLikelihoods, IntPtr labels, IntPtr probs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_EM_trainM(IntPtr model, IntPtr samples, IntPtr probs0, IntPtr logLikelihoods, IntPtr labels, IntPtr probs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_EM_predict(IntPtr model, IntPtr sample, IntPtr probs, out Vec2d ret);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_EM_isTrained(IntPtr model);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_EM_info(IntPtr model);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_EM_read(IntPtr model, IntPtr fn);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_Ptr_EM_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_Ptr_EM_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvSVMParams_new1(ref WCvSVMParams result);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvSVMParams_new2(ref WCvSVMParams result, int svmType, int kernelType, double degree, double gamma, double coef0, double c, double nu, double p, IntPtr classWeights, CvTermCriteria termCrit);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvSVM_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvSVM_new2_CvMat(IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, WCvSVMParams param);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvSVM_new2_Mat(IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, WCvSVMParams param);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvSVM_delete(IntPtr model);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvSVM_get_default_grid(ref CvParamGrid grid, int paramId);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvParamGrid_check(CvParamGrid grid);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvSVM_train_CvMat(IntPtr model, IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, WCvSVMParams param);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvSVM_train_Mat(IntPtr model, IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, WCvSVMParams param);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvSVM_train_auto_CvMat(IntPtr model, IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, WCvSVMParams param, int kFold, CvParamGrid cGrid, CvParamGrid gammaGrid, CvParamGrid pGrid, CvParamGrid nuGrid, CvParamGrid coefGrid, CvParamGrid degreeGrid, int balanced);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvSVM_train_auto_Mat(IntPtr model, IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, WCvSVMParams param, int kFold, CvParamGrid cGrid, CvParamGrid gammaGrid, CvParamGrid pGrid, CvParamGrid nuGrid, CvParamGrid coefGrid, CvParamGrid degreeGrid, int balanced);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvSVM_predict_CvMat1(IntPtr model, IntPtr sample, int returnDFVal);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvSVM_predict_CvMat2(IntPtr model, IntPtr sample, IntPtr results);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvSVM_predict_Mat1(IntPtr model, IntPtr sample, int returnDFVal);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvSVM_predict_Mat2(IntPtr model, IntPtr samples, IntPtr results);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* ml_CvSVM_get_support_vector(IntPtr model, int i);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvSVM_get_support_vector_count(IntPtr model);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvSVM_get_var_count(IntPtr model);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvSVM_get_params(IntPtr model, ref WCvSVMParams p);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvSVM_clear(IntPtr model);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvSVM_write(IntPtr model, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvSVM_read(IntPtr model, IntPtr storage, IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvKNearest_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvKNearest_new2_CvMat(IntPtr trainData, IntPtr responses, IntPtr sampleIdx, int isRegression, int maxK);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvKNearest_new2_Mat(IntPtr trainData, IntPtr responses, IntPtr sampleIdx, int isRegression, int maxK);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvKNearest_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvKNearest_train_CvMat(IntPtr obj, IntPtr trainData, IntPtr responses, IntPtr sampleIdx, int isRegression, int maxK, int updateBase);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvKNearest_train_Mat(IntPtr obj, IntPtr trainData, IntPtr responses, IntPtr sampleIdx, int isRegression, int maxK, int updateBase);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvKNearest_find_nearest_CvMat(IntPtr obj, IntPtr samples, int k, IntPtr results, [In] [Out] IntPtr[] neighbors, IntPtr neighborResponses, IntPtr dist);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvKNearest_find_nearest_Mat(IntPtr obj, IntPtr samples, int k, IntPtr results, IntPtr neighborResponses, IntPtr dists);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvKNearest_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvKNearest_get_max_k(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvKNearest_get_var_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvKNearest_get_sample_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvKNearest_is_regression(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvTrainTestSplit_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvTrainTestSplit_new2(int trainSampleCount, int mix);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvTrainTestSplit_new3(float trainSamplePortion, int mix);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvTrainTestSplit_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvTrainTestSplit_train_sample_part_count_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvTrainTestSplit_train_sample_part_count_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvTrainTestSplit_train_sample_part_portion_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvTrainTestSplit_train_sample_part_portion_set(IntPtr obj, float value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvTrainTestSplit_train_sample_part_mode_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvTrainTestSplit_train_sample_part_mode_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* ml_CvTrainTestSplit_class_part_count_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* ml_CvTrainTestSplit_class_part_portion_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvTrainTestSplit_class_part_mode_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvTrainTestSplit_class_part_mode_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvTrainTestSplit_mix_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvTrainTestSplit_mix_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvMLData_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvMLData_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvMLData_read_csv(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvMLData_get_values(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvMLData_get_responses(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvMLData_get_missing(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvMLData_set_response_idx(IntPtr obj, int idx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvMLData_get_response_idx(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvMLData_get_train_sample_idx(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvMLData_get_test_sample_idx(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvMLData_mix_train_and_test_idx(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvMLData_set_train_test_split(IntPtr obj, IntPtr spl);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvMLData_get_var_idx(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvMLData_change_var_idx(IntPtr obj, int vi, int state);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvMLData_get_var_types(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvMLData_get_var_type(IntPtr obj, int varIdx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvMLData_set_var_types(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string str);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvMLData_change_var_type(IntPtr obj, int varIdx, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvMLData_set_delimiter(IntPtr obj, byte ch);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte ml_CvMLData_get_delimiter(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvMLData_set_miss_ch(IntPtr obj, byte ch);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte ml_CvMLData_get_miss_ch(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeParams_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeParams_new2(int maxDepth, int minSampleCount, float regressionAccuracy, int useSurrogates, int maxCategories, int cvFolds, int use1SeRule, int truncatePrunedTree, IntPtr priors);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeParams_delete(IntPtr p);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeParams_max_categories_get(IntPtr p);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeParams_max_categories_set(IntPtr p, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeParams_max_depth_get(IntPtr p);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeParams_max_depth_set(IntPtr p, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeParams_min_sample_count_get(IntPtr p);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeParams_min_sample_count_set(IntPtr p, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeParams_cv_folds_get(IntPtr p);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeParams_cv_folds_set(IntPtr p, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeParams_use_surrogates_get(IntPtr p);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeParams_use_surrogates_set(IntPtr p, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeParams_use_1se_rule_get(IntPtr p);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeParams_use_1se_rule_set(IntPtr p, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeParams_truncate_pruned_tree_get(IntPtr p);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeParams_truncate_pruned_tree_set(IntPtr p, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvDTreeParams_regression_accuracy_get(IntPtr p);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeParams_regression_accuracy_set(IntPtr p, float value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern float* ml_CvDTreeParams_priors_get(IntPtr p);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeParams_priors_set(IntPtr p, IntPtr value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_new2(IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param, int shared, int addLabels);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeTrainData_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeTrainData_set_data(IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param, int shared, int addLabels, int updateData);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void ml_CvDTreeTrainData_get_vectors(IntPtr obj, IntPtr subsampleIdx, float* values, byte* missing, float* responses, int getClassIdx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_subsample_data(IntPtr obj, IntPtr subsampleIdx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeTrainData_write_params(IntPtr obj, IntPtr fs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeTrainData_read_params(IntPtr obj, IntPtr fs, IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeTrainData_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_get_num_classes(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_get_var_type(IntPtr obj, int vi);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_get_work_var_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_get_class_labels(IntPtr obj, IntPtr n, [In] [Out] int[] labelsBuf);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_get_ord_responses(IntPtr obj, IntPtr n, [In] [Out] float[] valuesBuf, [In] [Out] int[] sampleIndicesBuf);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_get_cv_labels(IntPtr obj, IntPtr n, [In] [Out] int[] labelsBuf);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_get_cat_var_data(IntPtr obj, IntPtr n, int vi, [In] [Out] int[] catValuesBuf);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeTrainData_get_ord_var_data(IntPtr obj, IntPtr n, int vi, [In] [Out] float[] ordValuesBuf, [In] [Out] int[] sortedIndicesBuf, [In] float[][] ordValues, [In] int[][] sortedIndices, [In] [Out] int[] sampleIndicesBuf);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_get_child_buf_idx(IntPtr obj, IntPtr n);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_set_params(IntPtr obj, IntPtr @params);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_new_node(IntPtr obj, IntPtr parent, int count, int storageIdx, int offset);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_new_split_ord(IntPtr obj, int vi, float cmpVal, int splitPoint, int inversed, float quality);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_new_split_cat(IntPtr obj, int vi, float quality);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeTrainData_free_node_data(IntPtr obj, IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeTrainData_free_train_data(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTreeTrainData_free_node(IntPtr obj, IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_sample_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_var_all(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_var_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_max_c_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_ord_var_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_cat_var_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_have_labels(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_have_priors(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_is_classifier(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_buf_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_buf_size(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTreeTrainData_shared(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_cat_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_cat_ofs(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_cat_map(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_counts(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_buf(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_direction(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_split_buf(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_var_idx(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_var_type(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_priors(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_priors_mult(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_tree_storage(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_temp_storage(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_data_root(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_node_heap(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_split_heap(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_cv_heap(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTreeTrainData_nv_heap(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ml_CvDTreeTrainData_rng(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTree_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTree_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTree_train1(IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr @params);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTree_train2(IntPtr obj, IntPtr trainData, IntPtr subsampleIdx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTree_train3(IntPtr obj, IntPtr trainData, IntPtr param);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTree_train_Mat(IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr @params);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTree_predict_CvMat(IntPtr obj, IntPtr sample, IntPtr missingDataMask, int preprocessedInput);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTree_predict_Mat(IntPtr obj, IntPtr sample, IntPtr missingDataMask, int preprocessedInput);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTree_getVarImportance(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTree_get_root(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvDTree_get_pruned_tree_idx(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvDTree_get_data(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvDTree_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CvDTree_read1")]
		public static extern void ml_CvDTree_read(IntPtr obj, IntPtr fs, IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CvDTree_read2")]
		public static extern void ml_CvDTree_read(IntPtr obj, IntPtr fs, IntPtr node, IntPtr data);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CvDTree_write1")]
		public static extern void ml_CvDTree_write(IntPtr obj, IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CvDTree_write2")]
		public static extern void ml_CvDTree_write(IntPtr obj, IntPtr fs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_Boost_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_Boost_new_CvMat(IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_Boost_new_Mat(IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_Boost_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_Boost_train_CvMat(IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param, int update);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_Boost_train_Mat(IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param, int update);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_Boost_predict_CvMat(IntPtr obj, IntPtr sample, IntPtr missing, IntPtr weakResponses, CvSlice slice, int rawMode, int returnSum);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_Boost_predict_Mat(IntPtr obj, IntPtr sample, IntPtr missing, CvSlice slice, int rawMode, int returnSum);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_Boost_prune(IntPtr obj, CvSlice slice);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_Boost_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_Boost_write(IntPtr obj, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_Boost_read(IntPtr obj, IntPtr storage, IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_Boost_get_weak_predictors(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_Boost_get_weights(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_Boost_get_subtree_weights(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_Boost_get_weak_response(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_Boost_get_params(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_BoostParams_sizeof();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_BoostParams_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_BoostParams_new2(int boostType, int weakCount, double weightTrimRate, int maxDepth, int useSurrogates, IntPtr priors);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_BoostParams_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* ml_BoostParams_boost_type(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* ml_BoostParams_weak_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* ml_BoostParams_split_criteria(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern double* ml_BoostParams_weight_trim_rate(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_ANN_MLP_TrainParams_new1(out WCvANN_MLP_TrainParams result);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_ANN_MLP_TrainParams_new2(CvTermCriteria termCrit, int trainMethod, double param1, double param2, out WCvANN_MLP_TrainParams result);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvANN_MLP_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvANN_MLP_new2_CvMat(IntPtr layerSizes, int activFunc, double fParam1, double fParam2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvANN_MLP_new2_Mat(IntPtr layerSizes, int activFunc, double fParam1, double fParam2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvANN_MLP_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvANN_MLP_create_CvMat(IntPtr obj, IntPtr layerSizes, int activFunc, double fParam1, double fParam2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvANN_MLP_create_Mat(IntPtr obj, IntPtr layerSizes, int activFunc, double fParam1, double fParam2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvANN_MLP_train_CvMat(IntPtr obj, IntPtr inputs, IntPtr outputs, IntPtr sampleWeights, IntPtr sampleIdx, WCvANN_MLP_TrainParams param, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvANN_MLP_train_Mat(IntPtr obj, IntPtr inputs, IntPtr outputs, IntPtr sampleWeights, IntPtr sampleIdx, WCvANN_MLP_TrainParams param, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvANN_MLP_predict_CvMat(IntPtr obj, IntPtr inputs, IntPtr outputs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float ml_CvANN_MLP_predict_Mat(IntPtr obj, IntPtr inputs, IntPtr outputs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvANN_MLP_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvANN_MLP_read(IntPtr obj, IntPtr fs, IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvANN_MLP_write(IntPtr obj, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_CvANN_MLP_get_layer_count(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvANN_MLP_get_layer_sizes(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern double* ml_CvANN_MLP_get_weights(IntPtr obj, int layer);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr imgproc_createCLAHE(double clipLimit, CvSize tileGridSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_Ptr_CLAHE_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr imgproc_Ptr_CLAHE_obj(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr imgproc_CLAHE_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_CLAHE_apply(IntPtr obj, IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_CLAHE_setClipLimit(IntPtr obj, double clipLimit);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_CLAHE_getClipLimit(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_CLAHE_setTilesGridSize(IntPtr obj, CvSize tileGridSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize imgproc_CLAHE_getTilesGridSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_CLAHE_collectGarbage(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void photo_inpaint(IntPtr src, IntPtr inpaintMask, IntPtr dst, double inpaintRadius, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void photo_fastNlMeansDenoising(IntPtr src, IntPtr dst, float h, int templateWindowSize, int searchWindowSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void photo_fastNlMeansDenoisingColored(IntPtr src, IntPtr dst, float h, float hColor, int templateWindowSize, int searchWindowSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void photo_fastNlMeansDenoisingMulti(IntPtr[] srcImgs, int srcImgsLength, IntPtr dst, int imgToDenoiseIndex, int temporalWindowSize, float h, int templateWindowSize, int searchWindowSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void photo_fastNlMeansDenoisingColoredMulti(IntPtr[] srcImgs, int srcImgsLength, IntPtr dst, int imgToDenoiseIndex, int temporalWindowSize, float h, float hColor, int templateWindowSize, int searchWindowSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ml_initModule_ml();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ml_CvStatModel_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvStatModel_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvStatModel_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvStatModel_save(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvStatModel_load(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvStatModel_write(IntPtr obj, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void ml_CvStatModel_read(IntPtr obj, IntPtr storage, IntPtr node);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int superres_initModule_superres();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void superres_FrameSource_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void superres_FrameSource_nextFrame(IntPtr obj, IntPtr frame);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void superres_FrameSource_reset(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createFrameSource_Empty();

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr superres_createFrameSource_Video([MarshalAs(UnmanagedType.LPStr)] string fileName);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr superres_createFrameSource_Video_GPU([MarshalAs(UnmanagedType.LPStr)] string fileName);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createFrameSource_Camera(int deviceId);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_Ptr_FrameSource_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void superres_Ptr_FrameSource_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void superres_SuperResolution_setInput(IntPtr obj, IntPtr frameSource);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void superres_SuperResolution_nextFrame(IntPtr obj, IntPtr frame);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void superres_SuperResolution_reset(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void superres_SuperResolution_collectGarbage(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_SuperResolution_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createSuperResolution_BTVL1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createSuperResolution_BTVL1_GPU();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createSuperResolution_BTVL1_OCL();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_Ptr_SuperResolution_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void superres_Ptr_SuperResolution_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void superres_DenseOpticalFlowExt_calc(IntPtr obj, IntPtr frame0, IntPtr frame1, IntPtr flow1, IntPtr flow2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void superres_DenseOpticalFlowExt_collectGarbage(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_DenseOpticalFlowExt_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_Ptr_DenseOpticalFlowExt_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void superres_Ptr_DenseOpticalFlowExt_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createOptFlow_Farneback();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createOptFlow_Farneback_GPU();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createOptFlow_Farneback_OCL();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createOptFlow_Simple();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createOptFlow_DualTVL1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createOptFlow_DualTVL1_GPU();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createOptFlow_DualTVL1_OCL();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createOptFlow_Brox_GPU();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createOptFlow_PyrLK_GPU();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr superres_createOptFlow_PyrLK_OCL();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorExtractor_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorExtractor_compute1(IntPtr obj, IntPtr image, IntPtr keypoint, IntPtr descriptors);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DescriptorExtractor_compute2(IntPtr obj, IntPtr[] images, int imagesSize, IntPtr keypoints, IntPtr[] descriptors, int descriptorsSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_DescriptorExtractor_descriptorSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_DescriptorExtractor_descriptorType(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_DescriptorExtractor_empty(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_DescriptorExtractor_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_DescriptorExtractor_create([MarshalAs(UnmanagedType.LPStr)] string descriptorExtractorType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_DescriptorExtractor_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_DescriptorExtractor_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_BriefDescriptorExtractor_new(int bytes);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_BriefDescriptorExtractor_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_BriefDescriptorExtractor_read(IntPtr obj, IntPtr fn);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_BriefDescriptorExtractor_write(IntPtr obj, IntPtr fs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_BriefDescriptorExtractor_descriptorSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_BriefDescriptorExtractor_descriptorType(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_BriefDescriptorExtractor_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_BriefDescriptorExtractor_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_BriefDescriptorExtractor_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void stitching_Stitcher_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr stitching_Stitcher_createDefault(int tryUseGpu);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double stitching_Stitcher_registrationResol(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void stitching_Stitcher_setRegistrationResol(IntPtr obj, double resolMpx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double stitching_Stitcher_seamEstimationResol(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void stitching_Stitcher_setSeamEstimationResol(IntPtr obj, double resolMpx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double stitching_Stitcher_compositingResol(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void stitching_Stitcher_setCompositingResol(IntPtr obj, double resolMpx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double stitching_Stitcher_panoConfidenceThresh(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void stitching_Stitcher_setPanoConfidenceThresh(IntPtr obj, double confThresh);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_waveCorrection(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void stitching_Stitcher_setWaveCorrection(IntPtr obj, int flag);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_waveCorrectKind(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void stitching_Stitcher_setWaveCorrectKind(IntPtr obj, int kind);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_estimateTransform_InputArray1(IntPtr obj, IntPtr images);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_estimateTransform_InputArray2(IntPtr obj, IntPtr images, IntPtr[] rois, int roisSize1, int[] roisSize2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_estimateTransform_MatArray1(IntPtr obj, IntPtr[] images, int imagesSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_estimateTransform_MatArray2(IntPtr obj, IntPtr[] images, int imagesSize, IntPtr[] rois, int roisSize1, int[] roisSize2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_composePanorama1(IntPtr obj, IntPtr pano);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_composePanorama2_InputArray(IntPtr obj, IntPtr images, IntPtr pano);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_composePanorama2_MatArray(IntPtr obj, IntPtr[] images, int imagesSize, IntPtr pano);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_stitch1_InputArray(IntPtr obj, IntPtr images, IntPtr pano);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_stitch1_MatArray(IntPtr obj, IntPtr[] images, int imagesSize, IntPtr pano);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_stitch2_InputArray(IntPtr obj, IntPtr images, IntPtr[] rois, int roisSize1, int[] roisSize2, IntPtr pano);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stitching_Stitcher_stitch2_MatArray(IntPtr obj, IntPtr[] images, int imagesSize, IntPtr[] rois, int roisSize1, int[] roisSize2, IntPtr pano);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void stitching_Stitcher_component(IntPtr obj, out IntPtr pointer, out int length);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double stitching_Stitcher_workScale(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "features2d_FeatureDetector_detect1")]
		public static extern void features2d_FeatureDetector_detect(IntPtr detector, IntPtr image, IntPtr keypoints, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "features2d_FeatureDetector_detect2")]
		public static extern void features2d_FeatureDetector_detect(IntPtr detector, IntPtr[] images, int imageLength, IntPtr keypoints, IntPtr[] mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_FeatureDetector_empty(IntPtr detector);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr features2d_FeatureDetector_create([MarshalAs(UnmanagedType.LPStr)] string detectorType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Feature2D_compute(IntPtr obj, IntPtr image, IntPtr keypoints, IntPtr descriptors);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr features2d_Feature2D_create([MarshalAs(UnmanagedType.LPStr)] string detectorType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_FeatureDetector_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_FeatureDetector_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_FeatureDetector_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_Feature2D_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_Feature2D_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_BRISK_new(int thresh, int octaves, float patternScale);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_BRISK_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_BRISK_descriptorSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_BRISK_descriptorType(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_BRISK_run1(IntPtr obj, IntPtr image, IntPtr mask, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_BRISK_run2(IntPtr obj, IntPtr image, IntPtr mask, IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_BRISK_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_BRISK_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_BRISK_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_ORB_new(int nFeatures, float scaleFactor, int nlevels, int edgeThreshold, int firstLevel, int wtaK, int scoreType, int patchSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_ORB_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_ORB_descriptorSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_ORB_descriptorType(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_ORB_run1(IntPtr obj, IntPtr image, IntPtr mask, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_ORB_run2(IntPtr obj, IntPtr image, IntPtr mask, IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_ORB_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_ORB_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_ORB_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_FREAK_new(int orientationNormalized, int scaleNormalized, float patternScale, int nOctaves, int[] selectedPairs, int selectedPairsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_FREAK_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_FREAK_descriptorSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int features2d_FREAK_descriptorType(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_FREAK_selectPairs(IntPtr obj, IntPtr[] images, int imagesLength, IntPtr keypoints, double corrThresh, int verbose, IntPtr outVal);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_FREAK_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_FREAK_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_FREAK_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_MSER_new(int delta, int minArea, int maxArea, double maxVariation, double minDiversity, int maxEvolution, double areaThreshold, double minMargin, int edgeBlurSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_MSER_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_MSER_detect(IntPtr obj, IntPtr image, out IntPtr msers, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_MSER_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_MSER_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_MSER_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_StarDetector_new(int maxSize, int responseThreshold, int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_StarDetector_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_StarDetector_detect(IntPtr obj, IntPtr image, out IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_StarDetector_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_StarDetector_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_StarDetector_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_FAST(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_FASTX(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_FastFeatureDetector_new(int threshold, int nonmaxSuppression);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_FastFeatureDetector_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_FastFeatureDetector_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_FastFeatureDetector_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_FastFeatureDetector_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_GFTTDetector_new(int maxCorners, double qualityLevel, double minDistance, int blockSize, int useHarrisDetector, double k);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_GFTTDetector_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_GFTTDetector_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_GFTTDetector_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_GFTTDetector_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_SimpleBlobDetector_new(ref SimpleBlobDetector.WParams parameters);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_SimpleBlobDetector_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_SimpleBlobDetector_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_SimpleBlobDetector_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_DenseFeatureDetector_new(float initFeatureScale, int featureScaleLevels, float featureScaleMul, int initXyStep, int initImgBound, int varyXyStepWithScale, int varyImgBoundWithScale);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_DenseFeatureDetector_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_DenseFeatureDetector_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr features2d_Ptr_DenseFeatureDetector_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_Ptr_DenseFeatureDetector_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_drawKeypoints(IntPtr image, KeyPoint[] keypoints, int keypointsLength, IntPtr outImage, CvScalar color, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_drawMatches1(IntPtr img1, KeyPoint[] keypoints1, int keypoints1Length, IntPtr img2, KeyPoint[] keypoints2, int keypoints2Length, DMatch[] matches1to2, int matches1to2Length, IntPtr outImg, CvScalar matchColor, CvScalar singlePointColor, byte[] matchesMask, int matchesMaskLength, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void features2d_drawMatches2(IntPtr img1, KeyPoint[] keypoints1, int keypoints1Length, IntPtr img2, KeyPoint[] keypoints2, int keypoints2Length, IntPtr[] matches1to2, int matches1to2Size1, int[] matches1to2Size2, IntPtr outImg, CvScalar matchColor, CvScalar singlePointColor, IntPtr[] matchesMask, int matchesMaskSize1, int[] matchesMaskSize2, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_Subdiv2D_new1")]
		public static extern IntPtr imgproc_Subdiv2D_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_Subdiv2D_new2")]
		public static extern IntPtr imgproc_Subdiv2D_new(CvRect rect);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_Subdiv2D_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_Subdiv2D_initDelaunay(IntPtr obj, CvRect rect);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_Subdiv2D_insert1")]
		public static extern int imgproc_Subdiv2D_insert(IntPtr obj, Point2f pt);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_Subdiv2D_insert2")]
		public static extern void imgproc_Subdiv2D_insert(IntPtr obj, [MarshalAs(UnmanagedType.LPArray)] Point2f[] ptArray, int length);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int imgproc_Subdiv2D_locate(IntPtr obj, Point2f pt, out int edge, out int vertex);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int imgproc_Subdiv2D_findNearest(IntPtr obj, Point2f pt, out Point2f nearestPt);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_Subdiv2D_getEdgeList(IntPtr obj, out IntPtr edgeList);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_Subdiv2D_getTriangleList(IntPtr obj, out IntPtr triangleList);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_Subdiv2D_getVoronoiFacetList(IntPtr obj, [MarshalAs(UnmanagedType.LPArray)] int[] idx, int idxCount, out IntPtr facetList, out IntPtr facetCenters);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_Subdiv2D_getVoronoiFacetList(IntPtr obj, IntPtr idx, int idxCount, out IntPtr facetList, out IntPtr facetCenters);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvPoint2D32f imgproc_Subdiv2D_getVertex(IntPtr obj, int vertex, out int firstEdge);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int imgproc_Subdiv2D_getEdge(IntPtr obj, int edge, int nextEdgeType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int imgproc_Subdiv2D_nextEdge(IntPtr obj, int edge);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int imgproc_Subdiv2D_rotateEdge(IntPtr obj, int edge, int rotate);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int imgproc_Subdiv2D_symEdge(IntPtr obj, int edge);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int imgproc_Subdiv2D_edgeOrg(IntPtr obj, int edge, out Point2f orgpt);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int imgproc_Subdiv2D_edgeDst(IntPtr obj, int edge, out Point2f dstpt);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int nonfree_initModule_nonfree();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nonfree_SURF_new1")]
		public static extern IntPtr nonfree_SURF_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nonfree_SURF_new2")]
		public static extern IntPtr nonfree_SURF_new(double hessianThreshold, int nOctaves, int nOctaveLayers, int extended, int upright);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SURF_delete(IntPtr obj);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr nonfree_SURF_createAlgorithm([MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr nonfree_Ptr_SURF_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_Ptr_SURF_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int nonfree_SURF_descriptorSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int nonfree_SURF_descriptorType(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SURF_run1(IntPtr obj, IntPtr img, IntPtr mask, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SURF_run2_vector(IntPtr obj, IntPtr img, IntPtr mask, IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SURF_run2_OutputArray(IntPtr obj, IntPtr img, IntPtr mask, IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr nonfree_SURF_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double nonfree_SURF_hessianThreshold_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int nonfree_SURF_nOctaves_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int nonfree_SURF_nOctaveLayers_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int nonfree_SURF_extended_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int nonfree_SURF_upright_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SURF_hessianThreshold_set(IntPtr obj, double value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SURF_nOctaves_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SURF_nOctaveLayers_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SURF_extended_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SURF_upright_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr nonfree_SIFT_new(int nfeatures, int nOctaveLayers, double contrastThreshold, double edgeThreshold, double sigma);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SIFT_delete(IntPtr obj);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr nonfree_SIFT_createAlgorithm([MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr nonfree_Ptr_SIFT_cast(IntPtr ptrAlgorithm);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr nonfree_Ptr_SIFT_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_Ptr_SIFT_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int nonfree_SIFT_descriptorSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int nonfree_SIFT_descriptorType(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SIFT_run1(IntPtr obj, IntPtr img, IntPtr mask, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SIFT_run2_OutputArray(IntPtr obj, IntPtr img, IntPtr mask, IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr nonfree_SIFT_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SIFT_buildGaussianPyramid(IntPtr obj, IntPtr baseMat, IntPtr pyr, int nOctaves);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SIFT_buildDoGPyramid(IntPtr obj, IntPtr[] pyr, int pyrLength, IntPtr dogPyr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nonfree_SIFT_findScaleSpaceExtrema(IntPtr obj, IntPtr[] gaussPyr, int gaussPyrLength, IntPtr[] dogPyr, int dogPyrLength, IntPtr keypoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr legacy_CvCamShiftTracker_sizeof();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr legacy_CvCamShiftTracker_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void legacy_CvCamShiftTracker_delete(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float legacy_CvCamShiftTracker_get_orientation(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float legacy_CvCamShiftTracker_get_length(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float legacy_CvCamShiftTracker_get_width(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvPoint2D32f legacy_CvCamShiftTracker_get_center(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvRect legacy_CvCamShiftTracker_get_window(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int legacy_CvCamShiftTracker_get_threshold(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int legacy_CvCamShiftTracker_get_hist_dims(IntPtr self, [MarshalAs(UnmanagedType.LPArray)] int[] dims);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int legacy_CvCamShiftTracker_get_min_ch_val(IntPtr self, int channel);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int legacy_CvCamShiftTracker_get_max_ch_val(IntPtr self, int channel);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int legacy_CvCamShiftTracker_set_window(IntPtr self, CvRect window);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int legacy_CvCamShiftTracker_set_threshold(IntPtr self, int threshold);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int legacy_CvCamShiftTracker_set_hist_bin_range(IntPtr self, int dim, int minVal, int maxVal);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int legacy_CvCamShiftTracker_set_hist_dims(IntPtr self, int cDims, [MarshalAs(UnmanagedType.LPArray)] int[] dims);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int legacy_CvCamShiftTracker_set_min_ch_val(IntPtr self, int channel, int val);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int legacy_CvCamShiftTracker_set_max_ch_val(IntPtr self, int channel, int val);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int legacy_CvCamShiftTracker_track_object(IntPtr self, IntPtr curFrame);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int legacy_CvCamShiftTracker_update_histogram(IntPtr self, IntPtr curFrame);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void legacy_CvCamShiftTracker_reset_histogram(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr legacy_CvCamShiftTracker_get_back_project(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float legacy_CvCamShiftTracker_query(IntPtr self, [MarshalAs(UnmanagedType.LPArray)] int[] bin);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int contrib_initModule_contrib();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr contrib_CvAdaptiveSkinDetector_new(int samplingDivider, int morphingMethod);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void contrib_CvAdaptiveSkinDetector_delete(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void contrib_CvAdaptiveSkinDetector_process(IntPtr self, IntPtr inputBgrImage, IntPtr outputHueMask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void contrib_FaceRecognizer_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void contrib_FaceRecognizer_train(IntPtr obj, IntPtr[] src, int srcLength, int[] labels, int labelsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void contrib_FaceRecognizer_update(IntPtr obj, IntPtr[] src, int srcLength, int[] labels, int labelsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int contrib_FaceRecognizer_predict1(IntPtr obj, IntPtr src);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void contrib_FaceRecognizer_predict2(IntPtr obj, IntPtr src, out int label, out double confidence);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void contrib_FaceRecognizer_save1(IntPtr obj, string filename);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void contrib_FaceRecognizer_load1(IntPtr obj, string filename);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void contrib_FaceRecognizer_save2(IntPtr obj, IntPtr fs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void contrib_FaceRecognizer_load2(IntPtr obj, IntPtr fs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr contrib_FaceRecognizer_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr contrib_createEigenFaceRecognizer(int numComponents, double threshold);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr contrib_createFisherFaceRecognizer(int numComponents, double threshold);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr contrib_createLBPHFaceRecognizer(int radius, int neighbors, int gridX, int gridY, double threshold);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr contrib_Ptr_FaceRecognizer_obj(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void contrib_Ptr_FaceRecognizer_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int contrib_chamerMatching(IntPtr img, IntPtr templ, IntPtr results, IntPtr cost, double templScale, int maxMatches, double minMatchDistance, int padX, int padY, int scales, double minScale, double maxScale, double orientationWeight, double truncate);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void contrib_applyColorMap(IntPtr src, IntPtr dst, int colormap);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_initModule_video();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractor_getBackgroundImage(IntPtr self, IntPtr backgroundImage);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractor_operator(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_Ptr_BackgroundSubtractor_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_Ptr_BackgroundSubtractor_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_BackgroundSubtractor_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_BackgroundSubtractorMOG_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_BackgroundSubtractorMOG_new2(int history, int nmixtures, double backgroundRatio, double noiseSigma);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractorMOG_delete(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractorMOG_operator(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractorMOG_initialize(IntPtr self, CvSize frameSize, int frameType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_Ptr_BackgroundSubtractorMOG_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_Ptr_BackgroundSubtractorMOG_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_BackgroundSubtractorMOG_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_BackgroundSubtractorMOG2_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_BackgroundSubtractorMOG2_new2(int history, float varThreshold, int bShadowDetection);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractorMOG2_delete(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractorMOG2_operator(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractorMOG2_getBackgroundImage(IntPtr self, IntPtr backgroundImage);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractorMOG2_initialize(IntPtr self, CvSize frameSize, int frameType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_Ptr_BackgroundSubtractorMOG2_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_Ptr_BackgroundSubtractorMOG2_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_BackgroundSubtractorMOG2_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_BackgroundSubtractorGMG_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractorGMG_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractorGMG_operator(IntPtr obj, IntPtr image, IntPtr fgmask, double learningRate);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractorGMG_release(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractorGMG_initialize(IntPtr obj, CvSize frameSize, double min, double max);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_Ptr_BackgroundSubtractorGMG_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_Ptr_BackgroundSubtractorGMG_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_BackgroundSubtractorGMG_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* video_BackgroundSubtractorGMG_maxFeatures(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern double* video_BackgroundSubtractorGMG_learningRate(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* video_BackgroundSubtractorGMG_numInitializationFrames(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* video_BackgroundSubtractorGMG_quantizationLevels(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern double* video_BackgroundSubtractorGMG_backgroundPrior(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern double* video_BackgroundSubtractorGMG_decisionThreshold(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int* video_BackgroundSubtractorGMG_smoothingRadius(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int video_BackgroundSubtractorGMG_updateBackgroundModel_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_BackgroundSubtractorGMG_updateBackgroundModel_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_updateMotionHistory(IntPtr silhouette, IntPtr mhi, double timestamp, double duration);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_calcMotionGradient(IntPtr mhi, IntPtr mask, IntPtr orientation, double delta1, double delta2, int apertureSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double video_calcGlobalOrientation(IntPtr orientation, IntPtr mask, IntPtr mhi, double timestamp, double duration);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_segmentMotion(IntPtr mhi, IntPtr segmask, IntPtr boundingRects, double timestamp, double segThresh);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvBox2D video_CamShift(IntPtr probImage, ref CvRect window, CvTermCriteria criteria);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int video_meanShift(IntPtr probImage, ref CvRect window, CvTermCriteria criteria);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_new2(int dynamParams, int measureParams, int controlParams, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_KalmanFilter_init(IntPtr obj, int dynamParams, int measureParams, int controlParams, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_KalmanFilter_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_predict(IntPtr obj, IntPtr control);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_correct(IntPtr obj, IntPtr measurement);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_statePre(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_statePost(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_transitionMatrix(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_controlMatrix(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_measurementMatrix(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_processNoiseCov(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_measurementNoiseCov(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_errorCovPre(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_gain(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_KalmanFilter_errorCovPost(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int video_buildOpticalFlowPyramid1(IntPtr img, IntPtr pyramid, CvSize winSize, int maxLevel, int withDerivatives, int pyrBorder, int derivBorder, int tryReuseInputImage);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int video_buildOpticalFlowPyramid2(IntPtr img, IntPtr pyramidVec, CvSize winSize, int maxLevel, int withDerivatives, int pyrBorder, int derivBorder, int tryReuseInputImage);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_calcOpticalFlowPyrLK_InputArray(IntPtr prevImg, IntPtr nextImg, IntPtr prevPts, IntPtr nextPts, IntPtr status, IntPtr err, CvSize winSize, int maxLevel, CvTermCriteria criteria, int flags, double minEigThreshold);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_calcOpticalFlowPyrLK_vector(IntPtr prevImg, IntPtr nextImg, Point2f[] prevPts, int prevPtsSize, IntPtr nextPts, IntPtr status, IntPtr err, CvSize winSize, int maxLevel, CvTermCriteria criteria, int flags, double minEigThreshold);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_calcOpticalFlowFarneback(IntPtr prev, IntPtr next, IntPtr flow, double pyrScale, int levels, int winSize, int iterations, int polyN, double polySigma, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_estimateRigidTransform(IntPtr src, IntPtr dst, int fullAffine);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_calcOpticalFlowSF1(IntPtr from, IntPtr to, IntPtr flow, int layers, int averagingBlockSize, int maxFlow);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_calcOpticalFlowSF2(IntPtr from, IntPtr to, IntPtr flow, int layers, int averagingBlockSize, int maxFlow, double sigmaDist, double sigmaColor, int postprocessWindow, double sigmaDistFix, double sigmaColorFix, double occThr, int upscaleAveragingRadius, double upscaleSigmaDist, double upscaleSigmaColor, double speedUpThr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_DenseOpticalFlow_calc(IntPtr obj, IntPtr i0, IntPtr i1, IntPtr flow);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_DenseOpticalFlow_collectGarbage(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_DenseOpticalFlow_info(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_createOptFlow_DualTVL1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr video_Ptr_DenseOpticalFlow_obj(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void video_Ptr_DenseOpticalFlow_delete(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_setNumThreads(int nthreads);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_getNumThreads();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_getThreadNum();

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_getBuildInformation([MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, uint maxLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern long core_getTickCount();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double core_getTickFrequency();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern long core_getCPUTickCount();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_checkHardwareSupport([MarshalAs(UnmanagedType.I4)] HardwareSupport feature);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_getNumberOfCPUs();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_fastMalloc(IntPtr bufSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_fastFree(IntPtr ptr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_setUseOptimized(int onoff);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_useOptimized();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_cvarrToMat(IntPtr arr, int copyData, int allowND, int coiMode);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_extractImageCOI(IntPtr arr, IntPtr coiimg, int coi);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_insertImageCOI(IntPtr coiimg, IntPtr arr, int coi);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_add(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask, int dtype);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_subtract(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask, int dtype);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_multiply(IntPtr src1, IntPtr src2, IntPtr dst, double scale, int dtype);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_divide1")]
		public static extern void core_divide(double scale, IntPtr src2, IntPtr dst, int dtype);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_divide2")]
		public static extern void core_divide(IntPtr src1, IntPtr src2, IntPtr dst, double scale, int dtype);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_scaleAdd(IntPtr src1, double alpha, IntPtr src2, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_addWeighted(IntPtr src1, double alpha, IntPtr src2, double beta, double gamma, IntPtr dst, int dtype);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_convertScaleAbs(IntPtr src, IntPtr dst, double alpha, double beta);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_LUT(IntPtr src, IntPtr lut, IntPtr dst, int interpolation);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvScalar core_sum(IntPtr src);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_countNonZero(IntPtr src);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_findNonZero(IntPtr src, IntPtr idx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvScalar core_mean(IntPtr src, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_meanStdDev_OutputArray(IntPtr src, IntPtr mean, IntPtr stddev, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_meanStdDev_Scalar(IntPtr src, out CvScalar mean, out CvScalar stddev, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_norm1")]
		public static extern double core_norm(IntPtr src1, int normType, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_norm2")]
		public static extern double core_norm(IntPtr src1, IntPtr src2, int normType, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_batchDistance(IntPtr src1, IntPtr src2, IntPtr dist, int dtype, IntPtr nidx, int normType, int k, IntPtr mask, int update, int crosscheck);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_normalize(IntPtr src, IntPtr dst, double alpha, double beta, int normType, int dtype, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_minMaxLoc1(IntPtr src, out double minVal, out double maxVal);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_minMaxLoc2(IntPtr src, out double minVal, out double maxVal, out CvPoint minLoc, out CvPoint maxLoc, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_minMaxIdx1(IntPtr src, out double minVal, out double maxVal);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_minMaxIdx2(IntPtr src, out double minVal, out double maxVal, out int minIdx, out int maxIdx, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_reduce(IntPtr src, IntPtr dst, int dim, int rtype, int dtype);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_merge([MarshalAs(UnmanagedType.LPArray)] IntPtr[] mv, uint count, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_split(IntPtr src, out IntPtr mv);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_mixChannels(IntPtr[] src, uint nsrcs, IntPtr[] dst, uint ndsts, int[] fromTo, uint npairs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_extractChannel(IntPtr src, IntPtr dst, int coi);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_insertChannel(IntPtr src, IntPtr dst, int coi);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_flip(IntPtr src, IntPtr dst, int flipCode);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_repeat1")]
		public static extern void core_repeat(IntPtr src, int ny, int nx, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_repeat2")]
		public static extern IntPtr core_repeat(IntPtr src, int ny, int nx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_hconcat1")]
		public static extern void core_hconcat([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_hconcat2")]
		public static extern void core_hconcat(IntPtr src1, IntPtr src2, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_vconcat1")]
		public static extern void core_vconcat([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_vconcat2")]
		public static extern void core_vconcat(IntPtr src1, IntPtr src2, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_bitwise_and(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_bitwise_or(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_bitwise_xor(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_bitwise_not(IntPtr src, IntPtr dst, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_absdiff(IntPtr src1, IntPtr src2, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_inRange_InputArray")]
		public static extern void core_inRange(IntPtr src, IntPtr lowerb, IntPtr upperb, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_inRange_Scalar")]
		public static extern void core_inRange(IntPtr src, CvScalar lowerb, CvScalar upperb, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_compare(IntPtr src1, IntPtr src2, IntPtr dst, int cmpop);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_min1(IntPtr src1, IntPtr src2, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_max1(IntPtr src1, IntPtr src2, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_min_MatMat(IntPtr src1, IntPtr src2, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_min_MatDouble(IntPtr src1, double src2, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_max_MatMat(IntPtr src1, IntPtr src2, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_max_MatDouble(IntPtr src1, double src2, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_sqrt(IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_pow_Mat(IntPtr src, double power, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_exp_Mat(IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_log_Mat(IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float core_cubeRoot(float val);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float core_fastAtan2(float y, float x);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_exp_Array(float[] src, float[] dst, int n);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_log_Array(float[] src, float[] dst, int n);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_fastAtan2_Array(float[] y, float[] x, float[] dst, int n, int angleInDegrees);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_magnitude_Array(float[] x, float[] y, float[] dst, int n);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_polarToCart(IntPtr magnitude, IntPtr angle, IntPtr x, IntPtr y, int angleInDegrees);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_cartToPolar(IntPtr x, IntPtr y, IntPtr magnitude, IntPtr angle, int angleInDegrees);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_phase(IntPtr x, IntPtr y, IntPtr angle, int angleInDegrees);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_magnitude_Mat(IntPtr x, IntPtr y, IntPtr magnitude);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_checkRange(IntPtr a, int quiet, out CvPoint pos, double minVal, double maxVal);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_patchNaNs(IntPtr a, double val);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_gemm(IntPtr src1, IntPtr src2, double alpha, IntPtr src3, double gamma, IntPtr dst, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_mulTransposed(IntPtr src, IntPtr dst, int aTa, IntPtr delta, double scale, int dtype);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_transpose(IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_transform(IntPtr src, IntPtr dst, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_perspectiveTransform(IntPtr src, IntPtr dst, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_perspectiveTransform_Mat(IntPtr src, IntPtr dst, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_perspectiveTransform_Point2f(IntPtr src, int srcLength, IntPtr dst, int dstLength, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_perspectiveTransform_Point2d(IntPtr src, int srcLength, IntPtr dst, int dstLength, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_perspectiveTransform_Point3f(IntPtr src, int srcLength, IntPtr dst, int dstLength, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_perspectiveTransform_Point3d(IntPtr src, int srcLength, IntPtr dst, int dstLength, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_completeSymm(IntPtr mtx, int lowerToUpper);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_setIdentity(IntPtr mtx, CvScalar s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double core_determinant(IntPtr mtx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvScalar core_trace(IntPtr mtx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double core_invert(IntPtr src, IntPtr dst, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_solve(IntPtr src1, IntPtr src2, IntPtr dst, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_sort(IntPtr src, IntPtr dst, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_sortIdx(IntPtr src, IntPtr dst, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_solveCubic(IntPtr coeffs, IntPtr roots);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double core_solvePoly(IntPtr coeffs, IntPtr roots, int maxIters);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen1")]
		public static extern int core_eigen(IntPtr src, IntPtr eigenvalues, int lowindex, int highindex);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen2")]
		public static extern int core_eigen(IntPtr src, IntPtr eigenvalues, IntPtr eigenvectors, int lowindex, int highindex);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen3")]
		public static extern int core_eigen(IntPtr src, bool computeEigenvectors, IntPtr eigenvalues, IntPtr eigenvectors);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen3")]
		public static extern void core_calcCovarMatrix_Mat([MarshalAs(UnmanagedType.LPArray)] IntPtr[] samples, int nsamples, IntPtr covar, IntPtr mean, int flags, int ctype);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen3")]
		public static extern void core_calcCovarMatrix_InputArray(IntPtr samples, IntPtr covar, IntPtr mean, int flags, int ctype);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_PCACompute(IntPtr data, IntPtr mean, IntPtr eigenvectors, int maxComponents);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_PCAComputeVar(IntPtr data, IntPtr mean, IntPtr eigenvectors, double retainedVariance);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_PCAProject(IntPtr data, IntPtr mean, IntPtr eigenvectors, IntPtr result);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_PCABackProject(IntPtr data, IntPtr mean, IntPtr eigenvectors, IntPtr result);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SVDecomp(IntPtr src, IntPtr w, IntPtr u, IntPtr vt, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_SVBackSubst(IntPtr w, IntPtr u, IntPtr vt, IntPtr rhs, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double core_Mahalanobis(IntPtr v1, IntPtr v2, IntPtr icovar);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double core_Mahalonobis(IntPtr v1, IntPtr v2, IntPtr icovar);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_dft(IntPtr src, IntPtr dst, int flags, int nonzeroRows);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_idft(IntPtr src, IntPtr dst, int flags, int nonzeroRows);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_dct(IntPtr src, IntPtr dst, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_idct(IntPtr src, IntPtr dst, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_mulSpectrums(IntPtr a, IntPtr b, IntPtr c, int flags, int conjB);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_getOptimalDFTSize(int vecsize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double core_kmeans(IntPtr data, int k, IntPtr bestLabels, CvTermCriteria criteria, int attempts, int flags, IntPtr centers);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong core_theRNG();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_randu_InputArray(IntPtr dst, IntPtr low, IntPtr high);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_randu_Scalar(IntPtr dst, CvScalar low, CvScalar high);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_randn_InputArray(IntPtr dst, IntPtr mean, IntPtr stddev);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_randn_Scalar(IntPtr dst, CvScalar mean, CvScalar stddev);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_randShuffle(IntPtr dst, double iterFactor, ref ulong rng);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_randShuffle(IntPtr dst, double iterFactor, IntPtr rng);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_line(IntPtr img, Point pt1, Point pt2, CvScalar color, int thickness, int lineType, int shift);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_rectangle1")]
		public static extern void core_rectangle(IntPtr img, Point pt1, Point pt2, CvScalar color, int thickness, int lineType, int shift);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_rectangle2")]
		public static extern void core_rectangle(IntPtr img, Rect rect, CvScalar color, int thickness, int lineType, int shift);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_circle(IntPtr img, Point center, int radius, CvScalar color, int thickness, int lineType, int shift);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_ellipse1")]
		public static extern void core_ellipse(IntPtr img, Point center, Size axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness, int lineType, int shift);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_ellipse2")]
		public static extern void core_ellipse(IntPtr img, RotatedRect box, CvScalar color, int thickness, int lineType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_fillConvexPoly(IntPtr img, Point[] pts, int npts, CvScalar color, int lineType, int shift);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_fillPoly(IntPtr img, IntPtr[] pts, int[] npts, int ncontours, CvScalar color, int lineType, int shift, Point offset);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_polylines(IntPtr img, IntPtr[] pts, int[] npts, int ncontours, int isClosed, CvScalar color, int thickness, int lineType, int shift);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_clipLine1")]
		public static extern int core_clipLine(Size imgSize, ref Point pt1, ref Point pt2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_clipLine2")]
		public static extern int core_clipLine(Rect imgRect, ref Point pt1, ref Point pt2);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void core_putText(IntPtr img, [MarshalAs(UnmanagedType.LPStr)] string text, CvPoint org, int fontFace, double fontScale, CvScalar color, int thickness, int lineType, int bottomLeftOrigin);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern CvSize core_getTextSize([MarshalAs(UnmanagedType.LPStr)] string text, int fontFace, double fontScale, int thickness, out int baseLine);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_Rodrigues(IntPtr src, IntPtr dst, IntPtr jacobian);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_Rodrigues_VecToMat(IntPtr vector, IntPtr matrix, IntPtr jacobian);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_Rodrigues_MatToVec(IntPtr vector, IntPtr matrix, IntPtr jacobian);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr calib3d_findHomography_InputArray(IntPtr srcPoints, IntPtr dstPoints, int method, double ransacReprojThreshold, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr calib3d_findHomography_vector(Point2d[] srcPoints, int srcPointsLength, Point2d[] dstPoints, int dstPointsLength, int method, double ransacReprojThreshold, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_RQDecomp3x3_InputArray(IntPtr src, IntPtr mtxR, IntPtr mtxQ, IntPtr qx, IntPtr qy, IntPtr qz, out Vec3d outVal);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_RQDecomp3x3_Mat(IntPtr src, IntPtr mtxR, IntPtr mtxQ, IntPtr qx, IntPtr qy, IntPtr qz, out Vec3d outVal);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_decomposeProjectionMatrix_InputArray(IntPtr projMatrix, IntPtr cameraMatrix, IntPtr rotMatrix, IntPtr transVect, IntPtr rotMatrixX, IntPtr rotMatrixY, IntPtr rotMatrixZ, IntPtr eulerAngles);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_decomposeProjectionMatrix_Mat(IntPtr projMatrix, IntPtr cameraMatrix, IntPtr rotMatrix, IntPtr transVect, IntPtr rotMatrixX, IntPtr rotMatrixY, IntPtr rotMatrixZ, IntPtr eulerAngles);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_matMulDeriv(IntPtr a, IntPtr b, IntPtr dABdA, IntPtr dABdB);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_composeRT_InputArray(IntPtr rvec1, IntPtr tvec1, IntPtr rvec2, IntPtr tvec2, IntPtr rvec3, IntPtr tvec3, IntPtr dr3dr1, IntPtr dr3dt1, IntPtr dr3dr2, IntPtr dr3dt2, IntPtr dt3dr1, IntPtr dt3dt1, IntPtr dt3dr2, IntPtr dt3dt2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_composeRT_Mat(IntPtr rvec1, IntPtr tvec1, IntPtr rvec2, IntPtr tvec2, IntPtr rvec3, IntPtr tvec3, IntPtr dr3dr1, IntPtr dr3dt1, IntPtr dr3dr2, IntPtr dr3dt2, IntPtr dt3dr1, IntPtr dt3dt1, IntPtr dt3dr2, IntPtr dt3dt2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_projectPoints_InputArray(IntPtr objectPoints, IntPtr rvec, IntPtr tvec, IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr imagePoints, IntPtr jacobian, double aspectRatio);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_projectPoints_Mat(IntPtr objectPoints, IntPtr rvec, IntPtr tvec, IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr imagePoints, IntPtr jacobian, double aspectRatio);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_solvePnP_InputArray(IntPtr selfectPoints, IntPtr imagePoints, IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr rvec, IntPtr tvec, int useExtrinsicGuess, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_solvePnP_vector(Point3f[] objectPoints, int objectPointsLength, Point2f[] imagePoints, int imagePointsLength, double[,] cameraMatrix, double[] distCoeffs, int distCoeffsLength, [Out] double[] rvec, [Out] double[] tvec, int useExtrinsicGuess, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_solvePnPRansac_InputArray(IntPtr objectPoints, IntPtr imagePoints, IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr rvec, IntPtr tvec, int useExtrinsicGuess, int iterationsCount, float reprojectionError, int minInliersCount, IntPtr inliers, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_solvePnPRansac_vector(Point3f[] objectPoints, int objectPointsLength, Point2f[] imagePoints, int imagePointsLength, double[,] cameraMatrix, double[] distCoeffs, int distCoeffsLength, [Out] double[] rvec, [Out] double[] tvec, int useExtrinsicGuess, int iterationsCount, float reprojectionError, int minInliersCount, IntPtr inliers, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr calib3d_initCameraMatrix2D_Mat(IntPtr[] objectPoints, int objectPointsLength, IntPtr[] imagePoints, int imagePointsLength, CvSize imageSize, double aspectRatio);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr calib3d_initCameraMatrix2D_array(IntPtr[] objectPoints, int opSize1, int[] opSize2, IntPtr[] imagePoints, int ipSize1, int[] ipSize2, CvSize imageSize, double aspectRatio);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_findChessboardCorners_InputArray(IntPtr image, CvSize patternSize, IntPtr corners, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_findChessboardCorners_vector(IntPtr image, CvSize patternSize, IntPtr corners, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_find4QuadCornerSubpix_InputArray(IntPtr img, IntPtr corners, CvSize regionSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_find4QuadCornerSubpix_vector(IntPtr img, IntPtr corners, CvSize regionSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_drawChessboardCorners_InputArray(IntPtr image, CvSize patternSize, IntPtr corners, int patternWasFound);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_drawChessboardCorners_array(IntPtr image, CvSize patternSize, Point2f[] corners, int cornersLength, int patternWasFound);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_findCirclesGrid_InputArray(IntPtr image, CvSize patternSize, IntPtr centers, int flags, IntPtr blobDetector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_findCirclesGrid_vector(IntPtr image, CvSize patternSize, IntPtr centers, int flags, IntPtr blobDetector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double calib3d_calibrateCamera_InputArray(IntPtr[] objectPoints, int objectPointsSize, IntPtr[] imagePoints, int imagePointsSize, CvSize imageSize, IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr rvecs, IntPtr tvecs, int flags, CvTermCriteria criteria);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double calib3d_calibrateCamera_vector(IntPtr[] objectPoints, int opSize1, int[] opSize2, IntPtr[] imagePoints, int ipSize1, int[] ipSize2, CvSize imageSize, [In] [Out] double[,] cameraMatrix, [In] [Out] double[] distCoeffs, int distCoeffsSize, IntPtr rvecs, IntPtr tvecs, int flags, CvTermCriteria criteria);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_calibrationMatrixValues_InputArray(IntPtr cameraMatrix, CvSize imageSize, double apertureWidth, double apertureHeight, out double fovx, out double fovy, out double focalLength, out Point2d principalPoint, out double aspectRatio);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_calibrationMatrixValues_array(double[,] cameraMatrix, CvSize imageSize, double apertureWidth, double apertureHeight, out double fovx, out double fovy, out double focalLength, out Point2d principalPoint, out double aspectRatio);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double calib3d_stereoCalibrate_InputArray(IntPtr[] objectPoints, int opSize, IntPtr[] imagePoints1, int ip1Size, IntPtr[] imagePoints2, int ip2Size, IntPtr cameraMatrix1, IntPtr distCoeffs1, IntPtr cameraMatrix2, IntPtr distCoeffs2, CvSize imageSize, IntPtr R, IntPtr T, IntPtr E, IntPtr F, CvTermCriteria criteria, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double calib3d_stereoCalibrate_array(IntPtr[] objectPoints, int opSize1, int[] opSizes2, IntPtr[] imagePoints1, int ip1Size1, int[] ip1Sizes2, IntPtr[] imagePoints2, int ip2Size1, int[] ip2Sizes2, [In] [Out] double[,] cameraMatrix1, [In] [Out] double[] distCoeffs1, int dc1Size, [In] [Out] double[,] cameraMatrix2, [In] [Out] double[] distCoeffs2, int dc2Size, CvSize imageSize, IntPtr R, IntPtr T, IntPtr E, IntPtr F, CvTermCriteria criteria, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_stereoRectify_InputArray(IntPtr cameraMatrix1, IntPtr distCoeffs1, IntPtr cameraMatrix2, IntPtr distCoeffs2, CvSize imageSize, IntPtr R, IntPtr T, IntPtr R1, IntPtr R2, IntPtr P1, IntPtr P2, IntPtr Q, int flags, double alpha, CvSize newImageSize, out CvRect validPixROI1, out CvRect validPixROI2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_stereoRectify_array(double[,] cameraMatrix1, double[] distCoeffs1, int dc1Size, double[,] cameraMatrix2, double[] distCoeffs2, int dc2Size, CvSize imageSize, double[,] R, double[] T, double[,] R1, double[,] R2, double[,] P1, double[,] P2, double[,] Q, int flags, double alpha, CvSize newImageSize, out CvRect validPixROI1, out CvRect validPixROI2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_stereoRectifyUncalibrated_InputArray(IntPtr points1, IntPtr points2, IntPtr F, CvSize imgSize, IntPtr H1, IntPtr H2, double threshold);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_stereoRectifyUncalibrated_array(Point2d[] points1, int points1Size, Point2d[] points2, int points2Size, [In] double[,] F, CvSize imgSize, [In] [Out] double[,] H1, [In] [Out] double[,] H2, double threshold);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float calib3d_rectify3Collinear_InputArray(IntPtr cameraMatrix1, IntPtr distCoeffs1, IntPtr cameraMatrix2, IntPtr distCoeffs2, IntPtr cameraMatrix3, IntPtr distCoeffs3, IntPtr[] imgpt1, int imgpt1Size, IntPtr[] imgpt3, int imgpt3Size, CvSize imageSize, IntPtr R12, IntPtr T12, IntPtr R13, IntPtr T13, IntPtr R1, IntPtr R2, IntPtr R3, IntPtr P1, IntPtr P2, IntPtr P3, IntPtr Q, double alpha, CvSize newImgSize, out CvRect roi1, out CvRect roi2, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr calib3d_getOptimalNewCameraMatrix_InputArray(IntPtr cameraMatrix, IntPtr distCoeffs, CvSize imageSize, double alpha, CvSize newImgSize, out CvRect validPixROI, int centerPrincipalPoint);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_getOptimalNewCameraMatrix_array([In] double[,] cameraMatrix, [In] double[] distCoeffs, int distCoeffsSize, CvSize imageSize, double alpha, CvSize newImgSize, out Rect validPixROI, int centerPrincipalPoint, [In] [Out] double[,] outValues);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_convertPointsToHomogeneous_InputArray(IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_convertPointsToHomogeneous_array1([In] Vec2f[] src, [In] [Out] Vec3f[] dst, int length);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_convertPointsToHomogeneous_array2([In] Vec3f[] src, [In] [Out] Vec4f[] dst, int length);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_convertPointsFromHomogeneous_InputArray(IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_convertPointsFromHomogeneous_array1([In] Vec3f[] src, [In] [Out] Vec2f[] dst, int length);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_convertPointsFromHomogeneous_array2([In] Vec4f[] src, [In] [Out] Vec3f[] dst, int length);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_convertPointsHomogeneous(IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr calib3d_findFundamentalMat_InputArray(IntPtr points1, IntPtr points2, int method, double param1, double param2, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr calib3d_findFundamentalMat_array(Point2d[] points1, int points1Size, Point2d[] points2, int points2Size, int method, double param1, double param2, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_computeCorrespondEpilines_InputArray(IntPtr points, int whichImage, IntPtr F, IntPtr lines);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_computeCorrespondEpilines_array2d([In] Point2d[] points, int pointsSize, int whichImage, double[,] F, [In] [Out] Point3f[] lines);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_computeCorrespondEpilines_array3d([In] Point3d[] points, int pointsSize, int whichImage, double[,] F, [In] [Out] Point3f[] lines);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_triangulatePoints_InputArray(IntPtr projMatr1, IntPtr projMatr2, IntPtr projPoints1, IntPtr projPoints2, IntPtr points4D);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_triangulatePoints_array([In] double[,] projMatr1, [In] double[,] projMatr2, [In] Point2d[] projPoints1, int projPoints1Size, [In] Point2d[] projPoints2, int projPoints2Size, [In] [Out] Vec4d[] points4D);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_correctMatches_InputArray(IntPtr F, IntPtr points1, IntPtr points2, IntPtr newPoints1, IntPtr newPoints2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_correctMatches_array(double[,] F, Point2d[] points1, int points1Size, Point2d[] points2, int points2Size, Point2d[] newPoints1, Point2d[] newPoints2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr calib3d_StereoBM_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr calib3d_StereoBM_new2(int preset, int ndisparities, int sadWindowSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoBM_init(IntPtr obj, int preset, int ndisparities, int sadWindowSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoBM_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoBM_compute(IntPtr obj, IntPtr left, IntPtr right, IntPtr disp, int disptype);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr calib3d_StereoSGBM_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr calib3d_StereoSGBM_new2(int minDisparity, int numDisparities, int SADWindowSize, int P1, int P2, int disp12MaxDiff, int preFilterCap, int uniquenessRatio, int speckleWindowSize, int speckleRange, [MarshalAs(UnmanagedType.Bool)] bool fullDP);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_compute(IntPtr obj, IntPtr left, IntPtr right, IntPtr disp);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_StereoSGBM_minDisparity_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_minDisparity_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_StereoSGBM_numberOfDisparities_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_numberOfDisparities_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_StereoSGBM_SADWindowSize_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_SADWindowSize_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_StereoSGBM_preFilterCap_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_preFilterCap_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_StereoSGBM_uniquenessRatio_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_uniquenessRatio_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_StereoSGBM_P1_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_P1_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_StereoSGBM_P2_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_P2_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_StereoSGBM_speckleWindowSize_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_speckleWindowSize_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_StereoSGBM_speckleRange_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_speckleRange_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_StereoSGBM_disp12MaxDiff_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_disp12MaxDiff_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_StereoSGBM_fullDP_get(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_StereoSGBM_fullDP_set(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_filterSpeckles(IntPtr img, double newVal, int maxSpeckleSize, double maxDiff, IntPtr buf);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvRect calib3d_getValidDisparityROI(CvRect roi1, CvRect roi2, int minDisparity, int numberOfDisparities, int SADWindowSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_validateDisparity(IntPtr disparity, IntPtr cost, int minDisparity, int numberOfDisparities, int disp12MaxDisp);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void calib3d_reprojectImageTo3D(IntPtr disparity, IntPtr _3dImage, IntPtr Q, int handleMissingValues, int ddepth);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int calib3d_estimateAffine3D(IntPtr src, IntPtr dst, IntPtr outVal, IntPtr inliers, double ransacThreshold, double confidence);

		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		static NativeMethods()
		{
			LoadLibraries();
			TryPInvoke();
		}

		public static void LoadLibraries(IEnumerable<string> additionalPaths = null)
		{
			if (!OpenCvSharp.NativeMethods.IsUnix())
			{
				string[] additionalPaths2 = EnumerableEx.ToArray(additionalPaths);
				OpenCvSharp.NativeMethods.LoadLibraries(additionalPaths2);
				WindowsLibraryLoader.Instance.LoadLibrary(DllContrib , additionalPaths2);
				WindowsLibraryLoader.Instance.LoadLibrary(DllGpu, additionalPaths2);
				WindowsLibraryLoader.Instance.LoadLibrary(DllOcl, additionalPaths2);
				WindowsLibraryLoader.Instance.LoadLibrary(DllNonfree, additionalPaths2);
				WindowsLibraryLoader.Instance.LoadLibrary(DllStitching, additionalPaths2);
				WindowsLibraryLoader.Instance.LoadLibrary(DllSuperres, additionalPaths2);
				WindowsLibraryLoader.Instance.LoadLibrary(DllVideoStab, additionalPaths2);
				WindowsLibraryLoader.Instance.LoadLibrary(DllExtern, additionalPaths2);
			}
		}

		private static void TryPInvoke()
		{
			if (!tried)
			{
				tried = true;
				try
				{
					Cv.GetTickCount();
					core_Mat_sizeof();
				}
				catch (DllNotFoundException ex)
				{
					OpenCvSharpException ex2 = PInvokeHelper.CreateException(ex);
					try
					{
						Console.WriteLine(ex2.Message);
					}
					catch
					{
					}
					try
					{
					}
					catch
					{
					}
					throw ex2;
				}
				catch (BadImageFormatException ex3)
				{
					OpenCvSharpException ex4 = PInvokeHelper.CreateException(ex3);
					try
					{
						Console.WriteLine(ex4.Message);
					}
					catch
					{
					}
					try
					{
					}
					catch
					{
					}
					throw ex4;
				}
				catch (Exception ex5)
				{
					Exception ex6 = ex5.InnerException ?? ex5;
					try
					{
						Console.WriteLine(ex6.Message);
					}
					catch
					{
					}
					try
					{
					}
					catch
					{
					}
					throw;
				}
			}
		}

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_MatExpr_new1")]
		public static extern IntPtr core_MatExpr_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_MatExpr_new2")]
		public static extern IntPtr core_MatExpr_new(IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_MatExpr_delete(IntPtr expr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_MatExpr_toMat(IntPtr expr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorUnaryMinus_MatExpr(IntPtr e);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorUnaryNot_MatExpr(IntPtr e);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorAdd_MatExprMat(IntPtr e, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorAdd_MatMatExpr(IntPtr m, IntPtr e);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorAdd_MatExprScalar(IntPtr e, CvScalar s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorAdd_ScalarMatExpr(CvScalar s, IntPtr e);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorAdd_MatExprMatExpr(IntPtr e1, IntPtr e2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorSubtract_MatExprMat(IntPtr e, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorSubtract_MatMatExpr(IntPtr m, IntPtr e);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorSubtract_MatExprScalar(IntPtr e, CvScalar s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorSubtract_ScalarMatExpr(CvScalar s, IntPtr e);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorSubtract_MatExprMatExpr(IntPtr e1, IntPtr e2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorMultiply_MatExprMat(IntPtr e, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorMultiply_MatMatExpr(IntPtr m, IntPtr e);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorMultiply_MatExprDouble(IntPtr e, double s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorMultiply_DoubleMatExpr(double s, IntPtr e);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorMultiply_MatExprMatExpr(IntPtr e1, IntPtr e2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorDivide_MatExprMat(IntPtr e, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorDivide_MatMatExpr(IntPtr m, IntPtr e);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorDivide_MatExprDouble(IntPtr e, double s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorDivide_DoubleMatExpr(double s, IntPtr e);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_operatorDivide_MatExprMatExpr(IntPtr e1, IntPtr e2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_MatExpr_row(IntPtr self, int y);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_MatExpr_col(IntPtr self, int x);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_MatExpr_diag1")]
		public static extern IntPtr core_MatExpr_diag(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_MatExpr_diag2")]
		public static extern IntPtr core_MatExpr_diag(IntPtr self, int d);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_MatExpr_submat(IntPtr self, int rowStart, int rowEnd, int colStart, int colEnd);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_MatExpr_cross(IntPtr self, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double core_MatExpr_dot(IntPtr self, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_MatExpr_t(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_MatExpr_inv1")]
		public static extern IntPtr core_MatExpr_inv(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_MatExpr_inv2")]
		public static extern IntPtr core_MatExpr_inv(IntPtr self, int method);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_MatExpr_mul_toMatExpr(IntPtr self, IntPtr e, double scale);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_MatExpr_mul_toMat(IntPtr self, IntPtr m, double scale);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize core_MatExpr_size(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_MatExpr_type(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_abs_MatExpr(IntPtr e);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr objdetect_LatentSvmDetector_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_LatentSvmDetector_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_LatentSvmDetector_clear(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_LatentSvmDetector_empty(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_LatentSvmDetector_load(IntPtr obj, IntPtr[] fileNames, int fileNamesLength, IntPtr[] classNames, int classNamesLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_LatentSvmDetector_detect(IntPtr obj, IntPtr image, IntPtr objectDetections, float overlapThreshold, int numThreads);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_LatentSvmDetector_getClassNames(IntPtr obj, IntPtr outValues);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr objdetect_LatentSvmDetector_getClassCount(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr objdetect_CascadeClassifier_new();

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr objdetect_CascadeClassifier_newFromFile([MarshalAs(UnmanagedType.LPStr)] string fileName);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_CascadeClassifier_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_CascadeClassifier_empty(IntPtr obj);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern int objdetect_CascadeClassifier_load(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fileName);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "objdetect_CascadeClassifier_detectMultiScale1")]
		public static extern void objdetect_CascadeClassifier_detectMultiScale(IntPtr obj, IntPtr image, IntPtr objects, double scaleFactor, int minNeighbors, int flags, CvSize minSize, CvSize maxSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "objdetect_CascadeClassifier_detectMultiScale2")]
		public static extern void objdetect_CascadeClassifier_detectMultiScale(IntPtr obj, IntPtr image, IntPtr objects, IntPtr rejectLevels, IntPtr levelWeights, double scaleFactor, int minNeighbors, int flags, CvSize minSize, CvSize maxSize, int outputRejectLevels);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_CascadeClassifier_isOldFormatCascade(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize objdetect_CascadeClassifier_getOriginalWindowSize(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_CascadeClassifier_getFeatureType(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_CascadeClassifier_setImage(IntPtr obj, IntPtr img);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_HOGDescriptor_sizeof();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr objdetect_HOGDescriptor_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr objdetect_HOGDescriptor_new2(CvSize winSize, CvSize blockSize, CvSize blockStride, CvSize cellSize, int nbins, int derivAperture, double winSigma, [MarshalAs(UnmanagedType.I4)] HistogramNormType histogramNormType, double l2HysThreshold, int gammaCorrection, int nlevels);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr objdetect_HOGDescriptor_new3([MarshalAs(UnmanagedType.LPStr)] string fileName);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_delete(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr objdetect_HOGDescriptor_getDescriptorSize(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_HOGDescriptor_checkDetectorSize(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double objdetect_HOGDescriptor_getWinSigma(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_setSVMDetector(IntPtr self, IntPtr svmdetector);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern bool objdetect_HOGDescriptor_load(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string objname);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void objdetect_HOGDescriptor_save(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string objname);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_compute(IntPtr self, IntPtr img, IntPtr descriptors, Size winStride, Size padding, [In] Point[] locations, int locationsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "objdetect_HOGDescriptor_detect1")]
		public static extern void objdetect_HOGDescriptor_detect(IntPtr self, IntPtr img, IntPtr foundLocations, double hitThreshold, CvSize winStride, CvSize padding, [In] Point[] searchLocations, int searchLocationsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "objdetect_HOGDescriptor_detect2")]
		public static extern void objdetect_HOGDescriptor_detect(IntPtr self, IntPtr img, IntPtr foundLocations, IntPtr weights, double hitThreshold, CvSize winStride, CvSize padding, [In] Point[] searchLocations, int searchLocationsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "objdetect_HOGDescriptor_detectMultiScale1")]
		public static extern void objdetect_HOGDescriptor_detectMultiScale(IntPtr self, IntPtr img, IntPtr foundLocations, double hitThreshold, CvSize winStride, CvSize padding, double scale, int groupThreshold);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "objdetect_HOGDescriptor_detectMultiScale2")]
		public static extern void objdetect_HOGDescriptor_detectMultiScale(IntPtr self, IntPtr img, IntPtr foundLocations, IntPtr foundWeights, double hitThreshold, CvSize winStride, CvSize padding, double scale, int groupThreshold);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_computeGradient(IntPtr self, IntPtr img, IntPtr grad, IntPtr angleOfs, CvSize paddingTL, CvSize paddingBR);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_detectROI(IntPtr obj, IntPtr img, Point[] locations, int locationsLength, IntPtr foundLocations, IntPtr confidences, double hitThreshold, CvSize winStride, CvSize padding);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_detectMultiScaleROI(IntPtr obj, IntPtr img, IntPtr foundLocations, IntPtr roiScales, IntPtr roiLocations, IntPtr roiConfidences, double hitThreshold, int groupThreshold);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void objdetect_HOGDescriptor_readALTModel(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string modelfile);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_groupRectangles(IntPtr obj, IntPtr rectList, IntPtr weights, int groupThreshold, double eps);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize objdetect_HOGDescriptor_winSize_get(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize objdetect_HOGDescriptor_blockSize_get(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize objdetect_HOGDescriptor_blockStride_get(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize objdetect_HOGDescriptor_cellSize_get(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_HOGDescriptor_nbins_get(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_HOGDescriptor_derivAperture_get(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double objdetect_HOGDescriptor_winSigma_get(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_HOGDescriptor_histogramNormType_get(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double objdetect_HOGDescriptor_L2HysThreshold_get(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_HOGDescriptor_gammaCorrection_get(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int objdetect_HOGDescriptor_nlevels_get(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_winSize_set(IntPtr self, CvSize value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_blockSize_set(IntPtr self, CvSize value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_blockStride_set(IntPtr self, CvSize value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_cellSize_set(IntPtr self, CvSize value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_nbins_set(IntPtr self, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_derivAperture_set(IntPtr self, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_winSigma_set(IntPtr self, double value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_histogramNormType_set(IntPtr self, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_L2HysThreshold_set(IntPtr self, double value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_gammaCorrection_set(IntPtr self, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_HOGDescriptor_nlevels_set(IntPtr self, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_groupRectangles1(IntPtr rectList, int groupThreshold, double eps);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_groupRectangles2(IntPtr rectList, IntPtr weights, int groupThreshold, double eps);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_groupRectangles3(IntPtr rectList, int groupThreshold, double eps, IntPtr weights, IntPtr levelWeights);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_groupRectangles4(IntPtr rectList, IntPtr rejectLevels, IntPtr levelWeights, int groupThreshold, double eps);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void objdetect_groupRectangles_meanshift(IntPtr rectList, IntPtr foundWeights, IntPtr foundScales, double detectThreshold, CvSize winDetSize);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void highgui_namedWindow([MarshalAs(UnmanagedType.LPStr)] string winname, int flags);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void highgui_destroyWindow([MarshalAs(UnmanagedType.LPStr)] string winName);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void highgui_destroyAllWindows();

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void highgui_imshow([MarshalAs(UnmanagedType.LPStr)] string winname, IntPtr mat);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr highgui_imread(string filename, int flags);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern int highgui_imwrite([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr img, [In] int[] @params, int paramsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr highgui_imdecode_Mat(IntPtr buf, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr highgui_imdecode_vector(byte[] buf, IntPtr bufLength, int flags);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void highgui_imencode_CvMat([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr img, out IntPtr buf, [In] int[] @params, int paramsLength);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern int highgui_imencode_vector([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr img, IntPtr buf, [In] int[] @params, int paramsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int highgui_startWindowThread();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int highgui_waitKey(int delay);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void highgui_resizeWindow([MarshalAs(UnmanagedType.LPStr)] string winName, int width, int height);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void highgui_moveWindow([MarshalAs(UnmanagedType.LPStr)] string winName, int x, int y);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void highgui_setWindowProperty([MarshalAs(UnmanagedType.LPStr)] string winName, int propId, double propValue);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern double highgui_getWindowProperty([MarshalAs(UnmanagedType.LPStr)] string winName, int propId);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void highgui_setMouseCallback(string winName, [MarshalAs(UnmanagedType.FunctionPtr)] CvMouseCallback onMouse, IntPtr userData);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern int highgui_createTrackbar([MarshalAs(UnmanagedType.LPStr)] string trackbarName, [MarshalAs(UnmanagedType.LPStr)] string winName, ref int value, int count, [MarshalAs(UnmanagedType.FunctionPtr)] CvTrackbarCallback2 onChange, IntPtr userData);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern int highgui_getTrackbarPos([MarshalAs(UnmanagedType.LPStr)] string trackbarName, [MarshalAs(UnmanagedType.LPStr)] string winName);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void highgui_setTrackbarPos(string trackbarName, string winName, int pos);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr highgui_VideoCapture_new();

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr highgui_VideoCapture_new_fromFile([MarshalAs(UnmanagedType.LPStr)] string fileName);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr highgui_VideoCapture_new_fromDevice(int device);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void highgui_VideoCapture_delete(IntPtr obj);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void highgui_VideoCapture_open_fromFile(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fileName);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void highgui_VideoCapture_open_fromDevice(IntPtr obj, int device);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int highgui_VideoCapture_isOpened(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void highgui_VideoCapture_release(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int highgui_VideoCapture_grab(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int highgui_VideoCapture_retrieve(IntPtr obj, IntPtr image, int channel);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int highgui_VideoCapture_read(IntPtr obj, IntPtr image);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int highgui_VideoCapture_set(IntPtr obj, int propId, double value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double highgui_VideoCapture_get(IntPtr obj, int propId);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr highgui_VideoWriter_new1();

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr highgui_VideoWriter_new2([MarshalAs(UnmanagedType.LPStr)] string fileName, int fourcc, double fps, CvSize frameSize, int isColor);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void highgui_VideoWriter_delete(IntPtr obj);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern int highgui_VideoWriter_open(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fileName, int fourcc, double fps, CvSize frameSize, int isColor);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int highgui_VideoWriter_isOpened(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void highgui_VideoWriter_release(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void highgui_VideoWriter_write(IntPtr obj, IntPtr image);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void highgui_cvConvertImage_Mat(IntPtr src, IntPtr dst, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr imgproc_getGaborKernel(Size ksize, double sigma, double theta, double lambd, double gamma, double psi, int ktype);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr imgproc_getStructuringElement(int shape, Size ksize, Point anchor);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_copyMakeBorder(IntPtr src, IntPtr dst, int top, int bottom, int left, int right, int borderType, CvScalar value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_medianBlur(IntPtr src, IntPtr dst, int ksize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_GaussianBlur(IntPtr src, IntPtr dst, CvSize ksize, double sigmaX, double sigmaY, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_bilateralFilter(IntPtr src, IntPtr dst, int d, double sigmaColor, double sigmaSpace, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_adaptiveBilateralFilter(IntPtr src, IntPtr dst, Size ksize, double sigmaSpace, double maxSigmaColor, CvPoint anchor, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_boxFilter(IntPtr src, IntPtr dst, int ddepth, Size ksize, Point anchor, int normalize, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_blur(IntPtr src, IntPtr dst, Size ksize, Point anchor, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_filter2D(IntPtr src, IntPtr dst, int ddepth, IntPtr kernel, Point anchor, double delta, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_sepFilter2D(IntPtr src, IntPtr dst, int ddepth, IntPtr kernelX, IntPtr kernelY, Point anchor, double delta, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_Sobel(IntPtr src, IntPtr dst, int ddepth, int dx, int dy, int ksize, double scale, double delta, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_Scharr(IntPtr src, IntPtr dst, int ddepth, int dx, int dy, double scale, double delta, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_Laplacian(IntPtr src, IntPtr dst, int ddepth, int ksize, double scale, double delta, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_Canny(IntPtr src, IntPtr edges, double threshold1, double threshold2, int apertureSize, int L2gradient);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_eigen2x2([In] float[,] a, [Out] float[,] e, int n);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_cornerEigenValsAndVecs(IntPtr src, IntPtr dst, int blockSize, int ksize, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_preCornerDetect(IntPtr src, IntPtr dst, int ksize, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_cornerSubPix(IntPtr image, IntPtr corners, Size winSize, Size zeroZone, CvTermCriteria criteria);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_goodFeaturesToTrack(IntPtr src, IntPtr corners, int maxCorners, double qualityLevel, double minDistance, IntPtr mask, int blockSize, int useHarrisDetector, double k);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_HoughLines(IntPtr src, IntPtr lines, double rho, double theta, int threshold, double srn, double stn);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_HoughLinesP(IntPtr src, IntPtr lines, double rho, double theta, int threshold, double minLineLength, double maxLineG);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_HoughCircles(IntPtr src, IntPtr circles, int method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_erode(IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations, int borderType, CvScalar borderValue);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_dilate(IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations, int borderType, CvScalar borderValue);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_morphologyEx(IntPtr src, IntPtr dst, int op, IntPtr kernel, Point anchor, int iterations, int borderType, CvScalar borderValue);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_resize(IntPtr src, IntPtr dst, CvSize dsize, double fx, double fy, int interpolation);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_warpAffine(IntPtr src, IntPtr dst, IntPtr m, CvSize dsize, int flags, int borderMode, CvScalar borderValue);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_warpPerspective_MisInputArray(IntPtr src, IntPtr dst, IntPtr m, CvSize dsize, int flags, int borderMode, CvScalar borderValue);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_warpPerspective_MisArray(IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.LPArray)] float[,] m, int mRow, int mCol, CvSize dsize, int flags, int borderMode, CvScalar borderValue);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_remap(IntPtr src, IntPtr dst, IntPtr map1, IntPtr map2, int interpolation, int borderMode, CvScalar borderValue);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_convertMaps(IntPtr map1, IntPtr map2, IntPtr dstmap1, IntPtr dstmap2, int dstmap1Type, int nninterpolation);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr imgproc_getRotationMatrix2D(CvPoint2D32f center, double angle, double scale);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_invertAffineTransform(IntPtr M, IntPtr iM);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_getPerspectiveTransform1")]
		public static extern IntPtr imgproc_getPerspectiveTransform(Point2f[] src, Point2f[] dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_getPerspectiveTransform1")]
		public static extern IntPtr imgproc_getPerspectiveTransform(IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_getAffineTransform1")]
		public static extern IntPtr imgproc_getAffineTransform(Point2f[] src, Point2f[] dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_getAffineTransform2")]
		public static extern IntPtr imgproc_getAffineTransform(IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_getRectSubPix(IntPtr image, Size patchSize, Point2f center, IntPtr patch, int patchType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_integral1")]
		public static extern void imgproc_integral(IntPtr src, IntPtr sum, int sdepth);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_integral2")]
		public static extern void imgproc_integral(IntPtr src, IntPtr sum, IntPtr sqsum, int sdepth);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_integral3")]
		public static extern void imgproc_integral(IntPtr src, IntPtr sum, IntPtr sqsum, IntPtr tilted, int sdepth);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_accumulate(IntPtr src, IntPtr dst, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_accumulateSquare(IntPtr src, IntPtr dst, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_accumulateProduct(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_accumulateWeighted(IntPtr src, IntPtr dst, double alpha, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_PSNR(IntPtr src1, IntPtr src2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvPoint2D64f imgproc_phaseCorrelate(IntPtr src1, IntPtr src2, IntPtr window);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvPoint2D64f imgproc_phaseCorrelateRes(IntPtr src1, IntPtr src2, IntPtr window, out double response);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_createHanningWindow(IntPtr dst, CvSize winSize, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_threshold(IntPtr src, IntPtr dst, double thresh, double maxval, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_adaptiveThreshold(IntPtr src, IntPtr dst, double maxValue, int adaptiveMethod, int thresholdType, int blockSize, double c);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_pyrDown(IntPtr src, IntPtr dst, CvSize dstsize, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_pyrUp(IntPtr src, IntPtr dst, CvSize dstsize, int borderType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_undistort(IntPtr src, IntPtr dst, IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr newCameraMatrix);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_initUndistortRectifyMap(IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr r, IntPtr newCameraMatrix, CvSize size, int m1Type, IntPtr map1, IntPtr map2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float imgproc_initWideAngleProjMap(IntPtr cameraMatrix, IntPtr distCoeffs, CvSize imageSize, int destImageWidth, int m1Type, IntPtr map1, IntPtr map2, int projType, double alpha);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr imgproc_getDefaultNewCameraMatrix(IntPtr cameraMatrix, CvSize imgSize, int centerPrincipalPoint);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_undistortPoints(IntPtr src, IntPtr dst, IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr r, IntPtr p);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_calcHist1(IntPtr[] images, int nimages, int[] channels, IntPtr mask, IntPtr hist, int dims, int[] histSize, IntPtr[] ranges, int uniform, int accumulate);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_calcBackProject(IntPtr[] images, int nimages, int[] channels, IntPtr hist, IntPtr backProject, IntPtr[] ranges, int uniform);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_compareHist1(IntPtr h1, IntPtr h2, int method);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_equalizeHist(IntPtr src, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float imgproc_EMD(IntPtr signature1, IntPtr signature2, int distType, IntPtr cost, out float lowerBound, IntPtr flow);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_watershed(IntPtr image, IntPtr markers);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_pyrMeanShiftFiltering(IntPtr src, IntPtr dst, double sp, double sr, int maxLevel, CvTermCriteria termcrit);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_grabCut(IntPtr img, IntPtr mask, CvRect rect, IntPtr bgdModel, IntPtr fgdModel, int iterCount, int mode);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_distanceTransformWithLabels(IntPtr src, IntPtr dst, IntPtr labels, int distanceType, int maskSize, int labelType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_distanceTransform(IntPtr src, IntPtr dst, int distanceType, int maskSize);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_floodFill1")]
		public static extern int imgproc_floodFill(IntPtr image, CvPoint seedPoint, CvScalar newVal, out CvRect rect, CvScalar loDiff, CvScalar upDiff, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_floodFill2")]
		public static extern int imgproc_floodFill(IntPtr image, IntPtr mask, CvPoint seedPoint, CvScalar newVal, out CvRect rect, CvScalar loDiff, CvScalar upDiff, int flags);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_cvtColor(IntPtr src, IntPtr dst, int code, int dstCn);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern WCvMoments imgproc_moments(IntPtr arr, int binaryImage);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_matchTemplate(IntPtr image, IntPtr templ, IntPtr result, int method);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_findContours1_vector(IntPtr image, out IntPtr contours, out IntPtr hierarchy, int mode, int method, CvPoint offset);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_findContours1_OutputArray(IntPtr image, out IntPtr contours, IntPtr hierarchy, int mode, int method, CvPoint offset);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_findContours2_vector(IntPtr image, out IntPtr contours, int mode, int method, CvPoint offset);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_findContours2_OutputArray(IntPtr image, out IntPtr contours, int mode, int method, CvPoint offset);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_drawContours_vector(IntPtr image, IntPtr[] contours, int contoursSize1, int[] contoursSize2, int contourIdx, CvScalar color, int thickness, int lineType, Vec4i[] hierarchy, int hiearchyLength, int maxLevel, CvPoint offset);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_drawContours_vector(IntPtr image, IntPtr[] contours, int contoursSize1, int[] contoursSize2, int contourIdx, CvScalar color, int thickness, int lineType, IntPtr hierarchy, int hiearchyLength, int maxLevel, CvPoint offset);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_drawContours_InputArray(IntPtr image, IntPtr[] contours, int contoursLength, int contourIdx, CvScalar color, int thickness, int lineType, IntPtr hierarchy, int maxLevel, CvPoint offset);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_approxPolyDP_InputArray(IntPtr curve, IntPtr approxCurve, double epsilon, int closed);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_approxPolyDP_Point(Point[] curve, int curveLength, out IntPtr approxCurve, double epsilon, int closed);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_approxPolyDP_Point2f(Point2f[] curve, int curveLength, out IntPtr approxCurve, double epsilon, int closed);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_arcLength_InputArray(IntPtr curve, int closed);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_arcLength_Point(Point[] curve, int curveLength, int closed);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_arcLength_Point2f(Point2f[] curve, int curveLength, int closed);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvRect imgproc_boundingRect_InputArray(IntPtr curve);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvRect imgproc_boundingRect_Point(Point[] curve, int curveLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvRect imgproc_boundingRect_Point2f(Point2f[] curve, int curveLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_contourArea_InputArray(IntPtr contour, int oriented);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_contourArea_Point(Point[] contour, int contourLength, int oriented);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_contourArea_Point2f(Point2f[] contour, int contourLength, int oriented);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvBox2D imgproc_minAreaRect_InputArray(IntPtr points);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvBox2D imgproc_minAreaRect_Point(Point[] points, int pointsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvBox2D imgproc_minAreaRect_Point2f(Point2f[] points, int pointsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_minEnclosingCircle_InputArray(IntPtr points, out Point2f center, out float radius);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_minEnclosingCircle_Point(Point[] points, int pointsLength, out Point2f center, out float radius);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_minEnclosingCircle_Point2f(Point2f[] points, int pointsLength, out Point2f center, out float radius);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_matchShapes_InputArray(IntPtr contour1, IntPtr contour2, int method, double parameter);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_matchShapes_Point(Point[] contour1, int contour1Length, Point[] contour2, int contour2Length, int method, double parameter);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_convexHull_InputArray(IntPtr points, IntPtr hull, int clockwise, int returnPoints);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_convexHull_Point_ReturnsPoints(Point[] points, int pointsLength, out IntPtr hull, int clockwise);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_convexHull_Point2f_ReturnsPoints(Point2f[] points, int pointsLength, out IntPtr hull, int clockwise);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_convexHull_Point_ReturnsIndices(Point[] points, int pointsLength, out IntPtr hull, int clockwise);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_convexHull_Point2f_ReturnsIndices(Point2f[] points, int pointsLength, out IntPtr hull, int clockwise);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_convexityDefects_InputArray(IntPtr contour, IntPtr convexHull, IntPtr convexityDefects);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_convexityDefects_Point(Point[] contour, int contourLength, int[] convexHull, int convexHullLength, out IntPtr convexityDefects);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_convexityDefects_Point2f(Point2f[] contour, int contourLength, int[] convexHull, int convexHullLength, out IntPtr convexityDefects);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int imgproc_isContourConvex_InputArray(IntPtr contour);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int imgproc_isContourConvex_Point(Point[] contour, int contourLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int imgproc_isContourConvex_Point2f(Point2f[] contour, int contourLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float imgproc_intersectConvexConvex_InputArray(IntPtr p1, IntPtr p2, IntPtr p12, int handleNested);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float imgproc_intersectConvexConvex_Point(Point[] p1, int p1Length, Point[] p2, int p2Length, out IntPtr p12, int handleNested);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern float imgproc_intersectConvexConvex_Point2f(Point2f[] p1, int p1Length, Point2f[] p2, int p2Length, out IntPtr p12, int handleNested);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvBox2D imgproc_fitEllipse_InputArray(IntPtr points);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvBox2D imgproc_fitEllipse_Point(Point[] points, int pointsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvBox2D imgproc_fitEllipse_Point2f(Point2f[] points, int pointsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_fitLine_InputArray(IntPtr points, IntPtr line, int distType, double param, double reps, double aeps);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_fitLine_Point(Point[] points, int pointsLength, [In] [Out] float[] line, int distType, double param, double reps, double aeps);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_fitLine_Point2f(Point2f[] points, int pointsLength, [In] [Out] float[] line, int distType, double param, double reps, double aeps);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_fitLine_Point3i(Point3i[] points, int pointsLength, [In] [Out] float[] line, int distType, double param, double reps, double aeps);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void imgproc_fitLine_Point3f(Point3f[] points, int pointsLength, [In] [Out] float[] line, int distType, double param, double reps, double aeps);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_pointPolygonTest_InputArray(IntPtr contour, Point2f pt, int measureDist);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_pointPolygonTest_Point(Point[] contour, int contourLength, Point2f pt, int measureDist);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double imgproc_pointPolygonTest_Point2f(Point2f[] contour, int contourLength, Point2f pt, int measureDist);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong core_Mat_sizeof();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new2(int rows, int cols, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new3(int rows, int cols, int type, CvScalar scalar);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new4(IntPtr mat, Range rowRange, Range colRange);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new5(IntPtr mat, Range rowRange);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new6(IntPtr mat, [MarshalAs(UnmanagedType.LPArray)] Range[] rowRange);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new7(IntPtr mat, CvRect roi);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new8(int rows, int cols, int type, IntPtr data, IntPtr step);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new9(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, int type, IntPtr data, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] steps);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new9(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, int type, IntPtr data, IntPtr steps);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new10(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new11(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, int type, CvScalar s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new_FromIplImage(IntPtr img, int copyData);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_new_FromCvMat(IntPtr mat, int copyData);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_release(IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_delete(IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_adjustROI(IntPtr nativeObj, int dtop, int dbottom, int dleft, int dright);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_assignTo1")]
		public static extern void core_Mat_assignTo(IntPtr self, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_assignTo2")]
		public static extern void core_Mat_assignTo(IntPtr self, IntPtr m, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_channels(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_checkVector1")]
		public static extern int core_Mat_checkVector(IntPtr self, int elemChannels);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_checkVector2")]
		public static extern int core_Mat_checkVector(IntPtr self, int elemChannels, int depth);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_checkVector3")]
		public static extern int core_Mat_checkVector(IntPtr self, int elemChannels, int depth, int requireContinuous);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_clone(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_col_toMat(IntPtr self, int x);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_col_toMatExpr(IntPtr self, int x);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_cols(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_colRange_toMat(IntPtr self, int startCol, int endCol);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_colRange_toMatExpr(IntPtr self, int startCol, int endCol);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_dims(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_convertTo(IntPtr self, IntPtr m, int rtype, double alpha, double beta);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_copyTo(IntPtr self, IntPtr m, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_create1")]
		public static extern void core_Mat_create(IntPtr self, int rows, int cols, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_create2")]
		public static extern void core_Mat_create(IntPtr self, int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_cross(IntPtr self, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_refcount(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern byte* core_Mat_data(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_datastart(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_dataend(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_datalimit(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_depth(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_diag1")]
		public static extern IntPtr core_Mat_diag(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_diag2")]
		public static extern IntPtr core_Mat_diag(IntPtr self, int d);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern double core_Mat_dot(IntPtr self, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong core_Mat_elemSize(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong core_Mat_elemSize1(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_empty(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_eye(int rows, int cols, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_inv1")]
		public static extern IntPtr core_Mat_inv(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_inv2")]
		public static extern IntPtr core_Mat_inv(IntPtr self, int method);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_isContinuous(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_isSubmatrix(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_locateROI(IntPtr self, out CvSize wholeSize, out CvPoint ofs);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_mul1")]
		public static extern IntPtr core_Mat_mul(IntPtr self, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_mul2")]
		public static extern IntPtr core_Mat_mul(IntPtr self, IntPtr m, double scale);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_ones1")]
		public static extern IntPtr core_Mat_ones(int rows, int cols, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_ones2")]
		public static extern IntPtr core_Mat_ones(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sz, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_reshape1")]
		public static extern IntPtr core_Mat_reshape(IntPtr self, int cn);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_reshape2")]
		public static extern IntPtr core_Mat_reshape(IntPtr self, int cn, int rows);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_reshape3")]
		public static extern IntPtr core_Mat_reshape(IntPtr self, int cn, int newndims, [MarshalAs(UnmanagedType.LPArray)] int[] newsz);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_rows(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_row_toMat(IntPtr self, int y);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_row_toMatExpr(IntPtr self, int y);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_rowRange_toMat(IntPtr self, int startRow, int endRow);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_rowRange_toMatExpr(IntPtr self, int startRow, int endRow);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_setTo_Scalar")]
		public static extern IntPtr core_Mat_setTo(IntPtr self, CvScalar value, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_setTo_InputArray")]
		public static extern IntPtr core_Mat_setTo(IntPtr self, IntPtr value, IntPtr mask);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern CvSize core_Mat_size(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_sizeAt(IntPtr self, int i);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_step11")]
		public static extern ulong core_Mat_step1(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_step12")]
		public static extern ulong core_Mat_step1(IntPtr self, int i);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern long core_Mat_step(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong core_Mat_stepAt(IntPtr self, int i);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_subMat1")]
		public static extern IntPtr core_Mat_subMat(IntPtr self, int rowStart, int rowEnd, int colStart, int colEnd);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_subMat2")]
		public static extern IntPtr core_Mat_subMat(IntPtr self, int nRanges, CvSlice[] ranges);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_t(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong core_Mat_total(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_type(IntPtr self);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_zeros1")]
		public static extern IntPtr core_Mat_zeros(int rows, int cols, int type);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_zeros2")]
		public static extern IntPtr core_Mat_zeros(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sz, int type);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public unsafe static extern sbyte* core_Mat_dump(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string format);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void core_Mat_dump_delete(sbyte* buf);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_ptr1d(IntPtr self, int i0);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_ptr2d(IntPtr self, int i0, int i1);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_ptr3d(IntPtr self, int i0, int i1, int i2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_ptrnd(IntPtr self, [MarshalAs(UnmanagedType.LPArray)] int[] idx);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_assignment_FromMat(IntPtr self, IntPtr newMat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_assignment_FromMatExpr(IntPtr self, IntPtr newMatExpr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_assignment_FromScalar(IntPtr self, CvScalar scalar);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_IplImage(IntPtr self, IntPtr outImage);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_IplImage_alignment(IntPtr self, out IntPtr outImage);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_CvMat(IntPtr self, IntPtr outMat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorUnaryMinus(IntPtr mat);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorAdd_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorAdd_MatScalar(IntPtr a, CvScalar s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorAdd_ScalarMat(CvScalar s, IntPtr a);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorMinus_Mat(IntPtr a);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorSubtract_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorSubtract_MatScalar(IntPtr a, CvScalar s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorSubtract_ScalarMat(CvScalar s, IntPtr a);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorMultiply_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorMultiply_MatDouble(IntPtr a, double s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorMultiply_DoubleMat(double s, IntPtr a);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorDivide_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorDivide_MatDouble(IntPtr a, double s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorDivide_DoubleMat(double s, IntPtr a);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorAnd_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorAnd_MatDouble(IntPtr a, double s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorAnd_DoubleMat(double s, IntPtr a);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorOr_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorOr_MatDouble(IntPtr a, double s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorOr_DoubleMat(double s, IntPtr a);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorXor_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorXor_MatDouble(IntPtr a, double s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorXor_DoubleMat(double s, IntPtr a);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorNot(IntPtr a);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorLT_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorLT_DoubleMat(double a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorLT_MatDouble(IntPtr a, double b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorLE_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorLE_DoubleMat(double a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorLE_MatDouble(IntPtr a, double b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorGT_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorGT_DoubleMat(double a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorGT_MatDouble(IntPtr a, double b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorGE_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorGE_DoubleMat(double a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorGE_MatDouble(IntPtr a, double b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorEQ_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorEQ_DoubleMat(double a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorEQ_MatDouble(IntPtr a, double b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorNE_MatMat(IntPtr a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorNE_DoubleMat(double a, IntPtr b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_Mat_operatorNE_MatDouble(IntPtr a, double b);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr core_abs_Mat(IntPtr e);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetB(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] byte[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetB(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] byte[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetS(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] short[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetS(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] short[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetS(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] ushort[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetS(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] ushort[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetI(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] int[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetI(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] int[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetF(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] float[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetF(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] float[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetD(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] double[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetD(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] double[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetVec3b(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Vec3b[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetVec3b(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Vec3b[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetVec3d(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Vec3d[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetVec3d(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Vec3d[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetVec4f(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Vec4f[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetVec4f(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Vec4f[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetVec6f(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Vec6f[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetVec6f(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Vec6f[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetVec4i(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Vec4i[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetVec4i(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Vec4i[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetPoint(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Point[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetPoint(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Point[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetPoint2f(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Point2f[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetPoint2f(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Point2f[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetPoint2d(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Point2d[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetPoint2d(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Point2d[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetPoint3i(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Point3i[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetPoint3i(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Point3i[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetPoint3f(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Point3f[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetPoint3f(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Point3f[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetPoint3d(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Point3d[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetPoint3d(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Point3d[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetRect(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Rect[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nSetRect(IntPtr obj, int row, int col, [In] [MarshalAs(UnmanagedType.LPArray)] Rect[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetB(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] byte[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetB(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] byte[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetS(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] short[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetS(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] short[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetS(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] ushort[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetS(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] ushort[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetI(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] int[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetI(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] int[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetF(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] float[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetF(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] float[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetD(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] double[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetD(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] double[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetVec3b(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Vec3b[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetVec3b(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Vec3b[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetVec3d(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Vec3d[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetVec3d(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Vec3d[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetVec4f(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Vec4f[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetVec4f(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Vec4f[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetVec6f(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Vec6f[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetVec6f(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Vec6f[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetVec4i(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Vec4i[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetVec4i(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Vec4i[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetPoint(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Point[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetPoint(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Point[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetPoint2f(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Point2f[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetPoint2f(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Point2f[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetPoint2d(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Point2d[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetPoint2d(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Point2d[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetPoint3i(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Point3i[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetPoint3i(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Point3i[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetPoint3f(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Point3f[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetPoint3f(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Point3f[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetPoint3d(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Point3d[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetPoint3d(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Point3d[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetRect(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Rect[] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern int core_Mat_nGetRect(IntPtr obj, int row, int col, [In] [Out] [MarshalAs(UnmanagedType.LPArray)] Rect[,] vals, int valsLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Mat(IntPtr self, IntPtr m);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_char(IntPtr self, sbyte v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_uchar(IntPtr self, byte v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_short(IntPtr self, short v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_ushort(IntPtr self, ushort v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_int(IntPtr self, int v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_float(IntPtr self, float v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_double(IntPtr self, double v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec2b(IntPtr self, Vec2b v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec3b(IntPtr self, Vec3b v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec4b(IntPtr self, Vec4b v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec6b(IntPtr self, Vec6b v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec2s(IntPtr self, Vec2s v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec3s(IntPtr self, Vec3s v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec4s(IntPtr self, Vec4s v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec6s(IntPtr self, Vec6s v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec2w(IntPtr self, Vec2w v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec3w(IntPtr self, Vec3w v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec4w(IntPtr self, Vec4w v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec6w(IntPtr self, Vec6w v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec2i(IntPtr self, Vec2i v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec3i(IntPtr self, Vec3i v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec4i(IntPtr self, Vec4i v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec6i(IntPtr self, Vec6i v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec2f(IntPtr self, Vec2f v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec3f(IntPtr self, Vec3f v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec4f(IntPtr self, Vec4f v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec6f(IntPtr self, Vec6f v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec2d(IntPtr self, Vec2d v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec3d(IntPtr self, Vec3d v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Vec6d(IntPtr self, Vec6d v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Point(IntPtr self, Point v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Point2f(IntPtr self, Point2f v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Point2d(IntPtr self, Point2d v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Point3i(IntPtr self, Point3i v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Point3f(IntPtr self, Point3f v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Point3d(IntPtr self, Point3d v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Size(IntPtr self, Size v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Size2f(IntPtr self, Size2f v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_push_back_Rect(IntPtr self, Rect v);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_reserve(IntPtr obj, IntPtr sz);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_resize1(IntPtr obj, IntPtr sz);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_resize2(IntPtr obj, IntPtr sz, CvScalar s);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void core_Mat_pop_back(IntPtr obj, IntPtr nelems);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_uchar_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_uchar_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_uchar_new3([In] byte[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_uchar_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_uchar_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_uchar_copy(IntPtr vector, IntPtr dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_uchar_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_int32_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_int32_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_int32_new3([In] int[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_int32_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_int32_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_int32_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_float_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_float_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_float_new3([In] float[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_float_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_float_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_float_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_double_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_double_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_double_new3([In] double[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_double_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_double_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_double_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec2f_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec2f_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec2f_new3([In] Vec2f[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec2f_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec2f_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Vec2f_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec3f_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec3f_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec3f_new3([In] Vec3f[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec3f_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec3f_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Vec3f_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec4f_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec4f_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec4f_new3([In] Vec4f[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec4f_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec4f_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Vec4f_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec4i_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec4i_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec4i_new3([In] Vec4i[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec4i_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec4i_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Vec4i_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec6f_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec6f_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec6f_new3([In] Vec6f[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec6f_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec6f_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Vec6f_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec6d_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec6d_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec6d_new3([In] Vec6d[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec6d_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Vec6d_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Vec6d_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point2i_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point2i_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point2i_new3([In] Point[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point2i_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point2i_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Point2i_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point2f_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point2f_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point2f_new3([In] Point2f[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point2f_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point2f_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Point2f_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point3f_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point3f_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point3f_new3([In] Point3f[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point3f_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Point3f_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Point3f_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Rect_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Rect_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Rect_new3([In] Rect[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Rect_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Rect_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Rect_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_KeyPoint_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_KeyPoint_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_KeyPoint_new3([In] KeyPoint[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_KeyPoint_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_KeyPoint_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_KeyPoint_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_DMatch_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_DMatch_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_DMatch_new3([In] DMatch[] data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_DMatch_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_DMatch_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_DMatch_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_float_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_float_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_float_getSize1(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_float_getSize2(IntPtr vector, [In] [Out] IntPtr[] size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_float_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_float_copy(IntPtr vec, IntPtr[] dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_float_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_double_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_double_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_double_getSize1(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_double_getSize2(IntPtr vector, [In] [Out] IntPtr[] size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_double_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_double_copy(IntPtr vec, IntPtr[] dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_double_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_KeyPoint_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_KeyPoint_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_KeyPoint_new3(IntPtr[] values, int size1, int[] size2);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_KeyPoint_getSize1(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_KeyPoint_getSize2(IntPtr vector, [In] [Out] IntPtr[] size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_KeyPoint_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_KeyPoint_copy(IntPtr vec, IntPtr[] dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_KeyPoint_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_DMatch_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_DMatch_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_DMatch_getSize1(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_DMatch_getSize2(IntPtr vector, [In] [Out] IntPtr[] size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_DMatch_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_DMatch_copy(IntPtr vec, IntPtr[] dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_DMatch_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_Point_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_Point_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_Point_getSize1(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_Point_getSize2(IntPtr vector, [In] [Out] IntPtr[] size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_Point_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_Point_copy(IntPtr vec, IntPtr[] dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_Point_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_Point2f_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_Point2f_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_Point2f_getSize1(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_Point2f_getSize2(IntPtr vector, [In] [Out] IntPtr[] size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_vector_Point2f_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_Point2f_copy(IntPtr vec, IntPtr[] dst);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_vector_Point2f_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_string_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_string_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_string_getSize(IntPtr vec);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_string_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern sbyte* vector_string_elemAt(IntPtr vector, int i);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_string_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Mat_new1();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Mat_new2(IntPtr size);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Mat_new3(IntPtr data, IntPtr dataLength);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Mat_getSize(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr vector_Mat_getPointer(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Mat_delete(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Mat_assignToArray(IntPtr vector, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] arr);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void vector_Mat_addref(IntPtr vector);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr flann_Index_new(IntPtr features, IntPtr @params, int distType);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_Index_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_Index_knnSearch1(IntPtr obj, [In] float[] queries, int queriesLength, [Out] int[] indices, [Out] float[] dists, int knn, IntPtr @params);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_Index_knnSearch2(IntPtr obj, IntPtr queries, IntPtr indices, IntPtr dists, int knn, IntPtr @params);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_Index_knnSearch3(IntPtr obj, IntPtr queries, [Out] int[] indices, [Out] float[] dists, int knn, IntPtr @params);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_Index_radiusSearch1(IntPtr obj, [In] float[] queries, int queriesLength, [Out] int[] indices, int indicesLength, [Out] float[] dists, int dists_length, float radius, int maxResults, IntPtr @params);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_Index_radiusSearch2(IntPtr obj, IntPtr queries, IntPtr indices, IntPtr dists, float radius, int maxResults, IntPtr @params);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_Index_radiusSearch3(IntPtr obj, IntPtr queries, [Out] int[] indices, int indicesLength, [Out] float[] dists, int distsLength, float radius, int maxResults, IntPtr @params);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void flann_Index_save(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr flann_IndexParams_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_IndexParams_delete(IntPtr obj);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void flann_IndexParams_getString(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string defaultVal, [MarshalAs(UnmanagedType.LPStr)] StringBuilder result);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern int flann_IndexParams_getInt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, int defaultVal);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern double flann_IndexParams_getDouble(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, double defaultVal);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void flann_IndexParams_setString(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string value);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void flann_IndexParams_setInt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, int value);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void flann_IndexParams_setDouble(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, double value);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void flann_IndexParams_setFloat(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, float value);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern void flann_IndexParams_setBool(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_IndexParams_setAlgorithm(IntPtr obj, int value);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr flann_LinearIndexParams_new();

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_LinearIndexParams_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr flann_KDTreeIndexParams_new(int trees);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_KDTreeIndexParams_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr flann_KMeansIndexParams_new(int branching, int iterations, [MarshalAs(UnmanagedType.I4)] FlannCentersInit centers_init, float cb_index);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_KMeansIndexParams_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr flann_CompositeIndexParams_new(int trees, int branching, int iterations, FlannCentersInit centers_init, float cb_index);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_CompositeIndexParams_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr flann_AutotunedIndexParams_new(float targetPrecision, float build_weight, float memory_weight, float sample_fraction);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_AutotunedIndexParams_delete(IntPtr obj);

		[DllImport(DllExtern, BestFitMapping = false, CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
		public static extern IntPtr flann_SavedIndexParams_new([MarshalAs(UnmanagedType.LPStr)] string filename);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_SavedIndexParams_delete(IntPtr obj);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr flann_SearchParams_new(int checks, float eps, int sorted);

		[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
		public static extern void flann_SearchParams_delete(IntPtr obj);
	}
}
