using AutoMapper;
using RestaurantsDomainLayer.Entities.Models;
using RestaurantsDomainLayer.Model;

namespace RestaurantsDomainLayer.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Restaurant, RestaurantDto>();
            this.CreateMap<RestaurantCreationDto, Restaurant>().ReverseMap();
            this.CreateMap<Address, AddressCreationDto>().ReverseMap();
        }
    }
}
