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
        void DeleteRestaurantAsync(Restaurant getRestaurant);
        void AddRestaurantAsync(Restaurant restaurant);
        void EditRestaurantAsync(Restaurant restaurant);
        Task<bool> SaveAsync();

    }
}
