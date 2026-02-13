using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Documents;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IDriverService
    {
        Task<Driver> GetDriverById(int id);
        Task<PageList<DriverResponseDto>> GetAllDrivers(PagingParam pagingParam);
        Task<Driver> AddDriver(Driver driver);
        Task UpdateDriver(Driver driver);
        Task<int> DeleteDriver(int id);
        Task<IEnumerable<InternalMaster>> GetDriverType();
        Task<IEnumerable<Driver>> GetAllDriverList();
        Task<string> GenerateDriverCode(int UserId);
    }
}
