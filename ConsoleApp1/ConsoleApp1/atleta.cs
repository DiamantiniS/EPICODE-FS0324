using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Atleta
{
    public string Nome { get; set; }
    public int Età { get; set; }
    public string Sport { get; set; }

    public void StampaDettagli()
    {
        Console.WriteLine($"Nome: {Nome}, Età: {Età}, Sport: {Sport}");
    }
}
