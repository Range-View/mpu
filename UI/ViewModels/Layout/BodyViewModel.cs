using DynamicData;
using Entities.Frame;
using ReactiveUI;
using System.Collections.ObjectModel;
using UI.ViewModels.Components.Chart;

namespace UI.ViewModels.Layout
{
    public class BodyViewModel : ViewModelBase
    {
        private CurrentFrame currentFrame;

        public PeakChartViewModel PeakChartViewModel { get; private set; }

        public CurrentFrame CurrentFrame
        {
            get => currentFrame;
            set
            {
                currentFrame = value;
                this.RaisePropertyChanged(nameof(CurrentFrame));
                this.RaisePropertyChanged(nameof(Rows));
                this.RaisePropertyChanged(nameof(Cols));
                this.RaisePropertyChanged(nameof(MaxValue));
                this.RaisePropertyChanged(nameof(MinValue));
                UpdateDetectedObjects();
            }
        }

        public BodyViewModel()
        {
            PeakChartViewModel = new PeakChartViewModel();
        }

        public BodyViewModel(CurrentFrame currentFrame)
        {
            CurrentFrame = currentFrame;
            PeakChartViewModel = new PeakChartViewModel();
            UpdateDetectedObjects();
        }

        public int Rows => CurrentFrame?.Range?.Rows ?? 0;
        public int Cols => CurrentFrame?.Range?.Cols ?? 0;
        public float MaxValue => CurrentFrame?.Range?.DepthMatrix.Cast<float>().Max() ?? 0;
        public float MinValue => CurrentFrame?.Range?.DepthMatrix.Cast<float>().Min() ?? 0;

        public void UpdateDetectedObjects()
        {
            if (PeakChartViewModel != null)
            {
                PeakChartViewModel.UpdateSeries(CurrentFrame);
            }

        }
    }
}
