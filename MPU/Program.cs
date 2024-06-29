using Avalonia;
using Avalonia.ReactiveUI;
using Managers;
using Managers.Services;

namespace MPU
{
    class Program
    {
        [STAThread]
        static async Task Main(string[] args)
        {
            // Init services and managers
            IOService.Initialize();
            UIManager uiManager = new UIManager();

            // Run UI in one thread
            var uiTask = Task.Run(() => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args));

            // Run main application loop in a different thread
            var mainLoopTask = Task.Run(() => MainLoop(uiManager));

            await Task.WhenAll(uiTask, mainLoopTask);
        }

        public static void MainLoop(UIManager uiManager)
        {
            bool shouldRender = true; // Replace later with actual stopping condition
            while (shouldRender)
            {
                string sensorData = IOService.ReadSensorData(0);
                Console.WriteLine($"Sensor Data: {sensorData}");

                uiManager.Update();
                Thread.Sleep(33); //~30 FPS
            }
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<UI.App>()
                         .UsePlatformDetect()
                         .LogToTrace()
                         .UseReactiveUI();
    }
}
