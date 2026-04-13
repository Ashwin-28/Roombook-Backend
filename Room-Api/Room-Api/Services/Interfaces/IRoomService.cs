using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Room_Api.DTOs;


namespace Room_Api.Services.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomListDto>> GetAllRoomsAsync();
        Task<RoomDetailDto> GetRoomByIdAsync(int id);
        Task<List<RoomListDto>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut);
    }
}
