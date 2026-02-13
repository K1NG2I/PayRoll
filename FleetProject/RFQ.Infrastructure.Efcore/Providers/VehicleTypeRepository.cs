using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RFQ.Infrastructure.Efcore.Providers
{

    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly ICommonRepositroy _commonRepositroy;

        public VehicleTypeRepository(FleetLynkDbContext appDbContext, ICommonRepositroy commonRepositroy)
        {
            _appDbContext = appDbContext;
            _commonRepositroy = commonRepositroy;
        }

        public async Task<CommanResponseDto> AddVehicleType(VehicleType vehicleType)
        {
            var exsitData = _appDbContext.com_mst_vehicle_type.Where(x => x.CompanyId == vehicleType.CompanyId && x.VehicleTypeName == vehicleType.VehicleTypeName && x.StatusId == (int)EStatus.IsActive).FirstOrDefault();
            if (exsitData != null)
            {
                return new CommanResponseDto() { Data = null, Message = "Duplicate Data Not Allowed", StatusCode = 404 };
            }
            else
            {
                _appDbContext.com_mst_vehicle_type.Add(vehicleType);
                await _appDbContext.SaveChangesAsync();
                return new CommanResponseDto { Data = vehicleType, Message = "Vehicle Type Added successfully", StatusCode = 200 };
            }
        }

        public async Task DeleteVehicleType(VehicleType vehicleType)
        {
            _appDbContext.com_mst_vehicle_type.Update(vehicleType);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PageList<VehicleTypeResponseDto>> GetAllVehicleType(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<VehicleTypeResponseDto>(StoredProcedureHelper.sp_GetVehicleTypeList, pagingParam);
        }

        public async Task<VehicleType?> GetVehicleTypeById(int id)
        {
            return await _appDbContext.com_mst_vehicle_type.Where(x => x.VehicleTypeId == id).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<VehicleType?> GetExistingVehicleTypeById(int id)
        {
            return await _appDbContext.com_mst_vehicle_type.Where(x => x.VehicleTypeId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateVehicleType(VehicleType vehicleType)
        {
            try
            {
                var exsiting = await GetExistingVehicleTypeById(vehicleType.VehicleTypeId);
                if (exsiting != null)
                {
                    var existingVehicleType = await _appDbContext.com_mst_vehicle_type
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.VehicleTypeName == vehicleType.VehicleTypeName);

                    if (existingVehicleType != null)
                    {
                        throw new InvalidOperationException("VehicleType Already Exsist.");
                    }
                    else
                    {
                        vehicleType.StatusId = exsiting.StatusId;
                        _appDbContext.com_mst_vehicle_type.Update(vehicleType);
                        await _appDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<InternalMaster>> GetAllVehicleCategory()
        {
            return await _appDbContext.internalMaster.Where(x => x.InternalMasterTypeId == (int)EnumInternalMasterType.VEHICLE_CATEGORY).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<MasterParty>> GetAllOwnerOrVendor()
        {
            var result = (from cp in _appDbContext.masterParty
                          join cmim in _appDbContext.internalMaster
                          on cp.PartyTypeId equals cmim.InternalMasterId
                          where cmim.InternalMasterName == "VENDOR"
                          select cp).ToList();
            return result;
        }

        public async Task<IEnumerable<VehicleType>> GetVehicleList()
        {
            return await _appDbContext.com_mst_vehicle_type
                .Where(x => x.StatusId == (int)EStatus.IsActive)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
