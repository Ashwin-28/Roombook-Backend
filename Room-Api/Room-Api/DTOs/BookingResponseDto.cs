namespace Room_Api.DTOs
{
    public class BookingResponseDto
    {
        public int BookingId { get; set; }
        public string RoomType { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfDays { get; set; }
        public int NumberOfRooms { get; set; }
        public string Status { get; set; }
        public BillDto Bill { get; set; }
    }
}
