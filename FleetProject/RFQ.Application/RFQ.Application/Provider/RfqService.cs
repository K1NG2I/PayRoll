using RFQ.Application.Interface;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using AutoMapper;
using RFQ.Domain.Enums;
using RFQ.Application.Helper;

namespace RFQ.Application.Provider
{
    public class RfqService : IRfqService
    {
        private readonly IRfqRepository _rfqRepository;

        private readonly IRfqRecipientRepository _rfqRecipientRepository;
        private readonly IMapper _mapper;
        private readonly LinkItemContextHelper _linkItemContextHelper;

        public RfqService(IRfqRepository rfqRepository, IRfqRecipientRepository rfqRecipientRepository, IMapper mapper, LinkItemContextHelper linkItemContextHelper)
        {
            _rfqRepository = rfqRepository;
            _rfqRecipientRepository = rfqRecipientRepository;
            _mapper = mapper;
            _linkItemContextHelper = linkItemContextHelper;
        }

        public async Task<RequestForQuoteDto> AddRfq(Rfq rfq, List<RfqRecipient> rfqRecipients)
        {
            RequestForQuoteDto rfqDetail = new();
            Rfq rfqResponse = await _rfqRepository.AddRfq(rfq);
            if (rfqResponse != null)
            {
                var rfqDto = _mapper.Map<RfqDto>(rfqResponse);
                rfqDetail.RfqRequestDto = rfqDto;

                if (rfqRecipients != null && rfqRecipients.Count > 0)
                {
                    rfqRecipients.ForEach(r => r.RfqId = rfqResponse.RfqId);
                    List<RfqRecipient> recipientResponse = await _rfqRecipientRepository.AddRfqRecipient(rfqRecipients);

                    if (recipientResponse != null && recipientResponse.Count > 0)
                    {
                        var recipientDtos = _mapper.Map<List<RfqRecipientRequestDto>>(recipientResponse);
                        rfqDetail.RfqRecipients = recipientDtos;
                    }
                }
            }
            return rfqDetail;
        }

        public async Task<bool> DeleteRfq(int id)
        {
            var result = await _rfqRepository.GetRfqId(id);
            if (result != null)
            {
                result.StatusId = (int)EStatus.Deleted;
                return await _rfqRepository.DeleteRfq(result);
            }
            return false;
        }

        public async Task<PageList<RfqListResponseDto>> GetAllRfq(PagingParam pagingParam)
        {
            var result = await _rfqRepository.GetAllRfq(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.RFQ_RequestForQuote);
            return result;
        }

        public async Task<Rfq> GetRfqId(int id)
        {
            return await _rfqRepository.GetRfqId(id);
        }

        public async Task<Rfq> UpdateRfq(Rfq rfq)
        {
            return await _rfqRepository.UpdateRfq(rfq);
        }

        public async Task<string> GenerateRfqAutoNo()
        {
            return await _rfqRepository.GenerateRfqAutoNo();
        }

        public async Task<Rfq> GetRfqByRfqNo(string rfqNo)
        {
            return await _rfqRepository.GetRfqByRfqNo(rfqNo);
        }

        public async Task<IEnumerable<RfqVendorListResponseDto>> GetAllVendorListForRfq(RfqVendorDetailsParam rfqVendorDetailsParam)
        {
            return await _rfqRepository.GetAllVendorListForRfq(rfqVendorDetailsParam);
        }
        public async Task<IEnumerable<RfqPreviousQuotesList>> GetPreviousQuotesList(RfqVendorDetailsParam rfqVendorDetailsParam)
        {
            return await _rfqRepository.GetPreviousQuotesList(rfqVendorDetailsParam);
        }
        public async Task<RfqQuoteRateVendorDetails> GetRfqQuoteRateVendorDetails(int rfqId)
        {
            return await _rfqRepository.GetRfqQuoteRateVendorDetails(rfqId);
        }

        public async Task<IEnumerable<Rfq>> GetRfqDrpList(int companyId)
        {
            return await _rfqRepository.GetRfqDrpList(companyId);
        }
        public async Task<IEnumerable<Rfq>> GetRfqTableData()
        {
            return await _rfqRepository.GetRfqTableData();
        }
    }
}
