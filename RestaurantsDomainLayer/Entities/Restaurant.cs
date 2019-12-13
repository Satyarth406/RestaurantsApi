using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantsDomainLayer.Entities
{
    public class Restaurant
    {
        public Restaurant()
        {
            FoodItems = new List<FoodItem>();
            Location = new Address();
        }

        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public FoodType Type { get; set; }
        [MinLength(1)]
        public int AverageCost { get; set; }
        [MaxLength(150)]
        public int DeliveryTime { get; set; }
        [Range(1,5)]
        public double Rating { get; set; }
        public List<FoodItem> FoodItems { get; set; }
        public Address Location { get; set; }

    }
}
