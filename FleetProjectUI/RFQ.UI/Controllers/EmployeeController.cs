using Microsoft.AspNetCore.Mvc;
using RFQ.UI.Application.Interface;
using RFQ.UI.Domain.Model;
using RFQ.UI.Domain.RequestDto;
using RFQ.UI.Extension;

namespace RFQ.UI.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices, IMenuServices menuServices, GlobalClass globalClass)
            : base(menuServices, globalClass)
        {
            _employeeServices = employeeServices;
        }

        public async Task<IActionResult> Index()
        {
            await SetMenuAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ViewEmployeeList([FromBody] PagingParam pagingParam)
        {
            try
            {
                var result = await _employeeServices.GetAllEmployees(pagingParam);
                if (Request.IsAjaxRequest())
                {
                    return Json(new
                    {
                        draw = result.PageNumber,
                        recordsTotal = result.TotalRecordCount,
                        recordsFiltered = result.TotalRecordCount,
                        displayColumn = result.DisplayColumns,
                        data = result.Result
                    });
                }
                return View(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> EditEmployee([FromBody] EmployeeUpdateRequestDto request)
        {
            if (request == null)
            {
                return Json(new { result = "error", message = "Invalid request" });
            }

            try
            {
                var result = await _employeeServices.UpdateEmployee(request);

                if (result)
                {
                    return Json(new
                    {
                        result = "success",
                        message = "Employee updated successfully"
                    });
                }

                return Json(new
                {
                    result = "error",
                    message = "Failed to update employee"
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
