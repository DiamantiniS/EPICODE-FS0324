public class AggiornamentoSpedizione
{
    public int IDAggiornamento { get; set; }
    public int IDSpedizione { get; set; }
    public string Stato { get; set; }
    public string Luogo { get; set; }
    public string Descrizione { get; set; }
    public DateTime DataOraAggiornamento { get; set; }
}
