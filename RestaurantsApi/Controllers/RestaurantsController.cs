using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantsDataAccessLayer.Interfaces;
using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.Entities.Models;
using RestaurantsDomainLayer.HelperModels;
using RetaurantApiServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsApi.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        //private readonly IRestaurantRepository _restaurantRepository;
        private readonly IRestaurantService _restaurantService;

        private readonly IMapper _mapper;
        private readonly IUrlHelper _urlHelper;

        public RestaurantsController(IRestaurantRepository restaurantRepository, IMapper mapper, IUrlHelper urlHelper, IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
            _urlHelper = urlHelper;
        }

        /// <summary>
        /// Get all the restaurants in the database
        /// </summary>
        /// <returns>Returns all the restaurants</returns>
        /// <response code="200">Returns all the restaurants</response>
        [HttpGet(Name = "AllRestaurants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RestaurantDto>>> GetAllRestaurantsAsync([FromQuery]RestaurantParams restaurantParams)
        {
            var allRestaurants = await _restaurantService.GetRestaurantsAsync(restaurantParams);
            if (allRestaurants == null)
            {
                return NotFound("The are no restaurants in the DB");
            }
            var allRestaurantsDto = _mapper.Map<List<RestaurantDto>>(allRestaurants);
            return Ok(allRestaurantsDto);
        }


        /// <summary>
        /// Get restaurant with the given id in the db
        /// </summary>
        /// <param name="id">The id of the restaurant</param>
        /// <returns>Returns a restaurant with the given id</returns>
        /// <response code="200">Returns the restaurant with the given id</response>
        [HttpGet("{id}", Name = "GetRestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RestaurantDto>> GetRestaurantAsync(Guid id)
        {
            var restaurant = await _restaurantService.GetRestaurantAsync(id);
            if (restaurant == null)
            {
                return NotFound($"The restaurant with the given {id} is not present");
            }
            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            return Ok(restaurantDto);
        }


        /// <summary>
        /// Add the given restaurant to the db
        /// </summary>
        /// <param name="restaurantCreationDto">Restaurant to add</param>
        /// <returns>Returns the added restaurant</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<RestaurantDto>> AddRestaurantAsync(RestaurantCreationDto restaurantCreationDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantCreationDto);
            _restaurantService.AddRestaurant(restaurant);
            if (await _restaurantService.SaveAsync())
            {
                throw new Exception("Creating a Restaurant failed to save. Please try again later");
            }
            var restaurantToReturn = _mapper.Map<RestaurantDto>(restaurant);
            return CreatedAtRoute("GetRestaurant", new { id = restaurant.Id }, restaurantToReturn);
        }


        /// <summary>
        /// Delete restaurant with the given id in the database
        /// </summary>
        /// <param name="id">The id of the restaurant to be deleted</param>
        /// <returns>This will delete the Resturant</returns>
        [HttpDelete("{id}", Name = "DeleteRestaurent")]
        public async Task<ActionResult> DeleteRestaurantAsync(Guid id)
        {
            var restaurant = await _restaurantService.GetRestaurantAsync(id);

            if (restaurant == null)
            {
                return NotFound($"The restaurant with the given {id} is not present");
            }

            _restaurantService.DeleteRestaurant(restaurant);

            if (await _restaurantService.SaveAsync())
            {
                throw new Exception("Failed to delete restaurant. Please try again later");
            }
            return NoContent();
        }


        /// <summary>
        /// Update restaurant with the given id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="restaurantCreationDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<RestaurantDto>> UpdateRestaurantAsync(Guid id, RestaurantCreationDto restaurantCreationDto)
        {
            var restaurantSaved = await _restaurantService.GetRestaurantAsync(id);

            if (restaurantSaved == null)
            {
                return NotFound($"The restaurant with the given {id} is not present");
            }

            _mapper.Map(restaurantCreationDto, restaurantSaved);
            _restaurantService.EditRestaurantAsync(restaurantSaved);

            if (await _restaurantService.SaveAsync())
            {
                throw new Exception("Failed to update Restaurant. Please try again later");
            }

            return CreatedAtRoute("GetRestaurant", new { id = restaurantSaved.Id }, _mapper.Map<RestaurantDto>(restaurantSaved));
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="restaurantPatchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult<Restaurant>> PartiallyUpdateRestaurantAsync(Guid id, JsonPatchDocument<RestaurantCreationDto> restaurantPatchDoc)
        {
            var restaurantInDb = await _restaurantService.GetRestaurantAsync(id);

            if (restaurantInDb == null)
            {
                return NotFound($"The restaurant with the given {id} is not present");
            }
            var restaurantCreationDto = _mapper.Map<RestaurantCreationDto>(restaurantInDb);

            restaurantPatchDoc.ApplyTo(restaurantCreationDto);

            _mapper.Map(restaurantCreationDto, restaurantInDb);
            _restaurantService.EditRestaurantAsync(restaurantInDb);

            if (await _restaurantService.SaveAsync())
            {
                throw new Exception("Failed to update Restaurant. Please try again later");
            }

            return NoContent();
        }
    }
}