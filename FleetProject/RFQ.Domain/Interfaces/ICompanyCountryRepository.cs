using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface ICompanyCountryRepository
    {
        Task<CompanyCountry> GetCountryById(int id);
        Task<IEnumerable<CompanyCountry>> GetAllCountry();
        Task<CompanyCountry> AddCountry(CompanyCountry country);
        Task UpdateCountry(CompanyCountry country);
        Task DeleteCountry(CompanyCountry country);
        Task<IEnumerable<LocationData>> GetStatesAndCitiesByCountry();
    }
}
