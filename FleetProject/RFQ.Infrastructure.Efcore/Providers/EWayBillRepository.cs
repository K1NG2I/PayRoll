using Microsoft.Data.SqlClient;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using System.Data;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class EWayBillRepository : IEWayBillRepository
    {
        private readonly IFleetLynkAdo _fleetLynkAdo;
        public EWayBillRepository(IFleetLynkAdo fleetLynkAdo)
        {
            _fleetLynkAdo = fleetLynkAdo;
        }
        public async Task<IEnumerable<TripDetailsResponse>> GetTripDetailsByBillExpiryDate(TripDetailsRequestDto requestDto)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@EWayBillExpiryDate", SqlDbType.VarChar){ Value=requestDto.EWayBillExpiryDate },
                new SqlParameter("@CompanyId", SqlDbType.Int) { Value=requestDto.CompanyId },
                new SqlParameter("@StatusId", SqlDbType.Int) { Value = (int)EStatus.IsActive }
            };

            var dataTable = await _fleetLynkAdo.ExecuteStoredProcedureAsync(
                StoredProcedureHelper.sp_GetTripDetails, parameters
            );
            var items = DataTableMapper.MapToList<TripDetailsResponse>(dataTable);
            return items;
        }
    }
}
