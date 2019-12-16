using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantsDataAccessLayer.Interfaces;
using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.Entities.Models;
using RestaurantsDomainLayer.HelperModels;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyModel.Resolution;

namespace RestaurantsApi.Controllers
{
    [Route("api/restaurants")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        private readonly IUrlHelper _urlHelper;

        public RestaurantsController(IRestaurantRepository restaurantRepository, IMapper mapper, IUrlHelper urlHelper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
            _urlHelper = urlHelper;
        }

        /// <summary>
        /// Get all the restaurants in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "AllRestaurants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Restaurant>> GetAllRestaurantsAsync([FromQuery]RestaurantParams restaurantParams)
        {
            var allRestaurants = await _restaurantRepository.GetRestaurantsAsync(restaurantParams);
            
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
        [ProducesResponseType(StatusCodes.Status200OK)]
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
            return CreatedAtRoute("GetRestaurant", new { id = restaurant.Id }, restaurantToReturn);
        }


        /// <summary>
        /// Delete restaurant with the given id in the database
        /// </summary>
        /// <param name="id">The id of the restaurant to be deleted</param>
        /// <returns>This will delete the Resturant</returns>
        [HttpDelete("{id}", Name = "DeleteRestaurent")]
        public async Task<ActionResult<Restaurant>> DeleteRestaurantAsync(Guid id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantAsync(id);

            if (restaurant == null)
            {
                return NotFound($"The restaurant with the given {id} is not present");
            }

            _restaurantRepository.DeleteRestaurantAsync(restaurant);

            if (await _restaurantRepository.Save())
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
        public async Task<ActionResult<Restaurant>> UpdateRestaurantAsync(Guid id, RestaurantCreationDto restaurantCreationDto)
        {
            ////Satyarth - see if this is really needed or not.
            if (restaurantCreationDto == null)
            {
                return BadRequest();
            }

            var restaurantSaved = await _restaurantRepository.GetRestaurantAsync(id);

            if (restaurantSaved == null)
            {
                return NotFound($"The restaurant with the given {id} is not present");
            }

            _mapper.Map(restaurantCreationDto, restaurantSaved);
            _restaurantRepository.EditRestaurantAsync(restaurantSaved);

            if (await _restaurantRepository.Save())
            {
                throw new Exception("Failed to update Restaurant. Please try again later");
            }

            return CreatedAtRoute("GetRestaurant", new { id = restaurantSaved.Id }, _mapper.Map<RestaurantDto>(restaurantSaved));
        }



        [HttpPatch("{id}")]
        public async Task<ActionResult<Restaurant>> PartiallyUpdateRestaurantAsync(Guid id, JsonPatchDocument<RestaurantCreationDto> restaurantPatchDoc)
        {
            var restaurantInDb = await _restaurantRepository.GetRestaurantAsync(id);

            if (restaurantInDb == null)
            {
                return NotFound($"The restaurant with the given {id} is not present");
            }
            var restaurantCreationDto = _mapper.Map<RestaurantCreationDto>(restaurantInDb);

            restaurantPatchDoc.ApplyTo(restaurantCreationDto);

            _mapper.Map(restaurantCreationDto, restaurantInDb);
            _restaurantRepository.EditRestaurantAsync(restaurantInDb);

            if (await _restaurantRepository.Save())
            {
                throw new Exception("Failed to update Restaurant. Please try again later");
            }

            return NoContent();
        }
    }
}