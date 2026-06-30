using Resturants.Domain.Entities;
using Resturants.Domain.Constants;



public interface IRestaurantAuthorizationService
{
    bool Authorize(Resturant restaurant,  ResourceOperation resourceOperation);
}