using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
	public class CvSubdiv2D : CvGraph
	{
		public new static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSubdiv2D));

		public unsafe int QuadEdges => ((WCvSubdiv2D*)(void*)ptr)->quad_edges;

		public unsafe bool IsGeometryValid => ((WCvSubdiv2D*)(void*)ptr)->is_geometry_valid != 0;

		public unsafe uint RecentEdge => ((WCvSubdiv2D*)(void*)ptr)->recent_edge;

		public unsafe CvPoint2D32f TopLeft => ((WCvSubdiv2D*)(void*)ptr)->topleft;

		public unsafe CvPoint2D32f BottomRight => ((WCvSubdiv2D*)(void*)ptr)->bottomright;

		protected CvSubdiv2D()
		{
			ptr = IntPtr.Zero;
		}

		public CvSubdiv2D(CvRect rect, CvMemStorage storage)
		{
			if (storage == null)
			{
				throw new ArgumentNullException();
			}
			IntPtr intPtr = NativeMethods.cvCreateSubdiv2D(SeqType.KindBinaryTree, SizeOf, CvSubdiv2DPoint.SizeOf, CvQuadEdge2D.SizeOf, storage.CvPtr);
			if (intPtr == IntPtr.Zero)
			{
				throw new OpenCvSharpException("Failed to create CvSubdiv2D");
			}
			NativeMethods.cvInitSubdivDelaunay2D(intPtr, rect);
			Initialize(intPtr);
			holdingStorage = storage;
			GC.KeepAlive(storage);
		}

		public CvSubdiv2D(IntPtr ptr)
			: base(ptr)
		{
			Initialize(ptr);
		}

		public void CalcVoronoi2D()
		{
			Cv.CalcSubdivVoronoi2D(this);
		}

		public void ClearVoronoi2D()
		{
			NativeMethods.cvClearSubdivVoronoi2D(ptr);
		}

		public CvSubdiv2DPoint FindNearestPoint2D(CvPoint2D32f pt)
		{
			return Cv.FindNearestPoint2D(this, pt);
		}

		public CvSubdiv2DPoint Insert(CvPoint2D32f pt)
		{
			return Cv.SubdivDelaunay2DInsert(this, pt);
		}

		public void InitSubdivDelaunay2D(CvRect rect)
		{
			Cv.InitSubdivDelaunay2D(this, rect);
		}

		public CvSubdiv2DPointLocation Locate(CvPoint2D32f pt, out CvSubdiv2DEdge edge)
		{
			return Cv.Subdiv2DLocate(this, pt, out edge);
		}

		public CvSubdiv2DPointLocation Locate(CvPoint2D32f pt, out CvSubdiv2DEdge edge, ref CvSubdiv2DPoint vertex)
		{
			return Cv.Subdiv2DLocate(this, pt, out edge, ref vertex);
		}
	}
}
