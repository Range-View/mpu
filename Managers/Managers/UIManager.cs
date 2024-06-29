using Avalonia;
using Avalonia.ReactiveUI;
using UI;

namespace Managers
{
    public class UIManager
    {
        public void Initialize(string[] appArgs)
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(appArgs);
        }

        public void Update()
        {
            // Update logic
        }

        public void Shutdown()
        {
            // Shutdown logic
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                         .UsePlatformDetect()
                         .LogToTrace()
                         .UseReactiveUI();
    }
}
