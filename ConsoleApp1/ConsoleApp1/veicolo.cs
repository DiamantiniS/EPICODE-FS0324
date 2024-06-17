using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Veicolo
{
    public string Marca { get; set; }
    public string Modello { get; set; }
    public int Anno { get; set; }

    public void StampaDettagli()
    {
        Console.WriteLine($"Marca: {Marca}, Modello: {Modello}, Anno: {Anno}");
    }
}
