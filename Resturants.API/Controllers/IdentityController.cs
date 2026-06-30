using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturants.Application.User.Commands.AssignUserRole;
using Resturants.Application.User.Commands.UnAssignUserRole;
using Resturants.Application.User.Commands.UpdateUserDetails;
using Resturants.Domain.Constants;

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


        [HttpPatch("userRole")]
        [Authorize(Roles =UserRoles.Admin)]
        public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
        {

            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("userRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UnAssignUserRole(UnAssignUserRoleCommand command)
        {

            await mediator.Send(command);
            return NoContent();
        }

    }
}
