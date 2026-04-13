namespace Room_Api.DTOs
{
    public class RoomDetailDto
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
        public decimal BasePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public int AvailableRooms { get; set; }
        public int MaxOccupancy { get; set; }
        public List<AmenityDto> Amenities { get; set; }
        public List<ReviewDto> Reviews { get; set; }
    }
}
