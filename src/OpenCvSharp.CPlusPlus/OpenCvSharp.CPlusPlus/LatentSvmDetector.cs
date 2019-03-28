using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class LatentSvmDetector : DisposableCvObject
	{
		public class ObjectDetection
		{
			public Rect Rect
			{
				get;
				set;
			}

			public float Score
			{
				get;
				set;
			}

			public int ClassId
			{
				get;
				set;
			}

			public ObjectDetection(Rect? rect = default(Rect?), float score = 0f, int classId = -1)
			{
				Rect = rect.GetValueOrDefault(default(Rect));
				Score = score;
				ClassId = classId;
			}
		}

		private bool disposed;

		public LatentSvmDetector()
		{
			ptr = NativeMethods.objdetect_LatentSvmDetector_new();
		}

		public LatentSvmDetector(IEnumerable<string> fileNames, IEnumerable<string> classNames)
			: this()
		{
			Load(fileNames, classNames);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						NativeMethods.objdetect_LatentSvmDetector_delete(ptr);
					}
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public virtual void Clear()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("LatentSvmDetector");
			}
			NativeMethods.objdetect_LatentSvmDetector_clear(ptr);
		}

		public virtual bool Empty()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("LatentSvmDetector");
			}
			return NativeMethods.objdetect_LatentSvmDetector_empty(ptr) != 0;
		}

		public virtual bool Load(IEnumerable<string> fileNames, IEnumerable<string> classNames)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("LatentSvmDetector");
			}
			if (fileNames == null)
			{
				throw new ArgumentNullException("fileNames");
			}
			if (classNames == null)
			{
				throw new ArgumentNullException("classNames");
			}
			using (StringArrayAddress stringArrayAddress = new StringArrayAddress(fileNames))
			{
				using (StringArrayAddress stringArrayAddress2 = new StringArrayAddress(classNames))
				{
					return NativeMethods.objdetect_LatentSvmDetector_load(ptr, stringArrayAddress.Pointer, stringArrayAddress.Dim1Length, stringArrayAddress2.Pointer, stringArrayAddress2.Dim1Length) != 0;
				}
			}
		}

		public virtual ObjectDetection[] Detect(Mat image, float overlapThreshold = 0.5f, int numThreads = -1)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("LatentSvmDetector");
			}
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfDisposed();
			using (VectorOfVec6d vectorOfVec6d = new VectorOfVec6d())
			{
				NativeMethods.objdetect_LatentSvmDetector_detect(ptr, image.CvPtr, vectorOfVec6d.CvPtr, overlapThreshold, numThreads);
				return EnumerableEx.SelectToArray(vectorOfVec6d.ToArray(), (Vec6d v) => new ObjectDetection
				{
					Rect = new Rect((int)v.Item0, (int)v.Item1, (int)v.Item2, (int)v.Item3),
					Score = (float)v.Item4,
					ClassId = (int)v.Item5
				});
			}
		}

		public string[] GetClassNames()
		{
			using (VectorOfString vectorOfString = new VectorOfString())
			{
				NativeMethods.objdetect_LatentSvmDetector_getClassNames(ptr, vectorOfString.CvPtr);
				return vectorOfString.ToArray();
			}
		}

		public long GetClassCount()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("LatentSvmDetector");
			}
			return NativeMethods.objdetect_LatentSvmDetector_getClassCount(ptr).ToInt64();
		}
	}
}
