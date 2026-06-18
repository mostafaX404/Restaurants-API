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
    internal class DeleteResturantHandler(ILogger<DeleteResturantHandler> logger,
        IResturantRepository resturantRepository) : IRequestHandler<DeleteResturantCommand,bool>
    {
        public async Task<bool> Handle(DeleteResturantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting the resturnat with id : {request.Id}");

            var resturant =await resturantRepository.GetByIdAsync(request.Id);

            if (resturant == null) {
                return false;
            }

            await resturantRepository.SaveChangers();


            return true;    
        }
    }
}
