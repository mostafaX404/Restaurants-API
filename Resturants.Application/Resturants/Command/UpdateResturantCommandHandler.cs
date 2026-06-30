using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Constants;
using Resturants.Domain.Entities;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Command
{
    public class UpdateResturantCommandHandler(ILogger<UpdateResturantCommandHandler> logger,
        IResturantRepository resturantRepository , IMapper mapper,
        IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<UpdateResturantCommand>
    {
        public async Task Handle(UpdateResturantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating the resturnat with id = {request.Id} with new data {request} ");



            var resturant = await resturantRepository.GetByIdAsync(request.Id)
                ?? throw new NotFoundExceptions(nameof(Resturant), request.Id.ToString());

            if (!restaurantAuthorizationService.Authorize(resturant, ResourceOperation.Update))
                throw new ForbidException();


            mapper.Map(request, resturant); 
          

        

        }
    }
}
