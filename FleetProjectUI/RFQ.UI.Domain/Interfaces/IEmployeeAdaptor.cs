using RFQ.UI.Domain.Helper;
using RFQ.UI.Domain.RequestDto;
using RFQ.UI.Domain.ResponseDto;

namespace RFQ.UI.Domain.Interfaces
{
    public interface IEmployeeAdaptor
    {
        Task<PageList<EmployeeResponseDto>?> GetAllEmployees(PagingParam pagingParam);
        Task<bool> UpdateEmployee(EmployeeUpdateRequestDto request);
    }
}
