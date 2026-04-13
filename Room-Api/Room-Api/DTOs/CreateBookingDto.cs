namespace Room_Api.DTOs
{
    public class CreateBookingDto
    {
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfRooms { get; set; }
        public List<BookingServiceItemDto> SelectedServices { get; set; }
    }
}
