using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo Codice Fiscale è obbligatorio.")]
        public string CodiceFiscale { get; set; }

        [Required(ErrorMessage = "Il campo Cognome è obbligatorio.")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Il campo Nome è obbligatorio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il campo Città è obbligatorio.")]
        public string Citta { get; set; }

        [Required(ErrorMessage = "Il campo Provincia è obbligatorio.")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Il campo Email è obbligatorio.")]
        [EmailAddress(ErrorMessage = "Indirizzo Email non valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Il campo Cellulare è obbligatorio.")]
        public string Cellulare { get; set; }
    }
}
