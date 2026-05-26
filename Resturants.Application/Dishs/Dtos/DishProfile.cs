
using AutoMapper;
using Resturants.Domain.Entities;

public class DishProfile : Profile    {

    public DishProfile()
    {
        CreateMap<Dish, DishDto>();
    }



}
