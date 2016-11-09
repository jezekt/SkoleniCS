using System;
using System.IO;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp.Logging
{
    public class TxtFileLogger : FileLoggerBase
    {
        public override void Log(LogLevel level, string message)
        {
            var text = $"{DateTime.Now} {level}: {message}" + Environment.NewLine;
            File.AppendAllText(FilePath, text);
        }


        public TxtFileLogger(string filePath) : base(filePath)
        {
        }
    }
}
