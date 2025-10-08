using CamCon.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Commands.Organizations.Commands;
using WebAPI.Commands.Users.Commands.CreateCommand;

namespace WebAPI.Controllers
{
    [Route("api/dept")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly ISender _mediator;

        public DepartmentController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
