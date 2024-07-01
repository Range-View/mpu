using Entities.Range;

namespace Entities.Frame
{
    public class CurrentFrame
    {
        public RangeData Range { get; set; }
        public FrameMetadata Metadata { get; set; }

        public CurrentFrame()
        {
            Range = new RangeData();
            Metadata = new FrameMetadata();
        }
    }

  
}
