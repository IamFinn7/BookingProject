using API.DTOs.Hotel;
using Application.Hotel.Commands;
using Application.Hotel.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;

namespace API.Controllers.Hotel
{
    [ApiController]
    [Route("api/hotels")]
    public class HotelController : BaseController
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> GetHotels(
            [FromQuery] string sortBy = "created_at:desc",
            [FromQuery] int page = 0,
            [FromQuery] int limit = 10
        )
        {
            var result = await _mediator.Send(new GetHotels(sortBy, page, limit));
            return Success(result, ResponseCode.SUCCESS.GetMessage());
        }

        [HttpPost]
        // [Authorize]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelCommand hotelCommand)
        {
            var result = await _mediator.Send(hotelCommand);
            return Success(
                result,
                ResponseCode.CREATED_SUCCESS.GetMessage(),
                ResponseCode.CREATED_SUCCESS.GetCode()
            );
        }

        [HttpPut("{id}")]
        // [Authorize]
        public async Task<IActionResult> UpdateHotel(
            string id,
            [FromBody] UpdateHotelRequest request
        )
        {
            await _mediator.Send(
                new UpdateHotelCommand(
                    id,
                    request.Name,
                    request.Address,
                    request.City,
                    request.Country,
                    request.Amenities,
                    request.Images
                )
            );
            return Success(ResponseCode.UPDATED_SUCCESS.GetMessage());
        }
    }
}
