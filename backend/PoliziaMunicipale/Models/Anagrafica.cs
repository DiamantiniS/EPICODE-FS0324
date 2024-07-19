using System;
using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipale.Models
{
    public class Anagrafica
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cognome { get; set; }

        public string Indirizzo { get; set; }

        public string Citta { get; set; }

        public string CAP { get; set; }

        [StringLength(16)]
        public string Cod_Fisc { get; set; }

       
    }
}
