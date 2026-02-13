using Microsoft.AspNetCore.Mvc;
using RFQ.UI.Application.Interface;
using RFQ.UI.Domain.RequestDto;
using RFQ.UI.Extension;

namespace RFQ.UI.Controllers
{
    public class ContactPersonDetailsController : Controller
    {
        private readonly IContactPersonDetailsService _contactPersonService;

        public ContactPersonDetailsController(
            IContactPersonDetailsService contactPersonService)
        {
            _contactPersonService = contactPersonService;
        }

        // =========================
        // LIST BY EMPLOYEE (AJAX)
        // =========================
        [HttpGet]
        public async Task<IActionResult> GetByEmployee(int employeeId)
        {
            try
            {
                var result = await _contactPersonService
                    .GetByEmployeeId(employeeId);

                if (Request.IsAjaxRequest())
                    return Json(result);

                return View(result);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = "error",
                    message = ex.Message
                });
            }
        }

        // =========================
        // ADD
        // =========================
        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] ContactPersonDetailsRequestDto request)
        {
            if (request == null || request.EmployeeId <= 0)
            {
                return Json(new
                {
                    result = "error",
                    message = "Invalid contact person data."
                });
            }

            try
            {
                var success = await _contactPersonService.Add(request);

                return Json(new
                {
                    result = success ? "success" : "error"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = "error",
                    message = ex.Message
                });
            }
        }

        // =========================
        // UPDATE
        // =========================
        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] ContactPersonDetailsRequestDto request)
        {
            if (request == null || request.ContactPersonDetailId <= 0)
            {
                return Json(new
                {
                    result = "error",
                    message = "Invalid contact person data."
                });
            }

            try
            {
                var success = await _contactPersonService.Update(request);

                return Json(new
                {
                    result = success ? "success" : "error"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = "error",
                    message = ex.Message
                });
            }
        }

        // =========================
        // DELETE (SOFT)
        // =========================
        [HttpDelete]
        public async Task<IActionResult> Delete(
            int contactPersonDetailId,
            int updatedBy)
        {
            if (contactPersonDetailId <= 0)
            {
                return Json(new
                {
                    result = "error",
                    message = "Invalid contact person id."
                });
            }

            try
            {
                var success = await _contactPersonService
                    .Delete(contactPersonDetailId, updatedBy);

                return Json(new
                {
                    result = success ? "success" : "error"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = "error",
                    message = ex.Message
                });
            }
        }
    }
}
