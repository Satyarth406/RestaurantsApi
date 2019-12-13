using RestaurantsDomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsDataAccessLayer.Interfaces
{
    public interface IFoodItemsRepository
    {
        Task<List<FoodItem>> GetFoodItemsForRestaurantAsync(Guid restaurantI);
        Task<FoodItem> GetFoodItemForRestaurantAsync(Guid restaurantId,Guid foodItemId);
        void DeleteFoodItemForRestaurantAsync(Guid restaurantId);
        void AddFoodItemToRestaurantAsync(Guid restaurantId,FoodItem foodItem);
        Task<Restaurant> EditFoodItemForRestaurantAsync(Restaurant restaurant);
        Task<bool> Save();
    }
}
