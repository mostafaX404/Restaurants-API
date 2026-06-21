
using MediatR;

namespace Resturants.Application.Dishs.Queries
{
    public record GetResturantDishByIdQuery(
        int ResturantId,
        int DishId) : IRequest<DishDto>;
}
