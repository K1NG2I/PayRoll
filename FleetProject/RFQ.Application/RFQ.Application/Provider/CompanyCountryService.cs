using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class CompanyCountryService : ICompanyCountryService
    {
        private readonly ICompanyCountryRepository _companyCountryRepository;

        public CompanyCountryService(ICompanyCountryRepository companyCountryRepository)
        {
            _companyCountryRepository = companyCountryRepository;
        }

        public Task<IEnumerable<CompanyCountry>> GetAllCountry()
        {
            return _companyCountryRepository.GetAllCountry();
        }
        public async Task<CompanyCountry> GetCountryById(int id)
        {
            return await _companyCountryRepository.GetCountryById(id);
        }

        public async Task UpdateCountry(CompanyCountry country)
        {
            await _companyCountryRepository.UpdateCountry(country);
        }

        public async Task<CompanyCountry> AddCountry(CompanyCountry country)
        {
            return await _companyCountryRepository.AddCountry(country);
        }

        public async Task<int> DeleteCountry(int id)
        {
            var result = await _companyCountryRepository.GetCountryById(id);
            if (result != null)
            {
                result.StatusId = (int)EStatus.Deleted;
                await _companyCountryRepository.DeleteCountry(result);
                return 1;
            }
            return 0;
        }

        public Task<IEnumerable<LocationData>> GetStatesAndCitiesByCountry()
        {
            return _companyCountryRepository.GetStatesAndCitiesByCountry();
        }
    }
}
