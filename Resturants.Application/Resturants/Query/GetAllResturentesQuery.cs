using MediatR;
using Resturants.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Query
{
    public class GetAllResturentesQuery : IRequest<PagedResult<ResturantDto>>
    {
        public string? SearchPhase { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string? SortBy { get; set; }

        public SortDirection SortDirection { get; set; }
    }
}
