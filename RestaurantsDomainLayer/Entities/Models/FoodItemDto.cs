using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestaurantsDomainLayer.Entities.Models
{
    /// <summary>
    /// FoodItem dto class containing Id, Name, Rating and cost
    /// </summary>
    public class FoodItemDto
    {
        /// <summary>
        /// The id of the Food Item
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the food item
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// The rating of the Food Item
        /// </summary>
        [Range(1, 5)]
        public double Rating { get; set; }

        /// <summary>
        /// The cost of the Food Item
        /// </summary>
        public int Cost { get; set; }


    }
}
