using HealthcareSystem.Business.Results;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareSystem.API.Controllers
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ControllerResult<T>(T data, bool IsSuccess = true, string message = "OK")
        {
            if (data.GetType().IsGenericType && data.GetType().GetGenericTypeDefinition() == typeof(GenericServiceResult<>))
            {
                return Ok(data);
            }
            return Ok(new Result<T> { Data = data, Message = message, IsSuccess = IsSuccess });

        }
    }
}
