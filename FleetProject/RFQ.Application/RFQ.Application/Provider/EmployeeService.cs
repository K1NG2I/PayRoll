using RFQ.Application.Interface;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetEmployeeById(id);
        }

        public async Task<Employee?> GetEmployeeByPan(string panNumber)
        {
            return await _employeeRepository.GetEmployeeByPan(panNumber);
        }

        public async Task<Employee?> GetEmployeeByAadhaar(string aadhaarNumber)
        {
            return await _employeeRepository.GetEmployeeByAadhaar(aadhaarNumber);
        }

        public async Task<PageList<Employee>> GetAllEmployees(PagingParam pagingParam)
        {
            return await _employeeRepository.GetAllEmployees(pagingParam);
        }
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            if (employee == null || employee.EmployeeId <= 0)
                return false;

            return await _employeeRepository.UpdateEmployee(employee);
        }
    }
}
