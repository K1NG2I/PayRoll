using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class RfqRecipientService : IRfqRecipientService
    {
        private readonly IRfqRecipientRepository _rfqRecipientRepository;
        public RfqRecipientService(IRfqRecipientRepository rfqRecipientRepository)
        {
            _rfqRecipientRepository = rfqRecipientRepository;
        }
        public Task AddRfqRecipient(List<RfqRecipient> rfqRecipient)
        {
            return _rfqRecipientRepository.AddRfqRecipient(rfqRecipient);
        }

        public async Task<int> DeleteRfqRecipient(int id)
        {
            var recipient = await _rfqRecipientRepository.GetRfqRecipientById(id);
            if (recipient != null)
            {
                await _rfqRecipientRepository.DeleteRfqRecipient(recipient);
                return 1;
            }
            return 0;
        }

        public Task<IEnumerable<RfqRecipient>> GetAllRfqRecipient()
        {
            return _rfqRecipientRepository.GetAllRfqRecipient();
        }

        public Task<RfqRecipient> GetRfqRecipientById(int id)
        {
            return _rfqRecipientRepository.GetRfqRecipientById(id);
        }

        public async Task<bool>UpdateRfqRecipient(int rfqId,List<RfqRecipient> rfqRecipient)
        {
            return await _rfqRecipientRepository.UpdateRfqRecipient(rfqId,rfqRecipient);
        }
    }
}
