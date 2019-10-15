using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationAndAuthorizationLibrary.Model;
using RestaurantsDataAccessLayer.Interfaces;

namespace RestaurantsDataAccessLayer.Repositories
{
    public class RestaurantsRepository : IRestaurantRepository
    {
        public List<Restaurant> Restaurants = new List<Restaurant>()
        {
            new Restaurant()
            {
                ID = Guid.NewGuid(), Name = "Truffles", Rating = 4.3, Location = new Address()
                {
                    Line1 = "St. Marks Road",
                    Line2 = "Central Bangalore",
                    City = "Bangalore",
                    State = "Karnataka",
                    Country = "India",
                },
                Type = FoodType.American | FoodType.Chinese | FoodType.Desserts,
                Image =
                    "https://res.cloudinary.com/swiggy/image/upload/fl_lossy,f_auto,q_auto,w_508,h_320,c_fill/sqy0lylcewphzxvljxsg",

                FoodItems = new List<FoodItem>()
                {
                    new FoodItem()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Veg Burger",
                        Cost = 129,
                        Rating = 4.4,

                        Image =
                            "https://res.cloudinary.com/swiggy/image/upload/fl_lossy,f_auto,q_auto,w_366,h_240,c_fill/bjmsrpelu21yncn9idr1"
                    },
                    new FoodItem()
                    {
                        ID = Guid.NewGuid(),
                        Cost = 200,
                        Rating = 4.3,
                        Image =
                            "https://res.cloudinary.com/swiggy/image/upload/fl_lossy,f_auto,q_auto,w_366,h_240,c_fill/umqlmm1ltapmcbbyvxnu"
                    },
                    new FoodItem()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Dragon Paneer",
                        Cost = 186,
                        Rating = 4.6,
                    }
                }
            },
            new Restaurant()
            {
                ID = Guid.NewGuid(), Name = "Meghana Foods", Rating = 4.4, Location = new Address()
                {
                    Line1 = "Residency Road",
                    Line2 = "Central Bangalore",
                    City = "Bangalore",
                    State = "Karnataka",
                    Country = "India",
                },
                Type = FoodType.NorthIndian,
                Image =
                    "https://res.cloudinary.com/swiggy/image/upload/fl_lossy,f_auto,q_auto,w_366,h_240,c_fill/hyezrfzwomzezlyxkfr7",

                FoodItems = new List<FoodItem>()
                {
                    new FoodItem()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Gobi Chilli",
                        Cost = 209,
                        Rating = 4.0,
                        Image =
                            "https://res.cloudinary.com/swiggy/image/upload/fl_lossy,f_auto,q_auto,w_366,h_240,c_fill/hyezrfzwomzezlyxkfr7"
                    },
                    new FoodItem()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Boneless Chicken Biryani",
                        Cost = 248,
                        Rating = 4.8,

                        Image =
                            "https://res.cloudinary.com/swiggy/image/upload/fl_lossy,f_auto,q_auto,w_366,h_240,c_fill/skgngivbcdhkpfi3oo2u"
                    },
                    new FoodItem()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Jeera Rice",
                        Cost = 150,
                        Rating = 4.6,

                        Image =
                            "https://res.cloudinary.com/swiggy/image/upload/fl_lossy,f_auto,q_auto,w_366,h_240,c_fill/v9kbmlerfd56tufd0qzl"
                    }
                }
            }
        };

        public Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            Restaurants.Add(restaurant);
            return Task.FromResult(restaurant);
        }

        public Task<Restaurant> DeleteRestaurantAsync(Guid restaurantId)
        {
            var restaurantToDelete = Restaurants.FirstOrDefault(t => t.ID == restaurantId);
            Restaurants.Remove(restaurantToDelete);
            return Task.FromResult(restaurantToDelete);
        }

        public Task<Restaurant> EditRestaurantAsync(Restaurant restaurant)
        {
            return Task.FromResult((Restaurant) null);
        }

        public Task<Restaurant> GetRestaurantAsync(Guid restaurantId)
        {
            return Task.FromResult<Restaurant>(Restaurants.First(t => t.ID == restaurantId));
        }

        public Task<List<Restaurant>> GetRestaurantsAsync()
        {
            return Task.FromResult(Restaurants);
        }
    }
}
