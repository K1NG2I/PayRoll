using RFQ.UI.Application.Interface;
using RFQ.UI.Domain.Interfaces;
using RFQ.UI.Domain.RequestDto;
using RFQ.UI.Domain.ResponseDto;

namespace RFQ.UI.Application.Provider
{
    public class ContactPersonDetailsService : IContactPersonDetailsService
    {
        private readonly IContactPersonDetailsAdaptor _adaptor;

        public ContactPersonDetailsService(
            IContactPersonDetailsAdaptor adaptor)
        {
            _adaptor = adaptor;
        }

        // =========================
        // LIST
        // =========================
        public async Task<List<ContactPersonDetailsResponseDto>> GetByEmployeeId(int employeeId)
        {
            var result = await _adaptor.GetByEmployeeId(employeeId);
            return result ?? new List<ContactPersonDetailsResponseDto>();
        }

        // =========================
        // ADD
        // =========================
        public async Task<bool> Add(ContactPersonDetailsRequestDto request)
        {
            return await _adaptor.Add(request);
        }

        // =========================
        // UPDATE
        // =========================
        public async Task<bool> Update(ContactPersonDetailsRequestDto request)
        {
            return await _adaptor.Update(request);
        }

        // =========================
        // DELETE
        // =========================
        public async Task<bool> Delete(int contactPersonDetailId, int updatedBy)
        {
            return await _adaptor.Delete(contactPersonDetailId, updatedBy);
        }
    }
}
