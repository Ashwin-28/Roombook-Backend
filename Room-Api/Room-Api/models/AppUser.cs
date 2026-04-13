using Microsoft.AspNetCore.Identity;

namespace Room_Api.models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
