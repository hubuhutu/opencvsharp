using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
	public abstract class Algorithm : DisposableCvObject
	{
		private bool disposed;

		private AlgorithmInfo infoObj;

        public string Name { get { return Info.Name; } }

		public AlgorithmInfo Info
		{
			get
			{
				if (disposed)
				{
					throw new ObjectDisposedException("Algorithm");
				}
				return infoObj ?? (infoObj = new AlgorithmInfo(InfoPtr));
			}
		}

		public abstract IntPtr InfoPtr
		{
			get;
		}

		internal Algorithm()
		{
		}

		public void Release()
		{
			Dispose(disposing: true);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				disposed = true;
				base.Dispose(disposing);
			}
		}

		public int GetInt(string name)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			IntPtr infoPtr = InfoPtr;
			int value = 0;
			NativeMethods.core_AlgorithmInfo_getInt(infoPtr, ptr, name, 0, ref value);
			return value;
		}

		public double GetDouble(string name)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			IntPtr infoPtr = InfoPtr;
			double value = 0.0;
			NativeMethods.core_AlgorithmInfo_getDouble(infoPtr, ptr, name, 2, ref value);
			return value;
		}

		public bool GetBool(string name)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			IntPtr infoPtr = InfoPtr;
			int value = 0;
			NativeMethods.core_AlgorithmInfo_getBool(infoPtr, ptr, name, 1, ref value);
			return value != 0;
		}

		public string GetString(string name)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			IntPtr infoPtr = InfoPtr;
			StringBuilder stringBuilder = new StringBuilder(65536);
			NativeMethods.core_AlgorithmInfo_getString(infoPtr, ptr, name, 3, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}

		public Mat GetMat(string name)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			IntPtr infoPtr = InfoPtr;
			Mat mat = new Mat();
			NativeMethods.core_AlgorithmInfo_getMat(infoPtr, ptr, name, 4, mat.CvPtr);
			return mat;
		}

		public Mat[] GetMatVector(string name)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			throw new NotImplementedException();
		}

		public Algorithm GetAlgorithm(string name)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			throw new NotImplementedException();
		}

		public void SetInt(string name, int value)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			NativeMethods.core_AlgorithmInfo_setInt(InfoPtr, ptr, name, 0, value, 0);
		}

		public void SetDouble(string name, double value)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			NativeMethods.core_AlgorithmInfo_setDouble(InfoPtr, ptr, name, 2, value, 0);
		}

		public void SetBool(string name, bool value)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			IntPtr infoPtr = InfoPtr;
			int value2 = value ? 1 : 0;
			NativeMethods.core_AlgorithmInfo_setBool(infoPtr, ptr, name, 1, value2, 0);
		}

		public void SetString(string name, string value)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			NativeMethods.core_AlgorithmInfo_setString(InfoPtr, ptr, name, 3, value, 0);
		}

		public void SetMat(string name, Mat value)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			value.ThrowIfDisposed();
			NativeMethods.core_AlgorithmInfo_setMat(InfoPtr, ptr, name, 4, value.CvPtr, 0);
		}

		public void SetMatVector(string name, IEnumerable<Mat> value)
		{
			throw new NotImplementedException();
		}

		public void SetAlgorithm(string name, Algorithm value)
		{
			throw new NotImplementedException();
		}

		public string ParamHelp(string name)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			return Info.ParamHelp(name);
		}

		public AlgorithmParamType ParamType(string name)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			return Info.ParamType(name);
		}

		public string[] GetParams()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Algorithm");
			}
			return Info.GetParams();
		}

		public static string[] GetList()
		{
			using (VectorOfString vectorOfString = new VectorOfString())
			{
				NativeMethods.core_Algorithm_getList(vectorOfString.CvPtr);
				return vectorOfString.ToArray();
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Algorithm [{0}]\n", Name);
			string[] @params = GetParams();
			foreach (string text in @params)
			{
				AlgorithmParamType algorithmParamType = ParamType(text);
				string name = Enum.GetName(typeof(AlgorithmParamType), algorithmParamType);
				stringBuilder.AppendFormat(" * {0} {1} = ", name, text);
				switch (algorithmParamType)
				{
				case AlgorithmParamType.Int:
				case AlgorithmParamType.Short:
				case AlgorithmParamType.UChar:
					stringBuilder.AppendFormat("{0}\n", GetInt(text));
					break;
				case AlgorithmParamType.Boolean:
					stringBuilder.AppendFormat("{0}\n", GetBool(text));
					break;
				case AlgorithmParamType.Real:
				case AlgorithmParamType.Float:
				case AlgorithmParamType.UInt64:
					stringBuilder.AppendFormat("{0}\n", GetDouble(text));
					break;
				case AlgorithmParamType.Mat:
					stringBuilder.AppendFormat("{0}\n", GetMat(text).ToString());
					break;
				case AlgorithmParamType.MatVector:
					stringBuilder.AppendFormat("Mat[{0}]\n", GetMatVector(text).Length);
					break;
				case AlgorithmParamType.String:
					stringBuilder.AppendFormat("{0}\n", GetString(text));
					break;
				case AlgorithmParamType.Algorithm:
					stringBuilder.AppendFormat("{0}\n", GetAlgorithm(text).Name);
					break;
				}
			}
			return stringBuilder.ToString();
		}
	}
}
