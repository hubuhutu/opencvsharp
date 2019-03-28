using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	public class CvDTreeParams : DisposableCvObject
	{
		protected float[] priors;

		protected GCHandle handle;

		private bool disposed;

		public int MaxCategories
		{
			get
			{
				return NativeMethods.ml_CvDTreeParams_max_categories_get(ptr);
			}
			set
			{
				NativeMethods.ml_CvDTreeParams_max_categories_set(ptr, value);
			}
		}

		public int MaxDepth
		{
			get
			{
				return NativeMethods.ml_CvDTreeParams_max_depth_get(ptr);
			}
			set
			{
				NativeMethods.ml_CvDTreeParams_max_depth_set(ptr, value);
			}
		}

		public int MinSampleCount
		{
			get
			{
				return NativeMethods.ml_CvDTreeParams_min_sample_count_get(ptr);
			}
			set
			{
				NativeMethods.ml_CvDTreeParams_min_sample_count_set(ptr, value);
			}
		}

		public int CvFolds
		{
			get
			{
				return NativeMethods.ml_CvDTreeParams_cv_folds_get(ptr);
			}
			set
			{
				NativeMethods.ml_CvDTreeParams_cv_folds_set(ptr, value);
			}
		}

		public bool UseSurrogates
		{
			get
			{
				return NativeMethods.ml_CvDTreeParams_use_surrogates_get(ptr) != 0;
			}
			set
			{
				NativeMethods.ml_CvDTreeParams_use_surrogates_set(ptr, value ? 1 : 0);
			}
		}

		public bool Use1seRule
		{
			get
			{
				return NativeMethods.ml_CvDTreeParams_use_1se_rule_get(ptr) != 0;
			}
			set
			{
				NativeMethods.ml_CvDTreeParams_use_1se_rule_set(ptr, value ? 1 : 0);
			}
		}

		public bool TruncatePrunedTree
		{
			get
			{
				return NativeMethods.ml_CvDTreeParams_truncate_pruned_tree_get(ptr) != 0;
			}
			set
			{
				NativeMethods.ml_CvDTreeParams_truncate_pruned_tree_set(ptr, value ? 1 : 0);
			}
		}

		public float RegressionAccuracy
		{
			get
			{
				return NativeMethods.ml_CvDTreeParams_regression_accuracy_get(ptr);
			}
			set
			{
				NativeMethods.ml_CvDTreeParams_regression_accuracy_set(ptr, value);
			}
		}

		public float[] Priors
		{
			get
			{
				return priors;
			}
			set
			{
				priors = value;
				if (handle.IsAllocated)
				{
					handle.Free();
				}
				if (value != null)
				{
					handle = GCHandle.Alloc(value, GCHandleType.Pinned);
					NativeMethods.ml_CvDTreeParams_priors_set(ptr, handle.AddrOfPinnedObject());
				}
			}
		}

		protected internal CvDTreeParams(IntPtr ptr)
		{
			base.ptr = ptr;
			priors = null;
		}

		public CvDTreeParams()
		{
			ptr = NativeMethods.ml_CvDTreeParams_new1();
			priors = null;
		}

		public CvDTreeParams(int maxDepth, int minSampleCount, float regressionAccuracy, bool useSurrogates, int maxCategories, int cvFolds, bool use1seRule, bool truncatePrunedTree, float[] priors)
		{
			IntPtr intPtr = IntPtr.Zero;
			if (priors != null)
			{
				handle = GCHandle.Alloc(priors, GCHandleType.Pinned);
				intPtr = handle.AddrOfPinnedObject();
			}
			ptr = NativeMethods.ml_CvDTreeParams_new2(maxDepth, minSampleCount, regressionAccuracy, useSurrogates ? 1 : 0, maxCategories, cvFolds, use1seRule ? 1 : 0, truncatePrunedTree ? 1 : 0, intPtr);
			this.priors = priors;
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (disposing && handle.IsAllocated)
					{
						handle.Free();
					}
					if (base.IsEnabledDispose)
					{
						if (ptr != IntPtr.Zero)
						{
							NativeMethods.ml_CvDTreeParams_delete(ptr);
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
