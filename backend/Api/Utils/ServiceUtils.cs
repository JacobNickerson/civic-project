using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.ServiceUtils
{
    public enum ServiceReturnCode
    {
        Success,
        NotFound,
        Unauthorized,
        InvalidInput,
        Conflict,
        InternalError
    }
    public static class ServiceHelper
    {
        public static IActionResult HandleReturnCode(ServiceReturnCode code)
        {
            return code switch
            {
                ServiceReturnCode.NotFound => new NotFoundResult(),
                ServiceReturnCode.Unauthorized => new UnauthorizedResult(),
                ServiceReturnCode.InvalidInput => new BadRequestObjectResult(new { err="Invalid input" }),
                ServiceReturnCode.Conflict => new ConflictResult(),
                ServiceReturnCode.InternalError => new StatusCodeResult(420), // This shouldn't actually happen, its a fake code
                ServiceReturnCode.Success => new OkResult(),
                _ => throw new NotImplementedException()
            };
        }
    }
}