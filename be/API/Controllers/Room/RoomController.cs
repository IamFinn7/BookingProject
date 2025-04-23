using Application.Features.Room.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;

namespace API.Controllers.Room
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomController : BaseController
    {
        // private readonly IMediator _mediator;

        // public RoomController(IMediator mediator)
        // {
        //     _mediator = mediator;
        // }

        // [HttpGet]
        // [Authorize]
        // public async Task<IActionResult> GetRooms(
        //     string
        //     [FromQuery] string sortBy = "created_at:desc",
        //     [FromQuery] int page = 0,
        //     [FromQuery] int limit = 10
        // )
        // {
        //     var result = await _mediator.Send(new GetRooms(sortBy, page, limit));
        //     return Success(result, ResponseCode.OK.GetMessage());
        // }
    }
}
