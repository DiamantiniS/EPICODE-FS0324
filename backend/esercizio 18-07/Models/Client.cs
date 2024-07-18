namespace esercizio_18_07.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public bool IsCompany { get; set; }
        public string FiscalCode { get; set; }
        public string VatNumber { get; set; }

        // Aggiungi questa proprietà per risolvere l'errore
        public ICollection<Shipment> Shipments { get; set; }
    }
}
