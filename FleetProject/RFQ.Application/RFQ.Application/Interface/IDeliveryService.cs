using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Application.Interface
{
    public interface IDeliveryService
    {
        Task<string> GenerateDocumentNo();
        Task<Delivery> AddDelivery(Delivery delivery);
        Task<PageList<DeliveryResponseDto>> GetAllDelivery(PagingParam pagingParam);
        Task<Delivery> GetDeliveryById(int id);
        Task UpdateDelivery(Delivery delivery);
        Task<int> DeleteDelivery(int id);
    }
}
