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

namespace Resturants.Application.Resturants.Query
{
    public class GetResturantByIdHandler(ILogger<GetResturantByIdHandler> ilogger,
        IResturantRepository resturantRepository , IMapper mapper) : IRequestHandler<GetResturantByIdQuery, ResturantDto>
    {
        public async Task<ResturantDto> Handle(GetResturantByIdQuery request, CancellationToken cancellationToken)
        {
            ilogger.LogInformation($"getting resturant with id = {{id}}");

            var result = await resturantRepository.GetByIdAsync(request.Id) 
                ?? throw  new NotFoundExceptions(nameof(Resturant), request.Id.ToString());

            var resturantDto = mapper.Map<ResturantDto>(result);

            return resturantDto;
        }
    }
}
