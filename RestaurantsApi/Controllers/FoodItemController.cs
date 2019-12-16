﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantsDataAccessLayer.Interfaces;
using RestaurantsDomainLayer.Entities;
using RetaurantApiServices.Interfaces;

namespace RestaurantsApi.Controllers
{
    [Route("api/restaurants/{restaurantId}/foodItems")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly IFoodItemsService _foodItemsService;
        //private readonly IFoodItemsRepository _foodItemsRepository;
        private readonly IMapper _mapper;

        public FoodItemController(IFoodItemsRepository foodItemsRepository, IMapper mapper, IFoodItemsService foodItemsService)
        {
            //_foodItemsRepository = foodItemsRepository;
            _foodItemsService = foodItemsService;
            _mapper = mapper;
        }

        [HttpGet(Name = "AllFoodItems")]
        public async Task<ActionResult<FoodItem>> GetFoodItemsForRestaurantAsync(Guid restaurantId)
        {
            var allFoodItems = await _foodItemsService.GetFoodItemsForRestaurantAsync(restaurantId);
            if (allFoodItems == null)
            {
                return NotFound("The are no food Items in the Restaurant.");
            }
            return Ok(allFoodItems);
        }
    }
}