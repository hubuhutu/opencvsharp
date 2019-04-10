using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	public class Subdiv2D : DisposableCvObject
	{
		private bool disposed;

		public const int PTLOC_ERROR = -2;

		public const int PTLOC_OUTSIDE_RECT = -1;

		public const int PTLOC_INSIDE = 0;

		public const int PTLOC_VERTEX = 1;

		public const int PTLOC_ON_EDGE = 2;

		public const int NEXT_AROUND_ORG = 0;

		public const int NEXT_AROUND_DST = 34;

		public const int PREV_AROUND_ORG = 17;

		public const int PREV_AROUND_DST = 51;

		public const int NEXT_AROUND_LEFT = 19;

		public const int NEXT_AROUND_RIGHT = 49;

		public const int PREV_AROUND_LEFT = 32;

		public const int PREV_AROUND_RIGHT = 2;

		public Subdiv2D()
		{
			ptr = NativeMethods.imgproc_Subdiv2D_new();
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public Subdiv2D(Rect rect)
		{
			ptr = NativeMethods.imgproc_Subdiv2D_new(rect);
			if (ptr == IntPtr.Zero)
			{
				throw new OpenCvSharpException();
			}
		}

		public void Release()
		{
			Dispose(disposing: true);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (ptr != IntPtr.Zero)
					{
						NativeMethods.imgproc_Subdiv2D_delete(ptr);
					}
					ptr = IntPtr.Zero;
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public void InitDelaunay(Rect rect)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			NativeMethods.imgproc_Subdiv2D_initDelaunay(ptr, rect);
		}

		public int Insert(Point2f pt)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			return NativeMethods.imgproc_Subdiv2D_insert(ptr, pt);
		}

		public void Insert(Point2f[] ptvec)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			if (ptvec == null)
			{
				throw new ArgumentNullException("ptvec");
			}
			NativeMethods.imgproc_Subdiv2D_insert(ptr, ptvec, ptvec.Length);
		}

		public void Insert(IEnumerable<Point2f> ptvec)
		{
			if (ptvec == null)
			{
				throw new ArgumentNullException("ptvec");
			}
			Insert(new List<Point2f>(ptvec).ToArray());
		}

		public int Locate(Point2f pt, out int edge, out int vertex)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			return NativeMethods.imgproc_Subdiv2D_locate(ptr, pt, out edge, out vertex);
		}

		public int FindNearest(Point2f pt)
		{
			Point2f nearestPt;
			return FindNearest(pt, out nearestPt);
		}

		public int FindNearest(Point2f pt, out Point2f nearestPt)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			return NativeMethods.imgproc_Subdiv2D_findNearest(ptr, pt, out nearestPt);
		}

		public Vec4f[] GetEdgeList()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
            IntPtr edgeList;
			NativeMethods.imgproc_Subdiv2D_getEdgeList(ptr, out  edgeList);
			using (VectorOfVec4f vectorOfVec4f = new VectorOfVec4f(edgeList))
			{
				return vectorOfVec4f.ToArray();
			}
		}

		public Vec6f[] GetTriangleList()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
            IntPtr triangleList;
            NativeMethods.imgproc_Subdiv2D_getTriangleList(ptr, out triangleList);
			using (VectorOfVec6f vectorOfVec6f = new VectorOfVec6f(triangleList))
			{
				return vectorOfVec6f.ToArray();
			}
		}

		public void GetVoronoiFacetList(IEnumerable<int> idx, out Point2f[][] facetList, out Point2f[] facetCenters)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			IntPtr facetList2;
			IntPtr facetCenters2;
			if (idx == null)
			{
				NativeMethods.imgproc_Subdiv2D_getVoronoiFacetList(ptr, IntPtr.Zero, 0, out facetList2, out facetCenters2);
			}
			else
			{
				int[] array = EnumerableEx.ToArray(idx);
				NativeMethods.imgproc_Subdiv2D_getVoronoiFacetList(ptr, array, array.Length, out facetList2, out facetCenters2);
			}
			using (VectorOfVectorPoint2f vectorOfVectorPoint2f = new VectorOfVectorPoint2f(facetList2))
			{
				facetList = vectorOfVectorPoint2f.ToArray();
			}
			using (VectorOfPoint2f vectorOfPoint2f = new VectorOfPoint2f(facetCenters2))
			{
				facetCenters = vectorOfPoint2f.ToArray();
			}
		}

		public Point2f GetVertex(int vertex)
		{
			int firstEdge;
			return GetVertex(vertex, out firstEdge);
		}

		public Point2f GetVertex(int vertex, out int firstEdge)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			return NativeMethods.imgproc_Subdiv2D_getVertex(ptr, vertex, out firstEdge);
		}

		public int GetEdge(int edge, int nextEdgeType)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			return NativeMethods.imgproc_Subdiv2D_getEdge(ptr, edge, nextEdgeType);
		}

		public int NextEdge(int edge)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			return NativeMethods.imgproc_Subdiv2D_nextEdge(ptr, edge);
		}

		public int RotateEdge(int edge, int rotate)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			return NativeMethods.imgproc_Subdiv2D_rotateEdge(ptr, edge, rotate);
		}

		public int SymEdge(int edge)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			return NativeMethods.imgproc_Subdiv2D_symEdge(ptr, edge);
		}

		public int EdgeOrg(int edge)
		{
			Point2f orgpt;
			return EdgeOrg(edge, out orgpt);
		}

		public int EdgeOrg(int edge, out Point2f orgpt)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			return NativeMethods.imgproc_Subdiv2D_edgeOrg(ptr, edge, out orgpt);
		}

		public int EdgeDst(int edge)
		{
			Point2f dstpt;
			return EdgeDst(edge, out dstpt);
		}

		public int EdgeDst(int edge, out Point2f dstpt)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Subdiv2D", "");
			}
			return NativeMethods.imgproc_Subdiv2D_edgeDst(ptr, edge, out dstpt);
		}
	}
}
