using System;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
	public class AlgorithmInfo : ICvPtrHolder
	{
		private readonly IntPtr ptr;

        public IntPtr CvPtr
        {
            get
            {
                return ptr;
            }
        }
		public string Name
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(1024);
				NativeMethods.core_AlgorithmInfo_name(ptr, stringBuilder, stringBuilder.Capacity);
				return stringBuilder.ToString();
			}
		}

		public AlgorithmInfo(IntPtr ptr)
		{
			this.ptr = ptr;
		}

		public string ParamHelp(string name)
		{
			StringBuilder stringBuilder = new StringBuilder(4096);
			NativeMethods.core_AlgorithmInfo_paramHelp(ptr, name, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}

		public string[] GetParams()
		{
			using (VectorOfString vectorOfString = new VectorOfString())
			{
				NativeMethods.core_AlgorithmInfo_getParams(ptr, vectorOfString.CvPtr);
				return vectorOfString.ToArray();
			}
		}

		public AlgorithmParamType ParamType(string name)
		{
			return (AlgorithmParamType)NativeMethods.core_AlgorithmInfo_paramType(ptr, name);
		}
	}
}
