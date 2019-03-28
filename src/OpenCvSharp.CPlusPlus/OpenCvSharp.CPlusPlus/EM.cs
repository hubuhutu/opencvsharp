using System;

namespace OpenCvSharp.CPlusPlus
{
	public class EM : Algorithm
	{
		private bool disposed;

		private Ptr<EM> modelPtr;

		public const int DEFAULT_NCLUSTERS = 5;

		public const int DEFAULT_MAX_ITERS = 100;

		public const EMCovMatType COV_MAT_SPHERICAL = EMCovMatType.Spherical;

		public const EMCovMatType COV_MAT_DIAGONAL = EMCovMatType.Diagonal;

		public const EMCovMatType COV_MAT_GENERIC = EMCovMatType.Generic;

		public const EMStartStep START_E_STEP = EMStartStep.E;

		public const EMStartStep START_M_STEP = EMStartStep.M;

		public const EMStartStep START_AUTO_STEP = EMStartStep.Auto;

		public override IntPtr InfoPtr => NativeMethods.ml_EM_info(ptr);

		public bool IsTrained
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("EM");
				}
				return NativeMethods.ml_EM_isTrained(ptr) != 0;
			}
		}

		public EM(int nClusters = 5, EMCovMatType covMatType = EMCovMatType.Diagonal, TermCriteria? termCrit = default(TermCriteria?))
		{
			TermCriteria valueOrDefault = termCrit.GetValueOrDefault(TermCriteria.Both(100, double.Epsilon));
			ptr = NativeMethods.ml_EM_new(nClusters, (int)covMatType, valueOrDefault);
		}

		internal EM(Ptr<EM> detectorPtr)
		{
			modelPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal EM(IntPtr rawPtr)
		{
			modelPtr = null;
			ptr = rawPtr;
		}

		internal static EM FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<EM> pointer");
			}
			return new EM(new Ptr<EM>(ptr));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						if (modelPtr != null)
						{
							modelPtr.Dispose();
							modelPtr = null;
						}
						else
						{
							if (ptr != IntPtr.Zero)
							{
								NativeMethods.ml_EM_delete(ptr);
							}
							ptr = IntPtr.Zero;
						}
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public virtual bool Train(InputArray samples, OutputArray logLikelihoods = null, OutputArray labels = null, OutputArray probs = null)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("EM");
			}
			if (samples == null)
			{
				throw new ArgumentNullException("samples");
			}
			samples.ThrowIfDisposed();
			logLikelihoods?.ThrowIfNotReady();
			labels?.ThrowIfNotReady();
			probs?.ThrowIfNotReady();
			int num = NativeMethods.ml_EM_train(ptr, samples.CvPtr, Cv2.ToPtr(logLikelihoods), Cv2.ToPtr(labels), Cv2.ToPtr(probs));
			logLikelihoods?.Fix();
			labels?.Fix();
			probs?.Fix();
			return num != 0;
		}

		public virtual bool TrainE(InputArray samples, InputArray means0, InputArray covs0 = null, InputArray weights0 = null, OutputArray logLikelihoods = null, OutputArray labels = null, OutputArray probs = null)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("EM");
			}
			if (samples == null)
			{
				throw new ArgumentNullException("samples");
			}
			if (means0 == null)
			{
				throw new ArgumentNullException("means0");
			}
			samples.ThrowIfDisposed();
			means0.ThrowIfDisposed();
			logLikelihoods?.ThrowIfNotReady();
			covs0?.ThrowIfDisposed();
			weights0?.ThrowIfDisposed();
			labels?.ThrowIfNotReady();
			probs?.ThrowIfNotReady();
			int num = NativeMethods.ml_EM_trainE(ptr, samples.CvPtr, means0.CvPtr, Cv2.ToPtr(covs0), Cv2.ToPtr(weights0), Cv2.ToPtr(logLikelihoods), Cv2.ToPtr(labels), Cv2.ToPtr(probs));
			logLikelihoods?.Fix();
			labels?.Fix();
			probs?.Fix();
			return num != 0;
		}

		public virtual bool TrainM(InputArray samples, InputArray probs0, OutputArray logLikelihoods = null, OutputArray labels = null, OutputArray probs = null)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("EM");
			}
			if (samples == null)
			{
				throw new ArgumentNullException("samples");
			}
			if (probs0 == null)
			{
				throw new ArgumentNullException("probs0");
			}
			samples.ThrowIfDisposed();
			probs0.ThrowIfDisposed();
			logLikelihoods?.ThrowIfNotReady();
			labels?.ThrowIfNotReady();
			probs?.ThrowIfNotReady();
			int num = NativeMethods.ml_EM_trainM(ptr, samples.CvPtr, probs0.CvPtr, Cv2.ToPtr(logLikelihoods), Cv2.ToPtr(labels), Cv2.ToPtr(probs));
			logLikelihoods?.Fix();
			labels?.Fix();
			probs?.Fix();
			return num != 0;
		}

		public virtual Vec2d Predict(InputArray sample, OutputArray probs = null)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("EM");
			}
			if (sample == null)
			{
				throw new ArgumentNullException("sample");
			}
			sample.ThrowIfDisposed();
			probs?.ThrowIfNotReady();
			NativeMethods.ml_EM_predict(ptr, sample.CvPtr, Cv2.ToPtr(probs), out Vec2d ret);
			probs?.Fix();
			return ret;
		}

		public void Clear()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("EM");
			}
			NativeMethods.ml_EM_clear(ptr);
		}
	}
}
