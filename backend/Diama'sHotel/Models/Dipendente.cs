namespace Diama_sHotel.Models
{
    public class Dipendente
    {
        public int IDDipendente { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Ruolo { get; set; }
    }
}
