using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Command
{
    public class DeleteResturantCommand(int id) : IRequest<bool>
    {
        public int Id { get; } = id;
    }
}
