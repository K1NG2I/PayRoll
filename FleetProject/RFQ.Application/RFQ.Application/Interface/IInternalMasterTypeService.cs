using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface IInternalMasterTypeService
    {
        Task<InternalMasterType> GetInternalMasterTypeById(int id);
        Task<IEnumerable<InternalMasterType>> GetAllInternalMasterType();
        Task<InternalMasterType> AddInternalMasterType(InternalMasterType masterType);
        Task UpdateInternalMasterType(InternalMasterType masterType);
        Task<int> DeleteInternalMasterType(int id);
    }
}
