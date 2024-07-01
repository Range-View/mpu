using Avalonia.Controls;
using Entities.Frame;
using UI.ViewModels;
using UI.Views.Layout;

namespace UI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(CurrentFrame currentFrame)
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(currentFrame);

            var bodyView = new BodyView(currentFrame);
            this.FindControl<Grid>("MainGrid").Children.Add(bodyView);
            Grid.SetRow(bodyView, 1);
        }
    }
}
