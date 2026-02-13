using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface ICompanyCityService
    {
        //CompanyCity
        Task<CompanyCity> GetCityById(int id);
        Task<IEnumerable<CompanyCity>> GetAllCity();
        Task<CompanyCity> AddCity(CompanyCity city);
        Task UpdateCity(CompanyCity city);
        Task<int> DeleteCity(int id);
    }
}
