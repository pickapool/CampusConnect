using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Commands.Likes.Commands;

namespace WebAPI.Controllers
{
    [Route("api/post/like/")]
    [ApiController]
    [Authorize]
    public class LikeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLike([FromBody] LikeUpdateCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result.Value);
        }
    }
}
