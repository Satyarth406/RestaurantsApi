using Microsoft.EntityFrameworkCore;
using RestaurantsDataAccessLayer.DbContext;
using RestaurantsDataAccessLayer.Interfaces;
using RestaurantsDomainLayer.Entities;
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


        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            return await _restaurantsDbContext.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantAsync(Guid restaurantId)
        {
            var restaurant = await _restaurantsDbContext.Restaurants.FindAsync(restaurantId);
            return restaurant;
        }

        public async void DeleteRestaurantAsync(Guid restaurantId)
        {
            var getRestaurant = await _restaurantsDbContext.Restaurants.FindAsync(restaurantId);
            _restaurantsDbContext.Restaurants.Remove(getRestaurant);
        }

        public async void AddRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantsDbContext.Restaurants.AddAsync(restaurant);
        }

        public Task<Restaurant> EditRestaurantAsync(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            return await _restaurantsDbContext.SaveChangesAsync() > 0;
        }
    }
}
