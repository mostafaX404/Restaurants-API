using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Seeders;
using Resturants.Domain.Entities;
using Resturants.Domain.Interfaces;
using Resturants.Infrastructure.Authorization;
using Resturants.Infrastructure.Authorization.Requirements;
using Resturants.Infrastructure.Presistence;
using Resturants.Infrastructure.Repositories;
using Resturants.Infrastructure.Seeders;
namespace Resturants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            services.AddDbContext<ResturantDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging());

            services.AddScoped<ISeeder, Seeder>();
            services.AddScoped<IResturantRepository, ResturantRepository>();
            services.AddScoped<IDishRepository, DishRepository>();

            services.AddIdentityApiEndpoints<AppUser>()
                .AddRoles<IdentityRole>()
                .AddClaimsPrincipalFactory<RestaurantsUserClaimsPrincipalFactory>()
                .AddEntityFrameworkStores<ResturantDbContext>();

            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();

            //second param is the value of "Nationality"  must be
            services.AddAuthorizationBuilder()
                .AddPolicy(PolicyNames.HasNationality, b => b.RequireClaim(AppClaimTypes.Nationality))
                .AddPolicy(PolicyNames.AtLeast20, b => b.AddRequirements(new MinimumAgeRequirement(20)))
                .AddPolicy(PolicyNames.CreatedAtLeast2Resturants, b=>b.AddRequirements(new CreatingMultipleResturantRequirment(2)));
                
            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, CreatedMultipleRestaurantsRequirementHandler>();
            services.AddScoped<IRestaurantAuthorizationService, RestaurantAuthorizationService>();
            
            return services;
        }
    }
}