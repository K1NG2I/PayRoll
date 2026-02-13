using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly FleetLynkDbContext _context;

        public EmployeeRepository(FleetLynkDbContext context)
        {
            _context = context;
        }

        public async Task<PageList<Employee>> GetAllEmployees(PagingParam pagingParam)
        {
            var query = _context.employees.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagingParam.SearchValue))
            {
                var term = pagingParam.SearchValue.Trim().ToLower();
                query = query.Where(x =>
                    (x.FullName != null && x.FullName.ToLower().Contains(term)) ||
                    (x.ContactNumber != null) ||
                    (x.AadhaarNumber != null && x.AadhaarNumber.Contains(term)) ||
                    (x.PanNumber != null && x.PanNumber.ToLower().Contains(term)));
            }

            var totalCount = await query.CountAsync();

            var pageSize = pagingParam.Length > 0 ? pagingParam.Length : 10;
            if (pagingParam.Length == -1) pageSize = totalCount > 0 ? totalCount : 1000;
            var pageNumber = pageSize > 0 ? (pagingParam.Start / pageSize) + 1 : 1;

            IOrderedQueryable<Employee> ordered = query.OrderBy(x => x.EmployeeId);
            if (!string.IsNullOrWhiteSpace(pagingParam.OrderColumn))
            {
                var desc = string.Equals(pagingParam.OrderDir, "DESC", StringComparison.OrdinalIgnoreCase);
                ordered = pagingParam.OrderColumn.ToLowerInvariant() switch
                {
                    "fullname" => desc ? query.OrderByDescending(x => x.FullName) : query.OrderBy(x => x.FullName),
                    "contactnumber" => desc ? query.OrderByDescending(x => x.ContactNumber) : query.OrderBy(x => x.ContactNumber),
                    "pannumber" => desc ? query.OrderByDescending(x => x.PanNumber) : query.OrderBy(x => x.PanNumber),
                    "aadhaarnumber" => desc ? query.OrderByDescending(x => x.AadhaarNumber) : query.OrderBy(x => x.AadhaarNumber),
                    "isactive" => desc ? query.OrderByDescending(x => x.IsActive) : query.OrderBy(x => x.IsActive),
                    _ => query.OrderBy(x => x.EmployeeId)
                };
            }

            var items = await ordered
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            const string displayColumns = "FullName as Full Name,ContactNumber as Contact,AadhaarNumber as Aadhaar,PanNumber as PAN,Salary as Salary,HireDate as Hire Date,IsActive as IsActive";
            return new PageList<Employee>(items, totalCount, pageNumber, pageSize, displayColumns);
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _context.employees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task<Employee?> GetEmployeeByPan(string panNumber)
        {
            if (string.IsNullOrWhiteSpace(panNumber)) return null;
            return await _context.employees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PanNumber == panNumber.Trim());
        }

        public async Task<Employee?> GetEmployeeByAadhaar(string aadhaarNumber)
        {
            if (string.IsNullOrWhiteSpace(aadhaarNumber)) return null;
            return await _context.employees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.AadhaarNumber == aadhaarNumber.Trim());
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var existingEmployee = await _context.employees
                .FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);

            if (existingEmployee == null)
                return false;

            existingEmployee.FullName = employee.FullName;
            existingEmployee.ContactNumber = employee.ContactNumber;
            existingEmployee.AadhaarNumber = employee.AadhaarNumber;
            existingEmployee.PanNumber = employee.PanNumber;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.HireDate = employee.HireDate;
            existingEmployee.IsActive = employee.IsActive;
            existingEmployee.UpdatedOn = DateTime.UtcNow;
            existingEmployee.UpdatedBy = employee.UpdatedBy;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
