
using AutoMapper;
using Resturants.Application.Dishs.Commands.CreateDish;
using Resturants.Domain.Entities;

public class DishProfile : Profile    {

    public DishProfile()
    {
        CreateMap<CreateDishCommand, Dish>();
        CreateMap<Dish, DishDto>();
    }



}
