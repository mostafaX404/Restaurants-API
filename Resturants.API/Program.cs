using Microsoft.EntityFrameworkCore;
using Restaurants.Infrastructure.Seeders;
using Resturants.Infrastructure.Extensions;
using Resturants.Application.Extensions;
using Resturants.Infrastructure.Presistence;
using Resturants.Infrastructure.Seeders;
using System.Threading.Tasks;
namespace Resturants.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddInfrastructure(builder.Configuration); 
            builder.Services.AddServicesExtensions();
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
                await seeder.Seed();
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
