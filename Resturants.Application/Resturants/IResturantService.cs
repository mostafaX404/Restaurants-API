using Resturants.Application.Resturants.Dtos;
using Resturants.Domain.Entities;

namespace Resturants.Application.Resturants
{
    public interface IResturantService
    {
        Task<IEnumerable<ResturantDto>> GetAllResturents();

        Task<ResturantDto> GetResturant(int id);

        Task<int> CreateResturant(CreateResturantDto dto);
    }
}