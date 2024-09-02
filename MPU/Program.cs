using Avalonia;
using MPU.Bootstrap;
using System.Threading.Tasks;

namespace MPU
{
    class Program
    {
        [STAThread]
        static async Task Main(string[] args)
        {
            var serviceProvider = AppInitializer.ConfigureServices();
            await AppInitializer.RunApplication(serviceProvider, args);
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppInitializer.BuildAvaloniaApp(AppInitializer.ConfigureServices());
    }
}
