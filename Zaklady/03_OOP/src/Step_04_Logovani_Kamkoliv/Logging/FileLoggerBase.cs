namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp.Logging
{
    public abstract class FileLoggerBase: ILogger
    {
        protected readonly string FilePath;


        public abstract void Log(LogLevel level, string message);


        protected FileLoggerBase(string filePath)
        {
            FilePath = filePath;
        }
    }
}
