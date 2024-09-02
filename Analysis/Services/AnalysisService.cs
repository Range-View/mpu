using Analysis.Algorithms;
using Entities.Frame;
using Entities.Range;

namespace Analysis.Services
{
    public class AnalysisService
    {
        public FrameInsights AnalyzeRangeData(RangeData rangeData)
        {
            FrameInsights insights = new();

            float maxValue = float.MinValue;
            float minValue = float.MaxValue;
            List<ObjectInsight> detectedObjects = new();

            bool[,] visited = new bool[rangeData.Rows, rangeData.Cols];
            for (int i = 0; i < rangeData.Rows; i++)
            {
                for (int j = 0; j < rangeData.Cols; j++)
                {
                    if (!visited[i, j] && rangeData.DepthMatrix[i, j] > 0)
                    {
                        ObjectInsight obj = ObjectDetection.DetectObject(rangeData, visited, i, j);
                        detectedObjects.Add(obj);
                    }
                }
            }

            foreach (ObjectInsight obj in detectedObjects)
            {
                if (obj.AverageDistance > maxValue)
                {
                    maxValue = obj.AverageDistance;
                }
                if (obj.AverageDistance < minValue)
                {
                    minValue = obj.AverageDistance;
                }

            }

            insights.MaxValue = maxValue;
            insights.MinValue = minValue;
            insights.DetectedObjects = detectedObjects;

            return insights;
        }
    }
}
