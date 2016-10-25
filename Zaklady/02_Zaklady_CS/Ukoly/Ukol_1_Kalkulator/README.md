�kol �. 1 - Kalkul�tor
======================

### Zad�n�
* vytvo�te konzolovou aplikaci, kter� bude umo��ovat prov�d�t z�kladn� matematick� operace (s��t�n�, od��t�n�, n�soben�, d�len�) na dvou ��slech.

### Step 1 - Z�kladn� forma
* takto m��e vypadat jeden z prvn�ch program� p�i absolvov�n� �kolen�
```c#
Console.WriteLine("Zadejte prvn� ��slo:");
string prvniCisloText = Console.ReadLine();
int prvniCislo = int.Parse(prvniCisloText);

Console.WriteLine("Zadejte druh� ��slo:");
string druheCisloText = Console.ReadLine();
int druheCislo = int.Parse(druheCisloText);

Console.WriteLine("Zadejte operand:");
string operand = Console.ReadLine();

Console.WriteLine("V�sledek:");
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
* program je sice funk�n�, ale m� n�kolik nedostatk�
	* nen� zde o�et�en vstup u�ivatele - pokud bude do programu zad�na hodnota, kterou program neo�ek�v� (nap�. p�smeno m�sto ��sla), tak program spadne;
	* v�sledek d�len� bude v tomto p��pad� v�dy cel� ��slo (i p�i d�len� se zbytkem);
	* program by mohl b�et ve smy�ce, dokud se ho u�ivate nerozhodne zav��t s�m.

### Step 2 - O�et�en� chyb
* v tomto kroce byly provedeny �pravy na z�klad� nedostatk�, kter� byly definov�ny v kroce 1
	* aplikace ji� nespadne p�i zad�n� neo�ek�van�ho vstupu;
	* program vrac� v�sledek d�len� jako desetinn� ��slo;
	* program b�� ve smy�ce.
```c#
while (true)
{
    Console.WriteLine("Zadejte prvn� ��slo:");
    string prvniCisloText = Console.ReadLine();
    int prvniCislo;
    if (int.TryParse(prvniCisloText, out prvniCislo))
    {
        Console.WriteLine("Zadejte druh� ��slo:");
        string druheCisloText = Console.ReadLine();
        int druheCislo;
        if (int.TryParse(druheCisloText, out druheCislo))
        {
            Console.WriteLine("Zadejte operand:");
            string operand = Console.ReadLine();

            Console.WriteLine("V�sledek:");
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
                    Console.WriteLine("Neplatn� operand.");
                    break;
            }
        }
        else
        {
            Console.WriteLine($"{druheCisloText} nen� ��slo.");
        }
    }
    else
    {
        Console.WriteLine($"{prvniCisloText} nen� ��slo.");
    }

    Console.ReadLine();
}
```
* program je funk�n� a byly u n�ho o�et�eny chyby vypl�vaj�c� ze vstupu u�ivatele, jeho z�pis je v�ak m�n� �iteln� a nedodr�uje n�kter� z�kladn� principy
	* v k�du se n�kter� ��sti opakuj�;
	* jsou zde pou�ity zano�en� podm�nky, kter� zt�uj� �itelnost k�du.

### Step 3 - Refactoring k�du
* v tomto kroce je proveden *refactoring* k�du - jedn� se o �pravu, kter� zachov�v� funk�nost, ale vylep�uje �itelnost k�du (viz [zde](https://cs.wikipedia.org/wiki/Refaktorov%C3%A1n%C3%AD));
* toto je z�ejm� z t�la hlavn� metody (tento z�pis by m�l b�t �iteln� i pro nezasv�cen�)
```c#
while (true)
{
    var prvniCislo = GetCisloZeVstupu("Zadejte prvn� ��slo:");
    var druheCislo = GetCisloZeVstupu("Zadejte druh� ��slo:");
    var operand = GetOperand();

    Console.WriteLine("V�sledek:");
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
            Console.WriteLine("Neplatn� operand.");
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
        Console.WriteLine("Zadan� vstup nen� ��slo.");
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
* metody pro v�po�et v�sledku
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
* k�d je ji� l�pe �iteln�, ale obsah souboru `Program.cs` se celkem rozrostl, co� nen� spr�vn� - �e�en� tohoto probl�mu je p�edm�tem n�sleduj�c�ho �kolu.

