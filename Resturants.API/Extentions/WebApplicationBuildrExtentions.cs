using Microsoft.OpenApi.Models;
using Resturants.API.Middlewares;
using Resturants.Application.Extensions;
using Resturants.Infrastructure.Extensions;
using Serilog;
using System.Runtime.CompilerServices;

namespace Resturants.API.NewFolder
{
    public static class WebApplicationBuildrExtentions
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddAuthentication();
            builder.Services.AddControllers();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddServicesExtensions();
            builder.Services.AddScoped<GlobalExceptionMiddle>();
            builder.Services.AddScoped<TimeLoggingMiddle>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearerAuth"
                }
            },
            []
        }
    });
            });
            builder.Host.UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
            });


        }
    }
}
