�kol �. 2 - T��da Kalkul�tor
============================

### Zad�n�
* program z [p�edchoz�ho](https://github.com/jezekt/SkoleniCS/tree/master/Zaklady/02_Zaklady_CS/Ukoly/Ukol_1_Kalkulator) �kolu [refaktorujte](https://cs.wikipedia.org/wiki/Refaktorov%C3%A1n%C3%AD) pomoc� t��d.

### �vod
* p�i vytv��en� t��dy je pot�eba br�t v �vahu jej� skute�nou zodpov�dnost (viz [zde](http://www.codeproject.com/Articles/703634/SOLID-architecture-principles-using-simple-Csharp#Understanding%E2%80%9CS%E2%80%9D-SRP(Singleresponsibilityprinciple).)). T��da by nem�la prov�d�t operace, kter� jsou mimo pole jej� p�sobnosti. Z p�edchoz�ho p��kladu by bylo mo�n� vz�t v�echny metody obsa��n� v `Program.cs` (mimo metodu `Main()`) a d�t je do t��dy nap�. `Kalkulator`. Objekty vytvo�en� z takov� t��dy by ale krom� matematick�ch operac� umo��ovaly prov�d�t �ten� vstupu u�ivatele z konzole. U t��dy, kter� se jmenuje `Kalkulator` lze o�ek�vat pouze prov�d�n� matematick�ch operac�. �ten� vstupu z konzole by m�la obstar�vat jin� t��da. K vy�e�en� �kolu budou proto pou�ity t�i t��dy zodpov�dn� za n�sleduj�c� funk�nosti:
	* prov�d�n� matematick�ch operac� (s��t�n�, od��t�n�, n�soben� a d�len� na dvou ��slech);
	* �ten� ��sel a operandu ze vstupu;
	* ��zen� procesu v�po�tu.

### T��da Kalkul�tor
* tato t��da je zodpov�dn� za prov�d�n� matematick�ch operac�

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

### T��da ConsoleInputReader
* tato t��da je zodpov�dn� za �ten� ��sel a operandu ze vstupu konzole;
* pro jasn�j�� pops�n� t��dy byl pou�it anglick� n�zev;

>Pozn�mka - N�zvy t��d a jejich �len� maj� pro z�sk�n� p�edstavy o funkci programu z�sadn� v�znam. Je proto pot�eba pou��vat jasn� a v�sti�n� pojmenov�n�.

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
            Console.WriteLine($"'{vstup}' nen� platn� operand.");
        }
    }

    private bool TryGetCislo(string cisloText, out int cislo)
    {

        if (!int.TryParse(cisloText, out cislo))
        {
            Console.WriteLine("Zadan� vstup nen� ��slo.");
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

### T��da ConsoleEquationSolver
* tato t��da je zodpov�dn� za ��zen� procesu v�po�tu;
* k napln�n� zodpov�dnosti vyu��v� dvou v��e popsan�ch t��d. Instance t�chto t��d jsou p�ed�ny v konstruktoru;

```c#
public class ConsoleEquationSolver
{
    private readonly Kalkulator _calc;
    private readonly ConsoleInputReader _inputReader;


    public void TwoVariablesEquation()
    {
        var prvniCislo = _inputReader.GetCisloZeVstupu("Zadejte prvn� ��slo:");
        var druheCislo = _inputReader.GetCisloZeVstupu("Zadejte druh� ��slo:");
        var operace = _inputReader.GetMatematickaOperace();

        Console.WriteLine("V�sledek:");
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
                throw new NotImplementedException("Tato matematick� operace nen� implementov�na.");
        }
    }


    public ConsoleEquationSolver(Kalkulator calc, ConsoleInputReader inputReader)
    {
        if (calc == null || inputReader == null) throw new ArgumentNullException(); // kontrola argument� konstruktoru
        Contract.EndContractBlock();

        _calc = calc;
        _inputReader = inputReader;
    }
}
```

### Program.cs
* v hlavn� metod� se pouze vytvo�� instance t��dy `ConsoleEquationSolver` v�etn� jej�ch argument� a vol� se �e�en� rovnice se dv�ma prom�nn�mi

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

* z�pis t�la hlavn� metody si lze velice zjednodu�en� p�edstavit jako vyto�en� n�jak�ho objektu typu `ConsoleEquationSolver`, kter� za pomoci dal��ch dovu objekt� typ� `Kalkulator` a `ConsoleInputReader` bude �e�it rovnici se dv�ma prom�nn�mi. Slov��ko *Console* v popisu typ� objekt� napov�d�, �e se jejich p�sobnost bude vztahovat pouze na oblast konzolov� aplikace.  