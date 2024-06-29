using System.Threading;
using Avalonia;
using Avalonia.ReactiveUI;
using UI;
using Managers.Services;

namespace Managers
{
    public class ApplicationManager
    {
        private UIManager uiManager;

        public ApplicationManager(string[] appArgs)
        {
            Initialize(appArgs);
        }

        private void Initialize(string[] appArgs)
        {
            IOService.Initialize();

            uiManager = new UIManager();
            uiManager.Initialize(appArgs);
        }

        public void Run()
        {
            bool shouldRender = true; // Replace later with actual stopping condition
            while (shouldRender)
            {
                string sensorData = IOService.ReadSensorData(0);
                Console.WriteLine($"Sensor Data: {sensorData}");

                uiManager.Update();
                Thread.Sleep(33); //30 FPS
            }
        }

        public void Shutdown()
        {
            //uiManager.Shutdown();
        }
    }
}
