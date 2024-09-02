using System.Text;

namespace Entities.Range
{

    public class RangeData
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public float[,] DepthMatrix { get; set; }

        public RangeData()
        {
            DepthMatrix = new float[0, 0];
        }

        public void InitializeMatrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            DepthMatrix = new float[rows, cols];
        }

        public void SetValue(int row, int col, float value)
        {
            if (row < Rows && col < Cols)
            {
                DepthMatrix[row, col] = value;
            }
        }
    }

}
