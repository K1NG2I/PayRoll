using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.Helper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using RFQ.Domain.Utility;
using RFQ.Domain.ResponseDto;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class MenuListRepository : IMenuListRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly IFleetLynkAdo _fleetLynkAdo;

        public MenuListRepository(FleetLynkDbContext appDbContext, IFleetLynkAdo fleetLynkAdo)
        {
            _appDbContext = appDbContext;
            _fleetLynkAdo = fleetLynkAdo;
        }

        public async Task<IEnumerable<MenuListResponseDto>> GetMenu(int profileId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@ProfileId", SqlDbType.Int) { Value = profileId }
            };
            var result = await _fleetLynkAdo.ExecuteStoredProcedureAsync(StoredProcedureHelper.sp_MenuList, parameters);
            return result.ToList<MenuListResponseDto>();
        }
    }
}
