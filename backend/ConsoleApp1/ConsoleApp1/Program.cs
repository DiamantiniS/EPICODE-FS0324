// See https://aka.ms/new-console-template for more information
using System;

namespace ConsoleAppExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creazione delle istanze delle classi
            Atleta atleta = new Atleta { Nome = "Mario Rossi", Età = 25, Sport = "Calcio" };
            Dipendente dipendente = new Dipendente { Nome = "Luca Bianchi", Posizione = "Manager", Stipendio = 50000 };
            Animale animale = new Animale { Nome = "Fido", Specie = "Cane", Età = 3 };
            Veicolo veicolo = new Veicolo { Marca = "Fiat", Modello = "500", Anno = 2020 };

            // Stampa dei dettagli delle istanze
            atleta.StampaDettagli();
            dipendente.StampaDettagli();
            animale.StampaDettagli();
            veicolo.StampaDettagli();
        }
    }
}