using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class CompanyStateService : ICompanyStateService
    {
        private readonly ICompanyStateRepository _companyStateRepository;

        public CompanyStateService(ICompanyStateRepository companyStateRepository)
        {
            _companyStateRepository = companyStateRepository;
        }

        public async Task<CompanyState> AddState(CompanyState state)
        {
            return await _companyStateRepository.AddState(state);
        }

        public async Task<int> DeleteState(int id)
        {
            var result = await _companyStateRepository.GetStateById(id);
            if (result != null)
            {
                result.StatusId = (int)EStatus.Deleted;
                await _companyStateRepository.DeleteState(result);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<CompanyState>> GetAllState()
        {
            return await _companyStateRepository.GetAllState();
        }

        public async Task<CompanyState> GetStateById(int id)
        {
            return await _companyStateRepository.GetStateById(id);
        }

        public async Task UpdateState(CompanyState state)
        {
            await _companyStateRepository.UpdateState(state);
        }
    }
}
