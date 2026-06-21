
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Entities;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Interfaces;

namespace Resturants.Application.Dishs.Queries
{
    public class GetResturantDishByIdQueryHandler(ILogger<GetResturantDishByIdQueryHandler> logger,
        IResturantRepository resturantRepo , IMapper mapper) : IRequestHandler<GetResturantDishByIdQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetResturantDishByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"getting the dish id : {request.DishId} in the resturant with id : {request.ResturantId}");

            var resturant = await resturantRepo.GetByIdAsync(request.ResturantId);

            if (resturant == null) throw new NotFoundExceptions(nameof(Resturant),request.ResturantId.ToString());

            var dish = resturant.Dishes.FirstOrDefault(d => d.Id == request.DishId && d.RestueantId == request.ResturantId);


            if (dish == null)
                throw new NotFoundExceptions(
                    nameof(Dish),
                    request.DishId.ToString());

            return mapper.Map<DishDto>(dish);
        }
    }
}
