using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturants.Application.Resturants;
using Resturants.Application.Resturants.Dtos;
using Resturants.Domain.Entities;

namespace Resturants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(IResturantService resturantService) : ControllerBase
    {

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await resturantService.GetAllResturents();
            return Ok(result);  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await resturantService.GetResturant(id);

            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateResturantDto dto)
        {
            int id = await resturantService.CreateResturant(dto);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
