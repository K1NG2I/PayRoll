using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface ICompanyCountryService
    {
        //CompanyCountry
        Task<CompanyCountry> GetCountryById(int id);
        Task<IEnumerable<CompanyCountry>> GetAllCountry();
        Task<CompanyCountry> AddCountry(CompanyCountry country);
        Task UpdateCountry(CompanyCountry country);
        Task<int> DeleteCountry(int id);

        Task<IEnumerable<LocationData>> GetStatesAndCitiesByCountry();
    }
}
