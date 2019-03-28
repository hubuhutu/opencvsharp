using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvSVM : CvStatModel
	{
		private bool disposed;

		public const SVMType C_SVC = SVMType.CSvc;

		public const SVMType NU_SVC = SVMType.NuSvc;

		public const SVMType ONE_CLASS = SVMType.OneClass;

		public const SVMType EPS_SVR = SVMType.EpsSvr;

		public const SVMType NU_SVR = SVMType.NuSvr;

		public const SVMKernelType LINEAR = SVMKernelType.Linear;

		public const SVMKernelType POLY = SVMKernelType.Poly;

		public const SVMKernelType RBF = SVMKernelType.Rbf;

		public const SVMKernelType SIGMOID = SVMKernelType.Sigmoid;

		public const SVMParamType C = SVMParamType.C;

		public const SVMParamType GAMMA = SVMParamType.Gamma;

		public const SVMParamType P = SVMParamType.P;

		public const SVMParamType NU = SVMParamType.Nu;

		public const SVMParamType COEF = SVMParamType.Coef;

		public const SVMParamType DEGREE = SVMParamType.Degree;

		public CvSVM()
		{
			ptr = NativeMethods.ml_CvSVM_new1();
		}

		public CvSVM(CvMat trainData, CvMat responses, CvMat varIdx = null, CvMat sampleIdx = null, CvSVMParams param = null)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (responses == null)
			{
				throw new ArgumentNullException("responses");
			}
			if (param == null)
			{
				param = new CvSVMParams();
			}
			trainData.ThrowIfDisposed();
			responses.ThrowIfDisposed();
			ptr = NativeMethods.ml_CvSVM_new2_CvMat(trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), param.NativeStruct);
		}

		public CvSVM(Mat trainData, Mat responses, Mat varIdx = null, Mat sampleIdx = null, CvSVMParams param = null)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (responses == null)
			{
				throw new ArgumentNullException("responses");
			}
			trainData.ThrowIfDisposed();
			responses.ThrowIfDisposed();
			if (param == null)
			{
				param = new CvSVMParams();
			}
			ptr = NativeMethods.ml_CvSVM_new2_Mat(trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), param.NativeStruct);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						if (ptr != IntPtr.Zero)
						{
							NativeMethods.ml_CvSVM_delete(ptr);
						}
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

		public static CvParamGrid GetDefaultGrid(SVMParamType paramId)
		{
			CvParamGrid grid = default(CvParamGrid);
			NativeMethods.ml_CvSVM_get_default_grid(ref grid, (int)paramId);
			return grid;
		}

		public int GetSupportVectorCount()
		{
			return NativeMethods.ml_CvSVM_get_support_vector_count(ptr);
		}

		public unsafe PointerAccessor1D_Single GetSupportVector(int i)
		{
			return new PointerAccessor1D_Single(NativeMethods.ml_CvSVM_get_support_vector(ptr, i));
		}

		public CvSVMParams GetParams()
		{
			WCvSVMParams p = default(WCvSVMParams);
			NativeMethods.ml_CvSVM_get_params(ptr, ref p);
			return new CvSVMParams(p);
		}

		public int GetVarCount()
		{
			return NativeMethods.ml_CvSVM_get_var_count(ptr);
		}

		public virtual bool Train(CvMat trainData, CvMat responses, CvMat varIdx = null, CvMat sampleIdx = null, CvSVMParams param = null)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (responses == null)
			{
				throw new ArgumentNullException("responses");
			}
			trainData.ThrowIfDisposed();
			responses.ThrowIfDisposed();
			if (param == null)
			{
				param = new CvSVMParams();
			}
			return NativeMethods.ml_CvSVM_train_CvMat(ptr, trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), param.NativeStruct) != 0;
		}

		public virtual bool Train(Mat trainData, Mat responses, Mat varIdx = null, Mat sampleIdx = null, CvSVMParams param = null)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (responses == null)
			{
				throw new ArgumentNullException("responses");
			}
			trainData.ThrowIfDisposed();
			responses.ThrowIfDisposed();
			if (param == null)
			{
				param = new CvSVMParams();
			}
			return NativeMethods.ml_CvSVM_train_Mat(ptr, trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx), param.NativeStruct) != 0;
		}

		public virtual bool TrainAuto(CvMat trainData, CvMat responses, CvMat varIdx, CvMat sampleIdx, CvSVMParams param, int kFold = 10, CvParamGrid? cGrid = default(CvParamGrid?), CvParamGrid? gammaGrid = default(CvParamGrid?), CvParamGrid? pGrid = default(CvParamGrid?), CvParamGrid? nuGrid = default(CvParamGrid?), CvParamGrid? coefGrid = default(CvParamGrid?), CvParamGrid? degreeGrid = default(CvParamGrid?), bool balanced = false)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (responses == null)
			{
				throw new ArgumentNullException("responses");
			}
			if (varIdx == null)
			{
				throw new ArgumentNullException("varIdx");
			}
			if (sampleIdx == null)
			{
				throw new ArgumentNullException("sampleIdx");
			}
			trainData.ThrowIfDisposed();
			responses.ThrowIfDisposed();
			varIdx.ThrowIfDisposed();
			sampleIdx.ThrowIfDisposed();
			if (param == null)
			{
				param = new CvSVMParams();
			}
			CvParamGrid defaultGrid = GetDefaultGrid(SVMParamType.C);
			CvParamGrid valueOrDefault = cGrid.GetValueOrDefault(defaultGrid);
			CvParamGrid valueOrDefault2 = gammaGrid.GetValueOrDefault(defaultGrid);
			CvParamGrid valueOrDefault3 = pGrid.GetValueOrDefault(defaultGrid);
			CvParamGrid valueOrDefault4 = nuGrid.GetValueOrDefault(defaultGrid);
			CvParamGrid valueOrDefault5 = coefGrid.GetValueOrDefault(defaultGrid);
			CvParamGrid valueOrDefault6 = degreeGrid.GetValueOrDefault(defaultGrid);
			return NativeMethods.ml_CvSVM_train_auto_CvMat(ptr, trainData.CvPtr, responses.CvPtr, varIdx.CvPtr, sampleIdx.CvPtr, param.NativeStruct, kFold, valueOrDefault, valueOrDefault2, valueOrDefault3, valueOrDefault4, valueOrDefault5, valueOrDefault6, balanced ? 1 : 0) != 0;
		}

		public virtual bool TrainAuto(Mat trainData, Mat responses, Mat varIdx, Mat sampleIdx, CvSVMParams param, int kFold = 10, CvParamGrid? cGrid = default(CvParamGrid?), CvParamGrid? gammaGrid = default(CvParamGrid?), CvParamGrid? pGrid = default(CvParamGrid?), CvParamGrid? nuGrid = default(CvParamGrid?), CvParamGrid? coefGrid = default(CvParamGrid?), CvParamGrid? degreeGrid = default(CvParamGrid?), bool balanced = false)
		{
			if (trainData == null)
			{
				throw new ArgumentNullException("trainData");
			}
			if (responses == null)
			{
				throw new ArgumentNullException("responses");
			}
			if (varIdx == null)
			{
				throw new ArgumentNullException("varIdx");
			}
			if (sampleIdx == null)
			{
				throw new ArgumentNullException("sampleIdx");
			}
			trainData.ThrowIfDisposed();
			responses.ThrowIfDisposed();
			varIdx.ThrowIfDisposed();
			sampleIdx.ThrowIfDisposed();
			if (param == null)
			{
				param = new CvSVMParams();
			}
			CvParamGrid defaultGrid = GetDefaultGrid(SVMParamType.C);
			CvParamGrid valueOrDefault = cGrid.GetValueOrDefault(defaultGrid);
			CvParamGrid valueOrDefault2 = gammaGrid.GetValueOrDefault(defaultGrid);
			CvParamGrid valueOrDefault3 = pGrid.GetValueOrDefault(defaultGrid);
			CvParamGrid valueOrDefault4 = nuGrid.GetValueOrDefault(defaultGrid);
			CvParamGrid valueOrDefault5 = coefGrid.GetValueOrDefault(defaultGrid);
			CvParamGrid valueOrDefault6 = degreeGrid.GetValueOrDefault(defaultGrid);
			return NativeMethods.ml_CvSVM_train_auto_CvMat(ptr, trainData.CvPtr, responses.CvPtr, varIdx.CvPtr, sampleIdx.CvPtr, param.NativeStruct, kFold, valueOrDefault, valueOrDefault2, valueOrDefault3, valueOrDefault4, valueOrDefault5, valueOrDefault6, balanced ? 1 : 0) != 0;
		}

		public virtual float Predict(CvMat sample, bool returnDfVal = false)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			sample.ThrowIfDisposed();
			return NativeMethods.ml_CvSVM_predict_CvMat1(ptr, sample.CvPtr, returnDfVal ? 1 : 0);
		}

		public virtual float Predict(CvMat sample, CvMat results)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			sample.ThrowIfDisposed();
			results.ThrowIfDisposed();
			return NativeMethods.ml_CvSVM_predict_CvMat2(ptr, sample.CvPtr, results.CvPtr);
		}

		public virtual float Predict(Mat sample, bool returnDfVal = false)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			sample.ThrowIfDisposed();
			return NativeMethods.ml_CvSVM_predict_CvMat1(ptr, sample.CvPtr, returnDfVal ? 1 : 0);
		}

		public virtual float Predict(InputArray sample, OutputArray results)
		{
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			sample.ThrowIfDisposed();
			results.ThrowIfNotReady();
			float result = NativeMethods.ml_CvSVM_predict_CvMat2(ptr, sample.CvPtr, results.CvPtr);
			results.Fix();
			return result;
		}

		public override void Clear()
		{
			NativeMethods.ml_CvSVM_clear(ptr);
		}

		public override void Write(CvFileStorage storage, string name)
		{
			if (storage == null)
			{
				throw new ArgumentNullException("storage");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			NativeMethods.ml_CvSVM_write(ptr, storage.CvPtr, name);
		}

		public override void Read(CvFileStorage storage, CvFileNode node)
		{
			if (storage == null)
			{
				throw new ArgumentNullException("storage");
			}
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			NativeMethods.ml_CvSVM_read(ptr, storage.CvPtr, node.CvPtr);
		}
	}
}
