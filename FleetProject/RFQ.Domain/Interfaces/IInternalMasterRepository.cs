using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface IInternalMasterRepository
    {
        Task<IEnumerable<InternalMaster>> GetAllInternalMaster();
    }
}
