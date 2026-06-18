using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Query
{
    public class GetResturantByIdQuery(int id) : IRequest<ResturantDto>
    {
        public int Id { get; } = id;
    }
}
