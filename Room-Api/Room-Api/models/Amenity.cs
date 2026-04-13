namespace Room_Api.models
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }            // WiFi, Pool, Gym...
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }        // "Amenity" or "Service"
        public ICollection<RoomAmenity> RoomAmenities { get; set; }
    }
}
