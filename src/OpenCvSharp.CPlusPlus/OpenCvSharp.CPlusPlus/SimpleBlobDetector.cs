using System;

namespace OpenCvSharp.CPlusPlus
{
	public class SimpleBlobDetector : FeatureDetector
	{
		public class Params
		{
			internal WParams data;

			public float ThresholdStep
			{
				get
				{
					return data.thresholdStep;
				}
				set
				{
					data.thresholdStep = value;
				}
			}

			public float MinThreshold
			{
				get
				{
					return data.minThreshold;
				}
				set
				{
					data.minThreshold = value;
				}
			}

			public float MaxThreshold
			{
				get
				{
					return data.maxThreshold;
				}
				set
				{
					data.maxThreshold = value;
				}
			}

			public uint MinRepeatability
			{
				get
				{
					return data.minRepeatability;
				}
				set
				{
					data.minRepeatability = value;
				}
			}

			public float MinDistBetweenBlobs
			{
				get
				{
					return data.minDistBetweenBlobs;
				}
				set
				{
					data.minDistBetweenBlobs = value;
				}
			}

			public bool FilterByColor
			{
				get
				{
					return data.filterByColor != 0;
				}
				set
				{
					data.filterByColor = (value ? 1 : 0);
				}
			}

			public byte BlobColor
			{
				get
				{
					return data.blobColor;
				}
				set
				{
					data.blobColor = value;
				}
			}

			public bool FilterByArea
			{
				get
				{
					return data.filterByArea != 0;
				}
				set
				{
					data.filterByArea = (value ? 1 : 0);
				}
			}

			public float MinArea
			{
				get
				{
					return data.minArea;
				}
				set
				{
					data.minArea = value;
				}
			}

			public float MaxArea
			{
				get
				{
					return data.maxArea;
				}
				set
				{
					data.maxArea = value;
				}
			}

			public bool FilterByCircularity
			{
				get
				{
					return data.filterByCircularity != 0;
				}
				set
				{
					data.filterByCircularity = (value ? 1 : 0);
				}
			}

			public float MinCircularity
			{
				get
				{
					return data.minCircularity;
				}
				set
				{
					data.minCircularity = value;
				}
			}

			public float MaxCircularity
			{
				get
				{
					return data.maxCircularity;
				}
				set
				{
					data.maxCircularity = value;
				}
			}

			public bool FilterByInertia
			{
				get
				{
					return data.filterByInertia != 0;
				}
				set
				{
					data.filterByInertia = (value ? 1 : 0);
				}
			}

			public float MinInertiaRatio
			{
				get
				{
					return data.minInertiaRatio;
				}
				set
				{
					data.minInertiaRatio = value;
				}
			}

			public float MaxInertiaRatio
			{
				get
				{
					return data.maxInertiaRatio;
				}
				set
				{
					data.maxInertiaRatio = value;
				}
			}

			public bool FilterByConvexity
			{
				get
				{
					return data.filterByConvexity != 0;
				}
				set
				{
					data.filterByConvexity = (value ? 1 : 0);
				}
			}

			public float MinConvexity
			{
				get
				{
					return data.minConvexity;
				}
				set
				{
					data.minConvexity = value;
				}
			}

			public float MaxConvexity
			{
				get
				{
					return data.maxConvexity;
				}
				set
				{
					data.maxConvexity = value;
				}
			}

			public Params()
			{
				data = new WParams
				{
					thresholdStep = 10f,
					minThreshold = 50f,
					maxThreshold = 220f,
					minRepeatability = 2u,
					minDistBetweenBlobs = 10f,
					filterByColor = 1,
					blobColor = 0,
					filterByArea = 1,
					minArea = 25f,
					maxArea = 5000f,
					filterByCircularity = 0,
					minCircularity = 0.8f,
					maxCircularity = float.MaxValue,
					filterByInertia = 1,
					minInertiaRatio = 0.1f,
					maxInertiaRatio = float.MaxValue,
					filterByConvexity = 1,
					minConvexity = 0.95f,
					maxConvexity = float.MaxValue
				};
			}
		}

		public struct WParams
		{
			public float thresholdStep;

			public float minThreshold;

			public float maxThreshold;

			public uint minRepeatability;

			public float minDistBetweenBlobs;

			public int filterByColor;

			public byte blobColor;

			public int filterByArea;

			public float minArea;

			public float maxArea;

			public int filterByCircularity;

			public float minCircularity;

			public float maxCircularity;

			public int filterByInertia;

			public float minInertiaRatio;

			public float maxInertiaRatio;

			public int filterByConvexity;

			public float minConvexity;

			public float maxConvexity;
		}

		private bool disposed;

		private Ptr<SimpleBlobDetector> detectorPtr;

		public override IntPtr InfoPtr => NativeMethods.features2d_GFTTDetector_info(ptr);

		public SimpleBlobDetector(Params parameters = null)
		{
			if (parameters == null)
			{
				parameters = new Params();
			}
			ptr = NativeMethods.features2d_SimpleBlobDetector_new(ref parameters.data);
		}

		internal SimpleBlobDetector(Ptr<SimpleBlobDetector> detectorPtr)
		{
			this.detectorPtr = detectorPtr;
			ptr = detectorPtr.Obj;
		}

		internal SimpleBlobDetector(IntPtr rawPtr)
		{
			detectorPtr = null;
			ptr = rawPtr;
		}

		internal new static SimpleBlobDetector FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid cv::Ptr<SimpleBlobDetector> pointer");
			}
			return new SimpleBlobDetector(new Ptr<SimpleBlobDetector>(ptr));
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (detectorPtr != null)
					{
						detectorPtr.Dispose();
						detectorPtr = null;
					}
					else
					{
						if (ptr != IntPtr.Zero)
						{
							NativeMethods.features2d_SimpleBlobDetector_delete(ptr);
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

		public KeyPoint[] Run(Mat image, Mat mask)
		{
			ThrowIfDisposed();
			return Detect(image, mask);
		}
	}
}
