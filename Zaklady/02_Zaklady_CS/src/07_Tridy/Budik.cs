using System;
using System.Timers;

namespace JezekT.SkoleniCS.Zaklady.ConsoleApp
{
    public class Budik
    {
        // FIELDS - PROMĚNNÉ
        private readonly Timer _timer;


        // EVENTS - UDÁLOSTI
        public event Action Buzeni;


        // PROPERTIES - VLASTNOSTI
        public DateTime CasBuzeni { get; private set; }
        public bool BudikZapnut { get; private set; }
        public bool VypisujCas { get; set; }


        // METHODS - METODY
        public void NastavitBudik(DateTime casBuzeni)
        {
            if (casBuzeni <= DateTime.Now)
            {
                throw new ArgumentException("Čas buzení spadá do minulosti."); // výjimka v případě, kdy se uživatel pokusí nastavit čas buzení v minulosti
            }

            CasBuzeni = casBuzeni;
        }
        
        public void ZapnoutBudik()
        {
            BudikZapnut = true;
            _timer.Start();
        }

        public void VypnoutBudik()
        {
            BudikZapnut = false;
            _timer.Stop();
        }


        // CONSTRUCTORS - KONSTRUKTORY
        public Budik()
        {
            _timer = new Timer(1000); // vytvoření nové instance časovače - nastaveno na 1000 ms
            _timer.Elapsed += OnTimerElapsed; // nastavení události při uplynutí nastavené doby časovače
        }


        // PRIVÁTNÍ METODY - pro přehlednost jsou umístěny pod konstruktorem
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var aktualniCas = DateTime.Now;
            if (VypisujCas)
            {
                Console.WriteLine(aktualniCas);
            }

            if (BudikZapnut && SpustitBuzeni(aktualniCas)) // pokud je budík zapnut a má se spustit buzení
            {
                Buzeni?.Invoke(); // vyvolá událost buzení
                VypnoutBudik();
            }
        }

        private bool SpustitBuzeni(DateTime aktualniCas)
        {
            return aktualniCas.Second == CasBuzeni.Second && // kontrola sekund
                   Math.Abs((CasBuzeni - aktualniCas).TotalSeconds) < 1; // kontrola zbytku (rok, měsíc, den, ...)
        }
    }
}
