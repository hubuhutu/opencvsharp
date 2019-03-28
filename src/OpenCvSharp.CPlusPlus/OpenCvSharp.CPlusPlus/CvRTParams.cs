using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	public class CvRTParams : CvDTreeParams
	{
		private bool disposed;

		public bool CalcVarImportance
		{
			get
			{
				return NativeMethods.ml_CvRTParams_calc_var_importance_get(ptr) != 0;
			}
			set
			{
				NativeMethods.ml_CvRTParams_calc_var_importance_set(ptr, value ? 1 : 0);
			}
		}

		public int NactiveVars
		{
			get
			{
				return NativeMethods.ml_CvRTParams_nactive_vars_get(ptr);
			}
			set
			{
				NativeMethods.ml_CvRTParams_nactive_vars_set(ptr, value);
			}
		}

		public CvTermCriteria TermCrit
		{
			get
			{
				return NativeMethods.ml_CvRTParams_term_crit_get(ptr);
			}
			set
			{
				NativeMethods.ml_CvRTParams_term_crit_set(ptr, value);
			}
		}

		protected internal CvRTParams(IntPtr ptr)
			: base(ptr)
		{
		}

		public CvRTParams()
			: base(IntPtr.Zero)
		{
			ptr = NativeMethods.ml_CvRTParams_new1();
		}

		public CvRTParams(int maxDepth, int minSampleCount, float regressionAccuracy, bool useSurrogates, int maxCategories, float[] priors, bool calcVarImportance, int nactiveVars, CvTermCriteria termCrit)
			: base(IntPtr.Zero)
		{
			IntPtr priors2 = IntPtr.Zero;
			if (priors != null)
			{
				handle = GCHandle.Alloc(priors, GCHandleType.Pinned);
				priors2 = handle.AddrOfPinnedObject();
			}
			base.priors = priors;
			ptr = NativeMethods.ml_CvRTParams_new2(maxDepth, minSampleCount, regressionAccuracy, useSurrogates ? 1 : 0, maxCategories, priors2, calcVarImportance ? 1 : 0, nactiveVars, termCrit.MaxIter, (float)termCrit.Epsilon, (int)termCrit.Type);
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
							NativeMethods.ml_CvRTParams_delete(ptr);
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
	}
}
