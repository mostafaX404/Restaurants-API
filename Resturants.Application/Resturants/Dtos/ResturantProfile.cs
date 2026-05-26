
using AutoMapper;
using Resturants.Application.Resturants.Dtos;
using Resturants.Domain.Entities;

public class ResturantProfile  : Profile
    {
    public ResturantProfile()
    {
        CreateMap<CreateResturantDto, Resturant>().ForMember(d=>d.Address , 
            opt => opt.MapFrom(s=> new Address
            {
                Street = s.Street,
                City = s.City,
                PostalCode = s.PostalCode,
            }));

        CreateMap<Resturant, ResturantDto>()
            .ForMember(d=>d.Street , opt => opt.MapFrom(s=> s.Address.Street == null ? null : s.Address.Street))
            .ForMember(d => d.Street, opt => opt.MapFrom(s => s.Address.PostalCode == null ? null : s.Address.PostalCode))
            .ForMember(d => d.Street, opt => opt.MapFrom(s => s.Address.City == null ? null : s.Address.City))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(s => s.Dishes == null ? null : s.Dishes));
    }


}
