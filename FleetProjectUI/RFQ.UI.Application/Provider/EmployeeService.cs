using RFQ.UI.Application.Interface;
using RFQ.UI.Domain.Helper;
using RFQ.UI.Domain.Interfaces;
using RFQ.UI.Domain.RequestDto;
using RFQ.UI.Domain.ResponseDto;

namespace RFQ.UI.Application.Provider
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly IEmployeeAdaptor _employeeAdaptor;

        public EmployeeService(IEmployeeAdaptor employeeAdaptor)
        {
            _employeeAdaptor = employeeAdaptor;
        }

        public async Task<PageList<EmployeeResponseDto>> GetAllEmployees(PagingParam pagingParam)
        {
            var result = await _employeeAdaptor.GetAllEmployees(pagingParam);
            return result ?? new PageList<EmployeeResponseDto>(new List<EmployeeResponseDto>(), 0, 0, 0);
        }
        public async Task<bool> UpdateEmployee(EmployeeUpdateRequestDto request)
        {
            if (request == null || request.EmployeeId <= 0)
                return false;

            return await _employeeAdaptor.UpdateEmployee(request);
        }
    }
}
