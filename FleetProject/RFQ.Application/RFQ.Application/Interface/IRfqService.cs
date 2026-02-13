using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IRfqService
    {
        Task<Rfq> GetRfqId(int id);
        Task<PageList<RfqListResponseDto>> GetAllRfq(PagingParam pagingParam);
        Task<Rfq> UpdateRfq(Rfq rfq);
        Task<bool> DeleteRfq(int id);
        Task<RequestForQuoteDto> AddRfq(Rfq rfq, List<RfqRecipient> rfqRecipients);
        Task<string> GenerateRfqAutoNo();
        Task<Rfq> GetRfqByRfqNo(string rfqNo);
        Task<IEnumerable<RfqVendorListResponseDto>> GetAllVendorListForRfq(RfqVendorDetailsParam rfqVendorDetailsParam);
        Task<IEnumerable<RfqPreviousQuotesList>> GetPreviousQuotesList(RfqVendorDetailsParam rfqVendorDetailsParam);
        Task<RfqQuoteRateVendorDetails> GetRfqQuoteRateVendorDetails(int rfqId);
        Task<IEnumerable<Rfq>> GetRfqDrpList(int companyId);
        Task<IEnumerable<Rfq>> GetRfqTableData();
    }
}
