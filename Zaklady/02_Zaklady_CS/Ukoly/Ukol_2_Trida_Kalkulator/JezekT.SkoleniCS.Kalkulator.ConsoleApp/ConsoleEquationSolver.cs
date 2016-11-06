using System;
using System.Diagnostics.Contracts;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp
{
    public class ConsoleEquationSolver
    {
        private readonly Kalkulator _calc;
        private readonly ConsoleInputReader _inputReader;


        public void TwoVariablesEquation()
        {
            var prvniCislo = _inputReader.GetCisloZeVstupu("Zadejte první číslo:");
            var druheCislo = _inputReader.GetCisloZeVstupu("Zadejte druhé číslo:");
            var operace = _inputReader.GetMatematickaOperace();

            Console.WriteLine("Výsledek:");
            switch (operace)
            {
                case MatematickaOperace.Scitani:
                    Console.WriteLine(_calc.GetSoucet(prvniCislo, druheCislo));
                    break;
                case MatematickaOperace.Odcitani:
                    Console.WriteLine(_calc.GetRozdil(prvniCislo, druheCislo));
                    break;
                case MatematickaOperace.Nasobeni:
                    Console.WriteLine(_calc.GetSoucin(prvniCislo, druheCislo));
                    break;
                case MatematickaOperace.Deleni:
                    Console.WriteLine(_calc.GetPodil(prvniCislo, druheCislo));
                    break;
                default:
                    throw new NotImplementedException("Tato matematická operace není implementována.");
            }
        }


        public ConsoleEquationSolver(Kalkulator calc, ConsoleInputReader inputReader)
        {
            if (calc == null || inputReader == null) throw new ArgumentNullException(); // kontrola argumentů konstruktoru
            Contract.EndContractBlock();

            _calc = calc;
            _inputReader = inputReader;
        }
    }
}
