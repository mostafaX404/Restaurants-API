using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Entities;
using Resturants.Domain.Exceptions;

namespace Resturants.Application.User.Commands.AssignUserRole
{
    public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger,
        UserManager<AppUser> userManager , RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRoleCommand>
    {
        public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Assigning user role : {request.RoleName} to the user : {request.Email}");

            var user = await userManager.FindByEmailAsync(request.Email)
                ?? throw new NotFoundExceptions(nameof(AppUser),request.Email) ;

            var role = await roleManager.FindByNameAsync(request.RoleName)
                ?? throw new NotFoundExceptions(nameof(IdentityRole), request.RoleName);

            await userManager.AddToRoleAsync(user, role.Name!);

           
        
        }
    }
}
