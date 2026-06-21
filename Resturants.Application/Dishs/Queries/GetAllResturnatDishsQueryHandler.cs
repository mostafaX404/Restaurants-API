using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Entities;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Dishs.Queries
{
    public class GetAllResturnatDishsQueryHandler(
        IResturantRepository resturantRepo , ILogger<GetAllResturnatDishsQueryHandler> logger,
        IMapper mapper) : IRequestHandler<GetAllResturantDishsQuery, IEnumerable<DishDto>>
    {
        public async Task<IEnumerable<DishDto>> Handle(GetAllResturantDishsQuery request, CancellationToken cancellationToken)
        {
            var resturant = await resturantRepo.GetByIdAsync(request.ResturantId);

            if(resturant == null) throw new NotFoundExceptions(nameof(Resturant),request.ResturantId.ToString());

            var dishes =  mapper.Map<IEnumerable<DishDto>>(resturant.Dishes);

            return dishes;
        }
    }
}
