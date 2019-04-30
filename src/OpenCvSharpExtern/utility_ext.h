#pragma once
#ifndef __UTILITY_EXT__
#define __UTILITY_EXT__

#include <opencv2\opencv.hpp>
#include <opencv2\core\internal.hpp>

#include <functional>

#define CV_OVERRIDE override

using namespace cv;

inline void parallel_for_(const Range& range, std::function<void(const Range&)> functor, double nstripes = -1.);

#endif