using API.DTOs.Hotel;
using Application.Hotel.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;

namespace API.Controllers.Hotel
{
    [ApiController]
    [Route("api/hotels/review")]
    public class HotelReviewController : BaseController
    {
        private readonly IMediator _mediator;

        public HotelReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        // [Authorize]
        public async Task<IActionResult> CreateHotelReview(
            [FromBody] CreateHotelReviewCommand hotelReviewCommand
        )
        {
            var result = await _mediator.Send(hotelReviewCommand);
            return Success(
                result,
                ResponseCode.CREATED_SUCCESS.GetMessage(),
                ResponseCode.CREATED_SUCCESS.GetCode()
            );
        }

        [HttpPut("{id}")]
        // [Authorize]
        public async Task<IActionResult> UpdateHotelReview(
            string id,
            [FromBody] UpdateHotelReviewRequest request
        )
        {
            var userId = "";
            await _mediator.Send(
                new UpdateHotelReviewCommand(
                    id,
                    userId,
                    request.Cleanliness,
                    request.Location,
                    request.Service,
                    request.Facilities,
                    request.Comment
                )
            );
            return Success(ResponseCode.UPDATED_SUCCESS.GetMessage());
        }

        [HttpDelete("{id}")]
        // [Authorize]
        public async Task<IActionResult> DeleteHotelReview(string id)
        {
            await _mediator.Send(new DeleteHotelReviewCommand(id));
            return Success(ResponseCode.DELETE_SUCCESS.GetMessage());
        }
    }
}
