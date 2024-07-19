namespace PoliziaMunicipale.Models
{
    public class VerbaleViolazione
    {
        public int VerbaleId { get; set; }
        public Verbale Verbale { get; set; }

        public int ViolazioneId { get; set; }
        public TipoViolazione Violazione { get; set; }
    }
}
