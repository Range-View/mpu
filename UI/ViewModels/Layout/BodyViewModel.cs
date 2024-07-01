using System;
using System.Collections.ObjectModel;
using System.Linq;
using Entities.Frame;
using ReactiveUI;

namespace UI.ViewModels.Layout
{
    public class BodyViewModel : ViewModelBase
    {
        private CurrentFrame currentFrame;
        private ObservableCollection<Tuple<int, int>> peakPositions;

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
            }
        }

        public BodyViewModel()
        {
            PeakPositions = new ObservableCollection<Tuple<int, int>>();
        }

        public BodyViewModel(CurrentFrame currentFrame)
        {
            CurrentFrame = currentFrame;
            PeakPositions = new ObservableCollection<Tuple<int, int>>();
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
            }
        }
    }
}
