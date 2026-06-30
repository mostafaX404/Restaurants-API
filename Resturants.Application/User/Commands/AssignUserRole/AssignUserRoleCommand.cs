using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.User.Commands.AssignUserRole
{
    public class AssignUserRoleCommand  : IRequest
    {
        public string Email { get; set; }
        public string RoleName { get; set; }

    }
}
