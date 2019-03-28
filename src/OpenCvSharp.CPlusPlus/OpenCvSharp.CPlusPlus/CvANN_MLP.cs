using System;

namespace OpenCvSharp.CPlusPlus
{
	public class CvANN_MLP : CvStatModel
	{
		private bool disposed;

		public const MLPActivationFunc IDENTITY = MLPActivationFunc.Identity;

		public const MLPActivationFunc SIGMOID_SYM = MLPActivationFunc.SigmoidSym;

		public const MLPActivationFunc GAUSSIAN = MLPActivationFunc.Gaussian;

		public const MLPTrainingFlag UPDATE_WEIGHTS = MLPTrainingFlag.UpdateWeights;

		public const MLPTrainingFlag NO_INPUT_SCALE = MLPTrainingFlag.NoInputScale;

		public const MLPTrainingFlag NO_OUTPUT_SCALE = MLPTrainingFlag.NoOutputScale;

		public CvANN_MLP()
		{
			ptr = NativeMethods.ml_CvANN_MLP_new1();
		}

		public CvANN_MLP(CvMat layerSizes, MLPActivationFunc activFunc = MLPActivationFunc.SigmoidSym, double fParam1 = 0.0, double fParam2 = 0.0)
		{
			if (layerSizes == null)
			{
				throw new ArgumentNullException("layerSizes");
			}
			ptr = NativeMethods.ml_CvANN_MLP_new2_CvMat(layerSizes.CvPtr, (int)activFunc, fParam1, fParam2);
		}

		public CvANN_MLP(Mat layerSizes, MLPActivationFunc activFunc = MLPActivationFunc.SigmoidSym, double fParam1 = 0.0, double fParam2 = 0.0)
		{
			if (layerSizes == null)
			{
				throw new ArgumentNullException("layerSizes");
			}
			ptr = NativeMethods.ml_CvANN_MLP_new2_Mat(layerSizes.CvPtr, (int)activFunc, fParam1, fParam2);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.ml_CvANN_MLP_delete(ptr);
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

		public void Create(CvMat layerSizes, MLPActivationFunc activFunc = MLPActivationFunc.SigmoidSym, double fParam1 = 0.0, double fParam2 = 0.0)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("StatModel");
			}
			if (layerSizes == null)
			{
				throw new ArgumentNullException("layerSizes");
			}
			layerSizes.ThrowIfDisposed();
			NativeMethods.ml_CvANN_MLP_create_CvMat(ptr, layerSizes.CvPtr, (int)activFunc, fParam1, fParam2);
		}

		public void Create(Mat layerSizes, MLPActivationFunc activFunc = MLPActivationFunc.SigmoidSym, double fParam1 = 0.0, double fParam2 = 0.0)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("StatModel");
			}
			if (layerSizes == null)
			{
				throw new ArgumentNullException("layerSizes");
			}
			layerSizes.ThrowIfDisposed();
			NativeMethods.ml_CvANN_MLP_create_Mat(ptr, layerSizes.CvPtr, (int)activFunc, fParam1, fParam2);
		}

		public virtual int Train(CvMat inputs, CvMat outputs, CvMat sampleWeights, CvMat sampleIdx = null, CvANN_MLP_TrainParams param = null, MLPTrainingFlag flags = MLPTrainingFlag.Zero)
		{
			if (inputs == null)
			{
				throw new ArgumentNullException("inputs");
			}
			if (outputs == null)
			{
				throw new ArgumentNullException("outputs");
			}
			inputs.ThrowIfDisposed();
			outputs.ThrowIfDisposed();
			if (param == null)
			{
				param = new CvANN_MLP_TrainParams();
			}
			return NativeMethods.ml_CvANN_MLP_train_CvMat(ptr, inputs.CvPtr, outputs.CvPtr, Cv2.ToPtr(sampleWeights), Cv2.ToPtr(sampleIdx), param.NativeStruct, (int)flags);
		}

		public virtual int Train(Mat inputs, Mat outputs, Mat sampleWeights, Mat sampleIdx = null, CvANN_MLP_TrainParams param = null, MLPTrainingFlag flags = MLPTrainingFlag.Zero)
		{
			if (inputs == null)
			{
				throw new ArgumentNullException("inputs");
			}
			if (outputs == null)
			{
				throw new ArgumentNullException("outputs");
			}
			inputs.ThrowIfDisposed();
			outputs.ThrowIfDisposed();
			if (param == null)
			{
				param = new CvANN_MLP_TrainParams();
			}
			return NativeMethods.ml_CvANN_MLP_train_CvMat(ptr, inputs.CvPtr, outputs.CvPtr, Cv2.ToPtr(sampleWeights), Cv2.ToPtr(sampleIdx), param.NativeStruct, (int)flags);
		}

		public float Predict(CvMat inputs, CvMat outputs)
		{
			if (inputs == null)
			{
				throw new ArgumentNullException("inputs");
			}
			if (outputs == null)
			{
				throw new ArgumentNullException("outputs");
			}
			inputs.ThrowIfDisposed();
			outputs.ThrowIfDisposed();
			return NativeMethods.ml_CvANN_MLP_predict_CvMat(ptr, inputs.CvPtr, outputs.CvPtr);
		}

		public float Predict(Mat inputs, Mat outputs)
		{
			if (inputs == null)
			{
				throw new ArgumentNullException("inputs");
			}
			if (outputs == null)
			{
				throw new ArgumentNullException("outputs");
			}
			inputs.ThrowIfDisposed();
			outputs.ThrowIfDisposed();
			return NativeMethods.ml_CvANN_MLP_predict_CvMat(ptr, inputs.CvPtr, outputs.CvPtr);
		}

		public int GetLayerCount()
		{
			return NativeMethods.ml_CvANN_MLP_get_layer_count(ptr);
		}

		public CvMat GetLayerSizes()
		{
			IntPtr intPtr = NativeMethods.ml_CvANN_MLP_get_layer_sizes(ptr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new CvMat(intPtr, isEnabledDispose: false);
		}

		public override void Clear()
		{
			NativeMethods.ml_CvANN_MLP_clear(ptr);
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
			NativeMethods.ml_CvANN_MLP_write(ptr, storage.CvPtr, name);
		}

		public override void Read(CvFileStorage fs, CvFileNode node)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			NativeMethods.ml_CvANN_MLP_read(ptr, fs.CvPtr, node.CvPtr);
		}
	}
}
