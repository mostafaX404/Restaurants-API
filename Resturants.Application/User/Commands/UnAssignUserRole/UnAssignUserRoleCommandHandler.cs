using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Resturants.Application.User.Commands.AssignUserRole;
using Resturants.Domain.Entities;
using Resturants.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.User.Commands.UnAssignUserRole
{
    public class UnAssignUserRoleCommandHandler(ILogger<UnAssignUserRoleCommandHandler> logger,
        UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<UnAssignUserRoleCommand>
    {
        public  async Task Handle(UnAssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"UnAssigning user role : {request.RoleName} to the user : {request.Email}");

            var user = await userManager.FindByEmailAsync(request.Email)
                ?? throw new NotFoundExceptions(nameof(AppUser), request.Email);

            var role = await roleManager.FindByNameAsync(request.RoleName)
                ?? throw new NotFoundExceptions(nameof(IdentityRole), request.RoleName);

            await userManager.RemoveFromRoleAsync(user, role.Name!);

        }
    }
}
