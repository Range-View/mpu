using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Frame
{
    public class FrameMetadata
    {
        public DateTime Timestamp { get; set; }
        public string FrameId { get; set; }

        public FrameMetadata()
        {
            Timestamp = DateTime.Now;
            FrameId = Guid.NewGuid().ToString();
        }
    }
}
