using Avalonia;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Entities.Frame;
using Managers;
using Managers.Services;
using Entities.Enums;
using Entities.Range;
using Entities.Util;
using Analysis.Services;

namespace MPU.Bootstrap
{
    public static class AppInitializer
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection()
                .AddSingleton<CurrentFrame>()
                .AddSingleton<UIManager>()
                .AddSingleton<AnalysisService>();

            var serviceProvider = services.BuildServiceProvider();
            ServiceLocator.Initialize(serviceProvider);
            return serviceProvider;
        }

        public static AppBuilder BuildAvaloniaApp(IServiceProvider serviceProvider)
            => AppBuilder.Configure<UI.App>()
                         .UsePlatformDetect()
                         .LogToTrace()
                         .UseReactiveUI();

        public static async Task RunApplication(ServiceProvider serviceProvider, string[] args)
        {
            var currentFrame = serviceProvider.GetService<CurrentFrame>();
            var uiManager = serviceProvider.GetService<UIManager>();

            IOService.Initialize();

            var uiTask = Task.Run(() => BuildAvaloniaApp(serviceProvider).StartWithClassicDesktopLifetime(args));
            var mainLoopTask = Task.Run(() => MainLoop(uiManager, currentFrame));

            await Task.WhenAll(uiTask, mainLoopTask);
        }

        private static void MainLoop(UIManager uiManager, CurrentFrame currentFrame)
        {
            var analysisService = ServiceLocator.Instance.GetRequiredService<AnalysisService>();

            bool shouldRender = true;
            while (shouldRender)
            {
                RangeData rangeData = IOService.ReadSensorBinary(SensorTypes.Range);
                currentFrame.Range = rangeData;
                currentFrame.Insights = analysisService.AnalyzeRangeData(rangeData);
                uiManager.Update();
                Thread.Sleep(33); //~30 FPS
            }
        }
    }
}
