using System.Collections.Generic;
using System.Threading.Tasks;
using Room_Api.DTOs;


namespace Room_Api.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> CreateReviewAsync(CreateReviewDto dto, string userId);
        Task<List<ReviewDto>> GetReviewsByRoomAsync(int roomId);
    }
}
