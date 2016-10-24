2 Základy C#
============

### 1 - Založení projektu
* Spustit Visual Studio 2015;
* File > New > Project > Console Application (Installed - Templates - Visual C# - Windows).

### 2 - Hello World
* do tìla metody `Main()` vepsat následující kód:
```c#
Console.WriteLine("Hello world");
Console.ReadKey();
```
* vyèistit kód:
  * odstranit zbyteèné `using` direktivy;
  * odstranit zbyteèné vstupní argumenty metody `Main()`.
```c#
using System;

namespace JezekT.SkoleniCS.Zaklady.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }
    }
}
```
* spustit aplikaci v režimu ladìní - tlaèítko `Start` nebo klávesa `F5`;
* dojde ke kompilaci souborù a ke spuštìní aplikace;
* objeví se konzole s nápisem "Hello World";
* jakoukoliv klávesou konzoli ukonèit.

>Bonus - Stejný program nyní vytvoøit bez Visual Studia za pomoci textového editoru a `csc.exe`.

### 3 - Datové typy, promìnné a výrazy
* pøehled datových typù je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/types-and-variables);
* deklarace promìnných
```c#
// Explicitní typování
int x; // deklarace promìnné
x = 1000000; // naplnìní promìnné hodnotou
byte y = 125; // deklarace promìnné a naplnìní hodnotou

// Implicitní typování - o typu rozhodne kompilátor
var soucet = x + y; // deklarace promìnné a naplnìní hodnotou
```
* implicitní a explicitní pøetypování je popsáno [zde](https://msdn.microsoft.com/cs-cz/library/ms173105.aspx)
```c#
int x = 150;
byte y = 1;
int soucet = x + y;

// Implicitní pøetypování
long z = x; // implicitní pøevod typu int (32 bit) na typ long (64 bit)
//y = x; // nelze provést - nelze zapsat hodnotu typu int (32 bit) do promìnné typu byte (8 bit)
x = y; // lze provést - promìnná y je typu byte a její hodnotu lze zapsat do promìnné typu int

// Explicitní pøetypování
y = (byte) soucet;
```
* pøevod øetìzce na èíslo
```c#
string text = "text";
//int i = text; // nelze pøetypovat string na typ int
int i = int.Parse(text); // v tomto pøípadì dojde bìhem pøetypování k výjimce
i = int.Parse("1256"); // øetìzec "1256" bude pøeveden na celé èíslo 1256

if (int.TryParse(text, out i))
{
	Console.WriteLine("Pøetypování se zdaøilo.");
}
else
{
	Console.WriteLine("Nelze pøetypovat.");
}
```
* výrazy jsou uvedeny [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/expressions).

### 4 - Pøíkazy
* pøehled pøíkazù je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/statements);
* podmínky `if`
```c#
var i = 5;

if (i > 10)
{
    Console.WriteLine("Èíslo je vìtší než 10.");
}
else if (i > 5)
{
    Console.WriteLine("Èíslo je vìtší než 5 a menší rovno 10.");
}
else
{
    Console.WriteLine("Èíslo je menší rovno 5.");
}

// Alternativní zápis 1
if (i > 10) Console.WriteLine("Èíslo je vìtší než 10.");
else if (i > 5) Console.WriteLine("Èíslo je vìtší než 5 a menší rovno 10.");
else Console.WriteLine("Èíslo je menší rovno 5.");

// Alternativní zápis 2
if (i > 10)
    Console.WriteLine("Èíslo je vìtší než 10.");
else if
    (i > 5) Console.WriteLine("Èíslo je vìtší než 5 a menší rovno 10.");
else // v pøípadì, že je potøeba použít více øádkù, je nutno použít složené závorky
{
    var text = "Èíslo je menší rovno 5.";
    Console.WriteLine(text);
}
```
* podmínìná smyèka `while`
```c#
// Vypíše èísla od 1 do 10
var i = 1;
while (i <= 10)
{
    Console.WriteLine(i);
    i++;
}
```
* podmínìná smyèka `do`
```c#
string s;
do
{
    Console.WriteLine("Pro opuštìní smyèky napište 'exit' a stisknìte ENTER");
    s = Console.ReadLine();
} while (s != "exit");

Console.WriteLine("OK");
```
* pøepínaè `switch`
```c#
var denVTydnu = DayOfWeek.Friday;

switch (denVTydnu)
{
    case DayOfWeek.Monday:
        Console.WriteLine("Pondìlí");
        break;
    case DayOfWeek.Tuesday:
        Console.WriteLine("Úterý");
        break;
    case DayOfWeek.Wednesday:
        Console.WriteLine("Støeda");
        break;
    case DayOfWeek.Thursday:
        Console.WriteLine("Ètvrtek");
        break;
    case DayOfWeek.Friday:
        Console.WriteLine("Pátek");
        break;
    case DayOfWeek.Saturday: // složený pøípad
    case DayOfWeek.Sunday:
        Console.WriteLine("Víkend");
        break;
    default: // v pøípadì, kdy nastane možnost, která není specifikována výše
        throw new NotImplementedException("Tento den v týdnu není implementován.");
}
```
* cyklus `for`
```c#
var cisla = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

// int i = 0 - deklarace a poèáteèní naplnìní promìnné, která se používá v podmínce cyklu
// i < 6 - podmínka cyklu
// i++ - výraz, který je proveden po každé iteraci
for (int i = 0; i < 6; i++)
{
    Console.WriteLine(cisla[i]);
}

for (int i = 9; i > 5; i = i - 1)
{
    Console.WriteLine(cisla[i]);
}
```
* cyklus `foreach`
```c#
var cisla = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

// projde všechny prvky kolekce cisla
// v každé iteraci je odpovídající prvek naplnìn do promìnné cislo
foreach (var cislo in cisla)
{
    Console.WriteLine(cislo);
}
```
* pøíkaz `break`
```c#
var email = "test@best.cz";
var jednotliveZnaky = email.ToCharArray();
string uzivatel = "";
for (int i = 0; i < jednotliveZnaky.Length; i++)
{
    var znak = jednotliveZnaky[i];
    if (znak == '@')
    {
        // opustí cyklus for a pokraèuje v bìhu
        break;
    }
    uzivatel += znak;
}

Console.WriteLine(uzivatel);
```
* pøíkaz `continue`
```c#
var cisla = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

Console.WriteLine("Sudá èísla:");
foreach (var cislo in cisla)
{
    if (cislo%2 != 0)
    {
        // pokraèuje v další iteraci cyklu foreach
        continue;
    }
    Console.WriteLine(cislo);
}
```
* odchycení výjimky pomocí `try-catch`
```c#
try // blok ve kterém se má provést odchycení výjimky
{
    var x = 10;
    var y = 0;
    var podil = x/y;

    Console.WriteLine(podil);
}
catch (DivideByZeroException ex) // blok ve kterém se øeší odchycená výjimka
{
    Console.WriteLine(ex.Message);
}
```

### 5 - Výètové typy
* popis výètových typù je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/enums).
```c#
public enum DruhVystupu
{
    Informace,
    Varovani,
    Chyba
}
```
* použití výètového typu
```c#
static void Main()
{
    VypisVystup("Toto je informace.", DruhVystupu.Informace);
    VypisVystup("Toto je varování.", DruhVystupu.Varovani);
    VypisVystup("Toto je chyba.", DruhVystupu.Chyba);

    Console.ReadKey();
}

private static void VypisVystup(string text, DruhVystupu druhVystupu)
{
    switch (druhVystupu)
    {
        case DruhVystupu.Informace:
            Console.ForegroundColor = ConsoleColor.White;
            break;
        case DruhVystupu.Varovani:
            Console.ForegroundColor = ConsoleColor.Yellow;
            break;
        case DruhVystupu.Chyba:
            Console.ForegroundColor = ConsoleColor.Red;
            break;
        default:
            throw new NotImplementedException();
    }
    Console.WriteLine(text);
    Console.ForegroundColor = ConsoleColor.White;
}
```

### 6 - Pole
* popis polí je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/arrays);
* jednorozmìrná pole - definice a naplnìní
```c#
private static int[] GetPoleCisel(int velikost)
{
    var cisla = new int[velikost]; // vytvoøení pole o dané velikosti
    for (int i = 0; i < cisla.Length; i++)
    {
        cisla[i] = i + 1; // naplnìní konkrétního prvku pole hodnotou
    }
    return cisla;
}
```

* jednorozmìrná pole - inicializace
```c#
// Další zpùsoby vytvoøení pole
var definovanaCislaA = new int[] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };
var definofavaCislaB = new[] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };
int[] definovanaCislaC = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };

var tretiPrvek = definovanaCislaC[2]; // získání hodnoty tøetího prvku pole pomocí indexu (index je od 0 do n)
```

* vícerozmìrná pole
```c#
var matice = new int[i, j]; // definice dvojrozmìrného pole

int hodnota = 0;
for (int k = 0; k < i; k++)
{
    for (int l = 0; l < j; l++)
    {
        matice[k, l] = hodnota; // naplnìní hodnoty prvku pole øádku k a sloupce l
        hodnota++;
    }
    hodnota = 0;
}
```

* vícenásobná pole
```c#
var hlavniPole = new int[i][]; // definice pole polí
for (int k = 0; k < i; k++)
{
    var prvek = GetPoleCisel(k+1);
    hlavniPole[k] = prvek; // prvek hlavního pole je pole èísel
}
return hlavniPole;
```

### 7 - Tøídy
* popis tøíd je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/classes-and-objects);

>Poznámka - Tøídy lze chápat jako pøedpis/schéma, podle kterého se vytváøí objekty. K vytvoøení objektu konkrétní tøídy se používá klíèové slovo *new*. 

* zápis jednoduché tøídy
```c#
public class Kontakt
{
    // PROPERTIES - VLASTNOSTI
    public string Jmeno { get; }
    public string Prijmeni { get; }
    public string Telefon { get; }

    // METHODS - METODY
    public void VypisDetaily()
    {
        Console.WriteLine("Jméno: " + Jmeno + "; Pøíjmení: " + Prijmeni + "; Telefon: " + Telefon + ".");
    }

    // CONSTRUCTORS - KONSTRUKTORY
    public Kontakt(string jmeno, string prijmeni, string telefon)
    {
        Jmeno = jmeno;
        Prijmeni = prijmeni;
        Telefon = telefon;
    }
}
``` 
* použití tøídy `Kontakt`
```c#
    // pole Kontaktù se tøemi instancemi tøídy Kontakt
    var seznamKontaktu = new[]
    {
        new Kontakt("Jan", "Novák", "111 202 303"),
        new Kontakt("Jiøí", "Èech", "333 123 321"),
        new Kontakt("Kamil", "Chvátal", "888 888 888")
    };

    foreach (var kontakt in seznamKontaktu)
    {
        kontakt.VypisDetaily();
    }
```
* složitìjší tøída
```c#
public class Budik
{
    // FIELDS - PROMÌNNÉ
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
            throw new ArgumentException("Èas buzení spadá do minulosti."); // výjimka v pøípadì, kdy se uživatel pokusí nastavit èas buzení v minulosti
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
        _timer = new Timer(1000); // vytvoøení nové instance èasovaèe - nastaveno na 1000 ms
        _timer.Elapsed += OnTimerElapsed; // nastavení události pøi uplynutí nastavené doby èasovaèe
    }


    // PRIVÁTNÍ METODY - pro pøehlednost jsou umístìny pod konstruktorem
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
                Math.Abs((CasBuzeni - aktualniCas).TotalSeconds) < 1; // kontrola zbytku (rok, mìsíc, den, ...)
    }
}
```
* použití tøídy `Budik`
```c#
var budik = new Budik {VypisujCas = true}; // vytvoøení nové instance tøídy Budik
budik.Buzeni += OnBuzeni; // pøipsání ke sledování událost Buzeni - metoda OnBuzeni()  
budik.NastavitBudik(DateTime.Now.AddSeconds(5)); // nastavení budíku na 5 s dopøedu
Console.WriteLine($"Budík nastaven na {budik.CasBuzeni}.");

budik.ZapnoutBudik();
```

>Poznámka - Pøi psaní tøíd je vhodné dodržovat základní principy viz [SOLID](http://www.codeproject.com/Articles/703634/SOLID-architecture-principles-using-simple-Csharp). 