using Entities.Frame;
using Entities.Range;
using Entities.Util;
namespace Analysis.Algorithms;
public static class ObjectDetection
{
    public static ObjectInsight DetectObject(RangeData rangeData, bool[,] visited, int startRow, int startCol, float depthThreshold)
    {
        var points = new List<(int Row, int Col)>();
        var queue = new Queue<(int Row, int Col)>();
        var pointDepths = new Dictionary<(int Row, int Col), float>();

        if (rangeData.DepthMatrix[startRow, startCol] > depthThreshold)
        {
            queue.Enqueue((startRow, startCol));
            visited[startRow, startCol] = true;
        }

        float totalDistance = 0;
        int count = 0;

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();
            points.Add((row, col));
            float value = rangeData.DepthMatrix[row, col];
            pointDepths[(row, col)] = value;
            totalDistance += value;
            count++;

            foreach (var (dr, dc) in MatrixUtil.Directions)
            {
                int newRow = row + dr;
                int newCol = col + dc;

                if (newRow >= 0 && newRow < rangeData.Rows &&
                    newCol >= 0 && newCol < rangeData.Cols &&
                    !visited[newRow, newCol] &&
                    rangeData.DepthMatrix[newRow, newCol] > depthThreshold)
                {
                    visited[newRow, newCol] = true;
                    queue.Enqueue((newRow, newCol));
                }
            }
        }

  
        var edgePoints = points.Where(p => IsEdgePoint(rangeData, p.Row, p.Col, depthThreshold)).ToList();

        var boundingBox = (
            points.Min(p => p.Row),
            points.Min(p => p.Col),
            points.Max(p => p.Row),
            points.Max(p => p.Col)
        );

        var normalizedEdgePoints = edgePoints
            .GroupBy(p => p.Col)
            .Select(g => new Coordinate((float)g.Key, pointDepths[g.First()]))
            .ToList();


        //var uniquePoints = points
        //    .GroupBy(p => p.Col)
        //    .Select(g => new Coordinate((float)g.Key, pointDepths[g.First()]))
        //    .ToList();

        return new ObjectInsight
        {
            Points = points,
            NormalizedPoints = normalizedEdgePoints,  
            AverageDistance = totalDistance / count,
            BoundingBox = boundingBox,
            EdgePoints = edgePoints 
        };
    }





    public static bool IsEdgePoint(RangeData rangeData, int row, int col, float depthThreshold)
    {

        foreach (var (dr, dc) in MatrixUtil.Directions)
        {
            int newRow = row + dr;
            int newCol = col + dc;

            // Check if the neighboring point is outside bounds or below the threshold
            if (newRow < 0 || newRow >= rangeData.Rows ||
                newCol < 0 || newCol >= rangeData.Cols ||
                rangeData.DepthMatrix[newRow, newCol] < depthThreshold)
            {
                return true;  // edge point
            }
        }

        return false;  // not edge point
    }

}
