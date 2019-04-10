using OpenCvSharp.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    public class CvSeq<T> : CvSeq, IEnumerable<T?>, IEnumerable where T : struct
    {
        public new CvSeq<T> HPrev
        {
            get
            {
                CvSeq hPrev = base.HPrev;
                if (hPrev == null)
                {
                    return null;
                }
                return new CvSeq<T>(hPrev);
            }
        }

        public new CvSeq<T> HNext
        {
            get
            {
                CvSeq hNext = base.HNext;
                if (hNext == null)
                {
                    return null;
                }
                return new CvSeq<T>(hNext);
            }
        }

        public new CvSeq<T> VPrev
        {
            get
            {
                CvSeq vPrev = base.VPrev;
                if (vPrev == null)
                {
                    return null;
                }
                return new CvSeq<T>(vPrev);
            }
        }

        public new CvSeq<T> VNext
        {
            get
            {
                CvSeq vNext = base.VNext;
                if (vNext == null)
                {
                    return null;
                }
                return new CvSeq<T>(vNext);
            }
        }

        public new T? this[int index]
        {
            get
            {
                return Cv.GetSeqElem(this, index);
            }
        }

        public CvSeq(SeqType seqFlags, CvMemStorage storage)
            : base(seqFlags, Util.SizeOf(typeof(T)), storage)
        {
        }

        public CvSeq(SeqType seqFlags, int headerSize, CvMemStorage storage)
            : base(seqFlags, headerSize, Util.SizeOf(typeof(T)), storage)
        {
        }

        public CvSeq(CvSeq seq)
            : base(seq.CvPtr)
        {
        }

        public CvSeq(IntPtr ptr)
            : base(ptr)
        {
        }

        public static CvSeq<T> FromArray(IEnumerable<T> array, SeqType seqFlags, CvMemStorage storage)
        {
            CvSeq<T> cvSeq = new CvSeq<T>(seqFlags, storage);
            foreach (T item in array)
            {
                Cv.SeqPush(cvSeq, item);
            }
            return cvSeq;
        }

        public new CvSeq<T> Clone()
        {
            return Cv.CloneSeq(this);
        }

        public new CvSeq<T> Clone(CvMemStorage storage)
        {
            return Cv.CloneSeq(this, storage);
        }

        public int ElemIdx(T element)
        {
            return Cv.SeqElemIdx(this, element);
        }

        public int ElemIdx(T element, out CvSeqBlock block)
        {
            return Cv.SeqElemIdx(this, element, out block);
        }

        public T? GetSeqElem(int index)
        {
            return Cv.GetSeqElem(this, index);
        }

        public virtual T Insert(int beforeIndex, T element)
        {
            return Cv.SeqInsert(this, beforeIndex, element);
        }

        public int Partition(CvMemStorage storage, out CvSeq labels, CvCmpFunc<T> isEqual)
        {
            return Cv.SeqPartition(this, storage, out labels, isEqual);
        }

        public virtual T Pop()
        {
            T element;
            Cv.SeqPop(this, out  element);
            return element;
        }

        public virtual T PopFront()
        {
            return base.PopFront<T>();
        }

        public T[] PopMulti(int count, InsertPosition inFront)
        {
            return PopMulti<T>(count, inFront);
        }

        public virtual T Push(T element)
        {
            return Cv.SeqPush(this, element);
        }

        public virtual T PushFront(T element)
        {
            return Cv.SeqPushFront(this, element);
        }

        public void PushMulti(T[] elements, InsertPosition inFront)
        {
            Cv.SeqPushMulti(this, elements, inFront);
        }

        public virtual T Search(T elem, CvCmpFunc<T> func, bool isSorted, out int elemIdx)
        {
            return Cv.SeqSearch(this, elem, func, isSorted, out elemIdx);
        }

        public new CvSeq<T> Slice(CvSlice slice)
        {
            return Cv.SeqSlice(this, slice);
        }

        public new CvSeq<T> Slice(CvSlice slice, CvMemStorage storage)
        {
            return Cv.SeqSlice(this, slice, storage);
        }

        public new CvSeq<T> Slice(CvSlice slice, CvMemStorage storage, bool copyData)
        {
            return Cv.SeqSlice(this, slice, storage, copyData);
        }

        public virtual void Sort(CvCmpFunc<T> func)
        {
            Cv.SeqSort(this, func);
        }

        public virtual void StartRead(CvSeqReader<T> reader)
        {
            Cv.StartReadSeq(this, reader);
        }

        public virtual void StartRead(CvSeqReader<T> reader, bool reverse)
        {
            Cv.StartReadSeq(this, reader, reverse);
        }

        public T[] ToArray()
        {
            T[] elements;
            return Cv.CvtSeqToArray(this, out elements);
        }

        public T[] ToArray(CvSlice slice)
        {
            T[] elements;
            return Cv.CvtSeqToArray(this, out elements, slice);
        }

        public CvSeq<CvPoint> ApproxPoly(int headerSize, CvMemStorage storage, ApproxPolyMethod method, double parameter)
        {
            if (typeof(T) == typeof(CvPoint))
            {
                return Cv.ApproxPoly(this as CvSeq<CvPoint>, headerSize, storage, method, parameter);
            }
            throw new InvalidOperationException("This instance must be CvSeq<CvPoint>");
        }

        public CvSeq<CvPoint> ApproxPoly(int headerSize, CvMemStorage storage, ApproxPolyMethod method, double parameter, bool parameter2)
        {
            if (typeof(T) == typeof(CvPoint))
            {
                return Cv.ApproxPoly(this as CvSeq<CvPoint>, headerSize, storage, method, parameter, parameter2);
            }
            throw new InvalidOperationException("This instance must be CvSeq<CvPoint>");
        }

        public IEnumerator<T?> GetEnumerator()
        {
            for (int i = 0; i < Total; i++)
            {
                yield return Cv.GetSeqElem(this, i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class CvSeq : CvTreeNode<CvSeq>, ICloneable
    {
        protected CvMemStorage holdingStorage;

        public new static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSeq));

        public unsafe override CvSeq HPrev
        {
            get
            {
                IntPtr intPtr = new IntPtr(((WCvSeq*)(void*)ptr)->h_prev);
                if (intPtr != IntPtr.Zero)
                {
                    return new CvSeq(intPtr);
                }
                return null;
            }
        }

        public unsafe override CvSeq HNext
        {
            get
            {
                IntPtr intPtr = new IntPtr(((WCvSeq*)(void*)ptr)->h_next);
                if (intPtr != IntPtr.Zero)
                {
                    return new CvSeq(intPtr);
                }
                return null;
            }
        }

        public unsafe override CvSeq VPrev
        {
            get
            {
                IntPtr intPtr = new IntPtr(((WCvSeq*)(void*)ptr)->v_prev);
                if (intPtr != IntPtr.Zero)
                {
                    return new CvSeq(intPtr);
                }
                return null;
            }
        }

        public unsafe override CvSeq VNext
        {
            get
            {
                IntPtr intPtr = new IntPtr(((WCvSeq*)(void*)ptr)->v_next);
                if (intPtr != IntPtr.Zero)
                {
                    return new CvSeq(intPtr);
                }
                return null;
            }
        }

        public unsafe int Total { get { return ((WCvSeq*)(void*)ptr)->total; } }

        public unsafe int ElemSize { get { return ((WCvSeq*)(void*)ptr)->elem_size; } }

        public unsafe IntPtr BlockMax { get { return new IntPtr(((WCvSeq*)(void*)ptr)->block_max); } }

        public unsafe IntPtr Ptr { get { return new IntPtr(((WCvSeq*)(void*)ptr)->ptr); } }

        public unsafe int DeltaElems
        {
            get
            {
                return ((WCvSeq*)(void*)ptr)->delta_elems;
            }
        }
        public unsafe CvMemStorage Storage
        {
            get
            {
                IntPtr intPtr = new IntPtr(((WCvSeq*)(void*)ptr)->storage);
                if (intPtr != IntPtr.Zero)
                {
                    return new CvMemStorage(intPtr, isEnabledDispose: false);
                }
                return null;
            }
        }

        public unsafe CvSeqBlock FreeBlocks
        {
            get
            {
                IntPtr intPtr = new IntPtr(((WCvSeq*)(void*)ptr)->storage);
                if (intPtr != IntPtr.Zero)
                {
                    return new CvSeqBlock(intPtr);
                }
                return null;
            }
        }

        public unsafe CvSeqBlock First
        {
            get
            {
                IntPtr intPtr = new IntPtr(((WCvSeq*)(void*)ptr)->first);
                if (intPtr != IntPtr.Zero)
                {
                    return new CvSeqBlock(intPtr);
                }
                return null;
            }
        }

        protected CvSeq()
        {
            ptr = IntPtr.Zero;
        }

        public CvSeq(SeqType seqFlags, int elemSize, CvMemStorage storage)
            : this(seqFlags, SizeOf, elemSize, storage)
        {
        }

        public CvSeq(SeqType seqFlags, int headerSize, int elemSize, CvMemStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException();
            }
            IntPtr p = NativeMethods.cvCreateSeq(seqFlags, headerSize, elemSize, storage.CvPtr);
            Initialize(p);
            holdingStorage = storage;
        }

        public CvSeq(IntPtr ptr)
        {
            Initialize(ptr);
        }

        public void CalcPGH(CvHistogram hist)
        {
            Cv.CalcPGH(this, hist);
        }

        public void ClearSeq()
        {
            Cv.ClearSeq(this);
        }

        public virtual CvSeq Clone()
        {
            return Cv.CloneSeq(this);
        }

        public virtual CvSeq Clone(CvMemStorage storage)
        {
            return Cv.CloneSeq(this, storage);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public CvMoments ContoursMoments()
        {
            CvMoments moments;
            Cv.ContoursMoments(this, out  moments);
            return moments;
        }

        public CvContourTree CreateContourTree(CvMemStorage storage, double threshold)
        {
            return Cv.CreateContourTree(this, storage, threshold);
        }

        public int ElemIdx<T>(T element) where T : struct
        {
            return Cv.SeqElemIdx(this, element);
        }

        public int ElemIdx<T>(T element, out CvSeqBlock block) where T : struct
        {
            return Cv.SeqElemIdx(this, element, out block);
        }

        public T? GetSeqElem<T>(int index) where T : struct
        {
            return Cv.GetSeqElem<T>(this, index);
        }

        public virtual T Insert<T>(int beforeIndex, T element) where T : struct
        {
            return Cv.SeqInsert(this, beforeIndex, element);
        }

        public virtual void InsertSlice(int beforeIndex, CvArr fromArr)
        {
            Cv.SeqInsertSlice(this, beforeIndex, fromArr);
        }

        public void Invert()
        {
            Cv.SeqInvert(this);
        }

        public virtual void Remove(int index)
        {
            Cv.SeqRemove(this, index);
        }

        public void RemoveSlice(CvSlice slice)
        {
            Cv.SeqRemoveSlice(this, slice);
        }

        public int Partition(CvMemStorage storage, out CvSeq labels, CvCmpFunc isEqual)
        {
            return Cv.SeqPartition(this, storage, out labels, isEqual);
        }

        public virtual T Pop<T>() where T : struct
        {
            T element;
            Cv.SeqPop(this, out  element);
            return element;
        }

        public virtual T PopFront<T>() where T : struct
		{
            T element;
			Cv.SeqPopFront(this, out  element);
			return element;
		}

        public T[] PopMulti<T>(int count, InsertPosition inFront) where T : struct
		{
            T[] elements;
			Cv.SeqPopMulti(this, out elements, count, inFront);
			return elements;
		}

        public virtual IntPtr Push()
        {
            return Cv.SeqPush(this);
        }

        public virtual T Push<T>(T element) where T : struct
        {
            return Cv.SeqPush(this, element);
        }

        public virtual T PushFront<T>(T element) where T : struct
        {
            return Cv.SeqPushFront(this, element);
        }

        public void PushMulti<T>(T[] elements, InsertPosition inFront) where T : struct
        {
            Cv.SeqPushMulti(this, elements, inFront);
        }

        public virtual IntPtr Search(IntPtr elem, CvCmpFunc func, bool isSorted, out int elemIdx)
        {
            return Cv.SeqSearch(this, elem, func, isSorted, out elemIdx);
        }

        public virtual void SetBlockSize(int deltaElems)
        {
            Cv.SetSeqBlockSize(this, deltaElems);
        }

        public virtual CvSeq Slice(CvSlice slice)
        {
            return Cv.SeqSlice(this, slice);
        }

        public virtual CvSeq Slice(CvSlice slice, CvMemStorage storage)
        {
            return Cv.SeqSlice(this, slice, storage);
        }

        public virtual CvSeq Slice(CvSlice slice, CvMemStorage storage, bool copyData)
        {
            return Cv.SeqSlice(this, slice, storage, copyData);
        }

        public virtual void Sort(CvCmpFunc func)
        {
            Cv.SeqSort(this, func);
        }

        public CvSeqWriter StartAppend()
		{
            CvSeqWriter writer;
			Cv.StartAppendToSeq(this, out  writer);
			return writer;
		}

        public virtual void StartRead(CvSeqReader reader)
        {
            Cv.StartReadSeq(this, reader);
        }

        public virtual void StartRead(CvSeqReader reader, bool reverse)
        {
            Cv.StartReadSeq(this, reader, reverse);
        }

        public T[] ToArray<T>() where T : struct
        {
            T[] elements;
            return Cv.CvtSeqToArray(this, out elements);
        }

        public T[] ToArray<T>(CvSlice slice) where T : struct
        {
            T[] elements;
            return Cv.CvtSeqToArray(this, out elements, slice);
        }
    }
}
