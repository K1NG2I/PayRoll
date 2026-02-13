using Microsoft.Azure.Documents.SystemFunctions;
using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System.IO;

namespace RFQ.Application.Provider
{
    public class RfqFinalService : IRfqFinalService
    {
        private readonly IRfqFinalRepository _rfqFinalRepository;
        private readonly IRfqFinalRateRepository _rfqFinalRateRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;
        public RfqFinalService(IRfqFinalRepository rfqFinalRepository,IRfqFinalRateRepository rfqFinalRateRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _rfqFinalRepository = rfqFinalRepository;
            _rfqFinalRateRepository = rfqFinalRateRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }
        public async Task<bool> AddRfqFinal(RfqFinal rfqFinal,List<RfqFinalRate> rfqFinalRates)
        {
            var rfqFinalResult = await _rfqFinalRepository.AddRfqFinal(rfqFinal);
            if (rfqFinalResult !=null)
            {
                if(rfqFinalRates.Count > 0)
                {
                    rfqFinalRates.ForEach(r => r.RfqFinalId = rfqFinalResult.RfqFinalIdId);
                    var rfqFinalRateResult = await _rfqFinalRateRepository.AddRfqFinalRate(rfqFinalRates);
                    if(rfqFinalRateResult != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        
        public async Task<IEnumerable<VendorFinalizationDto>> AwardedVendor(int id)
        {
            return await _rfqFinalRepository.AwardedVendor(id);
        }

        public async Task<bool> DeleteRfqFinal(int rfqFinalId)
        {
            var rfqFinal = await _rfqFinalRepository.DeleteRfqFinal(rfqFinalId);
            if(rfqFinal)
            {
                var rfqFinalRates = await _rfqFinalRateRepository.DeleteRfqFinalRate(rfqFinalId);
                if (rfqFinalRates)
                {
                    return true;
                }
                return true;
            }
            return false;
        }

        public async Task<PageList<RfqFinalizationResponseDto>> GetAllRfqFinalization(PagingParam pagingParam)
        {
            var result = await _rfqFinalRepository.GetAllRfqFinalization(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.RFQ_Finalization);
            return result;
        }

        public async Task<bool> UpdateRfqFinal(RfqFinal rfqFinal, List<RfqFinalRate> rfqFinalRates)
        {
            var rfqFinalResult = await _rfqFinalRepository.UpdateRfqFinal(rfqFinal);
            if (rfqFinalResult != null)
            {
                if (rfqFinalRates.Count <= 0)
                {
                    return true;
                }
                rfqFinalRates.ForEach(rfqFinalRates => rfqFinalRates.RfqFinalId = rfqFinalResult.RfqFinalIdId);
                var rfqFinalRateResult = await _rfqFinalRateRepository.UpdateRfqFinalRate(rfqFinalRates);
                if (rfqFinalRateResult != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }   
            }
            return false;
        }
    }
}
