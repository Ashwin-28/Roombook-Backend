namespace Room_Api.DTOs
{
    public class RoomListDto
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public string ImageUrl { get; set; }
        public decimal BasePrice { get; set; }
        public decimal CurrentPrice { get; set; }   // After dynamic pricing
        public double Rating { get; set; }
        public bool IsAvailable { get; set; }
        public int AvailableRooms { get; set; }
    }
}
