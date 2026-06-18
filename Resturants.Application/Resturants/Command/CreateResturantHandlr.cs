using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Entities;
using Resturants.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Command
{
    public class CreateResturantHandlr(ILogger<CreateResturantHandlr> ilogger , 
        IMapper mapper , IResturantRepository resturantRepository) : IRequestHandler<CreateResturantCommand, int>
    {
        public async Task<int> Handle(CreateResturantCommand request, CancellationToken cancellationToken)
        {
            ilogger.LogInformation($"Craeting new resturant = {request}");
            var resturant = mapper.Map<Resturant>(request);
            return await resturantRepository.Create(resturant);

        }
    }
}
