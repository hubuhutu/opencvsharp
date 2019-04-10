using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
	public class CvSet : CvSeq
	{
		public new static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSet));

		public unsafe CvSetElem FreeElems
		{
			get
			{
				IntPtr intPtr = new IntPtr(((WCvSet*)(void*)ptr)->free_elems);
				if (intPtr != IntPtr.Zero)
				{
					return new CvSetElem(intPtr);
				}
				return null;
			}
		}

        public unsafe int ActiveCount
        {
            get
            {
                return ((WCvSet*)(void*)ptr)->active_count;
            }
        }

		protected CvSet()
		{
			ptr = IntPtr.Zero;
		}

		public CvSet(SeqType setFlags, int headerSize, int elemSize, CvMemStorage storage)
		{
			if (storage == null)
			{
				throw new ArgumentNullException();
			}
			IntPtr p = NativeMethods.cvCreateSet(setFlags, headerSize, elemSize, storage.CvPtr);
			Initialize(p);
			holdingStorage = storage;
		}

		public CvSet(IntPtr ptr)
		{
			Initialize(ptr);
		}

		public void ClearSet()
		{
			Cv.ClearSet(this);
		}

		public CvSetElem GetSetElem(int index)
		{
			return Cv.GetSetElem(this, index);
		}

		public int SetAdd()
		{
			return Cv.SetAdd(this);
		}

		public int SetAdd(CvSetElem elem)
		{
			return Cv.SetAdd(this, elem);
		}

		public int SetAdd(CvSetElem elem, out CvSetElem insertedElem)
		{
			return Cv.SetAdd(this, elem, out insertedElem);
		}

		public CvSetElem SetNew()
		{
			return Cv.SetNew(this);
		}

		public void SetRemove(int index)
		{
			Cv.SetRemove(this, index);
		}

		public void SetRemoveByPtr(IntPtr elem)
		{
			Cv.SetRemoveByPtr(this, elem);
		}
	}
}
