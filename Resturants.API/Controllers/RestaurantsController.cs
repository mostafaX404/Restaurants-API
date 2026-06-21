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
        public async Task<ActionResult<IEnumerable<ResturantDto>>> GetAll()
        {
            var result = await mediator.Send(new GetAllResturentesQuery());
            return Ok(result);  
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResturantDto?>> GetById([FromRoute] int id)
        {
            var result = await mediator.Send( new GetResturantByIdQuery(id));

            if (result is null) return NotFound();

            return Ok(result);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await mediator.Send(new DeleteResturantCommand(id));

            return NotFound();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] int id , UpdateResturantCommand command)
        {
           await mediator.Send(command);

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
