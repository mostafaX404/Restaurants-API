using Microsoft.EntityFrameworkCore;
using Resturants.Domain.Entities;
using Resturants.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturants.Domain.Interfaces;
namespace Resturants.Infrastructure.Repositories
{
    internal class ResturantRepository(ResturantDbContext _dbContext) : IResturantRepository
    {
        public async Task<int> Create(Resturant resturant)
        {
            _dbContext.Resturants.Add(resturant);
            await _dbContext.SaveChangesAsync();
            return resturant.Id;
        }

        public async Task Delete(Resturant resturant)
        {
            _dbContext.Remove(resturant);
            await _dbContext.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<Resturant>> GetAllAsync()
        {
            var result = await _dbContext.Resturants.ToListAsync();

            return result;
        }


        public async Task<Resturant> GetByIdAsync(int id)
        {
            return await _dbContext.Resturants.Include(x=>x.Dishes).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task SaveChangers()
        {
              _dbContext.SaveChangesAsync();
        }
    }
}
