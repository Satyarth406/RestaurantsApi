using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestaurantsDomainLayer.Entities.Models
{
    public class FoodItemDto
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(1, 5)]
        public double Rating { get; set; }

        
        public int Cost { get; set; }


    }
}
