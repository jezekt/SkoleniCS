using System;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var equationSolver = new ConsoleEquationSolver(new Kalkulator(), new ConsoleInputReader());
            while (true)
            {
                equationSolver.TwoVariablesEquation();
                Console.ReadLine();
            }
        }
    }
}
