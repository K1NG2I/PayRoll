    
using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface IInternalMasterTypeRepository
    {
        Task<InternalMasterType> GetInternalMasterTypeId(int id);
        Task<IEnumerable<InternalMasterType>> GetAllInternalMasterType();
        Task<InternalMasterType> AddInternalMasterType(InternalMasterType masterType);
        Task UpdateInternalMasterType(InternalMasterType masterType);
        Task DeleteInternalMasterType(InternalMasterType masterType);
    }
}
