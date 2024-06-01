using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Util
{
    using System;
    using System.IO;

    public static class Logger
    {
        private static readonly string logFilePath = "log.txt"; 

        public static void LogMessage(string message)
        {
            WriteLog("INFO", message);
        }

        public static void LogError(string error)
        {
            WriteLog("ERROR", error);
        }

        private static void WriteLog(string logType, string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logType}] {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }

}
