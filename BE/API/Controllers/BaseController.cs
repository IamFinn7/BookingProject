using Microsoft.AspNetCore.Mvc;
using Shared.Responses;

namespace API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult Success<T>(
            T data,
            string message,
            int status = StatusCodes.Status200OK,
            Option option = null
        )
        {
            if (option == null)
            {
                return Ok(
                    new SuccessCommandResponse<T>
                    {
                        status = status,
                        message = message,
                        metadata = data,
                    }
                );
            }
            return Ok(
                new SuccessQueryResponse<T>
                {
                    status = status,
                    message = message,
                    metadata = data,
                    option = option,
                }
            );
        }

        protected IActionResult Success(
            string message,
            int status = StatusCodes.Status200OK,
            Option option = null
        )
        {
            if (option == null)
            {
                return Ok(new SuccessResponse { status = status, message = message });
            }
            return Ok(
                new SuccessOptionResponse
                {
                    status = status,
                    message = message,
                    option = option,
                }
            );
        }

        protected IActionResult Failure(int status, string message)
        {
            return StatusCode(status, new ErrorResponse { status = status, message = message });
        }
    }
}
