using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface ICompanyCityRepository
    {
        Task<CompanyCity> GetCityById(int id);
        Task<IEnumerable<CompanyCity>> GetAllCity();
        Task<CompanyCity> AddCity(CompanyCity city);
        Task UpdateCity(CompanyCity city);
        Task DeleteCity(CompanyCity city);
    }
}
