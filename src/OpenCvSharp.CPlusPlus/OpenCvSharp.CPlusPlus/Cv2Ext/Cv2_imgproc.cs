using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
	static partial class Cv2
	{
        #region ConnectedComponents

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="image">the image to be labeled</param>
        /// <param name="labels">destination labeled image</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <returns>The number of labels</returns>
        public static int ConnectedComponents(InputArray image, OutputArray labels,
            PixelConnectivity connectivity = PixelConnectivity.Connectivity8)
        {
            return ConnectedComponents(image, labels, connectivity, MatType.CV_32S);
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="image">the image to be labeled</param>
        /// <param name="labels">destination labeled image</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <param name="ltype">output image label type. Currently CV_32S and CV_16U are supported.</param>
        /// <returns>The number of labels</returns>
        public static int ConnectedComponents(InputArray image, OutputArray labels,
            PixelConnectivity connectivity, MatType ltype)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (labels == null)
                throw new ArgumentNullException("labels");
            image.ThrowIfDisposed();
            labels.ThrowIfNotReady();

            int result = NativeMethods.imgproc_connectedComponents(
                image.CvPtr, labels.CvPtr, (int)connectivity, ltype);

            GC.KeepAlive(image);
            GC.KeepAlive(labels);
            labels.Fix();
            return result;
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="image">the image to be labeled</param>
        /// <param name="labels">destination labeled rectangular array</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <returns>The number of labels</returns>
        public static int ConnectedComponents(InputArray image, out int[,] labels, PixelConnectivity connectivity)
        {
            using (var labelsMat = new MatOfInt())
            {
                int result = ConnectedComponents(image, labelsMat, connectivity, MatType.CV_32S);
                labels = labelsMat.ToRectangularArray();
                return result;
            }
        }

        #endregion
        #region ConnectedComponentsWithStats

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="image">the image to be labeled</param>
        /// <param name="labels">destination labeled image</param>
        /// <param name="stats">statistics output for each label, including the background label, 
        /// see below for available statistics. Statistics are accessed via stats(label, COLUMN) 
        /// where COLUMN is one of cv::ConnectedComponentsTypes</param>
        /// <param name="centroids">floating point centroid (x,y) output for each label, 
        /// including the background label</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <returns></returns>
        public static int ConnectedComponentsWithStats(
            InputArray image, OutputArray labels,
            OutputArray stats, OutputArray centroids,
            PixelConnectivity connectivity = PixelConnectivity.Connectivity8)
        {
            return ConnectedComponentsWithStats(image, labels, stats, centroids, connectivity, MatType.CV_32S);
        }

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="image">the image to be labeled</param>
        /// <param name="labels">destination labeled image</param>
        /// <param name="stats">statistics output for each label, including the background label, 
        /// see below for available statistics. Statistics are accessed via stats(label, COLUMN) 
        /// where COLUMN is one of cv::ConnectedComponentsTypes</param>
        /// <param name="centroids">floating point centroid (x,y) output for each label, 
        /// including the background label</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <param name="ltype">output image label type. Currently CV_32S and CV_16U are supported.</param>
        /// <returns></returns>
        public static int ConnectedComponentsWithStats(
            InputArray image, OutputArray labels,
            OutputArray stats, OutputArray centroids,
            PixelConnectivity connectivity,
            MatType ltype)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (labels == null)
                throw new ArgumentNullException("labels");
            if (stats == null)
                throw new ArgumentNullException("stats");
            if (centroids == null)
                throw new ArgumentNullException("centroids");
            image.ThrowIfDisposed();
            labels.ThrowIfNotReady();
            stats.ThrowIfNotReady();
            centroids.ThrowIfNotReady();

            int result = NativeMethods.imgproc_connectedComponentsWithStats(
                image.CvPtr, labels.CvPtr, stats.CvPtr, centroids.CvPtr, (int)connectivity, ltype);

            GC.KeepAlive(image);
            GC.KeepAlive(labels);
            GC.KeepAlive(stats);
            GC.KeepAlive(centroids);
            labels.Fix();
            stats.Fix();
            centroids.Fix();
            return result;
        }

        #endregion
        #region ConnectedComponentsEx

        /// <summary>
        /// computes the connected components labeled image of boolean image. 
        /// image with 4 or 8 way connectivity - returns N, the total number of labels [0, N-1] where 0 
        /// represents the background label. ltype specifies the output label image type, an important 
        /// consideration based on the total number of labels or alternatively the total number of 
        /// pixels in the source image.
        /// </summary>
        /// <param name="image">the image to be labeled</param>
        /// <param name="connectivity">8 or 4 for 8-way or 4-way connectivity respectively</param>
        /// <returns></returns>
        public static ConnectedComponents ConnectedComponentsEx(
            InputArray image, PixelConnectivity connectivity = PixelConnectivity.Connectivity8)
        {
            using (var labelsMat = new MatOfInt())
            using (var statsMat = new MatOfInt())
            using (var centroidsMat = new MatOfDouble())
            {
                int nLabels = ConnectedComponentsWithStats(
                    image, labelsMat, statsMat, centroidsMat, connectivity, MatType.CV_32S);
                var labels = labelsMat.ToRectangularArray();
                var stats = statsMat.ToRectangularArray();
                var centroids = centroidsMat.ToRectangularArray();

                var blobs = new ConnectedComponents.Blob[nLabels];
                for (int i = 0; i < nLabels; i++)
                {
                    blobs[i] = new ConnectedComponents.Blob
                    {
                        Label = i,
                        Left = stats[i, 0],
                        Top = stats[i, 1],
                        Width = stats[i, 2],
                        Height = stats[i, 3],
                        Area = stats[i, 4],
                        Centroid = new Point2d(centroids[i, 0], centroids[i, 1]),
                    };
                }
                return new ConnectedComponents(blobs, labels, nLabels);
            }
        }

        #endregion
	}
}
