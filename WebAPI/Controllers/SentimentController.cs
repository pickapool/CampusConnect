using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Commands.Sentiments.Commands;
using WebAPI.Commands.Sentiments.Queries;
using WebAPI.Commands.Users.Commands.ProfileCommands;
using WebAPI.Commands.Users.Queries;

namespace WebAPI.Controllers
{
    [Route("api/sentiment/")]
    [ApiController]
    [Authorize]
    public class SentimentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SentimentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddSentiment([FromBody] AddSentimentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSentiment([FromBody] DeleteSentimentCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return NotFound(result.Error.Description);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSentiments()
        {
            var result = await _mediator.Send(new GetSentimentsQuery());

            return Ok(result.Value);
        }
    }
}
