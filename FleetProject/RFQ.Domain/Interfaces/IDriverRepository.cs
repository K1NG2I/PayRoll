using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface IDriverRepository
    {
        Task<Driver> GetDriverById(int id);
        Task<PageList<DriverResponseDto>> GetAllDrivers(PagingParam pagingParam);
        Task<Driver> AddDriver(Driver driver);
        Task UpdateDriver(Driver driver);
        Task DeleteDriver(Driver driver);
        Task<IEnumerable<InternalMaster>> GetDriverType();
        Task<IEnumerable<Driver>> GetAllDriverList();
        Task<Driver> GetexistingDriverById(int id);
        Task<bool> IsDuplicateDriver(string licenseNo, int createdBy);
        Task<string> GenerateDriverCode(int UserId);
    }
}
