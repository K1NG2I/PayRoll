using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class MasterPartyVehicleTypeRepository : IMasterPartyVehicleTypeRepository
    {
        private readonly FleetLynkDbContext _fleetLynkDbContext;
        public MasterPartyVehicleTypeRepository(FleetLynkDbContext fleetLynkDbContext)
        {
            _fleetLynkDbContext = fleetLynkDbContext;
        }
        public async Task AddMasterPartyVehicleType(List<MasterPartyVehicleType> masterPartyVehicleTypes)
        {
            await _fleetLynkDbContext.masterPartyVehicleType.AddRangeAsync(masterPartyVehicleTypes);
            await _fleetLynkDbContext.SaveChangesAsync();
        }

        public async Task DeleteMasterPartyVehicleType(MasterPartyVehicleType masterPartyVehicleType)
        {
            _fleetLynkDbContext.masterPartyVehicleType.Remove(masterPartyVehicleType);
            await _fleetLynkDbContext.SaveChangesAsync();
        }

        public async Task DeleteMasterVehicleTypeByPartyId(int id)
        {
            var vehicleTypes = await _fleetLynkDbContext.masterPartyVehicleType.Where(x => x.PartyId == id).ToListAsync();
            if (vehicleTypes.Any())
            {
                _fleetLynkDbContext.masterPartyVehicleType.RemoveRange(vehicleTypes);
                await _fleetLynkDbContext.SaveChangesAsync();
            }
        }

        public async Task<MasterPartyVehicleType> GetMasterPartyVehicleTypeById(int id)
        {
            return await _fleetLynkDbContext.masterPartyVehicleType.Where(x => x.PartyVehicleTypeId == id).AsNoTracking().FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<MasterPartyVehicleTypeResponseDto>> GetMasterPartyVehicleTypeByPartyId(int id)
        {
            var query = from mastervehicle in _fleetLynkDbContext.masterPartyVehicleType
                        join vehicletype in _fleetLynkDbContext.com_mst_vehicle_type on mastervehicle.VehicleTypeId equals vehicletype.VehicleTypeId
                        where mastervehicle.PartyId == id
                        select new MasterPartyVehicleTypeResponseDto
                        {
                            PartyVehicleTypeId = mastervehicle.PartyVehicleTypeId,
                            PartyId = mastervehicle.PartyId,
                            VehicleTypeId = mastervehicle.VehicleTypeId,
                            VehicleTypeName = vehicletype.VehicleTypeName,
                        };
            return await query.ToListAsync();
        }

        public async Task UpdateMasterPartyVehicleType(List<MasterPartyVehicleType> masterPartyVehicleTypes)
        {
            _fleetLynkDbContext.masterPartyVehicleType.UpdateRange(masterPartyVehicleTypes);
            await _fleetLynkDbContext.SaveChangesAsync();
        }
    }
}
