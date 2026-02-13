using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface IInternalMasterService
    {
        Task<IEnumerable<InternalMaster>> GetAllInternalMaster();
    }
}
