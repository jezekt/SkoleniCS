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