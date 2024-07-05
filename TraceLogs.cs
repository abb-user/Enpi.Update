using System;
using System.IO;

namespace Electrification.ABB.SDK.EnPI.Update
{
    public class TraceLogs
    {
        public static void Log(string logFilePath, string message)
        {
            string logMessage = $"{DateTime.Now}: {message}";

            try
            {
                // Append the log message to the file
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
}
