using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Restaurants.Infrastructure.Seeders;
using Resturants.API.Middlewares;
using Resturants.Application.Extensions;
using Resturants.Domain.Entities;
using Resturants.Infrastructure.Extensions;
using Resturants.Infrastructure.Presistence;
using Resturants.Infrastructure.Seeders;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Threading.Tasks;
using Resturants.API.NewFolder;
namespace Resturants.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddPresentation();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
                await seeder.Seed();
            }

            // Configure the HTTP request pipeline.
            app.UseMiddleware<GlobalExceptionMiddle>();
            app.UseMiddleware<TimeLoggingMiddle>();

            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapGroup("api/identity").MapIdentityApi<AppUser>();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
