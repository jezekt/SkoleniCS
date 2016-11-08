using System;
using System.IO;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp.Logging
{
    public class ConsoleFileLoggerFactory
    {
        private readonly string _folderPath;


        public FileLoggerBase Create()
        {
            while (true)
            {
                Console.WriteLine("Vyberte typ souboru pro logování: *.txt (T) nebo *.xml (X)?");
                var input = Console.ReadLine()?.ToUpper();
                if (input == "T")
                {
                    return new TxtFileLogger(Path.Combine(_folderPath, "log.txt"));
                }
                if (input == "X")
                {
                    return new XmlFileLogger(Path.Combine(_folderPath, "log.xml"));
                }
                Console.WriteLine("Neplatný výběr.");
            }
        }


        public ConsoleFileLoggerFactory(string folderPath)
        {
            _folderPath = folderPath;
        }
    }
}
