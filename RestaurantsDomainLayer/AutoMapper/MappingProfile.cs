using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RestaurantsDomainLayer.Entities.Models;
using RestaurantsDomainLayer.Model;

namespace RestaurantsDomainLayer.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Restaurant, RestaurantDto>();
            this.CreateMap<RestaurantCreationDto, Restaurant>();    
        }
    }
}
