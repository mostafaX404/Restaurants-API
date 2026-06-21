using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturants.Application.User.Commands;

namespace Resturants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(IMediator mediator) : ControllerBase
    {
        [HttpPatch("user")]
        [Authorize]
        public async Task<IActionResult> UpdateUserDetails (UpdateUserDetailsCommand command)
        {

            await mediator.Send(command);
            return NoContent();
        }

    }
}
