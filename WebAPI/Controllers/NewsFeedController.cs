using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Commands.Feeds.Commands;

namespace WebAPI.Controllers
{
    [Route("api/post/")]
    [ApiController]
    [Authorize]
    public class NewsFeedController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsFeedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPost([FromBody] CreatePostCommand command)
        {
            var result = await _mediator.Send(command);

            if(result.IsSuccess)
                return Ok(result);

            return StatusCode(500);
        }
    }
}
