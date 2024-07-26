namespace Diama_sHotel.Models
{
    public class Prenotazione
    {
        public int IDPrenotazione { get; set; }
        public int IDCliente { get; set; }
        public int IDCamera { get; set; }
        public DateTime DataPrenotazione { get; set; }
        public int NumeroProgressivo { get; set; }
        public int Anno { get; set; }
        public DateTime PeriodoDal { get; set; }
        public DateTime PeriodoAl { get; set; }
        public decimal? CaparraConfirmatoria { get; set; }  
        public decimal TariffaApplicata { get; set; }
        public string TipologiaSoggiorno { get; set; }
    }
}
