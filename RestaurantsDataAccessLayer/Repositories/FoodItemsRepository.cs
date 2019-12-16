﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using RestaurantsDataAccessLayer.DbContext;
using RestaurantsDataAccessLayer.Interfaces;
using RestaurantsDomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace RestaurantsDataAccessLayer.Repositories
{
    public class FoodItemsRepository : IFoodItemsRepository
    {
        private readonly RestaurantsDbContext _restaurantsDbContext;

        public FoodItemsRepository(RestaurantsDbContext restaurantsDbContext)
        {
            _restaurantsDbContext = restaurantsDbContext;
        }
        public async Task<List<FoodItem>> GetFoodItemsForRestaurantAsync(Guid restaurantId)
        {
            var allFoodItems = await _restaurantsDbContext.FoodItems.Where(x => x.RestaurantId == restaurantId).ToListAsync();
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

        public async Task<bool> SaveAsync()
        {
            return await _restaurantsDbContext.SaveChangesAsync() > 0;
        }

        public Task<FoodItem> GetFoodItemForRestaurantAsync(Guid restaurantId, Guid foodItemId)
        {
            throw new NotImplementedException();
        }
    }
}
