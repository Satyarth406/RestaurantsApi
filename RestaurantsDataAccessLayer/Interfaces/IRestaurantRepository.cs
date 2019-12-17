using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.HelperModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsDataAccessLayer.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<PagedList<Restaurant>> GetRestaurantsAsync(RestaurantParams restaurantParams);
        Task<Restaurant> GetRestaurantAsync(Guid restaurantId);
        void DeleteRestaurant(Restaurant getRestaurant);
        void AddRestaurant(Restaurant restaurant);
        void EditRestaurantAsync(Restaurant restaurant);
        Task<bool> SaveAsync();

    }
}
