using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface ICompanyMasterPackingTypeService
    {
        Task<CompanyMasterPackingType> GetMasterPackingTypeById(int id);
        Task<IEnumerable<CompanyMasterPackingType>> GetAllMasterPackingType();
        Task<CompanyMasterPackingType> AddMasterPackingType(CompanyMasterPackingType masterPackingType);
        Task UpdatemasterPackingType(CompanyMasterPackingType masterPackingType);
        Task<int> DeletemasterPackingType(int id);
    }
}
