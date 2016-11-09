3 Objektově orientované programování
====================================

* česky psaný tutoriál k základům OOP je [zde](http://www.itnetwork.cz/csharp/oop);
* článek na wikipedii [zde](https://cs.wikipedia.org/wiki/Objektov%C4%9B_orientovan%C3%A9_programov%C3%A1n%C3%AD).

### 1 Objekty
* v [úkolech](https://github.com/jezekt/SkoleniCS/tree/master/Zaklady/02_Zaklady_CS/Ukoly) předchozího bloku se vytvářel kalkulátor, který bude schopný provádět základní matematické operace;
* v [prvním úkolu](https://github.com/jezekt/SkoleniCS/tree/master/Zaklady/02_Zaklady_CS/Ukoly/Ukol_1_Kalkulator#Úkol-č-1---kalkulátor) byl vytvořen funkční program, ve kterém byl ošetřen vstup uživatele. Celý kód byl však součástí souboru `Program.cs`. Takový zápis by se s přibývající funkčností stal nepřehledný;
* výsledkem [druhého úkolů](https://github.com/jezekt/SkoleniCS/tree/master/Zaklady/02_Zaklady_CS/Ukoly/Ukol_2_Trida_Kalkulator#Úkol-č-2---třída-kalkulátor) tedy bylo přepsání kódu do tříd. Byly stanoveny tři oblasti (*matematické operace*, *čtení vstupu* a *řízení procesu výpočtu*), za které zodpovídaly tři různé třídy. Vytvoření tříd, které jsou zodpovědné za určitou oblast, byl první krok k přechodu ze *strukturovaně* psaného kódu na *objektově* psaný kód. Při spuštění programu jsou vždy vytvořeny tři objekty, které zabezpečují výpočet.

>Poznámka - Třída reprezentuje datový typ, který je vytvořen programátorem (např. [string](https://msdn.microsoft.com/en-us/library/362314fe.aspx) - alias pro datový typ `System.String`, je definován ve třídě [String](https://msdn.microsoft.com/en-us/library/system.string.aspx)). Třída [Kalkulator](https://github.com/jezekt/SkoleniCS/tree/master/Zaklady/02_Zaklady_CS/Ukoly/Ukol_2_Trida_Kalkulator#třída-kalkulátor) je tedy datový typ, ve kterém je definováno, jak provádět základní matematické operace (*sčítání*, *odčítání*, *násobení* a *dělení*). Samotné provedení těcho operací však vykonává *objekt*, který je datového typu `Kalkulator` - ¹jinak řečeno instance třídy `Kalkulator`.
>
>¹ mezi objektem a instancí je určitý rozdíl - pro potřeby pochopení OOP budou pokládány za rovnocenné termíny.


#### Zjednodušený příklad
„Představte si třídu jako návod na sestavení nějakého stroje např. robota. Třída `Kalkulator` definuje robota, který umí počítat. Pokud chci, využívat funkčnost takového robota, tak jej musím nejprve vytvořit. To udělám pomocí klíčového slova *new* (např. *var robotPoctar = new Kalkulator()*). 

Vznikne mi tak nový objekt/robot typu `Kalkulator`, který je schopen provádět sčítání, odčítání, násobení a dělení. Když chci znát výsledek součtu dvou čísel, tak se zeptám vytvořeného robota, který byl přiřazen do proměnné *robotPoctar*. Dotaz na výsledek bude vypadat takto: *var vysledekSouctu = robotPoctar.GetSoucet(1, 1)*. 

Dále potřebuji nějakého robota, který bude číst vstup uživatele. K tomu mi bude sloužit robot typu `ConsoleInputReader`. Opět si ho vytvořím pomocí slovíčka *new*. Mám tedy již dva roboty - jeden, který umí počítat a druhý, který umí číst z konzole. 

Potřeboval bych ještě nějakého, který využije ty dva a společně tak uživateli umožní používat konzoli, jako jednoduchou kalkulačku. K takovému účelu si vytvořím robota typu `ConsoleEquationSolver` a při jeho stavbě použiji dva zmíněné roboty. Sestavený robot typu `ConsoleEquationSolver` poté samostatně řídí průběh výpočtu (od čtení z konzole, přes výpočet až po výpis výsledku).“

>Poznámka - Ve zjednodušeném příkladu se programátor na kód nedívá jako na výčet proměnných a metod poskládaných do funkčního celku, ale chápe ho jako prostředek, pomocí kterého vytváří vlastní prostředí, kde **objekty** zabezpečují fungování systému.

### 2 Dědičnost a polymorfismus
* infomrace o dědičnosti a polymorfismu lze získat [zde](http://www.itnetwork.cz/csharp/oop/c-sharp-tutorial-dedicnost-a-polymorfismus);
* v následujících krocích je názorné vysvětlení

#### Step 1 - Logování
* byl zadán požadavek, aby současný konzolový kalkulátor umožňoval záznam kroků uživatele do textového souboru. Pro naplnění tohoto požadavku byla vytvořena třída `TxtFileLogger`

```c#
public class TxtFileLogger
{
    private readonly string _filePath;


    public void Log(LogLevel level, string message)
    {
        var text = $"{DateTime.Now} {level}: {message}" + Environment.NewLine;
        File.AppendAllText(_filePath, text);
    }


    public TxtFileLogger(string filePath)
    {
        _filePath = filePath;
    }
}
```

```c#
public enum LogLevel
{
    Information,
    Warning,
    Error
}
```

* byla upravena třída `ConsoleEquationSolver` tak, aby využila funkčnosti typu `TxtFileLogger` a zaznamenávala kroky uživatele

```c#
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
```

* změna hlavní metody programu - k argumentům konstruktoru třídy `ConsoleEquationSolver` byl přidán vytvořený objekt typu `TxtFileLogger` (ten ke svému vytvoření vyžaduje cestu souboru, do kterého se bude provádět logování - je použita cesta, ze které se spouští aplikace)

```c#
static void Main()
{
    var logger = new TxtFileLogger(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"));
    var equationSolver = new ConsoleEquationSolver(new Kalkulator(), new ConsoleInputReader(), logger);
    while (true)
    {
        equationSolver.TwoVariablesEquation();
        Console.ReadLine();
    }
}
```

#### Step 2 - Logování do jiného typu souboru
* byl zadán požadavek, aby se logování neprovádělo do souboru *.txt, ale do souboru *.xml. Pro naplnění tohoto požadavku byla vytvořena třída `XmlFileLogger`

```c#
public class XmlFileLogger
{
    private const string LogsElementName = "Logs";
    private const string LogElementName = "Log";
    private const string DateTimeElementName = "DateTime";
    private const string LevelElementName = "Level";
    private const string MessageElementName = "Message";

    private readonly string _filePath;


    public void Log(LogLevel level, string message)
    {
        if (!File.Exists(_filePath))
        {
            CreateNewFileAndLog(level, message);
        }
        else
        {
            AddLogToExistingFile(level, message);
        }
    }


    public XmlFileLogger(string filePath)
    {
        _filePath = filePath;
    }


    private void CreateNewFileAndLog(LogLevel level, string message)
    {
        var xmlWriterSettings = new XmlWriterSettings { Indent = true, NewLineOnAttributes = true };
        using (var xmlWriter = XmlWriter.Create(_filePath, xmlWriterSettings))
        {
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement(LogsElementName);

            xmlWriter.WriteStartElement(LogElementName);
            xmlWriter.WriteElementString(DateTimeElementName, DateTime.Now.ToString(CultureInfo.CurrentCulture));
            xmlWriter.WriteElementString(LevelElementName, level.ToString());
            xmlWriter.WriteElementString(MessageElementName, message);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            xmlWriter.Close();
        }
    }
    private void AddLogToExistingFile(LogLevel level, string message)
    {
        var xDocument = XDocument.Load(_filePath);
        var root = xDocument.Element(LogsElementName);
        if (root != null)
        {
            var rows = root.Descendants(LogElementName);
            var lastRow = rows.Last();
            lastRow.AddAfterSelf(
                new XElement(LogElementName, new XElement(DateTimeElementName, DateTime.Now.ToString(CultureInfo.CurrentCulture)),
                                             new XElement(LevelElementName, level.ToString()),
                                             new XElement(MessageElementName, message)));
            xDocument.Save(_filePath);
        }
    }
}
```

* v hlavní metodě a ve třídě `ConsoleEquationSolver` byl změněn použitý typ loggeru.

#### Step 3 - Logování dle výběru
* byl zadán požadavek, aby si uživatel mohl vybrat mezi logováním do souboru *.txt a *.xml;
* předchozí řešení, kdy byl v kódu změněn typ loggeru již fungovat nebude, jelikož v běhu programu nelze zadaný typ měnit;
* je proto potřeba vytvořit typ, který bude reprezentovat oba výše zmíněné loggery. `TxtFileLogger` a `XmlFileLogger` mají následující společné znaky:
	* oba slouží k logování do souboru;
	* oba si v konstruktoru předávají cestu souboru;
	* oba mají metodu *Log(LogLevel, string)*;
* bude tedy vytvořen typ `FileLoggerBase`, který výše popsané znaky sdruží a od kterého budou oba loggery dědit.

##### FileLoggerBase

```c#
public abstract class FileLoggerBase
{
    protected readonly string FilePath;


    public abstract void Log(LogLevel level, string message);


    protected FileLoggerBase(string filePath)
    {
        FilePath = filePath;
    }
}
```

* slovo `abstract` v deklaraci třídy říká, že se jedná o abstraktní třídu. Taková třída nemůže být instancována (nelze z ní vytvořit objekt). Objekty mohou být vytvořeny pouze ze tříd, které od této třídy dědí, pokud nejsou také abstraktní;
* v konstruktoru třídy je předána cesta souboru. Tato cesta je dále naplněna do proměnné *FilePath*. Modifikátor `protected` omezuje přístupnost proměnné pouze na třídu `FileLoggerBase` samotnou a na všechny její potomky;
* abstraktní metoda *Log(LogLevel, string)* nemá žádné tělo. To vyplývá právě z toho, že je abstraktní. Abstraktní členy třídy nemají implementaci. Pouze říkají, že potomci, kteří od této třídy dědí, musí tyto členy implementovat.

##### Úprava TxtFileLogger

* `TxtFileLogger` a `XmlFileLogger` budou nyní dědit od třídy `FileLoggerBase` (ukázáno na `TxtFileLogger`, úpravy v `XmlFileLogger` jsou obdobné)

```c#
public class TxtFileLogger : FileLoggerBase
{
    public override void Log(LogLevel level, string message)
    {
        var text = $"{DateTime.Now} {level}: {message}" + Environment.NewLine;
        File.AppendAllText(FilePath, text);
    }


    public TxtFileLogger(string filePath) : base(filePath)
    {
    }
}
```

* dědičnost se nastavuje v deklaraci třídy. Třída, od které se dědí (*base class* - *mateřská třída*), se napíše za dvojtečku;
* jelikož mateřská třída obsahuje proměnnou *FilePath*, mohla být původní privátní proměnná *_filePath* odstraněna. V konstruktoru třídy však musí být předána cesta souboru mateřské třídě (za konstruktorem *: base(filePath)*);
* mateřská třída také říká, že každý potomek musí implementovat metodu *Log(LogLevel, string)*. Třída `TxtFileLogger` tedy musí mít ve svém zápisu přepsání (`override`) této metody.

##### Změna typu loggeru
* všude, kde byl doposud použit typ `XmlFileLogger` se nyní použije společný typ `FileLoggerBase`.

##### Výběr loggeru - ConsoleFileLoggerFactory
* zbývá vytvořit nějaký typ, který bude umožňovat výběr loggeru.

```c#
public class ConsoleFileLoggerFactory
{
    private readonly string _folderPath;


    public FileLoggerBase Create()
    {
        while (true)
        {
            Console.WriteLine("Vyberte typ souboru pro logování: *.txt (T) nebo *.xml (X)?");
            var input = Console.ReadLine()?.ToUpper();
            if (input == "T")
            {
                return new TxtFileLogger(Path.Combine(_folderPath, "log.txt"));
            }
            if (input == "X")
            {
                return new XmlFileLogger(Path.Combine(_folderPath, "log.xml"));
            }
            Console.WriteLine("Neplatný výběr.");
        }
    }


    public ConsoleFileLoggerFactory(string folderPath)
    {
        _folderPath = folderPath;
    }
}
```

##### Hlavní metoda programu
* do hlavní metody programu bylo doplněno vytvoření objektu typu `ConsoleFileLoggerFactory` a jeho následné použití při vytvoření loggeru

```c#
static void Main()
{
    var loggerFactory = new ConsoleFileLoggerFactory(AppDomain.CurrentDomain.BaseDirectory);
    var logger = loggerFactory.Create();
    var equationSolver = new ConsoleEquationSolver(new Kalkulator(), new ConsoleInputReader(), logger);
    while (true)
    {
        equationSolver.TwoVariablesEquation();
        Console.ReadLine();
    }
}
```

#### Step 4 - Logování kamkoliv
* byl zadán požadavek, aby se logování mohlo provádět kromě souborů také do konzole a časem možná i do databáze;
* k naplnění tohoto požadavku již nebude stačit třída `FileLoggerBase`, jelikož ta se dá použít jen na zápis do souborů. Požadavek je však i na zápis do konzole;
* bude tedy potřeba vytvořit typ společný pro všechny loggery. Řešením by bylo vytvořit typ `LoggerBase`, který by měl pouze jednu abstraktní metodu *Log(LogLevel, string)* a nic víc. Od tohoto typu by pak všechny loggery dědily;
* mateřská třída by neměla žádnou implementaci a ani by neumožňovala mít nějaký stav (např. ve vlastnosti nebo fieldu). V tom případě by bylo lepší místo *abstraktní třídy* použít *rozhraní* ([interface](https://msdn.microsoft.com/cs-cz/library/87d83y5b.aspx));

##### Interface
* rozhraní lze považovat za kotrakt, který říká, co třída k němu přihlášená musí implementovat;
* třída implementuje rozhraní (přihlašuje se ke kontraktu) stejně, jako by od něj dědila;
* zásadní výhoda oproti dědění z mateřské třídy je ta, že dědit lze pouze z jednoho typu, kdežto implementovat lze několik rozhraní;

##### Zjednodušený příklad
„Pro lepší představu opět použiji příklad s roboty. Než přišel požadavek na logování i do konzole, fungovala aplikace následovně:

1. vytvořila se výrobní linka na roboty (linka typu `ConsoleFileLoggerFactory`), kteří dokáží logovat do souboru (z linky budou vždy vycházet navenek stejní roboti, avšak s různými vnitřními díly - v závislosti na druhu souboru);
2. uživatel vybral, do jakého souboru chce logovat a linka vytvořila robota. Jeho vnitřní části odpovídají volbě uživatele. Linka při výrobě použila společné tělo (typu `FileLoggerBase`, které má proměnnou *FilePath* a dále výrobce uvádí, že umí logovat - abstraktní metoda *Log(LogLevel, string)*), do kterého dodala vnitřní části podle účelu (*.txt nebo *.xml);
3. vytvořený logovací robot se poté společně s robotem, který umí počítat a robotem, který umí číst, použily při výrobě řídícího robota;
4. řídící robot poté v cyklu prováděl řízení výpočtu.

S příchodem požadavku na logování i do konzole se situace změnila. Robot, který by měl logovat do konzole nemůže být v těle, které je určeno pro logování do souboru. Obsahoval by proměnnou *FilePath*, která by mu byla k ničemu. Nebudeme tedy vytvářet nějaké konkrétní společné tělo pro všechny logovací roboty, ale místo toho řekneme, že chceme **nějakého** robota, který **umí logovat** (tj. implementuje metodu *Log(LogLevel, string)*). Přesně k tomuto slouží rozhraní. Vytvoříme si tedy rozhraní `ILogger`, které nám bude říkat, že jakýkoliv implementující typ bude muset být schopen provést po svém metodu *Log(LogLevel, string)*.“

##### Rozhraní ILogger
* název každého rozhraní začíná velkým písmenem *"I"* (*i - interface*). Proto název rozhraní loggeru je *ILogger*;
* rozhraní není nic jiného, než jakýsi kontrakt, který říká, co typ implementující toto rozhraní bude umět;
* v rozhraní se definuje pouze funkčnost, která je veřejně přístupná, tj. `public`. Z toho důvodu se v rozhraní neuvádí modifikátor přístupnosti;
* definice rozhraní `ILogger`

```c#
public interface ILogger
{
    void Log(LogLevel level, string message);
}
```

##### Třída ConsoleLoggerFactory
* tato třída slouží k vytváření loggerů (typu `ILogger`). Jediná věc, kterou objekt vytvořený touto třídou bude umět je logování (metoda *Log(LogLevel, string)*);
* třída `ConsoleLoggerFactory` vyžaduje pro své fungování instanci třídy `ConsoleFileLoggerFactory`. Instance je předána v konstruktoru.

```c#
public class ConsoleLoggerFactory
{
    private readonly ConsoleFileLoggerFactory _fileLoggerFactory;

    public ILogger Create()
    {
        while (true)
        {
            Console.WriteLine("Vyberte typ logování: konzole (K); soubor (S); debug output (D)?");
            var input = Console.ReadLine()?.ToUpper();
            if (input == "K")
            {
                return new ConsoleLogger();
            }
            if (input == "S")
            {
                return _fileLoggerFactory.Create();
            }
            if (input == "D")
            {
                return new TraceListenerLogger();
            }
            Console.WriteLine("Neplatný výběr.");
        }
    }


    public ConsoleLoggerFactory(ConsoleFileLoggerFactory fileLoggerFactory)
    {
        if (fileLoggerFactory == null) throw new ArgumentNullException();
        Contract.EndContractBlock();

        _fileLoggerFactory = fileLoggerFactory;
    }
}
```

##### ConsoleLogger a TraceListenerLogger
* tyto třídy umožňují logování do konzole a do výstupu ladění (Debug Output);
* obě třídy implementují rozhraní `ILogger` (stejně tak `FileLoggerBase` a tím i `TxtFileLogger` a `XmlFileLogger`)

```c#
public class ConsoleLogger : ILogger
{
    public void Log(LogLevel level, string message)
    {
        Console.WriteLine($"{DateTime.Now} {level}: {message}");
    }
}

public class TraceListenerLogger : ILogger
{
    public void Log(LogLevel level, string message)
    {
        Debug.Print($"{DateTime.Now} {level}: {message}");
    }
}
```

##### Změna typu loggeru
* všude, kde byl doposud použit typ `FileLoggerBase` se nyní použije rozhraní `ILogger`.

##### Hlavní metoda programu
* v hlavní metodě programu se nyní vytváří objekt typu `ConsoleLoggerFactory`, který ke svému fungování potřebuje objekt typu `ConsoleFileLoggerFactory`

```c#
static void Main()
{
    var loggerFactory = new ConsoleLoggerFactory(new ConsoleFileLoggerFactory(AppDomain.CurrentDomain.BaseDirectory));
    var logger = loggerFactory.Create();
    var equationSolver = new ConsoleEquationSolver(new Kalkulator(), new ConsoleInputReader(), logger);
    while (true)
    {
        equationSolver.TwoVariablesEquation();
        Console.ReadLine();
    }
}
```

* proměnná *logger* je nyní typu `ILogger`. V této proměnné mohou být objekty všech typů, které implementují rozhraní `ILogger` (tj. `FileLoggerBase`, `TxtFileLogger`, `XmlFileLogger`, `ConsoleLogger` a `TraceListenerLogger`). 