
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Constants;
using Resturants.Domain.Entities;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Interfaces;

namespace Resturants.Application.Dishs.Commands.DeleteDishes
{
    public class DeleteAllDishesOfResturantCommandHandler(ILogger<DeleteAllDishesOfResturantCommandHandler> logger,
        IDishRepository dishRepo ,IResturantRepository resturantRepo,
        IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<DeleteAllDishesOfResturantCommand>
    {
        public async Task Handle(DeleteAllDishesOfResturantCommand request, CancellationToken cancellationToken)
        {
            logger.LogWarning($"Removing all dishes from resturant : {request.ResturantId}");
            var resturant = await resturantRepo.GetByIdAsync(request.ResturantId);

            if (resturant == null) throw new NotFoundExceptions(nameof(Resturant), request.ResturantId.ToString());

            if (!restaurantAuthorizationService.Authorize(resturant, ResourceOperation.Delete))
                throw new ForbidException();


            await dishRepo.Delete(resturant.Dishes);
        }
    }
}
