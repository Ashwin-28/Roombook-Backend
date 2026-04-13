namespace Room_Api.DTOs
{
    public class BillDto
    {
        public decimal RoomCharge { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal DemandSurcharge { get; set; }
        public decimal SeasonSurcharge { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
    }
}
