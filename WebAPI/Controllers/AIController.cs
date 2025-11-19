using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Commands.AICommands;
using WebAPI.Commands.Users.Commands.ProfileCommands;
using WebAPI.Commands.Users.Queries;

namespace WebAPI.Controllers
{
    [Route("api/ai/")]
    [ApiController]
    [Authorize]
    public class AIController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetBadWords([FromBody] GetListOfCommentsSentimentsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result.Value);
        }
    }
}
