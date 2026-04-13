using System;

namespace Room_Api.Services.Dto
{
    public class PriceEstimateRequestDto
    {
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfRooms { get; set; }
    }
}
