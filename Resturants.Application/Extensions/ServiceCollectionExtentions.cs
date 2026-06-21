using Microsoft.Extensions.DependencyInjection;
using Resturants.Application.Resturants;
using FluentValidation;
using Resturants.Application.Resturants.Command;
using MediatR;
using Resturants.Application.User;
namespace Resturants.Application.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtentions).Assembly;

           services.AddMediatR(conf => conf.RegisterServicesFromAssembly(applicationAssembly));
            services.AddAutoMapper(applicationAssembly);

            services.AddAutoMapper(applicationAssembly);
            
            services.AddValidatorsFromAssemblyContaining<CreateResturentCommandValidations>();

            services.AddScoped<IUserContext, UserContext>();
            services.AddHttpContextAccessor();
            
            
            return services;
        }
    }
}