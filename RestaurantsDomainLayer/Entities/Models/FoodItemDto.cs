using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestaurantsDomainLayer.Entities.Models
{
    class FoodItemDto
    {

        public string Name { get; set; }
        
        public double Rating { get; set; }     
        
        public int Cost { get; set; }
    }
}
