using Entities.Frame;
using UI.ViewModels.Layout;

namespace UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia! ";
        public BodyViewModel BodyViewModel { get; }

        public MainWindowViewModel()
        {
            // Default constructor for design-time support
        }

        public MainWindowViewModel(CurrentFrame currentFrame)
        {
            BodyViewModel = new BodyViewModel(currentFrame);
        }
    }
}
