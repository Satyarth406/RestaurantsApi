using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.Entities.Models;
using RetaurantApiServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsApi.Controllers
{
    [Route("api/restaurants/{restaurantId}/foodItems")]
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
        [HttpGet("{foodItemId}", Name = "GetFoodItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FoodItemDto>> GetFoodItemForRestaurantAsync(Guid restaurantId, Guid foodItemId)
        {
            var restaurant = await _restaurantService.GetRestaurantAsync(restaurantId);
            if (restaurant == null)
            {
                return BadRequest("The given restaurant doesn't exists");
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
        public async Task<ActionResult<FoodItemDto>> CreateFoodItemForRestaurantAsync(Guid restaurantId, FoodItemCreationDto foodItemCreateDto)
        {
            var restaurant = await _restaurantService.GetRestaurantAsync(restaurantId);
            if (restaurant == null)
            {
                return BadRequest("The given restaurant doesn't exists");
            }
            var foodItemCreate = _mapper.Map<FoodItem>(foodItemCreateDto);
            _foodItemsService.AddFoodItemToRestaurantAsync(restaurantId, foodItemCreate);
            if (!await _foodItemsService.SaveAsync())
            {
                throw new Exception("Something went wrong");
            }
            var foodItemDto = _mapper.Map<FoodItemDto>(foodItemCreate);
            return CreatedAtRoute("GetFoodItem", new { restaurantId = restaurantId, foodItemId = foodItemCreate.Id }, foodItemDto);
        }


        /// <summary>
        /// Get food item available in the restaurant.
        /// </summary>
        /// <param name="restaurantId">The id of the restaurant</param>
        /// <returns>This will return the corresponding food item of given restaurant</returns>
        [HttpDelete("{foodItemId}", Name = "DeleteFoodItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteFoodItemForRestaurantAsync(Guid restaurantId, Guid foodItemId)
        {
            var restaurant = await _restaurantService.GetRestaurantAsync(restaurantId);
            if (restaurant == null)
            {
                return NotFound("The given restaurant doesn't exist");
            }
            var foodItem = await _foodItemsService.GetFoodItemForRestaurantAsync(restaurantId, foodItemId);
            if (foodItem == null)
            {
                return NotFound("The given food item doesn't exist");

            }
            _foodItemsService.DeleteFoodItemForRestaurantAsync(foodItem);
            if (!await _foodItemsService.SaveAsync())
            {
                throw new Exception("Something went wrong");
            }
            return NoContent();
            
        }


        /// <summary>
        /// Update food item of the restaurant
        /// </summary>
        /// <param name="restaurantId">The id of the restaurant</param>
        /// <param name="foodItemId">The id of the food Item</param>
        /// <param name="foodItemCreationDto">The food item to be updated</param>
        /// <returns></returns>
        [HttpPut("{foodItemId}",Name = "UpdateFoodItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateFoodItemForRestaurantAsync(Guid restaurantId,Guid foodItemId, FoodItemCreationDto foodItemCreationDto)
        {
            var restaurant = await _restaurantService.GetRestaurantAsync(restaurantId);
            if (restaurant == null)
            {
                return BadRequest("The given restaurant doesn't exists");
            }

            var foodItem = await _foodItemsService.GetFoodItemForRestaurantAsync(restaurantId, foodItemId);
            _mapper.Map(foodItemCreationDto, foodItem);
            await _foodItemsService.EditFoodItemForRestaurantAsync(foodItem);
            if (!await _foodItemsService.SaveAsync())
            {
                throw new Exception("Something went wrong");
            }
            return NoContent();
        }

    }
}