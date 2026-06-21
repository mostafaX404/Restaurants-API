using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Dishs.Commands.DeleteDishes
{
    public class DeleteAllDishesOfResturantCommand(int id):IRequest
    {
        public int ResturantId { get; } = id;
    }
}
