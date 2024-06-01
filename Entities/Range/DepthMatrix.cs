using System.Text;

namespace Entities.Range
{
    public class RangeMatrix
    {
        private readonly float[,] matrix;
        private readonly int rows, cols;

        public RangeMatrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new float[rows, cols];
        }


        public float GetValue(int row, int col)
        {
            if (row < rows && col < cols)
            {
                return matrix[row, col];
            }
            return -1; // Out of bounds
        }

      
      
        public int Rows => rows;
        public int Cols => cols;

        public static RangeMatrix FromString(string rawData, int rows, int cols)
        {
            RangeMatrix matrix = new RangeMatrix(rows, cols);
            string[] data = rawData.Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (index < data.Length)
                    {
                        matrix.SetValue(i, j, float.Parse(data[index]));
                        index++;
                    }
                }
            }

            return matrix;
        }


        private void SetValue(int row, int col, float value)
        {
            if (row < rows && col < cols)
            {
                matrix[row, col] = value;
            }
        }
    }
}
