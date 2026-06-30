using Microsoft.AspNetCore.Authorization;

namespace Resturants.Infrastructure.Authorization.Requirements;

    public class MinimumAgeRequirement(int minimumAge)  :IAuthorizationRequirement
    {
    public int MinimumAge { get;} = minimumAge;

}

