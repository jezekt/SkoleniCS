Úkol è. 2 - Tøída Kalkulátor
============================

### Zadání
* program z [pøedchozího](https://github.com/jezekt/SkoleniCS/tree/master/Zaklady/02_Zaklady_CS/Ukoly/Ukol_1_Kalkulator) úkolu [refaktorujte](https://cs.wikipedia.org/wiki/Refaktorov%C3%A1n%C3%AD) pomocí tøíd.

### Úvod
* pøi vytváøení tøídy je potøeba brát v úvahu její skuteènou zodpovìdnost (viz [zde](http://www.codeproject.com/Articles/703634/SOLID-architecture-principles-using-simple-Csharp#Understanding%E2%80%9CS%E2%80%9D-SRP(Singleresponsibilityprinciple).)). Tøída by nemìla provádìt operace, které jsou mimo pole její pùsobnosti. Z pøedchozího pøíkladu by bylo možné vzít všechny metody obsažšné v `Program.cs` (mimo metodu `Main()`) a dát je do tøídy napø. `Kalkulator`. Objekty vytvoøené z takové tøídy by ale kromì matematických operací umožòovaly provádìt ètení vstupu uživatele z konzole. U tøídy, která se jmenuje `Kalkulator` lze oèekávat pouze provádìní matematických operací. Ètení vstupu z konzole by mìla obstarávat jiná tøída. K vyøešení úkolu budou proto použity tøi tøídy zodpovìdné za následující funkènosti:
	* provádìní matematických operací (sèítání, odèítání, násobení a dìlení na dvou èíslech);
	* ètení èísel a operandu ze vstupu;
	* øízení procesu výpoètu.

### Tøída Kalkulátor
* tato tøída je zodpovìdná za provádìní matematických operací

```c#
public class Kalkulator
{
    public int GetSoucet(int x, int y)
    {
        return x + y;
    }

    public int GetRozdil(int x, int y)
    {
        return x - y;
    }

    public int GetSoucin(int x, int y)
    {
        return x * y;
    }

    public int GetPodil(int x, int y)
    {
        return x / y;
    }
}
```

### Tøída ConsoleInputReader
* tato tøída je zodpovìdná za ètení èísel a operandu ze vstupu konzole;
* pro jasnìjší popsání tøídy byl použit anglický název;

>Poznámka - Názvy tøíd a jejich èlenù mají pro získání pøedstavy o funkci programu zásadní význam. Je proto potøeba používat jasná a výstižná pojmenování.

```c#
public class ConsoleInputReader
{
    public int GetCisloZeVstupu(string textPozadavku)
    {
        int cislo;
        string cisloText;
        do
        {
            Console.WriteLine(textPozadavku);
            cisloText = Console.ReadLine();
        } while (!TryGetCislo(cisloText, out cislo));
            
        return cislo;
    }

    public MatematickaOperace GetMatematickaOperace()
    {
        while (true)
        {
            Console.WriteLine("Zadejte operand:");
            var vstup = Console.ReadLine();
            if (vstup == "+")
            {
                return MatematickaOperace.Scitani;
            }
            if (vstup == "-")
            {
                return MatematickaOperace.Odcitani;
            }
            if (vstup == "*")
            {
                return MatematickaOperace.Nasobeni;
            }
            if (vstup == "/")
            {
                return MatematickaOperace.Deleni;
            }
            Console.WriteLine($"'{vstup}' není platný operand.");
        }
    }

    private bool TryGetCislo(string cisloText, out int cislo)
    {

        if (!int.TryParse(cisloText, out cislo))
        {
            Console.WriteLine("Zadaný vstup není èíslo.");
            return false;
        }
        return true;
    }
}
```

```c#
public enum MatematickaOperace
{
    Scitani,
    Odcitani,
    Nasobeni,
    Deleni
}
```

### Tøída ConsoleEquationSolver
* tato tøída je zodpovìdná za øízení procesu výpoètu;
* k naplnìní zodpovìdnosti využívá dvou výše popsaných tøíd. Instance tìchto tøíd jsou pøedány v konstruktoru;

```c#
public class ConsoleEquationSolver
{
    private readonly Kalkulator _calc;
    private readonly ConsoleInputReader _inputReader;


    public void TwoVariablesEquation()
    {
        var prvniCislo = _inputReader.GetCisloZeVstupu("Zadejte první èíslo:");
        var druheCislo = _inputReader.GetCisloZeVstupu("Zadejte druhé èíslo:");
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
        if (calc == null || inputReader == null) throw new ArgumentNullException(); // kontrola argumentù konstruktoru
        Contract.EndContractBlock();

        _calc = calc;
        _inputReader = inputReader;
    }
}
```

### Program.cs
* v hlavní metodì se pouze vytvoøí instance tøídy `ConsoleEquationSolver` vèetnì jejích argumentù a volá se øešení rovnice se dvìma promìnnými

```c#
static void Main()
{
    var equationSolver = new ConsoleEquationSolver(new Kalkulator(), new ConsoleInputReader());
    while (true)
    {
        equationSolver.TwoVariablesEquation();
        Console.ReadLine();
    }
}
```

* zápis tìla hlavní metody si lze velice zjednodušenì pøedstavit jako vytoøení nìjakého objektu typu `ConsoleEquationSolver`, který za pomoci dalších dovu objektù typù `Kalkulator` a `ConsoleInputReader` bude øešit rovnici se dvìma promìnnými. Slovíèko *Console* v popisu typù objektù napovídá, že se jejich pùsobnost bude vztahovat pouze na oblast konzolové aplikace.  