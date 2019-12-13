using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantsDataAccessLayer.Interfaces;
using RestaurantsDomainLayer.Entities;

namespace RestaurantsApi.Controllers
{
    [Route("api/restaurants/{restaurantId}/foodItems")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly IFoodItemsRepository _foodItemsRepository;
        private readonly IMapper _mapper;

        public FoodItemController(IFoodItemsRepository foodItemsRepository, IMapper mapper)
        {
            _foodItemsRepository = foodItemsRepository;
            _mapper = mapper;
        }
    }
}