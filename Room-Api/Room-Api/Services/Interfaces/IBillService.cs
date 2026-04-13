using System.Threading.Tasks;
using Room_Api.Services.Dto;

namespace Room_Api.Services.Interfaces
{
    public interface IBillService
    {
        Task<BillDto> GenerateBillAsync(int bookingId);
        Task<BillDto> GetBillAsync(int bookingId);
    }
}
