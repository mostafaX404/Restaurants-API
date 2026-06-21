
using Resturants.Domain.Entities;

namespace Resturants.Domain.Interfaces
{
    public interface IDishRepository
    {

        public Task<int> Create(Dish dish);

        public Task Delete(IEnumerable<Dish> entities);

    }
}
