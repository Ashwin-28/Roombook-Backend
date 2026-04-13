using System.Collections.Generic;

namespace Room_Api.Services.Dto
{
    public class RoomDetailDto
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public List<string> Amenities { get; set; } = new List<string>();
    }
}
