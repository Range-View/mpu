namespace Entities.Frame
{
    public class FrameInsights
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }
        public List<ObjectInsight> DetectedObjects { get; set; }

        public FrameInsights()
        {
            DetectedObjects = new List<ObjectInsight>();
        }
    }



    public class ObjectInsight
    {
        public (int MinRow, int MinCol, int MaxRow, int MaxCol) BoundingBox { get; set; }
        public float AverageDistance { get; set; }
        public List<(int Row, int Col)> Points { get; set; }
        public List<Coordinate> NormalizedPoints { get; set; }
        public List<(int Row, int Col)> EdgePoints { get; set; }

        public ObjectInsight()
        {
            Points = new List<(int Row, int Col)>();
            NormalizedPoints = new List<Coordinate>();
            EdgePoints = new List<(int Row, int Col)>();
        }
    }

    public struct Coordinate
    {
        public Coordinate(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; set; }
        public float Y { get; set; }
    }

}
