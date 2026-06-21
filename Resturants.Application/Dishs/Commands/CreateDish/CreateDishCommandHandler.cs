
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Entities;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Interfaces;

namespace Resturants.Application.Dishs.Commands.CreateDish
{
    public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger,
        IResturantRepository resturantRepo , IDishRepository dishRepository , IMapper mapper) : IRequestHandler<CreateDishCommand,int>
    {
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            var resturant = await resturantRepo.GetByIdAsync(request.ResturantId);

            if (resturant == null) {
                throw new NotFoundExceptions(nameof(Resturant), request.ResturantId.ToString());
            }

            var dish = mapper.Map<Dish>(request);
            dish.RestueantId = request.ResturantId;
            return await dishRepository.Create(dish);
        }
    }
}
