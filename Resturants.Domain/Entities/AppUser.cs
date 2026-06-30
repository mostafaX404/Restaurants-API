using Microsoft.AspNetCore.Identity;

namespace Resturants.Domain.Entities
{
    public class AppUser :IdentityUser
    {

        public DateOnly? DateOfBirth { get; set; }

        public string? Nationality { get; set; }

        public List<Resturant> OwndeResturants { get; set; } = [];

    }

}
