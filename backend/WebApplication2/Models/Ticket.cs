using System.ComponentModel.DataAnnotations;

namespace CinemaMVC.Models
{
    public class Ticket
    {
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "La sala è obbligatoria")]
        public string Room { get; set; }

        public bool IsReduced { get; set; }
    }
}
