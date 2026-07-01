using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Resturants.Application.Common;
using Resturants.Domain.Entities;
using Resturants.Domain.Interfaces;
using Resturants.Infrastructure.Presistence;
using System.Linq.Expressions;

namespace Resturants.Infrastructure.Repositories
{
    public class ResturantRepository(ResturantDbContext _dbContext) : IResturantRepository
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
            var result = await _dbContext.Resturants.Include(r=>r.Dishes).ToListAsync();

            return result;
        }


        public async Task<(IEnumerable<Resturant>,int)> GetAllMatchingAsync(string? searchPhase,
            int PageSize,
            int pageNumber , string? sortBy, SortDirection sortDirection)
        {
            var searchPhaseLower = searchPhase?.ToLower();

            var baseQuery = _dbContext.Resturants.Include(r => r.Dishes).Where(r => searchPhaseLower != null || (r.Name.ToLower().Contains(searchPhaseLower) ||
                r.Description.ToLower().Contains(searchPhaseLower)));

            var totalCount = await baseQuery.CountAsync();

            if (sortBy != null)
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Resturant, object>>>
                {
                    { nameof(Resturant.Name), r => r.Name },
                    { nameof(Resturant.Description), r => r.Description },
                    { nameof(Resturant.Category), r => r.Category },
                };

                var selectedColumn = columnsSelector[sortBy];

                baseQuery = sortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var result = await baseQuery
                .Skip(PageSize * (pageNumber-1))
                .Take(PageSize)
                .ToListAsync()  ;

            return (result,totalCount);
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
