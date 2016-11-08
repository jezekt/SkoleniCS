using System;
using JezekT.SkoleniCS.Kalkulator.ConsoleApp.Logging;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var loggerFactory = new ConsoleFileLoggerFactory(AppDomain.CurrentDomain.BaseDirectory);
            var logger = loggerFactory.Create();
            var equationSolver = new ConsoleEquationSolver(new Kalkulator(), new ConsoleInputReader(), logger);
            while (true)
            {
                equationSolver.TwoVariablesEquation();
                Console.ReadLine();
            }
        }
    }
}
