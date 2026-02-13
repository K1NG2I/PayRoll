using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly string _connectionString;
        private readonly ICommonRepositroy _commonRepositroy;

        public DeliveryRepository(FleetLynkDbContext appDbContext, IConfiguration configuration, ICommonRepositroy commonRepositroy)
        {
            _appDbContext = appDbContext;
            _connectionString = configuration.GetConnectionString("RfqDBConnection");
            _commonRepositroy = commonRepositroy;
        }

        public async Task<Delivery> AddDelivery(Delivery delivery)
        {
            await _appDbContext.AddAsync(delivery);
            await _appDbContext.SaveChangesAsync();
            return delivery;
        }

        public async Task DeleteDelivery(Delivery delivery)
        {
            _appDbContext.deliveries.Update(delivery);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<string> GenerateDocumentNo()
        {
            string nextDocumentNo = "";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("GetNextDocumentNo", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nextDocumentNo = reader["NextDocumentNo"].ToString();
                }
            }
            return nextDocumentNo;
        }

        public async Task<PageList<DeliveryResponseDto>> GetAllDelivery(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<DeliveryResponseDto>(StoredProcedureHelper.sp_GetDeliveryList, pagingParam);
        }

        public async Task<Delivery> GetDeliveryById(int id)
        {
            return await _appDbContext.deliveries.Where(x => x.DeliveryId == id && x.StatusId == (int)EStatus.IsActive).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateDelivery(Delivery delivery)
        {
            var existingDelivery = await GetDeliveryById(delivery.DeliveryId);
            if (existingDelivery != null)
            {
                delivery.CreatedOn = existingDelivery.CreatedOn;
                delivery.UpdatedOn = DateTime.Now;
                _appDbContext.deliveries.Update(delivery);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
