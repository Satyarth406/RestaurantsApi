using RestaurantsDomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantsDataAccessLayer.DbContext;
using RestaurantsDataAccessLayer.Interfaces;
using RetaurantApiServices.Interfaces;

namespace RetaurantApiServices.Services
{
    public class FoodItemsService : IFoodItemsService
    {
        private readonly IFoodItemsRepository _foodItemsRepository;

        public FoodItemsService(IFoodItemsRepository foodItemsRepository)
        {
            _foodItemsRepository = foodItemsRepository;
            _foodItemsRepository = foodItemsRepository;
        }
        public async Task<List<FoodItem>> GetFoodItemsForRestaurantAsync(Guid restaurantId)
        {
            var allFoodItems = await _foodItemsRepository.GetFoodItemsForRestaurantAsync(restaurantId);
            return allFoodItems;
        }


        public void DeleteFoodItemForRestaurantAsync(Guid restaurantId)
        {
            throw new NotImplementedException();
        }

        public void AddFoodItemToRestaurantAsync(Guid restaurantId, FoodItem foodItem)
        {
            throw new NotImplementedException();
        }

        public Task<Restaurant> EditFoodItemForRestaurantAsync(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            return await _foodItemsRepository.SaveAsync();
        }

        public Task<FoodItem> GetFoodItemForRestaurantAsync(Guid restaurantId, Guid foodItemId)
        {
            throw new NotImplementedException();
        }
    }
}
