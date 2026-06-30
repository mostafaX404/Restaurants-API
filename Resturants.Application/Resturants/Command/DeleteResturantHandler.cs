using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Entities;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Interfaces;
using Resturants.Domain.Constants;
namespace Resturants.Application.Resturants.Command
{
    internal class DeleteResturantHandler(ILogger<DeleteResturantHandler> logger,
        IResturantRepository resturantRepository, 
        IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<DeleteResturantCommand>
    {
        public async Task Handle(DeleteResturantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting the resturnat with id : {request.Id}");

            var resturant =await resturantRepository.GetByIdAsync(request.Id)
                ??  throw new  NotFoundExceptions(nameof(Resturant), request.Id.ToString()); ;

            if (!restaurantAuthorizationService.Authorize(resturant, ResourceOperation.Delete))
                throw new ForbidException();

            await resturantRepository.SaveChangers();


            
        }
    }
}
