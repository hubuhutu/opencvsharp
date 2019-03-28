using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
	public class CvGraph : CvSet
	{
		public new static readonly int SizeOf = Marshal.SizeOf(typeof(WCvGraph));

		public unsafe CvSet Edges
		{
			get
			{
				IntPtr intPtr = new IntPtr(((WCvGraph*)(void*)ptr)->edges);
				if (intPtr != IntPtr.Zero)
				{
					return new CvSet(intPtr);
				}
				return null;
			}
		}

		protected CvGraph()
		{
			ptr = IntPtr.Zero;
		}

		public CvGraph(SeqType graphFlags, int vtxSize, int edgeSize, CvMemStorage storage)
			: this(graphFlags, vtxSize, edgeSize, storage, SizeOf)
		{
		}

		public CvGraph(SeqType graphFlags, int vtxSize, int edgeSize, CvMemStorage storage, int headerSize)
		{
			if (storage == null)
			{
				throw new ArgumentNullException();
			}
			IntPtr p = NativeMethods.cvCreateGraph(graphFlags, headerSize, vtxSize, edgeSize, storage.CvPtr);
			Initialize(p);
			holdingStorage = storage;
		}

		public CvGraph(IntPtr ptr)
		{
			Initialize(ptr);
		}

		public void ClearGraph()
		{
			Cv.ClearGraph(this);
		}

		public CvGraph CloneGraph(CvMemStorage storage)
		{
			return Cv.CloneGraph(this, storage);
		}

		public CvGraphEdge FindGraphEdge(int startIdx, int endIdx)
		{
			return Cv.FindGraphEdge(this, startIdx, endIdx);
		}

		public CvGraphEdge GraphFindEdge(int startIdx, int endIdx)
		{
			return Cv.GraphFindEdge(this, startIdx, endIdx);
		}

		public CvGraphEdge FindGraphEdgeByPtr(CvGraphVtx startVtx, CvGraphVtx endVtx)
		{
			return Cv.FindGraphEdgeByPtr(this, startVtx, endVtx);
		}

		public CvGraphEdge GraphFindEdgeByPtr(CvGraphVtx startVtx, CvGraphVtx endVtx)
		{
			return Cv.GraphFindEdgeByPtr(this, startVtx, endVtx);
		}

		public int GraphAddEdge(int startIdx, int endIdx)
		{
			return Cv.GraphAddEdge(this, startIdx, endIdx);
		}

		public int GraphAddEdge(int startIdx, int endIdx, CvGraphEdge edge)
		{
			return Cv.GraphAddEdge(this, startIdx, endIdx, edge);
		}

		public int GraphAddEdge(int startIdx, int endIdx, CvGraphEdge edge, IntPtr insertedEdge)
		{
			return Cv.GraphAddEdge(this, startIdx, endIdx, edge, insertedEdge);
		}

		public int GraphAddEdgeByPtr(CvGraphEdge startVtx, CvGraphEdge endVtx)
		{
			return Cv.GraphAddEdgeByPtr(this, startVtx, endVtx);
		}

		public int GraphAddEdgeByPtr(CvGraphEdge startVtx, CvGraphEdge endVtx, CvGraphEdge edge)
		{
			return Cv.GraphAddEdgeByPtr(this, startVtx, endVtx, edge);
		}

		public int GraphAddEdgeByPtr(CvGraphEdge startVtx, CvGraphEdge endVtx, CvGraphEdge edge, IntPtr insertedEdge)
		{
			return Cv.GraphAddEdgeByPtr(this, startVtx, endVtx, edge, insertedEdge);
		}

		public int GraphAddVtx()
		{
			return Cv.GraphAddVtx(this);
		}

		public int GraphAddVtx(CvGraphVtx vtx)
		{
			return Cv.GraphAddVtx(this, vtx);
		}

		public int GraphAddVtx(CvGraphVtx vtx, out CvGraphVtx insertedVtx)
		{
			return Cv.GraphAddVtx(this, vtx, out insertedVtx);
		}

		public int GraphEdgeIdx(CvGraphEdge edge)
		{
			return Cv.GraphEdgeIdx(this, edge);
		}

		public int GraphGetEdgeCount()
		{
			return Cv.GraphGetEdgeCount(this);
		}

		public int GraphGetVtxCount()
		{
			return Cv.GraphGetVtxCount(this);
		}

		public void GraphRemoveEdge(int startIdx, int endIdx)
		{
			Cv.GraphRemoveEdge(this, startIdx, endIdx);
		}

		public void GraphRemoveEdgeByPtr(CvGraphVtx startVtx, CvGraphVtx endVtx)
		{
			Cv.GraphRemoveEdgeByPtr(this, startVtx, endVtx);
		}

		public int GraphRemoveVtx(int index)
		{
			return Cv.GraphRemoveVtx(this, index);
		}

		public int GraphRemoveVtxByPtr(CvGraphVtx vtx)
		{
			return Cv.GraphRemoveVtxByPtr(this, vtx);
		}

		public int GraphVtxDegree(int vtxIdx)
		{
			return Cv.GraphVtxDegree(this, vtxIdx);
		}

		public int GraphVtxDegreeByPtr(CvGraphVtx vtx)
		{
			return Cv.GraphVtxDegreeByPtr(this, vtx);
		}

		public int GraphVtxIdx(CvGraphVtx vtx)
		{
			return Cv.GraphVtxIdx(this, vtx);
		}
	}
}
