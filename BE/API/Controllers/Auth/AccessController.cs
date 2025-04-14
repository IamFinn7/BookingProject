using Application.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Auth
{
    [ApiController]
    [Route("api/access")]
    public class AccessController : BaseController
    {
        private readonly IMediator _mediator;

        public AccessController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
