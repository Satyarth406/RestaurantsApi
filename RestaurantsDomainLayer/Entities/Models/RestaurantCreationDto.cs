using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantsDomainLayer.Entities.Models
{
    /// <summary>
    /// Dto to create the restaurant
    /// </summary>
    public class RestaurantCreationDto
    {
        /// <summary>
        /// Name of the Restaurant
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        public FoodType Type { get; set; }

        [Range(0.0, Double.MaxValue)]
        public double AverageCost { get; set; }

        [Range(1, 5)]
        public double Rating { get; set; }

        [Required]
        public virtual AddressCreationDto Location { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
    }
}
