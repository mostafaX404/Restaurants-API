using Resturants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Domain.Interfaces
{
    public interface IResturantRepository
    {
        Task<IEnumerable<Resturant>> GetAllAsync();

        Task<Resturant> GetByIdAsync(int id);

        Task<int> Create(Resturant resturant);

        Task Delete(Resturant resturant);

        Task SaveChangers();

    }
}


