using AutoMapper;
using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.Entities.Models;

namespace RestaurantsDomainLayer.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantCreationDto, Restaurant>().ReverseMap();
            CreateMap<Address, AddressCreationDto>().ReverseMap();
        }
    }
}
