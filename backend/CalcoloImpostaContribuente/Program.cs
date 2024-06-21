class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserisci i dati del contribuente:");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Cognome: ");
        string cognome = Console.ReadLine();

        DateTime dataNascita;
        Console.Write("Data di nascita (gg/mm/aaaa): ");
        while (!DateTime.TryParse(Console.ReadLine(), out dataNascita))
        {
            Console.Write("Formato non valido. Riprova (gg/mm/aaaa): ");
        }

        Console.Write("Codice Fiscale: ");
        string codiceFiscale = Console.ReadLine();

        string sesso;
        Console.Write("Sesso (M/F): ");
        while (true)
        {
            sesso = Console.ReadLine().ToUpper();
            if (sesso == "M" || sesso == "F")
                break;
            Console.Write("Inserisci un valore valido (M/F): ");
        }

        Console.Write("Comune di Residenza: ");
        string comuneResidenza = Console.ReadLine();

        decimal redditoAnnuale;
        Console.Write("Reddito Annuale: ");
        while (!decimal.TryParse(Console.ReadLine(), out redditoAnnuale))
        {
            Console.Write("Formato non valido. Riprova: ");
        }

        Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

        decimal imposta = contribuente.CalcolaImposta();

        Console.WriteLine("\n==================================================");
        Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
        Console.WriteLine(contribuente.ToString());
        Console.WriteLine($"Reddito dichiarato: {redditoAnnuale:C}");
        Console.WriteLine($"IMPOSTA DA VERSARE: {imposta:C}");
    }
}