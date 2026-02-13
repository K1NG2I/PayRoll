using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface IRfqFinalRepository
    {
        Task<RfqFinal> AddRfqFinal(RfqFinal rfqFinal);
        Task<RfqFinal> UpdateRfqFinal(RfqFinal rfqFinal);
        Task<bool> DeleteRfqFinal(int rfqFinalId);
        Task<IEnumerable<VendorFinalizationDto>> AwardedVendor(int id);
        Task<PageList<RfqFinalizationResponseDto>> GetAllRfqFinalization(PagingParam pagingParam);
        Task<RfqFinal?> GetRfqFinalById(int rfqFinalId);
    }
}
