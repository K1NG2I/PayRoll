using Microsoft.AspNetCore.Mvc;
using RFQ.UI.Application.Interface;
using RFQ.UI.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RFQ.UI.Controllers
{
    public class TestController : BaseController
    {
        private static readonly object _lock = new object();

        // =========================
        // TEMP IN-MEMORY DATA
        // =========================
        private static List<TestModel> _tests = new()
        {
            new TestModel
            {
                TestId = 1,
                PersonName = "Alice",
                Company = "Acme",
                Location = "HQ",
                MobileNo = "9999999991",
                EmailId = "alice@example.com",
                IsActive = true
            },
            new TestModel
            {
                TestId = 2,
                PersonName = "Bob",
                Company = "Beta",
                Location = "Branch",
                MobileNo = "9999999992",
                EmailId = "bob@example.com",
                IsActive = true
            },
            new TestModel
            {
                TestId = 3,
                PersonName = "Carol",
                Company = "Gamma",
                Location = "Remote",
                MobileNo = "9999999993",
                EmailId = "carol@example.com",
                IsActive = false
            }
        };

        public TestController(IMenuServices menuServices, GlobalClass globalClass)
            : base(menuServices, globalClass)
        {
        }

        public async Task<IActionResult> Index()
        {
            await SetMenuAsync();

            return View();
        }

        // =========================
        // LIST
        // =========================
        [HttpPost("Test/ViewTestList")]
        public IActionResult ViewTestList([FromBody] object paging)
        {
            return Json(new
            {
                draw = 1,
                recordsTotal = _tests.Count,
                recordsFiltered = _tests.Count,
                data = _tests,
                displayColumn =
                    "PersonName as test Name," +
                    "Company as Franchise/Corporate Name," +
                    "Location as Location," +
                    "MobileNo as Phone Number," +
                    "EmailId as Email," +
                    "IsActive as IsActive"
            });
        }

        // =========================
        // EDIT (IN-MEMORY UPDATE)
        // =========================
        [HttpPut("Test/EditTest")]
        public IActionResult EditTest([FromBody] TestModel request)
        {
            if (request == null)
            {
                return Json(new { result = "error", message = "Invalid payload" });
            }

            try
            {
                lock (_lock)
                {
                    var test = _tests.FirstOrDefault(x => x.TestId == request.TestId);
                    if (test == null)
                    {
                        return Json(new { result = "error", message = "Test not found" });
                    }

                    test.PersonName = request.PersonName;
                    test.IsActive = request.IsActive;
                }

                return Json(new
                {
                    result = "success",
                    message = "Test updated successfully"
                });
            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = ex.Message });
            }
        }
    }

    // =========================
    // MODELS
    // =========================
    public class TestModel
    {
        public int TestId { get; set; }
        public string PersonName { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
    }

    public class TestEditRequestDto
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public bool Status { get; set; }
    }
}
