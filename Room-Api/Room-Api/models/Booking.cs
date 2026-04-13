using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Room_Api.models
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfDays { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal DynamicPriceAmount { get; set; }  // Surge/seasonal
        public decimal ServiceAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }          // Pending, Confirmed, Cancelled
        public DateTime BookedAt { get; set; }
        public ICollection<BookingService> BookingServices { get; set; }
        public Bill Bill { get; set; }
        public Review Review { get; set; }
    }
}
