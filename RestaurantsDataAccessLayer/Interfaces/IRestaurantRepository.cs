using RestaurantsDomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsDataAccessLayer.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRestaurantsAsync();
        Task<Restaurant> GetRestaurantAsync(Guid restaurantId);
        void DeleteRestaurantAsync(Guid restaurantId);
        void AddRestaurantAsync(Restaurant restaurant);
        Task<Restaurant> EditRestaurantAsync(Restaurant restaurant);
        Task<bool> Save();

    }
}
