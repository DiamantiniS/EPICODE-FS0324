using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipale.Models
{
    public class TipoViolazione
    {
        public int Id { get; set; }

        [Required]
        public string Descrizione { get; set; }

        
    }
}
