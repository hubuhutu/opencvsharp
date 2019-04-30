#pragma once
#ifndef __IMGPROC_CONN__
#define __IMGPROC_CONN__

#include <opencv2\opencv.hpp>
#include <opencv2\imgproc\imgproc.hpp>


using namespace cv;

//! connected components algorithm output formats
enum ConnectedComponentsTypes {
	CC_STAT_LEFT = 0, //!< The leftmost (x) coordinate which is the inclusive start of the bounding
					  //!< box in the horizontal direction.
					  CC_STAT_TOP = 1, //!< The topmost (y) coordinate which is the inclusive start of the bounding
									   //!< box in the vertical direction.
									   CC_STAT_WIDTH = 2, //!< The horizontal size of the bounding box
									   CC_STAT_HEIGHT = 3, //!< The vertical size of the bounding box
									   CC_STAT_AREA = 4, //!< The total area (in pixels) of the connected component
									   CC_STAT_MAX = 5
};

//! connected components algorithm
enum ConnectedComponentsAlgorithmsTypes {
	CCL_WU = 0,  //!< SAUF algorithm for 8-way connectivity, SAUF algorithm for 4-way connectivity
	CCL_DEFAULT = -1, //!< BBDT algorithm for 8-way connectivity, SAUF algorithm for 4-way connectivity
	CCL_GRANA = 1   //!< BBDT algorithm for 8-way connectivity, SAUF algorithm for 4-way connectivity
};



int connectedComponents(InputArray img_ , OutputArray _labels , int connectivity, int ltype);
int connectedComponents(InputArray img_ , OutputArray _labels , int connectivity, int ltype, int ccltype);

int connectedComponentsWithStats(InputArray img_ , OutputArray _labels , OutputArray statsv ,
	OutputArray centroids, int connectivity, int ltype);

int connectedComponentsWithStats(InputArray img_ , OutputArray _labels , OutputArray statsv ,
	OutputArray centroids, int connectivity, int ltype, int ccltype);

#endif