using Microsoft.Extensions.DependencyInjection;
using Resturants.Application.Resturants;

namespace Resturants.Application.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services)
        {
            services.AddScoped<IResturantService, ResturantService>();
            services.AddAutoMapper(typeof(ServiceCollectionExtentions).Assembly);
            return services;

        }
    }
}