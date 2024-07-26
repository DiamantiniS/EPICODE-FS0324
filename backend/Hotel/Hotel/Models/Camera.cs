using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Camera
    {
        [Key]
        public int Numero { get; set; }

        [Required]
        public string Descrizione { get; set; }

        [Required]
        public string Tipologia { get; set; }

        [Required]
        public decimal TariffaBase { get; set; }
    }
}
