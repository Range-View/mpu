using Entities.Frame;
using ReactiveUI;

namespace UI.ViewModels.Layout
{
    public class BodyViewModel : ViewModelBase
    {
        private CurrentFrame currentFrame;

        public CurrentFrame CurrentFrame
        {
            get => currentFrame;
            set
            {
                currentFrame = value;
                this.RaisePropertyChanged(nameof(CurrentFrame));
                this.RaisePropertyChanged(nameof(Rows));
                this.RaisePropertyChanged(nameof(Cols));
            }
        }

        public BodyViewModel()
        {
            // Default constructor for Avalonia XAML instantiation
        }

        public BodyViewModel(CurrentFrame currentFrame)
        {
            CurrentFrame = currentFrame;
        }

        public int Rows => CurrentFrame?.Range?.Rows ?? 0;
        public int Cols => CurrentFrame?.Range?.Cols ?? 0;
    }
}
