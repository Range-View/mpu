using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using UI.ViewModels;
using UI.Views;
using Entities.Frame;
using Entities.Util;

namespace UI
{
    public partial class App : Application
    {
        public App() { }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var serviceProvider = ServiceLocator.Instance;
                var currentFrame = serviceProvider.GetRequiredService<CurrentFrame>();
                desktop.MainWindow = new MainWindow(currentFrame)
                {
                    DataContext = new MainWindowViewModel(currentFrame),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
