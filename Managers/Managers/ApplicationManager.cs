using Managers.Services;
using System.Runtime.InteropServices;

namespace Managers
{
    public class ApplicationManager
    {
        private UIManager uiManager;

        public ApplicationManager()
        {
            Initialize();
        }

        private void Initialize()
        {
            IOService.Initialize();
            uiManager = new UIManager();
            //uiManager.Initialize();
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
