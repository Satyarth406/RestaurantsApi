using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantsDomainLayer.Entities.Models
{
    /// <summary>
    /// Resturant with Name, Type, AverageCost, Rating
    /// </summary>
    public class RestaurantDto
    {
        /// <summary>
        /// Name of the restaurant
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Type of the restaurant
        /// </summary>
        public FoodType Type { get; set; }

        /// <summary>
        /// Average cost of the restaurant
        /// </summary>
        [Range(0.0, Double.MaxValue)]
        public int AverageCost { get; set; }

        /// <summary>
        /// Average Rating of the restaurants
        /// </summary>
        [Range(1, 5)]
        public double Rating { get; set; }

        /// <summary>
        /// Address of the restaurant
        /// </summary>
        [Required]
        public AddressDto Location { get; set; }
    }
}
