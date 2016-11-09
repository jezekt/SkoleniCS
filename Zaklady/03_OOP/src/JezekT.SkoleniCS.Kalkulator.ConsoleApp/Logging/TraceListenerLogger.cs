using System;
using System.Diagnostics;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp.Logging
{
    public class TraceListenerLogger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
            Debug.Print($"{DateTime.Now} {level}: {message}");
        }
    }
}
