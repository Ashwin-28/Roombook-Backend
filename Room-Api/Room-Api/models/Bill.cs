namespace Room_Api.models
{
    public class Bill
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal DemandSurcharge { get; set; }  // Dynamic pricing add-on
        public decimal SeasonSurcharge { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime GeneratedAt { get; set; }
        public bool IsPaid { get; set; }
    }
}
