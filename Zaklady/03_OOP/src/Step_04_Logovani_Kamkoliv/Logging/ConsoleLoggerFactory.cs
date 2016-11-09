using System;
using System.Diagnostics.Contracts;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp.Logging
{
    public class ConsoleLoggerFactory
    {
        private readonly ConsoleFileLoggerFactory _fileLoggerFactory;

        public ILogger Create()
        {
            while (true)
            {
                Console.WriteLine("Vyberte typ logování: konzole (K); soubor (S); debug output (D)?");
                var input = Console.ReadLine()?.ToUpper();
                if (input == "K")
                {
                    return new ConsoleLogger();
                }
                if (input == "S")
                {
                    return _fileLoggerFactory.Create();
                }
                if (input == "D")
                {
                    return new TraceListenerLogger();
                }
                Console.WriteLine("Neplatný výběr.");
            }
        }


        public ConsoleLoggerFactory(ConsoleFileLoggerFactory fileLoggerFactory)
        {
            if (fileLoggerFactory == null) throw new ArgumentNullException();
            Contract.EndContractBlock();

            _fileLoggerFactory = fileLoggerFactory;
        }
    }
}
