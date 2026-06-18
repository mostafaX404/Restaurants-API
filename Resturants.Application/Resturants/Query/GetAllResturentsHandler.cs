using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Query
{
    internal class GetAllResturentsHandler (ILogger<GetAllResturentesQuery> ilogger ,
        IResturantRepository resturantRepository , IMapper mapper): IRequestHandler<GetAllResturentesQuery, IEnumerable<ResturantDto>>
    {
       
        public async Task<IEnumerable<ResturantDto>> Handle(GetAllResturentesQuery request, CancellationToken cancellationToken)
        {
            ilogger.LogInformation("Getting all resturents");

            var result = await resturantRepository.GetAllAsync();

            var resturantDtos = mapper.Map<IEnumerable<ResturantDto>>(result);

            return resturantDtos;
        }
    }
}
