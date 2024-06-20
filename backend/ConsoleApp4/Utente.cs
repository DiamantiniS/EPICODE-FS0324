using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Utente
{
    public static string Username { get; private set; }
    public static string Password { get; private set; }
    public static DateTime? LoginTime { get; private set; }
    private static List<DateTime> accessHistory = new List<DateTime>();

    public static bool Login(string username, string password, string confirmPassword)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Username non può essere vuoto.");
            return false;
        }

        if (password != confirmPassword)
        {
            Console.WriteLine("Le password non coincidono.");
            return false;
        }

        Username = username;
        Password = password;
        LoginTime = DateTime.Now;
        accessHistory.Add((DateTime)LoginTime);
        Console.WriteLine($"Login effettuato con successo alle {LoginTime}");
        return true;
    }

    public static void Logout()
    {
        if (Username == null)
        {
            Console.WriteLine("Nessun utente è attualmente loggato.");
            return;
        }

        Console.WriteLine($"Logout effettuato per l'utente {Username}.");
        Username = null;
        Password = null;
        LoginTime = null;
    }

    public static void VerificaOraDataLogin()
    {
        if (LoginTime == null)
        {
            Console.WriteLine("Nessun utente è attualmente loggato.");
            return;
        }

        Console.WriteLine($"L'utente {Username} ha effettuato il login alle {LoginTime}");
    }

    public static void ListaAccessi()
    {
        if (accessHistory.Count == 0)
        {
            Console.WriteLine("Nessun accesso registrato.");
            return;
        }

        Console.WriteLine("Storico degli accessi:");
        foreach (var access in accessHistory)
        {
            Console.WriteLine(access);
        }
    }
}