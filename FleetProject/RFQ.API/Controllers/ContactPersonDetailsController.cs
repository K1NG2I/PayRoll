using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.UI.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ContactPersonDetailsController : ControllerBase
    {
        private readonly IContactPersonDetailsService _contactPersonService;
        private readonly ILogger<ContactPersonDetailsController> _logger;

        public ContactPersonDetailsController(
            IContactPersonDetailsService contactPersonService,
            ILogger<ContactPersonDetailsController> logger)
        {
            _contactPersonService = contactPersonService;
            _logger = logger;
        }

        // =========================
        // GET BY EMPLOYEE
        // =========================
        [HttpGet("GetByEmployee/{employeeId}")]
        public async Task<IActionResult> GetByEmployee(int employeeId)
        {
            try
            {
                var result = await _contactPersonService
                    .GetContactPersonsByEmployee(employeeId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetByEmployee failed");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // =========================
        // GET BY ID
        // =========================
        [HttpGet("GetById/{ContactPersonId}")]
        public async Task<IActionResult> GetById(int ContactPersonId)
        {
            var result = await _contactPersonService
                .GetContactPersonById(ContactPersonId);

            if (result == null)
                return NotFound(new { message = "Contact person not found." });

            return Ok(result);
        }

        // =========================
        // ADD
        // =========================
        [HttpPost("Add")]
        public async Task<IActionResult> Add(
            [FromBody] ContactPersonDetailsRequestDto request)
        {
            if (request == null || request.EmployeeId <= 0)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = "Invalid contact person data."
                });
            }

            try
            {
                var model = new ContactPersonDetails
                {
                    EmployeeId = request.EmployeeId,
                    Relation = request.Relation,
                    ContactPersonName = request.ContactPersonName,
                    AadhaarNumber = request.AadhaarNumber,
                    PanNumber = request.PanNumber,
                    IsActive = request.IsActive,
                    CreatedOn = DateTime.UtcNow
                };

                var result = await _contactPersonService.AddContactPerson(model);

                return Ok(new
                {
                    IsSuccess = true,
                    Message = result
                        ? "Contact person added successfully."
                        : "Failed to add contact person."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Add ContactPersonDetails failed.");
                return StatusCode(500, new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        // =========================
        // UPDATE
        // =========================
        [HttpPost("Update")]
        public async Task<IActionResult> Update(
            [FromBody] ContactPersonDetailsRequestDto request)
        {
            if (request == null || request.ContactPersonDetailId <= 0)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = "Invalid contact person data."
                });
            }

            try
            {
                var model = new ContactPersonDetails
                {
                    ContactPersonDetailId = request.ContactPersonDetailId,
                    EmployeeId = request.EmployeeId,
                    Relation = request.Relation,
                    ContactPersonName = request.ContactPersonName,
                    AadhaarNumber = request.AadhaarNumber,
                    PanNumber = request.PanNumber,
                    IsActive = request.IsActive,
                    UpdatedOn = DateTime.UtcNow
                };

                var result = await _contactPersonService.UpdateContactPerson(model);

                return Ok(new
                {
                    IsSuccess = true,
                    Message = result
                        ? "Contact person updated successfully."
                        : "Contact person not found."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update ContactPersonDetails failed.");
                return StatusCode(500, new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        // =========================
        // SOFT DELETE
        // =========================
        [HttpDelete("Delete/{ContactPersonId}/{updatedBy}")]
        public async Task<IActionResult> Delete(
            int ContactPersonId,
            int updatedBy)
        {
            try
            {
                var result = await _contactPersonService
                    .DeleteContactPerson(ContactPersonId, updatedBy);

                return Ok(new
                {
                    IsSuccess = result,
                    Message = result
                        ? "Contact person deleted successfully."
                        : "Contact person not found."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete ContactPersonDetails failed.");
                return StatusCode(500, new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }
    }
}
