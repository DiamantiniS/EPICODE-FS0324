namespace esercizio_18_07.Models
{
    public class ShipmentUpdate
    {
        public int UpdateId { get; set; }
        public int ShipmentId { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime UpdateDate { get; set; }

        public Shipment Shipment { get; set; }
    }
}
