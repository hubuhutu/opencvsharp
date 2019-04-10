using System;
using System.IO;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    public abstract class CvArr : DisposableCvObject
    {
        public virtual int Dims { get { return Cv.GetDims(this); } }

        public virtual MatrixType ElemType { get { return (MatrixType)NativeMethods.cvGetElemType(base.CvPtr); } }

        public virtual int ElemChannels
        {
            get
            {
                switch (ElemType)
                {
                    case MatrixType.U8C1:
                    case MatrixType.S8C1:
                    case MatrixType.U16C1:
                    case MatrixType.S16C1:
                    case MatrixType.S32C1:
                    case MatrixType.F32C1:
                    case MatrixType.F64C1:
                        return 1;
                    case MatrixType.U8C2:
                    case MatrixType.S8C2:
                    case MatrixType.U16C2:
                    case MatrixType.S16C2:
                    case MatrixType.S32C2:
                    case MatrixType.F32C2:
                    case MatrixType.F64C2:
                        return 2;
                    case MatrixType.U8C3:
                    case MatrixType.S8C3:
                    case MatrixType.U16C3:
                    case MatrixType.S16C3:
                    case MatrixType.S32C3:
                    case MatrixType.F32C3:
                    case MatrixType.F64C3:
                        return 3;
                    case MatrixType.U8C4:
                    case MatrixType.S8C4:
                    case MatrixType.U16C4:
                    case MatrixType.S16C4:
                    case MatrixType.S32C4:
                    case MatrixType.F32C4:
                    case MatrixType.F64C4:
                        return 4;
                    default:
                        return -1;
                }
            }
        }

        public virtual int ElemDepth
        {
            get
            {
                switch (ElemType)
                {
                    case MatrixType.U8C1:
                    case MatrixType.S8C1:
                    case MatrixType.U8C2:
                    case MatrixType.S8C2:
                    case MatrixType.U8C3:
                    case MatrixType.S8C3:
                    case MatrixType.U8C4:
                    case MatrixType.S8C4:
                        return 8;
                    case MatrixType.U16C1:
                    case MatrixType.S16C1:
                    case MatrixType.U16C2:
                    case MatrixType.S16C2:
                    case MatrixType.U16C3:
                    case MatrixType.S16C3:
                    case MatrixType.U16C4:
                    case MatrixType.S16C4:
                        return 16;
                    case MatrixType.S32C1:
                    case MatrixType.F32C1:
                    case MatrixType.S32C2:
                    case MatrixType.F32C2:
                    case MatrixType.S32C3:
                    case MatrixType.F32C3:
                    case MatrixType.S32C4:
                    case MatrixType.F32C4:
                        return 32;
                    case MatrixType.F64C1:
                    case MatrixType.F64C2:
                    case MatrixType.F64C3:
                    case MatrixType.F64C4:
                        return 64;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public virtual CvScalar this[int idx0]
        {
            get
            {
                return Cv.Get1D(this, idx0);
            }
            set
            {
                Cv.Set1D(this, idx0, value);
            }
        }

        public virtual CvScalar this[int idx0, int idx1]
        {
            get
            {
                return Cv.Get2D(this, idx0, idx1);
            }
            set
            {
                Cv.Set2D(this, idx0, idx1, value);
            }
        }

        public virtual CvScalar this[int idx0, int idx1, int idx2]
        {
            get
            {
                return Cv.Get3D(this, idx0, idx1, idx2);
            }
            set
            {
                Cv.Set3D(this, idx0, idx1, idx2, value);
            }
        }

        public void AbsDiff(CvArr src2, CvArr dst)
        {
            Cv.AbsDiff(this, src2, dst);
        }

        public void Abs(CvArr dst)
        {
            Cv.Abs(this, dst);
        }

        public void AbsDiffS(CvArr dst, CvScalar value)
        {
            Cv.AbsDiffS(this, dst, value);
        }

        public void Acc(CvArr sum)
        {
            Cv.Acc(this, sum);
        }

        public void Acc(CvArr sum, CvArr mask)
        {
            Cv.Acc(this, sum, mask);
        }

        public void AdaptiveThreshold(CvArr dst, double maxValue)
        {
            Cv.AdaptiveThreshold(this, dst, maxValue);
        }

        public void AdaptiveThreshold(CvArr dst, double maxValue, AdaptiveThresholdType adaptiveMethod)
        {
            Cv.AdaptiveThreshold(this, dst, maxValue, adaptiveMethod);
        }

        public void AdaptiveThreshold(CvArr dst, double maxValue, AdaptiveThresholdType adaptiveMethod, ThresholdType thresholdType)
        {
            Cv.AdaptiveThreshold(this, dst, maxValue, adaptiveMethod, thresholdType);
        }

        public void AdaptiveThreshold(CvArr dst, double maxValue, AdaptiveThresholdType adaptiveMethod, ThresholdType thresholdType, int blockSize)
        {
            Cv.AdaptiveThreshold(this, dst, maxValue, adaptiveMethod, thresholdType, blockSize);
        }

        public void AdaptiveThreshold(CvArr dst, double maxValue, AdaptiveThresholdType adaptiveMethod, ThresholdType thresholdType, int blockSize, double param1)
        {
            Cv.AdaptiveThreshold(this, dst, maxValue, adaptiveMethod, thresholdType, blockSize, param1);
        }

        public void Add(CvArr src2, CvArr dst)
        {
            Cv.Add(this, src2, dst);
        }

        public void Add(CvArr src2, CvArr dst, CvArr mask)
        {
            Cv.Add(this, src2, dst, mask);
        }

        public void AddS(CvScalar value, CvArr dst)
        {
            Cv.AddS(this, value, dst);
        }

        public void AddS(CvScalar value, CvArr dst, CvArr mask)
        {
            Cv.AddS(this, value, dst, mask);
        }

        public void AddText(string text, CvPoint location, CvFont font)
        {
            Cv.AddText(this, text, location, font);
        }

        public void AddWeighted(double alpha, CvArr src2, double beta, double gamma, CvArr dst)
        {
            Cv.AddWeighted(this, alpha, src2, beta, gamma, dst);
        }

        public void And(CvArr src2, CvArr dst)
        {
            Cv.And(this, src2, dst);
        }

        public void And(CvArr src2, CvArr dst, CvArr mask)
        {
            Cv.And(this, src2, dst, mask);
        }

        public void AndS(CvScalar value, CvArr dst)
        {
            Cv.AndS(this, value, dst);
        }

        public void AndS(CvScalar value, CvArr dst, CvArr mask)
        {
            Cv.AndS(this, value, dst, mask);
        }

        public double ArcLength()
        {
            return Cv.ArcLength(this);
        }

        public double ArcLength(CvSlice slice)
        {
            return Cv.ArcLength(this, slice);
        }

        public double ArcLength(CvSlice slice, int isClosed)
        {
            return Cv.ArcLength(this, slice, isClosed);
        }

        public CvScalar Avg()
        {
            return Cv.Avg(this, null);
        }

        public CvScalar Avg(CvArr mask)
        {
            return Cv.Avg(this, mask);
        }

        public void AvgSdv(out CvScalar mean, out CvScalar stdDev)
        {
            Cv.AvgSdv(this, out mean, out stdDev, null);
        }

        public void AvgSdv(out CvScalar mean, out CvScalar stdDev, CvArr mask)
        {
            Cv.AvgSdv(this, out mean, out stdDev, mask);
        }

        public CvRect BoundingRect()
        {
            return Cv.BoundingRect(this);
        }

        public CvRect BoundingRect(bool update)
        {
            return Cv.BoundingRect(this, update);
        }

        public void Canny(CvArr edges, double threshold1, double threshold2)
        {
            Cv.Canny(this, edges, threshold1, threshold2, ApertureSize.Size3);
        }

        public void Canny(CvArr edges, double threshold1, double threshold2, ApertureSize apertureSize)
        {
            Cv.Canny(this, edges, threshold1, threshold2, apertureSize);
        }

        public bool CheckArr()
        {
            return Cv.CheckArr(this);
        }

        public bool CheckArr(CheckArrFlag flags)
        {
            return Cv.CheckArr(this, flags);
        }

        public bool CheckArr(CheckArrFlag flags, double minVal, double maxVal)
        {
            return Cv.CheckArr(this, flags, minVal, maxVal);
        }

        public bool CheckArray()
        {
            return Cv.CheckArray(this);
        }

        public bool CheckArray(CheckArrFlag flags)
        {
            return Cv.CheckArray(this, flags);
        }

        public bool CheckArray(CheckArrFlag flags, double minVal, double maxVal)
        {
            return Cv.CheckArray(this, flags, minVal, maxVal);
        }

        public bool CheckContourConvexity()
        {
            return Cv.CheckContourConvexity(this);
        }

        public void Circle(int centerX, int centerY, int radius, CvScalar color)
        {
            Cv.Circle(this, centerX, centerY, radius, color);
        }

        public void Circle(int centerX, int centerY, int radius, CvScalar color, int thickness)
        {
            Cv.Circle(this, centerX, centerY, radius, color, thickness);
        }

        public void Circle(int centerX, int centerY, int radius, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Circle(this, centerX, centerY, radius, color, thickness, lineType);
        }

        public void Circle(int centerX, int centerY, int radius, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Circle(this, centerX, centerY, radius, color, thickness, lineType, shift);
        }

        public void Circle(CvPoint center, int radius, CvScalar color)
        {
            Cv.Circle(this, center, radius, color);
        }

        public void Circle(CvPoint center, int radius, CvScalar color, int thickness)
        {
            Cv.Circle(this, center, radius, color, thickness);
        }

        public void Circle(CvPoint center, int radius, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Circle(this, center, radius, color, thickness, lineType);
        }

        public void Circle(CvPoint center, int radius, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Circle(this, center, radius, color, thickness, lineType, shift);
        }

        public void DrawCircle(int centerX, int centerY, int radius, CvScalar color)
        {
            Cv.DrawCircle(this, centerX, centerY, radius, color);
        }

        public void DrawCircle(int centerX, int centerY, int radius, CvScalar color, int thickness)
        {
            Cv.DrawCircle(this, centerX, centerY, radius, color, thickness);
        }

        public void DrawCircle(int centerX, int centerY, int radius, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawCircle(this, centerX, centerY, radius, color, thickness, lineType);
        }

        public void DrawCircle(int centerX, int centerY, int radius, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawCircle(this, centerX, centerY, radius, color, thickness, lineType, shift);
        }

        public void DrawCircle(CvPoint center, int radius, CvScalar color)
        {
            Cv.DrawCircle(this, center, radius, color);
        }

        public void DrawCircle(CvPoint center, int radius, CvScalar color, int thickness)
        {
            Cv.DrawCircle(this, center, radius, color, thickness);
        }

        public void DrawCircle(CvPoint center, int radius, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawCircle(this, center, radius, color, thickness, lineType);
        }

        public void DrawCircle(CvPoint center, int radius, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawCircle(this, center, radius, color, thickness, lineType, shift);
        }

        public void ClearND(params int[] idx)
        {
            Cv.ClearND(this, idx);
        }

        public void Cmp(CvArr src2, CvArr dst, ArrComparison cmpOp)
        {
            Cv.Cmp(this, src2, dst, cmpOp);
        }

        public void CmpS(double value, CvArr dst, ArrComparison cmpOp)
        {
            Cv.CmpS(this, value, dst, cmpOp);
        }

        public double ContourArea()
        {
            return Cv.ContourArea(this);
        }

        public double ContourArea(CvSlice slice)
        {
            return Cv.ContourArea(this, slice);
        }

        public double ContourPerimeter()
        {
            return Cv.ContourPerimeter(this);
        }

        public void ConvertScale(CvArr dst)
        {
            Cv.ConvertScale(this, dst);
        }

        public void ConvertScale(CvArr dst, double scale)
        {
            Cv.ConvertScale(this, dst, scale);
        }

        public void ConvertScale(CvArr dst, double scale, double shift)
        {
            Cv.ConvertScale(this, dst, scale, shift);
        }

        public void CvtScale(CvArr dst)
        {
            Cv.CvtScale(this, dst);
        }

        public void CvtScale(CvArr dst, double scale)
        {
            Cv.CvtScale(this, dst, scale);
        }

        public void CvtScale(CvArr dst, double scale, double shift)
        {
            Cv.CvtScale(this, dst, scale, shift);
        }

        public void Scale(CvArr dst)
        {
            Cv.Scale(this, dst);
        }

        public void Scale(CvArr dst, double scale)
        {
            Cv.Scale(this, dst, scale);
        }

        public void Scale(CvArr dst, double scale, double shift)
        {
            Cv.Scale(this, dst, scale, shift);
        }

        public void Convert(CvArr dst)
        {
            Cv.Convert(this, dst);
        }

        public void ConvertScaleAbs(CvArr dst)
        {
            Cv.ConvertScaleAbs(this, dst);
        }

        public void ConvertScaleAbs(CvArr dst, double scale)
        {
            Cv.ConvertScaleAbs(this, dst, scale);
        }

        public void ConvertScaleAbs(CvArr dst, double scale, double shift)
        {
            Cv.ConvertScaleAbs(this, dst, scale, shift);
        }

        public void CvtScaleAbs(CvArr dst)
        {
            Cv.CvtScaleAbs(this, dst);
        }

        public void CvtScaleAbs(CvArr dst, double scale)
        {
            Cv.CvtScaleAbs(this, dst, scale);
        }

        public void CvtScaleAbs(CvArr dst, double scale, double shift)
        {
            Cv.CvtScaleAbs(this, dst, scale, shift);
        }

        public void ConvexHull2(out int[] hull, ConvexHullOrientation orientation)
        {
            Cv.ConvexHull2(this, out hull, orientation);
        }

        public void ConvexHull2(out CvPoint[] hull, ConvexHullOrientation orientation)
        {
            Cv.ConvexHull2(this, out hull, orientation);
        }

        public void ConvexHull2(out CvPoint2D32f[] hull, ConvexHullOrientation orientation)
        {
            Cv.ConvexHull2(this, out hull, orientation);
        }

        public CvSeq<CvConvexityDefect> ConvexityDefects(CvArr convexhull)
        {
            return Cv.ConvexityDefects(this, convexhull, null);
        }

        public CvSeq<CvConvexityDefect> ConvexityDefects(CvArr convexhull, CvMemStorage storage)
        {
            return Cv.ConvexityDefects(this, convexhull, storage);
        }

        public CvSeq<CvConvexityDefect> ConvexityDefects(int[] convexhull)
        {
            return Cv.ConvexityDefects(this, convexhull);
        }

        public void Copy(CvArr dst)
        {
            Cv.Copy(this, dst);
        }

        public void Copy(CvArr dst, CvArr mask)
        {
            Cv.Copy(this, dst, mask);
        }

        public void CopyMakeBorder(CvArr dst, CvPoint offset, BorderType bordertype)
        {
            Cv.CopyMakeBorder(this, dst, offset, bordertype);
        }

        public void CopyMakeBorder(CvArr dst, CvPoint offset, BorderType bordertype, CvScalar value)
        {
            Cv.CopyMakeBorder(this, dst, offset, bordertype, value);
        }

        public void CornerEigenValsAndVecs(CvArr eigenvv, int blockSize)
        {
            Cv.CornerEigenValsAndVecs(this, eigenvv, blockSize);
        }

        public void CornerEigenValsAndVecs(CvArr eigenvv, int blockSize, ApertureSize apertureSize)
        {
            Cv.CornerEigenValsAndVecs(this, eigenvv, blockSize, apertureSize);
        }

        public void CornerHarris(CvArr harrisResponce, int blockSize)
        {
            Cv.CornerHarris(this, harrisResponce, blockSize);
        }

        public void CornerHarris(CvArr harrisResponce, int blockSize, ApertureSize apertureSize)
        {
            Cv.CornerHarris(this, harrisResponce, blockSize, apertureSize);
        }

        public void CornerHarris(CvArr harrisResponce, int blockSize, ApertureSize apertureSize, double k)
        {
            Cv.CornerHarris(this, harrisResponce, blockSize, apertureSize, k);
        }

        public void CornerMinEigenVal(CvArr eigenval, int blockSize)
        {
            Cv.CornerMinEigenVal(this, eigenval, blockSize);
        }

        public void CornerMinEigenVal(CvArr eigenval, int blockSize, ApertureSize apertureSize)
        {
            Cv.CornerMinEigenVal(this, eigenval, blockSize, apertureSize);
        }

        public int CountNonZero()
        {
            return Cv.CountNonZero(this);
        }

        public void CreateData()
        {
            Cv.CreateData(this);
        }

        public CvMat[] CreatePyramid(int extraLayers, double rate, CvSize[] layerSizes, CvArr bufarr, bool calc, CvFilter filter)
        {
            return Cv.CreatePyramid(this, extraLayers, rate, layerSizes, bufarr, calc, filter);
        }

        public void CrossProduct(CvArr src2, CvArr dst)
        {
            Cv.CrossProduct(this, src2, dst);
        }

        public void CvtColor(CvArr dst, ColorConversion code)
        {
            Cv.CvtColor(this, dst, code);
        }

        public void DCT(CvArr dst, DCTFlag flags)
        {
            Cv.DCT(this, dst, flags);
        }

        public void DecRefData()
        {
            Cv.DecRefData(this);
        }

        public double Det()
        {
            return Cv.Det(this);
        }

        public void DFT(CvArr dst, DFTFlag flags)
        {
            Cv.DFT(this, dst, flags);
        }

        public void DFT(CvArr dst, DFTFlag flags, int nonzeroRows)
        {
            Cv.DFT(this, dst, flags, nonzeroRows);
        }

        public void FFT(CvArr dst, DFTFlag flags)
        {
            Cv.FFT(this, dst, flags);
        }

        public void FFT(CvArr dst, DFTFlag flags, int nonzeroRows)
        {
            Cv.FFT(this, dst, flags, nonzeroRows);
        }

        public void Dilate(CvArr dst)
        {
            Cv.Dilate(this, dst);
        }

        public void Dilate(CvArr dst, IplConvKernel element)
        {
            Cv.Dilate(this, dst, element);
        }

        public void Dilate(CvArr dst, IplConvKernel element, int iterations)
        {
            Cv.Dilate(this, dst, element, iterations);
        }

        public void DistTransform(CvArr dst)
        {
            Cv.DistTransform(this, dst);
        }

        public void DistTransform(CvArr dst, DistanceType distanceType)
        {
            Cv.DistTransform(this, dst, distanceType);
        }

        public void DistTransform(CvArr dst, DistanceType distanceType, int maskSize)
        {
            Cv.DistTransform(this, dst, distanceType, maskSize);
        }

        public void DistTransform(CvArr dst, DistanceType distanceType, int maskSize, float[] mask)
        {
            Cv.DistTransform(this, dst, distanceType, maskSize, mask);
        }

        public void DistTransform(CvArr dst, DistanceType distanceType, int maskSize, float[] mask, CvArr labels)
        {
            Cv.DistTransform(this, dst, distanceType, maskSize, mask, labels);
        }

        public void Div(CvArr src2, CvArr dst)
        {
            Cv.Div(this, src2, dst);
        }

        public void Div(CvArr src2, CvArr dst, double scale)
        {
            Cv.Div(this, src2, dst, scale);
        }

        public void DrawChessboardCorners(CvSize patternSize, CvPoint2D32f[] corners, bool patternWasFound)
        {
            Cv.DrawChessboardCorners(this, patternSize, corners, patternWasFound);
        }

        public void DrawContours(CvSeq<CvPoint> contour, CvScalar externalColor, CvScalar holeColor, int maxLevel)
        {
            Cv.DrawContours(this, contour, externalColor, holeColor, maxLevel);
        }

        public void DrawContours(CvSeq<CvPoint> contour, CvScalar externalColor, CvScalar holeColor, int maxLevel, int thickness)
        {
            Cv.DrawContours(this, contour, externalColor, holeColor, maxLevel, thickness);
        }

        public void DrawContours(CvSeq<CvPoint> contour, CvScalar externalColor, CvScalar holeColor, int maxLevel, int thickness, LineType lineType)
        {
            Cv.DrawContours(this, contour, externalColor, holeColor, maxLevel, thickness, lineType);
        }

        public void DrawContours(CvSeq<CvPoint> contour, CvScalar externalColor, CvScalar holeColor, int maxLevel, int thickness, LineType lineType, CvPoint offset)
        {
            Cv.DrawContours(this, contour, externalColor, holeColor, maxLevel, thickness, lineType, offset);
        }

        public void EigenVV(CvArr evects, CvArr evals)
        {
            Cv.EigenVV(this, evects, evals);
        }

        public void EigenVV(CvArr evects, CvArr evals, double eps)
        {
            Cv.EigenVV(this, evects, evals, eps);
        }

        public void Ellipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color)
        {
            Cv.Ellipse(this, center, axes, angle, startAngle, endAngle, color);
        }

        public void Ellipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness)
        {
            Cv.Ellipse(this, center, axes, angle, startAngle, endAngle, color, thickness);
        }

        public void Ellipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Ellipse(this, center, axes, angle, startAngle, endAngle, color, thickness, lineType);
        }

        public void Ellipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Ellipse(this, center, axes, angle, startAngle, endAngle, color, thickness, lineType, shift);
        }

        public void DrawEllipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color)
        {
            Cv.DrawEllipse(this, center, axes, angle, startAngle, endAngle, color);
        }

        public void DrawEllipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness)
        {
            Cv.DrawEllipse(this, center, axes, angle, startAngle, endAngle, color, thickness);
        }

        public void DrawEllipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawEllipse(this, center, axes, angle, startAngle, endAngle, color, thickness, lineType);
        }

        public void DrawEllipse(CvPoint center, CvSize axes, double angle, double startAngle, double endAngle, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawEllipse(this, center, axes, angle, startAngle, endAngle, color, thickness, lineType, shift);
        }

        public void EllipseBox(CvBox2D box, CvScalar color)
        {
            Cv.EllipseBox(this, box, color);
        }

        public void EllipseBox(CvBox2D box, CvScalar color, int thickness)
        {
            Cv.EllipseBox(this, box, color, thickness);
        }

        public void EllipseBox(CvBox2D box, CvScalar color, int thickness, LineType lineType)
        {
            Cv.EllipseBox(this, box, color, thickness, lineType);
        }

        public void EllipseBox(CvBox2D box, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.EllipseBox(this, box, color, thickness, lineType, shift);
        }

        public void EqualizeHist(CvArr dst)
        {
            Cv.EqualizeHist(this, dst);
        }

        public void Erode(CvArr dst)
        {
            Cv.Erode(this, dst);
        }

        public void Erode(CvArr dst, IplConvKernel element)
        {
            Cv.Erode(this, dst, element);
        }

        public void Erode(CvArr dst, IplConvKernel element, int iterations)
        {
            Cv.Erode(this, dst, element, iterations);
        }

        public void Exp(CvArr dst)
        {
            Cv.Exp(this, dst);
        }

        public CvContour[] ExtractMSER(CvArr mask, CvMemStorage storage, CvMSERParams @params)
        {
            CvContour[] contours;
            Cv.ExtractMSER(this, mask, out  contours, storage, @params);
            return contours;
        }

        public void ExtractSURF(CvArr mask, out CvSeq<CvSURFPoint> keypoints, out CvSeq<IntPtr> descriptors, CvMemStorage storage, CvSURFParams param)
        {
            Cv.ExtractSURF(this, mask, out keypoints, out descriptors, storage, param);
        }

        public void ExtractSURF(CvArr mask, ref CvSeq<CvSURFPoint> keypoints, out CvSeq<IntPtr> descriptors, CvMemStorage storage, CvSURFParams param, bool useProvidedKeyPts)
        {
            Cv.ExtractSURF(this, mask, ref keypoints, out descriptors, storage, param, useProvidedKeyPts);
        }

        public void ExtractSURF(CvArr mask, out CvSURFPoint[] keypoints, out float[][] descriptors, CvSURFParams param)
        {
            Cv.ExtractSURF(this, mask, out keypoints, out descriptors, param);
        }

        public void ExtractSURF(CvArr mask, ref CvSURFPoint[] keypoints, out float[][] descriptors, CvSURFParams param, bool useProvidedKeyPts)
        {
            Cv.ExtractSURF(this, mask, ref keypoints, out descriptors, param, useProvidedKeyPts);
        }

        public void FillConvexPoly(CvPoint[] pts, CvScalar color)
        {
            Cv.FillConvexPoly(this, pts, color);
        }

        public void FillConvexPoly(CvPoint[] pts, CvScalar color, LineType lineType)
        {
            Cv.FillConvexPoly(this, pts, color, lineType);
        }

        public void FillConvexPoly(CvPoint[] pts, CvScalar color, LineType lineType, int shift)
        {
            Cv.FillConvexPoly(this, pts, color, lineType, shift);
        }

        public void FillPoly(CvPoint[][] pts, CvScalar color)
        {
            Cv.FillPoly(this, pts, color);
        }

        public void FillPoly(CvPoint[][] pts, CvScalar color, LineType lineType)
        {
            Cv.FillPoly(this, pts, color, lineType);
        }

        public void FillPoly(CvPoint[][] pts, CvScalar color, LineType lineType, int shift)
        {
            Cv.FillPoly(this, pts, color, lineType, shift);
        }

        public void Filter2D(CvArr dst, CvMat kernel)
        {
            Cv.Filter2D(this, dst, kernel);
        }

        public void Filter2D(CvArr dst, CvMat kernel, CvPoint anchor)
        {
            Cv.Filter2D(this, dst, kernel, anchor);
        }

        public bool FindChessboardCorners(CvSize patternSize, out CvPoint2D32f[] corners)
        {
            return Cv.FindChessboardCorners(this, patternSize, out corners);
        }

        public bool FindChessboardCorners(CvSize patternSize, out CvPoint2D32f[] corners, out int cornerCount)
        {
            return Cv.FindChessboardCorners(this, patternSize, out corners, out cornerCount);
        }

        public bool FindChessboardCorners(CvSize patternSize, out CvPoint2D32f[] corners, out int cornerCount, ChessboardFlag flags)
        {
            return Cv.FindChessboardCorners(this, patternSize, out corners, out cornerCount, flags);
        }

        public int FindContours(CvMemStorage storage, out CvSeq<CvPoint> firstContour)
        {
            return Cv.FindContours(this, storage, out firstContour);
        }

        public int FindContours(CvMemStorage storage, out CvSeq<CvPoint> firstContour, int headerSize)
        {
            return Cv.FindContours(this, storage, out firstContour, headerSize);
        }

        public int FindContours(CvMemStorage storage, out CvSeq<CvPoint> firstContour, int headerSize, ContourRetrieval mode)
        {
            return Cv.FindContours(this, storage, out firstContour, headerSize, mode);
        }

        public int FindContours(CvMemStorage storage, out CvSeq<CvPoint> firstContour, int headerSize, ContourRetrieval mode, ContourChain method)
        {
            return Cv.FindContours(this, storage, out firstContour, headerSize, mode, method);
        }

        public int FindContours(CvMemStorage storage, out CvSeq<CvPoint> firstContour, int headerSize, ContourRetrieval mode, ContourChain method, CvPoint offset)
        {
            return Cv.FindContours(this, storage, out firstContour, headerSize, mode, method, offset);
        }

        public void FindCornerSubPix(CvPoint2D32f[] corners, int count, CvSize win, CvSize zeroZone, CvTermCriteria criteria)
        {
            Cv.FindCornerSubPix(this, corners, count, win, zeroZone, criteria);
        }

        public CvBox2D FitEllipse2()
        {
            return Cv.FitEllipse2(this);
        }

        public void FitLine(DistanceType distType, double param, double reps, double aeps, float[] line)
        {
            Cv.FitLine(this, distType, param, reps, aeps, line);
        }

        public void Flip()
        {
            Cv.Flip(this);
        }

        public void Flip(CvArr dst)
        {
            Cv.Flip(this, dst);
        }

        public void Flip(CvArr dst, FlipMode flipMode)
        {
            Cv.Flip(this, dst, flipMode);
        }

        public void Mirror()
        {
            Cv.Mirror(this);
        }

        public void Mirror(CvArr dst)
        {
            Cv.Mirror(this, dst);
        }

        public void Mirror(CvArr dst, FlipMode flipMode)
        {
            Cv.Mirror(this, dst, flipMode);
        }

        public void FloodFill(CvPoint seedPoint, CvScalar newVal)
        {
            Cv.FloodFill(this, seedPoint, newVal);
        }

        public void FloodFill(CvPoint seedPoint, CvScalar newVal, CvScalar loDiff)
        {
            Cv.FloodFill(this, seedPoint, newVal, loDiff);
        }

        public void FloodFill(CvPoint seedPoint, CvScalar newVal, CvScalar loDiff, CvScalar upDiff)
        {
            Cv.FloodFill(this, seedPoint, newVal, loDiff, upDiff);
        }

        public void FloodFill(CvPoint seedPoint, CvScalar newVal, CvScalar loDiff, CvScalar upDiff, out CvConnectedComp comp)
        {
            Cv.FloodFill(this, seedPoint, newVal, loDiff, upDiff, out comp);
        }

        public void FloodFill(CvPoint seedPoint, CvScalar newVal, CvScalar loDiff, CvScalar upDiff, out CvConnectedComp comp, FloodFillFlag flags)
        {
            Cv.FloodFill(this, seedPoint, newVal, loDiff, upDiff, out comp, flags);
        }

        public void FloodFill(CvPoint seedPoint, CvScalar newVal, CvScalar loDiff, CvScalar upDiff, out CvConnectedComp comp, FloodFillFlag flags, CvArr mask)
        {
            Cv.FloodFill(this, seedPoint, newVal, loDiff, upDiff, out comp, flags, mask);
        }

        public CvScalar Get1D(int idx0)
        {
            return NativeMethods.cvGet1D(base.CvPtr, idx0);
        }

        public CvScalar Get2D(int idx0, int idx1)
        {
            return NativeMethods.cvGet2D(base.CvPtr, idx0, idx1);
        }

        public CvScalar Get3D(int idx0, int idx1, int idx2)
        {
            return NativeMethods.cvGet3D(base.CvPtr, idx0, idx1, idx2);
        }

        public CvScalar GetND(params int[] idx)
        {
            return NativeMethods.cvGetND(base.CvPtr, idx);
        }

        public CvMat GetCol(int col)
        {
            CvMat submat;
            return Cv.GetCol(this, out submat, col);
        }

        public CvMat GetCols(int startCol, int endCol)
        {
            CvMat submat;
            return Cv.GetCols(this, out submat, startCol, endCol);
        }

        public CvMat GetDiag(out CvMat submat)
        {
            return Cv.GetDiag(this, out submat);
        }

        public CvMat GetDiag(out CvMat submat, DiagType diag)
        {
            return Cv.GetDiag(this, out submat, diag);
        }

        public int GetDims()
        {
            return Cv.GetDims(this);
        }

        public int GetDims(out int[] sizes)
        {
            return Cv.GetDims(this, out sizes);
        }

        public int GetDimSize(int index)
        {
            return Cv.GetDimSize(this, index);
        }

        public MatrixType GetElemType()
        {
            return Cv.GetElemType(this);
        }

        public void GetQuadrangleSubPix(CvArr dst, CvMat mapMatrix)
        {
            Cv.GetQuadrangleSubPix(this, dst, mapMatrix);
        }

        public void GetRawData(out IntPtr data)
        {
            Cv.GetRawData(this, out data);
        }

        public void GetRawData(out IntPtr data, out int step)
        {
            Cv.GetRawData(this, out data, out step);
        }

        public void GetRawData(out IntPtr data, out int step, out CvSize roiSize)
        {
            Cv.GetRawData(this, out data, out step, out roiSize);
        }

        public double GetReal1D(int idx0)
        {
            return NativeMethods.cvGetReal1D(base.CvPtr, idx0);
        }

        public double GetReal2D(int idx0, int idx1)
        {
            return NativeMethods.cvGetReal2D(base.CvPtr, idx0, idx1);
        }

        public double GetReal3D(int idx0, int idx1, int idx2)
        {
            return NativeMethods.cvGetReal3D(base.CvPtr, idx0, idx1, idx2);
        }

        public double GetRealND(params int[] idx)
        {
            return NativeMethods.cvGetRealND(base.CvPtr, idx);
        }

        public void GetRectSubPix(CvArr dst, CvPoint2D32f center)
        {
            Cv.GetRectSubPix(this, dst, center);
        }

        public CvMat GetRow(int row)
        {
            CvMat submat;
            return Cv.GetRow(this, out submat, row);
        }

        public CvMat GetRows(int startRow, int endRow)
        {
            CvMat submat;
            return Cv.GetRows(this, out submat, startRow, endRow);
        }

        public CvMat GetRows(int startRow, int endRow, int deltaRow)
        {
            CvMat submat;
            return Cv.GetRows(this, out submat, startRow, endRow, deltaRow);
        }

        public CvSize GetSize()
        {
            return Cv.GetSize(this);
        }

        public CvSeq GetStarKeypoints(CvMemStorage storage)
        {
            return Cv.GetStarKeypoints(this, storage, new CvStarDetectorParams());
        }

        public CvSeq<CvStarKeypoint> GetStarKeypoints(CvMemStorage storage, CvStarDetectorParams @params)
        {
            return Cv.GetStarKeypoints(this, storage, @params);
        }

        public CvMat GetSubRect(out CvMat submat, CvRect rect)
        {
            return Cv.GetSubRect(this, out submat, rect);
        }

        public CvMat GetSubArr(out CvMat submat, CvRect rect)
        {
            return Cv.GetSubArr(this, out submat, rect);
        }

        public CvSeq<CvAvgComp> HaarDetectObjects(CvHaarClassifierCascade cascade, CvMemStorage storage)
        {
            return Cv.HaarDetectObjects(this, cascade, storage);
        }

        public CvSeq<CvAvgComp> HaarDetectObjects(CvHaarClassifierCascade cascade, CvMemStorage storage, double scaleFactor)
        {
            return Cv.HaarDetectObjects(this, cascade, storage, scaleFactor);
        }

        public CvSeq<CvAvgComp> HaarDetectObjects(CvHaarClassifierCascade cascade, CvMemStorage storage, double scaleFactor, int minNeighbors)
        {
            return Cv.HaarDetectObjects(this, cascade, storage, scaleFactor, minNeighbors);
        }

        public CvSeq<CvAvgComp> HaarDetectObjects(CvHaarClassifierCascade cascade, CvMemStorage storage, double scaleFactor, int minNeighbors, HaarDetectionType flags)
        {
            return Cv.HaarDetectObjects(this, cascade, storage, scaleFactor, minNeighbors, flags);
        }

        public CvSeq<CvAvgComp> HaarDetectObjects(CvHaarClassifierCascade cascade, CvMemStorage storage, double scaleFactor, int minNeighbors, HaarDetectionType flags, CvSize minSize, CvSize maxSize)
        {
            return Cv.HaarDetectObjects(this, cascade, storage, scaleFactor, minNeighbors, flags, minSize, maxSize);
        }

        public CvSeq<CvCircleSegment> HoughCircles(CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist);
        }

        public CvSeq<CvCircleSegment> HoughCircles(CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1);
        }

        public CvSeq<CvCircleSegment> HoughCircles(CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1, param2);
        }

        public CvSeq<CvCircleSegment> HoughCircles(CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1, param2, minRadius);
        }

        public CvSeq<CvCircleSegment> HoughCircles(CvMemStorage circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1, param2, minRadius, maxRadius);
        }

        public CvSeq<CvCircleSegment> HoughCircles(CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist);
        }

        public CvSeq<CvCircleSegment> HoughCircles(CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1);
        }

        public CvSeq<CvCircleSegment> HoughCircles(CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1, param2);
        }

        public CvSeq<CvCircleSegment> HoughCircles(CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1, param2, minRadius);
        }

        public CvSeq<CvCircleSegment> HoughCircles(CvMat circleStorage, HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius)
        {
            return Cv.HoughCircles(this, circleStorage, method, dp, minDist, param1, param2, minRadius);
        }

        public CvSeq HoughLines2(CvMemStorage lineStorage, HoughLinesMethod method, double rho, double theta, int threshold)
        {
            return Cv.HoughLines2(this, lineStorage, method, rho, theta, threshold);
        }

        public CvSeq HoughLines2(CvMemStorage lineStorage, HoughLinesMethod method, double rho, double theta, int threshold, double param1, double param2)
        {
            return Cv.HoughLines2(this, lineStorage, method, rho, theta, threshold, param1, param2);
        }

        public CvSeq HoughLines2(CvMat lineStorage, HoughLinesMethod method, double rho, double theta, int threshold)
        {
            return Cv.HoughLines2(this, lineStorage, method, rho, theta, threshold, 0.0, 0.0);
        }

        public CvSeq HoughLines2(CvMat lineStorage, HoughLinesMethod method, double rho, double theta, int threshold, double param1, double param2)
        {
            return Cv.HoughLines2(this, lineStorage, method, rho, theta, threshold, param1, param2);
        }

        public int IncRefData()
        {
            return Cv.IncRefData(this);
        }

        public void Inpaint(CvArr mask, CvArr dst, double inpaintRange, InpaintMethod flags)
        {
            Cv.Inpaint(this, mask, dst, inpaintRange, flags);
        }

        public void InRange(CvArr lower, CvArr upper, CvArr dst)
        {
            Cv.InRange(this, lower, upper, dst);
        }

        public void InRangeS(CvScalar lower, CvScalar upper, CvArr dst)
        {
            Cv.InRangeS(this, lower, upper, dst);
        }

        public void Integral(CvArr sum)
        {
            Cv.Integral(this, sum);
        }

        public void Integral(CvArr sum, CvArr sqsum)
        {
            Cv.Integral(this, sum, sqsum);
        }

        public void Integral(CvArr sum, CvArr sqsum, CvArr tiltedSum)
        {
            Cv.Integral(this, sum, sqsum, tiltedSum);
        }

        public double Invert(CvArr dst)
        {
            return Cv.Invert(this, dst);
        }

        public double Invert(CvArr dst, InvertMethod method)
        {
            return Cv.Invert(this, dst, method);
        }

        public double Inv(CvArr dst)
        {
            return Cv.Inv(this, dst);
        }

        public double Inv(CvArr dst, InvertMethod method)
        {
            return Cv.Inv(this, dst, method);
        }

        public void KMeans2(int clusterCount, CvArr labels, CvTermCriteria termcrit)
        {
            Cv.KMeans2(this, clusterCount, labels, termcrit);
        }

        public void Laplace(CvArr dst)
        {
            Cv.Laplace(this, dst);
        }

        public void Laplace(CvArr dst, ApertureSize apertureSize)
        {
            Cv.Laplace(this, dst, apertureSize);
        }

        public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color)
        {
            Cv.Line(this, pt1X, pt1Y, pt2X, pt2Y, color);
        }

        public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness)
        {
            Cv.Line(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness);
        }

        public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Line(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType);
        }

        public void Line(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Line(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType, shift);
        }

        public void Line(CvPoint pt1, CvPoint pt2, CvScalar color)
        {
            Cv.Line(this, pt1, pt2, color);
        }

        public void Line(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness)
        {
            Cv.Line(this, pt1, pt2, color, thickness);
        }

        public void Line(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Line(this, pt1, pt2, color, thickness, lineType);
        }

        public void Line(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Line(this, pt1, pt2, color, thickness, lineType, shift);
        }

        public void DrawLine(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color)
        {
            Cv.DrawLine(this, pt1X, pt1Y, pt2X, pt2Y, color);
        }

        public void DrawLine(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness)
        {
            Cv.DrawLine(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness);
        }

        public void DrawLine(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawLine(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType);
        }

        public void DrawLine(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawLine(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType, shift);
        }

        public void DrawLine(CvPoint pt1, CvPoint pt2, CvScalar color)
        {
            Cv.DrawLine(this, pt1, pt2, color);
        }

        public void DrawLine(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness)
        {
            Cv.DrawLine(this, pt1, pt2, color, thickness);
        }

        public void DrawLine(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawLine(this, pt1, pt2, color, thickness, lineType);
        }

        public void DrawLine(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawLine(this, pt1, pt2, color, thickness, lineType, shift);
        }

        public void LinearPolar(CvArr dst, CvPoint2D32f center, double maxRadius)
        {
            Cv.LinearPolar(this, dst, center, maxRadius);
        }

        public void LinearPolar(CvArr dst, CvPoint2D32f center, double maxRadius, Interpolation flags)
        {
            Cv.LinearPolar(this, dst, center, maxRadius, flags);
        }

        public void Log(CvArr dst)
        {
            Cv.Log(this, dst);
        }

        public void LogPolar(CvArr dst, CvPoint2D32f center, double m)
        {
            Cv.LogPolar(this, dst, center, m);
        }

        public void LogPolar(CvArr dst, CvPoint2D32f center, double m, Interpolation flags)
        {
            Cv.LogPolar(this, dst, center, m, flags);
        }

        public void LUT(CvArr dst, CvArr lut)
        {
            Cv.LUT(this, dst, lut);
        }

        public void LUT(CvArr dst, byte[] lut)
        {
            Cv.LUT(this, dst, lut);
        }

        public void LUT(CvArr dst, short[] lut)
        {
            Cv.LUT(this, dst, lut);
        }

        public void LUT(CvArr dst, int[] lut)
        {
            Cv.LUT(this, dst, lut);
        }

        public void LUT(CvArr dst, float[] lut)
        {
            Cv.LUT(this, dst, lut);
        }

        public void LUT(CvArr dst, double[] lut)
        {
            Cv.LUT(this, dst, lut);
        }

        public void MatchTemplate(CvArr templ, CvArr result, MatchTemplateMethod method)
        {
            Cv.MatchTemplate(this, templ, result, method);
        }

        public void Max(CvArr src2, CvArr dst)
        {
            Cv.Max(this, src2, dst);
        }

        public void MaxS(double value, CvArr dst)
        {
            Cv.MaxS(this, value, dst);
        }

        public void Min(CvArr src2, CvArr dst)
        {
            Cv.Min(this, src2, dst);
        }

        public CvBox2D MinAreaRect2()
        {
            return Cv.MinAreaRect2(this);
        }

        public CvBox2D MinAreaRect2(CvMemStorage storage)
        {
            return Cv.MinAreaRect2(this, storage);
        }

        public bool MinEnclosingCircle(out CvPoint2D32f center, out float radius)
        {
            return Cv.MinEnclosingCircle(this, out center, out radius);
        }

        public void MinMaxLoc(out double minVal, out double maxVal)
        {
            Cv.MinMaxLoc(this, out minVal, out maxVal);
        }

        public void MinMaxLoc(out double minVal, out double maxVal, CvArr mask)
        {
            Cv.MinMaxLoc(this, out minVal, out maxVal, mask);
        }

        public void MinMaxLoc(out CvPoint minLoc, out CvPoint maxLoc)
        {
            Cv.MinMaxLoc(this, out minLoc, out maxLoc);
        }

        public void MinMaxLoc(out CvPoint minLoc, out CvPoint maxLoc, CvArr mask)
        {
            Cv.MinMaxLoc(this, out minLoc, out maxLoc, mask);
        }

        public void MinMaxLoc(out double minVal, out double maxVal, out CvPoint minLoc, out CvPoint maxLoc)
        {
            Cv.MinMaxLoc(this, out minVal, out maxVal, out minLoc, out maxLoc);
        }

        public void MinMaxLoc(out double minVal, out double maxVal, out CvPoint minLoc, out CvPoint maxLoc, CvArr mask)
        {
            Cv.MinMaxLoc(this, out minVal, out maxVal, out minLoc, out maxLoc, mask);
        }

        public void MinS(double value, CvArr dst)
        {
            Cv.MinS(this, value, dst);
        }

        public CvMoments Moments(bool isBinary)
        {
            CvMoments moments;
            Cv.Moments(this, out moments, isBinary);
            return moments;
        }

        public void Mul(CvArr src2, CvArr dst)
        {
            Cv.Mul(this, src2, dst);
        }

        public void Mul(CvArr src2, CvArr dst, double scale)
        {
            Cv.Mul(this, src2, dst, scale);
        }

        public double Norm()
        {
            return Cv.Norm(this);
        }

        public double Norm(CvArr arr2)
        {
            return Cv.Norm(this, arr2);
        }

        public double Norm(CvArr arr2, NormType normType)
        {
            return Cv.Norm(this, arr2, normType);
        }

        public double Norm(CvArr arr2, NormType normType, CvArr mask)
        {
            return Cv.Norm(this, arr2, normType, mask);
        }

        public void Normalize(CvArr dst)
        {
            Cv.Normalize(this, dst);
        }

        public void Normalize(CvArr dst, double a, double b)
        {
            Cv.Normalize(this, dst, a, b);
        }

        public void Normalize(CvArr dst, double a, double b, NormType normType)
        {
            Cv.Normalize(this, dst, a, b, normType);
        }

        public void Normalize(CvArr dst, double a, double b, NormType normType, CvArr mask)
        {
            Cv.Normalize(this, dst, a, b, normType, mask);
        }

        public void Not(CvArr dst)
        {
            Cv.Not(this, dst);
        }

        public void Or(CvArr src2, CvArr dst)
        {
            Cv.Or(this, src2, dst);
        }

        public void Or(CvArr src2, CvArr dst, CvArr mask)
        {
            Cv.Or(this, src2, dst, mask);
        }

        public void OrS(CvScalar value, CvArr dst)
        {
            Cv.OrS(this, value, dst);
        }

        public void OrS(CvScalar value, CvArr dst, CvArr mask)
        {
            Cv.OrS(this, value, dst, mask);
        }

        public void PerspectiveTransform(CvArr dst, CvMat mat)
        {
            Cv.PerspectiveTransform(this, dst, mat);
        }

        public double PointPolygonTest(CvPoint2D32f pt, bool measureDist)
        {
            return Cv.PointPolygonTest(this, pt, measureDist);
        }

        public void PolyLine(CvPoint[][] pts, bool isClosed, CvScalar color)
        {
            Cv.PolyLine(this, pts, isClosed, color);
        }

        public void PolyLine(CvPoint[][] pts, bool isClosed, CvScalar color, int thickness)
        {
            Cv.PolyLine(this, pts, isClosed, color, thickness);
        }

        public void PolyLine(CvPoint[][] pts, bool isClosed, CvScalar color, int thickness, LineType lineType)
        {
            Cv.PolyLine(this, pts, isClosed, color, thickness, lineType);
        }

        public void PolyLine(CvPoint[][] pts, bool isClosed, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.PolyLine(this, pts, isClosed, color, thickness, lineType, shift);
        }

        public void DrawPolyLine(CvPoint[][] pts, bool isClosed, CvScalar color)
        {
            Cv.DrawPolyLine(this, pts, isClosed, color);
        }

        public void DrawPolyLine(CvPoint[][] pts, bool isClosed, CvScalar color, int thickness)
        {
            Cv.DrawPolyLine(this, pts, isClosed, color, thickness);
        }

        public void DrawPolyLine(CvPoint[][] pts, bool isClosed, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawPolyLine(this, pts, isClosed, color, thickness, lineType);
        }

        public void DrawPolyLine(CvPoint[][] pts, bool isClosed, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawPolyLine(this, pts, isClosed, color, thickness, lineType, shift);
        }

        public void Pow(CvArr dst, double power)
        {
            Cv.Pow(this, dst, power);
        }

        public void PreCornerDetect(CvArr corners)
        {
            Cv.PreCornerDetect(this, corners);
        }

        public void PreCornerDetect(CvArr corners, ApertureSize apertureSize)
        {
            Cv.PreCornerDetect(this, corners, apertureSize);
        }

        public IntPtr Ptr1D(int idx0)
        {
            return Cv.Ptr1D(this, idx0);
        }

        public IntPtr Ptr1D(int idx0, out MatrixType type)
        {
            return Cv.Ptr1D(this, idx0, out type);
        }

        public IntPtr Ptr2D(int idx0, int idx1)
        {
            return Cv.Ptr2D(this, idx0, idx1);
        }

        public IntPtr Ptr2D(int idx0, int idx1, out MatrixType type)
        {
            return Cv.Ptr2D(this, idx0, idx1, out type);
        }

        public IntPtr Ptr3D(int idx0, int idx1, int idx2)
        {
            return Cv.Ptr3D(this, idx0, idx1, idx2);
        }

        public IntPtr Ptr3D(int idx0, int idx1, int idx2, out MatrixType type)
        {
            return Cv.Ptr3D(this, idx0, idx1, idx2, out type);
        }

        public IntPtr PtrND(params int[] idx)
        {
            return Cv.PtrND(this, idx);
        }

        public IntPtr PtrND(int[] idx, out MatrixType type)
        {
            return Cv.PtrND(this, idx, out type);
        }

        public IntPtr PtrND(int[] idx, out MatrixType type, bool createNode)
        {
            return Cv.PtrND(this, idx, out type, createNode);
        }

        public IntPtr PtrND(int[] idx, out MatrixType type, bool createNode, uint? precalcHashval)
        {
            return Cv.PtrND(this, idx, out type, createNode, precalcHashval);
        }

        public void PutText(string text, CvPoint org, CvFont font, CvScalar color)
        {
            Cv.PutText(this, text, org, font, color);
        }

        public void PyrDown(CvArr dst)
        {
            Cv.PyrDown(this, dst);
        }

        public void PyrDown(CvArr dst, CvFilter filter)
        {
            Cv.PyrDown(this, dst, filter);
        }

        public void PyrMeanShiftFiltering(CvArr dst, double sp, double sr)
        {
            Cv.PyrMeanShiftFiltering(this, dst, sp, sr);
        }

        public void PyrMeanShiftFiltering(CvArr dst, double sp, double sr, int maxLevel)
        {
            Cv.PyrMeanShiftFiltering(this, dst, sp, sr, maxLevel);
        }

        public void PyrMeanShiftFiltering(CvArr dst, double sp, double sr, int maxLevel, CvTermCriteria termcrit)
        {
            Cv.PyrMeanShiftFiltering(this, dst, sp, sr, maxLevel, termcrit);
        }

        public void PyrUp(CvArr dst)
        {
            Cv.PyrUp(this, dst);
        }

        public void PyrUp(CvArr dst, CvFilter filter)
        {
            Cv.PyrUp(this, dst, filter);
        }

        public void RandShuffle()
        {
            Cv.RandShuffle(this);
        }

        public void RandShuffle(CvRNG rng)
        {
            Cv.RandShuffle(this, rng);
        }

        public void RandShuffle(CvRNG rng, double iterFactor)
        {
            Cv.RandShuffle(this, rng, iterFactor);
        }

        public void Range(double start, double end)
        {
            Cv.Range(this, start, end);
        }

        public void Rectangle(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color)
        {
            Cv.Rectangle(this, pt1X, pt1Y, pt2X, pt2Y, color);
        }

        public void Rectangle(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness)
        {
            Cv.Rectangle(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness);
        }

        public void Rectangle(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Rectangle(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType);
        }

        public void Rectangle(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Rectangle(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType, shift);
        }

        public void Rectangle(CvPoint pt1, CvPoint pt2, CvScalar color)
        {
            Cv.Rectangle(this, pt1, pt2, color);
        }

        public void Rectangle(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness)
        {
            Cv.Rectangle(this, pt1, pt2, color, thickness);
        }

        public void Rectangle(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Rectangle(this, pt1, pt2, color, thickness, lineType);
        }

        public void Rectangle(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Rectangle(this, pt1, pt2, color, thickness, lineType, shift);
        }

        public void Rectangle(CvRect rect, CvScalar color)
        {
            Cv.Rectangle(this, rect, color);
        }

        public void Rectangle(CvRect rect, CvScalar color, int thickness)
        {
            Cv.Rectangle(this, rect, color, thickness);
        }

        public void Rectangle(CvRect rect, CvScalar color, int thickness, LineType lineType)
        {
            Cv.Rectangle(this, rect, color, thickness, lineType);
        }

        public void Rectangle(CvRect rect, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.Rectangle(this, rect, color, thickness, lineType, shift);
        }

        public void DrawRect(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color)
        {
            Cv.DrawRect(this, pt1X, pt1Y, pt2X, pt2Y, color);
        }

        public void DrawRect(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness)
        {
            Cv.DrawRect(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness);
        }

        public void DrawRect(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawRect(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType);
        }

        public void DrawRect(int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawRect(this, pt1X, pt1Y, pt2X, pt2Y, color, thickness, lineType, shift);
        }

        public void DrawRect(CvPoint pt1, CvPoint pt2, CvScalar color)
        {
            Cv.DrawRect(this, pt1, pt2, color);
        }

        public void DrawRect(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness)
        {
            Cv.DrawRect(this, pt1, pt2, color, thickness);
        }

        public void DrawRect(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawRect(this, pt1, pt2, color, thickness, lineType);
        }

        public void DrawRect(CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawRect(this, pt1, pt2, color, thickness, lineType, shift);
        }

        public void DrawRect(CvRect rect, CvScalar color)
        {
            Cv.DrawRect(this, rect, color);
        }

        public void DrawRect(CvRect rect, CvScalar color, int thickness)
        {
            Cv.DrawRect(this, rect, color, thickness);
        }

        public void DrawRect(CvRect rect, CvScalar color, int thickness, LineType lineType)
        {
            Cv.DrawRect(this, rect, color, thickness, lineType);
        }

        public void DrawRect(CvRect rect, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Cv.DrawRect(this, rect, color, thickness, lineType, shift);
        }

        public void Reduce(CvArr dst)
        {
            Cv.Reduce(this, dst);
        }

        public void Reduce(CvArr dst, ReduceDimension dim)
        {
            Cv.Reduce(this, dst, dim);
        }

        public void Reduce(CvArr dst, ReduceDimension dim, ReduceOperation type)
        {
            Cv.Reduce(this, dst, dim, type);
        }

        public void ReleaseData()
        {
            Cv.ReleaseData(this);
        }

        public void Remap(CvArr dst, CvArr mapx, CvArr mapy)
        {
            Cv.Remap(this, dst, mapx, mapy);
        }

        public void Remap(CvArr dst, CvArr mapx, CvArr mapy, Interpolation flags)
        {
            Cv.Remap(this, dst, mapx, mapy, flags);
        }

        public void Remap(CvArr dst, CvArr mapx, CvArr mapy, Interpolation flags, CvScalar fillval)
        {
            Cv.Remap(this, dst, mapx, mapy, flags, fillval);
        }

        public void Repeat(CvArr dst)
        {
            Cv.Repeat(this, dst);
        }

        public CvMat Reshape(out CvMat header, int newCn)
        {
            return Cv.Reshape(this, out header, newCn);
        }

        public CvMat Reshape(out CvMat header, int newCn, int newRows)
        {
            return Cv.Reshape(this, out header, newCn, newRows);
        }

        public CvMat Reshape(CvMat header, int newCn)
        {
            return Cv.Reshape(this, header, newCn);
        }

        public CvMat Reshape(CvMat header, int newCn, int newRows)
        {
            return Cv.Reshape(this, header, newCn, newRows);
        }

        public T ReshapeMatND<T>(int sizeofHeader, T header, int newCn, int newDims, int[] newSizes) where T : CvArr
        {
            return Cv.ReshapeMatND(this, sizeofHeader, header, newCn, newDims, newSizes);
        }

        public T ReshapeND<T>(T header, int newCn, int newDims, int[] newSizes) where T : CvArr
        {
            return Cv.ReshapeND(this, header, newCn, newDims, newSizes);
        }

        public void Resize(CvArr dst)
        {
            Cv.Resize(this, dst);
        }

        public void Resize(CvArr dst, Interpolation interpolation)
        {
            Cv.Resize(this, dst, interpolation);
        }

        public int SampleLine(CvPoint pt1, CvPoint pt2, out CvPoint[] buffer, int connectivity)
        {
            return Cv.SampleLine(this, pt1, pt2, out buffer, connectivity);
        }

        public void ScaleAdd(CvScalar scale, CvArr src2, CvArr dst)
        {
            Cv.ScaleAdd(this, scale, src2, dst);
        }

        public void MulAddS(CvScalar scale, CvArr src2, CvArr dst)
        {
            Cv.MulAddS(this, scale, src2, dst);
        }

        public void Set(CvScalar value)
        {
            Cv.Set(this, value);
        }

        public void Set(CvScalar value, CvArr mask)
        {
            Cv.Set(this, value, mask);
        }

        public void Set1D(int idx0, CvScalar value)
        {
            NativeMethods.cvSet1D(base.CvPtr, idx0, value);
        }

        public void Set2D(int idx0, int idx1, CvScalar value)
        {
            NativeMethods.cvSet2D(base.CvPtr, idx0, idx1, value);
        }

        public void Set3D(int idx0, int idx1, int idx2, CvScalar value)
        {
            NativeMethods.cvSet3D(base.CvPtr, idx0, idx1, idx2, value);
        }

        public void SetND(CvScalar value, params int[] idx)
        {
            NativeMethods.cvSetND(base.CvPtr, idx, value);
        }

        public void SetData<T>(T[] data, int step) where T : struct
        {
            Cv.SetData(this, data, step);
        }

        public void SetData(IntPtr data, int step)
        {
            Cv.SetData(this, data, step);
        }

        public void SetIdentity()
        {
            Cv.SetIdentity(this);
        }

        public void SetIdentity(CvScalar value)
        {
            Cv.SetIdentity(this, value);
        }

        public void SetReal1D(int idx0, double value)
        {
            NativeMethods.cvSetReal1D(base.CvPtr, idx0, value);
        }

        public void SetReal2D(int idx0, int idx1, double value)
        {
            NativeMethods.cvSetReal2D(base.CvPtr, idx0, idx1, value);
        }

        public void SetReal3D(int idx0, int idx1, int idx2, double value)
        {
            NativeMethods.cvSetReal3D(base.CvPtr, idx0, idx1, idx2, value);
        }

        public void SetRealND(double value, params int[] idx)
        {
            NativeMethods.cvSetRealND(base.CvPtr, idx, value);
        }

        public void SetZero()
        {
            Cv.SetZero(this);
        }

        public void Zero()
        {
            Cv.Zero(this);
        }

        public void Smooth(CvArr dst)
        {
            Cv.Smooth(this, dst);
        }

        public void Smooth(CvArr dst, SmoothType smoothtype)
        {
            Cv.Smooth(this, dst, smoothtype);
        }

        public void Smooth(CvArr dst, SmoothType smoothtype, int param1)
        {
            Cv.Smooth(this, dst, smoothtype, param1);
        }

        public void Smooth(CvArr dst, SmoothType smoothtype, int param1, int param2)
        {
            Cv.Smooth(this, dst, smoothtype, param1, param2);
        }

        public void Smooth(CvArr dst, SmoothType smoothtype, int param1, int param2, double param3)
        {
            Cv.Smooth(this, dst, smoothtype, param1, param2, param3);
        }

        public void Smooth(CvArr dst, SmoothType smoothtype, int param1, int param2, double param3, double param4)
        {
            Cv.Smooth(this, dst, smoothtype, param1, param2, param3, param4);
        }

        public void Sobel(CvArr dst, int xorder, int yorder)
        {
            Cv.Sobel(this, dst, xorder, yorder);
        }

        public void Sobel(CvArr dst, int xorder, int yorder, ApertureSize apertureSize)
        {
            Cv.Sobel(this, dst, xorder, yorder, apertureSize);
        }

        public void Sort()
        {
            Cv.Sort(this);
        }

        public void Sort(CvArr dst)
        {
            Cv.Sort(this, dst);
        }

        public void Sort(CvArr dst, CvArr idxmat)
        {
            Cv.Sort(this, dst, idxmat);
        }

        public void Sort(CvArr dst, CvArr idxmat, SortFlag flags)
        {
            Cv.Sort(this, dst, idxmat, flags);
        }

        public void Split(CvArr dst0, CvArr dst1, CvArr dst2, CvArr dst3)
        {
            Cv.Split(this, dst0, dst1, dst2, dst3);
        }

        public void CvtPixToPlane(CvArr dst0, CvArr dst1, CvArr dst2, CvArr dst3)
        {
            Cv.Split(this, dst0, dst1, dst2, dst3);
        }

        public void SquareAcc(CvArr sqsum)
        {
            Cv.SquareAcc(this, sqsum);
        }

        public void SquareAcc(CvArr sqsum, CvArr mask)
        {
            Cv.SquareAcc(this, sqsum, mask);
        }

        public CvContourScanner StartFindContours(CvMemStorage storage)
        {
            return Cv.StartFindContours(this, storage);
        }

        public CvContourScanner StartFindContours(CvMemStorage storage, int headerSize)
        {
            return Cv.StartFindContours(this, storage, headerSize);
        }

        public CvContourScanner StartFindContours(CvMemStorage storage, int headerSize, ContourRetrieval mode)
        {
            return Cv.StartFindContours(this, storage, headerSize, mode);
        }

        public CvContourScanner StartFindContours(CvMemStorage storage, int headerSize, ContourRetrieval mode, ContourChain method)
        {
            return Cv.StartFindContours(this, storage, headerSize, mode, method);
        }

        public CvContourScanner StartFindContours(CvMemStorage storage, int headerSize, ContourRetrieval mode, ContourChain method, CvPoint offset)
        {
            return Cv.StartFindContours(this, storage, headerSize, mode, method, offset);
        }

        public void Sub(CvArr src2, CvArr dst)
        {
            Cv.Sub(this, src2, dst);
        }

        public void Sub(CvArr src2, CvArr dst, CvArr mask)
        {
            Cv.Sub(this, src2, dst, mask);
        }

        public void SubS(CvScalar value, CvArr dst)
        {
            Cv.SubS(this, value, dst);
        }

        public void SubS(CvScalar value, CvArr dst, CvArr mask)
        {
            Cv.SubS(this, value, dst, mask);
        }

        public void SubRS(CvScalar value, CvArr dst)
        {
            Cv.SubRS(this, value, dst);
        }

        public void SubRS(CvScalar value, CvArr dst, CvArr mask)
        {
            Cv.SubRS(this, value, dst, mask);
        }

        public CvScalar Sum()
        {
            return Cv.Sum(this);
        }

        public void SVD(CvArr w)
        {
            Cv.SVD(this, w);
        }

        public void SVD(CvArr w, CvArr u)
        {
            Cv.SVD(this, w, u);
        }

        public void SVD(CvArr w, CvArr u, CvArr v)
        {
            Cv.SVD(this, w, u, v);
        }

        public void SVD(CvArr w, CvArr u, CvArr v, SVDFlag flags)
        {
            Cv.SVD(this, w, u, v, flags);
        }

        public void Threshold(CvArr dst, double threshold, double maxValue, ThresholdType thresholdType)
        {
            Cv.Threshold(this, dst, threshold, maxValue, thresholdType);
        }

        public CvScalar Trace()
        {
            return Cv.Trace(this);
        }

        public void Transpose(CvArr dst)
        {
            Cv.Transpose(this, dst);
        }

        public void T(CvArr dst)
        {
            Cv.T(this, dst);
        }

        public void Undistort2(CvArr dst, CvMat intrinsicMatrix, CvMat distortionCoeffs)
        {
            Cv.Undistort2(this, dst, intrinsicMatrix, distortionCoeffs);
        }

        public void Undistort2(CvArr dst, CvMat intrinsicMatrix, CvMat distortionCoeffs, CvMat newCameraMatrix)
        {
            Cv.Undistort2(this, dst, intrinsicMatrix, distortionCoeffs, newCameraMatrix);
        }

        public void ValidateDisparity(CvArr cost, int minDisparity, int numberOfDisparities)
        {
            Cv.ValidateDisparity(this, cost, minDisparity, numberOfDisparities);
        }

        public void ValidateDisparity(CvArr cost, int minDisparity, int numberOfDisparities, int disp12MaxDiff)
        {
            Cv.ValidateDisparity(this, cost, minDisparity, numberOfDisparities, disp12MaxDiff);
        }

        public void WarpPerspective(CvArr dst, CvMat mapMatrix)
        {
            Cv.WarpPerspective(this, dst, mapMatrix);
        }

        public void WarpPerspective(CvArr dst, CvMat mapMatrix, Interpolation flags)
        {
            Cv.WarpPerspective(this, dst, mapMatrix, flags);
        }

        public void WarpPerspective(CvArr dst, CvMat mapMatrix, Interpolation flags, CvScalar fillval)
        {
            Cv.WarpPerspective(this, dst, mapMatrix, flags, fillval);
        }

        public void Watershed(CvArr markers)
        {
            Cv.Watershed(this, markers);
        }

        public void Xor(CvArr src2, CvArr dst)
        {
            Cv.Xor(this, src2, dst);
        }

        public void Xor(CvArr src2, CvArr dst, CvArr mask)
        {
            Cv.Xor(this, src2, dst, mask);
        }

        public void XorS(CvScalar value, CvArr dst)
        {
            Cv.XorS(this, value, dst);
        }

        public void XorS(CvScalar value, CvArr dst, CvArr mask)
        {
            Cv.XorS(this, value, dst, mask);
        }

        internal CvArr()
        {
        }

        internal CvArr(bool isEnabledDispose)
            : base(isEnabledDispose)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public CvLineSegmentPolar[] HoughLinesStandard(double rho, double theta, int threshold)
        {
            return HoughLinesStandard(rho, theta, threshold, 0.0, 0.0);
        }

        public CvLineSegmentPolar[] HoughLinesStandard(double rho, double theta, int threshold, double param1, double param2)
        {
            using (CvMemStorage cvMemStorage = new CvMemStorage())
            {
                IntPtr intPtr = NativeMethods.cvHoughLines2(base.CvPtr, cvMemStorage.CvPtr, HoughLinesMethod.Standard, rho, theta, threshold, param1, param2);
                if (intPtr == IntPtr.Zero)
                {
                    throw new OpenCvSharpException();
                }
                return new CvSeq<CvLineSegmentPolar>(intPtr).ToArray();
            }
        }

        public CvLineSegmentPoint[] HoughLinesProbabilistic(double rho, double theta, int threshold)
        {
            return HoughLinesProbabilistic(rho, theta, threshold, 0.0, 0.0);
        }

        public CvLineSegmentPoint[] HoughLinesProbabilistic(double rho, double theta, int threshold, double param1, double param2)
        {
            using (CvMemStorage cvMemStorage = new CvMemStorage())
            {
                IntPtr intPtr = NativeMethods.cvHoughLines2(base.CvPtr, cvMemStorage.CvPtr, HoughLinesMethod.Probabilistic, rho, theta, threshold, param1, param2);
                if (intPtr == IntPtr.Zero)
                {
                    throw new OpenCvSharpException();
                }
                return new CvSeq<CvLineSegmentPoint>(intPtr).ToArray();
            }
        }

        public void Merge(CvArr src0, CvArr src1, CvArr src2, CvArr src3)
        {
            Cv.Merge(src0, src1, src2, src3, this);
        }

        public void CvtPlaneToPix(CvArr src0, CvArr src1, CvArr src2, CvArr src3)
        {
            Cv.CvtPlaneToPix(src0, src1, src2, src3, this);
        }

        public void RandArr(CvRNG rng, DistributionType distType, CvScalar param1, CvScalar param2)
        {
            Cv.RandArr(rng, this, distType, param1, param2);
        }

        public int SaveImage(string filename)
        {
            return Cv.SaveImage(filename, this);
        }

        public int SaveImage(string fileName, int[] prms)
        {
            return Cv.SaveImage(fileName, this, prms);
        }

        public int SaveImage(string fileName, params ImageEncodingParam[] prms)
        {
            return Cv.SaveImage(fileName, this, prms);
        }

        public byte[] ToBytes(string ext, params ImageEncodingParam[] encodingParams)
        {
            using (CvMat cvMat = Cv.EncodeImage(ext, this, encodingParams))
            {
                byte[] array = new byte[cvMat.Rows * cvMat.Cols];
                Marshal.Copy(cvMat.Data, array, 0, array.Length);
                return array;
            }
        }

        public void ToStream(Stream outStream, string ext, params ImageEncodingParam[] encodingParams)
        {
            if (outStream == null)
            {
                throw new ArgumentNullException("outStream");
            }
            byte[] array = ToBytes(ext, encodingParams);
            outStream.Write(array, 0, array.Length);
        }

        public void DrawMarker(int x, int y, CvScalar color)
        {
            DrawMarker(x, y, color, MarkerStyle.Cross, 10, LineType.Link8, 1);
        }

        public void DrawMarker(int x, int y, CvScalar color, MarkerStyle style)
        {
            DrawMarker(x, y, color, style, 10, LineType.Link8, 1);
        }

        public void DrawMarker(int x, int y, CvScalar color, MarkerStyle style, int size)
        {
            DrawMarker(x, y, color, style, size, LineType.Link8, 1);
        }

        public void DrawMarker(int x, int y, CvScalar color, MarkerStyle style, int size, LineType lineType)
        {
            DrawMarker(x, y, color, style, size, LineType.Link8, 1);
        }

        public void DrawMarker(int x, int y, CvScalar color, MarkerStyle style, int size, LineType lineType, int thickness)
        {
            int num = size / 2;
            switch (style)
            {
                case MarkerStyle.CircleLine:
                    Circle(x, y, num, color, thickness, lineType);
                    break;
                case MarkerStyle.CircleFilled:
                    Circle(x, y, num, color, -1, lineType);
                    break;
                case MarkerStyle.Cross:
                    Line(x, y - num, x, y + num, color, thickness, lineType);
                    Line(x - num, y, x + num, y, color, thickness, lineType);
                    break;
                case MarkerStyle.TiltedCross:
                    Line(x - num, y - num, x + num, y + num, color, thickness, lineType);
                    Line(x + num, y - num, x - num, y + num, color, thickness, lineType);
                    break;
                case MarkerStyle.CircleAndCross:
                    Circle(x, y, num, color, thickness, lineType);
                    Line(x, y - num, x, y + num, color, thickness, lineType);
                    Line(x - num, y, x + num, y, color, thickness, lineType);
                    break;
                case MarkerStyle.CircleAndTiltedCross:
                    Circle(x, y, num, color, thickness, lineType);
                    Line(x - num, y - num, x + num, y + num, color, thickness, lineType);
                    Line(x + num, y - num, x - num, y + num, color, thickness, lineType);
                    break;
                case MarkerStyle.DiamondLine:
                case MarkerStyle.DiamondFilled:
                    {
                        int num2 = (int)((double)size * Math.Sqrt(2.0) / 2.0);
                        CvPoint[] array2 = new CvPoint[4]
				{
					new CvPoint(x, y - num2),
					new CvPoint(x + num2, y),
					new CvPoint(x, y + num2),
					new CvPoint(x - num2, y)
				};
                        switch (style)
                        {
                            case MarkerStyle.DiamondLine:
                                var point = new CvPoint[1][]
                    {
                        array2
                    };

                                PolyLine(point, true, color, thickness, lineType);
                                break;
                            case MarkerStyle.DiamondFilled:
                                FillConvexPoly(array2, color, lineType);
                                break;
                        }
                        break;
                    }
                case MarkerStyle.SquareLine:
                case MarkerStyle.SquareFilled:
                    {
                        CvPoint[] array = new CvPoint[4]
				{
					new CvPoint(x - num, y - num),
					new CvPoint(x + num, y - num),
					new CvPoint(x + num, y + num),
					new CvPoint(x - num, y + num)
				};
                        switch (style)
                        {
                            case MarkerStyle.SquareLine:
                                PolyLine(new CvPoint[1][]
					{
						array
					}, true, color, thickness, lineType);
                                break;
                            case MarkerStyle.SquareFilled:
                                FillConvexPoly(array, color, lineType);
                                break;
                        }
                        break;
                    }
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
