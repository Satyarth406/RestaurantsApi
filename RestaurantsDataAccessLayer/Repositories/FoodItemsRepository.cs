using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestaurantsDataAccessLayer.Interfaces;
using RestaurantsDomainLayer.Entities;

namespace RestaurantsDataAccessLayer.Repositories
{
    public class FoodItemsRepository:IFoodItemsRepository
    {
        public Task<List<FoodItem>> GetFoodItemsForRestaurantAsync(Guid restaurantI)
        {
            throw new NotImplementedException();
        }

        public Task<FoodItem> GetFoodItemForRestaurantAsync(Guid restaurantId, Guid foodItemId)
        {
            throw new NotImplementedException();
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

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }
    }
}
