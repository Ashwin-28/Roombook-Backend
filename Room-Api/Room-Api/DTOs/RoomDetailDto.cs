using System.Collections.Generic;

namespace Room_Api.DTOs
{
    public class RoomDetailDto
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public int AvailableRooms { get; set; }
        public int MaxOccupancy { get; set; }
        public List<AmenityDto> Amenities { get; set; } = new List<AmenityDto>();
        public List<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }
}
