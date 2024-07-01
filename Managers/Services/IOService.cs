using Entities.Enums;
using Entities.Range;
using System;
using System.Runtime.InteropServices;

namespace Managers.Services
{
    public static class IOService
    {
        private const string WindowsLibrary = "IO_Manager.dll";
        private const string LinuxLibrary = "IO_Manager.so";

        static IOService()
        {
            var libraryPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                NativeLibrary.Load(System.IO.Path.Combine(libraryPath, WindowsLibrary));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                NativeLibrary.Load(System.IO.Path.Combine(libraryPath, LinuxLibrary));
            }
        }



        [DllImport(WindowsLibrary, EntryPoint = "initialize", CallingConvention = CallingConvention.Cdecl)]
        //[DllImport(LinuxLibrary, EntryPoint = "initialize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Initialize();



        [DllImport(WindowsLibrary, EntryPoint = "shutdown", CallingConvention = CallingConvention.Cdecl)]
        ////[DllImport(LinuxLibrary, EntryPoint = "shutdown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Shutdown();



        [DllImport(WindowsLibrary, EntryPoint = "readSensorData", CallingConvention = CallingConvention.Cdecl)]
        ////[DllImport(LinuxLibrary, EntryPoint = "readSensorData", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ReadSensorDataInternal(int sensorType);


        public static string ReadSensorData(SensorTypes sensorType)
        {
            IntPtr dataPtr = ReadSensorDataInternal((int)sensorType);
            if (dataPtr == IntPtr.Zero)
            {
                throw new Exception("Failed to read sensor data");
            }
            return Marshal.PtrToStringAnsi(dataPtr);
        }


        [DllImport(WindowsLibrary, EntryPoint = "readSensorBinaryData", CallingConvention = CallingConvention.Cdecl)]
        //[DllImport(LinuxLibrary, EntryPoint = "readSensorBinaryData", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ReadSensorBinaryDataInternal(int sensorType, out int size);

        public static RangeData ReadSensorBinary(SensorTypes sensorType)
        {
            int size;
            IntPtr dataPtr = ReadSensorBinaryDataInternal((int)sensorType, out size);
            if (dataPtr == IntPtr.Zero)
            {
                throw new Exception("Failed to read sensor binary data");
            }

            byte[] data = new byte[size];
            Marshal.Copy(dataPtr, data, 0, size);

            RangeData rangeData = new RangeData();
            using (MemoryStream ms = new MemoryStream(data))
            using (BinaryReader br = new BinaryReader(ms))
            {
                int rows = br.ReadInt32();
                int cols = br.ReadInt32(); 
                rangeData.InitializeMatrix(rows, cols);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        float value = br.ReadSingle();
                        rangeData.SetValue(i, j, value);
                    }
                }
            }

            return rangeData;
        }





        [DllImport(WindowsLibrary, EntryPoint = "writeSensorData", CallingConvention = CallingConvention.Cdecl)]
        ////[DllImport(LinuxLibrary, EntryPoint = "writeSensorData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void WriteSensorData(int sensorType, string data);
    }
}
