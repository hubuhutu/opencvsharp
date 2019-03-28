using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	public class CvBoostParams : CvDTreeParams
	{
		private bool disposed;

		public unsafe BoostType BoostType
		{
			get
			{
				return (BoostType)(*NativeMethods.ml_BoostParams_boost_type(ptr));
			}
			set
			{
				*NativeMethods.ml_BoostParams_boost_type(ptr) = (int)value;
			}
		}

		public unsafe int WeakCount
		{
			get
			{
				return *NativeMethods.ml_BoostParams_weak_count(ptr);
			}
			set
			{
				*NativeMethods.ml_BoostParams_weak_count(ptr) = value;
			}
		}

		public unsafe BoostSplitCriteria SplitCriteria
		{
			get
			{
				return (BoostSplitCriteria)(*NativeMethods.ml_BoostParams_split_criteria(ptr));
			}
			set
			{
				*NativeMethods.ml_BoostParams_split_criteria(ptr) = (int)value;
			}
		}

		public unsafe double WeightTrimRate
		{
			get
			{
				return *NativeMethods.ml_BoostParams_weight_trim_rate(ptr);
			}
			set
			{
				*NativeMethods.ml_BoostParams_weight_trim_rate(ptr) = value;
			}
		}

		internal CvBoostParams(IntPtr ptr, bool isEnabledDispose)
		{
			base.ptr = ptr;
			base.IsEnabledDispose = isEnabledDispose;
		}

		public CvBoostParams()
		{
			ptr = NativeMethods.ml_BoostParams_new1();
		}

		public CvBoostParams(BoostType boostType, int weakCount, double weightTrimRate, int maxDepth, bool useSurrogates, float[] priors)
		{
			IntPtr priors2 = IntPtr.Zero;
			if (priors != null)
			{
				handle = GCHandle.Alloc(priors, GCHandleType.Pinned);
				priors2 = handle.AddrOfPinnedObject();
			}
			base.priors = priors;
			ptr = NativeMethods.ml_BoostParams_new2((int)boostType, weakCount, weightTrimRate, maxDepth, useSurrogates ? 1 : 0, priors2);
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
							NativeMethods.ml_BoostParams_delete(ptr);
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
