using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dipendente
{
    public string Nome { get; set; }
    public string Posizione { get; set; }
    public double Stipendio { get; set; }

    public void StampaDettagli()
    {
        Console.WriteLine($"Nome: {Nome}, Posizione: {Posizione}, Stipendio: {Stipendio}");
    }
}
