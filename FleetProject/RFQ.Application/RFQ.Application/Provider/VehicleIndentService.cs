using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class VehicleIndentService : IVehicleIndentService
    {
        private readonly IVehicleIndentRepository _vehicleIndentRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;
        public VehicleIndentService(IVehicleIndentRepository vehicleIndentRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _vehicleIndentRepository = vehicleIndentRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }

        public async Task<bool> AddVehicleIndent(VehicleIndent vehicleIndent)
        {
            return await _vehicleIndentRepository.AddVehicleIndent(vehicleIndent);
        }

        public async Task<bool> DeleteVehicleIndent(int id)
        {
            try
            {
                var result = await _vehicleIndentRepository.GetVehicleIndentById(id);
                if (result != null)
                {
                    result.StatusId = (int)EStatus.Deleted;
                    return await _vehicleIndentRepository.DeleteVehicleIndent(result);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GenerateVehicleIndent()
        {
            return await _vehicleIndentRepository.GenerateVehicleIndent();
        }

        public async Task<PageList<VehicleIndentResponseDto>> GetAllVehicleIndent(PagingParam pagingParam)
        {
            var result = await _vehicleIndentRepository.GetAllVehicleIndent(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.VehicleIndent);
            return result;
        }

        public async Task<IEnumerable<VehicleIndent>> GetAllVehicleIndentList(int companyId)
        {
            return await _vehicleIndentRepository.GetAllVehicleIndentList(companyId);
        }

        public async Task<VehicleIndent> GetVehicleIndentById(int id)
        {
            return await _vehicleIndentRepository.GetVehicleIndentById(id);
        }

        public async Task UpdateVehicleIndent(VehicleIndent vehicleIndent)
        {
            await _vehicleIndentRepository.UpdateVehicleIndent(vehicleIndent);
        }
        public async Task<bool> IndentReferenceCheckInRfqAsync(int indentId)
        {
            return await _vehicleIndentRepository.IndentReferenceCheckInRfqAsync(indentId);
        }
    }
}
