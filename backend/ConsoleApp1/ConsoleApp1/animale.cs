using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Animale
{
    public string Nome { get; set; }
    public string Specie { get; set; }
    public int Età { get; set; }

    public void StampaDettagli()
    {
        Console.WriteLine($"Nome: {Nome}, Specie: {Specie}, Età: {Età}");
    }
}
