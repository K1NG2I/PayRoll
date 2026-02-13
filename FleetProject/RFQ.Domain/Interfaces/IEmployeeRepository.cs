using RFQ.Domain.Helper;
using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeById(int id);
        Task<Employee?> GetEmployeeByPan(string panNumber);
        Task<Employee?> GetEmployeeByAadhaar(string aadhaarNumber);
        Task<PageList<Employee>> GetAllEmployees(PagingParam pagingParam);
        Task<bool> UpdateEmployee(Employee employee);
    }
}
