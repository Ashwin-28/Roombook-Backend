using System.Collections.Generic;
using System.Threading.Tasks;
using Room_Api.Services.Dto;

namespace Room_Api.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingResponseDto> CreateBookingAsync(CreateBookingDto dto, string userId);
        Task<List<BookingResponseDto>> GetUserBookingsAsync(string userId);
        Task<BookingResponseDto> GetBookingByIdAsync(int bookingId, string userId);
        Task<bool> CancelBookingAsync(int bookingId, string userId);
        Task<bool> CheckoutAsync(int bookingId, string userId);
    }
}
