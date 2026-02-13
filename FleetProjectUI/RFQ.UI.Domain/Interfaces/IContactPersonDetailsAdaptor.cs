using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RFQ.UI.Domain.RequestDto;
using RFQ.UI.Domain.ResponseDto;

namespace RFQ.UI.Domain.Interfaces
{
    public interface IContactPersonDetailsAdaptor
    {
        // =========================
        // LIST BY EMPLOYEE
        // =========================
        Task<List<ContactPersonDetailsResponseDto>> GetByEmployeeId(int employeeId);

        // =========================
        // ADD
        // =========================
        Task<bool> Add(ContactPersonDetailsRequestDto request);

        // =========================
        // UPDATE
        // =========================
        Task<bool> Update(ContactPersonDetailsRequestDto request);

        // =========================
        // DELETE (SOFT)
        // =========================
        Task<bool> Delete(int contactPersonDetailId, int updatedBy);
    }
}

