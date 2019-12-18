using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantsDomainLayer.Entities;

namespace RetaurantApiServices.Interfaces
{
    public interface IFoodItemsService
    {
        Task<List<FoodItem>> GetFoodItemsForRestaurantAsync(Guid restaurantId);
        Task<FoodItem> GetFoodItemForRestaurantAsync(Guid restaurantId,Guid foodItemId);
        void DeleteFoodItemForRestaurantAsync(FoodItem foodItem);
        void AddFoodItemToRestaurantAsync(Guid restaurantId,FoodItem foodItem);
        Task<Restaurant> EditFoodItemForRestaurantAsync(FoodItem foodItem);
        Task<bool> SaveAsync();
    }
}
