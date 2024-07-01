using Entities.Frame;
using Entities.Range;

namespace Analysis.Services
{
    public class AnalysisService
    {
        public FrameInsights AnalyzeRangeData(RangeData rangeData)
        {
            var insights = new FrameInsights();

            float maxValue = float.MinValue;
            float minValue = float.MaxValue;
            var peakPositions = new List<(int, int)>();

            for (int i = 0; i < rangeData.Rows; i++)
            {
                for (int j = 0; j < rangeData.Cols; j++)
                {
                    float value = rangeData.DepthMatrix[i, j];
                    if (value > maxValue)
                    {
                        maxValue = value;
                        peakPositions.Clear();
                        peakPositions.Add((i, j));
                    }
                    else if (value == maxValue)
                    {
                        peakPositions.Add((i, j));
                    }

                    if (value < minValue)
                    {
                        minValue = value;
                    }
                }
            }

            insights.MaxValue = maxValue;
            insights.MinValue = minValue;
            insights.PeakPositions = peakPositions;


            return insights;
        }
    }
}
