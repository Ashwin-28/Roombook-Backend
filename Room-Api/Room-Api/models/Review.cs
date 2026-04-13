namespace Room_Api.models
{
    public class Review
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int Rating { get; set; }             // 1-5
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
