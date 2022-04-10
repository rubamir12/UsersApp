using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Dtos;
using Users.Application.Features.Queries;

namespace Users.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetMenUnder25()
        {
            IEnumerable<UserDto> result = await _mediator.Send(new GetMenUnder25Query()).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetYoungestMan()
        {
            UserDto result = await _mediator.Send(new GetYoungestManQuery()).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetWomenOver40()
        {
            IEnumerable<UserDto> result = await _mediator.Send(new GetWomenOver40Query()).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetWomenWithManagerAndAdminRoles()
        {
            IEnumerable<UserDto> result = await _mediator.Send(new GetWomenWithManagerAndAdminRolesQuery()).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetManagersStartingWithJo()
        {
            IEnumerable<UserDto> result = await _mediator.Send(new GetManagersStartingWithJoQuery()).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> ExportUsersToFile()
        {
            string result = await _mediator.Send(new ExportUsersToFileQuery()).ConfigureAwait(false);
            return Ok(result);
        }
    }
}