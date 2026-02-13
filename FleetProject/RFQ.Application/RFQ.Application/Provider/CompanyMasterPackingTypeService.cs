using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class CompanyMasterPackingTypeService : ICompanyMasterPackingTypeService
    {
        private readonly ICompanyMasterPackingTypeRepository _companyMasterPackingTypeRepository;

        public CompanyMasterPackingTypeService(ICompanyMasterPackingTypeRepository companyMasterPackingTypeRepository)
        {
            _companyMasterPackingTypeRepository = companyMasterPackingTypeRepository;
        }

        public async Task<CompanyMasterPackingType> AddMasterPackingType(CompanyMasterPackingType masterPackingType)
        {
            return await _companyMasterPackingTypeRepository.AddMasterPackingType(masterPackingType);
        }

        public async Task<int> DeletemasterPackingType(int id)
        {
            var result = await _companyMasterPackingTypeRepository.GetMasterPackingTypeById(id);
            if (result != null)
            {
                await _companyMasterPackingTypeRepository.DeletemasterPackingType(result);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<CompanyMasterPackingType>> GetAllMasterPackingType()
        {
            return await _companyMasterPackingTypeRepository.GetAllMasterPackingType();
        }

        public async Task<CompanyMasterPackingType> GetMasterPackingTypeById(int id)
        {
            return await _companyMasterPackingTypeRepository.GetMasterPackingTypeById(id);
        }

        public async Task UpdatemasterPackingType(CompanyMasterPackingType masterPackingType)
        {
            await _companyMasterPackingTypeRepository.UpdatemasterPackingType(masterPackingType);
        }
    }
}
