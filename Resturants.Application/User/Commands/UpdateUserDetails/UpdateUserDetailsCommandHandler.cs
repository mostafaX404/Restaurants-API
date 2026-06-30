using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturants.Domain.Exceptions;

namespace Resturants.Application.User.Commands.UpdateUserDetails
{
    public class UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommandHandler> logger ,
        IUserContext userContext , IUserStore<AppUser> userStore) : IRequestHandler<UpdateUserDetailsCommand>
    {
        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation($"Updating user : {user!.Id} with new data : {request}");

            var dbUser =  await userStore.FindByIdAsync(user!.Id,cancellationToken);

            if (dbUser == null)
            {
                throw new NotFoundExceptions(nameof(User),user!.Id);
            }

            dbUser.Nationality = request.Nationality;
            dbUser.DateOfBirth = request.DateOfBirth;

            userStore.UpdateAsync(dbUser, cancellationToken);
        }
    }
}
