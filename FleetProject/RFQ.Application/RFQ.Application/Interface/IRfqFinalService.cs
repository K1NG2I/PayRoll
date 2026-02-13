using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IRfqFinalService
    {
        Task<bool> AddRfqFinal(RfqFinal rfqFinal,List<RfqFinalRate> rfqFinalRates);
        Task<bool> UpdateRfqFinal(RfqFinal rfqFinal, List<RfqFinalRate> rfqFinalRates);
        Task<bool> DeleteRfqFinal(int rfqFinalId);
        Task<IEnumerable<VendorFinalizationDto>> AwardedVendor(int id);
        Task<PageList<RfqFinalizationResponseDto>> GetAllRfqFinalization(PagingParam pagingParam);

    }
}
