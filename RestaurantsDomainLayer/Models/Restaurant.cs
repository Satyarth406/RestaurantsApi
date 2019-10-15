using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationAndAuthorizationLibrary.Model
{
    public class Restaurant
    {
        public Restaurant()
        {
            FoodItems = new List<FoodItem>();
            Location = new Address();
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public FoodType Type { get; set; }
        public int AverageCost { get; set; }
        public int DeliveryTime { get; set; }
        public double Rating { get; set; }
        public List<FoodItem> FoodItems { get; set; }
        public string Image { get; set; }
        public Address Location { get; set; }

    }
}
