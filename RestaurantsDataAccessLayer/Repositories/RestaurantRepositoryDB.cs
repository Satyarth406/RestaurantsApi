using Microsoft.EntityFrameworkCore;
using RestaurantsDataAccessLayer.DbContext;
using RestaurantsDataAccessLayer.Interfaces;
using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public async Task<PagedList<Restaurant>> GetRestaurantsAsync(RestaurantParams restaurantParams)
        {
            return await PagedList<Restaurant>.Create(_restaurantsDbContext.Restaurants,restaurantParams.PageNumber,restaurantParams.PageSize);
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

        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantsDbContext.Restaurants.AddAsync(restaurant);
        }

        public async void EditRestaurantAsync(Restaurant restaurant)
        {
           
        }

        public async Task<bool> SaveAsync()
        {
            return await _restaurantsDbContext.SaveChangesAsync() > 0;
        }
    }
}
