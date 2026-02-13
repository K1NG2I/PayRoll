using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface ICompanyMasterPackingTypeRepository
    {
        Task<CompanyMasterPackingType> GetMasterPackingTypeById(int id);
        Task<IEnumerable<CompanyMasterPackingType>> GetAllMasterPackingType();
        Task<CompanyMasterPackingType> AddMasterPackingType(CompanyMasterPackingType masterPackingType);
        Task UpdatemasterPackingType(CompanyMasterPackingType masterPackingType);
        Task DeletemasterPackingType(CompanyMasterPackingType masterPackingType);
    }
}
