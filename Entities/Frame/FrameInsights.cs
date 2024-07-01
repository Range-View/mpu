using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Frame
{
    public class FrameInsights
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }
        public List<(int Row, int Col)> PeakPositions { get; set; }
    }
}
