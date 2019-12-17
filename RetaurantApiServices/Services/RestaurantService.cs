using RestaurantsDataAccessLayer.DbContext;
using RestaurantsDomainLayer.Entities;
using RestaurantsDomainLayer.HelperModels;
using RetaurantApiServices.Interfaces;
using System;
using System.Threading.Tasks;
using RestaurantsDataAccessLayer.Interfaces;

namespace RestaurantsDataAccessLayer.Repositories
{
    public class RestaurantsService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantsService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<PagedList<Restaurant>> GetRestaurantsAsync(RestaurantParams restaurantParams)
        {
            return await _restaurantRepository.GetRestaurantsAsync(restaurantParams);
        }

        public async Task<Restaurant> GetRestaurantAsync(Guid restaurantId)
        {
            var restaurant = await _restaurantRepository.GetRestaurantAsync(restaurantId);
            return restaurant;
        }

        public void DeleteRestaurant(Restaurant deleteRestaurant)
        {
            _restaurantRepository.DeleteRestaurant(deleteRestaurant);
        }

        public  void AddRestaurant(Restaurant restaurant)
        {
             _restaurantRepository.AddRestaurant(restaurant);
        }

        public void EditRestaurant(Restaurant restaurant)
        {

        }

        public async Task<bool> SaveAsync()
        {
            return await _restaurantRepository.SaveAsync();
        }
    }
}
