using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AuthorizationAndAuthorizationLibrary.Model;

namespace RestaurantsDataAccessLayer.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRestaurantsAsync();
        Task<Restaurant> GetRestaurantAsync(Guid restaurantId);
        Task<Restaurant> DeleteRestaurantAsync(Guid restaurantId);
        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);
        Task<Restaurant> EditRestaurantAsync(Restaurant restaurant);
    }
}
