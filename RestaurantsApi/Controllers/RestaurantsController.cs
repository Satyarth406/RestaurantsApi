using AutoMapper;
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
            if (restaurantCreationDto == null)
            {
                return BadRequest();
            }

            var restaurant = _mapper.Map<Restaurant>(restaurantCreationDto);
            _restaurantRepository.AddRestaurantAsync(restaurant);
            if (await _restaurantRepository.Save())
            {
                throw new Exception("Creating a Restaurant failed to save. Please try again later");
            }

            var restaurantToReturn = _mapper.Map<RestaurantDto>(restaurant);
            return CreatedAtRoute("GetRestaurant", new { id = restaurant.ID }, restaurantToReturn);
        }

        
        }

        /// <summary>
        /// Delete restaurant with the given id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteRestaurent")]
        public async Task<ActionResult<Restaurant>> DeleteRestaurantAsync(Guid id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantAsync(id);

            if(restaurant == null)
            {
                return NotFound($"The restaurant with the given {id} is not present");
            }

            _restaurantRepository.DeleteRestaurantAsync(restaurant);
            return NoContent();
        }

        /// <summary>
        /// Update restaurant with the given id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="restaurantCreationDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Restaurant>> UpdateRestaurantAsync(Guid id, RestaurantCreationDto restaurantCreationDto)
        {
            if (restaurantCreationDto == null)
            {
                return BadRequest();
            }

            var restaurantSaved = await _restaurantRepository.GetRestaurantAsync(id);

            if(restaurantSaved == null)
            {
                return NotFound($"The restaurant with the given {id} is not present");
            }

            _mapper.Map(restaurantCreationDto, restaurantSaved);
            _restaurantRepository.EditRestaurantAsync(restaurantSaved);
            _restaurantRepository.AddRestaurantAsync(restaurantSaved);

            await _restaurantRepository.Save();
            return CreatedAtRoute("GetRestaurant", new { id = restaurantSaved.ID }, _mapper.Map<RestaurantDto>(restaurantSaved));
        }
    }
}