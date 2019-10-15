using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestaurantsDomainLayer.Model
{
    public class Restaurant
    {
        public Restaurant()
        {
            FoodItems = new List<FoodItem>();
            Location = new Address();
        }

        [Key]
        public Guid ID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public FoodType Type { get; set; }
        [MinLength(1)]
        public int AverageCost { get; set; }
        [MaxLength(150)]
        public int DeliveryTime { get; set; }
        [Range(1,5)]
        public double Rating { get; set; }
        public virtual List<FoodItem> FoodItems { get; set; }
        public virtual Address Location { get; set; }

    }
}
