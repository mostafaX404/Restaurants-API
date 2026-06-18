using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Command
{
    public class UpdateResturantCommandHandler(ILogger<UpdateResturantCommandHandler> logger,
        IResturantRepository resturantRepository , IMapper mapper) : IRequestHandler<UpdateResturantCommand, bool>
    {
        public async Task<bool> Handle(UpdateResturantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating the resturnat with id = {request.Id} with new data {request} ");

            var resturant = await resturantRepository.GetByIdAsync(request.Id);
            if (resturant == null)
            {
                return false;
            }

            mapper.Map(request, resturant); 
          

            return true;

        }
    }
}
