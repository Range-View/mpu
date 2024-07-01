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
        private ObservableCollection<Tuple<int, int>> peakPositions;

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
                this.RaisePropertyChanged(nameof(PeakPositions));
                UpdatePeakPositions();
            }
        }

        public BodyViewModel()
        {
            PeakPositions = new ObservableCollection<Tuple<int, int>>();
            PeakChartViewModel = new PeakChartViewModel();
        }

        public BodyViewModel(CurrentFrame currentFrame)
        {
            CurrentFrame = currentFrame;
            PeakPositions = new ObservableCollection<Tuple<int, int>>();
            PeakChartViewModel = new PeakChartViewModel();
            UpdatePeakPositions();
        }

        public int Rows => CurrentFrame?.Range?.Rows ?? 0;
        public int Cols => CurrentFrame?.Range?.Cols ?? 0;
        public float MaxValue => CurrentFrame?.Range?.DepthMatrix.Cast<float>().Max() ?? 0;
        public float MinValue => CurrentFrame?.Range?.DepthMatrix.Cast<float>().Min() ?? 0;
        public ObservableCollection<Tuple<int, int>> PeakPositions
        {
            get => peakPositions;
            set
            {
                peakPositions = value;
                this.RaisePropertyChanged(nameof(PeakPositions));
                PeakChartViewModel?.UpdateSeries(PeakPositions); 
            }
        }

        private void UpdatePeakPositions()
        {
            if (PeakPositions is null) return;
            PeakPositions.Clear();
            foreach (var peak in CurrentFrame?.Insights?.PeakPositions)
            {
                PeakPositions.Add(new Tuple<int, int>(peak.Row, peak.Col));
            }
            PeakChartViewModel?.UpdateSeries(PeakPositions); 
        }
    }
}
