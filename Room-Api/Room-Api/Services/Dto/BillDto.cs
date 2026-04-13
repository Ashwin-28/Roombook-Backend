namespace Room_Api.Services.Dto
{
    public class BillDto
    {
        public int BookingId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
    }
}
