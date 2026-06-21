using Resturants.Domain.Entities;
using Resturants.Domain.Interfaces;
using Resturants.Infrastructure.Presistence;

namespace Resturants.Infrastructure.Repositories
{
    public class DishRepository(ResturantDbContext resturantDb) : IDishRepository
    {
        public async Task<int> Create(Dish dish )
        {
            resturantDb.Add(dish);
            await resturantDb.SaveChangesAsync();

            return dish.Id;
        }

        public async Task Delete(IEnumerable<Dish> entities)
        {
             resturantDb.RemoveRange(entities);
            await resturantDb.SaveChangesAsync();
        }
    }
}
