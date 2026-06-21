using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturants.Application.Dishs.Commands.CreateDish;
using Resturants.Application.Dishs.Commands.DeleteDishes;
using Resturants.Application.Dishs.Queries;

namespace Resturants.API.Controllers
{
    [Route("api/restaurants/{resturantId}/dishs")]
    [ApiController]
    public class DishsController(IMediator mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromRoute] int resturantId, CreateDishCommand command)
        {
            command.ResturantId = resturantId;
            var dishId = await mediator.Send(command);

            return CreatedAtAction(nameof(GetResturantDisheById),new {resturantId , dishId});
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllResturantDishs([FromRoute] int resturantId)
        {
            var result = await mediator.Send(new GetAllResturantDishsQuery(resturantId));

            return Ok(result);
        }


        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDto>> GetResturantDisheById([FromRoute] int resturantId, [FromRoute] int dishId )
        {
            var result = await mediator.Send(new GetResturantDishByIdQuery(resturantId, dishId));

            return Ok(result);
        }


        [HttpDelete("")]
        public async Task<IActionResult> DeleteAllDishesOfResturnt([FromRoute] int resturantId)
        {
            await mediator.Send(new DeleteAllDishesOfResturantCommand(resturantId));

            return NoContent();
        }
    }
}
