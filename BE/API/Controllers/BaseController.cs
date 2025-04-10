using API.Response;
using Microsoft.AspNetCore.Mvc;

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
                    option = option,
                    metadata = data,
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

        protected IActionResult InternalServerError(string message = "INTERNAL_SERVER_ERROR")
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new ErrorResponse
                {
                    status = StatusCodes.Status500InternalServerError,
                    message = message,
                }
            );
        }

        protected IActionResult AuthorizationError(string message)
        {
            return StatusCode(
                StatusCodes.Status401Unauthorized,
                new ErrorResponse { status = StatusCodes.Status401Unauthorized, message = message }
            );
        }

        protected IActionResult Failure(int status, string message)
        {
            if (status == StatusCodes.Status404NotFound)
            {
                return NotFound(new ErrorResponse { status = status, message = message });
            }
            return BadRequest(new ErrorResponse { status = status, message = message });
        }
    }
}
