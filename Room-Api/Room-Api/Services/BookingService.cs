using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Room_Api.Data;
using Room_Api.Services.Dto;
using Room_Api.Services.Interfaces;

namespace Room_Api.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BookingResponseDto> CreateBookingAsync(CreateBookingDto dto, string userId)
        {
            var booking = new Room_Api.models.Booking
            {
                RoomId = dto.RoomId,
                CheckInDate = dto.CheckInDate,
                CheckOutDate = dto.CheckOutDate,
                NumberOfRooms = dto.NumberOfRooms,
                UserId = userId,
                Status = "Confirmed",
                BookedAt = System.DateTime.UtcNow
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return new BookingResponseDto
            {
                Id = booking.Id,
                RoomId = booking.RoomId,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                TotalAmount = booking.TotalAmount,
                Status = booking.Status
            };
        }

        public async Task<List<BookingResponseDto>> GetUserBookingsAsync(string userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .Select(b => new BookingResponseDto
                {
                    Id = b.Id,
                    RoomId = b.RoomId,
                    CheckInDate = b.CheckInDate,
                    CheckOutDate = b.CheckOutDate,
                    TotalAmount = b.TotalAmount,
                    Status = b.Status
                })
                .ToListAsync();
        }

        public async Task<BookingResponseDto> GetBookingByIdAsync(int bookingId, string userId)
        {
            var b = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == bookingId && x.UserId == userId);
            if (b == null) return null!;
            return new BookingResponseDto
            {
                Id = b.Id,
                RoomId = b.RoomId,
                CheckInDate = b.CheckInDate,
                CheckOutDate = b.CheckOutDate,
                TotalAmount = b.TotalAmount,
                Status = b.Status
            };
        }

        public async Task<bool> CancelBookingAsync(int bookingId, string userId)
        {
            var b = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == bookingId && x.UserId == userId);
            if (b == null) return false;
            b.Status = "Cancelled";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckoutAsync(int bookingId, string userId)
        {
            var b = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == bookingId && x.UserId == userId);
            if (b == null) return false;
            b.Status = "Completed";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
