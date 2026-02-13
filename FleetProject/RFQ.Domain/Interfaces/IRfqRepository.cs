using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface IRfqRepository
    {
        Task<Rfq?> GetRfqId(int id);
        Task<PageList<RfqListResponseDto>> GetAllRfq(PagingParam pagingParam);
        Task<Rfq> AddRfq(Rfq rfq);
        Task<Rfq> UpdateRfq(Rfq rfq);
        Task<bool> DeleteRfq(Rfq rfq);
        Task<string> GenerateRfqAutoNo();
        Task<Rfq> GetRfqByRfqNo(string rfqNo);
        Task<IEnumerable<RfqVendorListResponseDto>> GetAllVendorListForRfq(RfqVendorDetailsParam rfqVendorDetailsParam);
        Task<IEnumerable<RfqPreviousQuotesList>> GetPreviousQuotesList(RfqVendorDetailsParam rfqVendorDetailsParam);
        Task<RfqQuoteRateVendorDetails> GetRfqQuoteRateVendorDetails(int rfqId);
        Task<IEnumerable<Rfq>> GetRfqDrpList(int companyId);
        Task<IEnumerable<Rfq>> GetRfqTableData();
    }
}
