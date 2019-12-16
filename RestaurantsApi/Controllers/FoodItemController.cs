using System;
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
        //private readonly IFoodItemsRepository _foodItemsRepository;
        private readonly IMapper _mapper;

        public FoodItemController(IFoodItemsRepository foodItemsRepository, IMapper mapper, IFoodItemsService foodItemsService)
        {
            //_foodItemsRepository = foodItemsRepository;
            _foodItemsService = foodItemsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all food item of the given id of the restaurant.
        /// </summary>
        /// <param name="restaurantId">The id of the restaurant.</param>
        /// <returns>This will return all the food item of given restaurant</returns>
        [HttpGet(Name = "AllFoodItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FoodItem>> GetFoodItemsForRestaurantAsync(Guid restaurantId)
        {
            var allFoodItems = await _foodItemsService.GetFoodItemsForRestaurantAsync(restaurantId);
            if (allFoodItems == null)
            {
                return NotFound("The are no food Items in the Restaurant.");
            }
            return Ok(allFoodItems);
        }

        /// <summary>
        /// Get food item available in the restaurant.
        /// </summary>
        /// <param name="restaurantId">The id of the restaurant.</param>
        /// <param name="foodItemId">The id of the restaurant.</param>
        /// <returns>This will return all the food item of given restaurant</returns>
        [HttpGet("restaurantId,foodItemId}", Name = "FoodItemById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FoodItem>> GetFoodItemForRestaurantAsync(Guid restaurantId, Guid foodItemId)
        {
            var fooditem = await _foodItemsRepository.GetFoodItemsForRestaurantAsync(restaurantId, foodItemId);
            var fooditemDto = _mapper.Map<FoodItemDto>(restaurant);
            if (fooditemDto == null)
            {
                return NotFound($"The food item with the given food item {foodItemId} and restaurant {restaurantId} is not present");
            }
            return Ok(fooditemDto);
        }
    }
}