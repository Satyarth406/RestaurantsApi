using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.HelperModels;
using System;
using System.Threading.Tasks;

namespace RetaurantApiServices.Interfaces
{
    public interface IRestaurantService
    {
        Task<PagedList<Restaurant>> GetRestaurantsAsync(RestaurantParams restaurantParams);
        Task<Restaurant> GetRestaurantAsync(Guid restaurantId);
        void DeleteRestaurant(Restaurant getRestaurant);
        void AddRestaurant(Restaurant restaurant);
        void EditRestaurant(Restaurant restaurant);
        Task<bool> SaveAsync();

    }
}
