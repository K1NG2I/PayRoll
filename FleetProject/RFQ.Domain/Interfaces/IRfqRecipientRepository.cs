using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface IRfqRecipientRepository
    {
        Task<RfqRecipient> GetRfqRecipientById(int id);
        Task<IEnumerable<RfqRecipient>> GetAllRfqRecipient();
        Task<List<RfqRecipient>> AddRfqRecipient(List<RfqRecipient> rfqRecipient);
        Task<bool> UpdateRfqRecipient(int rfqId,List<RfqRecipient> rfqRecipient);
        Task DeleteRfqRecipient(RfqRecipient rfqRecipient);
    }
}
