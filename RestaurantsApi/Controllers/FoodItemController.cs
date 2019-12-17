using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantsDataAccessLayer.Interfaces;
using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.Entities.Models;
using RetaurantApiServices.Interfaces;

namespace RestaurantsApi.Controllers
{
    [Route("api/restaurants/{restaurantId}/foodItems")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly IFoodItemsService _foodItemsService;
        private readonly IRestaurantService _restaurantService;

        private readonly IMapper _mapper;

        public FoodItemController(IMapper mapper, IFoodItemsService foodItemsService, IRestaurantService restaurantService)
        {

            _foodItemsService = foodItemsService;
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all food item of the given id of the restaurant.
        /// </summary>
        /// <param name="restaurantId">The id of the restaurant.</param>
        /// <returns>This will return all the food item of given restaurant</returns>
        [HttpGet(Name = "AllFoodItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<FoodItemDto>>> GetFoodItemsForRestaurantAsync(Guid restaurantId)
        {
            var allFoodItems = await _foodItemsService.GetFoodItemsForRestaurantAsync(restaurantId);
            if (allFoodItems == null)
            {
                return NotFound("The are no food Items in the Restaurant.");
            }

            var foodItemsDto = _mapper.Map<List<FoodItemDto>>(allFoodItems);
            return Ok(foodItemsDto);
        }

        /// <summary>
        /// Get food item available in the restaurant.
        /// </summary>
        /// <param name="restaurantId">The id of the restaurant</param>
        /// <param name="foodItemId">The id of the foodItem</param>
        /// <returns>This will return the corresponding food item of given restaurant</returns>
        [HttpGet("{foodItemId}", Name = "FoodItemById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FoodItemDto>> GetFoodItemForRestaurantAsync(Guid restaurantId, Guid foodItemId)
        {
            var restaurant = await _restaurantService.GetRestaurantAsync(restaurantId);
            if (restaurant == null)
            {
                return BadRequest("The given restaurant doesnt exists");
            }
            var foodItem = await _foodItemsService.GetFoodItemForRestaurantAsync(restaurantId, foodItemId);
            if (foodItem == null)
            {
                return NotFound($"The food item with the given food item {foodItemId} and restaurant {restaurantId} is not present");
            }
            var foodItemDto = _mapper.Map<FoodItemDto>(foodItem);
            return Ok(foodItemDto);
        }


        /// <summary>
        /// Get food item available in the restaurant.
        /// </summary>
        /// <param name="restaurantId">The id of the restaurant</param>
        /// <returns>This will return the corresponding food item of given restaurant</returns>
        [HttpPost(Name = "CreateFoodItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<FoodItemDto>> CreateFoodItemForRestaurantAsync(Guid restaurantId, FoodItemCreateDto foodItemCreateDto)
        {
            var restaurant = await _restaurantService.GetRestaurantAsync(restaurantId);
            if (restaurant == null)
            {
                return BadRequest("The given restaurant doesn't exists");
            }
            var foodItemCreate = _mapper.Map<FoodItem>(foodItemCreateDto);
            _foodItemsService.AddFoodItemToRestaurant(restaurantId, foodItemCreate);
            if (!await _foodItemsService.SaveAsync())
            {
                throw new Exception("Something went wrong");
            }
            var foodItemDto = _mapper.Map<FoodItemDto>(foodItemCreate);
            return CreatedAtAction("FoodItemById", new { restaurantId = restaurantId, foodItemId = foodItemCreate.Id }, foodItemDto);

        }
    }
}