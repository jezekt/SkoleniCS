using System;
using System.IO;
using JezekT.SkoleniCS.Kalkulator.ConsoleApp.Logging;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var logger = new TxtFileLogger(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"));
            var equationSolver = new ConsoleEquationSolver(new Kalkulator(), new ConsoleInputReader(), logger);
            while (true)
            {
                equationSolver.TwoVariablesEquation();
                Console.ReadLine();
            }
        }
    }
}
