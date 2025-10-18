using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Commands.AdminPageRequests.Commands;
using WebAPI.Commands.Notifications.Queries;

namespace WebAPI.Controllers
{
    [Route("api/pagerequest/")]
    [ApiController]
    [Authorize]
    public class AdminPageRequestController : ControllerBase
    {
        private readonly ISender _mediator;

        public AdminPageRequestController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestAdminCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
