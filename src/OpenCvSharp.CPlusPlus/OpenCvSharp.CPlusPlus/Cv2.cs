using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    public static partial class Cv2
    {
        public const int GC_BGD = 0;

        public const int GC_FGD = 1;

        public const int GC_PR_BGD = 2;

        public const int GC_PR_FGD = 3;

        internal static IntPtr ToPtr(ICvPtrHolder obj)
        {
            return obj != null ? obj.CvPtr : IntPtr.Zero;
        }

        public static void GroupRectangles(IList<Rect> rectList, int groupThreshold, double eps = 0.2)
        {
            if (rectList == null)
            {
                throw new ArgumentNullException("rectList");
            }
            using (VectorOfRect vectorOfRect = new VectorOfRect(rectList))
            {
                NativeMethods.objdetect_groupRectangles1(vectorOfRect.CvPtr, groupThreshold, eps);
                ClearAndAddRange(rectList, vectorOfRect.ToArray());
            }
        }

        public static void GroupRectangles(IList<Rect> rectList, out int[] weights, int groupThreshold, double eps = 0.2)
        {
            if (rectList == null)
            {
                throw new ArgumentNullException("rectList");
            }
            using (VectorOfRect vectorOfRect = new VectorOfRect(rectList))
            {
                using (VectorOfInt32 vectorOfInt = new VectorOfInt32())
                {
                    NativeMethods.objdetect_groupRectangles2(vectorOfRect.CvPtr, vectorOfInt.CvPtr, groupThreshold, eps);
                    ClearAndAddRange(rectList, vectorOfRect.ToArray());
                    weights = vectorOfInt.ToArray();
                }
            }
        }

        public static void GroupRectangles(IList<Rect> rectList, int groupThreshold, double eps, out int[] weights, out double[] levelWeights)
        {
            if (rectList == null)
            {
                throw new ArgumentNullException("rectList");
            }
            using (VectorOfRect vectorOfRect = new VectorOfRect(rectList))
            {
                using (VectorOfInt32 vectorOfInt = new VectorOfInt32())
                {
                    using (VectorOfDouble vectorOfDouble = new VectorOfDouble())
                    {
                        NativeMethods.objdetect_groupRectangles3(vectorOfRect.CvPtr, groupThreshold, eps, vectorOfInt.CvPtr, vectorOfDouble.CvPtr);
                        ClearAndAddRange(rectList, vectorOfRect.ToArray());
                        weights = vectorOfInt.ToArray();
                        levelWeights = vectorOfDouble.ToArray();
                    }
                }
            }
        }

        public static void GroupRectangles(IList<Rect> rectList, out int[] rejectLevels, out double[] levelWeights, int groupThreshold, double eps = 0.2)
        {
            if (rectList == null)
            {
                throw new ArgumentNullException("rectList");
            }
            using (VectorOfRect vectorOfRect = new VectorOfRect(rectList))
            {
                using (VectorOfInt32 vectorOfInt = new VectorOfInt32())
                {
                    using (VectorOfDouble vectorOfDouble = new VectorOfDouble())
                    {
                        NativeMethods.objdetect_groupRectangles4(vectorOfRect.CvPtr, vectorOfInt.CvPtr, vectorOfDouble.CvPtr, groupThreshold, eps);
                        ClearAndAddRange(rectList, vectorOfRect.ToArray());
                        rejectLevels = vectorOfInt.ToArray();
                        levelWeights = vectorOfDouble.ToArray();
                    }
                }
            }
        }

        public static void GroupRectanglesMeanshift(IList<Rect> rectList, out double[] foundWeights, out double[] foundScales, double detectThreshold = 0.0, Size? winDetSize = default(Size?))
        {
            if (rectList == null)
            {
                throw new ArgumentNullException("rectList");
            }
            Size valueOrDefault = winDetSize.GetValueOrDefault(new Size(64, 128));
            using (VectorOfRect vectorOfRect = new VectorOfRect(rectList))
            {
                using (VectorOfDouble vectorOfDouble = new VectorOfDouble())
                {
                    using (VectorOfDouble vectorOfDouble2 = new VectorOfDouble())
                    {
                        NativeMethods.objdetect_groupRectangles_meanshift(vectorOfRect.CvPtr, vectorOfDouble.CvPtr, vectorOfDouble2.CvPtr, detectThreshold, valueOrDefault);
                        ClearAndAddRange(rectList, vectorOfRect.ToArray());
                        foundWeights = vectorOfDouble.ToArray();
                        foundScales = vectorOfDouble2.ToArray();
                    }
                }
            }
        }

        private static void ClearAndAddRange<T>(IList<T> list, IEnumerable<T> values)
        {
            list.Clear();
            foreach (T value in values)
            {
                list.Add(value);
            }
        }

        public static void FAST(InputArray image, out KeyPoint[] keypoints, int threshold, bool nonmaxSupression = true)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            image.ThrowIfDisposed();
            using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_FAST(image.CvPtr, vectorOfKeyPoint.CvPtr, threshold, nonmaxSupression ? 1 : 0);
                keypoints = vectorOfKeyPoint.ToArray();
            }
        }

        public static void FASTX(InputArray image, out KeyPoint[] keypoints, int threshold, bool nonmaxSupression, int type)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            image.ThrowIfDisposed();
            using (VectorOfKeyPoint vectorOfKeyPoint = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_FASTX(image.CvPtr, vectorOfKeyPoint.CvPtr, threshold, nonmaxSupression ? 1 : 0, type);
                keypoints = vectorOfKeyPoint.ToArray();
            }
        }

        public static void DrawKeypoints(Mat image, IEnumerable<KeyPoint> keypoints, Mat outImage, Scalar? color = default(Scalar?), DrawMatchesFlags flags = DrawMatchesFlags.Default)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (outImage == null)
            {
                throw new ArgumentNullException("outImage");
            }
            if (keypoints == null)
            {
                throw new ArgumentNullException("keypoints");
            }
            image.ThrowIfDisposed();
            outImage.ThrowIfDisposed();
            KeyPoint[] array = EnumerableEx.ToArray(keypoints);
            Scalar valueOrDefault = color.GetValueOrDefault(Scalar.All(-1.0));
            NativeMethods.features2d_drawKeypoints(image.CvPtr, array, array.Length, outImage.CvPtr, valueOrDefault, (int)flags);
        }

        public static void DrawMatches(Mat img1, IEnumerable<KeyPoint> keypoints1, Mat img2, IEnumerable<KeyPoint> keypoints2, IEnumerable<DMatch> matches1To2, Mat outImg, Scalar? matchColor = default(Scalar?), Scalar? singlePointColor = default(Scalar?), IEnumerable<byte> matchesMask = null, DrawMatchesFlags flags = DrawMatchesFlags.Default)
        {
            if (img1 == null)
            {
                throw new ArgumentNullException("img1");
            }
            if (img2 == null)
            {
                throw new ArgumentNullException("img2");
            }
            if (outImg == null)
            {
                throw new ArgumentNullException("outImg");
            }
            if (keypoints1 == null)
            {
                throw new ArgumentNullException("keypoints1");
            }
            if (keypoints2 == null)
            {
                throw new ArgumentNullException("keypoints2");
            }
            if (matches1To2 == null)
            {
                throw new ArgumentNullException("matches1To2");
            }
            img1.ThrowIfDisposed();
            img2.ThrowIfDisposed();
            outImg.ThrowIfDisposed();
            KeyPoint[] array = EnumerableEx.ToArray(keypoints1);
            KeyPoint[] array2 = EnumerableEx.ToArray(keypoints2);
            DMatch[] array3 = EnumerableEx.ToArray(matches1To2);
            Scalar valueOrDefault = matchColor.GetValueOrDefault(Scalar.All(-1.0));
            Scalar valueOrDefault2 = singlePointColor.GetValueOrDefault(Scalar.All(-1.0));
            byte[] array4 = null;
            int matchesMaskLength = 0;
            if (matchesMask != null)
            {
                array4 = EnumerableEx.ToArray(matchesMask);
                matchesMaskLength = array4.Length;
            }
            NativeMethods.features2d_drawMatches1(img1.CvPtr, array, array.Length, img2.CvPtr, array2, array2.Length, array3, array3.Length, outImg.CvPtr, valueOrDefault, valueOrDefault2, array4, matchesMaskLength, (int)flags);
        }

        public static void DrawMatches(Mat img1, IEnumerable<KeyPoint> keypoints1, Mat img2, IEnumerable<KeyPoint> keypoints2, IEnumerable<IEnumerable<DMatch>> matches1To2, Mat outImg, Scalar? matchColor = default(Scalar?), Scalar? singlePointColor = default(Scalar?), IEnumerable<IEnumerable<byte>> matchesMask = null, DrawMatchesFlags flags = DrawMatchesFlags.Default)
        {
            if (img1 == null)
            {
                throw new ArgumentNullException("img1");
            }
            if (img2 == null)
            {
                throw new ArgumentNullException("img2");
            }
            if (outImg == null)
            {
                throw new ArgumentNullException("outImg");
            }
            if (keypoints1 == null)
            {
                throw new ArgumentNullException("keypoints1");
            }
            if (keypoints2 == null)
            {
                throw new ArgumentNullException("keypoints2");
            }
            if (matches1To2 == null)
            {
                throw new ArgumentNullException("matches1To2");
            }
            img1.ThrowIfDisposed();
            img2.ThrowIfDisposed();
            outImg.ThrowIfDisposed();
            KeyPoint[] array = EnumerableEx.ToArray(keypoints1);
            KeyPoint[] array2 = EnumerableEx.ToArray(keypoints2);
            DMatch[][] array3 = EnumerableEx.SelectToArray(matches1To2, EnumerableEx.ToArray<DMatch>);
            int matches1to2Size = array3.Length;
            int[] matches1to2Size2 = EnumerableEx.SelectToArray(array3, (DMatch[] dm) => dm.Length);
            Scalar valueOrDefault = matchColor.GetValueOrDefault(Scalar.All(-1.0));
            Scalar valueOrDefault2 = singlePointColor.GetValueOrDefault(Scalar.All(-1.0));
            using (ArrayAddress2<DMatch> arrayAddress = new ArrayAddress2<DMatch>(array3))
            {
                if (matchesMask == null)
                {
                    NativeMethods.features2d_drawMatches2(img1.CvPtr, array, array.Length, img2.CvPtr, array2, array2.Length, arrayAddress, matches1to2Size, matches1to2Size2, outImg.CvPtr, valueOrDefault, valueOrDefault2, null, 0, null, (int)flags);
                }
                else
                {
                    byte[][] array4 = EnumerableEx.SelectToArray(matchesMask, EnumerableEx.ToArray<byte>);
                    int matchesMaskSize = array3.Length;
                    int[] matchesMaskSize2 = EnumerableEx.SelectToArray(array4, (byte[] dm) => dm.Length);
                    using (ArrayAddress2<byte> self = new ArrayAddress2<byte>(array4))
                    {
                        NativeMethods.features2d_drawMatches2(img1.CvPtr, array, array.Length, img2.CvPtr, array2, array2.Length, arrayAddress.Pointer, matches1to2Size, matches1to2Size2, outImg.CvPtr, valueOrDefault, valueOrDefault2, self, matchesMaskSize, matchesMaskSize2, (int)flags);
                    }
                }
            }
        }

        public static bool InitModule_ML()
        {
            return NativeMethods.ml_initModule_ml() != 0;
        }

        public static bool InitModule_Contrib()
        {
            return NativeMethods.contrib_initModule_contrib() != 0;
        }

        public static int ChamferMatching(Mat img, Mat templ, out Point[][] results, out float[] cost, double templScale = 1.0, int maxMatches = 20, double minMatchDistance = 1.0, int padX = 3, int padY = 3, int scales = 5, double minScale = 0.6, double maxScale = 1.6, double orientationWeight = 0.5, double truncate = 20.0)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            if (templ == null)
            {
                throw new ArgumentNullException("templ");
            }
            img.ThrowIfDisposed();
            templ.ThrowIfDisposed();
            using (VectorOfVectorPoint vectorOfVectorPoint = new VectorOfVectorPoint())
            {
                using (VectorOfFloat vectorOfFloat = new VectorOfFloat())
                {
                    int result = NativeMethods.contrib_chamerMatching(img.CvPtr, templ.CvPtr, vectorOfVectorPoint.CvPtr, vectorOfFloat.CvPtr, templScale, maxMatches, minMatchDistance, padX, padY, scales, minScale, maxScale, orientationWeight, truncate);
                    GC.KeepAlive(img);
                    GC.KeepAlive(templ);
                    results = vectorOfVectorPoint.ToArray();
                    cost = vectorOfFloat.ToArray();
                    return result;
                }
            }
        }

        public static void ApplyColorMap(InputArray src, OutputArray dst, ColorMapMode colormap)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.contrib_applyColorMap(src.CvPtr, dst.CvPtr, (int)colormap);
            dst.Fix();
            GC.KeepAlive(src);
        }

        public static void Inpaint(InputArray src, InputArray inpaintMask, OutputArray dst, double inpaintRadius, InpaintMethod flags)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (inpaintMask == null)
            {
                throw new ArgumentNullException("inpaintMask");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            inpaintMask.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.photo_inpaint(src.CvPtr, inpaintMask.CvPtr, dst.CvPtr, inpaintRadius, (int)flags);
            dst.Fix();
        }

        public static void FastNlMeansDenoising(InputArray src, OutputArray dst, float h = 3f, int templateWindowSize = 7, int searchWindowSize = 21)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.photo_fastNlMeansDenoising(src.CvPtr, dst.CvPtr, h, templateWindowSize, searchWindowSize);
            dst.Fix();
        }

        public static void FastNlMeansDenoisingColored(InputArray src, OutputArray dst, float h = 3f, float hColor = 3f, int templateWindowSize = 7, int searchWindowSize = 21)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.photo_fastNlMeansDenoisingColored(src.CvPtr, dst.CvPtr, h, hColor, templateWindowSize, searchWindowSize);
            dst.Fix();
        }

        public static void FastNlMeansDenoisingMulti(IEnumerable<InputArray> srcImgs, OutputArray dst, int imgToDenoiseIndex, int temporalWindowSize, float h = 3f, int templateWindowSize = 7, int searchWindowSize = 21)
        {
            if (srcImgs == null)
            {
                throw new ArgumentNullException("srcImgs");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            dst.ThrowIfNotReady();
            IntPtr[] array = EnumerableEx.SelectPtrs(srcImgs);
            NativeMethods.photo_fastNlMeansDenoisingMulti(array, array.Length, dst.CvPtr, imgToDenoiseIndex, templateWindowSize, h, templateWindowSize, searchWindowSize);
            dst.Fix();
        }

        public static void FastNlMeansDenoisingMulti(IEnumerable<Mat> srcImgs, OutputArray dst, int imgToDenoiseIndex, int temporalWindowSize, float h = 3f, int templateWindowSize = 7, int searchWindowSize = 21)
        {
            FastNlMeansDenoisingMulti(EnumerableEx.Select(srcImgs, (Mat m) => new InputArray(m)), dst, imgToDenoiseIndex, templateWindowSize, h, templateWindowSize, searchWindowSize);
        }

        public static void FastNlMeansDenoisingColoredMulti(IEnumerable<InputArray> srcImgs, OutputArray dst, int imgToDenoiseIndex, int temporalWindowSize, float h = 3f, float hColor = 3f, int templateWindowSize = 7, int searchWindowSize = 21)
        {
            if (srcImgs == null)
            {
                throw new ArgumentNullException("srcImgs");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            dst.ThrowIfNotReady();
            IntPtr[] array = EnumerableEx.SelectPtrs(srcImgs);
            NativeMethods.photo_fastNlMeansDenoisingColoredMulti(array, array.Length, dst.CvPtr, imgToDenoiseIndex, templateWindowSize, h, hColor, templateWindowSize, searchWindowSize);
            dst.Fix();
        }

        public static void FastNlMeansDenoisingColoredMulti(IEnumerable<Mat> srcImgs, OutputArray dst, int imgToDenoiseIndex, int temporalWindowSize, float h = 3f, float hColor = 3f, int templateWindowSize = 7, int searchWindowSize = 21)
        {
            FastNlMeansDenoisingColoredMulti(EnumerableEx.Select(srcImgs, (Mat m) => new InputArray(m)), dst, imgToDenoiseIndex, templateWindowSize, h, hColor, templateWindowSize, searchWindowSize);
        }

        public static bool InitModule_NonFree()
        {
            return NativeMethods.nonfree_initModule_nonfree() != 0;
        }

        public static void InitModule_Video()
        {
            NativeMethods.video_initModule_video();
        }

        public static void UpdateMotionHistory(InputArray silhouette, InputOutputArray mhi, double timestamp, double duration)
        {
            if (silhouette == null)
            {
                throw new ArgumentNullException("silhouette");
            }
            if (mhi == null)
            {
                throw new ArgumentNullException("mhi");
            }
            silhouette.ThrowIfDisposed();
            mhi.ThrowIfNotReady();
            NativeMethods.video_updateMotionHistory(silhouette.CvPtr, mhi.CvPtr, timestamp, duration);
            mhi.Fix();
        }

        public static void CalcMotionGradient(InputArray mhi, OutputArray mask, OutputArray orientation, double delta1, double delta2, int apertureSize = 3)
        {
            if (mhi == null)
            {
                throw new ArgumentNullException("mhi");
            }
            if (mask == null)
            {
                throw new ArgumentNullException("mask");
            }
            if (orientation == null)
            {
                throw new ArgumentNullException("orientation");
            }
            mhi.ThrowIfDisposed();
            mask.ThrowIfNotReady();
            orientation.ThrowIfNotReady();
            NativeMethods.video_calcMotionGradient(mhi.CvPtr, mask.CvPtr, orientation.CvPtr, delta1, delta2, apertureSize);
            mask.Fix();
            orientation.Fix();
        }

        public static double CalcGlobalOrientation(InputArray orientation, InputArray mask, InputArray mhi, double timestamp, double duration)
        {
            if (orientation == null)
            {
                throw new ArgumentNullException("orientation");
            }
            if (mask == null)
            {
                throw new ArgumentNullException("mask");
            }
            if (mhi == null)
            {
                throw new ArgumentNullException("mhi");
            }
            orientation.ThrowIfDisposed();
            mask.ThrowIfDisposed();
            mhi.ThrowIfDisposed();
            return NativeMethods.video_calcGlobalOrientation(orientation.CvPtr, mask.CvPtr, mhi.CvPtr, timestamp, duration);
        }

        public static void SegmentMotion(InputArray mhi, OutputArray segmask, out Rect[] boundingRects, double timestamp, double segThresh)
        {
            if (mhi == null)
            {
                throw new ArgumentNullException("mhi");
            }
            if (segmask == null)
            {
                throw new ArgumentNullException("segmask");
            }
            mhi.ThrowIfDisposed();
            segmask.ThrowIfNotReady();
            using (VectorOfRect vectorOfRect = new VectorOfRect())
            {
                NativeMethods.video_segmentMotion(mhi.CvPtr, segmask.CvPtr, vectorOfRect.CvPtr, timestamp, segThresh);
                boundingRects = vectorOfRect.ToArray();
            }
            segmask.Fix();
        }

        public static RotatedRect CamShift(InputArray probImage, ref Rect window, TermCriteria criteria)
        {
            if (probImage == null)
            {
                throw new ArgumentNullException("probImage");
            }
            probImage.ThrowIfDisposed();
            CvRect window2 = window;
            RotatedRect result = NativeMethods.video_CamShift(probImage.CvPtr, ref window2, criteria);
            window = window2;
            return result;
        }

        public static int MeanShift(InputArray probImage, ref Rect window, TermCriteria criteria)
        {
            if (probImage == null)
            {
                throw new ArgumentNullException("probImage");
            }
            probImage.ThrowIfDisposed();
            CvRect window2 = window;
            int result = NativeMethods.video_meanShift(probImage.CvPtr, ref window2, criteria);
            window = window2;
            return result;
        }

        public static int BuildOpticalFlowPyramid(InputArray img, OutputArray pyramid, Size winSize, int maxLevel, bool withDerivatives = true, BorderType pyrBorder = BorderType.Reflect101, BorderType derivBorder = BorderType.Constant, bool tryReuseInputImage = true)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            if (pyramid == null)
            {
                throw new ArgumentNullException("pyramid");
            }
            img.ThrowIfDisposed();
            pyramid.ThrowIfNotReady();
            int result = NativeMethods.video_buildOpticalFlowPyramid1(img.CvPtr, pyramid.CvPtr, winSize, maxLevel, withDerivatives ? 1 : 0, (int)pyrBorder, (int)derivBorder, tryReuseInputImage ? 1 : 0);
            pyramid.Fix();
            return result;
        }

        public static int BuildOpticalFlowPyramid(InputArray img, out Mat[] pyramid, Size winSize, int maxLevel, bool withDerivatives = true, BorderType pyrBorder = BorderType.Reflect101, BorderType derivBorder = BorderType.Constant, bool tryReuseInputImage = true)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            img.ThrowIfDisposed();
            using (VectorOfMat vectorOfMat = new VectorOfMat())
            {
                int result = NativeMethods.video_buildOpticalFlowPyramid1(img.CvPtr, vectorOfMat.CvPtr, winSize, maxLevel, withDerivatives ? 1 : 0, (int)pyrBorder, (int)derivBorder, tryReuseInputImage ? 1 : 0);
                pyramid = vectorOfMat.ToArray();
                return result;
            }
        }

        public static void CalcOpticalFlowPyrLK(InputArray prevImg, InputArray nextImg, InputArray prevPts, InputOutputArray nextPts, OutputArray status, OutputArray err, Size? winSize = default(Size?), int maxLevel = 3, TermCriteria? criteria = default(TermCriteria?), OpticalFlowFlags flags = OpticalFlowFlags.None, double minEigThreshold = 0.0001)
        {
            if (prevImg == null)
            {
                throw new ArgumentNullException("prevImg");
            }
            if (nextImg == null)
            {
                throw new ArgumentNullException("nextImg");
            }
            if (prevPts == null)
            {
                throw new ArgumentNullException("prevPts");
            }
            if (nextPts == null)
            {
                throw new ArgumentNullException("nextPts");
            }
            if (status == null)
            {
                throw new ArgumentNullException("status");
            }
            if (err == null)
            {
                throw new ArgumentNullException("err");
            }
            prevImg.ThrowIfDisposed();
            nextImg.ThrowIfDisposed();
            prevPts.ThrowIfDisposed();
            nextPts.ThrowIfNotReady();
            status.ThrowIfNotReady();
            err.ThrowIfNotReady();
            Size valueOrDefault = winSize.GetValueOrDefault(new Size(21, 21));
            TermCriteria valueOrDefault2 = criteria.GetValueOrDefault(TermCriteria.Both(30, 0.01));
            NativeMethods.video_calcOpticalFlowPyrLK_InputArray(prevImg.CvPtr, nextImg.CvPtr, prevPts.CvPtr, nextPts.CvPtr, status.CvPtr, err.CvPtr, valueOrDefault, maxLevel, valueOrDefault2, (int)flags, minEigThreshold);
            nextPts.Fix();
            status.Fix();
            err.Fix();
        }

        public static void CalcOpticalFlowPyrLK(InputArray prevImg, InputArray nextImg, Point2f[] prevPts, ref Point2f[] nextPts, out byte[] status, out float[] err, Size? winSize = default(Size?), int maxLevel = 3, TermCriteria? criteria = default(TermCriteria?), OpticalFlowFlags flags = OpticalFlowFlags.None, double minEigThreshold = 0.0001)
        {
            if (prevImg == null)
            {
                throw new ArgumentNullException("prevImg");
            }
            if (nextImg == null)
            {
                throw new ArgumentNullException("nextImg");
            }
            if (prevPts == null)
            {
                throw new ArgumentNullException("prevPts");
            }
            if (nextPts == null)
            {
                throw new ArgumentNullException("nextPts");
            }
            prevImg.ThrowIfDisposed();
            nextImg.ThrowIfDisposed();
            Size valueOrDefault = winSize.GetValueOrDefault(new Size(21, 21));
            TermCriteria valueOrDefault2 = criteria.GetValueOrDefault(TermCriteria.Both(30, 0.01));
            using (VectorOfPoint2f vectorOfPoint2f = new VectorOfPoint2f())
            {
                using (VectorOfByte vectorOfByte = new VectorOfByte())
                {
                    using (VectorOfFloat vectorOfFloat = new VectorOfFloat())
                    {
                        NativeMethods.video_calcOpticalFlowPyrLK_vector(prevImg.CvPtr, nextImg.CvPtr, prevPts, prevPts.Length, vectorOfPoint2f.CvPtr, vectorOfByte.CvPtr, vectorOfFloat.CvPtr, valueOrDefault, maxLevel, valueOrDefault2, (int)flags, minEigThreshold);
                        nextPts = vectorOfPoint2f.ToArray();
                        status = vectorOfByte.ToArray();
                        err = vectorOfFloat.ToArray();
                    }
                }
            }
        }

        public static void CalcOpticalFlowFarneback(InputArray prev, InputArray next, InputOutputArray flow, double pyrScale, int levels, int winsize, int iterations, int polyN, double polySigma, OpticalFlowFlags flags)
        {
            if (prev == null)
            {
                throw new ArgumentNullException("prev");
            }
            if (next == null)
            {
                throw new ArgumentNullException("next");
            }
            if (flow == null)
            {
                throw new ArgumentNullException("flow");
            }
            prev.ThrowIfDisposed();
            next.ThrowIfDisposed();
            flow.ThrowIfNotReady();
            NativeMethods.video_calcOpticalFlowFarneback(prev.CvPtr, next.CvPtr, flow.CvPtr, pyrScale, levels, winsize, iterations, polyN, polySigma, (int)flags);
            flow.Fix();
        }

        public static Mat EstimateRigidTransform(InputArray src, InputArray dst, bool fullAffine)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            return new Mat(NativeMethods.video_estimateRigidTransform(src.CvPtr, dst.CvPtr, fullAffine ? 1 : 0));
        }

        public static void CalcOpticalFlowSF(Mat from, Mat to, Mat flow, int layers, int averagingBlockSize, int maxFlow)
        {
            if (from == null)
            {
                throw new ArgumentNullException("from");
            }
            if (to == null)
            {
                throw new ArgumentNullException("to");
            }
            if (flow == null)
            {
                throw new ArgumentNullException("flow");
            }
            from.ThrowIfDisposed();
            to.ThrowIfDisposed();
            flow.ThrowIfDisposed();
            NativeMethods.video_calcOpticalFlowSF1(from.CvPtr, to.CvPtr, flow.CvPtr, layers, averagingBlockSize, maxFlow);
        }

        public static void CalcOpticalFlowSF(Mat from, Mat to, Mat flow, int layers, int averagingBlockSize, int maxFlow, double sigmaDist, double sigmaColor, int postprocessWindow, double sigmaDistFix, double sigmaColorFix, double occThr, int upscaleAveragingRadius, double upscaleSigmaDist, double upscaleSigmaColor, double speedUpThr)
        {
            if (from == null)
            {
                throw new ArgumentNullException("from");
            }
            if (to == null)
            {
                throw new ArgumentNullException("to");
            }
            if (flow == null)
            {
                throw new ArgumentNullException("flow");
            }
            from.ThrowIfDisposed();
            to.ThrowIfDisposed();
            flow.ThrowIfDisposed();
            NativeMethods.video_calcOpticalFlowSF2(from.CvPtr, to.CvPtr, flow.CvPtr, layers, averagingBlockSize, maxFlow, sigmaDist, sigmaColor, postprocessWindow, sigmaDistFix, sigmaColorFix, occThr, upscaleAveragingRadius, upscaleSigmaDist, upscaleSigmaColor, speedUpThr);
        }

        public static DenseOpticalFlow CreateOptFlow_DualTVL1()
        {
            return DenseOpticalFlow.CreateOptFlow_DualTVL1();
        }

        public static FrameSource CreateFrameSource_Empty()
        {
            return FrameSource.CreateEmptySource();
        }

        public static FrameSource CreateFrameSource_Video(string fileName)
        {
            return FrameSource.CreateVideoSource(fileName);
        }

        public static FrameSource CreateFrameSource_Video_GPU(string fileName)
        {
            return FrameSource.CreateVideoSourceGpu(fileName);
        }

        public static FrameSource CreateFrameSource_Camera(int deviceId)
        {
            return FrameSource.CreateCameraSource(deviceId);
        }

        public static SuperResolution CreateSuperResolution_BTVL1()
        {
            return SuperResolution.CreateBTVL1();
        }

        public static SuperResolution CreateSuperResolution_BTVL1_GPU()
        {
            return SuperResolution.CreateBTVL1_GPU();
        }

        public static SuperResolution CreateSuperResolution_BTVL1_OCL()
        {
            return SuperResolution.CreateBTVL1_OCL();
        }

        public static DenseOpticalFlowExt CreateOptFlow_Farneback()
        {
            return DenseOpticalFlowExt.CreateFarneback();
        }

        public static DenseOpticalFlowExt CreateOptFlow_Farneback_GPU()
        {
            return DenseOpticalFlowExt.CreateFarneback_GPU();
        }

        public static DenseOpticalFlowExt CreateOptFlow_Farneback_OCL()
        {
            return DenseOpticalFlowExt.CreateFarneback_OCL();
        }

        public static DenseOpticalFlowExt CreateOptFlow_Simple()
        {
            return DenseOpticalFlowExt.CreateSimple();
        }

        public static DenseOpticalFlowExt CreateOptFlow_DualTVL1Ex()
        {
            return DenseOpticalFlowExt.CreateDualTVL1();
        }

        public static DenseOpticalFlowExt CreateOptFlow_DualTVL1_GPU()
        {
            return DenseOpticalFlowExt.CreateDualTVL1_GPU();
        }

        public static DenseOpticalFlowExt CreateOptFlow_DualTVL1_OCL()
        {
            return DenseOpticalFlowExt.CreateDualTVL1_OCL();
        }

        public static DenseOpticalFlowExt CreateOptFlow_Brox_GPU()
        {
            return DenseOpticalFlowExt.CreateBrox_GPU();
        }

        public static DenseOpticalFlowExt CreateOptFlow_PyrLK_GPU()
        {
            return DenseOpticalFlowExt.CreatePyrLK_GPU();
        }

        public static DenseOpticalFlowExt CreateOptFlow_PyrLK_OCL()
        {
            return DenseOpticalFlowExt.CreatePyrLK_OCL();
        }

        public static void Rodrigues(InputArray src, OutputArray dst, OutputArray jacobian = null)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.calib3d_Rodrigues(src.CvPtr, dst.CvPtr, ToPtr(jacobian));
            dst.Fix();
            if (jacobian != null)
                jacobian.Fix();
        }

        public static void Rodrigues(double[] vector, out double[,] matrix, out double[,] jacobian)
        {
            if (vector == null)
            {
                throw new ArgumentNullException("vector");
            }
            if (vector.Length != 3)
            {
                throw new ArgumentException("vector.Length != 3");
            }
            using (Mat mat = new Mat(3, 1, MatType.CV_64FC1, vector, 0L))
            {
                using (MatOfDouble matOfDouble = new MatOfDouble())
                {
                    using (MatOfDouble matOfDouble2 = new MatOfDouble())
                    {
                        NativeMethods.calib3d_Rodrigues_VecToMat(mat.CvPtr, matOfDouble.CvPtr, matOfDouble2.CvPtr);
                        matrix = matOfDouble.ToRectangularArray();
                        jacobian = matOfDouble2.ToRectangularArray();
                    }
                }
            }
        }

        public static void Rodrigues(double[] vector, out double[,] matrix)
        {
            double[,] _;
            Rodrigues(vector, out matrix, out _);
        }

        public static void Rodrigues(double[,] matrix, out double[] vector, out double[,] jacobian)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }
            if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
            {
                throw new ArgumentException("matrix must be double[3,3]");
            }
            using (Mat mat = new Mat(3, 3, MatType.CV_64FC1, matrix, 0L))
            {
                using (MatOfDouble matOfDouble = new MatOfDouble())
                {
                    using (MatOfDouble matOfDouble2 = new MatOfDouble())
                    {
                        NativeMethods.calib3d_Rodrigues_MatToVec(mat.CvPtr, matOfDouble.CvPtr, matOfDouble2.CvPtr);
                        vector = matOfDouble.ToArray();
                        jacobian = matOfDouble2.ToRectangularArray();
                    }
                }
            }
        }

        public static void Rodrigues(double[,] matrix, out double[] vector)
        {
            double[,] _;
            Rodrigues(matrix, out vector, out  _);
        }

        public static Mat FindHomography(InputArray srcPoints, InputArray dstPoints, HomographyMethod method = HomographyMethod.Zero, double ransacReprojThreshold = 3.0, OutputArray mask = null)
        {
            if (srcPoints == null)
            {
                throw new ArgumentNullException("srcPoints");
            }
            if (dstPoints == null)
            {
                throw new ArgumentNullException("dstPoints");
            }
            srcPoints.ThrowIfDisposed();
            dstPoints.ThrowIfDisposed();
            IntPtr ptr = NativeMethods.calib3d_findHomography_InputArray(srcPoints.CvPtr, dstPoints.CvPtr, (int)method, ransacReprojThreshold, ToPtr(mask));
            if (mask != null)
                mask.Fix();
            return new Mat(ptr);
        }

        public static Mat FindHomography(IEnumerable<Point2d> srcPoints, IEnumerable<Point2d> dstPoints, HomographyMethod method = HomographyMethod.Zero, double ransacReprojThreshold = 3.0, OutputArray mask = null)
        {
            if (srcPoints == null)
            {
                throw new ArgumentNullException("srcPoints");
            }
            if (dstPoints == null)
            {
                throw new ArgumentNullException("dstPoints");
            }
            Point2d[] array = EnumerableEx.ToArray(srcPoints);
            Point2d[] array2 = EnumerableEx.ToArray(dstPoints);
            IntPtr ptr = NativeMethods.calib3d_findHomography_vector(array, array.Length, array2, array2.Length, (int)method, ransacReprojThreshold, ToPtr(mask));
            if (mask != null)
                mask.Fix();
            return new Mat(ptr);
        }

        public static Vec3d RQDecomp3x3(InputArray src, OutputArray mtxR, OutputArray mtxQ, OutputArray qx = null, OutputArray qy = null, OutputArray qz = null)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (mtxR == null)
            {
                throw new ArgumentNullException("mtxR");
            }
            if (mtxQ == null)
            {
                throw new ArgumentNullException("mtxQ");
            }
            src.ThrowIfDisposed();
            mtxR.ThrowIfNotReady();
            mtxQ.ThrowIfNotReady();
            Vec3d outVal;
            NativeMethods.calib3d_RQDecomp3x3_InputArray(src.CvPtr, mtxR.CvPtr, mtxQ.CvPtr, ToPtr(qx), ToPtr(qy), ToPtr(qz), out outVal);
            if (qx != null)
                qx.Fix();
            if (qy != null)
                qy.Fix();
            if (qz != null)
                qz.Fix();
            return outVal;
        }

        public static Vec3d RQDecomp3x3(double[,] src, out double[,] mtxR, out double[,] mtxQ)
        {
            double[,] qx;
            double[,] qy;
            double[,] qz;
            return RQDecomp3x3(src, out mtxR, out mtxQ, out qx, out qy, out qz);
        }

        public static Vec3d RQDecomp3x3(double[,] src, out double[,] mtxR, out double[,] mtxQ, out double[,] qx, out double[,] qy, out double[,] qz)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (src.GetLength(0) != 3 || src.GetLength(1) != 3)
            {
                throw new ArgumentException("src must be double[3,3]");
            }
            using (Mat mat = new Mat(3, 3, MatType.CV_64FC1))
            {
                using (MatOfDouble matOfDouble = new MatOfDouble())
                {
                    using (MatOfDouble matOfDouble2 = new MatOfDouble())
                    {
                        using (MatOfDouble matOfDouble3 = new MatOfDouble())
                        {
                            using (MatOfDouble matOfDouble4 = new MatOfDouble())
                            {
                                using (MatOfDouble matOfDouble5 = new MatOfDouble())
                                {
                                    Vec3d outVal;
                                    NativeMethods.calib3d_RQDecomp3x3_Mat(mat.CvPtr, matOfDouble.CvPtr, matOfDouble2.CvPtr, matOfDouble3.CvPtr, matOfDouble4.CvPtr, matOfDouble5.CvPtr, out  outVal);
                                    mtxR = matOfDouble.ToRectangularArray();
                                    mtxQ = matOfDouble2.ToRectangularArray();
                                    qx = matOfDouble3.ToRectangularArray();
                                    qy = matOfDouble4.ToRectangularArray();
                                    qz = matOfDouble5.ToRectangularArray();
                                    return outVal;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void DecomposeProjectionMatrix(InputArray projMatrix, OutputArray cameraMatrix, OutputArray rotMatrix, OutputArray transVect, OutputArray rotMatrixX = null, OutputArray rotMatrixY = null, OutputArray rotMatrixZ = null, OutputArray eulerAngles = null)
        {
            if (projMatrix == null)
            {
                throw new ArgumentNullException("projMatrix");
            }
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            if (rotMatrix == null)
            {
                throw new ArgumentNullException("rotMatrix");
            }
            projMatrix.ThrowIfDisposed();
            cameraMatrix.ThrowIfNotReady();
            rotMatrix.ThrowIfNotReady();
            transVect.ThrowIfNotReady();
            NativeMethods.calib3d_decomposeProjectionMatrix_InputArray(projMatrix.CvPtr, cameraMatrix.CvPtr, rotMatrix.CvPtr, transVect.CvPtr, ToPtr(rotMatrixX), ToPtr(rotMatrixY), ToPtr(rotMatrixZ), ToPtr(eulerAngles));
            cameraMatrix.Fix();
            rotMatrix.Fix();
            transVect.Fix();
            if (rotMatrixX != null)
                rotMatrixX.Fix();
            if (rotMatrixY != null)
                rotMatrixY.Fix();
            if (rotMatrixZ != null)
                rotMatrixZ.Fix();
            if (eulerAngles != null)
                eulerAngles.Fix();
        }

        public static void DecomposeProjectionMatrix(double[,] projMatrix, out double[,] cameraMatrix, out double[,] rotMatrix, out double[] transVect, out double[,] rotMatrixX, out double[,] rotMatrixY, out double[,] rotMatrixZ, out double[] eulerAngles)
        {
            if (projMatrix == null)
            {
                throw new ArgumentNullException("projMatrix");
            }
            int length = projMatrix.GetLength(0);
            int length2 = projMatrix.GetLength(1);
            if ((length != 3 || length2 != 4) && (length != 4 || length2 != 3))
            {
                throw new ArgumentException("projMatrix must be double[3,4] or double[4,3]");
            }
            using (Mat mat = new Mat(3, 4, MatType.CV_64FC1, projMatrix, 0L))
            {
                using (MatOfDouble matOfDouble = new MatOfDouble())
                {
                    using (MatOfDouble matOfDouble2 = new MatOfDouble())
                    {
                        using (MatOfDouble matOfDouble3 = new MatOfDouble())
                        {
                            using (MatOfDouble matOfDouble4 = new MatOfDouble())
                            {
                                using (MatOfDouble matOfDouble5 = new MatOfDouble())
                                {
                                    using (MatOfDouble matOfDouble6 = new MatOfDouble())
                                    {
                                        using (MatOfDouble matOfDouble7 = new MatOfDouble())
                                        {
                                            NativeMethods.calib3d_decomposeProjectionMatrix_Mat(mat.CvPtr, matOfDouble.CvPtr, matOfDouble2.CvPtr, matOfDouble3.CvPtr, matOfDouble4.CvPtr, matOfDouble5.CvPtr, matOfDouble6.CvPtr, matOfDouble7.CvPtr);
                                            cameraMatrix = matOfDouble.ToRectangularArray();
                                            rotMatrix = matOfDouble2.ToRectangularArray();
                                            transVect = matOfDouble3.ToArray();
                                            rotMatrixX = matOfDouble4.ToRectangularArray();
                                            rotMatrixY = matOfDouble5.ToRectangularArray();
                                            rotMatrixZ = matOfDouble6.ToRectangularArray();
                                            eulerAngles = matOfDouble7.ToArray();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void DecomposeProjectionMatrix(double[,] projMatrix, out double[,] cameraMatrix, out double[,] rotMatrix, out double[] transVect)
        {
            double[,] _1, _2, _3; double[] _4;
            DecomposeProjectionMatrix(projMatrix, out cameraMatrix, out rotMatrix, out transVect, out  _1, out _2, out _3, out _4);
        }

        public static void MatMulDeriv(InputArray a, InputArray b, OutputArray dABdA, OutputArray dABdB)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            if (b == null)
            {
                throw new ArgumentNullException("b");
            }
            if (dABdA == null)
            {
                throw new ArgumentNullException("dABdA");
            }
            if (dABdB == null)
            {
                throw new ArgumentNullException("dABdB");
            }
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            dABdA.ThrowIfNotReady();
            dABdB.ThrowIfNotReady();
            NativeMethods.calib3d_matMulDeriv(a.CvPtr, b.CvPtr, dABdA.CvPtr, dABdB.CvPtr);
            dABdA.Fix();
            dABdB.Fix();
        }

        public static void ComposeRT(InputArray rvec1, InputArray tvec1, InputArray rvec2, InputArray tvec2, OutputArray rvec3, OutputArray tvec3, OutputArray dr3dr1 = null, OutputArray dr3dt1 = null, OutputArray dr3dr2 = null, OutputArray dr3dt2 = null, OutputArray dt3dr1 = null, OutputArray dt3dt1 = null, OutputArray dt3dr2 = null, OutputArray dt3dt2 = null)
        {
            if (rvec1 == null)
            {
                throw new ArgumentNullException("rvec1");
            }
            if (tvec1 == null)
            {
                throw new ArgumentNullException("tvec1");
            }
            if (rvec2 == null)
            {
                throw new ArgumentNullException("rvec2");
            }
            if (tvec2 == null)
            {
                throw new ArgumentNullException("tvec2");
            }
            rvec1.ThrowIfDisposed();
            tvec1.ThrowIfDisposed();
            rvec2.ThrowIfDisposed();
            tvec2.ThrowIfDisposed();
            rvec3.ThrowIfNotReady();
            tvec3.ThrowIfNotReady();
            NativeMethods.calib3d_composeRT_InputArray(rvec1.CvPtr, tvec1.CvPtr, rvec2.CvPtr, tvec2.CvPtr, rvec3.CvPtr, tvec3.CvPtr, ToPtr(dr3dr1), ToPtr(dr3dt1), ToPtr(dr3dr2), ToPtr(dr3dt2), ToPtr(dt3dr1), ToPtr(dt3dt1), ToPtr(dt3dr2), ToPtr(dt3dt2));
        }

        public static void ComposeRT(double[] rvec1, double[] tvec1, double[] rvec2, double[] tvec2, out double[] rvec3, out double[] tvec3, out double[,] dr3dr1, out double[,] dr3dt1, out double[,] dr3dr2, out double[,] dr3dt2, out double[,] dt3dr1, out double[,] dt3dt1, out double[,] dt3dr2, out double[,] dt3dt2)
        {
            if (rvec1 == null)
            {
                throw new ArgumentNullException("rvec1");
            }
            if (tvec1 == null)
            {
                throw new ArgumentNullException("tvec1");
            }
            if (rvec2 == null)
            {
                throw new ArgumentNullException("rvec2");
            }
            if (tvec2 == null)
            {
                throw new ArgumentNullException("tvec2");
            }
            using (Mat mat = new Mat(3, 1, MatType.CV_64FC1, rvec1, 0L))
            {
                using (Mat mat2 = new Mat(3, 1, MatType.CV_64FC1, tvec1, 0L))
                {
                    using (Mat mat3 = new Mat(3, 1, MatType.CV_64FC1, rvec2, 0L))
                    {
                        using (Mat mat4 = new Mat(3, 1, MatType.CV_64FC1, tvec2, 0L))
                        {
                            using (MatOfDouble matOfDouble = new MatOfDouble())
                            {
                                using (MatOfDouble matOfDouble2 = new MatOfDouble())
                                {
                                    using (MatOfDouble matOfDouble3 = new MatOfDouble())
                                    {
                                        using (MatOfDouble matOfDouble4 = new MatOfDouble())
                                        {
                                            using (MatOfDouble matOfDouble5 = new MatOfDouble())
                                            {
                                                using (MatOfDouble matOfDouble6 = new MatOfDouble())
                                                {
                                                    using (MatOfDouble matOfDouble7 = new MatOfDouble())
                                                    {
                                                        using (MatOfDouble matOfDouble8 = new MatOfDouble())
                                                        {
                                                            using (MatOfDouble matOfDouble9 = new MatOfDouble())
                                                            {
                                                                using (MatOfDouble matOfDouble10 = new MatOfDouble())
                                                                {
                                                                    NativeMethods.calib3d_composeRT_Mat(mat.CvPtr, mat2.CvPtr, mat3.CvPtr, mat4.CvPtr, matOfDouble.CvPtr, matOfDouble2.CvPtr, matOfDouble3.CvPtr, matOfDouble4.CvPtr, matOfDouble5.CvPtr, matOfDouble6.CvPtr, matOfDouble7.CvPtr, matOfDouble8.CvPtr, matOfDouble9.CvPtr, matOfDouble10.CvPtr);
                                                                    rvec3 = matOfDouble.ToArray();
                                                                    tvec3 = matOfDouble2.ToArray();
                                                                    dr3dr1 = matOfDouble3.ToRectangularArray();
                                                                    dr3dt1 = matOfDouble4.ToRectangularArray();
                                                                    dr3dr2 = matOfDouble5.ToRectangularArray();
                                                                    dr3dt2 = matOfDouble6.ToRectangularArray();
                                                                    dt3dr1 = matOfDouble7.ToRectangularArray();
                                                                    dt3dt1 = matOfDouble8.ToRectangularArray();
                                                                    dt3dr2 = matOfDouble9.ToRectangularArray();
                                                                    dt3dt2 = matOfDouble10.ToRectangularArray();
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void ComposeRT(double[] rvec1, double[] tvec1, double[] rvec2, double[] tvec2, out double[] rvec3, out double[] tvec3)
        {

            double[,] _1, _2, _3, _4, _5, _6, _7, _8;
            ComposeRT(rvec1, tvec2, rvec2, tvec2, out rvec3, out tvec3, out  _1, out  _2, out  _3, out _4, out  _5, out  _6, out  _7, out  _8);
        }

        public static void ProjectPoints(InputArray objectPoints, InputArray rvec, InputArray tvec, InputArray cameraMatrix, InputArray distCoeffs, OutputArray imagePoints, OutputArray jacobian = null, double aspectRatio = 0.0)
        {
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (rvec == null)
            {
                throw new ArgumentNullException("rvec");
            }
            if (tvec == null)
            {
                throw new ArgumentNullException("tvec");
            }
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            if (imagePoints == null)
            {
                throw new ArgumentNullException("imagePoints");
            }
            objectPoints.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();
            imagePoints.ThrowIfNotReady();
            NativeMethods.calib3d_projectPoints_InputArray(objectPoints.CvPtr, rvec.CvPtr, tvec.CvPtr, cameraMatrix.CvPtr, ToPtr(distCoeffs), imagePoints.CvPtr, ToPtr(jacobian), aspectRatio);
        }

        public static void ProjectPoints(IEnumerable<Point3d> objectPoints, double[] rvec, double[] tvec, double[,] cameraMatrix, double[] distCoeffs, out Point2d[] imagePoints, out double[,] jacobian, double aspectRatio = 0.0)
        {
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (rvec == null)
            {
                throw new ArgumentNullException("rvec");
            }
            if (rvec.Length != 3)
            {
                throw new ArgumentException("rvec.Length != 3");
            }
            if (tvec == null)
            {
                throw new ArgumentNullException("tvec");
            }
            if (tvec.Length != 3)
            {
                throw new ArgumentException("tvec.Length != 3");
            }
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
            {
                throw new ArgumentException("cameraMatrix must be double[3,3]");
            }
            Point3d[] array = EnumerableEx.ToArray(objectPoints);
            using (Mat mat2 = new Mat(array.Length, 1, MatType.CV_64FC3, array, 0L))
            {
                using (Mat mat3 = new Mat(3, 1, MatType.CV_64FC1, rvec, 0L))
                {
                    using (Mat mat4 = new Mat(3, 1, MatType.CV_64FC1, tvec, 0L))
                    {
                        using (Mat mat5 = new Mat(3, 3, MatType.CV_64FC1, cameraMatrix, 0L))
                        {
                            using (MatOfPoint2d matOfPoint2d = new MatOfPoint2d())
                            {
                                Mat mat = new Mat();
                                if (distCoeffs != null)
                                {
                                    mat = new Mat(distCoeffs.Length, 1, MatType.CV_64FC1, distCoeffs, 0L);
                                }
                                MatOfDouble matOfDouble = new MatOfDouble();
                                NativeMethods.calib3d_projectPoints_Mat(mat2.CvPtr, mat3.CvPtr, mat4.CvPtr, mat5.CvPtr, mat.CvPtr, matOfPoint2d.CvPtr, matOfDouble.CvPtr, aspectRatio);
                                imagePoints = matOfPoint2d.ToArray();
                                jacobian = matOfDouble.ToRectangularArray();
                            }
                        }
                    }
                }
            }
        }

        public static void SolvePnP(InputArray objectPoints, InputArray imagePoints, InputArray cameraMatrix, InputArray distCoeffs, OutputArray rvec, OutputArray tvec, bool useExtrinsicGuess = false, SolvePnPFlag flags = SolvePnPFlag.Iterative)
        {
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (imagePoints == null)
            {
                throw new ArgumentNullException("imagePoints");
            }
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            if (rvec == null)
            {
                throw new ArgumentNullException("rvec");
            }
            if (tvec == null)
            {
                throw new ArgumentNullException("tvec");
            }
            objectPoints.ThrowIfDisposed();
            imagePoints.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();
            IntPtr distCoeffs2 = ToPtr(distCoeffs);
            NativeMethods.calib3d_solvePnP_InputArray(objectPoints.CvPtr, imagePoints.CvPtr, cameraMatrix.CvPtr, distCoeffs2, rvec.CvPtr, tvec.CvPtr, useExtrinsicGuess ? 1 : 0, (int)flags);
            rvec.Fix();
            tvec.Fix();
        }

        public static void SolvePnP(IEnumerable<Point3f> objectPoints, IEnumerable<Point2f> imagePoints, double[,] cameraMatrix, IEnumerable<double> distCoeffs, out double[] rvec, out double[] tvec, bool useExtrinsicGuess = false, SolvePnPFlag flags = SolvePnPFlag.Iterative)
        {
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (imagePoints == null)
            {
                throw new ArgumentNullException("imagePoints");
            }
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
            {
                throw new ArgumentException("");
            }
            Point3f[] array = EnumerableEx.ToArray(objectPoints);
            Point2f[] array2 = EnumerableEx.ToArray(imagePoints);
            double[] array3 = EnumerableEx.ToArray(distCoeffs);
            int distCoeffsLength = (distCoeffs != null) ? array3.Length : 0;
            rvec = new double[3];
            tvec = new double[3];
            NativeMethods.calib3d_solvePnP_vector(array, array.Length, array2, array2.Length, cameraMatrix, array3, distCoeffsLength, rvec, tvec, useExtrinsicGuess ? 1 : 0, (int)flags);
        }

        public static void SolvePnPRansac(InputArray objectPoints, InputArray imagePoints, InputArray cameraMatrix, InputArray distCoeffs, OutputArray rvec, OutputArray tvec, bool useExtrinsicGuess = false, int iterationsCount = 100, float reprojectionError = 8f, int minInliersCount = 100, OutputArray inliers = null, SolvePnPFlag flags = SolvePnPFlag.Iterative)
        {
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (imagePoints == null)
            {
                throw new ArgumentNullException("imagePoints");
            }
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            if (rvec == null)
            {
                throw new ArgumentNullException("rvec");
            }
            if (tvec == null)
            {
                throw new ArgumentNullException("tvec");
            }
            objectPoints.ThrowIfDisposed();
            imagePoints.ThrowIfDisposed();
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();
            IntPtr distCoeffs2 = ToPtr(distCoeffs);
            NativeMethods.calib3d_solvePnPRansac_InputArray(objectPoints.CvPtr, imagePoints.CvPtr, cameraMatrix.CvPtr, distCoeffs2, rvec.CvPtr, tvec.CvPtr, useExtrinsicGuess ? 1 : 0, iterationsCount, reprojectionError, minInliersCount, ToPtr(inliers), (int)flags);
            rvec.Fix();
            tvec.Fix();
            if (inliers != null)
                inliers.Fix();
        }

        public static void SolvePnPRansac(IEnumerable<Point3f> objectPoints, IEnumerable<Point2f> imagePoints, double[,] cameraMatrix, IEnumerable<double> distCoeffs, out double[] rvec, out double[] tvec)
        {
            int[] _;
            SolvePnPRansac(objectPoints, imagePoints, cameraMatrix, distCoeffs, out rvec, out tvec, out _);
        }

        public static void SolvePnPRansac(IEnumerable<Point3f> objectPoints, IEnumerable<Point2f> imagePoints, double[,] cameraMatrix, IEnumerable<double> distCoeffs, out double[] rvec, out double[] tvec, out int[] inliers, bool useExtrinsicGuess = false, int iterationsCount = 100, float reprojectionError = 8f, int minInliersCount = 100, SolvePnPFlag flags = SolvePnPFlag.Iterative)
        {
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (imagePoints == null)
            {
                throw new ArgumentNullException("imagePoints");
            }
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
            {
                throw new ArgumentException("");
            }
            Point3f[] array = EnumerableEx.ToArray(objectPoints);
            Point2f[] array2 = EnumerableEx.ToArray(imagePoints);
            double[] array3 = EnumerableEx.ToArray(distCoeffs);
            int distCoeffsLength = (distCoeffs != null) ? array3.Length : 0;
            rvec = new double[3];
            tvec = new double[3];
            using (VectorOfInt32 vectorOfInt = new VectorOfInt32())
            {
                NativeMethods.calib3d_solvePnPRansac_vector(array, array.Length, array2, array2.Length, cameraMatrix, array3, distCoeffsLength, rvec, tvec, useExtrinsicGuess ? 1 : 0, iterationsCount, reprojectionError, minInliersCount, vectorOfInt.CvPtr, (int)flags);
                inliers = vectorOfInt.ToArray();
            }
        }

        public static Mat InitCameraMatrix2D(IEnumerable<Mat> objectPoints, IEnumerable<Mat> imagePoints, Size imageSize, double aspectRatio = 1.0)
        {
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (imagePoints == null)
            {
                throw new ArgumentNullException("imagePoints");
            }
            IntPtr[] array = EnumerableEx.SelectPtrs(objectPoints);
            IntPtr[] array2 = EnumerableEx.SelectPtrs(imagePoints);
            return new Mat(NativeMethods.calib3d_initCameraMatrix2D_Mat(array, array.Length, array2, array2.Length, imageSize, aspectRatio));
        }

        public static Mat InitCameraMatrix2D(IEnumerable<IEnumerable<Point3d>> objectPoints, IEnumerable<IEnumerable<Point2d>> imagePoints, Size imageSize, double aspectRatio = 1.0)
        {
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (imagePoints == null)
            {
                throw new ArgumentNullException("imagePoints");
            }
            using (ArrayAddress2<Point3d> arrayAddress = new ArrayAddress2<Point3d>(objectPoints))
            {
                using (ArrayAddress2<Point2d> arrayAddress2 = new ArrayAddress2<Point2d>(imagePoints))
                {
                    return new Mat(NativeMethods.calib3d_initCameraMatrix2D_array(arrayAddress, arrayAddress.Dim1Length, arrayAddress.Dim2Lengths, arrayAddress2, arrayAddress2.Dim1Length, arrayAddress2.Dim2Lengths, imageSize, aspectRatio));
                }
            }
        }

        public static bool FindChessboardCorners(InputArray image, Size patternSize, OutputArray corners, ChessboardFlag flags = ChessboardFlag.AdaptiveThresh | ChessboardFlag.NormalizeImage)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (corners == null)
            {
                throw new ArgumentNullException("corners");
            }
            image.ThrowIfDisposed();
            corners.ThrowIfNotReady();
            int num = NativeMethods.calib3d_findChessboardCorners_InputArray(image.CvPtr, patternSize, corners.CvPtr, (int)flags);
            corners.Fix();
            return num != 0;
        }

        public static bool FindChessboardCorners(InputArray image, Size patternSize, out Point2f[] corners, ChessboardFlag flags = ChessboardFlag.AdaptiveThresh | ChessboardFlag.NormalizeImage)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            image.ThrowIfDisposed();
            using (VectorOfPoint2f vectorOfPoint2f = new VectorOfPoint2f())
            {
                int num = NativeMethods.calib3d_findChessboardCorners_vector(image.CvPtr, patternSize, vectorOfPoint2f.CvPtr, (int)flags);
                corners = vectorOfPoint2f.ToArray();
                return num != 0;
            }
        }

        public static bool Find4QuadCornerSubpix(InputArray img, InputOutputArray corners, Size regionSize)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            if (corners == null)
            {
                throw new ArgumentNullException("corners");
            }
            img.ThrowIfDisposed();
            corners.ThrowIfNotReady();
            int num = NativeMethods.calib3d_find4QuadCornerSubpix_InputArray(img.CvPtr, corners.CvPtr, regionSize);
            corners.Fix();
            return num != 0;
        }

        public static bool Find4QuadCornerSubpix(InputArray img, [In] [Out] Point2f[] corners, Size regionSize)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            if (corners == null)
            {
                throw new ArgumentNullException("corners");
            }
            img.ThrowIfDisposed();
            using (VectorOfPoint2f vectorOfPoint2f = new VectorOfPoint2f(corners))
            {
                int num = NativeMethods.calib3d_find4QuadCornerSubpix_vector(img.CvPtr, vectorOfPoint2f.CvPtr, regionSize);
                Point2f[] array = vectorOfPoint2f.ToArray();
                for (int i = 0; i < corners.Length; i++)
                {
                    corners[i] = array[i];
                }
                return num != 0;
            }
        }

        public static void DrawChessboardCorners(InputOutputArray image, Size patternSize, InputArray corners, bool patternWasFound)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (corners == null)
            {
                throw new ArgumentNullException("corners");
            }
            image.ThrowIfNotReady();
            corners.ThrowIfDisposed();
            NativeMethods.calib3d_drawChessboardCorners_InputArray(image.CvPtr, patternSize, corners.CvPtr, patternWasFound ? 1 : 0);
            image.Fix();
        }

        public static void DrawChessboardCorners(InputOutputArray image, Size patternSize, IEnumerable<Point2f> corners, bool patternWasFound)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (corners == null)
            {
                throw new ArgumentNullException("corners");
            }
            image.ThrowIfNotReady();
            Point2f[] array = EnumerableEx.ToArray(corners);
            NativeMethods.calib3d_drawChessboardCorners_array(image.CvPtr, patternSize, array, array.Length, patternWasFound ? 1 : 0);
            image.Fix();
        }

        public static bool FindCirclesGrid(InputArray image, Size patternSize, OutputArray centers, FindCirclesGridFlag flags = FindCirclesGridFlag.SymmetricGrid, FeatureDetector blobDetector = null)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (centers == null)
            {
                throw new ArgumentNullException("centers");
            }
            image.ThrowIfDisposed();
            centers.ThrowIfNotReady();
            int num = NativeMethods.calib3d_findCirclesGrid_InputArray(image.CvPtr, patternSize, centers.CvPtr, (int)flags, ToPtr(blobDetector));
            centers.Fix();
            GC.KeepAlive(image);
            return num != 0;
        }

        public static bool FindCirclesGrid(InputArray image, Size patternSize, out Point2f[] centers, FindCirclesGridFlag flags = FindCirclesGridFlag.SymmetricGrid, FeatureDetector blobDetector = null)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            image.ThrowIfDisposed();
            using (VectorOfPoint2f vectorOfPoint2f = new VectorOfPoint2f())
            {
                int num = NativeMethods.calib3d_findCirclesGrid_vector(image.CvPtr, patternSize, vectorOfPoint2f.CvPtr, (int)flags, ToPtr(blobDetector));
                centers = vectorOfPoint2f.ToArray();
                GC.KeepAlive(image);
                return num != 0;
            }
        }

        public static double CalibrateCamera(IEnumerable<Mat> objectPoints, IEnumerable<Mat> imagePoints, Size imageSize, InputOutputArray cameraMatrix, InputOutputArray distCoeffs, out Mat[] rvecs, out Mat[] tvecs, CalibrationFlag flags = CalibrationFlag.Zero, TermCriteria? criteria = default(TermCriteria?))
        {
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            if (distCoeffs == null)
            {
                throw new ArgumentNullException("distCoeffs");
            }
            cameraMatrix.ThrowIfNotReady();
            distCoeffs.ThrowIfNotReady();
            TermCriteria valueOrDefault = criteria.GetValueOrDefault(new TermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 30, double.Epsilon));
            IntPtr[] array = EnumerableEx.SelectPtrs(objectPoints);
            IntPtr[] imagePoints2 = EnumerableEx.SelectPtrs(imagePoints);
            double result;
            using (VectorOfMat vectorOfMat = new VectorOfMat())
            {
                using (VectorOfMat vectorOfMat2 = new VectorOfMat())
                {
                    result = NativeMethods.calib3d_calibrateCamera_InputArray(array, array.Length, imagePoints2, array.Length, imageSize, cameraMatrix.CvPtr, distCoeffs.CvPtr, vectorOfMat.CvPtr, vectorOfMat2.CvPtr, (int)flags, valueOrDefault);
                    rvecs = vectorOfMat.ToArray();
                    tvecs = vectorOfMat2.ToArray();
                }
            }
            cameraMatrix.Fix();
            distCoeffs.Fix();
            return result;
        }

        public static double CalibrateCamera(IEnumerable<IEnumerable<Point3f>> objectPoints, IEnumerable<IEnumerable<Point2f>> imagePoints, Size imageSize, double[,] cameraMatrix, double[] distCoeffs, out Vec3d[] rvecs, out Vec3d[] tvecs, CalibrationFlag flags = CalibrationFlag.Zero, TermCriteria? criteria = default(TermCriteria?))
        {
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            if (distCoeffs == null)
            {
                throw new ArgumentNullException("distCoeffs");
            }
            TermCriteria valueOrDefault = criteria.GetValueOrDefault(new TermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 30, double.Epsilon));
            using (ArrayAddress2<Point3f> arrayAddress = new ArrayAddress2<Point3f>(objectPoints))
            {
                using (ArrayAddress2<Point2f> arrayAddress2 = new ArrayAddress2<Point2f>(imagePoints))
                {
                    using (VectorOfMat vectorOfMat = new VectorOfMat())
                    {
                        using (VectorOfMat vectorOfMat2 = new VectorOfMat())
                        {
                            double result = NativeMethods.calib3d_calibrateCamera_vector(arrayAddress.Pointer, arrayAddress.Dim1Length, arrayAddress.Dim2Lengths, arrayAddress2.Pointer, arrayAddress2.Dim1Length, arrayAddress2.Dim2Lengths, imageSize, cameraMatrix, distCoeffs, distCoeffs.Length, vectorOfMat.CvPtr, vectorOfMat2.CvPtr, (int)flags, valueOrDefault);
                            Mat[] enumerable = vectorOfMat.ToArray();
                            Mat[] enumerable2 = vectorOfMat2.ToArray();
                            rvecs = EnumerableEx.SelectToArray(enumerable, (Mat m) => m.Get<Vec3d>(0));
                            tvecs = EnumerableEx.SelectToArray(enumerable2, (Mat m) => m.Get<Vec3d>(0));
                            return result;
                        }
                    }
                }
            }
        }

        public static void CalibrationMatrixValues(InputArray cameraMatrix, Size imageSize, double apertureWidth, double apertureHeight, out double fovx, out double fovy, out double focalLength, out Point2d principalPoint, out double aspectRatio)
        {
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            cameraMatrix.ThrowIfDisposed();
            NativeMethods.calib3d_calibrationMatrixValues_InputArray(cameraMatrix.CvPtr, imageSize, apertureWidth, apertureHeight, out fovx, out fovy, out focalLength, out principalPoint, out aspectRatio);
        }

        public static void CalibrationMatrixValues(double[,] cameraMatrix, Size imageSize, double apertureWidth, double apertureHeight, out double fovx, out double fovy, out double focalLength, out Point2d principalPoint, out double aspectRatio)
        {
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            if (cameraMatrix.GetLength(0) != 3 || cameraMatrix.GetLength(1) != 3)
            {
                throw new ArgumentException("cameraMatrix must be 3x3");
            }
            NativeMethods.calib3d_calibrationMatrixValues_array(cameraMatrix, imageSize, apertureWidth, apertureHeight, out fovx, out fovy, out focalLength, out principalPoint, out aspectRatio);
        }

        public static double StereoCalibrate(IEnumerable<InputArray> objectPoints, IEnumerable<InputArray> imagePoints1, IEnumerable<InputArray> imagePoints2, InputOutputArray cameraMatrix1, InputOutputArray distCoeffs1, InputOutputArray cameraMatrix2, InputOutputArray distCoeffs2, Size imageSize, OutputArray R, OutputArray T, OutputArray E, OutputArray F, TermCriteria? criteria = default(TermCriteria?), CalibrationFlag flags = CalibrationFlag.FixIntrinsic)
        {
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (imagePoints1 == null)
            {
                throw new ArgumentNullException("imagePoints1");
            }
            if (imagePoints2 == null)
            {
                throw new ArgumentNullException("imagePoints2");
            }
            if (cameraMatrix1 == null)
            {
                throw new ArgumentNullException("cameraMatrix1");
            }
            if (distCoeffs1 == null)
            {
                throw new ArgumentNullException("distCoeffs1");
            }
            if (cameraMatrix2 == null)
            {
                throw new ArgumentNullException("cameraMatrix2");
            }
            if (distCoeffs2 == null)
            {
                throw new ArgumentNullException("distCoeffs2");
            }
            cameraMatrix1.ThrowIfDisposed();
            distCoeffs1.ThrowIfDisposed();
            cameraMatrix2.ThrowIfDisposed();
            distCoeffs2.ThrowIfDisposed();
            cameraMatrix1.ThrowIfNotReady();
            cameraMatrix2.ThrowIfNotReady();
            distCoeffs1.ThrowIfNotReady();
            distCoeffs2.ThrowIfNotReady();
            IntPtr[] array = EnumerableEx.SelectPtrs(objectPoints);
            IntPtr[] array2 = EnumerableEx.SelectPtrs(imagePoints1);
            IntPtr[] array3 = EnumerableEx.SelectPtrs(imagePoints2);
            TermCriteria valueOrDefault = criteria.GetValueOrDefault(new TermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 30, 1E-06));
            double result = NativeMethods.calib3d_stereoCalibrate_InputArray(array, array.Length, array2, array2.Length, array3, array3.Length, cameraMatrix1.CvPtr, distCoeffs1.CvPtr, cameraMatrix2.CvPtr, distCoeffs2.CvPtr, imageSize, ToPtr(R), ToPtr(T), ToPtr(E), ToPtr(F), valueOrDefault, (int)flags);
            cameraMatrix1.Fix();
            distCoeffs1.Fix();
            cameraMatrix2.Fix();
            distCoeffs2.Fix();
            if (R != null)
                R.Fix();
            if (T != null)
                T.Fix();
            if (E != null) E.Fix();
            if (F != null) F.Fix();
            return result;
        }

        public static double StereoCalibrate(IEnumerable<IEnumerable<Point3d>> objectPoints, IEnumerable<IEnumerable<Point2d>> imagePoints1, IEnumerable<IEnumerable<Point2d>> imagePoints2, double[,] cameraMatrix1, double[] distCoeffs1, double[,] cameraMatrix2, double[] distCoeffs2, Size imageSize, OutputArray R, OutputArray T, OutputArray E, OutputArray F, TermCriteria? criteria = default(TermCriteria?), CalibrationFlag flags = CalibrationFlag.FixIntrinsic)
        {
            if (objectPoints == null)
            {
                throw new ArgumentNullException("objectPoints");
            }
            if (imagePoints1 == null)
            {
                throw new ArgumentNullException("imagePoints1");
            }
            if (imagePoints2 == null)
            {
                throw new ArgumentNullException("imagePoints2");
            }
            if (cameraMatrix1 == null)
            {
                throw new ArgumentNullException("cameraMatrix1");
            }
            if (distCoeffs1 == null)
            {
                throw new ArgumentNullException("distCoeffs1");
            }
            if (cameraMatrix2 == null)
            {
                throw new ArgumentNullException("cameraMatrix2");
            }
            if (distCoeffs2 == null)
            {
                throw new ArgumentNullException("distCoeffs2");
            }
            TermCriteria valueOrDefault = criteria.GetValueOrDefault(new TermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 30, 1E-06));
            using (ArrayAddress2<Point3d> arrayAddress = new ArrayAddress2<Point3d>(objectPoints))
            {
                using (ArrayAddress2<Point2d> arrayAddress2 = new ArrayAddress2<Point2d>(imagePoints1))
                {
                    using (ArrayAddress2<Point2d> arrayAddress3 = new ArrayAddress2<Point2d>(imagePoints2))
                    {
                        return NativeMethods.calib3d_stereoCalibrate_array(arrayAddress.Pointer, arrayAddress.Dim1Length, arrayAddress.Dim2Lengths, arrayAddress2.Pointer, arrayAddress2.Dim1Length, arrayAddress2.Dim2Lengths, arrayAddress3.Pointer, arrayAddress3.Dim1Length, arrayAddress3.Dim2Lengths, cameraMatrix1, distCoeffs1, distCoeffs1.Length, cameraMatrix2, distCoeffs2, distCoeffs2.Length, imageSize, ToPtr(R), ToPtr(T), ToPtr(E), ToPtr(F), valueOrDefault, (int)flags);
                    }
                }
            }
        }

        public static void StereoRectify(InputArray cameraMatrix1, InputArray distCoeffs1, InputArray cameraMatrix2, InputArray distCoeffs2, Size imageSize, InputArray R, InputArray T, OutputArray R1, OutputArray R2, OutputArray P1, OutputArray P2, OutputArray Q, StereoRectificationFlag flags = StereoRectificationFlag.ZeroDisparity, double alpha = -1.0, Size? newImageSize = default(Size?))
        {
            Size valueOrDefault = newImageSize.GetValueOrDefault(new Size(0, 0));
            Rect _1, _2;
            StereoRectify(cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2, imageSize, R, T, R1, R2, P1, P2, Q, flags, alpha, valueOrDefault, out _1, out _2);
        }

        public static void StereoRectify(InputArray cameraMatrix1, InputArray distCoeffs1, InputArray cameraMatrix2, InputArray distCoeffs2, Size imageSize, InputArray R, InputArray T, OutputArray R1, OutputArray R2, OutputArray P1, OutputArray P2, OutputArray Q, StereoRectificationFlag flags, double alpha, Size newImageSize, out Rect validPixROI1, out Rect validPixROI2)
        {
            if (cameraMatrix1 == null)
            {
                throw new ArgumentNullException("cameraMatrix1");
            }
            if (distCoeffs1 == null)
            {
                throw new ArgumentNullException("distCoeffs1");
            }
            if (cameraMatrix2 == null)
            {
                throw new ArgumentNullException("cameraMatrix2");
            }
            if (distCoeffs2 == null)
            {
                throw new ArgumentNullException("distCoeffs2");
            }
            if (R == null)
            {
                throw new ArgumentNullException("R");
            }
            if (T == null)
            {
                throw new ArgumentNullException("T");
            }
            if (R1 == null)
            {
                throw new ArgumentNullException("R1");
            }
            if (R2 == null)
            {
                throw new ArgumentNullException("R2");
            }
            if (P1 == null)
            {
                throw new ArgumentNullException("P1");
            }
            if (P2 == null)
            {
                throw new ArgumentNullException("P2");
            }
            if (Q == null)
            {
                throw new ArgumentNullException("Q");
            }
            cameraMatrix1.ThrowIfDisposed();
            distCoeffs1.ThrowIfDisposed();
            cameraMatrix2.ThrowIfDisposed();
            distCoeffs2.ThrowIfDisposed();
            R.ThrowIfDisposed();
            T.ThrowIfDisposed();
            R1.ThrowIfNotReady();
            R2.ThrowIfNotReady();
            P1.ThrowIfNotReady();
            P2.ThrowIfNotReady();
            Q.ThrowIfNotReady();
            CvRect validPixROI3;
            CvRect validPixROI4;
            NativeMethods.calib3d_stereoRectify_InputArray(cameraMatrix1.CvPtr, distCoeffs1.CvPtr, cameraMatrix2.CvPtr, distCoeffs2.CvPtr, imageSize, R.CvPtr, T.CvPtr, R1.CvPtr, R2.CvPtr, P1.CvPtr, P2.CvPtr, Q.CvPtr, (int)flags, alpha, newImageSize, out  validPixROI3, out  validPixROI4);
            validPixROI1 = validPixROI3;
            validPixROI2 = validPixROI4;
            R1.Fix();
            R2.Fix();
            P1.Fix();
            P2.Fix();
            Q.Fix();
        }

        public static void StereoRectify(double[,] cameraMatrix1, double[] distCoeffs1, double[,] cameraMatrix2, double[] distCoeffs2, Size imageSize, double[,] R, double[] T, out double[,] R1, out double[,] R2, out double[,] P1, out double[,] P2, out double[,] Q, StereoRectificationFlag flags = StereoRectificationFlag.ZeroDisparity, double alpha = -1.0, Size? newImageSize = default(Size?))
        {
            Size valueOrDefault = newImageSize.GetValueOrDefault(new Size(0, 0));
            Rect _1, _2;
            StereoRectify(cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2, imageSize, R, T, out R1, out R2, out P1, out P2, out Q, flags, alpha, valueOrDefault, out  _1, out  _2);
        }

        public static void StereoRectify(double[,] cameraMatrix1, double[] distCoeffs1, double[,] cameraMatrix2, double[] distCoeffs2, Size imageSize, double[,] R, double[] T, out double[,] R1, out double[,] R2, out double[,] P1, out double[,] P2, out double[,] Q, StereoRectificationFlag flags, double alpha, Size newImageSize, out Rect validPixROI1, out Rect validPixROI2)
        {
            if (cameraMatrix1 == null)
            {
                throw new ArgumentNullException("cameraMatrix1");
            }
            if (distCoeffs1 == null)
            {
                throw new ArgumentNullException("distCoeffs1");
            }
            if (cameraMatrix2 == null)
            {
                throw new ArgumentNullException("cameraMatrix2");
            }
            if (distCoeffs2 == null)
            {
                throw new ArgumentNullException("distCoeffs2");
            }
            if (R == null)
            {
                throw new ArgumentNullException("R");
            }
            if (T == null)
            {
                throw new ArgumentNullException("T");
            }
            R1 = new double[3, 3];
            R2 = new double[3, 3];
            P1 = new double[3, 4];
            P2 = new double[3, 4];
            Q = new double[4, 4];
            CvRect validPixROI3, validPixROI4;
            NativeMethods.calib3d_stereoRectify_array(cameraMatrix1, distCoeffs1, distCoeffs1.Length, cameraMatrix2, distCoeffs2, distCoeffs2.Length, imageSize, R, T, R1, R2, P1, P2, Q, (int)flags, alpha, newImageSize, out  validPixROI3, out  validPixROI4);
            validPixROI1 = validPixROI3;
            validPixROI2 = validPixROI4;
        }

        public static bool StereoRectifyUncalibrated(InputArray points1, InputArray points2, InputArray F, Size imgSize, OutputArray H1, OutputArray H2, double threshold = 5.0)
        {
            if (points1 == null)
            {
                throw new ArgumentNullException("points1");
            }
            if (points2 == null)
            {
                throw new ArgumentNullException("points2");
            }
            if (F == null)
            {
                throw new ArgumentNullException("F");
            }
            if (H1 == null)
            {
                throw new ArgumentNullException("H1");
            }
            if (H2 == null)
            {
                throw new ArgumentNullException("H2");
            }
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();
            F.ThrowIfDisposed();
            H1.ThrowIfNotReady();
            H2.ThrowIfNotReady();
            int num = NativeMethods.calib3d_stereoRectifyUncalibrated_InputArray(points1.CvPtr, points2.CvPtr, F.CvPtr, imgSize, H1.CvPtr, H2.CvPtr, threshold);
            H1.Fix();
            H2.Fix();
            return num != 0;
        }

        public static bool StereoRectifyUncalibrated(IEnumerable<Point2d> points1, IEnumerable<Point2d> points2, double[,] F, Size imgSize, out double[,] H1, out double[,] H2, double threshold = 5.0)
        {
            if (points1 == null)
            {
                throw new ArgumentNullException("points1");
            }
            if (points2 == null)
            {
                throw new ArgumentNullException("points2");
            }
            if (F == null)
            {
                throw new ArgumentNullException("F");
            }
            if (F.GetLength(0) != 3 || F.GetLength(1) != 3)
            {
                throw new ArgumentException("F != double[3,3]");
            }
            Point2d[] array = EnumerableEx.ToArray(points1);
            Point2d[] array2 = EnumerableEx.ToArray(points2);
            H1 = new double[3, 3];
            H2 = new double[3, 3];
            return NativeMethods.calib3d_stereoRectifyUncalibrated_array(array, array.Length, array2, array2.Length, F, imgSize, H1, H2, threshold) != 0;
        }

        public static float Rectify3Collinear(InputArray cameraMatrix1, InputArray distCoeffs1, InputArray cameraMatrix2, InputArray distCoeffs2, InputArray cameraMatrix3, InputArray distCoeffs3, IEnumerable<InputArray> imgpt1, IEnumerable<InputArray> imgpt3, Size imageSize, InputArray R12, InputArray T12, InputArray R13, InputArray T13, OutputArray R1, OutputArray R2, OutputArray R3, OutputArray P1, OutputArray P2, OutputArray P3, OutputArray Q, double alpha, Size newImgSize, out Rect roi1, out Rect roi2, StereoRectificationFlag flags)
        {
            if (cameraMatrix1 == null)
            {
                throw new ArgumentNullException("cameraMatrix1");
            }
            if (distCoeffs1 == null)
            {
                throw new ArgumentNullException("distCoeffs1");
            }
            if (cameraMatrix2 == null)
            {
                throw new ArgumentNullException("cameraMatrix2");
            }
            if (distCoeffs2 == null)
            {
                throw new ArgumentNullException("distCoeffs2");
            }
            if (cameraMatrix3 == null)
            {
                throw new ArgumentNullException("cameraMatrix3");
            }
            if (distCoeffs3 == null)
            {
                throw new ArgumentNullException("distCoeffs3");
            }
            if (imgpt1 == null)
            {
                throw new ArgumentNullException("imgpt1");
            }
            if (imgpt3 == null)
            {
                throw new ArgumentNullException("imgpt3");
            }
            if (R12 == null)
            {
                throw new ArgumentNullException("R12");
            }
            if (T12 == null)
            {
                throw new ArgumentNullException("T12");
            }
            if (R13 == null)
            {
                throw new ArgumentNullException("R13");
            }
            if (T13 == null)
            {
                throw new ArgumentNullException("T13");
            }
            if (R1 == null)
            {
                throw new ArgumentNullException("R1");
            }
            if (R2 == null)
            {
                throw new ArgumentNullException("R2");
            }
            if (R3 == null)
            {
                throw new ArgumentNullException("R3");
            }
            if (P1 == null)
            {
                throw new ArgumentNullException("P1");
            }
            if (P2 == null)
            {
                throw new ArgumentNullException("P2");
            }
            if (P3 == null)
            {
                throw new ArgumentNullException("P3");
            }
            if (Q == null)
            {
                throw new ArgumentNullException("Q");
            }
            cameraMatrix1.ThrowIfDisposed();
            distCoeffs1.ThrowIfDisposed();
            cameraMatrix2.ThrowIfDisposed();
            distCoeffs2.ThrowIfDisposed();
            cameraMatrix3.ThrowIfDisposed();
            distCoeffs3.ThrowIfDisposed();
            R12.ThrowIfDisposed();
            T12.ThrowIfDisposed();
            R13.ThrowIfDisposed();
            T13.ThrowIfDisposed();
            R1.ThrowIfNotReady();
            R2.ThrowIfNotReady();
            R3.ThrowIfNotReady();
            P1.ThrowIfNotReady();
            P2.ThrowIfNotReady();
            P3.ThrowIfNotReady();
            Q.ThrowIfNotReady();
            IntPtr[] array = EnumerableEx.SelectPtrs(imgpt1);
            IntPtr[] array2 = EnumerableEx.SelectPtrs(imgpt3);
            CvRect roi3;
            CvRect roi4;
            float result = NativeMethods.calib3d_rectify3Collinear_InputArray(cameraMatrix1.CvPtr, distCoeffs1.CvPtr, cameraMatrix2.CvPtr, distCoeffs2.CvPtr, cameraMatrix3.CvPtr, distCoeffs3.CvPtr, array, array.Length, array2, array2.Length, imageSize, R12.CvPtr, T12.CvPtr, R13.CvPtr, T13.CvPtr, R1.CvPtr, R2.CvPtr, R3.CvPtr, P1.CvPtr, P2.CvPtr, P3.CvPtr, Q.CvPtr, alpha, newImgSize, out roi3, out roi4, (int)flags);
            roi1 = roi3;
            roi2 = roi4;
            R1.Fix();
            R2.Fix();
            R3.Fix();
            P1.Fix();
            P2.Fix();
            P3.Fix();
            Q.Fix();
            return result;
        }

        public static Mat GetOptimalNewCameraMatrix(InputArray cameraMatrix, InputArray distCoeffs, Size imageSize, double alpha, Size newImgSize, out Rect validPixROI, bool centerPrincipalPoint = false)
        {
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException();
            }
            cameraMatrix.ThrowIfDisposed();
            CvRect validPixROI2 = default(CvRect);
            IntPtr ptr = NativeMethods.calib3d_getOptimalNewCameraMatrix_InputArray(cameraMatrix.CvPtr, ToPtr(distCoeffs), imageSize, alpha, newImgSize, out validPixROI2, centerPrincipalPoint ? 1 : 0);
            validPixROI = validPixROI2;
            return new Mat(ptr);
        }

        public static double[,] GetOptimalNewCameraMatrix(double[,] cameraMatrix, double[] distCoeffs, Size imageSize, double alpha, Size newImgSize, out Rect validPixROI, bool centerPrincipalPoint = false)
        {
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException();
            }
            double[,] array = new double[3, 3];
            NativeMethods.calib3d_getOptimalNewCameraMatrix_array(cameraMatrix, distCoeffs, distCoeffs.Length, imageSize, alpha, newImgSize, out validPixROI, centerPrincipalPoint ? 1 : 0, array);
            return array;
        }

        public static void ConvertPointsToHomogeneous(InputArray src, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.calib3d_convertPointsToHomogeneous_InputArray(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static Vec3f[] ConvertPointsToHomogeneous(IEnumerable<Vec2f> src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            Vec2f[] array = EnumerableEx.ToArray(src);
            Vec3f[] array2 = new Vec3f[array.Length];
            NativeMethods.calib3d_convertPointsToHomogeneous_array1(array, array2, array.Length);
            return array2;
        }

        public static Vec4f[] ConvertPointsToHomogeneous(IEnumerable<Vec3f> src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            Vec3f[] array = EnumerableEx.ToArray(src);
            Vec4f[] array2 = new Vec4f[array.Length];
            NativeMethods.calib3d_convertPointsToHomogeneous_array2(array, array2, array.Length);
            return array2;
        }

        public static void ConvertPointsFromHomogeneous(InputArray src, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.calib3d_convertPointsFromHomogeneous_InputArray(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static Vec2f[] ConvertPointsFromHomogeneous(IEnumerable<Vec3f> src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            Vec3f[] array = EnumerableEx.ToArray(src);
            Vec2f[] array2 = new Vec2f[array.Length];
            NativeMethods.calib3d_convertPointsFromHomogeneous_array1(array, array2, array.Length);
            return array2;
        }

        public static Vec3f[] ConvertPointsFromHomogeneous(IEnumerable<Vec4f> src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            Vec4f[] array = EnumerableEx.ToArray(src);
            Vec3f[] array2 = new Vec3f[array.Length];
            NativeMethods.calib3d_convertPointsFromHomogeneous_array2(array, array2, array.Length);
            return array2;
        }

        public static void ConvertPointsHomogeneous(InputArray src, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.calib3d_convertPointsHomogeneous(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static Mat FindFundamentalMat(InputArray points1, InputArray points2, FundamentalMatMethod method = FundamentalMatMethod.RansacOnly, double param1 = 3.0, double param2 = 0.99, OutputArray mask = null)
        {
            if (points1 == null)
            {
                throw new ArgumentNullException("points1");
            }
            if (points2 == null)
            {
                throw new ArgumentNullException("points2");
            }
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();
            IntPtr ptr = NativeMethods.calib3d_findFundamentalMat_InputArray(points1.CvPtr, points2.CvPtr, (int)method, param1, param2, ToPtr(mask));
            if (mask != null)
                mask.Fix();
            return new Mat(ptr);
        }

        public static Mat FindFundamentalMat(IEnumerable<Point2d> points1, IEnumerable<Point2d> points2, FundamentalMatMethod method = FundamentalMatMethod.RansacOnly, double param1 = 3.0, double param2 = 0.99, OutputArray mask = null)
		{
			if (points1 == null)
			{
				throw new ArgumentNullException("points1");
			}
			if (points2 == null)
			{
				throw new ArgumentNullException("points2");
			}
			Point2d[] array = EnumerableEx.ToArray(points1);
			Point2d[] array2 = EnumerableEx.ToArray(points2);
			IntPtr ptr = NativeMethods.calib3d_findFundamentalMat_array(array, array.Length, array2, array2.Length, (int)method, param1, param2, ToPtr(mask));
			if(mask!=null)
            mask.Fix();
			return new Mat(ptr);
		}

        public static void ComputeCorrespondEpilines(InputArray points, int whichImage, InputArray F, OutputArray lines)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            if (F == null)
            {
                throw new ArgumentNullException("F");
            }
            if (lines == null)
            {
                throw new ArgumentNullException("lines");
            }
            points.ThrowIfDisposed();
            F.ThrowIfDisposed();
            lines.ThrowIfNotReady();
            NativeMethods.calib3d_computeCorrespondEpilines_InputArray(points.CvPtr, whichImage, F.CvPtr, lines.CvPtr);
            lines.Fix();
        }

        public static Point3f[] ComputeCorrespondEpilines(IEnumerable<Point2d> points, int whichImage, double[,] F)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            if (F == null)
            {
                throw new ArgumentNullException("F");
            }
            if (F.GetLength(0) != 3 && F.GetLength(1) != 3)
            {
                throw new ArgumentException("F != double[3,3]");
            }
            Point2d[] array = EnumerableEx.ToArray(points);
            Point3f[] array2 = new Point3f[array.Length];
            NativeMethods.calib3d_computeCorrespondEpilines_array2d(array, array.Length, whichImage, F, array2);
            return array2;
        }

        public static Point3f[] ComputeCorrespondEpilines(IEnumerable<Point3d> points, int whichImage, double[,] F)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            if (F == null)
            {
                throw new ArgumentNullException("F");
            }
            if (F.GetLength(0) != 3 && F.GetLength(1) != 3)
            {
                throw new ArgumentException("F != double[3,3]");
            }
            Point3d[] array = EnumerableEx.ToArray(points);
            Point3f[] array2 = new Point3f[array.Length];
            NativeMethods.calib3d_computeCorrespondEpilines_array3d(array, array.Length, whichImage, F, array2);
            return array2;
        }

        public static void TriangulatePoints(InputArray projMatr1, InputArray projMatr2, InputArray projPoints1, InputArray projPoints2, OutputArray points4D)
        {
            if (projMatr1 == null)
            {
                throw new ArgumentNullException("projMatr1");
            }
            if (projMatr2 == null)
            {
                throw new ArgumentNullException("projMatr2");
            }
            if (projPoints1 == null)
            {
                throw new ArgumentNullException("projPoints1");
            }
            if (projPoints2 == null)
            {
                throw new ArgumentNullException("projPoints2");
            }
            if (points4D == null)
            {
                throw new ArgumentNullException("points4D");
            }
            projMatr1.ThrowIfDisposed();
            projMatr2.ThrowIfDisposed();
            projPoints1.ThrowIfDisposed();
            projPoints2.ThrowIfDisposed();
            points4D.ThrowIfNotReady();
            NativeMethods.calib3d_triangulatePoints_InputArray(projMatr1.CvPtr, projMatr2.CvPtr, projPoints1.CvPtr, projPoints2.CvPtr, points4D.CvPtr);
            points4D.Fix();
        }

        public static Vec4d[] TriangulatePoints(double[,] projMatr1, double[,] projMatr2, IEnumerable<Point2d> projPoints1, IEnumerable<Point2d> projPoints2)
        {
            if (projMatr1 == null)
            {
                throw new ArgumentNullException("projMatr1");
            }
            if (projMatr2 == null)
            {
                throw new ArgumentNullException("projMatr2");
            }
            if (projPoints1 == null)
            {
                throw new ArgumentNullException("projPoints1");
            }
            if (projPoints2 == null)
            {
                throw new ArgumentNullException("projPoints2");
            }
            if (projMatr1.GetLength(0) != 3 && projMatr1.GetLength(1) != 4)
            {
                throw new ArgumentException("projMatr1 != double[3,4]");
            }
            if (projMatr2.GetLength(0) != 3 && projMatr2.GetLength(1) != 4)
            {
                throw new ArgumentException("projMatr2 != double[3,4]");
            }
            Point2d[] array = EnumerableEx.ToArray(projPoints1);
            Point2d[] array2 = EnumerableEx.ToArray(projPoints2);
            Vec4d[] array3 = new Vec4d[array.Length];
            NativeMethods.calib3d_triangulatePoints_array(projMatr1, projMatr2, array, array.Length, array2, array2.Length, array3);
            return array3;
        }

        public static void CorrectMatches(InputArray F, InputArray points1, InputArray points2, OutputArray newPoints1, OutputArray newPoints2)
        {
            if (F == null)
            {
                throw new ArgumentNullException("F");
            }
            if (points1 == null)
            {
                throw new ArgumentNullException("points1");
            }
            if (points2 == null)
            {
                throw new ArgumentNullException("points2");
            }
            if (newPoints1 == null)
            {
                throw new ArgumentNullException("newPoints1");
            }
            if (newPoints2 == null)
            {
                throw new ArgumentNullException("newPoints2");
            }
            F.ThrowIfDisposed();
            points1.ThrowIfDisposed();
            points2.ThrowIfDisposed();
            newPoints1.ThrowIfNotReady();
            newPoints2.ThrowIfNotReady();
            NativeMethods.calib3d_correctMatches_InputArray(F.CvPtr, points1.CvPtr, points2.CvPtr, newPoints1.CvPtr, newPoints2.CvPtr);
            newPoints1.Fix();
            newPoints2.Fix();
        }

        public static void CorrectMatches(double[,] F, IEnumerable<Point2d> points1, IEnumerable<Point2d> points2, out Point2d[] newPoints1, out Point2d[] newPoints2)
        {
            if (F == null)
            {
                throw new ArgumentNullException("F");
            }
            if (points1 == null)
            {
                throw new ArgumentNullException("points1");
            }
            if (points2 == null)
            {
                throw new ArgumentNullException("points2");
            }
            Point2d[] array = EnumerableEx.ToArray(points1);
            Point2d[] array2 = EnumerableEx.ToArray(points2);
            newPoints1 = new Point2d[array.Length];
            newPoints2 = new Point2d[array2.Length];
            NativeMethods.calib3d_correctMatches_array(F, array, array.Length, array2, array2.Length, newPoints1, newPoints2);
        }

        public static void FilterSpeckles(InputOutputArray img, double newVal, int maxSpeckleSize, double maxDiff, InputOutputArray buf = null)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            img.ThrowIfNotReady();
            NativeMethods.calib3d_filterSpeckles(img.CvPtr, newVal, maxSpeckleSize, maxDiff, ToPtr(buf));
            img.Fix();
        }

        public static Rect GetValidDisparityROI(Rect roi1, Rect roi2, int minDisparity, int numberOfDisparities, int SADWindowSize)
        {
            return NativeMethods.calib3d_getValidDisparityROI(roi1, roi2, minDisparity, numberOfDisparities, SADWindowSize);
        }

        public static void ValidateDisparity(InputOutputArray disparity, InputArray cost, int minDisparity, int numberOfDisparities, int disp12MaxDisp = 1)
        {
            if (disparity == null)
            {
                throw new ArgumentNullException("disparity");
            }
            if (cost == null)
            {
                throw new ArgumentNullException("cost");
            }
            disparity.ThrowIfNotReady();
            cost.ThrowIfDisposed();
            NativeMethods.calib3d_validateDisparity(disparity.CvPtr, cost.CvPtr, minDisparity, numberOfDisparities, disp12MaxDisp);
            disparity.Fix();
        }

        public static void ReprojectImageTo3D(InputArray disparity, OutputArray _3dImage, InputArray Q, bool handleMissingValues = false, int ddepth = -1)
        {
            if (disparity == null)
            {
                throw new ArgumentNullException("disparity");
            }
            if (_3dImage == null)
            {
                throw new ArgumentNullException("_3dImage");
            }
            if (Q == null)
            {
                throw new ArgumentNullException("Q");
            }
            disparity.ThrowIfDisposed();
            _3dImage.ThrowIfNotReady();
            Q.ThrowIfDisposed();
            NativeMethods.calib3d_reprojectImageTo3D(disparity.CvPtr, _3dImage.CvPtr, Q.CvPtr, handleMissingValues ? 1 : 0, ddepth);
            _3dImage.Fix();
        }

        public static int EstimateAffine3D(InputArray src, InputArray dst, OutputArray outVal, OutputArray inliers, double ransacThreshold = 3.0, double confidence = 0.99)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (outVal == null)
            {
                throw new ArgumentNullException("outVal");
            }
            if (inliers == null)
            {
                throw new ArgumentNullException("inliers");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            outVal.ThrowIfNotReady();
            inliers.ThrowIfNotReady();
            int result = NativeMethods.calib3d_estimateAffine3D(src.CvPtr, dst.CvPtr, outVal.CvPtr, inliers.CvPtr, ransacThreshold, confidence);
            outVal.Fix();
            inliers.Fix();
            return result;
        }

        public static void NamedWindow(string winname)
        {
            NamedWindow(winname, WindowMode.None);
        }

        public static void NamedWindow(string winname, WindowMode flags)
        {
            if (string.IsNullOrEmpty(winname))
            {
                throw new ArgumentNullException("winname");
            }
            try
            {
                NativeMethods.highgui_namedWindow(winname, (int)flags);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        public static void DestroyWindow(string winName)
        {
            if (string.IsNullOrEmpty("winName"))
            {
                throw new ArgumentNullException("winName");
            }
            NativeMethods.highgui_destroyWindow(winName);
        }

        public static void DestroyAllWindows()
        {
            NativeMethods.highgui_destroyAllWindows();
        }

        public static void ImShow(string winname, Mat mat)
        {
            if (string.IsNullOrEmpty(winname))
            {
                throw new ArgumentNullException("winname");
            }
            if (mat == null)
            {
                throw new ArgumentNullException("mat");
            }
            try
            {
                NativeMethods.highgui_imshow(winname, mat.CvPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        public static Mat ImRead(string fileName, LoadMode flags = LoadMode.Color)
        {
            return new Mat(fileName, flags);
        }

        public static bool ImWrite(string fileName, Mat img, int[] prms = null)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            if (prms == null)
            {
                prms = new int[0];
            }
            try
            {
                return NativeMethods.highgui_imwrite(fileName, img.CvPtr, prms, prms.Length) != 0;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        public static bool ImWrite(string fileName, Mat img, params ImageEncodingParam[] prms)
        {
            if (prms != null)
            {
                List<int> list = new List<int>();
                foreach (ImageEncodingParam imageEncodingParam in prms)
                {
                    list.Add((int)imageEncodingParam.EncodingID);
                    list.Add(imageEncodingParam.Value);
                }
                return ImWrite(fileName, img, list.ToArray());
            }
            return ImWrite(fileName, img);
        }

        public static Mat ImDecode(Mat buf, LoadMode flags)
        {
            if (buf == null)
            {
                throw new ArgumentNullException("buf");
            }
            return new Mat(NativeMethods.highgui_imdecode_Mat(buf.CvPtr, (int)flags));
        }

        public static Mat ImDecode(byte[] buf, LoadMode flags)
        {
            if (buf == null)
            {
                throw new ArgumentNullException("buf");
            }
            return new Mat(NativeMethods.highgui_imdecode_vector(buf, new IntPtr(buf.LongLength), (int)flags));
        }

        public static bool ImEncode(string ext, InputArray img, out byte[] buf, int[] prms = null)
        {
            if (string.IsNullOrEmpty(ext))
            {
                throw new ArgumentNullException("ext");
            }
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            if (prms == null)
            {
                prms = new int[0];
            }
            img.ThrowIfDisposed();
            using (VectorOfByte vectorOfByte = new VectorOfByte())
            {
                int num = NativeMethods.highgui_imencode_vector(ext, img.CvPtr, vectorOfByte.CvPtr, prms, prms.Length);
                buf = vectorOfByte.ToArray();
                return num != 0;
            }
        }

        public static void ImEncode(string ext, InputArray img, out byte[] buf, params ImageEncodingParam[] prms)
        {
            if (prms != null)
            {
                List<int> list = new List<int>();
                foreach (ImageEncodingParam imageEncodingParam in prms)
                {
                    list.Add((int)imageEncodingParam.EncodingID);
                    list.Add(imageEncodingParam.Value);
                }
                ImEncode(ext, img, out buf, list.ToArray());
            }
            else
            {
                ImEncode(ext, img, out buf);
            }
        }

        public static int StartWindowThread()
        {
            return NativeMethods.highgui_startWindowThread();
        }

        public static int WaitKey(int delay = 0)
        {
            try
            {
                return NativeMethods.highgui_waitKey(delay);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        public static void ResizeWindow(string winName, int width, int height)
        {
            if (string.IsNullOrEmpty(winName))
            {
                throw new ArgumentNullException("winName");
            }
            NativeMethods.highgui_resizeWindow(winName, width, height);
        }

        public static void MoveWindow(string winName, int x, int y)
        {
            if (string.IsNullOrEmpty(winName))
            {
                throw new ArgumentNullException("winName");
            }
            NativeMethods.highgui_moveWindow(winName, x, y);
        }

        public static void SetWindowProperty(string winName, WindowProperty propId, WindowPropertyValue propValue)
        {
            if (string.IsNullOrEmpty(winName))
            {
                throw new ArgumentNullException("winName");
            }
            NativeMethods.highgui_setWindowProperty(winName, (int)propId, (double)propValue);
        }

        public static void SetWindowProperty(string winName, WindowProperty propId, double propValue)
        {
            if (string.IsNullOrEmpty(winName))
            {
                throw new ArgumentNullException("winName");
            }
            NativeMethods.highgui_setWindowProperty(winName, (int)propId, propValue);
        }

        public static WindowPropertyValue GetWindowProperty(string winName, WindowProperty propId)
        {
            if (string.IsNullOrEmpty(winName))
            {
                throw new ArgumentNullException("winName");
            }
            return (WindowPropertyValue)NativeMethods.highgui_getWindowProperty(winName, (int)propId);
        }

        public static void SetMouseCallback(string windowName, CvMouseCallback onMouse)
        {
            if (string.IsNullOrEmpty(windowName))
            {
                throw new ArgumentNullException("windowName");
            }
            if (onMouse == null)
            {
                throw new ArgumentNullException("onMouse");
            }
            Window windowByName = Window.GetWindowByName(windowName);
            if (windowByName != null)
            {
                windowByName.OnMouseCallback += onMouse;
            }
        }

        public static void ConvertImage(Mat src, Mat dst, ConvertImageFlag flags = ConvertImageFlag.None)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            dst.Create(src.Size(), MatType.CV_8UC3);
            NativeMethods.highgui_cvConvertImage_Mat(src.CvPtr, dst.CvPtr, (int)flags);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
        }

        public static void SetNumThreads(int nthreads)
        {
            NativeMethods.core_setNumThreads(nthreads);
        }

        public static int GetNumThreads()
        {
            return NativeMethods.core_getNumThreads();
        }

        public static int GetThreadNum()
        {
            return NativeMethods.core_getThreadNum();
        }

        public static string GetBuildInformation()
        {
            StringBuilder stringBuilder = new StringBuilder(65536);
            NativeMethods.core_getBuildInformation(stringBuilder, (uint)stringBuilder.Capacity);
            return stringBuilder.ToString();
        }

        public static long GetTickCount()
        {
            return NativeMethods.core_getTickCount();
        }

        public static double GetTickFrequency()
        {
            return NativeMethods.core_getTickFrequency();
        }

        public static long GetCpuTickCount()
        {
            return NativeMethods.core_getCPUTickCount();
        }

        public static bool CheckHardwareSupport(HardwareSupport feature)
        {
            return NativeMethods.core_checkHardwareSupport(feature) != 0;
        }

        public static int GetNumberOfCpus()
        {
            return NativeMethods.core_getNumberOfCPUs();
        }

        public static IntPtr FastMalloc(long bufSize)
        {
            return NativeMethods.core_fastMalloc(new IntPtr(bufSize));
        }

        public static void FastFree(IntPtr ptr)
        {
            NativeMethods.core_fastFree(ptr);
        }

        public static void SetUseOptimized(bool onoff)
        {
            NativeMethods.core_setUseOptimized(onoff ? 1 : 0);
        }

        public static bool UseOptimized()
        {
            return NativeMethods.core_useOptimized() != 0;
        }

        public static int AlignSize(int sz, int n)
        {
            if ((n & (n - 1)) != 0)
            {
                throw new ArgumentException();
            }
            return (sz + n - 1) & -n;
        }

        public static Mat CvArrToMat(CvArr arr, bool copyData = false, bool allowND = true, int coiMode = 0)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            arr.ThrowIfDisposed();
            return new Mat(NativeMethods.core_cvarrToMat(arr.CvPtr, copyData ? 1 : 0, allowND ? 1 : 0, coiMode));
        }

        public static void ExtractImageCOI(CvArr arr, OutputArray coiimg, int coi = -1)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            if (coiimg == null)
            {
                throw new ArgumentNullException("coiimg");
            }
            arr.ThrowIfDisposed();
            coiimg.ThrowIfNotReady();
            NativeMethods.core_extractImageCOI(arr.CvPtr, coiimg.CvPtr, coi);
            coiimg.Fix();
        }

        public static void InsertImageCOI(InputArray coiimg, CvArr arr, int coi = -1)
        {
            if (coiimg == null)
            {
                throw new ArgumentNullException("coiimg");
            }
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            coiimg.ThrowIfDisposed();
            arr.ThrowIfDisposed();
            NativeMethods.core_insertImageCOI(coiimg.CvPtr, arr.CvPtr, coi);
        }

        public static MatExpr Abs(Mat src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            src.ThrowIfDisposed();
            return new MatExpr(NativeMethods.core_abs_Mat(src.CvPtr));
        }

        public static MatExpr Abs(MatExpr src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            src.ThrowIfDisposed();
            return new MatExpr(NativeMethods.core_abs_MatExpr(src.CvPtr));
        }

        public static void Add(InputArray src1, InputArray src2, OutputArray dst, InputArray mask = null, int dtype = -1)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_add(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask), dtype);
            dst.Fix();
        }

        public static void Subtract(InputArray src1, InputArray src2, OutputArray dst, InputArray mask = null, int dtype = -1)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_subtract(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask), dtype);
            dst.Fix();
        }

        public static void Multiply(InputArray src1, InputArray src2, OutputArray dst, double scale = 1.0, int dtype = -1)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_multiply(src1.CvPtr, src2.CvPtr, dst.CvPtr, scale, dtype);
            dst.Fix();
        }

        public static void Divide(InputArray src1, InputArray src2, OutputArray dst, double scale = 1.0, int dtype = -1)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_divide(src1.CvPtr, src2.CvPtr, dst.CvPtr, scale, dtype);
            dst.Fix();
        }

        public static void Divide(double scale, InputArray src2, OutputArray dst, int dtype = -1)
        {
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_divide(scale, src2.CvPtr, dst.CvPtr, dtype);
            dst.Fix();
        }

        public static void ScaleAdd(InputArray src1, double alpha, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_scaleAdd(src1.CvPtr, alpha, src2.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static void AddWeighted(InputArray src1, double alpha, InputArray src2, double beta, double gamma, OutputArray dst, int dtype = -1)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_addWeighted(src1.CvPtr, alpha, src2.CvPtr, beta, gamma, dst.CvPtr, dtype);
            dst.Fix();
        }

        public static void ConvertScaleAbs(InputArray src, OutputArray dst, double alpha = 1.0, double beta = 0.0)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_convertScaleAbs(src.CvPtr, dst.CvPtr, alpha, beta);
            dst.Fix();
        }

        public static void LUT(InputArray src, InputArray lut, OutputArray dst, int interpolation = 0)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (lut == null)
            {
                throw new ArgumentNullException("lut");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            lut.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_LUT(src.CvPtr, lut.CvPtr, dst.CvPtr, interpolation);
        }

        public static void LUT(InputArray src, byte[] lut, OutputArray dst, int interpolation = 0)
        {
            if (lut == null)
            {
                throw new ArgumentNullException("lut");
            }
            if (lut.Length != 256)
            {
                throw new ArgumentException("lut.Length != 256");
            }
            using (Mat mat = new Mat(256, 1, MatType.CV_8UC1, lut, 0L))
            {
                LUT(src, mat, dst, interpolation);
            }
        }

        public static Scalar Sum(InputArray src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            src.ThrowIfDisposed();
            return NativeMethods.core_sum(src.CvPtr);
        }

        public static int CountNonZero(InputArray mtx)
        {
            if (mtx == null)
            {
                throw new ArgumentNullException("mtx");
            }
            mtx.ThrowIfDisposed();
            return NativeMethods.core_countNonZero(mtx.CvPtr);
        }

        public static void FindNonZero(InputArray src, OutputArray idx)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (idx == null)
            {
                throw new ArgumentNullException("idx");
            }
            src.ThrowIfDisposed();
            idx.ThrowIfNotReady();
            NativeMethods.core_findNonZero(src.CvPtr, idx.CvPtr);
            idx.Fix();
        }

        public static Scalar Mean(InputArray src, InputArray mask = null)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            src.ThrowIfDisposed();
            return NativeMethods.core_mean(src.CvPtr, ToPtr(mask));
        }

        public static void MeanStdDev(InputArray src, OutputArray mean, OutputArray stddev, InputArray mask = null)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (mean == null)
            {
                throw new ArgumentNullException("mean");
            }
            if (stddev == null)
            {
                throw new ArgumentNullException("stddev");
            }
            src.ThrowIfDisposed();
            mean.ThrowIfNotReady();
            stddev.ThrowIfNotReady();
            NativeMethods.core_meanStdDev_OutputArray(src.CvPtr, mean.CvPtr, stddev.CvPtr, ToPtr(mask));
            mean.Fix();
            stddev.Fix();
            GC.KeepAlive(src);
            GC.KeepAlive(mask);
        }

        public static void MeanStdDev(InputArray src, out Scalar mean, out Scalar stddev, InputArray mask = null)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			src.ThrowIfDisposed();
            CvScalar mean2, stddev2;
			NativeMethods.core_meanStdDev_Scalar(src.CvPtr, out mean2, out  stddev2, ToPtr(mask));
			mean = mean2;
			stddev = stddev2;
			GC.KeepAlive(src);
			GC.KeepAlive(mask);
		}

        public static double Norm(InputArray src1, NormType normType = NormType.L2, InputArray mask = null)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            src1.ThrowIfDisposed();
            return NativeMethods.core_norm(src1.CvPtr, (int)normType, ToPtr(mask));
        }

        public static double Norm(InputArray src1, InputArray src2, NormType normType = NormType.L2, InputArray mask = null)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            return NativeMethods.core_norm(src1.CvPtr, src2.CvPtr, (int)normType, ToPtr(mask));
        }

        public static void BatchDistance(InputArray src1, InputArray src2, OutputArray dist, int dtype, OutputArray nidx, NormType normType = NormType.L2, int k = 0, InputArray mask = null, int update = 0, bool crosscheck = false)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dist == null)
            {
                throw new ArgumentNullException("dist");
            }
            if (nidx == null)
            {
                throw new ArgumentNullException("nidx");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dist.ThrowIfNotReady();
            nidx.ThrowIfNotReady();
            NativeMethods.core_batchDistance(src1.CvPtr, src2.CvPtr, dist.CvPtr, dtype, nidx.CvPtr, (int)normType, k, ToPtr(mask), update, crosscheck ? 1 : 0);
            dist.Fix();
            nidx.Fix();
        }

        public static void Normalize(InputArray src, OutputArray dst, double alpha = 1.0, double beta = 0.0, NormType normType = NormType.L2, int dtype = -1, InputArray mask = null)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_normalize(src.CvPtr, dst.CvPtr, alpha, beta, (int)normType, dtype, ToPtr(mask));
            dst.Fix();
        }

        public static void MinMaxLoc(InputArray src, out double minVal, out double maxVal)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            src.ThrowIfDisposed();
            NativeMethods.core_minMaxLoc1(src.CvPtr, out minVal, out maxVal);
            GC.KeepAlive(src);
        }

        public static void MinMaxLoc(InputArray src, out Point minLoc, out Point maxLoc)
		{
            double _1,_2;
			MinMaxLoc(src, out _1, out _2, out minLoc, out maxLoc);
		}

        public static void MinMaxLoc(InputArray src, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc, InputArray mask = null)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			src.ThrowIfDisposed();
            CvPoint minLoc2,maxLoc2;
			NativeMethods.core_minMaxLoc2(src.CvPtr, out minVal, out maxVal, out  minLoc2, out  maxLoc2, ToPtr(mask));
			minLoc = minLoc2;
			maxLoc = maxLoc2;
			GC.KeepAlive(src);
		}

        public static void MinMaxIdx(InputArray src, out double minVal, out double maxVal)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            src.ThrowIfDisposed();
            NativeMethods.core_minMaxIdx1(src.CvPtr, out minVal, out maxVal);
            GC.KeepAlive(src);
        }

        public static void MinMaxIdx(InputArray src, out int minIdx, out int maxIdx)
		{
            double _1,_2;
			MinMaxIdx(src, out _1, out _2, out minIdx, out maxIdx);
		}

        public static void MinMaxIdx(InputArray src, out double minVal, out double maxVal, out int minIdx, out int maxIdx, InputArray mask = null)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            src.ThrowIfDisposed();
            NativeMethods.core_minMaxIdx2(src.CvPtr, out minVal, out maxVal, out minIdx, out maxIdx, ToPtr(mask));
            GC.KeepAlive(src);
        }

        public static void Reduce(InputArray src, OutputArray dst, ReduceDimension dim, ReduceOperation rtype, int dtype)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_reduce(src.CvPtr, dst.CvPtr, (int)dim, (int)rtype, dtype);
            dst.Fix();
        }

        public static void Merge(Mat[] mv, Mat dst)
        {
            if (mv == null)
            {
                throw new ArgumentNullException("mv");
            }
            if (mv.Length == 0)
            {
                throw new ArgumentException("mv.Length == 0");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            foreach (Mat obj in mv)
            {
                if (obj == null)
                {
                    throw new ArgumentException("mv contains null element");
                }
                obj.ThrowIfDisposed();
            }
            dst.ThrowIfDisposed();
            IntPtr[] array = new IntPtr[mv.Length];
            for (int j = 0; j < mv.Length; j++)
            {
                array[j] = mv[j].CvPtr;
            }
            NativeMethods.core_merge(array, (uint)array.Length, dst.CvPtr);
        }

        public static void Split(Mat src, out Mat[] mv)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			src.ThrowIfDisposed();
            IntPtr mv2;
            NativeMethods.core_split(src.CvPtr, out mv2);
			using (VectorOfMat vectorOfMat = new VectorOfMat(mv2))
			{
				mv = vectorOfMat.ToArray();
			}
		}

        public static Mat[] Split(Mat src)
		{
            Mat[] mv;
            Split(src, out mv);
			return mv;
		}

        public static void MixChannels(Mat[] src, Mat[] dst, int[] fromTo)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (fromTo == null)
            {
                throw new ArgumentNullException("fromTo");
            }
            if (src.Length == 0)
            {
                throw new ArgumentException("src.Length == 0");
            }
            if (dst.Length == 0)
            {
                throw new ArgumentException("dst.Length == 0");
            }
            if (fromTo.Length == 0 || fromTo.Length % 2 != 0)
            {
                throw new ArgumentException("fromTo.Length == 0");
            }
            IntPtr[] array = new IntPtr[src.Length];
            IntPtr[] array2 = new IntPtr[dst.Length];
            for (int i = 0; i < src.Length; i++)
            {
                src[i].ThrowIfDisposed();
                array[i] = src[i].CvPtr;
            }
            for (int j = 0; j < dst.Length; j++)
            {
                dst[j].ThrowIfDisposed();
                array2[j] = dst[j].CvPtr;
            }
            NativeMethods.core_mixChannels(array, (uint)src.Length, array2, (uint)dst.Length, fromTo, (uint)(fromTo.Length / 2));
        }

        public static void ExtractChannel(InputArray src, OutputArray dst, int coi)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_extractChannel(src.CvPtr, dst.CvPtr, coi);
            dst.Fix();
        }

        public static void InsertChannel(InputArray src, InputOutputArray dst, int coi)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_insertChannel(src.CvPtr, dst.CvPtr, coi);
            dst.Fix();
        }

        public static void Flip(InputArray src, OutputArray dst, FlipMode flipCode)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_flip(src.CvPtr, dst.CvPtr, (int)flipCode);
            dst.Fix();
        }

        public static void Repeat(InputArray src, int ny, int nx, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_repeat(src.CvPtr, ny, nx, dst.CvPtr);
            dst.Fix();
        }

        public static Mat Repeat(Mat src, int ny, int nx)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            src.ThrowIfDisposed();
            return new Mat(NativeMethods.core_repeat(src.CvPtr, ny, nx));
        }

        public static void HConcat(Mat[] src, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (src.Length == 0)
            {
                throw new ArgumentException("src.Length == 0");
            }
            IntPtr[] array = new IntPtr[src.Length];
            for (int i = 0; i < src.Length; i++)
            {
                src[i].ThrowIfDisposed();
                array[i] = src[i].CvPtr;
            }
            NativeMethods.core_hconcat(array, (uint)src.Length, dst.CvPtr);
            dst.Fix();
        }

        public static void HConcat(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_hconcat(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static void VConcat(Mat[] src, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (src.Length == 0)
            {
                throw new ArgumentException("src.Length == 0");
            }
            IntPtr[] array = new IntPtr[src.Length];
            for (int i = 0; i < src.Length; i++)
            {
                src[i].ThrowIfDisposed();
                array[i] = src[i].CvPtr;
            }
            NativeMethods.core_vconcat(array, (uint)src.Length, dst.CvPtr);
            dst.Fix();
        }

        public static void VConcat(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_vconcat(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static void BitwiseAnd(InputArray src1, InputArray src2, OutputArray dst, InputArray mask = null)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_bitwise_and(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }

        public static void BitwiseOr(InputArray src1, InputArray src2, OutputArray dst, InputArray mask = null)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_bitwise_or(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }

        public static void BitwiseXor(InputArray src1, InputArray src2, OutputArray dst, InputArray mask = null)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_bitwise_xor(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }

        public static void BitwiseNot(InputArray src, OutputArray dst, InputArray mask = null)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_bitwise_not(src.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }

        public static void Absdiff(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_absdiff(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static void InRange(InputArray src, InputArray lowerb, InputArray upperb, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (lowerb == null)
            {
                throw new ArgumentNullException("lowerb");
            }
            if (upperb == null)
            {
                throw new ArgumentNullException("upperb");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            lowerb.ThrowIfDisposed();
            upperb.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_inRange(src.CvPtr, lowerb.CvPtr, upperb.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static void InRange(InputArray src, Scalar lowerb, Scalar upperb, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_inRange(src.CvPtr, lowerb, upperb, dst.CvPtr);
            dst.Fix();
        }

        public static void Compare(InputArray src1, InputArray src2, OutputArray dst, ArrComparison cmpop)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_compare(src1.CvPtr, src2.CvPtr, dst.CvPtr, (int)cmpop);
            dst.Fix();
        }

        public static void Min(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_min1(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static void Min(Mat src1, Mat src2, Mat dst)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            NativeMethods.core_min_MatMat(src1.CvPtr, src2.CvPtr, dst.CvPtr);
        }

        public static void Min(Mat src1, double src2, Mat dst)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            NativeMethods.core_min_MatDouble(src1.CvPtr, src2, dst.CvPtr);
        }

        public static void Max(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_max1(src1.CvPtr, src2.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static void Max(Mat src1, Mat src2, Mat dst)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            NativeMethods.core_max_MatMat(src1.CvPtr, src2.CvPtr, dst.CvPtr);
        }

        public static void Max(Mat src1, double src2, Mat dst)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            NativeMethods.core_max_MatDouble(src1.CvPtr, src2, dst.CvPtr);
        }

        public static void Sqrt(InputArray src, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_sqrt(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static void Pow(InputArray src, double power, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_pow_Mat(src.CvPtr, power, dst.CvPtr);
            dst.Fix();
        }

        public static void Exp(InputArray src, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_exp_Mat(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static float[] Exp(float[] src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            float[] array = new float[src.Length];
            NativeMethods.core_exp_Array(src, array, array.Length);
            return array;
        }

        public static void Log(InputArray src, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_log_Mat(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static float[] Log(float[] src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            float[] array = new float[src.Length];
            NativeMethods.core_log_Array(src, array, array.Length);
            return array;
        }

        public static float CubeRoot(float val)
        {
            return NativeMethods.core_cubeRoot(val);
        }

        public static float FastAtan2(float y, float x)
        {
            return NativeMethods.core_fastAtan2(y, x);
        }

        public static float[] FastAtan2(float[] y, float[] x, bool angleInDegrees)
        {
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y.Length != x.Length)
            {
                throw new ArgumentException("y.Length != x.Length");
            }
            if (y.Length == 0)
            {
                throw new ArgumentException("y.Length == 0");
            }
            float[] array = new float[y.Length];
            NativeMethods.core_fastAtan2_Array(y, x, array, array.Length, angleInDegrees ? 1 : 0);
            return array;
        }

        public static void PolarToCart(InputArray magnitude, InputArray angle, OutputArray x, OutputArray y, bool angleInDegrees = false)
        {
            if (magnitude == null)
            {
                throw new ArgumentNullException("magnitude");
            }
            if (angle == null)
            {
                throw new ArgumentNullException("angle");
            }
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            magnitude.ThrowIfDisposed();
            angle.ThrowIfDisposed();
            x.ThrowIfNotReady();
            y.ThrowIfNotReady();
            NativeMethods.core_polarToCart(magnitude.CvPtr, angle.CvPtr, x.CvPtr, y.CvPtr, angleInDegrees ? 1 : 0);
            x.Fix();
            y.Fix();
        }

        public static void CartToPolar(InputArray x, InputArray y, OutputArray magnitude, OutputArray angle, bool angleInDegrees = false)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            if (magnitude == null)
            {
                throw new ArgumentNullException("magnitude");
            }
            if (angle == null)
            {
                throw new ArgumentNullException("angle");
            }
            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            magnitude.ThrowIfNotReady();
            angle.ThrowIfNotReady();
            NativeMethods.core_cartToPolar(x.CvPtr, y.CvPtr, magnitude.CvPtr, angle.CvPtr, angleInDegrees ? 1 : 0);
            magnitude.Fix();
            angle.Fix();
        }

        public static void Phase(InputArray x, InputArray y, OutputArray angle, bool angleInDegrees = false)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            if (angle == null)
            {
                throw new ArgumentNullException("angle");
            }
            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            angle.ThrowIfNotReady();
            NativeMethods.core_phase(x.CvPtr, y.CvPtr, angle.CvPtr, angleInDegrees ? 1 : 0);
            angle.Fix();
        }

        public static void Magnitude(InputArray x, InputArray y, OutputArray magnitude)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            if (magnitude == null)
            {
                throw new ArgumentNullException("magnitude");
            }
            x.ThrowIfDisposed();
            y.ThrowIfDisposed();
            magnitude.ThrowIfNotReady();
            NativeMethods.core_magnitude_Mat(x.CvPtr, y.CvPtr, magnitude.CvPtr);
            magnitude.Fix();
        }

        public static float[] Magnitude(float[] x, float[] y)
        {
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y.Length != x.Length)
            {
                throw new ArgumentException("y.Length != x.Length");
            }
            if (y.Length == 0)
            {
                throw new ArgumentException("y.Length == 0");
            }
            float[] array = new float[y.Length];
            NativeMethods.core_magnitude_Array(y, x, array, array.Length);
            return array;
        }

        public static bool CheckRange(InputArray src, bool quiet = true)
        {
            Point pos;
            return CheckRange(src, quiet, out pos);
        }

        public static bool CheckRange(InputArray src, bool quiet, out Point pos, double minVal = double.MinValue, double maxVal = double.MaxValue)
        {
            if (src == null)
            {
                throw new ArgumentNullException("a");
            }
            src.ThrowIfDisposed();
            CvPoint pos2;
            int num = NativeMethods.core_checkRange(src.CvPtr, quiet ? 1 : 0, out pos2, minVal, maxVal);
            pos = pos2;
            return num != 0;
        }

        public static void PatchNaNs(InputOutputArray a, double val = 0.0)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            a.ThrowIfNotReady();
            NativeMethods.core_patchNaNs(a.CvPtr, val);
        }

        public static void Gemm(InputArray src1, InputArray src2, double alpha, InputArray src3, double gamma, OutputArray dst, GemmOperation flags = GemmOperation.Zero)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (src3 == null)
            {
                throw new ArgumentNullException("src3");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            src3.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_gemm(src1.CvPtr, src2.CvPtr, alpha, src3.CvPtr, gamma, dst.CvPtr, (int)flags);
            dst.Fix();
        }

        public static void MulTransposed(InputArray src, OutputArray dst, bool aTa, InputArray delta = null, double scale = 1.0, int dtype = -1)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_mulTransposed(src.CvPtr, dst.CvPtr, aTa ? 1 : 0, ToPtr(delta), scale, dtype);
            dst.Fix();
        }

        public static void Transpose(InputArray src, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_transpose(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static void Transform(InputArray src, OutputArray dst, InputArray m)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            m.ThrowIfDisposed();
            NativeMethods.core_transform(src.CvPtr, dst.CvPtr, m.CvPtr);
            dst.Fix();
        }

        public static void PerspectiveTransform(InputArray src, OutputArray dst, InputArray m)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            m.ThrowIfDisposed();
            NativeMethods.core_perspectiveTransform(src.CvPtr, dst.CvPtr, m.CvPtr);
            GC.KeepAlive(src);
            dst.Fix();
        }

        public static Point2f[] PerspectiveTransform(IEnumerable<Point2f> src, Mat m)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            using (MatOfPoint2f matOfPoint2f = MatOfPoint2f.FromArray(src))
            {
                using (MatOfPoint2f matOfPoint2f2 = new MatOfPoint2f())
                {
                    NativeMethods.core_perspectiveTransform_Mat(matOfPoint2f.CvPtr, matOfPoint2f2.CvPtr, m.CvPtr);
                    return matOfPoint2f2.ToArray();
                }
            }
        }

        public static Point2d[] PerspectiveTransform(IEnumerable<Point2d> src, Mat m)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            using (MatOfPoint2d matOfPoint2d = MatOfPoint2d.FromArray(src))
            {
                using (MatOfPoint2d matOfPoint2d2 = new MatOfPoint2d())
                {
                    NativeMethods.core_perspectiveTransform_Mat(matOfPoint2d.CvPtr, matOfPoint2d2.CvPtr, m.CvPtr);
                    return matOfPoint2d2.ToArray();
                }
            }
        }

        public static Point3f[] PerspectiveTransform(IEnumerable<Point3f> src, Mat m)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            using (MatOfPoint3f matOfPoint3f = MatOfPoint3f.FromArray(src))
            {
                using (MatOfPoint3f matOfPoint3f2 = new MatOfPoint3f())
                {
                    NativeMethods.core_perspectiveTransform_Mat(matOfPoint3f.CvPtr, matOfPoint3f2.CvPtr, m.CvPtr);
                    return matOfPoint3f2.ToArray();
                }
            }
        }

        public static Point3d[] PerspectiveTransform(IEnumerable<Point3d> src, Mat m)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            using (MatOfPoint3d matOfPoint3d = MatOfPoint3d.FromArray(src))
            {
                using (MatOfPoint3d matOfPoint3d2 = new MatOfPoint3d())
                {
                    NativeMethods.core_perspectiveTransform_Mat(matOfPoint3d.CvPtr, matOfPoint3d2.CvPtr, m.CvPtr);
                    return matOfPoint3d2.ToArray();
                }
            }
        }

        public static void CompleteSymm(InputOutputArray mtx, bool lowerToUpper = false)
        {
            if (mtx == null)
            {
                throw new ArgumentNullException("mtx");
            }
            mtx.ThrowIfNotReady();
            NativeMethods.core_completeSymm(mtx.CvPtr, lowerToUpper ? 1 : 0);
        }

        public static void SetIdentity(InputOutputArray mtx, Scalar? s = default(Scalar?))
        {
            if (mtx == null)
            {
                throw new ArgumentNullException("mtx");
            }
            mtx.ThrowIfNotReady();
            Scalar valueOrDefault = s.GetValueOrDefault(new Scalar(1.0));
            NativeMethods.core_setIdentity(mtx.CvPtr, valueOrDefault);
        }

        public static double Determinant(InputArray mtx)
        {
            if (mtx == null)
            {
                throw new ArgumentNullException("mtx");
            }
            mtx.ThrowIfDisposed();
            return NativeMethods.core_determinant(mtx.CvPtr);
        }

        public static Scalar Trace(InputArray mtx)
        {
            if (mtx == null)
            {
                throw new ArgumentNullException("mtx");
            }
            mtx.ThrowIfDisposed();
            return NativeMethods.core_trace(mtx.CvPtr);
        }

        public static double Invert(InputArray src, OutputArray dst, MatrixDecomposition flags = MatrixDecomposition.LU)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            double result = NativeMethods.core_invert(src.CvPtr, dst.CvPtr, (int)flags);
            dst.Fix();
            return result;
        }

        public static bool Solve(InputArray src1, InputArray src2, OutputArray dst, MatrixDecomposition flags = MatrixDecomposition.LU)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            int num = NativeMethods.core_solve(src1.CvPtr, src2.CvPtr, dst.CvPtr, (int)flags);
            dst.Fix();
            return num != 0;
        }

        public static void Sort(InputArray src, OutputArray dst, SortFlag flags)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_sort(src.CvPtr, dst.CvPtr, (int)flags);
            dst.Fix();
        }

        public static void SortIdx(InputArray src, OutputArray dst, SortFlag flags)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_sortIdx(src.CvPtr, dst.CvPtr, (int)flags);
            dst.Fix();
        }

        public static int SolveCubic(InputArray coeffs, OutputArray roots)
        {
            if (coeffs == null)
            {
                throw new ArgumentNullException("coeffs");
            }
            if (roots == null)
            {
                throw new ArgumentNullException("roots");
            }
            coeffs.ThrowIfDisposed();
            roots.ThrowIfNotReady();
            int result = NativeMethods.core_solveCubic(coeffs.CvPtr, roots.CvPtr);
            roots.Fix();
            return result;
        }

        public static double SolvePoly(InputArray coeffs, OutputArray roots, int maxIters = 300)
        {
            if (coeffs == null)
            {
                throw new ArgumentNullException("coeffs");
            }
            if (roots == null)
            {
                throw new ArgumentNullException("roots");
            }
            coeffs.ThrowIfDisposed();
            roots.ThrowIfNotReady();
            double result = NativeMethods.core_solvePoly(coeffs.CvPtr, roots.CvPtr, maxIters);
            roots.Fix();
            return result;
        }

        public static bool Eigen(InputArray src, OutputArray eigenvalues, int lowindex = -1, int highindex = -1)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (eigenvalues == null)
            {
                throw new ArgumentNullException("eigenvalues");
            }
            src.ThrowIfDisposed();
            eigenvalues.ThrowIfNotReady();
            int num = NativeMethods.core_eigen(src.CvPtr, eigenvalues.CvPtr, lowindex, highindex);
            eigenvalues.Fix();
            return num != 0;
        }

        public static bool Eigen(InputArray src, OutputArray eigenvalues, OutputArray eigenvectors, int lowindex = -1, int highindex = -1)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (eigenvalues == null)
            {
                throw new ArgumentNullException("eigenvalues");
            }
            if (eigenvectors == null)
            {
                throw new ArgumentNullException("eigenvectors");
            }
            src.ThrowIfDisposed();
            eigenvalues.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();
            int num = NativeMethods.core_eigen(src.CvPtr, eigenvalues.CvPtr, eigenvectors.CvPtr, lowindex, highindex);
            eigenvalues.Fix();
            eigenvectors.Fix();
            return num != 0;
        }

        public static bool Eigen(InputArray src, bool computeEigenvectors, OutputArray eigenvalues, OutputArray eigenvectors)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (eigenvalues == null)
            {
                throw new ArgumentNullException("eigenvalues");
            }
            if (eigenvectors == null)
            {
                throw new ArgumentNullException("eigenvectors");
            }
            src.ThrowIfDisposed();
            eigenvalues.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();
            int num = NativeMethods.core_eigen(src.CvPtr, computeEigenvectors, eigenvalues.CvPtr, eigenvectors.CvPtr);
            eigenvalues.Fix();
            eigenvectors.Fix();
            return num != 0;
        }

        public static void CalcCovarMatrix(Mat[] samples, Mat covar, Mat mean, CovarMatrixFlag flags)
        {
            CalcCovarMatrix(samples, covar, mean, flags, 6);
        }

        public static void CalcCovarMatrix(Mat[] samples, Mat covar, Mat mean, CovarMatrixFlag flags, MatType ctype)
        {
            if (samples == null)
            {
                throw new ArgumentNullException("samples");
            }
            if (covar == null)
            {
                throw new ArgumentNullException("covar");
            }
            if (mean == null)
            {
                throw new ArgumentNullException("mean");
            }
            covar.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            NativeMethods.core_calcCovarMatrix_Mat(EnumerableEx.SelectPtrs(samples), samples.Length, covar.CvPtr, mean.CvPtr, (int)flags, ctype);
        }

        public static void CalcCovarMatrix(InputArray samples, OutputArray covar, OutputArray mean, CovarMatrixFlag flags)
        {
            CalcCovarMatrix(samples, covar, mean, flags, 6);
        }

        public static void CalcCovarMatrix(InputArray samples, OutputArray covar, OutputArray mean, CovarMatrixFlag flags, MatType ctype)
        {
            if (samples == null)
            {
                throw new ArgumentNullException("samples");
            }
            if (covar == null)
            {
                throw new ArgumentNullException("covar");
            }
            if (mean == null)
            {
                throw new ArgumentNullException("mean");
            }
            samples.ThrowIfDisposed();
            covar.ThrowIfNotReady();
            mean.ThrowIfNotReady();
            NativeMethods.core_calcCovarMatrix_InputArray(samples.CvPtr, covar.CvPtr, mean.CvPtr, (int)flags, ctype);
            covar.Fix();
            mean.Fix();
        }

        public static void PCACompute(InputArray data, InputOutputArray mean, OutputArray eigenvectors, int maxComponents = 0)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (mean == null)
            {
                throw new ArgumentNullException("mean");
            }
            if (eigenvectors == null)
            {
                throw new ArgumentNullException("eigenvectors");
            }
            data.ThrowIfDisposed();
            mean.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();
            NativeMethods.core_PCACompute(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, maxComponents);
            mean.Fix();
            eigenvectors.Fix();
        }

        public static void PCAComputeVar(InputArray data, InputOutputArray mean, OutputArray eigenvectors, double retainedVariance)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (mean == null)
            {
                throw new ArgumentNullException("mean");
            }
            if (eigenvectors == null)
            {
                throw new ArgumentNullException("eigenvectors");
            }
            data.ThrowIfDisposed();
            mean.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();
            NativeMethods.core_PCAComputeVar(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, retainedVariance);
            mean.Fix();
            eigenvectors.Fix();
        }

        public static void PCAProject(InputArray data, InputArray mean, InputArray eigenvectors, OutputArray result)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (mean == null)
            {
                throw new ArgumentNullException("mean");
            }
            if (eigenvectors == null)
            {
                throw new ArgumentNullException("eigenvectors");
            }
            if (result == null)
            {
                throw new ArgumentNullException("result");
            }
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            eigenvectors.ThrowIfDisposed();
            result.ThrowIfNotReady();
            NativeMethods.core_PCAProject(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, result.CvPtr);
            result.Fix();
        }

        public static void PCABackProject(InputArray data, InputArray mean, InputArray eigenvectors, OutputArray result)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (mean == null)
            {
                throw new ArgumentNullException("mean");
            }
            if (eigenvectors == null)
            {
                throw new ArgumentNullException("eigenvectors");
            }
            if (result == null)
            {
                throw new ArgumentNullException("result");
            }
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            eigenvectors.ThrowIfDisposed();
            result.ThrowIfNotReady();
            NativeMethods.core_PCABackProject(data.CvPtr, mean.CvPtr, eigenvectors.CvPtr, result.CvPtr);
            result.Fix();
        }

        public static void SVDecomp(InputArray src, OutputArray w, OutputArray u, OutputArray vt, SVDFlag flags = SVDFlag.Zero)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (w == null)
            {
                throw new ArgumentNullException("w");
            }
            if (u == null)
            {
                throw new ArgumentNullException("u");
            }
            if (vt == null)
            {
                throw new ArgumentNullException("vt");
            }
            src.ThrowIfDisposed();
            w.ThrowIfNotReady();
            u.ThrowIfNotReady();
            vt.ThrowIfNotReady();
            NativeMethods.core_SVDecomp(src.CvPtr, w.CvPtr, u.CvPtr, vt.CvPtr, (int)flags);
            w.Fix();
            u.Fix();
            vt.Fix();
        }

        public static void SVBackSubst(InputArray w, InputArray u, InputArray vt, InputArray rhs, OutputArray dst)
        {
            if (w == null)
            {
                throw new ArgumentNullException("w");
            }
            if (u == null)
            {
                throw new ArgumentNullException("u");
            }
            if (vt == null)
            {
                throw new ArgumentNullException("vt");
            }
            if (rhs == null)
            {
                throw new ArgumentNullException("rhs");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            w.ThrowIfDisposed();
            u.ThrowIfDisposed();
            vt.ThrowIfDisposed();
            rhs.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_SVBackSubst(w.CvPtr, u.CvPtr, vt.CvPtr, rhs.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static double Mahalanobis(InputArray v1, InputArray v2, InputArray icovar)
        {
            if (v1 == null)
            {
                throw new ArgumentNullException("v1");
            }
            if (v2 == null)
            {
                throw new ArgumentNullException("v2");
            }
            if (icovar == null)
            {
                throw new ArgumentNullException("icovar");
            }
            v1.ThrowIfDisposed();
            v2.ThrowIfDisposed();
            icovar.ThrowIfDisposed();
            return NativeMethods.core_Mahalanobis(v1.CvPtr, v2.CvPtr, icovar.CvPtr);
        }

        public static double Mahalonobis(InputArray v1, InputArray v2, InputArray icovar)
        {
            return Mahalanobis(v1, v2, icovar);
        }

        public static void Dft(InputArray src, OutputArray dst, DftFlag2 flags = DftFlag2.None, int nonzeroRows = 0)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_dft(src.CvPtr, dst.CvPtr, (int)flags, nonzeroRows);
            dst.Fix();
        }

        public static void Idft(InputArray src, OutputArray dst, DftFlag2 flags = DftFlag2.None, int nonzeroRows = 0)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_idft(src.CvPtr, dst.CvPtr, (int)flags, nonzeroRows);
            dst.Fix();
        }

        public static void Dct(InputArray src, OutputArray dst, DctFlag2 flags = DctFlag2.None)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_dct(src.CvPtr, dst.CvPtr, (int)flags);
            dst.Fix();
        }

        public static void Idct(InputArray src, OutputArray dst, DctFlag2 flags = DctFlag2.None)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_idct(src.CvPtr, dst.CvPtr, (int)flags);
            dst.Fix();
        }

        public static void MulSpectrums(InputArray a, InputArray b, OutputArray c, MulSpectrumsFlag flags, bool conjB = false)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            if (b == null)
            {
                throw new ArgumentNullException("b");
            }
            if (c == null)
            {
                throw new ArgumentNullException("c");
            }
            a.ThrowIfDisposed();
            b.ThrowIfDisposed();
            c.ThrowIfNotReady();
            NativeMethods.core_mulSpectrums(a.CvPtr, b.CvPtr, c.CvPtr, (int)flags, conjB ? 1 : 0);
            c.Fix();
        }

        public static int GetOptimalDFTSize(int vecsize)
        {
            return NativeMethods.core_getOptimalDFTSize(vecsize);
        }

        public static double Kmeans(InputArray data, int k, InputOutputArray bestLabels, TermCriteria criteria, int attempts, KMeansFlag flags, OutputArray centers = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (bestLabels == null)
			{
				throw new ArgumentNullException("bestLabels");
			}
			data.ThrowIfDisposed();
			bestLabels.ThrowIfDisposed();
			double result = NativeMethods.core_kmeans(data.CvPtr, k, bestLabels.CvPtr, criteria, attempts, (int)flags, ToPtr(centers));
			bestLabels.Fix();
            if(centers != null) centers.Fix();
			return result;
		}

        public static RNG TheRNG()
        {
            return new RNG(NativeMethods.core_theRNG());
        }

        public static void Randu(InputOutputArray dst, InputArray low, InputArray high)
        {
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (low == null)
            {
                throw new ArgumentNullException("low");
            }
            if (high == null)
            {
                throw new ArgumentNullException("high");
            }
            dst.ThrowIfNotReady();
            low.ThrowIfDisposed();
            high.ThrowIfDisposed();
            NativeMethods.core_randu_InputArray(dst.CvPtr, low.CvPtr, high.CvPtr);
            dst.Fix();
        }

        public static void Randu(InputOutputArray dst, Scalar low, Scalar high)
        {
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            dst.ThrowIfNotReady();
            NativeMethods.core_randu_Scalar(dst.CvPtr, low, high);
            dst.Fix();
        }

        public static void Randn(InputOutputArray dst, InputArray mean, InputArray stddev)
        {
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (mean == null)
            {
                throw new ArgumentNullException("mean");
            }
            if (stddev == null)
            {
                throw new ArgumentNullException("stddev");
            }
            dst.ThrowIfNotReady();
            mean.ThrowIfDisposed();
            stddev.ThrowIfDisposed();
            NativeMethods.core_randn_InputArray(dst.CvPtr, mean.CvPtr, stddev.CvPtr);
            dst.Fix();
        }

        public static void Randn(InputOutputArray dst, Scalar mean, Scalar stddev)
        {
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            dst.ThrowIfNotReady();
            NativeMethods.core_randn_Scalar(dst.CvPtr, mean, stddev);
            dst.Fix();
        }

        public static void RandShuffle(InputOutputArray dst, double iterFactor, RNG rng = null)
        {
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            dst.ThrowIfNotReady();
            if (rng == null)
            {
                NativeMethods.core_randShuffle(dst.CvPtr, iterFactor, IntPtr.Zero);
            }
            else
            {
                ulong rng2 = rng.State;
                NativeMethods.core_randShuffle(dst.CvPtr, iterFactor, ref rng2);
                rng.State = rng2;
            }
            dst.Fix();
        }

        public static void Line(Mat img, int pt1X, int pt1Y, int pt2X, int pt2Y, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Line(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness, lineType, shift);
        }

        public static void Line(Mat img, Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            img.ThrowIfDisposed();
            NativeMethods.core_line(img.CvPtr, pt1, pt2, color, thickness, (int)lineType, shift);
        }

        public static void Rectangle(Mat img, Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            NativeMethods.core_rectangle(img.CvPtr, pt1, pt2, color, thickness, (int)lineType, shift);
        }

        public static void Rectangle(Mat img, Rect rect, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            NativeMethods.core_rectangle(img.CvPtr, rect, color, thickness, (int)lineType, shift);
        }

        public static void Circle(Mat img, int centerX, int centerY, int radius, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Circle(img, new Point(centerX, centerY), radius, color, thickness, lineType, shift);
        }

        public static void Circle(Mat img, Point center, int radius, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            img.ThrowIfDisposed();
            NativeMethods.core_circle(img.CvPtr, center, radius, color, thickness, (int)lineType, shift);
        }

        public static void Ellipse(Mat img, Point center, Size axes, double angle, double startAngle, double endAngle, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            img.ThrowIfDisposed();
            NativeMethods.core_ellipse(img.CvPtr, center, axes, angle, startAngle, endAngle, color, thickness, (int)lineType, shift);
        }

        public static void Ellipse(Mat img, RotatedRect box, Scalar color, int thickness = 1, LineType lineType = LineType.Link8)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            img.ThrowIfDisposed();
            NativeMethods.core_ellipse(img.CvPtr, box, color, thickness, (int)lineType);
        }

        public static void FillConvexPoly(Mat img, IEnumerable<Point> pts, Scalar color, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            img.ThrowIfDisposed();
            Point[] array = Util.ToArray(pts);
            NativeMethods.core_fillConvexPoly(img.CvPtr, array, array.Length, color, (int)lineType, shift);
        }

        public static void FillPoly(Mat img, IEnumerable<IEnumerable<Point>> pts, Scalar color, LineType lineType = LineType.Link8, int shift = 0, Point? offset = default(Point?))
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            img.ThrowIfDisposed();
            Point valueOrDefault = offset.GetValueOrDefault(default(Point));
            List<Point[]> list = new List<Point[]>();
            List<int> list2 = new List<int>();
            foreach (IEnumerable<Point> pt in pts)
            {
                Point[] array = Util.ToArray(pt);
                list.Add(array);
                list2.Add(array.Length);
            }
            Point[][] array2 = list.ToArray();
            int[] npts = list2.ToArray();
            int ncontours = array2.Length;
            using (ArrayAddress2<Point> arrayAddress = new ArrayAddress2<Point>(array2))
            {
                NativeMethods.core_fillPoly(img.CvPtr, arrayAddress.Pointer, npts, ncontours, color, (int)lineType, shift, valueOrDefault);
            }
        }

        public static void Polylines(Mat img, IEnumerable<IEnumerable<Point>> pts, bool isClosed, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            img.ThrowIfDisposed();
            List<Point[]> list = new List<Point[]>();
            List<int> list2 = new List<int>();
            foreach (IEnumerable<Point> pt in pts)
            {
                Point[] array = Util.ToArray(pt);
                list.Add(array);
                list2.Add(array.Length);
            }
            Point[][] array2 = list.ToArray();
            int[] npts = list2.ToArray();
            int ncontours = array2.Length;
            using (ArrayAddress2<Point> arrayAddress = new ArrayAddress2<Point>(array2))
            {
                NativeMethods.core_polylines(img.CvPtr, arrayAddress.Pointer, npts, ncontours, isClosed ? 1 : 0, color, thickness, (int)lineType, shift);
            }
        }

        public static bool ClipLine(Size imgSize, ref Point pt1, ref Point pt2)
        {
            return NativeMethods.core_clipLine(imgSize, ref pt1, ref pt2) != 0;
        }

        public static bool ClipLine(Rect imgRect, ref Point pt1, ref Point pt2)
        {
            return NativeMethods.core_clipLine(imgRect, ref pt1, ref pt2) != 0;
        }

        public static void PutText(Mat img, string text, Point org, FontFace fontFace, double fontScale, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, bool bottomLeftOrigin = false)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(text);
            }
            img.ThrowIfDisposed();
            NativeMethods.core_putText(img.CvPtr, text, org, (int)fontFace, fontScale, color, thickness, (int)lineType, bottomLeftOrigin ? 1 : 0);
        }

        public static Size GetTextSize(string text, FontFace fontFace, double fontScale, int thickness, out int baseLine)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(text);
            }
            return NativeMethods.core_getTextSize(text, (int)fontFace, fontScale, thickness, out baseLine);
        }

        public static Mat GetGaborKernel(Size ksize, double sigma, double theta, double lambd, double gamma, double psi, int ktype)
        {
            return new Mat(NativeMethods.imgproc_getGaborKernel(ksize, sigma, theta, lambd, gamma, psi, ktype));
        }

        public static Mat GetStructuringElement(StructuringElementShape shape, Size ksize)
        {
            return GetStructuringElement(shape, ksize, new Point(-1, -1));
        }

        public static Mat GetStructuringElement(StructuringElementShape shape, Size ksize, Point anchor)
        {
            return new Mat(NativeMethods.imgproc_getStructuringElement((int)shape, ksize, anchor));
        }

        public static void CopyMakeBorder(InputArray src, OutputArray dst, int top, int bottom, int left, int right, BorderType borderType, Scalar? value = default(Scalar?))
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            Scalar valueOrDefault = value.GetValueOrDefault(default(Scalar));
            NativeMethods.imgproc_copyMakeBorder(src.CvPtr, dst.CvPtr, top, bottom, left, right, (int)borderType, valueOrDefault);
            dst.Fix();
        }

        public static void MedianBlur(InputArray src, OutputArray dst, int ksize)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_medianBlur(src.CvPtr, dst.CvPtr, ksize);
            dst.Fix();
        }

        public static void GaussianBlur(InputArray src, OutputArray dst, Size ksize, double sigmaX, double sigmaY = 0.0, BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_GaussianBlur(src.CvPtr, dst.CvPtr, ksize, sigmaX, sigmaY, (int)borderType);
            dst.Fix();
        }

        public static void BilateralFilter(InputArray src, OutputArray dst, int d, double sigmaColor, double sigmaSpace, BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_bilateralFilter(src.CvPtr, dst.CvPtr, d, sigmaColor, sigmaSpace, (int)borderType);
            dst.Fix();
        }

        public static void AdaptiveBilateralFilter(InputArray src, OutputArray dst, Size ksize, double sigmaSpace, double maxSigmaColor = 20.0, Point? anchor = default(Point?), BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.imgproc_adaptiveBilateralFilter(src.CvPtr, dst.CvPtr, ksize, sigmaSpace, maxSigmaColor, valueOrDefault, (int)borderType);
            dst.Fix();
        }

        public static void BoxFilter(InputArray src, OutputArray dst, MatType ddepth, Size ksize, Point? anchor = default(Point?), bool normalize = true, BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.imgproc_boxFilter(src.CvPtr, dst.CvPtr, ddepth, ksize, valueOrDefault, normalize ? 1 : 0, (int)borderType);
            dst.Fix();
        }

        public static void Blur(InputArray src, OutputArray dst, Size ksize, Point? anchor = default(Point?), BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.imgproc_blur(src.CvPtr, dst.CvPtr, ksize, valueOrDefault, (int)borderType);
            dst.Fix();
        }

        public static void Filter2D(InputArray src, OutputArray dst, MatType ddepth, InputArray kernel, Point? anchor = default(Point?), double delta = 0.0, BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            kernel.ThrowIfDisposed();
            Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.imgproc_filter2D(src.CvPtr, dst.CvPtr, ddepth, kernel.CvPtr, valueOrDefault, delta, (int)borderType);
            dst.Fix();
        }

        public static void SepFilter2D(InputArray src, OutputArray dst, MatType ddepth, InputArray kernelX, InputArray kernelY, Point? anchor = default(Point?), double delta = 0.0, BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (kernelX == null)
            {
                throw new ArgumentNullException("kernelX");
            }
            if (kernelY == null)
            {
                throw new ArgumentNullException("kernelY");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            kernelX.ThrowIfDisposed();
            kernelY.ThrowIfDisposed();
            Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
            NativeMethods.imgproc_sepFilter2D(src.CvPtr, dst.CvPtr, ddepth, kernelX.CvPtr, kernelY.CvPtr, valueOrDefault, delta, (int)borderType);
            dst.Fix();
        }

        public static void Sobel(InputArray src, OutputArray dst, MatType ddepth, int xorder, int yorder, int ksize = 3, double scale = 1.0, double delta = 0.0, BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_Sobel(src.CvPtr, dst.CvPtr, ddepth, xorder, yorder, ksize, scale, delta, (int)borderType);
            dst.Fix();
        }

        public static void Scharr(InputArray src, OutputArray dst, MatType ddepth, int xorder, int yorder, double scale = 1.0, double delta = 0.0, BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_Scharr(src.CvPtr, dst.CvPtr, ddepth, xorder, yorder, scale, delta, (int)borderType);
            dst.Fix();
        }

        public static void Laplacian(InputArray src, OutputArray dst, MatType ddepth, int ksize = 1, double scale = 1.0, double delta = 0.0, BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_Laplacian(src.CvPtr, dst.CvPtr, ddepth, ksize, scale, delta, (int)borderType);
            dst.Fix();
        }

        public static void Canny(InputArray src, OutputArray edges, double threshold1, double threshold2, int apertureSize = 3, bool L2gradient = false)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (edges == null)
            {
                throw new ArgumentNullException("edges");
            }
            src.ThrowIfDisposed();
            edges.ThrowIfNotReady();
            NativeMethods.imgproc_Canny(src.CvPtr, edges.CvPtr, threshold1, threshold2, apertureSize, L2gradient ? 1 : 0);
            edges.Fix();
        }

        public static float[,] Eigen2x2(float[,] a, int n)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            if (a.GetLength(0) != 2 || a.GetLength(1) != 2)
            {
                throw new ArgumentException("Dimension of 'a' != 2");
            }
            float[,] array = new float[2, 2];
            NativeMethods.imgproc_eigen2x2(a, array, n);
            return array;
        }

        public static void CornerEigenValsAndVecs(InputArray src, OutputArray dst, int blockSize, int ksize, BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_cornerEigenValsAndVecs(src.CvPtr, dst.CvPtr, blockSize, ksize, (int)borderType);
            dst.Fix();
        }

        public static void PreCornerDetect(InputArray src, OutputArray dst, int ksize, BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_preCornerDetect(src.CvPtr, dst.CvPtr, ksize, (int)borderType);
            dst.Fix();
        }

        public static Point2f[] CornerSubPix(InputArray image, IEnumerable<Point2f> inputCorners, Size winSize, Size zeroZone, CvTermCriteria criteria)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (inputCorners == null)
            {
                throw new ArgumentNullException("inputCorners");
            }
            image.ThrowIfDisposed();
            Point2f[] array = Util.ToArray(inputCorners);
            Point2f[] array2 = new Point2f[array.Length];
            Array.Copy(array, array2, array.Length);
            using (VectorOfPoint2f vectorOfPoint2f = new VectorOfPoint2f(array2))
            {
                NativeMethods.imgproc_cornerSubPix(image.CvPtr, vectorOfPoint2f.CvPtr, winSize, zeroZone, criteria);
                return vectorOfPoint2f.ToArray();
            }
        }

        public static Point2f[] GoodFeaturesToTrack(InputArray src, int maxCorners, double qualityLevel, double minDistance, InputArray mask, int blockSize, bool useHarrisDetector, double k)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            src.ThrowIfDisposed();
            using (VectorOfPoint2f vectorOfPoint2f = new VectorOfPoint2f())
            {
                IntPtr mask2 = ToPtr(mask);
                NativeMethods.imgproc_goodFeaturesToTrack(src.CvPtr, vectorOfPoint2f.CvPtr, maxCorners, qualityLevel, minDistance, mask2, blockSize, (!useHarrisDetector) ? 1 : 0, k);
                return vectorOfPoint2f.ToArray();
            }
        }

        public static CvLineSegmentPolar[] HoughLines(InputArray image, double rho, double theta, int threshold, double srn = 0.0, double stn = 0.0)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            using (VectorOfVec2f vectorOfVec2f = new VectorOfVec2f())
            {
                NativeMethods.imgproc_HoughLines(image.CvPtr, vectorOfVec2f.CvPtr, rho, theta, threshold, srn, stn);
                return vectorOfVec2f.ToArray<CvLineSegmentPolar>();
            }
        }

        public static CvLineSegmentPoint[] HoughLinesP(InputArray image, double rho, double theta, int threshold, double minLineLength = 0.0, double maxLineGap = 0.0)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            image.ThrowIfDisposed();
            using (VectorOfVec4i vectorOfVec4i = new VectorOfVec4i())
            {
                NativeMethods.imgproc_HoughLinesP(image.CvPtr, vectorOfVec4i.CvPtr, rho, theta, threshold, minLineLength, maxLineGap);
                return vectorOfVec4i.ToArray<CvLineSegmentPoint>();
            }
        }

        public static CvCircleSegment[] HoughCircles(InputArray image, HoughCirclesMethod method, double dp, double minDist, double param1 = 100.0, double param2 = 100.0, int minRadius = 0, int maxRadius = 0)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            image.ThrowIfDisposed();
            using (VectorOfVec3f vectorOfVec3f = new VectorOfVec3f())
            {
                NativeMethods.imgproc_HoughCircles(image.CvPtr, vectorOfVec3f.CvPtr, (int)method, dp, minDist, param1, param2, minRadius, maxRadius);
                return vectorOfVec3f.ToArray<CvCircleSegment>();
            }
        }

        public static Scalar MorphologyDefaultBorderValue()
        {
            return Scalar.All(double.MaxValue);
        }

        public static void Dilate(InputArray src, OutputArray dst, InputArray element, Point? anchor = default(Point?), int iterations = 1, BorderType borderType = BorderType.Constant, Scalar? borderValue = default(Scalar?))
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            Point valueOrDefault = anchor.GetValueOrDefault(new Point(-1, -1));
            Scalar valueOrDefault2 = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());
            IntPtr kernel = ToPtr(element);
            NativeMethods.imgproc_dilate(src.CvPtr, dst.CvPtr, kernel, valueOrDefault, iterations, (int)borderType, valueOrDefault2);
            dst.Fix();
        }

        public static void Erode(InputArray src, OutputArray dst, InputArray element, CvPoint? anchor = default(CvPoint?), int iterations = 1, BorderType borderType = BorderType.Constant, CvScalar? borderValue = default(CvScalar?))
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            Point anchor2 = anchor.GetValueOrDefault(new Point(-1, -1));
            Scalar self = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());
            IntPtr kernel = ToPtr(element);
            NativeMethods.imgproc_erode(src.CvPtr, dst.CvPtr, kernel, anchor2, iterations, (int)borderType, self);
            dst.Fix();
        }

        public static void MorphologyEx(InputArray src, OutputArray dst, MorphologyOperation op, InputArray element, CvPoint? anchor = default(CvPoint?), int iterations = 1, BorderType borderType = BorderType.Constant, CvScalar? borderValue = default(CvScalar?))
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CvPoint valueOrDefault = anchor.GetValueOrDefault(new CvPoint(-1, -1));
            CvScalar valueOrDefault2 = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());
            IntPtr kernel = ToPtr(element);
            NativeMethods.imgproc_morphologyEx(src.CvPtr, dst.CvPtr, (int)op, kernel, valueOrDefault, iterations, (int)borderType, valueOrDefault2);
            dst.Fix();
        }

        public static void Resize(InputArray src, OutputArray dst, Size dsize, double fx = 0.0, double fy = 0.0, Interpolation interpolation = Interpolation.Linear)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_resize(src.CvPtr, dst.CvPtr, dsize, fx, fy, (int)interpolation);
            dst.Fix();
        }

        public static void WarpAffine(InputArray src, OutputArray dst, InputArray m, Size dsize, Interpolation flags = Interpolation.Linear, BorderType borderMode = BorderType.Constant, Scalar? borderValue = default(Scalar?))
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            m.ThrowIfDisposed();
            CvScalar borderValue2 = borderValue.GetValueOrDefault(CvScalar.ScalarAll(0.0));
            NativeMethods.imgproc_warpAffine(src.CvPtr, dst.CvPtr, m.CvPtr, dsize, (int)flags, (int)borderMode, borderValue2);
            dst.Fix();
        }

        public static void WarpPerspective(InputArray src, OutputArray dst, InputArray m, Size dsize, Interpolation flags = Interpolation.Linear, BorderType borderMode = BorderType.Constant, Scalar? borderValue = default(Scalar?))
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            m.ThrowIfDisposed();
            CvScalar borderValue2 = borderValue.GetValueOrDefault(CvScalar.ScalarAll(0.0));
            NativeMethods.imgproc_warpPerspective_MisInputArray(src.CvPtr, dst.CvPtr, m.CvPtr, dsize, (int)flags, (int)borderMode, borderValue2);
            dst.Fix();
        }

        public static void WarpPerspective(InputArray src, OutputArray dst, float[,] m, Size dsize, Interpolation flags = Interpolation.Linear, BorderType borderMode = BorderType.Constant, Scalar? borderValue = default(Scalar?))
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            CvScalar borderValue2 = borderValue.GetValueOrDefault(CvScalar.ScalarAll(0.0));
            int length = m.GetLength(0);
            int length2 = m.GetLength(1);
            NativeMethods.imgproc_warpPerspective_MisArray(src.CvPtr, dst.CvPtr, m, length, length2, dsize, (int)flags, (int)borderMode, borderValue2);
            dst.Fix();
        }

        public static void Remap(InputArray src, OutputArray dst, InputArray map1, InputArray map2, Interpolation interpolation = Interpolation.Linear, BorderType borderMode = BorderType.Constant, CvScalar? borderValue = default(CvScalar?))
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (map1 == null)
            {
                throw new ArgumentNullException("map1");
            }
            if (map2 == null)
            {
                throw new ArgumentNullException("map2");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            map1.ThrowIfDisposed();
            map2.ThrowIfDisposed();
            CvScalar valueOrDefault = borderValue.GetValueOrDefault(CvScalar.ScalarAll(0.0));
            NativeMethods.imgproc_remap(src.CvPtr, dst.CvPtr, map1.CvPtr, map2.CvPtr, (int)interpolation, (int)borderMode, valueOrDefault);
            dst.Fix();
        }

        public static void ConvertMaps(InputArray map1, InputArray map2, OutputArray dstmap1, OutputArray dstmap2, MatType dstmap1Type, bool nnInterpolation = false)
        {
            if (map1 == null)
            {
                throw new ArgumentNullException("map1");
            }
            if (map2 == null)
            {
                throw new ArgumentNullException("map2");
            }
            if (dstmap1 == null)
            {
                throw new ArgumentNullException("dstmap1");
            }
            if (dstmap2 == null)
            {
                throw new ArgumentNullException("dstmap2");
            }
            map1.ThrowIfDisposed();
            map2.ThrowIfDisposed();
            dstmap1.ThrowIfDisposed();
            dstmap2.ThrowIfDisposed();
            NativeMethods.imgproc_convertMaps(map1.CvPtr, map2.CvPtr, dstmap1.CvPtr, dstmap2.CvPtr, dstmap1Type, nnInterpolation ? 1 : 0);
            dstmap1.Fix();
            dstmap2.Fix();
        }

        public static Mat GetRotationMatrix2D(Point2f center, double angle, double scale)
        {
            return new Mat(NativeMethods.imgproc_getRotationMatrix2D(center, angle, scale));
        }

        public static void InvertAffineTransform(InputArray m, OutputArray im)
        {
            if (m == null)
            {
                throw new ArgumentNullException("m");
            }
            if (im == null)
            {
                throw new ArgumentNullException("im");
            }
            m.ThrowIfDisposed();
            im.ThrowIfNotReady();
            NativeMethods.imgproc_invertAffineTransform(m.CvPtr, im.CvPtr);
        }

        public static Mat GetPerspectiveTransform(IEnumerable<Point2f> src, IEnumerable<Point2f> dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            Point2f[] src2 = Util.ToArray(src);
            Point2f[] dst2 = Util.ToArray(dst);
            return new Mat(NativeMethods.imgproc_getPerspectiveTransform(src2, dst2));
        }

        public static Mat GetPerspectiveTransform(InputArray src, InputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            return new Mat(NativeMethods.imgproc_getPerspectiveTransform(src.CvPtr, dst.CvPtr));
        }

        public static Mat GetAffineTransform(IEnumerable<Point2f> src, IEnumerable<Point2f> dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            Point2f[] src2 = Util.ToArray(src);
            Point2f[] dst2 = Util.ToArray(dst);
            return new Mat(NativeMethods.imgproc_getAffineTransform(src2, dst2));
        }

        public static Mat GetAffineTransform(InputArray src, InputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            return new Mat(NativeMethods.imgproc_getAffineTransform(src.CvPtr, dst.CvPtr));
        }

        public static void GetRectSubPix(InputArray image, Size patchSize, Point2f center, OutputArray patch, int patchType = -1)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (patch == null)
            {
                throw new ArgumentNullException("patch");
            }
            image.ThrowIfDisposed();
            patch.ThrowIfNotReady();
            NativeMethods.imgproc_getRectSubPix(image.CvPtr, patchSize, center, patch.CvPtr, patchType);
            patch.Fix();
        }

        public static void Integral(InputArray src, OutputArray sum, int sdepth = -1)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (sum == null)
            {
                throw new ArgumentNullException("sum");
            }
            src.ThrowIfDisposed();
            sum.ThrowIfNotReady();
            NativeMethods.imgproc_integral(src.CvPtr, sum.CvPtr, sdepth);
            sum.Fix();
        }

        public static void Integral(InputArray src, OutputArray sum, OutputArray sqsum, int sdepth = -1)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (sum == null)
            {
                throw new ArgumentNullException("sum");
            }
            if (sqsum == null)
            {
                throw new ArgumentNullException("sqsum");
            }
            src.ThrowIfDisposed();
            sum.ThrowIfNotReady();
            sqsum.ThrowIfNotReady();
            NativeMethods.imgproc_integral(src.CvPtr, sum.CvPtr, sqsum.CvPtr, sdepth);
            sum.Fix();
            sqsum.Fix();
        }

        public static void Integral(InputArray src, OutputArray sum, OutputArray sqsum, OutputArray tilted, int sdepth = -1)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (sum == null)
            {
                throw new ArgumentNullException("sum");
            }
            if (sqsum == null)
            {
                throw new ArgumentNullException("sqsum");
            }
            if (tilted == null)
            {
                throw new ArgumentNullException("tilted");
            }
            src.ThrowIfDisposed();
            sum.ThrowIfNotReady();
            sqsum.ThrowIfNotReady();
            tilted.ThrowIfNotReady();
            NativeMethods.imgproc_integral(src.CvPtr, sum.CvPtr, sqsum.CvPtr, tilted.CvPtr, sdepth);
            sum.Fix();
            sqsum.Fix();
            tilted.Fix();
        }

        public static void Accumulate(InputArray src, InputOutputArray dst, InputArray mask)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_accumulate(src.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }

        public static void AccumulateSquare(InputArray src, InputOutputArray dst, InputArray mask)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_accumulateSquare(src.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }

        public static void AccumulateProduct(InputArray src1, InputArray src2, InputOutputArray dst, InputArray mask)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_accumulateProduct(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask));
            dst.Fix();
        }

        public static void AccumulateWeighted(InputArray src, InputOutputArray dst, double alpha, InputArray mask)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_accumulateWeighted(src.CvPtr, dst.CvPtr, alpha, ToPtr(mask));
            dst.Fix();
        }

        public static double PSNR(InputArray src1, InputArray src2)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            return NativeMethods.imgproc_PSNR(src1.CvPtr, src2.CvPtr);
        }

        public static Point2d PhaseCorrelate(InputArray src1, InputArray src2, InputArray window = null)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            return NativeMethods.imgproc_phaseCorrelate(src1.CvPtr, src2.CvPtr, ToPtr(window));
        }

        public static Point2d PhaseCorrelateRes(InputArray src1, InputArray src2, InputArray window)
        {
            double response;
            return PhaseCorrelateRes(src1, src2, window, out response);
        }

        public static Point2d PhaseCorrelateRes(InputArray src1, InputArray src2, InputArray window, out double response)
        {
            if (src1 == null)
            {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null)
            {
                throw new ArgumentNullException("src2");
            }
            if (window == null)
            {
                throw new ArgumentNullException("src2");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            window.ThrowIfDisposed();
            return NativeMethods.imgproc_phaseCorrelateRes(src1.CvPtr, src2.CvPtr, window.CvPtr, out response);
        }

        public static void CreateHanningWindow(InputOutputArray dst, Size winSize, MatType type)
        {
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_createHanningWindow(dst.CvPtr, winSize, type);
            dst.Fix();
        }

        public static double Threshold(InputArray src, OutputArray dst, double thresh, double maxval, ThresholdType type)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            double result = NativeMethods.imgproc_threshold(src.CvPtr, dst.CvPtr, thresh, maxval, (int)type);
            dst.Fix();
            return result;
        }

        public static void AdaptiveThreshold(InputArray src, OutputArray dst, double maxValue, AdaptiveThresholdType adaptiveMethod, ThresholdType thresholdType, int blockSize, double c)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_adaptiveThreshold(src.CvPtr, dst.CvPtr, maxValue, (int)adaptiveMethod, (int)thresholdType, blockSize, c);
            dst.Fix();
        }

        public static void PyrDown(InputArray src, OutputArray dst, Size? dstSize = default(Size?), BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            Size valueOrDefault = dstSize.GetValueOrDefault(default(Size));
            NativeMethods.imgproc_pyrDown(src.CvPtr, dst.CvPtr, valueOrDefault, (int)borderType);
            dst.Fix();
        }

        public static void PyrUp(InputArray src, OutputArray dst, Size? dstSize = default(Size?), BorderType borderType = BorderType.Reflect101)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            Size valueOrDefault = dstSize.GetValueOrDefault(default(Size));
            NativeMethods.imgproc_pyrUp(src.CvPtr, dst.CvPtr, valueOrDefault, (int)borderType);
            dst.Fix();
        }

        public static void Undistort(InputArray src, OutputArray dst, InputArray cameraMatrix, InputArray distCoeffs, InputArray newCameraMatrix = null)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            cameraMatrix.ThrowIfDisposed();
            NativeMethods.imgproc_undistort(src.CvPtr, dst.CvPtr, cameraMatrix.CvPtr, ToPtr(distCoeffs), ToPtr(newCameraMatrix));
            dst.Fix();
        }

        public static void InitUndistortRectifyMap(InputArray cameraMatrix, InputArray distCoeffs, InputArray r, InputArray newCameraMatrix, Size size, MatType m1Type, OutputArray map1, OutputArray map2)
        {
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            if (distCoeffs == null)
            {
                throw new ArgumentNullException("distCoeffs");
            }
            if (r == null)
            {
                throw new ArgumentNullException("r");
            }
            if (newCameraMatrix == null)
            {
                throw new ArgumentNullException("newCameraMatrix");
            }
            if (map1 == null)
            {
                throw new ArgumentNullException("map1");
            }
            if (map2 == null)
            {
                throw new ArgumentNullException("map2");
            }
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            r.ThrowIfDisposed();
            newCameraMatrix.ThrowIfDisposed();
            map1.ThrowIfNotReady();
            map2.ThrowIfNotReady();
            NativeMethods.imgproc_initUndistortRectifyMap(cameraMatrix.CvPtr, distCoeffs.CvPtr, r.CvPtr, newCameraMatrix.CvPtr, size, m1Type, map1.CvPtr, map2.CvPtr);
            map1.Fix();
            map2.Fix();
        }

        public static float InitWideAngleProjMap(InputArray cameraMatrix, InputArray distCoeffs, Size imageSize, int destImageWidth, MatType m1Type, OutputArray map1, OutputArray map2, ProjectionType projType, double alpha = 0.0)
        {
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            if (distCoeffs == null)
            {
                throw new ArgumentNullException("distCoeffs");
            }
            if (map1 == null)
            {
                throw new ArgumentNullException("map1");
            }
            if (map2 == null)
            {
                throw new ArgumentNullException("map2");
            }
            cameraMatrix.ThrowIfDisposed();
            distCoeffs.ThrowIfDisposed();
            map1.ThrowIfNotReady();
            map2.ThrowIfNotReady();
            float result = NativeMethods.imgproc_initWideAngleProjMap(cameraMatrix.CvPtr, distCoeffs.CvPtr, imageSize, destImageWidth, m1Type, map1.CvPtr, map2.CvPtr, (int)projType, alpha);
            map1.Fix();
            map2.Fix();
            return result;
        }

        public static Mat GetDefaultNewCameraMatrix(InputArray cameraMatrix, Size? imgSize = default(Size?), bool centerPrincipalPoint = false)
        {
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            cameraMatrix.ThrowIfDisposed();
            Size valueOrDefault = imgSize.GetValueOrDefault(default(Size));
            return new Mat(NativeMethods.imgproc_getDefaultNewCameraMatrix(cameraMatrix.CvPtr, valueOrDefault, centerPrincipalPoint ? 1 : 0));
        }

        public static void UndistortPoints(InputArray src, OutputArray dst, InputArray cameraMatrix, InputArray distCoeffs, InputArray r = null, InputArray p = null)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (cameraMatrix == null)
            {
                throw new ArgumentNullException("cameraMatrix");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            cameraMatrix.ThrowIfDisposed();
            NativeMethods.imgproc_undistortPoints(src.CvPtr, dst.CvPtr, cameraMatrix.CvPtr, ToPtr(distCoeffs), ToPtr(r), ToPtr(p));
            dst.Fix();
        }

        public static void CalcHist(Mat[] images, int[] channels, InputArray mask, OutputArray hist, int dims, int[] histSize, Rangef[] ranges, bool uniform = true, bool accumulate = false)
        {
            if (ranges == null)
            {
                throw new ArgumentNullException("ranges");
            }
            float[][] ranges2 = EnumerableEx.SelectToArray(ranges, (Rangef r) => new float[2]
			{
				r.Start,
				r.End
			});
            CalcHist(images, channels, mask, hist, dims, histSize, ranges2, uniform, accumulate);
        }

        public static void CalcHist(Mat[] images, int[] channels, InputArray mask, OutputArray hist, int dims, int[] histSize, float[][] ranges, bool uniform = true, bool accumulate = false)
        {
            if (images == null)
            {
                throw new ArgumentNullException("images");
            }
            if (channels == null)
            {
                throw new ArgumentNullException("channels");
            }
            if (hist == null)
            {
                throw new ArgumentNullException("hist");
            }
            if (histSize == null)
            {
                throw new ArgumentNullException("histSize");
            }
            if (ranges == null)
            {
                throw new ArgumentNullException("ranges");
            }
            hist.ThrowIfNotReady();
            IntPtr[] images2 = EnumerableEx.SelectPtrs(images);
            using (ArrayAddress2<float> self = new ArrayAddress2<float>(ranges))
            {
                NativeMethods.imgproc_calcHist1(images2, images.Length, channels, ToPtr(mask), hist.CvPtr, dims, histSize, self, uniform ? 1 : 0, accumulate ? 1 : 0);
            }
            hist.Fix();
        }

        public static void CalcBackProject(Mat[] images, int[] channels, InputArray hist, OutputArray backProject, Rangef[] ranges, bool uniform = true)
        {
            if (images == null)
            {
                throw new ArgumentNullException("images");
            }
            if (channels == null)
            {
                throw new ArgumentNullException("channels");
            }
            if (hist == null)
            {
                throw new ArgumentNullException("hist");
            }
            if (backProject == null)
            {
                throw new ArgumentNullException("backProject");
            }
            if (ranges == null)
            {
                throw new ArgumentNullException("ranges");
            }
            hist.ThrowIfDisposed();
            backProject.ThrowIfNotReady();
            IntPtr[] images2 = EnumerableEx.SelectPtrs(images);
            using (ArrayAddress2<float> self = new ArrayAddress2<float>(EnumerableEx.SelectToArray(ranges, (Rangef r) => new float[2]
			{
				r.Start,
				r.End
			})))
            {
                NativeMethods.imgproc_calcBackProject(images2, images.Length, channels, hist.CvPtr, backProject.CvPtr, self, uniform ? 1 : 0);
            }
            backProject.Fix();
        }

        public static double CompareHist(InputArray h1, InputArray h2, HistogramComparison method)
        {
            if (h1 == null)
            {
                throw new ArgumentNullException("h1");
            }
            if (h2 == null)
            {
                throw new ArgumentNullException("h2");
            }
            h1.ThrowIfDisposed();
            h2.ThrowIfDisposed();
            return NativeMethods.imgproc_compareHist1(h1.CvPtr, h2.CvPtr, (int)method);
        }

        public static void EqualizeHist(InputArray src, OutputArray dst)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_equalizeHist(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        public static CLAHE CreateCLAHE(double clipLimit = 40.0, Size? tileGridSize = default(Size?))
        {
            return CLAHE.Create(clipLimit, tileGridSize);
        }

        public static float EMD(InputArray signature1, InputArray signature2, DistanceType distType)
        {
            float lowerBound;
            return EMD(signature1, signature1, distType, null, out lowerBound, null);
        }

        public static float EMD(InputArray signature1, InputArray signature2, DistanceType distType, InputArray cost)
        {
            float lowerBound;
            return EMD(signature1, signature1, distType, cost, out lowerBound, null);
        }

        public static float EMD(InputArray signature1, InputArray signature2, DistanceType distType, InputArray cost, out float lowerBound)
        {
            return EMD(signature1, signature1, distType, cost, out lowerBound, null);
        }

        public static float EMD(InputArray signature1, InputArray signature2, DistanceType distType, InputArray cost, out float lowerBound, OutputArray flow)
		{
			if (signature1 == null)
			{
				throw new ArgumentNullException("signature1");
			}
			if (signature2 == null)
			{
				throw new ArgumentNullException("signature2");
			}
			signature1.ThrowIfDisposed();
			signature2.ThrowIfDisposed();
			float result = NativeMethods.imgproc_EMD(signature1.CvPtr, signature2.CvPtr, (int)distType, ToPtr(cost), out lowerBound, ToPtr(flow));
			if(flow!=null) flow.Fix();
			return result;
		}

        public static void Watershed(InputArray image, InputOutputArray markers)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (markers == null)
            {
                throw new ArgumentNullException("markers");
            }
            image.ThrowIfDisposed();
            markers.ThrowIfNotReady();
            NativeMethods.imgproc_watershed(image.CvPtr, markers.CvPtr);
            markers.Fix();
        }

        public static void PyrMeanShiftFiltering(InputArray src, OutputArray dst, double sp, double sr, int maxLevel = 1, TermCriteria? termcrit = default(TermCriteria?))
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            TermCriteria valueOrDefault = termcrit.GetValueOrDefault(new TermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 5, 1.0));
            NativeMethods.imgproc_pyrMeanShiftFiltering(src.CvPtr, dst.CvPtr, sp, sr, maxLevel, valueOrDefault);
            dst.Fix();
        }

        public static void GrabCut(InputArray img, InputOutputArray mask, Rect rect, InputOutputArray bgdModel, InputOutputArray fgdModel, int iterCount, GrabCutFlag mode)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            if (mask == null)
            {
                throw new ArgumentNullException("mask");
            }
            if (bgdModel == null)
            {
                throw new ArgumentNullException("bgdModel");
            }
            if (fgdModel == null)
            {
                throw new ArgumentNullException("fgdModel");
            }
            img.ThrowIfDisposed();
            mask.ThrowIfNotReady();
            bgdModel.ThrowIfNotReady();
            fgdModel.ThrowIfNotReady();
            NativeMethods.imgproc_grabCut(img.CvPtr, mask.CvPtr, rect, bgdModel.CvPtr, fgdModel.CvPtr, iterCount, (int)mode);
            mask.Fix();
            bgdModel.Fix();
            fgdModel.Fix();
        }

        public static void DistanceTransformWithLabels(InputArray src, OutputArray dst, OutputArray labels, DistanceType distanceType, DistanceMaskSize maskSize, DistTransformLabelType labelType = DistTransformLabelType.CComp)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            if (labels == null)
            {
                throw new ArgumentNullException("labels");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            labels.ThrowIfNotReady();
            NativeMethods.imgproc_distanceTransformWithLabels(src.CvPtr, dst.CvPtr, labels.CvPtr, (int)distanceType, (int)maskSize, (int)labelType);
            dst.Fix();
            labels.Fix();
        }

        public static void DistanceTransform(InputArray src, OutputArray dst, DistanceType distanceType, DistanceMaskSize maskSize)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_distanceTransform(src.CvPtr, dst.CvPtr, (int)distanceType, (int)maskSize);
            dst.Fix();
        }

        public static int FloodFill(InputOutputArray image, Point seedPoint, Scalar newVal)
        {
            Rect rect = default(Rect);
            return FloodFill(image, seedPoint, newVal, out rect);
        }

        public static int FloodFill(InputOutputArray image, Point seedPoint, Scalar newVal, out Rect rect, Scalar? loDiff = default(Scalar?), Scalar? upDiff = default(Scalar?), FloodFillFlag flags = FloodFillFlag.Link4)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            image.ThrowIfNotReady();
            Scalar valueOrDefault = loDiff.GetValueOrDefault(default(Scalar));
            Scalar valueOrDefault2 = upDiff.GetValueOrDefault(default(Scalar));
            CvRect rect2;
            int result = NativeMethods.imgproc_floodFill(image.CvPtr, seedPoint, newVal, out rect2, valueOrDefault, valueOrDefault2, (int)flags);
            rect = rect2;
            image.Fix();
            return result;
        }

        public static int FloodFill(InputOutputArray image, InputOutputArray mask, Point seedPoint, Scalar newVal)
        {
            Rect rect = default(Rect);
            return FloodFill(image, mask, seedPoint, newVal, out rect);
        }

        public static int FloodFill(InputOutputArray image, InputOutputArray mask, Point seedPoint, Scalar newVal, out Rect rect, Scalar? loDiff = default(Scalar?), Scalar? upDiff = default(Scalar?), FloodFillFlag flags = FloodFillFlag.Link4)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (mask == null)
            {
                throw new ArgumentNullException("mask");
            }
            image.ThrowIfNotReady();
            mask.ThrowIfNotReady();
            Scalar valueOrDefault = loDiff.GetValueOrDefault(default(Scalar));
            Scalar valueOrDefault2 = upDiff.GetValueOrDefault(default(Scalar));
            CvRect rect2;
            int result = NativeMethods.imgproc_floodFill(image.CvPtr, mask.CvPtr, seedPoint, newVal, out rect2, valueOrDefault, valueOrDefault2, (int)flags);
            rect = rect2;
            image.Fix();
            mask.Fix();
            return result;
        }

        public static void CvtColor(InputArray src, OutputArray dst, ColorConversion code, int dstCn = 0)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_cvtColor(src.CvPtr, dst.CvPtr, (int)code, dstCn);
            dst.Fix();
        }

        public static Moments Moments(InputArray array, bool binaryImage = false)
        {
            return new Moments(array, binaryImage);
        }

        public static Moments Moments(byte[,] array, bool binaryImage = false)
        {
            return new Moments(array, binaryImage);
        }

        public static Moments Moments(float[,] array, bool binaryImage = false)
        {
            return new Moments(array, binaryImage);
        }

        public static Moments Moments(IEnumerable<Point> array, bool binaryImage = false)
        {
            return new Moments(array, binaryImage);
        }

        public static Moments Moments(IEnumerable<Point2f> array, bool binaryImage = false)
        {
            return new Moments(array, binaryImage);
        }

        public static void MatchTemplate(InputArray image, InputArray templ, OutputArray result, MatchTemplateMethod method)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (templ == null)
            {
                throw new ArgumentNullException("templ");
            }
            if (result == null)
            {
                throw new ArgumentNullException("result");
            }
            image.ThrowIfDisposed();
            templ.ThrowIfDisposed();
            result.ThrowIfNotReady();
            NativeMethods.imgproc_matchTemplate(image.CvPtr, templ.CvPtr, result.CvPtr, (int)method);
            result.Fix();
        }

        public static void FindContours(InputOutputArray image, out Point[][] contours, out HierarchyIndex[] hierarchy, ContourRetrieval mode, ContourChain method, Point? offset = default(Point?))
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfNotReady();
			CvPoint offset2 = offset.GetValueOrDefault(default(Point));
            IntPtr contours2, hierarchy2;
			NativeMethods.imgproc_findContours1_vector(image.CvPtr, out contours2, out  hierarchy2, (int)mode, (int)method, offset2);
			using (VectorOfVectorPoint vectorOfVectorPoint = new VectorOfVectorPoint(contours2))
			{
				using (VectorOfVec4i vectorOfVec4i = new VectorOfVec4i(hierarchy2))
				{
					contours = vectorOfVectorPoint.ToArray();
					Vec4i[] enumerable = vectorOfVec4i.ToArray();
					hierarchy = EnumerableEx.SelectToArray(enumerable, HierarchyIndex.FromVec4i);
				}
			}
			image.Fix();
		}

        public static void FindContours(InputOutputArray image, out Mat[] contours, OutputArray hierarchy, ContourRetrieval mode, ContourChain method, Point? offset = default(Point?))
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			if (hierarchy == null)
			{
				throw new ArgumentNullException("hierarchy");
			}
			image.ThrowIfNotReady();
			hierarchy.ThrowIfNotReady();
			CvPoint offset2 = offset.GetValueOrDefault(default(Point));
            IntPtr contours2;
			NativeMethods.imgproc_findContours1_OutputArray(image.CvPtr, out  contours2, hierarchy.CvPtr, (int)mode, (int)method, offset2);
			using (VectorOfMat vectorOfMat = new VectorOfMat(contours2))
			{
				contours = vectorOfMat.ToArray();
			}
			image.Fix();
			hierarchy.Fix();
		}

        public static Point[][] FindContoursAsArray(InputOutputArray image, ContourRetrieval mode, ContourChain method, Point? offset = default(Point?))
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfNotReady();
			CvPoint offset2 = offset.GetValueOrDefault(default(Point));
            IntPtr contours;
			NativeMethods.imgproc_findContours2_vector(image.CvPtr, out contours, (int)mode, (int)method, offset2);
			image.Fix();
			using (VectorOfVectorPoint vectorOfVectorPoint = new VectorOfVectorPoint(contours))
			{
				return vectorOfVectorPoint.ToArray();
			}
		}

        public static MatOfPoint[] FindContoursAsMat(InputOutputArray image, ContourRetrieval mode, ContourChain method, Point? offset = default(Point?))
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			image.ThrowIfNotReady();
			CvPoint offset2 = offset.GetValueOrDefault(default(Point));
            IntPtr contours;
			NativeMethods.imgproc_findContours2_OutputArray(image.CvPtr, out  contours, (int)mode, (int)method, offset2);
			image.Fix();
			using (VectorOfMat vectorOfMat = new VectorOfMat(contours))
			{
				return vectorOfMat.ToArray<MatOfPoint>();
			}
		}

        public static void DrawContours(InputOutputArray image, IEnumerable<IEnumerable<Point>> contours, int contourIdx, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, IEnumerable<HierarchyIndex> hierarchy = null, int maxLevel = int.MaxValue, Point? offset = default(Point?))
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (contours == null)
            {
                throw new ArgumentNullException("contours");
            }
            image.ThrowIfNotReady();
            CvPoint offset2 = offset.GetValueOrDefault(default(Point));
            Point[][] array = EnumerableEx.SelectToArray(contours, EnumerableEx.ToArray<Point>);
            int[] contoursSize = EnumerableEx.SelectToArray(array, (Point[] pts) => pts.Length);
            using (ArrayAddress2<Point> arrayAddress = new ArrayAddress2<Point>(array))
            {
                if (hierarchy == null)
                {
                    NativeMethods.imgproc_drawContours_vector(image.CvPtr, arrayAddress.Pointer, array.Length, contoursSize, contourIdx, color, thickness, (int)lineType, IntPtr.Zero, 0, maxLevel, offset2);
                }
                else
                {
                    Vec4i[] array2 = EnumerableEx.SelectToArray(hierarchy, (HierarchyIndex hi) => hi.ToVec4i());
                    NativeMethods.imgproc_drawContours_vector(image.CvPtr, arrayAddress.Pointer, array.Length, contoursSize, contourIdx, color, thickness, (int)lineType, array2, array2.Length, maxLevel, offset2);
                }
            }
            image.Fix();
        }

        public static void DrawContours(InputOutputArray image, IEnumerable<Mat> contours, int contourIdx, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, Mat hierarchy = null, int maxLevel = int.MaxValue, Point? offset = default(Point?))
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (contours == null)
            {
                throw new ArgumentNullException("contours");
            }
            image.ThrowIfNotReady();
            CvPoint offset2 = offset.GetValueOrDefault(default(Point));
            IntPtr[] array = EnumerableEx.SelectPtrs(contours);
            NativeMethods.imgproc_drawContours_InputArray(image.CvPtr, array, array.Length, contourIdx, color, thickness, (int)lineType, ToPtr(hierarchy), maxLevel, offset2);
            image.Fix();
        }

        public static void ApproxPolyDP(InputArray curve, OutputArray approxCurve, double epsilon, bool closed)
        {
            if (curve == null)
            {
                throw new ArgumentNullException("curve");
            }
            if (approxCurve == null)
            {
                throw new ArgumentNullException("approxCurve");
            }
            curve.ThrowIfDisposed();
            approxCurve.ThrowIfNotReady();
            NativeMethods.imgproc_approxPolyDP_InputArray(curve.CvPtr, approxCurve.CvPtr, epsilon, closed ? 1 : 0);
            approxCurve.Fix();
        }

        public static Point[] ApproxPolyDP(IEnumerable<Point> curve, double epsilon, bool closed)
        {
            if (curve == null)
            {
                throw new ArgumentNullException("curve");
            }
            Point[] array = EnumerableEx.ToArray(curve);
            IntPtr approxCurve = default(IntPtr);
            NativeMethods.imgproc_approxPolyDP_Point(array, array.Length, out approxCurve, epsilon, closed ? 1 : 0);
            using (VectorOfPoint vectorOfPoint = new VectorOfPoint(approxCurve))
            {
                return vectorOfPoint.ToArray();
            }
        }

        public static Point2f[] ApproxPolyDP(IEnumerable<Point2f> curve, double epsilon, bool closed)
        {
            if (curve == null)
            {
                throw new ArgumentNullException("curve");
            }
            Point2f[] array = EnumerableEx.ToArray(curve);
            IntPtr approxCurve = default(IntPtr);
            NativeMethods.imgproc_approxPolyDP_Point2f(array, array.Length, out approxCurve, epsilon, closed ? 1 : 0);
            using (VectorOfPoint2f vectorOfPoint2f = new VectorOfPoint2f(approxCurve))
            {
                return vectorOfPoint2f.ToArray();
            }
        }

        public static double ArcLength(InputArray curve, bool closed)
        {
            if (curve == null)
            {
                throw new ArgumentNullException("curve");
            }
            curve.ThrowIfDisposed();
            return NativeMethods.imgproc_arcLength_InputArray(curve.CvPtr, closed ? 1 : 0);
        }

        public static double ArcLength(IEnumerable<Point> curve, bool closed)
        {
            if (curve == null)
            {
                throw new ArgumentNullException("curve");
            }
            Point[] array = EnumerableEx.ToArray(curve);
            return NativeMethods.imgproc_arcLength_Point(array, array.Length, closed ? 1 : 0);
        }

        public static double ArcLength(IEnumerable<Point2f> curve, bool closed)
        {
            if (curve == null)
            {
                throw new ArgumentNullException("curve");
            }
            Point2f[] array = EnumerableEx.ToArray(curve);
            return NativeMethods.imgproc_arcLength_Point2f(array, array.Length, closed ? 1 : 0);
        }

        public static Rect BoundingRect(InputArray curve)
        {
            if (curve == null)
            {
                throw new ArgumentNullException("curve");
            }
            curve.ThrowIfDisposed();
            return NativeMethods.imgproc_boundingRect_InputArray(curve.CvPtr);
        }

        public static Rect BoundingRect(IEnumerable<Point> curve)
        {
            if (curve == null)
            {
                throw new ArgumentNullException("curve");
            }
            Point[] array = EnumerableEx.ToArray(curve);
            return NativeMethods.imgproc_boundingRect_Point(array, array.Length);
        }

        public static Rect BoundingRect(IEnumerable<Point2f> curve)
        {
            if (curve == null)
            {
                throw new ArgumentNullException("curve");
            }
            Point2f[] array = EnumerableEx.ToArray(curve);
            return NativeMethods.imgproc_boundingRect_Point2f(array, array.Length);
        }

        public static double ContourArea(InputArray contour, bool oriented = false)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            contour.ThrowIfDisposed();
            return NativeMethods.imgproc_contourArea_InputArray(contour.CvPtr, oriented ? 1 : 0);
        }

        public static double ContourArea(IEnumerable<Point> contour, bool oriented = false)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            Point[] array = EnumerableEx.ToArray(contour);
            return NativeMethods.imgproc_contourArea_Point(array, array.Length, oriented ? 1 : 0);
        }

        public static double ContourArea(IEnumerable<Point2f> contour, bool oriented = false)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            Point2f[] array = EnumerableEx.ToArray(contour);
            return NativeMethods.imgproc_contourArea_Point2f(array, array.Length, oriented ? 1 : 0);
        }

        public static RotatedRect MinAreaRect(InputArray points)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            points.ThrowIfDisposed();
            return NativeMethods.imgproc_minAreaRect_InputArray(points.CvPtr);
        }

        public static RotatedRect MinAreaRect(IEnumerable<Point> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point[] array = EnumerableEx.ToArray(points);
            return NativeMethods.imgproc_minAreaRect_Point(array, array.Length);
        }

        public static RotatedRect MinAreaRect(IEnumerable<Point2f> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point2f[] array = EnumerableEx.ToArray(points);
            return NativeMethods.imgproc_minAreaRect_Point2f(array, array.Length);
        }

        public static void MinEnclosingCircle(InputArray points, out Point2f center, out float radius)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            points.ThrowIfDisposed();
            NativeMethods.imgproc_minEnclosingCircle_InputArray(points.CvPtr, out center, out radius);
        }

        public static void MinEnclosingCircle(IEnumerable<Point> points, out Point2f center, out float radius)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point[] array = EnumerableEx.ToArray(points);
            NativeMethods.imgproc_minEnclosingCircle_Point(array, array.Length, out center, out radius);
        }

        public static void MinEnclosingCircle(IEnumerable<Point2f> points, out Point2f center, out float radius)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point2f[] array = EnumerableEx.ToArray(points);
            NativeMethods.imgproc_minEnclosingCircle_Point2f(array, array.Length, out center, out radius);
        }

        public static double MatchShapes(InputArray contour1, InputArray contour2, MatchShapesMethod method, double parameter = 0.0)
        {
            if (contour1 == null)
            {
                throw new ArgumentNullException("contour1");
            }
            if (contour2 == null)
            {
                throw new ArgumentNullException("contour2");
            }
            return NativeMethods.imgproc_matchShapes_InputArray(contour1.CvPtr, contour2.CvPtr, (int)method, parameter);
        }

        public static double MatchShapes(IEnumerable<Point> contour1, IEnumerable<Point> contour2, MatchShapesMethod method, double parameter = 0.0)
        {
            if (contour1 == null)
            {
                throw new ArgumentNullException("contour1");
            }
            if (contour2 == null)
            {
                throw new ArgumentNullException("contour2");
            }
            Point[] array = EnumerableEx.ToArray(contour1);
            Point[] array2 = EnumerableEx.ToArray(contour2);
            return NativeMethods.imgproc_matchShapes_Point(array, array.Length, array2, array2.Length, (int)method, parameter);
        }

        public static void ConvexHull(InputArray points, OutputArray hull, bool clockwise = false, bool returnPoints = true)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            if (hull == null)
            {
                throw new ArgumentNullException("hull");
            }
            points.ThrowIfDisposed();
            hull.ThrowIfNotReady();
            NativeMethods.imgproc_convexHull_InputArray(points.CvPtr, hull.CvPtr, clockwise ? 1 : 0, returnPoints ? 1 : 0);
            hull.Fix();
        }

        public static Point[] ConvexHull(IEnumerable<Point> points, bool clockwise = false)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point[] array = EnumerableEx.ToArray(points);
            IntPtr hull = default(IntPtr);
            NativeMethods.imgproc_convexHull_Point_ReturnsPoints(array, array.Length, out hull, clockwise ? 1 : 0);
            using (VectorOfPoint vectorOfPoint = new VectorOfPoint(hull))
            {
                return vectorOfPoint.ToArray();
            }
        }

        public static Point2f[] ConvexHull(IEnumerable<Point2f> points, bool clockwise = false)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point2f[] array = EnumerableEx.ToArray(points);
            IntPtr hull = default(IntPtr);
            NativeMethods.imgproc_convexHull_Point2f_ReturnsPoints(array, array.Length, out hull, clockwise ? 1 : 0);
            using (VectorOfPoint2f vectorOfPoint2f = new VectorOfPoint2f(hull))
            {
                return vectorOfPoint2f.ToArray();
            }
        }

        public static int[] ConvexHullIndices(IEnumerable<Point> points, bool clockwise = false)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point[] array = EnumerableEx.ToArray(points);
            IntPtr hull = default(IntPtr);
            NativeMethods.imgproc_convexHull_Point_ReturnsIndices(array, array.Length, out hull, clockwise ? 1 : 0);
            using (VectorOfInt32 vectorOfInt = new VectorOfInt32(hull))
            {
                return vectorOfInt.ToArray();
            }
        }

        public static int[] ConvexHullIndices(IEnumerable<Point2f> points, bool clockwise = false)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point2f[] array = EnumerableEx.ToArray(points);
            IntPtr hull = default(IntPtr);
            NativeMethods.imgproc_convexHull_Point2f_ReturnsIndices(array, array.Length, out hull, clockwise ? 1 : 0);
            using (VectorOfInt32 vectorOfInt = new VectorOfInt32(hull))
            {
                return vectorOfInt.ToArray();
            }
        }

        public static void ConvexityDefects(InputArray contour, InputArray convexHull, OutputArray convexityDefects)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            if (convexHull == null)
            {
                throw new ArgumentNullException("convexHull");
            }
            if (convexityDefects == null)
            {
                throw new ArgumentNullException("convexityDefects");
            }
            contour.ThrowIfDisposed();
            convexHull.ThrowIfDisposed();
            convexityDefects.ThrowIfNotReady();
            NativeMethods.imgproc_convexityDefects_InputArray(contour.CvPtr, convexHull.CvPtr, convexityDefects.CvPtr);
            convexityDefects.Fix();
        }

        public static Vec4i[] ConvexityDefects(IEnumerable<Point> contour, IEnumerable<int> convexHull)
		{
			if (contour == null)
			{
				throw new ArgumentNullException("contour");
			}
			if (convexHull == null)
			{
				throw new ArgumentNullException("convexHull");
			}
			Point[] array = EnumerableEx.ToArray(contour);
			int[] array2 = EnumerableEx.ToArray(convexHull);
            IntPtr convexityDefects;
			NativeMethods.imgproc_convexityDefects_Point(array, array.Length, array2, array2.Length, out convexityDefects);
			using (VectorOfVec4i vectorOfVec4i = new VectorOfVec4i(convexityDefects))
			{
				return vectorOfVec4i.ToArray();
			}
		}

        public static Vec4i[] ConvexityDefects(IEnumerable<Point2f> contour, IEnumerable<int> convexHull)
		{
			if (contour == null)
			{
				throw new ArgumentNullException("contour");
			}
			if (convexHull == null)
			{
				throw new ArgumentNullException("convexHull");
			}
			Point2f[] array = EnumerableEx.ToArray(contour);
			int[] array2 = EnumerableEx.ToArray(convexHull);
            IntPtr convexityDefects;
			NativeMethods.imgproc_convexityDefects_Point2f(array, array.Length, array2, array2.Length, out convexityDefects);
			using (VectorOfVec4i vectorOfVec4i = new VectorOfVec4i(convexityDefects))
			{
				return vectorOfVec4i.ToArray();
			}
		}

        public static bool IsContourConvex(InputArray contour)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            contour.ThrowIfDisposed();
            return NativeMethods.imgproc_isContourConvex_InputArray(contour.CvPtr) != 0;
        }

        public static bool IsContourConvex(IEnumerable<Point> contour)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            Point[] array = EnumerableEx.ToArray(contour);
            return NativeMethods.imgproc_isContourConvex_Point(array, array.Length) != 0;
        }

        public static bool IsContourConvex(IEnumerable<Point2f> contour)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            Point2f[] array = EnumerableEx.ToArray(contour);
            return NativeMethods.imgproc_isContourConvex_Point2f(array, array.Length) != 0;
        }

        public static float IntersectConvexConvex(InputArray p1, InputArray p2, OutputArray p12, bool handleNested = true)
        {
            if (p1 == null)
            {
                throw new ArgumentNullException("p1");
            }
            if (p2 == null)
            {
                throw new ArgumentNullException("p2");
            }
            if (p12 == null)
            {
                throw new ArgumentNullException("p12");
            }
            p1.ThrowIfDisposed();
            p2.ThrowIfDisposed();
            p12.ThrowIfNotReady();
            float result = NativeMethods.imgproc_intersectConvexConvex_InputArray(p1.CvPtr, p2.CvPtr, p12.CvPtr, handleNested ? 1 : 0);
            p12.Fix();
            return result;
        }

        public static float IntersectConvexConvex(IEnumerable<Point> p1, IEnumerable<Point> p2, out Point[] p12, bool handleNested = true)
        {
            if (p1 == null)
            {
                throw new ArgumentNullException("p1");
            }
            if (p2 == null)
            {
                throw new ArgumentNullException("p2");
            }
            Point[] array = EnumerableEx.ToArray(p1);
            Point[] array2 = EnumerableEx.ToArray(p2);
            IntPtr p13 = default(IntPtr);
            float result = NativeMethods.imgproc_intersectConvexConvex_Point(array, array.Length, array2, array2.Length, out p13, handleNested ? 1 : 0);
            using (VectorOfPoint vectorOfPoint = new VectorOfPoint(p13))
            {
                p12 = vectorOfPoint.ToArray();
                return result;
            }
        }

        public static float IntersectConvexConvex(IEnumerable<Point2f> p1, IEnumerable<Point2f> p2, out Point2f[] p12, bool handleNested = true)
        {
            if (p1 == null)
            {
                throw new ArgumentNullException("p1");
            }
            if (p2 == null)
            {
                throw new ArgumentNullException("p2");
            }
            Point2f[] array = EnumerableEx.ToArray(p1);
            Point2f[] array2 = EnumerableEx.ToArray(p2);
            IntPtr p13 = default(IntPtr);
            float result = NativeMethods.imgproc_intersectConvexConvex_Point2f(array, array.Length, array2, array2.Length, out p13, handleNested ? 1 : 0);
            using (VectorOfPoint2f vectorOfPoint2f = new VectorOfPoint2f(p13))
            {
                p12 = vectorOfPoint2f.ToArray();
                return result;
            }
        }

        public static RotatedRect FitEllipse(InputArray points)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            points.ThrowIfDisposed();
            return NativeMethods.imgproc_fitEllipse_InputArray(points.CvPtr);
        }

        public static RotatedRect FitEllipse(IEnumerable<Point> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point[] array = EnumerableEx.ToArray(points);
            return NativeMethods.imgproc_fitEllipse_Point(array, array.Length);
        }

        public static RotatedRect FitEllipse(IEnumerable<Point2f> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point2f[] array = EnumerableEx.ToArray(points);
            return NativeMethods.imgproc_fitEllipse_Point2f(array, array.Length);
        }

        public static void FitLine(InputArray points, OutputArray line, DistanceType distType, double param, double reps, double aeps)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            if (line == null)
            {
                throw new ArgumentNullException("line");
            }
            points.ThrowIfDisposed();
            line.ThrowIfNotReady();
            NativeMethods.imgproc_fitLine_InputArray(points.CvPtr, line.CvPtr, (int)distType, param, reps, aeps);
            line.Fix();
        }

        public static CvLine2D FitLine(IEnumerable<Point> points, DistanceType distType, double param, double reps, double aeps)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point[] array = EnumerableEx.ToArray(points);
            float[] line = new float[4];
            NativeMethods.imgproc_fitLine_Point(array, array.Length, line, (int)distType, param, reps, aeps);
            return new CvLine2D(line);
        }

        public static CvLine2D FitLine(IEnumerable<Point2f> points, DistanceType distType, double param, double reps, double aeps)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point2f[] array = EnumerableEx.ToArray(points);
            float[] line = new float[4];
            NativeMethods.imgproc_fitLine_Point2f(array, array.Length, line, (int)distType, param, reps, aeps);
            return new CvLine2D(line);
        }

        public static CvLine3D FitLine(IEnumerable<Point3i> points, DistanceType distType, double param, double reps, double aeps)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point3i[] array = EnumerableEx.ToArray(points);
            float[] line = new float[6];
            NativeMethods.imgproc_fitLine_Point3i(array, array.Length, line, (int)distType, param, reps, aeps);
            return new CvLine3D(line);
        }

        public static CvLine3D FitLine(IEnumerable<Point3f> points, DistanceType distType, double param, double reps, double aeps)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            Point3f[] array = EnumerableEx.ToArray(points);
            float[] line = new float[6];
            NativeMethods.imgproc_fitLine_Point3f(array, array.Length, line, (int)distType, param, reps, aeps);
            return new CvLine3D(line);
        }

        public static double PointPolygonTest(InputArray contour, Point2f pt, bool measureDist)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            contour.ThrowIfDisposed();
            return NativeMethods.imgproc_pointPolygonTest_InputArray(contour.CvPtr, pt, measureDist ? 1 : 0);
        }

        public static double PointPolygonTest(IEnumerable<Point> contour, Point2f pt, bool measureDist)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            Point[] array = EnumerableEx.ToArray(contour);
            return NativeMethods.imgproc_pointPolygonTest_Point(array, array.Length, pt, measureDist ? 1 : 0);
        }

        public static double PointPolygonTest(IEnumerable<Point2f> contour, Point2f pt, bool measureDist)
        {
            if (contour == null)
            {
                throw new ArgumentNullException("contour");
            }
            Point2f[] array = EnumerableEx.ToArray(contour);
            return NativeMethods.imgproc_pointPolygonTest_Point2f(array, array.Length, pt, measureDist ? 1 : 0);
        }
    }
}
