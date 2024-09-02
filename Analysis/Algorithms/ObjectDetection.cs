using Entities.Frame;
using Entities.Range;
namespace Analysis.Algorithms;
public static class ObjectDetection
{
    public static ObjectInsight DetectObject(RangeData rangeData, bool[,] visited, int startRow, int startCol)
    {
        var points = new List<(int Row, int Col)>();
        var queue = new Queue<(int Row, int Col)>();
        var pointDepths = new Dictionary<(int Row, int Col), float>();
        queue.Enqueue((startRow, startCol));
        visited[startRow, startCol] = true;

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

            var directions = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            foreach (var (dr, dc) in directions)
            {
                int newRow = row + dr;
                int newCol = col + dc;
                if (newRow >= 0 && newRow < rangeData.Rows && newCol >= 0 && newCol < rangeData.Cols &&
                    !visited[newRow, newCol] && rangeData.DepthMatrix[newRow, newCol] > 0)
                {
                    visited[newRow, newCol] = true;
                    queue.Enqueue((newRow, newCol));
                }
            }
        }

        var boundingBox = (
            points.Min(p => p.Row),
            points.Min(p => p.Col),
            points.Max(p => p.Row),
            points.Max(p => p.Col)
        );

        var uniquePoints = points
            .GroupBy(p => p.Col)
            .Select(g => new Coordinate((float)g.Key, pointDepths[g.First()])) 
            .ToList();

        return new ObjectInsight
        {
            Points = points,
            NormalizedPoints = uniquePoints,
            AverageDistance = totalDistance / count,
            BoundingBox = boundingBox
        };
    }
}
