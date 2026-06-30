
using Microsoft.AspNetCore.Authorization;
using Resturants.Application.User;
using Resturants.Domain.Interfaces;

namespace Resturants.Infrastructure.Authorization.Requirements;

internal class CreatedMultipleRestaurantsRequirementHandler(IResturantRepository restaurantsRepository,
    IUserContext userContext) : AuthorizationHandler<CreatingMultipleResturantRequirment>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        CreatingMultipleResturantRequirment requirement)
    {
        var currentUser = userContext.GetCurrentUser();

        var restaurants = await restaurantsRepository.GetAllAsync();

        var userRestaurantsCreated = restaurants.Count(r => r.OwnerId == currentUser!.Id);

        if (userRestaurantsCreated >= requirement.MinimumRestaurantsCreated)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }
}

