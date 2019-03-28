using System;
using System.IO;

namespace OpenCvSharp.CPlusPlus
{
	public class CascadeClassifier : DisposableCvObject
	{
		private bool disposed;

		public CascadeClassifier()
		{
			ptr = NativeMethods.objdetect_CascadeClassifier_new();
		}

		public CascadeClassifier(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException("\"" + fileName + "\"not found", fileName);
			}
			ptr = NativeMethods.objdetect_CascadeClassifier_newFromFile(fileName);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.objdetect_CascadeClassifier_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public virtual bool Empty()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CascadeClassifier");
			}
			return NativeMethods.objdetect_CascadeClassifier_empty(ptr) != 0;
		}

		public bool Load(string fileName)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CascadeClassifier");
			}
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException("\"" + fileName + "\"not found", fileName);
			}
			return NativeMethods.objdetect_CascadeClassifier_load(ptr, fileName) != 0;
		}

		public virtual Rect[] DetectMultiScale(Mat image, double scaleFactor = 1.1, int minNeighbors = 3, HaarDetectionType flags = HaarDetectionType.Zero, Size? minSize = default(Size?), Size? maxSize = default(Size?))
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CascadeClassifier");
			}
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfDisposed();
			Size valueOrDefault = minSize.GetValueOrDefault(default(Size));
			Size valueOrDefault2 = maxSize.GetValueOrDefault(default(Size));
			using (VectorOfRect vectorOfRect = new VectorOfRect())
			{
				NativeMethods.objdetect_CascadeClassifier_detectMultiScale(ptr, image.CvPtr, vectorOfRect.CvPtr, scaleFactor, minNeighbors, (int)flags, valueOrDefault, valueOrDefault2);
				return vectorOfRect.ToArray();
			}
		}

		public virtual Rect[] DetectMultiScale(Mat image, out int[] rejectLevels, out double[] levelWeights, double scaleFactor = 1.1, int minNeighbors = 3, HaarDetectionType flags = HaarDetectionType.Zero, Size? minSize = default(Size?), Size? maxSize = default(Size?), bool outputRejectLevels = false)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CascadeClassifier");
			}
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfDisposed();
			Size valueOrDefault = minSize.GetValueOrDefault(default(Size));
			Size valueOrDefault2 = maxSize.GetValueOrDefault(default(Size));
			using (VectorOfRect vectorOfRect = new VectorOfRect())
			{
				using (VectorOfInt32 vectorOfInt = new VectorOfInt32())
				{
					using (VectorOfDouble vectorOfDouble = new VectorOfDouble())
					{
						NativeMethods.objdetect_CascadeClassifier_detectMultiScale(ptr, image.CvPtr, vectorOfRect.CvPtr, vectorOfInt.CvPtr, vectorOfDouble.CvPtr, scaleFactor, minNeighbors, (int)flags, valueOrDefault, valueOrDefault2, outputRejectLevels ? 1 : 0);
						rejectLevels = vectorOfInt.ToArray();
						levelWeights = vectorOfDouble.ToArray();
						return vectorOfRect.ToArray();
					}
				}
			}
		}

		public bool IsOldFormatCascade()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CascadeClassifier");
			}
			return NativeMethods.objdetect_CascadeClassifier_isOldFormatCascade(ptr) != 0;
		}

		public virtual Size GetOriginalWindowSize()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CascadeClassifier");
			}
			return NativeMethods.objdetect_CascadeClassifier_getOriginalWindowSize(ptr);
		}

		public int GetFeatureType()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CascadeClassifier");
			}
			return NativeMethods.objdetect_CascadeClassifier_getFeatureType(ptr);
		}

		public bool SetImage(Mat img)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CascadeClassifier");
			}
			if (img == null)
			{
				throw new ArgumentNullException("img");
			}
			img.ThrowIfDisposed();
			return NativeMethods.objdetect_CascadeClassifier_setImage(ptr, img.CvPtr) != 0;
		}
	}
}
