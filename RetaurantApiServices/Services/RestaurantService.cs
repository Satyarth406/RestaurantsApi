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

        public void DeleteRestaurantAsync(Restaurant deleteRestaurant)
        {
            _restaurantRepository.DeleteRestaurantAsync(deleteRestaurant);
        }

        public async void AddRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantRepository.AddRestaurantAsync(restaurant);
        }

        public async void EditRestaurantAsync(Restaurant restaurant)
        {

        }

        public async Task<bool> SaveAsync()
        {
            return await _restaurantRepository.SaveAsync();
        }
    }
}
