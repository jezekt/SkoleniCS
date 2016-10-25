Úkol è. 1 - Kalkulátor
======================

### Zadání
* vytvoøte konzolovou aplikaci, která bude umožòovat provádìt základní matematické operace (sèítání, odèítání, násobení, dìlení) na dvou èíslech.

### Step 1 - Základní forma
* takto mùže vypadat jeden z prvních programù pøi absolvování školení
```c#
Console.WriteLine("Zadejte první èíslo:");
string prvniCisloText = Console.ReadLine();
int prvniCislo = int.Parse(prvniCisloText);

Console.WriteLine("Zadejte druhé èíslo:");
string druheCisloText = Console.ReadLine();
int druheCislo = int.Parse(druheCisloText);

Console.WriteLine("Zadejte operand:");
string operand = Console.ReadLine();

Console.WriteLine("Výsledek:");
switch (operand)
{
    case "+":
        Console.WriteLine(prvniCislo + druheCislo);
        break;
    case "-":
        Console.WriteLine(prvniCislo - druheCislo);
        break;
    case "*":
        Console.WriteLine(prvniCislo*druheCislo);
        break;
    case "/":
        Console.WriteLine(prvniCislo/druheCislo);
        break;
}

Console.ReadLine();
```
* program je sice funkèní, ale má nìkolik nedostatkù
	* není zde ošetøen vstup uživatele - pokud bude do programu zadána hodnota, kterou program neoèekává (napø. písmeno místo èísla), tak program spadne;
	* výsledek dìlení bude v tomto pøípadì vždy celé èíslo (i pøi dìlení se zbytkem);
	* program by mohl bìžet ve smyèce, dokud se ho uživate nerozhodne zavøít sám.

### Step 2 - Ošetøení chyb
* v tomto kroce byly provedeny úpravy na základì nedostatkù, které byly definovány v kroce 1
	* aplikace již nespadne pøi zadání neoèekávaného vstupu;
	* program vrací výsledek dìlení jako desetinné èíslo;
	* program bìží ve smyèce.
```c#
while (true)
{
    Console.WriteLine("Zadejte první èíslo:");
    string prvniCisloText = Console.ReadLine();
    int prvniCislo;
    if (int.TryParse(prvniCisloText, out prvniCislo))
    {
        Console.WriteLine("Zadejte druhé èíslo:");
        string druheCisloText = Console.ReadLine();
        int druheCislo;
        if (int.TryParse(druheCisloText, out druheCislo))
        {
            Console.WriteLine("Zadejte operand:");
            string operand = Console.ReadLine();

            Console.WriteLine("Výsledek:");
            switch (operand)
            {
                case "+":
                    Console.WriteLine(prvniCislo + druheCislo);
                    break;
                case "-":
                    Console.WriteLine(prvniCislo - druheCislo);
                    break;
                case "*":
                    Console.WriteLine(prvniCislo * druheCislo);
                    break;
                case "/":
                    Console.WriteLine((decimal)prvniCislo / druheCislo);
                    break;
                default:
                    Console.WriteLine("Neplatný operand.");
                    break;
            }
        }
        else
        {
            Console.WriteLine($"{druheCisloText} není èíslo.");
        }
    }
    else
    {
        Console.WriteLine($"{prvniCisloText} není èíslo.");
    }

    Console.ReadLine();
}
```
* program je funkèní a byly u nìho ošetøeny chyby vyplývající ze vstupu uživatele, jeho zápis je však ménì èitelný a nedodržuje nìkteré základní principy
	* v kódu se nìkteré èásti opakují;
	* jsou zde použity zanoøené podmínky, které ztìžují èitelnost kódu.

### Step 3 - Refactoring kódu
* v tomto kroce je proveden *refactoring* kódu - jedná se o úpravu, která zachovává funkènost, ale vylepšuje èitelnost kódu (viz [zde](https://cs.wikipedia.org/wiki/Refaktorov%C3%A1n%C3%AD));
* toto je zøejmé z tìla hlavní metody (tento zápis by mìl být èitelný i pro nezasvìcené)
```c#
while (true)
{
    var prvniCislo = GetCisloZeVstupu("Zadejte první èíslo:");
    var druheCislo = GetCisloZeVstupu("Zadejte druhé èíslo:");
    var operand = GetOperand();

    Console.WriteLine("Výsledek:");
    switch (operand)
    {
        case "+":
            Console.WriteLine(GetSoucet(prvniCislo, druheCislo));
            break;
        case "-":
            Console.WriteLine(GetRozdil(prvniCislo, druheCislo));
            break;
        case "*":
            Console.WriteLine(GetSoucin(prvniCislo, druheCislo));
            break;
        case "/":
            Console.WriteLine(GetPodil(prvniCislo, druheCislo));
            break;
        default:
            Console.WriteLine("Neplatný operand.");
            break;
    }

    Console.ReadLine();
}
```
* metoda `GetCisloZeVstupu`
```c#
private static int GetCisloZeVstupu(string textPozadavku)
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

private static bool TryGetCislo(string cisloText, out int cislo)
{

    if (!int.TryParse(cisloText, out cislo))
    {
        Console.WriteLine("Zadaný vstup není èíslo.");
        return false;
    }
    return true;
}
```
* metoda `GetOperand`
```c#
private static string GetOperand()
{
    Console.WriteLine("Zadejte operand:");
    return Console.ReadLine();
}
```
* metody pro výpoèet výsledku
```c#
private static int GetSoucet(int x, int y)
{
    int soucet = x + y;
    return soucet;
}

private static int GetRozdil(int x, int y)
{
    return x - y;
}

private static int GetSoucin(int x, int y)
{
    return x * y;
}

private static int GetPodil(int x, int y)
{
    return x / y;
}
```
* kód je již lépe èitelný, ale obsah souboru `Program.cs` se celkem rozrostl, což není správné - øešení tohoto problému je pøedmìtem následujícího úkolu.

