using System;
using System.Diagnostics.Contracts;
using JezekT.SkoleniCS.Kalkulator.ConsoleApp.Logging;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp
{
    public class ConsoleEquationSolver
    {
        private readonly Kalkulator _calc;
        private readonly ConsoleInputReader _inputReader;
        private readonly TxtFileLogger _logger;


        public void TwoVariablesEquation()
        {
            var prvniCislo = _inputReader.GetCisloZeVstupu("Zadejte první číslo:");
            _logger.Log(LogLevel.Information, $"Uživatel zadal první číslo: {prvniCislo}");

            var druheCislo = _inputReader.GetCisloZeVstupu("Zadejte druhé číslo:");
            _logger.Log(LogLevel.Information, $"Uživatel zadal druhé číslo: {druheCislo}");

            var operace = _inputReader.GetMatematickaOperace();
            _logger.Log(LogLevel.Information, $"Uživatel zvolil matematickou operaci: {operace}");

            int vysledek;
            switch (operace)
            {
                case MatematickaOperace.Scitani:
                    vysledek = _calc.GetSoucet(prvniCislo, druheCislo);
                    break;
                case MatematickaOperace.Odcitani:
                    vysledek = _calc.GetRozdil(prvniCislo, druheCislo);
                    break;
                case MatematickaOperace.Nasobeni:
                    vysledek = _calc.GetSoucin(prvniCislo, druheCislo);
                    break;
                case MatematickaOperace.Deleni:
                    vysledek = _calc.GetPodil(prvniCislo, druheCislo);
                    break;
                default:
                    _logger.Log(LogLevel.Error, $"Matematická operace {operace} není implementována.");
                    throw new NotImplementedException("Tato matematická operace není implementována.");
            }
            Console.WriteLine($"Výsledek: {vysledek}");
            _logger.Log(LogLevel.Information, $"Výsledek výpočtu je: {vysledek}");
        }


        public ConsoleEquationSolver(Kalkulator calc, ConsoleInputReader inputReader, TxtFileLogger logger)
        {
            if (calc == null || inputReader == null || logger == null) throw new ArgumentNullException(); // kontrola argumentů konstruktoru
            Contract.EndContractBlock();

            _calc = calc;
            _inputReader = inputReader;
            _logger = logger;
        }
    }
}
