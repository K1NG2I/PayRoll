using RFQ.Application.Helper;
using RFQ.Application.Interface;
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

namespace RFQ.Application.Provider
{
    public class DeliveryService : IDeliveryService
    {
        private IDeliveryRepository _deliveryRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;

        public DeliveryService(IDeliveryRepository deliveryRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _deliveryRepository = deliveryRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }

        public async Task<string> GenerateDocumentNo()
        {
            return await _deliveryRepository.GenerateDocumentNo();
        }

        public async Task<Delivery> AddDelivery(Delivery delivery)
        {
            return await _deliveryRepository.AddDelivery(delivery);
        }

        public async Task<PageList<DeliveryResponseDto>> GetAllDelivery(PagingParam pagingParam)
        {
            var result = await _deliveryRepository.GetAllDelivery(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.Delivery);
            return result;

        }

        public async Task<Delivery> GetDeliveryById(int id)
        {
            return await _deliveryRepository.GetDeliveryById(id);
        }

        public async Task UpdateDelivery(Delivery delivery)
        {
             await _deliveryRepository.UpdateDelivery(delivery);
        }

        public async Task<int> DeleteDelivery(int id)
        {
            var delivery = await _deliveryRepository.GetDeliveryById(id);
            if (delivery != null)
            {
                delivery.StatusId = (int)EStatus.Deleted;
                await _deliveryRepository.DeleteDelivery(delivery);
                return 1;
            }
            return 0;
        }
    }
}
