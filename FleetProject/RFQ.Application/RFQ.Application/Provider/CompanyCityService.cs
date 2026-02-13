using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;


namespace RFQ.Application.Provider
{
    public class CompanyCityService : ICompanyCityService
    {
        private readonly ICompanyCityRepository _companyCityRepository;

        public CompanyCityService(ICompanyCityRepository companyCityRepository)
        {
            _companyCityRepository = companyCityRepository;
        }

        public async Task<CompanyCity> GetCityById(int id)
        {
            return await _companyCityRepository.GetCityById(id);
        }

        public async Task<IEnumerable<CompanyCity>> GetAllCity()
        {
            return await _companyCityRepository.GetAllCity();
        }

        public async Task<CompanyCity> AddCity(CompanyCity city)
        {
            return await _companyCityRepository.AddCity(city);
        }

        public async Task UpdateCity(CompanyCity city)
        {
            await _companyCityRepository.UpdateCity(city);
        }

        public async Task<int> DeleteCity(int id)
        {
            var city = await _companyCityRepository.GetCityById(id);
            if (city != null)
            {
                city.StatusId = (int)EStatus.Deleted;
                await _companyCityRepository.DeleteCity(city);
                return 1;
            }
            return 0;
        }


    }
}
