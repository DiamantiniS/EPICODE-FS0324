namespace esercizio_18_07.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public int ClientId { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime ShipmentDate { get; set; }
        public decimal Weight { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationAddress { get; set; }
        public string RecipientName { get; set; }
        public decimal ShippingCost { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }

        public Client Client { get; set; }
        public ICollection<ShipmentUpdate> ShipmentUpdates { get; set; }
    }
}
