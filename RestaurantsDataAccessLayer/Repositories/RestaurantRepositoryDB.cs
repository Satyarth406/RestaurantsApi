using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantsDataAccessLayer.DbContext;
using RestaurantsDataAccessLayer.Interfaces;
using RestaurantsDomainLayer.Model;

namespace RestaurantsDataAccessLayer.Repositories
{
    public class RestaurantsRepositoryDB : IRestaurantRepository
    {
        private readonly RestaurantsDbContext _restaurantsDbContext;

        public RestaurantsRepositoryDB(RestaurantsDbContext restaurantsDbContext)
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
