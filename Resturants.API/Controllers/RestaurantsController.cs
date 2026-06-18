using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturants.Application.Resturants;
using Resturants.Application.Resturants.Command;
using Resturants.Application.Resturants.Dtos;
using Resturants.Application.Resturants.Query;
using Resturants.Domain.Entities;

namespace Resturants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController( IMediator mediator) : ControllerBase
    {

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllResturentesQuery());
            return Ok(result);  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await mediator.Send( new GetResturantByIdQuery(id));

            if (result is null) return NotFound();

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await mediator.Send(new DeleteResturantCommand(id));

            if (result) return NoContent();

            return NotFound();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id , UpdateResturantCommand command)
        {
            var result = await mediator.Send(command);

            if (result) return NoContent();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateResturantCommand command)
        {
            int id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
