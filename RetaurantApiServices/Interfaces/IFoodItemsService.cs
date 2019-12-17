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
        void DeleteFoodItemForRestaurantAsync(Guid restaurantId);
        void AddFoodItemToRestaurantAsync(Guid restaurantId,FoodItem foodItem);
        Task<Restaurant> EditFoodItemForRestaurantAsync(Restaurant restaurant);
        Task<bool> SaveAsync();
    }
}
