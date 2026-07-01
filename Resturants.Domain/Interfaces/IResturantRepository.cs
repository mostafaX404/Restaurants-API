using Resturants.Domain.Entities;
using Resturants.Domain.Constants;
using Resturants.Application.Common;

namespace Resturants.Domain.Interfaces
{
    public interface IResturantRepository
    {
        Task<IEnumerable<Resturant>> GetAllAsync();

        Task<Resturant> GetByIdAsync(int id);

        Task<int> Create(Resturant resturant);

        Task Delete(Resturant resturant);

        Task SaveChangers();

        Task<(IEnumerable<Resturant>,int)> GetAllMatchingAsync(string? searchPhase,int PageSize , int PageNumber,string? SortBy ,SortDirection sortDirection );


    }
}


