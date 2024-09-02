using Entities.Enums;
using Entities.Range;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Managers.Services
{
    public static class IOService
    {
        private static readonly string LibraryName;

        static IOService()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                LibraryName = "IO_Manager.dll";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                LibraryName = "libIO_Manager.so";
            }
            else
            {
                throw new PlatformNotSupportedException("Unsupported platform");
            }

            NativeLibrary.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LibraryName));
        }

        [DllImport("IO_Manager", EntryPoint = "initialize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Initialize();

        [DllImport("IO_Manager", EntryPoint = "shutdown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Shutdown();

        [DllImport("IO_Manager", EntryPoint = "readSensorData", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport("IO_Manager", EntryPoint = "readSensorBinaryData", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport("IO_Manager", EntryPoint = "writeSensorData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void WriteSensorData(int sensorType, string data);
    }
}
