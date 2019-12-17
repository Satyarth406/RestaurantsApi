﻿using RestaurantsDomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsDataAccessLayer.Interfaces
{
    public interface IFoodItemsRepository
    {
        Task<List<FoodItem>> GetFoodItemsForRestaurantAsync(Guid restaurantId);
        Task<FoodItem> GetFoodItemForRestaurantAsync(Guid restaurantId,Guid foodItemId);
        void DeleteFoodItemForRestaurant(Guid restaurantId);
        void AddFoodItemToRestaurant(Guid restaurantId,FoodItem foodItem);
        Task<Restaurant> EditFoodItemForRestaurantAsync(Restaurant restaurant);
        Task<bool> SaveAsync();
    }
}
