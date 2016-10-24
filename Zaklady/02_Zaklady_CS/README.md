2 Z�klady C#
============

### 1 - Zalo�en� projektu
* Spustit Visual Studio 2015;
* File > New > Project > Console Application (Installed - Templates - Visual C# - Windows).

### 2 - Hello World
* do t�la metody `Main()` vepsat n�sleduj�c� k�d:
```c#
Console.WriteLine("Hello world");
Console.ReadKey();
```
* vy�istit k�d:
  * odstranit zbyte�n� `using` direktivy;
  * odstranit zbyte�n� vstupn� argumenty metody `Main()`.
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
* spustit aplikaci v re�imu lad�n� - tla��tko `Start` nebo kl�vesa `F5`;
* dojde ke kompilaci soubor� a ke spu�t�n� aplikace;
* objev� se konzole s n�pisem "Hello World";
* jakoukoliv kl�vesou konzoli ukon�it.

>Bonus - Stejn� program nyn� vytvo�it bez Visual Studia za pomoci textov�ho editoru a `csc.exe`.

### 3 - Datov� typy, prom�nn� a v�razy
* p�ehled datov�ch typ� je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/types-and-variables);
* deklarace prom�nn�ch
```c#
// Explicitn� typov�n�
int x; // deklarace prom�nn�
x = 1000000; // napln�n� prom�nn� hodnotou
byte y = 125; // deklarace prom�nn� a napln�n� hodnotou

// Implicitn� typov�n� - o typu rozhodne kompil�tor
var soucet = x + y; // deklarace prom�nn� a napln�n� hodnotou
```
* implicitn� a explicitn� p�etypov�n� je pops�no [zde](https://msdn.microsoft.com/cs-cz/library/ms173105.aspx)
```c#
int x = 150;
byte y = 1;
int soucet = x + y;

// Implicitn� p�etypov�n�
long z = x; // implicitn� p�evod typu int (32 bit) na typ long (64 bit)
//y = x; // nelze prov�st - nelze zapsat hodnotu typu int (32 bit) do prom�nn� typu byte (8 bit)
x = y; // lze prov�st - prom�nn� y je typu byte a jej� hodnotu lze zapsat do prom�nn� typu int

// Explicitn� p�etypov�n�
y = (byte) soucet;
```
* p�evod �et�zce na ��slo
```c#
string text = "text";
//int i = text; // nelze p�etypovat string na typ int
int i = int.Parse(text); // v tomto p��pad� dojde b�hem p�etypov�n� k v�jimce
i = int.Parse("1256"); // �et�zec "1256" bude p�eveden na cel� ��slo 1256

if (int.TryParse(text, out i))
{
	Console.WriteLine("P�etypov�n� se zda�ilo.");
}
else
{
	Console.WriteLine("Nelze p�etypovat.");
}
```
* v�razy jsou uvedeny [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/expressions).

### 4 - P��kazy
* p�ehled p��kaz� je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/statements);
* podm�nky `if`
```c#
var i = 5;

if (i > 10)
{
    Console.WriteLine("��slo je v�t�� ne� 10.");
}
else if (i > 5)
{
    Console.WriteLine("��slo je v�t�� ne� 5 a men�� rovno 10.");
}
else
{
    Console.WriteLine("��slo je men�� rovno 5.");
}

// Alternativn� z�pis 1
if (i > 10) Console.WriteLine("��slo je v�t�� ne� 10.");
else if (i > 5) Console.WriteLine("��slo je v�t�� ne� 5 a men�� rovno 10.");
else Console.WriteLine("��slo je men�� rovno 5.");

// Alternativn� z�pis 2
if (i > 10)
    Console.WriteLine("��slo je v�t�� ne� 10.");
else if
    (i > 5) Console.WriteLine("��slo je v�t�� ne� 5 a men�� rovno 10.");
else // v p��pad�, �e je pot�eba pou��t v�ce ��dk�, je nutno pou��t slo�en� z�vorky
{
    var text = "��slo je men�� rovno 5.";
    Console.WriteLine(text);
}
```
* podm�n�n� smy�ka `while`
```c#
// Vyp�e ��sla od 1 do 10
var i = 1;
while (i <= 10)
{
    Console.WriteLine(i);
    i++;
}
```
* podm�n�n� smy�ka `do`
```c#
string s;
do
{
    Console.WriteLine("Pro opu�t�n� smy�ky napi�te 'exit' a stiskn�te ENTER");
    s = Console.ReadLine();
} while (s != "exit");

Console.WriteLine("OK");
```
* p�ep�na� `switch`
```c#
var denVTydnu = DayOfWeek.Friday;

switch (denVTydnu)
{
    case DayOfWeek.Monday:
        Console.WriteLine("Pond�l�");
        break;
    case DayOfWeek.Tuesday:
        Console.WriteLine("�ter�");
        break;
    case DayOfWeek.Wednesday:
        Console.WriteLine("St�eda");
        break;
    case DayOfWeek.Thursday:
        Console.WriteLine("�tvrtek");
        break;
    case DayOfWeek.Friday:
        Console.WriteLine("P�tek");
        break;
    case DayOfWeek.Saturday: // slo�en� p��pad
    case DayOfWeek.Sunday:
        Console.WriteLine("V�kend");
        break;
    default: // v p��pad�, kdy nastane mo�nost, kter� nen� specifikov�na v��e
        throw new NotImplementedException("Tento den v t�dnu nen� implementov�n.");
}
```
* cyklus `for`
```c#
var cisla = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

// int i = 0 - deklarace a po��te�n� napln�n� prom�nn�, kter� se pou��v� v podm�nce cyklu
// i < 6 - podm�nka cyklu
// i++ - v�raz, kter� je proveden po ka�d� iteraci
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

// projde v�echny prvky kolekce cisla
// v ka�d� iteraci je odpov�daj�c� prvek napln�n do prom�nn� cislo
foreach (var cislo in cisla)
{
    Console.WriteLine(cislo);
}
```
* p��kaz `break`
```c#
var email = "test@best.cz";
var jednotliveZnaky = email.ToCharArray();
string uzivatel = "";
for (int i = 0; i < jednotliveZnaky.Length; i++)
{
    var znak = jednotliveZnaky[i];
    if (znak == '@')
    {
        // opust� cyklus for a pokra�uje v b�hu
        break;
    }
    uzivatel += znak;
}

Console.WriteLine(uzivatel);
```
* p��kaz `continue`
```c#
var cisla = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

Console.WriteLine("Sud� ��sla:");
foreach (var cislo in cisla)
{
    if (cislo%2 != 0)
    {
        // pokra�uje v dal�� iteraci cyklu foreach
        continue;
    }
    Console.WriteLine(cislo);
}
```
* odchycen� v�jimky pomoc� `try-catch`
```c#
try // blok ve kter�m se m� prov�st odchycen� v�jimky
{
    var x = 10;
    var y = 0;
    var podil = x/y;

    Console.WriteLine(podil);
}
catch (DivideByZeroException ex) // blok ve kter�m se �e�� odchycen� v�jimka
{
    Console.WriteLine(ex.Message);
}
```

### 5 - V��tov� typy
* popis v��tov�ch typ� je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/enums).
```c#
public enum DruhVystupu
{
    Informace,
    Varovani,
    Chyba
}
```
* pou�it� v��tov�ho typu
```c#
static void Main()
{
    VypisVystup("Toto je informace.", DruhVystupu.Informace);
    VypisVystup("Toto je varov�n�.", DruhVystupu.Varovani);
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
* popis pol� je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/arrays);
* jednorozm�rn� pole - definice a napln�n�
```c#
private static int[] GetPoleCisel(int velikost)
{
    var cisla = new int[velikost]; // vytvo�en� pole o dan� velikosti
    for (int i = 0; i < cisla.Length; i++)
    {
        cisla[i] = i + 1; // napln�n� konkr�tn�ho prvku pole hodnotou
    }
    return cisla;
}
```

* jednorozm�rn� pole - inicializace
```c#
// Dal�� zp�soby vytvo�en� pole
var definovanaCislaA = new int[] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };
var definofavaCislaB = new[] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };
int[] definovanaCislaC = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };

var tretiPrvek = definovanaCislaC[2]; // z�sk�n� hodnoty t�et�ho prvku pole pomoc� indexu (index je od 0 do n)
```

* v�cerozm�rn� pole
```c#
var matice = new int[i, j]; // definice dvojrozm�rn�ho pole

int hodnota = 0;
for (int k = 0; k < i; k++)
{
    for (int l = 0; l < j; l++)
    {
        matice[k, l] = hodnota; // napln�n� hodnoty prvku pole ��dku k a sloupce l
        hodnota++;
    }
    hodnota = 0;
}
```

* v�cen�sobn� pole
```c#
var hlavniPole = new int[i][]; // definice pole pol�
for (int k = 0; k < i; k++)
{
    var prvek = GetPoleCisel(k+1);
    hlavniPole[k] = prvek; // prvek hlavn�ho pole je pole ��sel
}
return hlavniPole;
```

### 7 - T��dy
* popis t��d je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/classes-and-objects);

>Pozn�mka - T��dy lze ch�pat jako p�edpis/sch�ma, podle kter�ho se vytv��� objekty. K vytvo�en� objektu konkr�tn� t��dy se pou��v� kl��ov� slovo *new*. 

* z�pis jednoduch� t��dy
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
        Console.WriteLine("Jm�no: " + Jmeno + "; P��jmen�: " + Prijmeni + "; Telefon: " + Telefon + ".");
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
* pou�it� t��dy `Kontakt`
```c#
    // pole Kontakt� se t�emi instancemi t��dy Kontakt
    var seznamKontaktu = new[]
    {
        new Kontakt("Jan", "Nov�k", "111 202 303"),
        new Kontakt("Ji��", "�ech", "333 123 321"),
        new Kontakt("Kamil", "Chv�tal", "888 888 888")
    };

    foreach (var kontakt in seznamKontaktu)
    {
        kontakt.VypisDetaily();
    }
```
* slo�it�j�� t��da
```c#
public class Budik
{
    // FIELDS - PROM�NN�
    private readonly Timer _timer;


    // EVENTS - UD�LOSTI
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
            throw new ArgumentException("�as buzen� spad� do minulosti."); // v�jimka v p��pad�, kdy se u�ivatel pokus� nastavit �as buzen� v minulosti
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
        _timer = new Timer(1000); // vytvo�en� nov� instance �asova�e - nastaveno na 1000 ms
        _timer.Elapsed += OnTimerElapsed; // nastaven� ud�losti p�i uplynut� nastaven� doby �asova�e
    }


    // PRIV�TN� METODY - pro p�ehlednost jsou um�st�ny pod konstruktorem
    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        var aktualniCas = DateTime.Now;
        if (VypisujCas)
        {
            Console.WriteLine(aktualniCas);
        }

        if (BudikZapnut && SpustitBuzeni(aktualniCas)) // pokud je bud�k zapnut a m� se spustit buzen�
        {
            Buzeni?.Invoke(); // vyvol� ud�lost buzen�
            VypnoutBudik();
        }
    }

    private bool SpustitBuzeni(DateTime aktualniCas)
    {
        return aktualniCas.Second == CasBuzeni.Second && // kontrola sekund
                Math.Abs((CasBuzeni - aktualniCas).TotalSeconds) < 1; // kontrola zbytku (rok, m�s�c, den, ...)
    }
}
```
* pou�it� t��dy `Budik`
```c#
var budik = new Budik {VypisujCas = true}; // vytvo�en� nov� instance t��dy Budik
budik.Buzeni += OnBuzeni; // p�ips�n� ke sledov�n� ud�lost Buzeni - metoda OnBuzeni()  
budik.NastavitBudik(DateTime.Now.AddSeconds(5)); // nastaven� bud�ku na 5 s dop�edu
Console.WriteLine($"Bud�k nastaven na {budik.CasBuzeni}.");

budik.ZapnoutBudik();
```

>Pozn�mka - P�i psan� t��d je vhodn� dodr�ovat z�kladn� principy viz [SOLID](http://www.codeproject.com/Articles/703634/SOLID-architecture-principles-using-simple-Csharp). 