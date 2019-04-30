#include "utility_ext.h"

class ParallelLoopBodyLambdaWrapper : public ParallelLoopBody
{
private:
	std::function<void(const Range&)> m_functor;
public:
	ParallelLoopBodyLambdaWrapper(std::function<void(const Range&)> functor) :
		m_functor(functor)
	{ }

	virtual void operator() (const cv::Range& range) const CV_OVERRIDE
	{
		m_functor(range);
	}
};

inline void parallel_for_(const Range& range, std::function<void(const Range&)> functor, double nstripes )
{
	cv::parallel_for_(range, ParallelLoopBodyLambdaWrapper(functor), nstripes);
}