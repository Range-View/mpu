using System.Runtime.InteropServices;

namespace Managers.Services
{
    public class IOService
    {
        private const string DllName = "YourCppLibrary.dll";

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void initialize();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void shutdown();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr readSensorData(int sensorType);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void writeSensorData(int sensorType, string data);


        public void Initialize()
        {
            initialize();
        }

        public void Shutdown()
        {
            shutdown();
        }

        public string ReadSensorData(int sensorType)
        {
            IntPtr ptr = readSensorData(sensorType);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public void WriteSensorData(int sensorType, string data)
        {
            writeSensorData(sensorType, data);
        }
    }
}
