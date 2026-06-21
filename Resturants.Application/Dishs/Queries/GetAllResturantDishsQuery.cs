using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Dishs.Queries
{
    public class GetAllResturantDishsQuery(int id) : IRequest<IEnumerable<DishDto>>
    {
        public int ResturantId { get; set; } = id;
    }
}
