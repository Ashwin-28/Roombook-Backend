namespace Room_Api.models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }        // Single, Double, Suite
        public string Description { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
        public int TotalRooms { get; set; }
        public int AvailableRooms { get; set; }
        public decimal BasePrice { get; set; }      // Base price per night
        public bool IsAvailable { get; set; }
        public int MaxOccupancy { get; set; }
        public ICollection<RoomAmenity> RoomAmenities { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
