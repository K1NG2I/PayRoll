using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RFQ.Domain.ResponseDto;

namespace RFQ.Web.API.Filter
{
    public class CommanResponseResultFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var response = new CommanResponseDto
                {
                    StatusCode = objectResult.StatusCode,
                    Message = objectResult.StatusCode >= 200 && objectResult.StatusCode < 300 ? "Success" : "Failure",
                    Data = objectResult.Value
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = objectResult.StatusCode
                };
            }
            else if (context.Result is StatusCodeResult statusCodeResult)
            {
                var response = new CommanResponseDto
                {
                    StatusCode = statusCodeResult.StatusCode,
                    Message = statusCodeResult.StatusCode >= 200 && statusCodeResult.StatusCode < 300 ? "Success" : "Failure",
                    Data = null,
                    ErrorMessage = statusCodeResult.StatusCode >= 200 && statusCodeResult.StatusCode < 300 ? new List<string>().ToString() : new List<string> { "An error occurred" }.ToString()
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = statusCodeResult.StatusCode
                };
            }
            await next();
        }

    }

}