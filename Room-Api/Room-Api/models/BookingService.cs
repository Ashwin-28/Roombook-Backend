namespace Room_Api.models
{
    public class BookingService
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
