using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Commands.Users.Commands.ProfileCommands;
using WebAPI.Commands.Users.Queries;

namespace WebAPI.Controllers
{
    [Route("api/profile/")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProfile([FromBody] CreateProfileCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] UserUpdateProfileCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(Guid id)
        {
            var result = await _mediator.Send(new ProfileGetByIdQuery(id));

            if (result.IsFailure)
                return NotFound(result.Error.Description);

            return Ok(result.Value);
        }
    }
}
