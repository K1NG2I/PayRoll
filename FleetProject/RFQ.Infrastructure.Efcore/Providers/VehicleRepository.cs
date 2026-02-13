using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System.Data;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly ICommonRepositroy _commonRepositroy;
        public VehicleRepository(FleetLynkDbContext appDbContext, ICommonRepositroy commonRepositroy)
        {
            _appDbContext = appDbContext;
            _commonRepositroy = commonRepositroy;
        }

        public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
        {
            await _appDbContext.com_mst_vehicle.AddAsync(vehicle);
            await _appDbContext.SaveChangesAsync();
            return vehicle;
        }

        public async Task DeleteVehicle(Vehicle vehicle)
        {
            _appDbContext.com_mst_vehicle.Update(vehicle);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                var existingVehicle = await GetExistingVehicleById(vehicle.VehicleId);
                if (existingVehicle != null)
                {
                    vehicle.CreatedOn = existingVehicle.CreatedOn;
                    vehicle.UpdatedOn = DateTime.Now;
                    vehicle.StatusId = existingVehicle.StatusId;
                    _appDbContext.com_mst_vehicle.Update(vehicle);
                    await _appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PageList<VehicleResponseDto>> GetAllVehicles(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<VehicleResponseDto>(StoredProcedureHelper.sp_GetAllVehicleList, pagingParam);
        }
        public async Task<Vehicle> GetVehicleById(int id)
        {
            return await _appDbContext.com_mst_vehicle.Where(x => x.VehicleId == id && x.StatusId == (int)EStatus.IsActive).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<Vehicle?> GetExistingVehicleById(int id)
        {
            return await _appDbContext.com_mst_vehicle.Where(x => x.VehicleId == id).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<MasterParty>> GetAllOwnerOrVendor(int companyId)
        {
            return await _appDbContext.masterParty.Where(mp => mp.PartyTypeId == (int)EnumInternalMaster.VENDOR && mp.PartyCategoryId == (int)EnumInternalMaster.OWNER && mp.StatusId == (int)EStatus.IsActive && mp.CompanyId == companyId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<InternalMaster>> GetAllVehicleCategory()
        {
            return await _appDbContext.internalMaster.Where(x => x.InternalMasterTypeId == (int)EnumInternalMasterType.VEHICLE_CATEGORY).AsNoTracking().ToListAsync();
        }

        public async Task<List<VehicleType>> GetAllVehicleType(int companyId)
        {
            return await _appDbContext.com_mst_vehicle_type.Where(vt => vt.StatusId == (int)EStatus.IsActive && vt.CompanyId == companyId).ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehicleNumber()
        {
            return await _appDbContext.com_mst_vehicle.Where(vt => vt.StatusId == (int)EStatus.IsActive).Select(v => v).AsNoTracking().ToListAsync();
        }

        public async Task<Vehicle?> GetVehicleByVehicleNo(string vehicleNo)
        {
            return await _appDbContext.com_mst_vehicle.Where(x => x.VehicleNo == vehicleNo).FirstOrDefaultAsync();
        }
    }
}
