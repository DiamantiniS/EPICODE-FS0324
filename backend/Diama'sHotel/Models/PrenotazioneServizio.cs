namespace Diama_sHotel.Models
{
    public class PrenotazioneServizio
    {
        public int IDPrenotazioneServizio { get; set; }
        public int IDPrenotazione { get; set; }
        public int IDServizio { get; set; }
        public DateTime Data { get; set; }
        public int Quantità { get; set; }
        public decimal PrezzoTotale { get; set; }
    }
}
