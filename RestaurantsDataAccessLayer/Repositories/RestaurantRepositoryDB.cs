using Microsoft.EntityFrameworkCore;
using RestaurantsDataAccessLayer.DbContext;
using RestaurantsDataAccessLayer.Interfaces;
using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.HelperModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsDataAccessLayer.Repositories
{
    public class RestaurantsRepositoryDb : IRestaurantRepository
    {
        private readonly RestaurantsDbContext _restaurantsDbContext;

        public RestaurantsRepositoryDb(RestaurantsDbContext restaurantsDbContext)
        {
            _restaurantsDbContext = restaurantsDbContext;
        }


        public async Task<List<Restaurant>> GetRestaurantsAsync(RestaurantParams restaurantParams)
        {
            return await _restaurantsDbContext.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantAsync(Guid restaurantId)
        {
            var restaurant = await _restaurantsDbContext.Restaurants.FindAsync(restaurantId);
            return restaurant;
        }

        public void DeleteRestaurantAsync(Restaurant getRestaurant)
        {
            _restaurantsDbContext.Restaurants.Remove(getRestaurant);
        }

        public async void AddRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantsDbContext.Restaurants.AddAsync(restaurant);
        }

        public async void EditRestaurantAsync(Restaurant restaurant)
        {
           
        }

        public async Task<bool> Save()
        {
            return await _restaurantsDbContext.SaveChangesAsync() > 0;
        }
    }
}
