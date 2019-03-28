using System;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Flann
{
	public class IndexParams : DisposableCvObject
	{
		private bool disposed;

		public IndexParams()
		{
			ptr = NativeMethods.flann_IndexParams_new();
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create IndexParams");
			}
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
							NativeMethods.flann_IndexParams_delete(ptr);
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

		public string GetString(string key, string defaultVal)
		{
			StringBuilder stringBuilder = new StringBuilder(1024);
			NativeMethods.flann_IndexParams_getString(ptr, key, defaultVal, stringBuilder);
			return stringBuilder.ToString();
		}

		public string GetString(string key)
		{
			return GetString(key, null);
		}

		public int GetInt(string key, int defaultVal)
		{
			return NativeMethods.flann_IndexParams_getInt(ptr, key, defaultVal);
		}

		public int GetInt(string key)
		{
			return GetInt(key, -1);
		}

		public double GetDouble(string key, double defaultVal)
		{
			return NativeMethods.flann_IndexParams_getDouble(ptr, key, defaultVal);
		}

		public double GetDouble(string key)
		{
			return GetDouble(key, -1.0);
		}

		public void SetString(string key, string value)
		{
			NativeMethods.flann_IndexParams_setString(ptr, key, value);
		}

		public void SetInt(string key, int value)
		{
			NativeMethods.flann_IndexParams_setInt(ptr, key, value);
		}

		public void SetDouble(string key, double value)
		{
			NativeMethods.flann_IndexParams_setDouble(ptr, key, value);
		}

		public void SetFloat(string key, float value)
		{
			NativeMethods.flann_IndexParams_setFloat(ptr, key, value);
		}

		public void SetBool(string key, bool value)
		{
			NativeMethods.flann_IndexParams_setBool(ptr, key, value ? 1 : 0);
		}

		public void SetAlgorithm(int value)
		{
			NativeMethods.flann_IndexParams_setAlgorithm(ptr, value);
		}
	}
}
