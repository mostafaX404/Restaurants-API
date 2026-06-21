
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Entities;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Interfaces;

namespace Resturants.Application.Dishs.Commands.DeleteDishes
{
    public class DeleteAllDishesOfResturantCommandHandler(ILogger<DeleteAllDishesOfResturantCommandHandler> logger,
        IDishRepository dishRepo ,IResturantRepository resturantRepo) : IRequestHandler<DeleteAllDishesOfResturantCommand>
    {
        public async Task Handle(DeleteAllDishesOfResturantCommand request, CancellationToken cancellationToken)
        {
            var resturant = await resturantRepo.GetByIdAsync(request.ResturantId);

            if (resturant == null) throw new NotFoundExceptions(nameof(Resturant), request.ResturantId.ToString());

            await dishRepo.Delete(resturant.Dishes);
        }
    }
}
