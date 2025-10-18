
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Commands.Notifications.Queries;

namespace WebAPI.Controllers
{
    [Route("api/notify/")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly ISender _mediator;

        public NotificationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var result = await _mediator.Send(new GetAllNotificationsQuery());

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdNotificationQuery(id));

            return Ok(result.Value);
        }
    }
}
