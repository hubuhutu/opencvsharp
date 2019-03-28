using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus.Gpu
{
	public abstract class GpuMatIndexer<T> where T : struct
	{
		protected readonly GpuMat parent;

		protected readonly long step;

		protected readonly int sizeOfT;

		public abstract T this[int i0, int i1]
		{
			get;
			set;
		}

		internal GpuMatIndexer(GpuMat parent)
		{
			this.parent = parent;
			step = parent.Step();
			sizeOfT = Marshal.SizeOf(typeof(T));
		}
	}
}
