using System;
using System.IO;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp.Logging
{
    public class TxtFileLogger
    {
        private readonly string _filePath;


        public void Log(LogLevel level, string message)
        {
            var text = $"{DateTime.Now} {level}: {message}" + Environment.NewLine;
            File.AppendAllText(_filePath, text);
        }


        public TxtFileLogger(string filePath)
        {
            _filePath = filePath;
        }
    }
}
