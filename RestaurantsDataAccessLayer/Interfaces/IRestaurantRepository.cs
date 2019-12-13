using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestaurantsDomainLayer.Model;

namespace RestaurantsDataAccessLayer.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRestaurantsAsync();
        Task<Restaurant> GetRestaurantAsync(Guid restaurantId);
        void DeleteRestaurantAsync(Restaurant getRestaurant);
        void AddRestaurantAsync(Restaurant restaurant);
        void EditRestaurantAsync(Restaurant restaurant);
        Task<bool> Save();

    }
}
