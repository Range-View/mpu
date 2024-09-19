namespace Entities.Util
{
    public static class MatrixUtil
    {
        public static (int, int)[] Directions =
        {
            (-1, 0),  // Up: Move one row up (decrease row by 1), same column
            (1, 0),   // Down: Move one row down (increase row by 1), same column
            (0, -1),  // Left: Move one column left (decrease column by 1), same row
            (0, 1)    // Right: Move one column right (increase column by 1), same row
        };
    }
}
