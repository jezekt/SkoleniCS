using System;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
            Console.WriteLine($"{DateTime.Now} {level}: {message}");
        }
    }
}
