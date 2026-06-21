using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Seeders;
using Resturants.Infrastructure.Presistence;
using Resturants.Infrastructure.Seeders;
using Resturants.Infrastructure.Repositories;
using Resturants.Domain.Interfaces;
using Resturants.Domain.Entities;
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

            services.AddIdentityApiEndpoints<AppUser>().AddEntityFrameworkStores<ResturantDbContext>();

            return services;
        }
    }
}