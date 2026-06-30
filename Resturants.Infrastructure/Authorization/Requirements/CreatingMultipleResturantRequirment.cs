using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Infrastructure.Authorization.Requirements
{
    public class CreatingMultipleResturantRequirment(int minimumResturnatCreated) : IAuthorizationRequirement
    {
        public int MinimumRestaurantsCreated { get; } =minimumResturnatCreated;
    }
}
