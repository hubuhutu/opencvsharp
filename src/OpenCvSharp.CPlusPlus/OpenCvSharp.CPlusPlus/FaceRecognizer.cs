using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class FaceRecognizer : Algorithm
	{
		private bool disposed;

		private Ptr<FaceRecognizer> recognizerPtr;

		public override IntPtr InfoPtr => NativeMethods.contrib_FaceRecognizer_info(ptr);

		protected FaceRecognizer()
		{
			recognizerPtr = null;
			ptr = IntPtr.Zero;
		}

		internal static FaceRecognizer FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<FaceRecognizer> pointer");
			}
			Ptr<FaceRecognizer> ptr2 = new Ptr<FaceRecognizer>(ptr);
			return new FaceRecognizer
			{
				recognizerPtr = ptr2,
				ptr = ptr2.Obj
			};
		}

		internal static FaceRecognizer FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid FaceRecognizer pointer");
			}
			return new FaceRecognizer
			{
				recognizerPtr = null,
				ptr = ptr
			};
		}

		public static FaceRecognizer CreateEigenFaceRecognizer(int numComponents = 0, double threshold = double.MaxValue)
		{
			return FromPtr(NativeMethods.contrib_createEigenFaceRecognizer(numComponents, threshold));
		}

		public static FaceRecognizer CreateFisherFaceRecognizer(int numComponents = 0, double threshold = double.MaxValue)
		{
			return FromPtr(NativeMethods.contrib_createFisherFaceRecognizer(numComponents, threshold));
		}

		public static FaceRecognizer CreateLBPHFaceRecognizer(int radius = 1, int neighbors = 8, int gridX = 8, int gridY = 8, double threshold = double.MaxValue)
		{
			return FromPtr(NativeMethods.contrib_createLBPHFaceRecognizer(radius, neighbors, gridX, gridY, threshold));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						if (recognizerPtr != null)
						{
							recognizerPtr.Dispose();
						}
						recognizerPtr = null;
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

		public virtual void Train(IEnumerable<Mat> src, IEnumerable<int> labels)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (labels == null)
			{
				throw new ArgumentNullException("labels");
			}
			IntPtr[] array = EnumerableEx.SelectPtrs(src);
			int[] array2 = EnumerableEx.ToArray(labels);
			NativeMethods.contrib_FaceRecognizer_train(ptr, array, array.Length, array2, array2.Length);
		}

		public void Update(IEnumerable<Mat> src, IEnumerable<int> labels)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (labels == null)
			{
				throw new ArgumentNullException("labels");
			}
			IntPtr[] array = EnumerableEx.SelectPtrs(src);
			int[] array2 = EnumerableEx.ToArray(labels);
			NativeMethods.contrib_FaceRecognizer_update(ptr, array, array.Length, array2, array2.Length);
		}

		public virtual int Predict(InputArray src)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			src.ThrowIfDisposed();
			return NativeMethods.contrib_FaceRecognizer_predict1(ptr, src.CvPtr);
		}

		public virtual void Predict(InputArray src, out int label, out double confidence)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			src.ThrowIfDisposed();
			NativeMethods.contrib_FaceRecognizer_predict2(ptr, src.CvPtr, out label, out confidence);
		}

		public virtual void Save(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			NativeMethods.contrib_FaceRecognizer_save1(ptr, fileName);
		}

		public virtual void Load(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			NativeMethods.contrib_FaceRecognizer_load1(ptr, fileName);
		}

		public virtual void Save(FileStorage fs)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			NativeMethods.contrib_FaceRecognizer_save2(ptr, fs.CvPtr);
		}

		public virtual void Load(FileStorage fs)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			NativeMethods.contrib_FaceRecognizer_load2(ptr, fs.CvPtr);
		}
	}
}
