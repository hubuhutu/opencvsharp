using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvSVMParams
	{
		private WCvSVMParams data;

        internal WCvSVMParams NativeStruct { get { return data; } }

		public SVMType SVMType
		{
			get
			{
				return (SVMType)data.svm_type;
			}
			set
			{
				data.svm_type = (int)value;
			}
		}

		public SVMKernelType KernelType
		{
			get
			{
				return (SVMKernelType)data.kernel_type;
			}
			set
			{
				data.kernel_type = (int)value;
			}
		}

		public double Degree
		{
			get
			{
				return data.degree;
			}
			set
			{
				data.degree = value;
			}
		}

		public double Gamma
		{
			get
			{
				return data.gamma;
			}
			set
			{
				data.gamma = value;
			}
		}

		public double Coef0
		{
			get
			{
				return data.coef0;
			}
			set
			{
				data.coef0 = value;
			}
		}

		public double C
		{
			get
			{
				return data.C;
			}
			set
			{
				data.C = value;
			}
		}

		public double Nu
		{
			get
			{
				return data.nu;
			}
			set
			{
				data.nu = value;
			}
		}

		public double P
		{
			get
			{
				return data.p;
			}
			set
			{
				data.p = value;
			}
		}

		public unsafe CvMat ClassWeights
		{
			get
			{
				IntPtr intPtr = new IntPtr(data.class_weights);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new CvMat(intPtr, isEnabledDispose: false);
			}
			set
			{
				if (value == null)
				{
					data.class_weights = null;
				}
				data.class_weights = value.CvPtr.ToPointer();
			}
		}

		public CvTermCriteria TermCrit
		{
			get
			{
				return data.term_crit;
			}
			set
			{
				data.term_crit = value;
			}
		}

		internal CvSVMParams(WCvSVMParams data)
		{
			this.data = data;
		}

		public CvSVMParams()
		{
			data = default(WCvSVMParams);
			NativeMethods.ml_CvSVMParams_new1(ref data);
		}

		public CvSVMParams(SVMType svmType, SVMKernelType kernelType, double degree, double gamma, double coef0, double c, double nu, double p, CvMat classWeights, CvTermCriteria termCrit)
		{
			data = default(WCvSVMParams);
			NativeMethods.ml_CvSVMParams_new2(ref data, (int)svmType, (int)kernelType, degree, gamma, coef0, c, nu, p, Cv2.ToPtr(classWeights), termCrit);
		}
	}
}
