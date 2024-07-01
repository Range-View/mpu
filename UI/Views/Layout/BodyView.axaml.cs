using Avalonia.Controls;
using Entities.Frame;
using UI.ViewModels.Layout;

namespace UI.Views.Layout
{
    public partial class BodyView : UserControl
    {
        public BodyView()
        {
            InitializeComponent();
        }

        public BodyView(CurrentFrame currentFrame)
        {
            InitializeComponent();
            DataContext = new BodyViewModel(currentFrame);
        }
    }
}
