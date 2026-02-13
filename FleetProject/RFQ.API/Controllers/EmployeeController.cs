using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        /// <summary>
        /// Get paged list of employees. POST body: PagingParam (ProfileId, CompanyId, Draw, Start, Length, SearchValue, OrderColumn, OrderDir).
        /// </summary>
        [HttpPost("GetAllEmployees")]
        public async Task<ActionResult> GetAllEmployees([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("GetAllEmployees");
                var result = await _employeeService.GetAllEmployees(pagingParam);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAllEmployees failed.");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get employee by ID. POST body: { "id": 1 }
        /// </summary>
        [HttpPost("GetEmployeeById")]
        public async Task<ActionResult<Employee>> GetEmployeeById([FromBody] GetEmployeeByIdRequest request)
        {
            try
            {
                _logger.LogInformation("GetEmployeeById for Id: {Id}", request.Id);
                var employee = await _employeeService.GetEmployeeById(request.Id);
                if (employee == null)
                    return NotFound(new { message = "Employee not found." });
                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetEmployeeById failed.");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get employee by PAN. POST body: { "panNumber": "ABCDE1234F" }
        /// </summary>
        [HttpPost("GetEmployeeByPan")]
        public async Task<ActionResult<Employee>> GetEmployeeByPan([FromBody] GetEmployeeByPanRequest request)
        {
            try
            {
                _logger.LogInformation("GetEmployeeByPan for Pan: {Pan}", request.PanNumber);
                var employee = await _employeeService.GetEmployeeByPan(request.PanNumber);
                if (employee == null)
                    return NotFound(new { message = "Employee not found." });
                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetEmployeeByPan failed.");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get employee by Aadhaar. POST body: { "aadhaarNumber": "123456789012" }
        /// </summary>
        [HttpPost("GetEmployeeByAadhaar")]
        public async Task<ActionResult<Employee>> GetEmployeeByAadhaar([FromBody] GetEmployeeByAadhaarRequest request)
        {
            try
            {
                _logger.LogInformation("GetEmployeeByAadhaar for Aadhaar: {Aadhaar}", request.AadhaarNumber);
                var employee = await _employeeService.GetEmployeeByAadhaar(request.AadhaarNumber);
                if (employee == null)
                    return NotFound(new { message = "Employee not found." });
                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetEmployeeByAadhaar failed.");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest request)
        {
            try
            {
                if (request == null || request.EmployeeId <= 0)
                {
                    return BadRequest(new
                    {
                        IsSuccess = false,
                        Message = "Invalid employee data."
                    });
                }

                _logger.LogInformation(
                    "UpdateEmployee called for EmployeeId: {EmployeeId}",
                    request.EmployeeId
                );

                var employee = new Employee
                {
                    EmployeeId = request.EmployeeId,
                    FullName = request.FullName,
                    ContactNumber = request.ContactNumber,
                    AadhaarNumber = request.AadhaarNumber,
                    PanNumber = request.PanNumber,
                    Salary = request.Salary,
                    HireDate = request.HireDate,
                    IsActive = request.IsActive,
                    UpdatedBy = request.UpdatedBy,
                    UpdatedOn = DateTime.UtcNow
                };

                var result = await _employeeService.UpdateEmployee(employee);

                if (!result)
                {
                    return NotFound(new
                    {
                        IsSuccess = false,
                        Message = "Employee not found."
                    });
                }

                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Employee updated successfully."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update Employee failed.");
                return StatusCode(500, new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

    }
}
