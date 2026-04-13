using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Room_Api.Data;
using Room_Api.DTOs;
using Room_Api.Services.Interfaces;

namespace Room_Api.Services
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context;

        public RoomService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoomListDto>> GetAllRoomsAsync()
        {
            return await _context.Rooms
                .Select(r => new RoomListDto
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    RoomType = r.RoomType,
                    BasePrice = r.BasePrice,
                    IsAvailable = r.IsAvailable
                })
                .ToListAsync();
        }

        public async Task<RoomDetailDto> GetRoomByIdAsync(int id)
        {
            var room = await _context.Rooms
                .Include(r => r.RoomAmenities)
                .ThenInclude(ra => ra.Amenity)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (room == null) return null!;

            return new RoomDetailDto
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                RoomType = room.RoomType,
                Description = room.Description,
                BasePrice = room.BasePrice,
                Amenities = room.RoomAmenities.Select(x => new AmenityDto {
                    Id = x.Amenity.Id,
                    Name = x.Amenity.Name,
                    Description = x.Amenity.Description,
                    Price = x.Amenity.Price,
                    Category = x.Amenity.Category
                }).ToList()
            };
        }

        public async Task<List<RoomListDto>> GetAvailableRoomsAsync(System.DateTime checkIn, System.DateTime checkOut)
        {
            var bookedRoomIds = await _context.Bookings
                .Where(b => b.Status != "Cancelled" && b.CheckInDate < checkOut && b.CheckOutDate > checkIn)
                .Select(b => b.RoomId)
                .Distinct()
                .ToListAsync();

            return await _context.Rooms
                .Where(r => !bookedRoomIds.Contains(r.Id) && r.IsAvailable)
                .Select(r => new RoomListDto
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    RoomType = r.RoomType,
                    BasePrice = r.BasePrice,
                    IsAvailable = r.IsAvailable
                })
                .ToListAsync();
        }
    }
}
