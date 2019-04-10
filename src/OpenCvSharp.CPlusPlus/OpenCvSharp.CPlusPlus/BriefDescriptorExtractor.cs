using System;

namespace OpenCvSharp.CPlusPlus
{
	public class BriefDescriptorExtractor : DescriptorExtractor
	{
		public const int PATCH_SIZE = 48;

		public const int KERNEL_SIZE = 9;

		private bool disposed;

		private Ptr<BriefDescriptorExtractor> extractorPtr;

        public override IntPtr InfoPtr { get { return NativeMethods.features2d_BriefDescriptorExtractor_info(ptr); } }

		public BriefDescriptorExtractor(int bytes = 32)
		{
			ptr = NativeMethods.features2d_BriefDescriptorExtractor_new(bytes);
		}

		internal BriefDescriptorExtractor(Ptr<BriefDescriptorExtractor> extractorPtr, IntPtr ptr)
		{
			this.extractorPtr = null;
			base.ptr = IntPtr.Zero;
		}

		internal new static BriefDescriptorExtractor FromPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid BriefDescriptorExtractor pointer");
			}
			Ptr<BriefDescriptorExtractor> ptr2 = new Ptr<BriefDescriptorExtractor>(ptr);
			return new BriefDescriptorExtractor(ptr2, ptr2.Obj);
		}

		internal new static BriefDescriptorExtractor FromRawPtr(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Invalid BriefDescriptorExtractor pointer");
			}
			return new BriefDescriptorExtractor(null, ptr);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (base.IsEnabledDispose)
					{
						if (extractorPtr != null)
						{
							extractorPtr.Dispose();
						}
						else
						{
							NativeMethods.features2d_BriefDescriptorExtractor_delete(ptr);
						}
						extractorPtr = null;
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

		public override int DescriptorSize()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("BriefDescriptorExtractor");
			}
			return NativeMethods.features2d_BriefDescriptorExtractor_descriptorSize(ptr);
		}

		public override int DescriptorType()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("BriefDescriptorExtractor");
			}
			return NativeMethods.features2d_BriefDescriptorExtractor_descriptorType(ptr);
		}
	}
}
