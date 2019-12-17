using AutoMapper;
using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.Entities.Models;

namespace RestaurantsDomainLayer.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
            CreateMap<RestaurantCreationDto, Restaurant>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<AddressCreationDto, Address>().ReverseMap();
        }
    }
}
