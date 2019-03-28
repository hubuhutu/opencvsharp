namespace OpenCvSharp.CPlusPlus
{
	public class CvANN_MLP_TrainParams
	{
		private WCvANN_MLP_TrainParams data;

		internal WCvANN_MLP_TrainParams NativeStruct => data;

		public TermCriteria TermCrit
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

		public MLPTrainingMethod TrainMethod
		{
			get
			{
				return (MLPTrainingMethod)data.train_method;
			}
			set
			{
				data.train_method = (int)value;
			}
		}

		public double BpDwScale
		{
			get
			{
				return data.bp_dw_scale;
			}
			set
			{
				data.bp_dw_scale = value;
			}
		}

		public double BpMomentScale
		{
			get
			{
				return data.bp_moment_scale;
			}
			set
			{
				data.bp_moment_scale = value;
			}
		}

		public double RpDw0
		{
			get
			{
				return data.rp_dw0;
			}
			set
			{
				data.rp_dw0 = value;
			}
		}

		public double RpDwPlus
		{
			get
			{
				return data.rp_dw_plus;
			}
			set
			{
				data.rp_dw_plus = value;
			}
		}

		public double RpDwMinus
		{
			get
			{
				return data.rp_dw_minus;
			}
			set
			{
				data.rp_dw_minus = value;
			}
		}

		public double RpDwMin
		{
			get
			{
				return data.rp_dw_min;
			}
			set
			{
				data.rp_dw_min = value;
			}
		}

		public double RpDwMax
		{
			get
			{
				return data.rp_dw_max;
			}
			set
			{
				data.rp_dw_max = value;
			}
		}

		public CvANN_MLP_TrainParams()
		{
			NativeMethods.ml_ANN_MLP_TrainParams_new1(out data);
		}

		public CvANN_MLP_TrainParams(TermCriteria termCrit, MLPTrainingMethod trainMethod, double param1, double param2 = 0.0)
		{
			NativeMethods.ml_ANN_MLP_TrainParams_new2(termCrit, (int)trainMethod, param1, param2, out data);
		}
	}
}
