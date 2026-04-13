using System;
using System.Threading.Tasks;
using Room_Api.Services.Dto;

namespace Room_Api.Services.Interfaces
{
    public interface IDynamicPricingService
    {
        Task<decimal> CalculatePriceAsync(int roomId, DateTime checkIn, DateTime checkOut, int numRooms);
        Task<PriceEstimateResponseDto> GetPriceEstimateAsync(PriceEstimateRequestDto dto);
    }
}
