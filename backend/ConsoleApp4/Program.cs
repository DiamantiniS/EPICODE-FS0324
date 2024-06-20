using System;

namespace LoginApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============OPERAZIONI==============");
                Console.WriteLine("Scegli l'operazione da effettuare:");
                Console.WriteLine("1.: Login");
                Console.WriteLine("2.: Logout");
                Console.WriteLine("3.: Verifica ora e data di login");
                Console.WriteLine("4.: Lista degli accessi");
                Console.WriteLine("5.: Esci");
                Console.WriteLine("========================================");
                Console.Write("Scelta: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        EseguiLogin();
                        break;
                    case "2":
                        Utente.Logout();
                        break;
                    case "3":
                        Utente.VerificaOraDataLogin();
                        break;
                    case "4":
                        Utente.ListaAccessi();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }

                Console.WriteLine("Premi un tasto per continuare...");
                Console.ReadKey();
            }
        }

        static void EseguiLogin()
        {
            Console.Write("Inserisci username: ");
            string username = Console.ReadLine();

            Console.Write("Inserisci password: ");
            string password = Console.ReadLine();

            Console.Write("Conferma password: ");
            string confirmPassword = Console.ReadLine();

            Utente.Login(username, password, confirmPassword);
        }
    }
}