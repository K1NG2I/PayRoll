using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RFQ.Application.Provider
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;
        public DriverService(IDriverRepository driverRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _driverRepository = driverRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }
        public async Task<Driver> AddDriver(Driver driver)
        {
            return await _driverRepository.AddDriver(driver);
        }

        public async Task<int> DeleteDriver(int id)
        {
            var result = await _driverRepository.GetexistingDriverById(id);
            if (result != null)
            {
                if (result.StatusId == (int)EStatus.IsActive)
                    result.StatusId = (int)EStatus.Deleted;
                else
                    result.StatusId = (int)EStatus.IsActive;
                await _driverRepository.DeleteDriver(result);
                return 1;
            }
            return 0;
        }

        public async Task<PageList<DriverResponseDto>> GetAllDrivers(PagingParam pagingParam)
        {
            var result =  await _driverRepository.GetAllDrivers(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.Driver);
            return result;
        }

        public async Task<Driver> GetDriverById(int id)
        {
            return await _driverRepository.GetDriverById(id);
        }

        public async Task<IEnumerable<InternalMaster>> GetDriverType()
        {
            return await _driverRepository.GetDriverType();
        }

        public async Task UpdateDriver(Driver driver)
        {
            await _driverRepository.UpdateDriver(driver);
        }
        public async Task<IEnumerable<Driver>> GetAllDriverList()
        {
            return await _driverRepository.GetAllDriverList();
        }

        public async Task<string> GenerateDriverCode(int UserId)
        {
            return await _driverRepository.GenerateDriverCode(UserId);
        }
    }
}
