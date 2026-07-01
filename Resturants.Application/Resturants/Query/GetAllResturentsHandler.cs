using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Application.Common;
using Resturants.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Query
{
    internal class GetAllResturentsHandler (ILogger<GetAllResturentesQuery> ilogger ,
        IResturantRepository resturantRepository , IMapper mapper): IRequestHandler<GetAllResturentesQuery, PagedResult<ResturantDto>>
    {
       
        public async Task<PagedResult<ResturantDto>> Handle(GetAllResturentesQuery request, CancellationToken cancellationToken)
        {
            ilogger.LogInformation("Getting all resturents");

            var (resturants,totalCount) = await resturantRepository.GetAllMatchingAsync
                (request.SearchPhase,request.PageSize,request.PageNumber ,request.SortBy,request.SortDirection);

            var resturantDtos = mapper.Map<IEnumerable<ResturantDto>>(resturants);

            var result = new PagedResult<ResturantDto>(resturantDtos, totalCount, request.PageSize, request.PageNumber);

            return result;
        }
    }
}
