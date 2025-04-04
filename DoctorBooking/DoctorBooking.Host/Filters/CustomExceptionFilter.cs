using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using DoctorBooking.Host.Exceptions.Base;
using DoctorBooking.Shared.Exceptions;

namespace DoctorBooking.Host.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)

        {
            var problemDetails = new ProblemDetails
            {
                Type = "https://example.com/problems/internal-server-error",
                Title = "Internal Server Error",
                Status = 500,
                Extensions =
            {
                ["error"] = new Dictionary<string, string>
                {
                    {"Code", "InternalError" },
                    {"message" , "An error occurred while processing your request" }
                }
            }
            };


            IActionResult result = new ObjectResult(problemDetails)
            {
                StatusCode = 500
            };

            if (context.Exception is AppException ex)
            {
                // Filling the problemDetails object
                problemDetails.Type = ex.Type;
                problemDetails.Title = ex.Title;
                problemDetails.Status = ex.Status;



                problemDetails.Extensions["error"] = new Dictionary<string, string>
                {
                    {"Code", ex.Code },
                    {"message" , ex.Message }
                };

                if (ex is ValidationException vex && vex.Errors != null)
                {

                    problemDetails.Extensions["errors"] = vex.Errors;
                }

                result = new ObjectResult(problemDetails)
                {
                    StatusCode = ex.Status
                };
            }


            var traceId = context.HttpContext.TraceIdentifier;
            if (!string.IsNullOrEmpty(traceId))
            {
                problemDetails.Extensions["traceId"] = traceId;
            }



            context.Result = result;


            context.ExceptionHandled = true;
        }

    }
}



