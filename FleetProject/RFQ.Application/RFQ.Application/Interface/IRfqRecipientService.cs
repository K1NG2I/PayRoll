using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface IRfqRecipientService
    {
        Task<RfqRecipient> GetRfqRecipientById(int id);
        Task<IEnumerable<RfqRecipient>> GetAllRfqRecipient();
        Task AddRfqRecipient(List<RfqRecipient> rfqRecipient);
        Task<bool> UpdateRfqRecipient(int rfqId,List<RfqRecipient> rfqRecipient);
        Task<int> DeleteRfqRecipient(int id);
    }
}
