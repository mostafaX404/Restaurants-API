using AutoMapper;
using Microsoft.Extensions.Logging;
using Resturants.Application.Resturants.Dtos;
using Resturants.Domain.Entities;
using Resturants.Domain.Interfaces;
namespace Resturants.Application.Resturants
{
    public class ResturantService(IResturantRepository resturantRepository,
        ILogger<ResturantService> ilogger , IMapper mapper) : IResturantService

    {
        public async Task<int> CreateResturant(CreateResturantDto dto)
        {
            ilogger.LogInformation("Craeting new resturant");
            var resturant = mapper.Map<Resturant>(dto);
            return await resturantRepository.Create(resturant);
        }

        public async Task<IEnumerable<ResturantDto>> GetAllResturents()
        {
            ilogger.LogInformation("Getting all resturents");

            var result = await resturantRepository.GetAllAsync();

            var resturantDto = mapper.Map<IEnumerable<ResturantDto>>(result);

            return resturantDto;
        }

        public async Task<ResturantDto> GetResturant(int id)
        {
            ilogger.LogInformation($"getting resturant with id = {{id}}");

            var result = await resturantRepository.GetByIdAsync(id);

            var resturantDto = mapper.Map<ResturantDto>(result);

            return resturantDto;
        }
    }
}
