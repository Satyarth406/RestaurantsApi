﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantsDataAccessLayer.Interfaces;
using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.Entities.Models;
using System;
using System.Threading.Tasks;

namespace RestaurantsApi.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    [Authorize]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantsController(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all the restaurants in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "AllRestaurants")]
        public async Task<ActionResult<Restaurant>> GetAllRestaurantsAsync()
        {
            var allRestaurants = await _restaurantRepository.GetRestaurantsAsync();
            if (allRestaurants == null)
            {
                return NotFound("The are no restaurants in the DB");
            }
            return Ok(allRestaurants);
        }


        /// <summary>
        /// Get restaurant with the given id in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetRestaurant")]
        public async Task<ActionResult<Restaurant>> GetRestaurantAsync(Guid id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantAsync(id);
            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            if (restaurantDto == null)
            {
                return NotFound($"The restaurant with the given {id} is not present");
            }
            return Ok(restaurantDto);
        }


        /// <summary>
        /// Get all the restaurants in the database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Restaurant>> AddRestaurantAsync(RestaurantCreationDto restaurantCreationDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantCreationDto);
            _restaurantRepository.AddRestaurantAsync(restaurant);
            if (await _restaurantRepository.Save())
            {
                throw new Exception("Creating a Restaurant failed to save. Please try again later");
            }
            var restaurantToReturn = _mapper.Map<RestaurantDto>(restaurant);
            return CreatedAtRoute("GetRestaurant", new { id = restaurant.Id }, restaurantToReturn);
        }
    }
}