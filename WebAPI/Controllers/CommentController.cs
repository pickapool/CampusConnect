using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Commands.Comments.Commands;
using WebAPI.Commands.Comments.Queries;
using WebAPI.Commands.Likes.Commands;

namespace WebAPI.Controllers
{
    [Route("api/comment/")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] AddCommentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result.Value);
        }

        [HttpGet("{newsFeedId}")]
        public async Task<IActionResult> AddComment(Guid newsFeedId)
        {
            var result = await _mediator.Send(new GetCommentsByNewsFeedIdCommand(newsFeedId));

            return Ok(result.Value);
        }
    }
}
