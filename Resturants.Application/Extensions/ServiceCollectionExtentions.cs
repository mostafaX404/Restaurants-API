using Microsoft.Extensions.DependencyInjection;
using Resturants.Application.Resturants;
using FluentValidation;
using Resturants.Application.Resturants.Command;
using MediatR;
namespace Resturants.Application.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtentions).Assembly;

           services.AddMediatR(conf => conf.RegisterServicesFromAssembly(applicationAssembly));
            services.AddAutoMapper(applicationAssembly);

            
            services.AddValidatorsFromAssemblyContaining<CreateResturentCommandValidations>();
             return services;

        }
    }
}